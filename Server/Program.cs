using Kitaplar.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Kitaplar;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var CS = builder.Configuration["ConnectionStrings:CS"];
        builder.Services.AddDbContext<KitapDB>(option => option.UseSqlServer(CS));
        // Add services to the container.

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        //builder.Services.AddSwaggerGen(options =>
        //{
        //    options.SwaggerDoc("v1", new OpenApiInfo
        //    {
        //        Version = "v1",
        //        Title = "ToDo API",
        //        Description = "An ASP.NET Core Web API for managing ToDo items",
        //        TermsOfService = new Uri("https://example.com/terms"),
        //        Contact = new OpenApiContact
        //        {
        //            Name = "Example Contact",
        //            Url = new Uri("https://example.com/contact")
        //        },
        //        License = new OpenApiLicense
        //        {
        //            Name = "Example License",
        //            Url = new Uri("https://example.com/license")
        //        }
        //    });
        //});

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //    options.RoutePrefix = string.Empty;
            //});
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();


        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}
