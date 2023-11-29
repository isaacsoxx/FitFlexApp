namespace FitFlexApp.DTOs.Model
{
    public class UserIncludePlanDTO
    {
        public int Id { get; set; }
        public int UserId { set; get; }
        public string Email { set; get; } = String.Empty;
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string Password { set; get; } = String.Empty;
        public ICollection<PlanDTO> Plans { set; get; } = new List<PlanDTO>();
    }
}
