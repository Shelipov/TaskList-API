using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.DAL.Interface.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        [MaxLength(255)]
        public string? FirstName { get; set; }
        [MaxLength(255)]
        public string? LastName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [NotMapped] public string FullName => $"{FirstName} {LastName}";
        public virtual ICollection<UserCurrentTaskList> UserCurrentTaskList { get; set; }
    }
}
