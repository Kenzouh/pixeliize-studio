using System.ComponentModel.DataAnnotations;

namespace woolly_friends.Models.ViewModels.UserAuth
{
    // holds login form data
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string UserEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
