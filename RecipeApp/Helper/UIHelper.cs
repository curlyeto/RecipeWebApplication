using BootstrapBlazor.Components;
using Microsoft.JSInterop;
using RecipeApp.ClassLibrary.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeApp.Helper
{
    public class UIHelper
    {
        private readonly IJSRuntime _jsRuntime;

        public UIHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task Alert(string message)
        {
            await _jsRuntime.InvokeVoidAsync("alert", message);
        }
        public async Task<User?> getResponseToUser(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var user = JsonSerializer.Deserialize<User>(responseContent, options);
            return user;
        }
        public async Task saveLocalStorage(String key, params object?[]? value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }
        public async Task<string> readLocalStorage(String key)
        {
          string userId=await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "userId");
          return userId;
        }


    }
}
