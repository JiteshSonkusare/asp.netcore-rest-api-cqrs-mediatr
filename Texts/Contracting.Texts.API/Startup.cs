using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Texts.API.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Texts.API.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Texts.API.Application.Infrastructure;
using Texts.API.Application.Infrastructure.Notification;
using Texts.API.Application.Commands.CreateText;

namespace Texts.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add Auto-mapper
            services.AddAutoMapper(typeof(Startup));

            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();

            // Add MediatR
            services.AddMediatR(typeof(Startup));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // Add DbContext using SQL Server Provider
            services.AddDbContext<ContractingTextsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TextsConn")));

            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .AddMvcOptions(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateTextCommandValidator>());

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute
                (
                    name: "default",
                    template: "api/{controller}/{action}/{id?}"
                );
            });
        }
    }
}
