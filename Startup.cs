using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lyncas.Business;
using lyncas.Business.Interfaces;
using lyncas.Model.Context;
using lyncas.Repository;
using lyncas.Repository.Generic;
using lyncas.Repository.Interfaces;
using lyncas.Services;
using lyncas.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace lyncas
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

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "lyncas", Version = "v1" });
      });

      services.AddHttpClient<IBookService, BookService>(b => b.BaseAddress = new Uri(Configuration["BookApiConfig:BaseUrl"]));


      services.AddScoped<IFavoritoBusiness, FavoritoBusiness>();
      services.AddScoped<IFavoritoRepository, FavoritoRepository>();



      services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

      services.AddDbContext<Context>(options => options.UseInMemoryDatabase("db"));


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "lyncas v1"));
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
