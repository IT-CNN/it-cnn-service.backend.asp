using CNN.Core.Business.Models.ProductModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Product> _products;


    private IQueryable<Product> _productsJoinned
    {
        get
        {
            return _products
                .Include(p => p.Prices)
                .Include(p => p.Quantities)
                .Include(p => p.Categories);
        }
    }
    public ProductRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
        _products = dbContext.Products;
    }
    public async Task<Product> CreateAsync(Product product)
    {
        await _products.AddAsync(product);
        await _context.SaveChangesAsync();
        _context.Attach(product);
        return (await _productsJoinned.FirstOrDefaultAsync(p => p.Id == product.Id))!;
    }
    public async Task<Product?> GetByNameAsync(string name) => await _productsJoinned.FirstOrDefaultAsync(p => p.Name == name);
    public async Task<ICollection<Product>> GetAllAsync() => await _productsJoinned.ToListAsync();
    public async Task<Product?> GetByIdAsync(Guid id) => await _productsJoinned.FirstOrDefaultAsync(p => p.Id == id);
    public async Task UpdateAsync(Product product)
    {
        product.UpdateAt = DateTime.UtcNow;
        _products.Update(product);
        await _context.SaveChangesAsync();
        _context.Attach(product);
    }
    public async Task DeleteAsync(Product product)
    {
        _products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
