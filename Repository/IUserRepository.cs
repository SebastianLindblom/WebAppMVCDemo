using System.Collections.Generic;
using ClassLibrary;

namespace Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByUsername();
        User FindUserWithUsername(string username);
    }
}
