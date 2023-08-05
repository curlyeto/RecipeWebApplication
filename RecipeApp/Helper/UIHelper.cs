using Microsoft.JSInterop;
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
    }
}
