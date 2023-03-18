using CNN.Core.Business.Models.UserModels;
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
    Task<ICollection<UserCsvModel>> AddManyByCsvAsync(List<UserCsvModel> dataExtract, string role);
    Task<User?> FindByIdAsync(Guid id);
    Task<User?> FindByUserNameAsync(string userName);
    Task<ICollection<User>> GetAllAsync();
    Task<User?> GetByCredentialsAsync(string userName, string password);
}
