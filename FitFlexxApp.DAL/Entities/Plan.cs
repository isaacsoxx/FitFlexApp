using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitFlexApp.DAL.Entities
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [ForeignKey("PlanTypeId")]
        public PlanType? PlanType { get; set; }
        public int PlanTypeId { get; set; }
        // parent entity mapping properties
        [ForeignKey("UserAccessPlanId")]
        public UserAccessPlan? UserAccessPlan { get; set; }
        public int UserAccessPlanId { get; set; }
    }
}
