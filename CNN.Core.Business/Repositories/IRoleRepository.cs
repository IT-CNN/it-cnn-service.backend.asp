using CNN.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Repositories;

public interface IRoleRepository
{
    Task<ICollection<Role>> GetAsync();
    Task<Role?> GetAsync(Guid id);
}
