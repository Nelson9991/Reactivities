using Reactivities.Application.Activities;
using Reactivities.Application.Core;

namespace Reactivities.API.Extensions;

public static class ApplicationServiceExtensions
{
   public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddSqlServer<ApplicationDbContext>(configuration.GetConnectionString("DefaultConnection"));

      services.AddMediatR(typeof(List.Handler).Assembly);
      services.AddAutoMapper(typeof(MappingProfiles).Assembly);

      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();

      services.AddCors(opts =>
      {
         opts.AddPolicy("CorsPolicy", policy =>
         {
            policy.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000");
         });
      });

      return services;
   }
}
