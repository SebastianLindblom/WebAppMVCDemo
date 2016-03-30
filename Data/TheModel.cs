namespace Data
{
    using System.Data.Entity;
    using ClassLibrary;
    using System.Collections.Generic;
    public partial class TheModel : DbContext
    {
        public TheModel()  : base("name=TheModel")
        {
            System.AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, ""));
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<TheModel>(new DBInitializer());
        }
  
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserTaskModel> Task { get; set; }

        public class DBInitializer : DropCreateDatabaseIfModelChanges<TheModel>
        {
            protected override void Seed(TheModel context)
            {

                IList<User> defaultUser = new List<User>();
                defaultUser.Add(new User() { Username = "Lorem" });
                defaultUser.Add(new User() { Username = "Wendy" });
                defaultUser.Add(new User() { Username = "Daniel" });

                IList<UserTaskModel> defaultTask = new List<UserTaskModel>();
                defaultTask.Add(new UserTaskModel() { TaskName = "Buy food", Date = System.DateTime.Now.AddDays(1), Where = "The store", UserId = 1 } );
                defaultTask.Add(new UserTaskModel() { TaskName = "Buy gift", Date = System.DateTime.Now.AddDays(2), Where = "The big store" , UserId = 1 });
                defaultTask.Add(new UserTaskModel() { TaskName = "Bake a cake", Date = System.DateTime.Now.AddDays(3), Where = "The store" , UserId = 1 });

                defaultTask.Add(new UserTaskModel() { TaskName = "Buy Cheese", Date = System.DateTime.Now.AddDays(1), Where = "Food store", UserId = 2 });
                defaultTask.Add(new UserTaskModel() { TaskName = "Buy Hairspray", Date = System.DateTime.Now.AddDays(2), Where = "Hairdresser", UserId = 2 });
                defaultTask.Add(new UserTaskModel() { TaskName = "Study geometry", Date = System.DateTime.Now.AddDays(3), Where = "Home", UserId = 2 });

                defaultTask.Add(new UserTaskModel() { TaskName = "Meet John", Date = System.DateTime.Now.AddDays(1), Where = "At the bar", UserId = 3 });
                defaultTask.Add(new UserTaskModel() { TaskName = "Water plants", Date = System.DateTime.Now.AddDays(2), Where = "Home", UserId = 3 });
                defaultTask.Add(new UserTaskModel() { TaskName = "Turn in the project", Date = System.DateTime.Now.AddDays(3), Where = "School", UserId = 3 });


                foreach (User std in defaultUser)
                    context.User.Add(std);

                foreach (UserTaskModel stdT in defaultTask)
                    context.Task.Add(stdT);

                base.Seed(context);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTaskModel>()
            .HasRequired(c => c.User)
            .WithMany(p => p.Tasks)
            .HasForeignKey(c => c.UserId);
        }
    }
}
