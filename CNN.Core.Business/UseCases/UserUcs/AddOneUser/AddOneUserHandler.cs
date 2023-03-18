using CNN.Core.Business.Helpers;
using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using CNN.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNN.Core.Business.Extensions;

namespace CNN.Core.Business.UseCases.UserUcs.AddOneUser;

public class AddOneUserHandler : IRequestHandler<AddOneUserCommand, UserOutModel>
{
    private readonly IUserRepository _repo;
    private readonly IFileHelper _fileHelper;

    public AddOneUserHandler(IUserRepository repo, IFileHelper fileHelper)
    {
        _repo = repo;
        _fileHelper = fileHelper;
    }

    public async Task<UserOutModel> Handle(AddOneUserCommand request, CancellationToken cancellationToken)
    {
        var model = request.User;
        var role = request.Role;

        ValidatorBehavior<UserInModel>.Validate(model);

        if (role == AppRoles.ADMIN) throw new UnauthorizedAccessException();
        string? picture = null;

        if (model.Picture is not null)
        {
            var result = await _fileHelper.SaveImageToServerAsync(model.Picture, new[] { role, "pictures" });
            picture = result.Item1;
        }

        var user = new User()
        {
            UserName = model.UserName,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            BirthDate = model.BirthDate,
        };
        if (picture != null) user.Picture = picture;

        try
        {
            User created = await _repo.AddAsync(user, model.Password ?? DefaultParams.defaultPwd, role);

            return created.ToModel();
        }
        catch (NotFoundEntityException ex)
        {
            if (picture is not null) _fileHelper.DeleteImageToServer(picture);
            throw new NotFoundEntityException(ex.Errors);
        }
    }
}
