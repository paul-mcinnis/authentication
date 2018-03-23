using System;
using Auth.Library.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Library.Models
{
    public class User : IUser
    {
        [Column("user_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelId { get; set; }
        
        [Column("date_created")]
        public DateTime DateCreated { get; set; }
        
        [Column("date_modified")]
        public DateTime DateModified { get; set; }
        
        [Column("user_name")]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }
        
        [Column("password_digest")]
        public string PasswordDigest { get; set; }
        
        [Column("password_salt")]
        public string PasswordSalt { get; set; }
        
        [Column("active")]
        public bool? IsActive { get; set; }

        }
}
