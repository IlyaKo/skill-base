using Domain;
using Microsoft.EntityFrameworkCore;
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
        => await base.GetAllAsync().ToListAsync();

    public async Task<User> GetById(int id)
        => await base.FindById(id).FirstOrDefaultAsync();

    public async Task Delete(int id)
    {
        var user = await base.FindById(id).FirstOrDefaultAsync();
        if (user != null)
        {
            await base.DeleteAsync(user);
        }
    }
}
