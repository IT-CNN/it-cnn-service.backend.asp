using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.WhoIAm;

public class WhoIAmHandler : IRequestHandler<WhoIAmQuery, UserOutModel>
{
    private readonly IUserRepository _repo;

    public WhoIAmHandler(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<UserOutModel> Handle(WhoIAmQuery request, CancellationToken cancellationToken)
    {
        var user = await _repo.FindByUserNameAsync(request.UserName);
        if (user == null) throw new UnauthorizedAccessException();

        return user.ToModel();
    }
}
