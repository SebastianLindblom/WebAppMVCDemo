using Data;
using System.Data.Entity.Validation;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TheModel _context;

        public UnitOfWork(TheModel context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Tasks = new TaskRepository(_context);
        }

        public IUserRepository Users { get; private set; }
        public ITaskRepository Tasks { get; private set; }


        public void Complete()
        {
            try
            {
                 _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine(("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage));
                    }
                }
            }
        }

        public void Dispose()
        {
            Complete();
            _context.Dispose();
        }
    }
}