using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
namespace Repository
{
    public class TaskRepository : Repository<UserTaskModel>, ITaskRepository
    {
        public TaskRepository(Data.TheModel context) : base(context)
        {

        }
        public Data.TheModel PlutoContext { get { return Context as Data.TheModel; } }

        public IEnumerable<UserTaskModel> GetByUsername(string username)
        {
            return PlutoContext.Task.Where(x => x.User.Username.Equals(username));
        }
        public UserTaskModel FindTaskWithName(string name)
        {
            return PlutoContext.Task.Where(x => x.TaskName.Equals(name)).FirstOrDefault();
        }
        public IEnumerable<UserTaskModel> GetTasksClosest(string username)
        {
            try
            {
                return PlutoContext.Task.Where(x => x.User.Username.Equals(username) && x.Date >= DateTime.Now).OrderBy(z => z.Date);
            }
            catch (Exception e) { throw e; }
        }

    }
}
