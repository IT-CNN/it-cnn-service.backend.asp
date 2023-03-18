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

namespace CNN.Core.Business.UseCases.UserUcs.GetUsers;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, ICollection<UserOutModel>>
{
    private readonly IUserRepository _repo;

    public GetUsersHandler(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<ICollection<UserOutModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        ICollection<User> users = await _repo.GetAllAsync();
        return users.Select(u => u.ToModel()).ToList();
    }
}
