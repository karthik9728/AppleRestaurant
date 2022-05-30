﻿ using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Apple.Services.Identity
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources => 
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScope => new List<ApiScope>
        {
            new ApiScope("apple","Appler Server"),
            new ApiScope(name:"read",displayName:"Read Your Data"),
            new ApiScope(name:"write",displayName:"Write Your Data"),
            new ApiScope(name:"delete",displayName:"Delete Your Data"),
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId ="client",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"read","write","profile"}
            },
            new Client
            {
                ClientId ="apple",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris ={ "https://localhost:44311/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:44311/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "apple"
                }
            },
        };
    }
}
