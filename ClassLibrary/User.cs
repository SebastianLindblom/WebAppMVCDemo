namespace ClassLibrary
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<UserTaskModel>();
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int UserId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        public virtual ICollection<UserTaskModel> Tasks { get; set; }

    }
}
