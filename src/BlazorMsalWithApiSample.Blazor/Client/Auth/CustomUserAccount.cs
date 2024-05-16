﻿using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Text.Json.Serialization;

namespace BlazorMsalWithApiSample.Client.Auth
{
    public class CustomUserAccount : RemoteUserAccount
    {
        [JsonPropertyName("roles")]
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}
