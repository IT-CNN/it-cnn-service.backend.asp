using CNN.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Repositories;

public interface ICategoryRepository
{
    Task<ICollection<Category>> GetManyAsync(ICollection<Guid> categoryIds);
}
