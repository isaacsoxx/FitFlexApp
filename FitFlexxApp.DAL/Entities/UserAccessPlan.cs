using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFlexApp.DAL.Entities
{
    public class UserAccessPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AccessFee { set; get; }
        [MaxLength(128)]
        public string Description { set; get; } = string.Empty;
        // self referencing navigation properties
        // [ForeignKey("InstructorId")]
        // public User? Instructor { get; set; }
        public int InstructorId { get; set; }
        // parent entity navigation properties
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }
        // child properties
        public ICollection<Plan> Plans { set; get; } = new List<Plan>();
    }
}
