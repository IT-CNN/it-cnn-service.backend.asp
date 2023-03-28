using CNN.Core.Business.Repositories;
using CNN.Core.Domain;
using CNN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Infra.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<Role> _roles;

    public RoleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _roles = dbContext.Roles;
    }

    public async Task<ICollection<Role>> GetAsync() => await _roles.Where(r => r.Name != AppRoles.ADMIN).ToListAsync();
    public async Task<Role?> GetAsync(Guid id) => await _roles.Where(r => r.Name != AppRoles.ADMIN && r.Id == id).FirstOrDefaultAsync();
}
