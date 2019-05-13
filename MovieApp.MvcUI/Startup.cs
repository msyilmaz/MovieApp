using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Business.Abstract;
using MovieApp.Business.Concrete;
using MovieApp.Core.Data;
using MovieApp.Core.Data.EntityFramework;
using MovieApp.Data.Abstract;
using MovieApp.Data.Concrete.EntityFramework;

namespace MovieApp.MvcUI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("MovieApp.Data")));

            services.AddTransient<DbContext, MovieDbContext>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(efRepositoryBase<>));

            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<IUserDal, efUserDal>();

            services.AddTransient<ICommentDal, efCommentDal>();
            services.AddTransient<ICommentService, CommentManager>();

            services.AddTransient<IBlogDal, efBlogDal>();
            services.AddTransient<IBlogService, BlogManager>();

            services.AddTransient<ICastDal, efCastDal>();
            services.AddTransient<ICastService, CastManager>();

            services.AddTransient<IUnitOfWork, efUnitOfWork>();




            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }




            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
