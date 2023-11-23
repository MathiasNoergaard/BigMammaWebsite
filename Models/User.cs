using System.ComponentModel.DataAnnotations;
namespace BigMammaWebsite.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public User() { }

        public User(int iD, string username, string password)
        {
            ID = iD;
            Username = username;
            Password = password;
        }
    }
}
