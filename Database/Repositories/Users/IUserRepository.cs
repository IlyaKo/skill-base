using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Users;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task Delete(int id);
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task Update(User user);
}