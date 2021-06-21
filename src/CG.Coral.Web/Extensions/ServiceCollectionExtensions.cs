using CG.Coral.Web;
using CG.Coral.Web.Services;
using CG.Validations;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IServiceCollection"/>
    /// type.
    /// </summary>
    /// <remarks>
    /// This class contains only those extension methods that are related to logic
    /// that lives within the <see cref="CG.Coral.Web"/> project. Look in other
    /// projects for extensions methods related to their logic - for instance,
    /// the extension methods for the <see cref="CG.Coral"/> project are located
    /// in the <see cref="CG.Coral"/> project.
    /// </remarks>
    public static partial class ServiceCollectionExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method adds custom Blazor logic for the server.
        /// </summary>
        /// <param name="serviceCollection">The service collection to use for
        /// the operation.</param>
        /// <param name="configuration">The configuration to use for the operation.</param>
        /// <returns>The value of the <paramref name="serviceCollection"/> parameter,
        /// for chaining calls together.</returns>
        public static IServiceCollection AddCustomBlazor(
            this IServiceCollection serviceCollection,
            IConfiguration configuration
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(serviceCollection, nameof(serviceCollection))
                .ThrowIfNull(configuration, nameof(configuration));

            // Add support for razor pages.
            serviceCollection.AddRazorPages();

            // Add support for server-side Blazor.
            serviceCollection.AddServerSideBlazor();

            // Add support for controllers.
            serviceCollection.AddControllersWithViews();

            // Return the service collection.
            return serviceCollection;
        }

        // *******************************************************************

        /// <summary>
        /// This method adds custom identity logic for the server.
        /// </summary>
        /// <param name="serviceCollection">The service collection to use for
        /// the operation.</param>
        /// <param name="configuration">The configuration to use for the operation.</param>
        /// <returns>The value of the <paramref name="serviceCollection"/> parameter,
        /// for chaining calls together.</returns>
        public static IServiceCollection AddCustomIdentity(
            this IServiceCollection serviceCollection,
            IConfiguration configuration
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(serviceCollection, nameof(serviceCollection))
                .ThrowIfNull(configuration, nameof(configuration));

            serviceCollection.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            }).AddInMemoryClients(IS4Config.Clients())
              .AddInMemoryIdentityResources(IS4Config.IdentityResources())
              .AddInMemoryApiResources(IS4Config.ApiResources())
              .AddInMemoryApiScopes(IS4Config.ApiScopes())
              .AddTestUsers(IS4Config.Users())
              .AddDeveloperSigningCredential();

            // Return the service collection.
            return serviceCollection;
        }

        // *******************************************************************

        /// <summary>
        /// This method adds custom HTTP services for  the server.
        /// </summary>
        /// <param name="serviceCollection">The service collection to use for
        /// the operation.</param>
        /// <param name="configuration">The configuration to use for the operation.</param>
        /// <returns>The value of the <paramref name="serviceCollection"/> parameter,
        /// for chaining calls together.</returns>
        public static IServiceCollection AddCustomServices(
            this IServiceCollection serviceCollection,
            IConfiguration configuration
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(serviceCollection, nameof(serviceCollection))
                .ThrowIfNull(configuration, nameof(configuration));

            // Add a token provider service.
            serviceCollection.AddScoped<TokenProvider>();

            // Add a token service.
            serviceCollection.AddScoped<ITokenService, TokenService>();

            // Return the service collection.
            return serviceCollection;
        }

        #endregion
    }
}
