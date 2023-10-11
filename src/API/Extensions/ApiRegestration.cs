using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
namespace API.Extensions {
    public static class ApiRegestration {
        public static IServiceCollection AddApiRegestration(this IServiceCollection services) {
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.Configure<ApiBehaviorOptions>(opt => {
                opt.InvalidModelStateResponseFactory = context => {
                    var errorResponse = new ApiValidationErrorResponse {
                        Errors = context.ModelState
                                .Where(x => x.Value.Errors.Count > 0)
                                .SelectMany(x => x.Value.Errors)
                                .Select(x => x.ErrorMessage).ToArray()
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

           
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", pol => {
                    pol.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:4200");
                });
            });
            return services;
        }
    }
}
