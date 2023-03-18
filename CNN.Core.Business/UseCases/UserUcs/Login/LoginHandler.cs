using CNN.Core.Business.Authentication;
using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.Login;

public class LoginHandler : IRequestHandler<LoginQuery, UserAuthOutModel>
{
    private readonly IUserRepository _repo;
    private readonly IJwtService _jwtService;

    public LoginHandler(IUserRepository repo, IJwtService jwtService)
    {
        _repo = repo;
        _jwtService = jwtService;
    }

    public async Task<UserAuthOutModel> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var credentials = request.Credentials;
        ValidatorBehavior<LoginModel>.Validate(credentials);

        User? user = await _repo.GetByCredentialsAsync(userName: credentials.UserName, password: credentials.Password);
        if (user is null) throw new UnauthorizedAccessException();

        var token = _jwtService.Generate(user, user.UserRoles.Select(ur => ur.Role).ToList());
        return user.ToAuthModel(token);
    }
}
