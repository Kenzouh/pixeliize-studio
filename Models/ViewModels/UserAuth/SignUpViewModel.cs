using System.ComponentModel.DataAnnotations;

namespace woolly_friends.Models.ViewModels.UserAuth
{
    // This ViewModel is for validating inputs.
    public class SignUpViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string UserEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Incorrect password! Please try again.")]
        public string ConfirmPassword { get; set; }
    }
}
