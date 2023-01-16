using Commerce.Api.Extensions;
using Commerce.Api.Filters;
using Commerce.Api.IoC;
using Commerce.Application.Mappings;
using Commerce.Data.IoC;
using Commerce.Services.IoC;

namespace Commerce.Api
{
    public class Startup : Interfaces.IStartup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => {
                        options.Filters.Add<ExceptionFilter>();
                    }).AddNewtonsoftJson(options => {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });

            services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            }).CreateMapper());

            services.AddSwagger();
            services.AddServices(Configuration);
            services.AddJwtAuthentication(Configuration);
            services.AddRepositories();
            services.AddApplication();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
