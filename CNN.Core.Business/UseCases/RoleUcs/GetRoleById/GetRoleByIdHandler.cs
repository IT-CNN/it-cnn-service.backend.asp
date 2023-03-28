using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.RoleModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.RoleUcs.GetRoleById;

public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, RoleOutModel>
{
    private readonly IRoleRepository _repo;

    public GetRoleByIdHandler(IRoleRepository repo)
    {
        _repo = repo;
    }

    public async Task<RoleOutModel> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        Role? role = await _repo.GetAsync(request.Id);
        return role == null
            ? throw new NotFoundEntityException(new Dictionary<string, string> { { "Id", "This role doesn't exist !"} })
            : role.ToModel();
    }
}
