using Microsoft.AspNetCore.Components;

namespace BlazorMsalWithApiSample.Client.Shared
{
    partial class Authentication : ComponentBase
    {
        [Parameter]
        public string? Action { get; set; }
    }
}
