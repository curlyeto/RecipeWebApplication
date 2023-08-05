using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace RecipeApp.Modal
{
    public class User
    {
        public int Id;
        public string Image;
        [Required]
        public string FirstName;
        public string MiddleName;
        [Required]
        public string LastName;
        [Required]
        public string Email;
        [Required]
        public string Password;
        public User(int id, string image,  string firstName, string middleName, string lastName, string email, string password)
        {
            Id = id;
            Image = image;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public User() { }

        public User defaultUser()
        {
            User? user;
            user = new User(0, "https://t3.ftcdn.net/jpg/02/43/12/34/360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg", "Test", "", "User", "test@gmail.com", "1234");
            return user;
        }

        
    }
   

    
}
