using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitFlexApp.DAL.Entities
{
    public class TrainingPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [ForeignKey("TrainingPlanTypeId")]
        public TrainingPlanType? TrainingPlanType { get; set; }
        public int TrainingPlanTypeId { get; set; }

        [ForeignKey("UserId")]
        public User? CoachUser { get; set; }
        public int UserId { get; set; }
    }
}
