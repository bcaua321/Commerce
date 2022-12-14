using Commerce.Api.Filters;
using Commerce.Application.Mappings;
using Commerce.Data.Context;
using Commerce.Data.IoC;
using Commerce.Services.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add<ExceptionFilter>();
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfiguration());
}).CreateMapper());

var version = new MySqlServerVersion(new Version(8, 0, 29));
var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<DatabaseContext>(x => x
        .UseMySql(connectionString, version, mySqlOptions =>
        {
            mySqlOptions.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName);
        }));

builder.Services.AddRepositories();
builder.Services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
