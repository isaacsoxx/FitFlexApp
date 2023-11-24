using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitFlexxApp.DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { set; get; }
        [Required]
        public string Email { set; get; } = string.Empty;
        [Required]
        public string FirstName { set; get; } = string.Empty;
        public string LastName { set; get; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public ICollection<Plan> Plans { set; get; } = new List<Plan>();
    }
}
