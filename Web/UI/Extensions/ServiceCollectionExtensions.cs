using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Security;
using Solution.Infrastructure.Databases.Database.Context;

namespace Solution.Web.UI.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddAuthenticationCustom(this IServiceCollection services)
		{
			var jsonWebToken = DependencyInjection.GetService<IJsonWebToken>();

			void JwtBearer(JwtBearerOptions jwtBearer)
			{
				jwtBearer.RequireHttpsMetadata = false;
				jwtBearer.SaveToken = true;
				jwtBearer.TokenValidationParameters = jsonWebToken.GetTokenValidationParameters();
			}

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
		}

		public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
		{
			DependencyInjection.RegisterServices(services);
			DependencyInjection.AddDbContext<DatabaseContext>(configuration.GetConnectionString(nameof(DatabaseContext)));
			DependencyInjection.GetService<DatabaseContext>().Seed();
		}

		public static void AddMvcCustom(this IServiceCollection services)
		{
			void Mvc(MvcOptions mvc)
			{
				var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
				mvc.Filters.Add(new AuthorizeFilter(policy));
			}

			void Json(MvcJsonOptions json)
			{
				json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			}

			services.AddMvc(Mvc).AddJsonOptions(Json);
		}

		public static void AddSpaStaticFilesCustom(this IServiceCollection services)
		{
			services.AddSpaStaticFiles(spa => spa.RootPath = "ClientApp/dist");
		}
	}
}
