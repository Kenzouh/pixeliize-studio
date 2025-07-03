using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace woolly_friends.Models.Tables
{
    public class AdditionalUserInfo
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }

        [MaxLength(255)]
        public string? HomeAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        public virtual User User { get; set; }
    }
}