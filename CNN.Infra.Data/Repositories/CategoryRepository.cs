using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task AddAsync(Category category)
    {
        _categories.Add(category);
        await _context.SaveChangesAsync();
        _context.Attach(category);
    }

    public async Task DeleteAsync(Category exist)
    {
        _categories.Remove(exist);
        await _context.SaveChangesAsync();
    }

    public async Task<Category?> GetAsync(string name) => 
        await _categories.FirstOrDefaultAsync(c => c.Name == name);

    public async Task<ICollection<Category>> GetAsync() => 
        await _categories.ToListAsync();

    public async Task<Category?> GetAsync(Guid id) =>
        await _categories.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<ICollection<Category>> GetManyAsync(ICollection<Guid> categoryIds) => 
        await _context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();

    public async Task UpdateAsync(Category category)
    {
        _categories.Update(category);
        await _context.SaveChangesAsync();
        _context.Attach(category);
    }
}
