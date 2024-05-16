using BlazorMsalWithApiSample.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorMsalWithApiSample.Client.Auth
{
    /// <summary>
    /// From https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-6.0#custom-authorizationmessagehandler-class
    /// </summary>
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
                NavigationManager navigation)
                : base(provider, navigation)
        {
            ConfigureHandler(
                authorizedUrls: new[] { APIClient.BaseAddress },
                scopes: new[] { "YOUR_APP_SCOPE_HERE", "..." });    // Example: api://some-guid-here/TestScope.Name
        }
    }
}
