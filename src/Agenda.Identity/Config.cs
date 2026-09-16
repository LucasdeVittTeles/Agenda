using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Agenda.Identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
       [
           new IdentityResources.OpenId(),
            new IdentityResources.Profile()
       ];

        public static IEnumerable<ApiScope> ApiScopes =>
            [
                new ApiScope("agenda_api", "Agenda API")
            ];

        public static IEnumerable<Client> Clients =>
            [
                new Client
            {
                ClientId = "agenda_react",
                ClientName = "Agenda React",

                AllowedGrantTypes = GrantTypes.Code,

                RequireClientSecret = false,

                AllowOfflineAccess = true,

                RedirectUris =
                {
                    "http://localhost:5173/callback"
                },

                PostLogoutRedirectUris =
                {
                    "http://localhost:5173"
                },

                AllowedCorsOrigins =
                {
                    "http://localhost:5173"
                },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "agenda_api"
                },

                RequirePkce = true
            }
            ];

    }
}
