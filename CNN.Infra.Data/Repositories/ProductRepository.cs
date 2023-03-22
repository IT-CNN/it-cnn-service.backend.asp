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

    public async Task<Product?> GetByNameAsync(string name)
    {
        return await _productsJoinned
            .FirstOrDefaultAsync(p => p.Name == name);
    }
}
