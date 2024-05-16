using BlazorMsalWithApiSample.Client;
using BlazorMsalWithApiSample.Client.Auth;
using BlazorMsalWithApiSample.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMsalAuthentication<RemoteAuthenticationState,
    CustomUserAccount>(options =>
    {
        // This is used to save the cache in the browser's localStorage, so the authentication is kept
        // even between different browser tabs.
        // Valid values are sessionStorage and localStorage.
        options.ProviderOptions.Cache.CacheLocation = "localStorage";

        builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
        // It is used to indicate to the user that the app accesses the data. The openid permission must be added.
        //options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/openid");

        // From https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/azure-active-directory-groups-and-roles?view=aspnetcore-6.0#app-roles
        options.UserOptions.RoleClaim = "appRole";
    })
    .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount,
        CustomAccountFactory>();

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<APIClient>(
        client => client.BaseAddress = new Uri(APIClient.BaseAddress))
    .AddHttpMessageHandler(sp => sp.GetRequiredService<CustomAuthorizationMessageHandler>());

await builder.Build().RunAsync();
