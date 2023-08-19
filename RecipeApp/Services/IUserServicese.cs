using RecipeApp.ClassLibrary.Model;

namespace RecipeApp.Services
{
    public interface IUserServicese
    {
        Task<List<User>> getUsers();
        Task<HttpResponseMessage> Login(String email, String password);
        Task<User> getUser(int userId);
        Task<HttpResponseMessage> EditUser(String firstName, String lastName, String photo, String email,string password, int userId);
        Task<bool> registerUser(String firstName, String lastName, String email, string password);
    }
}
