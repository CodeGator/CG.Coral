using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace CG.Coral.Web
{
    internal static class IS4Config
    {
        public static List<TestUser> Users()
        {
            return new List<TestUser> 
            {
                new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "martin",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "martin@codegator.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "DA689B8E-6B09-47DE-8328-CFFB911CE9D7",
                    ClientName = "CG.Olive.Web",
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequireConsent = false,
                    RequirePkce = true,
                    AllowOfflineAccess = true,
                    ClientSecrets = new List<Secret> {new Secret("3DFC0E24-A141-4181-BFAD-10ADF2709550".Sha256())},
                    AllowedScopes = new List<string> { "openid", "profile", "email", "api1.read", "api1.write" },
                    RedirectUris = { "https://localhost:5005/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5005/signout-oidc" }
                }
            };
        }

        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "api1",
                    DisplayName = "API #1",
                    Description = "Allow the application to access API #1 on your behalf",
                    Scopes = new List<string> {"api1.read", "api1.write"},
                    ApiSecrets = new List<Secret> {new Secret("D3820CE6-1C5A-455D-9A36-AE1D87CB01C3".Sha256())},
                    UserClaims = new List<string> {"role", "name", "email"}
                }
            };
        }

        public static IEnumerable<ApiScope> ApiScopes()
        {
            return new[]
            {
                new ApiScope("api1.read", "Read Access to API #1"),
                new ApiScope("api1.write", "Write Access to API #1")
            };
        }
    }
}
