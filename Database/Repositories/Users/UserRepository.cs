using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Users;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppContext context) : base(context)
    {

    }

    public async Task<User> Create(User user)
        => await base.AddAsync(user);

    public async Task Update(User user)
        => await base.UpdateAsync(user);

    public async Task<List<User>> GetAll()
        => await base.GetAllAsync();

    public async Task<User> GetById(int id)
        => await base.FindByIdAsync(id);

    public async Task Delete(int id)
    {
        var user = await base.FindByIdAsync(id);
        if (user != null)
        {
            await base.DeleteAsync(user);
        }
    }
}
