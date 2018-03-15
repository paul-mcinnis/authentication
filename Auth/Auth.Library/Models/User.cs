using Auth.Library.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Auth.Library.Models
{
    public class User : IUser
    {
        public int ModelId { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }
     
    }
}
