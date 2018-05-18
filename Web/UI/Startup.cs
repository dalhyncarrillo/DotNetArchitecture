using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.Web.UI.Extensions;

namespace Solution.Web.UI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		public void Configure(IApplicationBuilder application, IHostingEnvironment environment)
		{
			application.UseExceptionCustom(environment);
			application.UseAuthentication();
			application.UseCorsCustom();
			application.UseStaticFiles();
			application.UseSpaStaticFiles();
			application.UseResponseCaching();
			application.UseMvcWithDefaultRoute();
			application.UseSpaCustom(environment);
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDependencyInjectionCustom(Configuration);
			services.AddAuthenticationCustom();
			services.AddCors();
			services.AddResponseCaching();
			services.AddMemoryCache();
			services.AddMvcCustom();
			services.AddSpaStaticFilesCustom();
		}
	}
}
