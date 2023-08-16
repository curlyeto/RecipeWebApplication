using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RecipeApp.ClassLibrary.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string Photo { get; set; }
        [StringLength(200)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(200)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public User(int id, string image, string firstName, string lastName, string email, string password)
        {
            Id = id;
            Photo = image;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        public User() { }

        public User defaultUser()
        {
            User? user;
            user = new User(0, "https://t3.ftcdn.net/jpg/02/43/12/34/360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg", "Test", "User", "test@gmail.com", "1234");
            return user;
        }
    }

}
