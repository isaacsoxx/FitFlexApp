using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFlexApp.DAL.Entities
{
    public class UserSubscriptionPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AccessFee { set; get; }
        [MaxLength(128)]
        public string Description { set; get; } = string.Empty;
        // self referencing navigation properties
        public int InstructorId { get; set; }
        // [ForeignKey("InstructorId")]
        // public User? Instructor { get; set; }
        // parent entity navigation properties
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        // child properties
        public ICollection<Plan> Plans { set; get; } = new List<Plan>();
    }
}
