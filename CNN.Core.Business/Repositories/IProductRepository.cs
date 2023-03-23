using CNN.Core.Business.Models.ProductModel;
using CNN.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product);
    Task DeleteAsync(Product product);
    Task<ICollection<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task<Product?> GetByNameAsync(string name);
    Task UpdateAsync(Product product);
}
