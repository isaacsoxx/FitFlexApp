using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitFlexxApp.DAL.Entities
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
