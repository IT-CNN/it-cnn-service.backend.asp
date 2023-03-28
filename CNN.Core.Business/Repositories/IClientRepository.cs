using CNN.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Repositories;

public interface IClientRepository
{
    Task CreateAsync(Client client);
    Task DeleteAsync(Client client);
    Task<ICollection<Client>> GetAsync();
    Task<Client?> GetAsync(Guid id);
    Task<Client?> GetAsync(string name);
    Task<Client?> GetAsync(string name, string phoneNumber);
    Task UpdateAsync(Client client);
}
