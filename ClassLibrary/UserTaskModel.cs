namespace ClassLibrary
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Tasks")]
    public partial class UserTaskModel
    {
        public UserTaskModel()
        {
            
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int TaskId { get; set; }

        [StringLength(50)]
        public string TaskName { get; set; }

        [DisplayName("Date of task")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Where { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}
