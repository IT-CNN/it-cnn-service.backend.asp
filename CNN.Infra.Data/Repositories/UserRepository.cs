using CNN.Core.Business.Extensions;
using CNN.Core.Business.Helpers;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IFileHelper _fileHelper;
    private readonly IQueryable<User> _userDb;

    private IQueryable<User> UsersIncluded { get
        {
            return _userDb
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role);
        } }

    private IQueryable<User> UserActiveOrAdmin { get
        {
            return UsersIncluded
                .Where(u => u.IsActivated || u.UserRoles.FirstOrDefault(ur => ur.Role.Name == AppRoles.ADMIN) != null);
        } }

    public UserRepository(UserManager<User> userManager, RoleManager<Role> roleManager, IFileHelper fileHelper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _userDb = userManager.Users;
        _fileHelper = fileHelper;
    }

    public async Task<User> AddAsync(User user, string password, string role)
    {
        User created = await CreateUser(user, password);
        User createWithRole = await AddToRole(created, role);

        return createWithRole;
    }

    /// <summary>
    /// Add user to role
    /// </summary>
    /// <param name="created"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundEntityException"></exception>
    /// <exception cref="BadRequestException"></exception>
    private async Task<User> AddToRole(User created, string role)
    {
        var roleExist = await _roleManager.RoleExistsAsync(role);
        if (!roleExist)
        {
            Dictionary<string, string> errs = new() { { "Role", role.ToNotExistMsg()} };
            throw new NotFoundEntityException(errs);
        }

        var roleResult = await _userManager.AddToRoleAsync(created, role);
        if (!roleResult.Succeeded)
        {
            var errors = new Dictionary<string, List<string>>();
            throw new BadRequestException(errors);
        }

        return (await FindByUserName(created.UserName ?? string.Empty))!;
    }

    private static void CheckIdentityResultAndThrowException(IdentityResult identityResult)
    {
        var errors = new Dictionary<string, List<string>>();
        foreach (var error in identityResult.Errors)
        {
            switch (error.Code)
            {
                case "DuplicateEmail":
                    errors
                        .AddOrCreate(new KeyValuePair<string, string>("Email", "email".ToAlReadyExistMsg()));
                    break;
                case "InvalidEmail":
                    errors
                        .AddOrCreate(new KeyValuePair<string, string>("Email", "email".ToInvalidMsg()));
                    break;
                case "DuplicateUserName":
                    errors
                        .AddOrCreate(new KeyValuePair<string, string>("UserName", "username".ToAlReadyExistMsg()));
                    break;
                case "InvalidUserName":
                    errors
                        .AddOrCreate(new KeyValuePair<string, string>("UserName", "username".ToInvalidMsg()));
                    break;
                case "UserAlreadyInRole":
                    errors
                        .AddOrCreate(new KeyValuePair<string, string>("Role", "This creator already in role !"));
                    break;
                case "DefaultError":
                    errors
                        .AddOrCreate(new KeyValuePair<string, string>("Default", "Something went wrong !"));
                    break;
                default:
                    break;

            }
        }
        throw new BadRequestException(errors);
    }

    private async Task<User> CreateUser(User user, string password)
    {
        var identityResult = await _userManager.CreateAsync(user, password);
        if (!identityResult.Succeeded)
        {
            if (user.Picture is not null) _fileHelper.DeleteImageToServer(user.Picture);
            CheckIdentityResultAndThrowException(identityResult);
        }

        return (await FindByUserName(user.UserName ?? string.Empty))!;
    }

    public async Task<User?> FindByUserName(string userName)
    {
        return await UsersIncluded.FirstOrDefaultAsync(x => x.UserName == userName);
    }

    public async Task<User?> GetByCredentialsAsync(string userName, string password)
    {
        var user = await UserActiveOrAdmin.FirstOrDefaultAsync(u => u.UserName == userName);
        if (user == null) throw new UnauthorizedAccessException();

        var isCorrectPwd = await _userManager.CheckPasswordAsync(user, password);
        if (!isCorrectPwd) throw new UnauthorizedAccessException();

        return user;
    }
}
