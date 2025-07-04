using System.ComponentModel.DataAnnotations;

namespace woolly_friends.Models.ViewModels.UserProfile
{
    public class UpdateProfileViewModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [Phone, MaxLength(11)]
        public string? UserContact { get; set; }

        [EmailAddress, MaxLength(50)]
        public string? UserEmail { get; set; }

        [MaxLength(255)]
        public string? HomeAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        public string? ExistingImagePath { get; set; }

        public IFormFile? NewProfileImage { get; set; }
    }
}
