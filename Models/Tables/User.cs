using System.ComponentModel.DataAnnotations;

namespace woolly_friends.Models.Tables
{
    // roles duh
    public enum Role
    {
        User,
        Admin
    }

    // This maps out to the User database table
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, MaxLength(50)]
        public string UserEmail { get; set; }

        [Required, DataType(DataType.Password), MaxLength(255)]
        public string UserPassword { get; set; }

        [MaxLength(30)]
        public string? Username { get; set; }

        [Phone, MaxLength(11)]
        public string? UserContact { get; set; }
        [MaxLength(255)]
        public string? UserImgPath { get; set; } = "/Images/DefaultProfile.png";
        public bool IsActive { get; set; } = true;
        public Role UserRole { get; set; } = Role.User;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
