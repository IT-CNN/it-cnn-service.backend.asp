using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.RoleModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using MediatR;

namespace CNN.Core.Business.UseCases.RoleUcs.GetRolesQuery;

public class GetRolesHandler : IRequestHandler<GetRolesQuery, ICollection<RoleOutModel>>
{
    private readonly IRoleRepository _repo;

    public GetRolesHandler(IRoleRepository repo)
    {
        _repo = repo;
    }

    public async Task<ICollection<RoleOutModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        ICollection<Role> roles = await _repo.GetAsync();
        return roles.Select(r => r.ToModel()).ToList();
    }
}
