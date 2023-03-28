using CNN.Core.Business.Models.CategoryModel;
using CNN.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task DeleteAsync(Category exist);
    Task<Category?> GetAsync(string name);
    Task<ICollection<Category>> GetAsync();
    Task<Category?> GetAsync(Guid id);
    Task<ICollection<Category>> GetManyAsync(ICollection<Guid> categoryIds);
    Task UpdateAsync(Category category);
}
