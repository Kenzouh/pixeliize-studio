using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace woolly_friends.Models.Tables
{
    public enum TransactionType
    {
        Adoption,
        Sale
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PetPrice { get; set; }

        [Required]
        [MaxLength(100)]
        public string PetName { get; set; }

        [Required]
        public string PetType { get; set; }

        [Required]
        public string PetBreed { get; set; }

        [Required]
        public Gender PetGender { get; set; }

        public DateTime? PetDateOfBirth { get; set; }

        [Required]
        public string PetLocation { get; set; }

        [Required, Display(Name = "Pet Picture")]
        public string PetImgPath { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
