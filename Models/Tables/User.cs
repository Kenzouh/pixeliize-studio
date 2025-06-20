using System.ComponentModel.DataAnnotations;

namespace woolly_friends.Models.Tables
{
    // This maps out to the User database table
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string UserEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string UserPassword { get; set; }

        public string? Username { get; set; }
        public string? UserAddress { get; set; }
        public string? UserImgPath { get; set; } // NOTE: currently null, but this should have a default path for the default blank pfp
    }
}
