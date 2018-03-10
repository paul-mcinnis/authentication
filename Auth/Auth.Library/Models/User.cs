using Auth.Library.Interfaces;

namespace Auth.Library.Models
{
    public class User : IUser
    {
        public int ModelId { get; set; }
        public string UserName { get; set; }

    }
}
