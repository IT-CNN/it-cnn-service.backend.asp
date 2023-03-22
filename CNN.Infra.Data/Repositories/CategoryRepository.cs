using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Category> _categories;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
        _categories = context.Categories;
    }

    public async Task<ICollection<Category>> GetManyAsync(ICollection<Guid> categoryIds)
    {
        return await _context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();
    }
}
