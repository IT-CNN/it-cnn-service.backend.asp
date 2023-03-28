using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CNN.Infra.Data.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Client> _clients;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
        _clients = context.Clients;
    }

    public async Task CreateAsync(Client client)
    {
        _clients.Add(client);
        await _context.SaveChangesAsync();
        _context.Attach(client);
    }

    public async Task DeleteAsync(Client client)
    {
        _clients.Remove(client);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Client>> GetAsync() => await _clients.ToListAsync();

    public async Task<Client?> GetAsync(Guid id) => await _clients.FindAsync(id);

    public async Task<Client?> GetAsync(string name) => 
        await _clients.FirstOrDefaultAsync(c => c.Name == name);

    public async Task<Client?> GetAsync(string name, string phoneNumber) => 
        await _clients.FirstOrDefaultAsync(c => c.Name == name || c.PhoneNumber == phoneNumber);

    public async Task UpdateAsync(Client client)
    {
        client.UpdateAt = DateTime.Now;
        _clients.Update(client);
        await _context.SaveChangesAsync();
        _context.Attach(client);
    }
}
