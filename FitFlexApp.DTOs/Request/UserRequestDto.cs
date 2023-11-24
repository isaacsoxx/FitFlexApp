using System.ComponentModel.DataAnnotations;

namespace FitFlexApp.DTOs.Request
{
    public class UserRequestDto
    {
        [Required(ErrorMessage = "Please provide your ID.")]
        public int Id { set; get; }
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [Required(ErrorMessage = "A valid name should be provided")]
        public string FirstName { set; get; }
        public string LastName { set; get; }
        [Required(ErrorMessage = "You need to provide a password to secure your account")]
        public string Password { set; get; }
    }
}
