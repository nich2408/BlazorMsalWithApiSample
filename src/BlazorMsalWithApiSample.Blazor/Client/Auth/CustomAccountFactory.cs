﻿using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;

namespace BlazorMsalWithApiSample.Client.Auth
{
    /// <summary>
    /// From https://code-maze.com/using-app-roles-with-azure-active-directory-and-blazor-webassembly-hosted-apps/
    /// </summary>
    public class CustomAccountFactory : AccountClaimsPrincipalFactory<CustomUserAccount>
    {
        public CustomAccountFactory(IAccessTokenProviderAccessor accessor)
            : base(accessor)
        {
        }

        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(CustomUserAccount account,
            RemoteAuthenticationUserOptions options)
        {
            var initialUser = await base.CreateUserAsync(account, options);
            if (initialUser.Identity.IsAuthenticated)
            {
                var userIdentity = (ClaimsIdentity)initialUser.Identity;

                foreach (var role in account.Roles)
                {
                    userIdentity.AddClaim(new Claim("appRole", role));
                }
            }

            return initialUser;
        }
    }
}
