using System.Collections.Generic;
using ClassLibrary;
namespace Repository
{
    public interface ITaskRepository : IRepository<UserTaskModel>
    {
        UserTaskModel FindTaskWithName(string name);
        IEnumerable<UserTaskModel> GetByUsername(string username);
        IEnumerable<UserTaskModel> GetTasksClosest(string username);
    }
}
