using CNN.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Repositories;

public interface IUserRepository
{
    Task<User> AddAsync(User user, string password, string role);
    Task<User?> FindByUserName(string userName);
    Task<User?> GetByCredentialsAsync(string userName, string password);
}
