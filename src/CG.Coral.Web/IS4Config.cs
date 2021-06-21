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
                    AllowedScopes = new List<string> { "openid", "profile", "email", "oliveapi.read", "oliveapi.write" },
                    RedirectUris = { "https://localhost:5005/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5005/signout-oidc" }
                },
                new Client
                {
                    ClientId = "4D0880B4-174E-4C88-99BA-0CED9004970F",
                    ClientName = "CG.Beryl.Web",
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequireConsent = false,
                    RequirePkce = true,
                    AllowOfflineAccess = true,
                    ClientSecrets = new List<Secret> {new Secret("ACA4D701-F8F2-4E34-BC84-1E68FF2597F2".Sha256())},
                    AllowedScopes = new List<string> { "openid", "profile", "email", "berylapi.read", "berylapi.write" },
                    RedirectUris = { "https://localhost:5008/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5008/signout-oidc" }
                },
                new Client
                {
                    ClientId = "1D98140B-0C29-47C3-92FE-110E393AC75F",
                    ClientName = "CG.Obsidian.Web",
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequireConsent = false,
                    RequirePkce = true,
                    AllowOfflineAccess = true,
                    ClientSecrets = new List<Secret> {new Secret("EAC5C954-94D7-4FFC-8296-6BF1D09261BD".Sha256())},
                    AllowedScopes = new List<string> { "openid", "profile", "email", "obsidianapi.read", "obsidianapi.write" },
                    RedirectUris = { "https://localhost:5011/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5011/signout-oidc" }
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
                    Name = "oliveapi",
                    DisplayName = "CG.Olive API",
                    Description = "Allow the application to access CG.Olive API on your behalf",
                    Scopes = new List<string> {"oliveapi.read", "oliveapi.write"},
                    ApiSecrets = new List<Secret> {new Secret("D3820CE6-1C5A-455D-9A36-AE1D87CB01C3".Sha256())},
                    UserClaims = new List<string> {"role", "name", "email"}
                },
                new ApiResource
                {
                    Name = "berylapi",
                    DisplayName = "CG.Beryl API",
                    Description = "Allow the application to access CG.Beryl API on your behalf",
                    Scopes = new List<string> {"berylapi.read", "berylapi.write"},
                    ApiSecrets = new List<Secret> {new Secret("AD16A903-A6CA-4EB4-AE78-1D4484D1E442".Sha256())},
                    UserClaims = new List<string> {"role", "name", "email"}
                },
                new ApiResource
                {
                    Name = "obsidianapi",
                    DisplayName = "CG.Obsidian API",
                    Description = "Allow the application to access CG.Obsidian API on your behalf",
                    Scopes = new List<string> { "obsidianapi.read", "obsidianapi.write"},
                    ApiSecrets = new List<Secret> {new Secret("C0795EDB-767C-4E04-A2AF-B027A79B2272".Sha256())},
                    UserClaims = new List<string> {"role", "name", "email"}
                }
            };
        }

        public static IEnumerable<ApiScope> ApiScopes()
        {
            return new[]
            {
                new ApiScope("berylapi.read", "Read Access to CG.Beryl API"),
                new ApiScope("berylapi.write", "Write Access to CG.Beryl API"),
                new ApiScope("oliveapi.read", "Read Access to CG.Olive API"),
                new ApiScope("oliveapi.write", "Write Access to CG.Olive API"),
                new ApiScope("obsidianapi.read", "Read Access to CG.Obsidian API"),
                new ApiScope("obsidianapi.write", "Write Access to CG.Obsidian API")
            };
        }
    }
}
