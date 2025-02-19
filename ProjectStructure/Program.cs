using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


            var webApplicationBuilder = WebApplication.CreateBuilder();

            #region Configure Service 

            webApplicationBuilder.Services.AddControllersWithViews(); 

            #endregion

            var app= webApplicationBuilder.Build();

            #region Configure 
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error");
            }

            app.UseRouting();

           
                app.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                app.MapGet("/Hamada", async context =>
                {
                    await context.Response.WriteAsync("Hello Hamada!");
                });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}");

                    
                #endregion

                app.Run();


           
      