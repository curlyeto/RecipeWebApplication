using RecipeApp.ClassLibrary.Model;
using System.Net.Http.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Net;

namespace RecipeApp.Services
{
    public class UserServices : IUserServicese
    {
        private readonly HttpClient _httpClient;
        public UserServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> EditUser(string firstName, string lastName, string photo, string email, string password, int userId)
        {
            var user = new
            {
                id = userId,
                firstName = firstName,
                lastName = lastName,
                photo = photo,
                email = email,
                password = password,
                userId = userId
            };

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://localhost:7006/api/User/{userId}", content);
            return response;
        }

        public async Task<User> getUser(int userId)
        {
            return await _httpClient.GetFromJsonAsync<User>("api/User/" + userId);
        }

        public async Task<List<User>> getUsers()
        {
           
            return await _httpClient.GetFromJsonAsync<List<User>>("api/User/getAllUsers");
        }
        public async Task<HttpResponseMessage> Login(String email,String password)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            Console.WriteLine("https://localhost:7006/api/User/Login?email=" + email + "&password=" + password);
            return await _httpClient.PostAsync("https://localhost:7006/api/User/Login?email="+email+"&password="+password, content);
        }

        public async Task<bool> registerUser(string firstName, string lastName, string email, string password)
        {
            var user = new
            {
                id = 0,
                firstName = firstName,
                lastName = lastName,
                photo = "",
                email = email,
                password = password
            };

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://localhost:7006/api/User", content);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
