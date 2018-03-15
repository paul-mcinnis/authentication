using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Auth.Library.Interfaces;

namespace Auth.Data.Models
{
    public class User : IUser
    {
        [Column("user_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelId { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }
    }
}
