using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
namespace Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Data.TheModel context) : base(context)
        {

        }

        public IEnumerable<User> GetByUsername()
        {
            return null;
        }
        public User FindUserWithUsername(string username)
        {
            return PlutoContext.User.Where(x => x.Username.Equals(username)).FirstOrDefault();
        }
        public Data.TheModel PlutoContext { get { return Context as Data.TheModel; } }
    }
}
