using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using service_practice.Repositories;
using service_practice.Services;
using System.Data;
using MySqlConnector;

namespace service_practice
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddTransient<PostsService>();
      services.AddTransient<PostRepository>();
      services.AddTransient<CommentsService>();
      services.AddTransient<CommentsRepository>();

      services.AddCors(options =>
                {
                  options.AddPolicy("CorsDevPolicy", builder =>
              {
                builder
                .WithOrigins(new string[]{
                            "http://localhost:8080",
                            "http://localhost:8081"
                          })
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
              });
                });

      services.AddControllers();
      services.AddScoped<IDbConnection>(x => CreateDbConnection());
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "service_practice", Version = "v1" });
      });
    }

    private System.Data.IDbConnection CreateDbConnection()
    {
      string connectString = Configuration["db:gearhost"];
      return new MySqlConnection(connectString);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseCors("CorsDevPolicy");
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "service_practice v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
