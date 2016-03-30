using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using ClassLibrary;

namespace Service
{
    public class ServiceController
    {
        public ServiceController()
        {

        }



        //Add
        public void AddPersonal(User p)
        {
            using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
            {
                unitOfWork.Users.Add(p);
            }
        }
        public void AddTask(UserTaskModel t)
        {
            if (LoggedIn.IsLoggedIn_())
            {
                using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
                {
                    t.UserId = FindUserFromUsername(LoggedIn.Username).UserId;
                    unitOfWork.Tasks.Add(t);
                }
            }
        }


        //Edit

        //Find

        public User FindUserFromUsername(string username)
        {
            using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
            {
                return unitOfWork.Users.FindUserWithUsername(username);
            }
        }



        public User FindUserFromId(int? id)
        {
            using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
            {
                return unitOfWork.Users.Get(id);
            }
        }
        public UserTaskModel FindTaskFromId(int? id)
        {
            if (LoggedIn.IsLoggedIn_())
            {
                using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
                {
                    return unitOfWork.Tasks.Get(id);
                }
            }
            return new UserTaskModel();
        }

        //Delete

        public void RemoveUser(int? id)
        {
            using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
            {
                unitOfWork.Tasks.Remove(unitOfWork.Tasks.Get(id));
            }
        }

        public void RemoveTask(int? id)
        {
            if (LoggedIn.IsLoggedIn_())
            {
                using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
                {
                    unitOfWork.Tasks.Remove(unitOfWork.Tasks.Get(id));
                }
            }
        }
        public void RemoveTask(string id)
        {
            int i = int.Parse(id);
            if (LoggedIn.IsLoggedIn_())
            {
                using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
                {
                    unitOfWork.Tasks.Remove(unitOfWork.Tasks.Get(i));
                }
            }
        }

        //List
        public IEnumerable<ClassLibrary.User> GetUsers()
        {
            using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
            {
                return unitOfWork.Users.GetAll();
            }
        }


        public IEnumerable<UserTaskModel> GetTasksClosest()
        {
            if (LoggedIn.IsLoggedIn_())
            {
                using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
                {
                    return unitOfWork.Tasks.GetTasksClosest(LoggedIn.Username).ToList();
                }
            }
            else return new List<UserTaskModel>();
        }

        //Utility


        public bool IsLoggedIn()
        {
            return LoggedIn.IsLoggedIn_();
        }
        public User LogIn(string username)
        {
            using (var unitOfWork = new UnitOfWork(new Data.TheModel()))
            {
                User u = unitOfWork.Users.FindUserWithUsername(username);
                if (u != null) { new LoggedIn(username); }
                return u;
            }
        }
        public void LogOut() { LoggedIn.LogOutSource(); }
    }

}
