using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserOutModel>
{
    private readonly IUserRepository _repo;

    public GetUserByIdHandler(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<UserOutModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await _repo.FindByIdAsync(request.Id);

        if (user is null) throw new NotFoundEntityException(new Dictionary<string, string> { { "Id", request.Id.ToString().ToNotExistMsg() } });
        return user.ToModel();
    }
}
