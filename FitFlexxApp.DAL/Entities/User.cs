using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitFlexApp.DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UserId { set; get; }
        [Required]
        public string Email { set; get; } = string.Empty;
        public string? FirstName { set; get; } = string.Empty;
        public string? LastName { set; get; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        // child properties
        public ICollection<UserAccessPlan> UserAccessPlans { get; set; } = new List<UserAccessPlan>();
    }
}
