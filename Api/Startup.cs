using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Configuration;
using Api.Extentions;
using Api.MappingProfile;
using ApiServices;
using ApiServices.Configuration;
using ApiServices.Services;
using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository.AbstractionRepositories;
using Repository.ImplementationRepositories;
using Repository.UnitOfWork;

namespace Api
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

            
            services.Configure<RateLimitConfiguration>(Configuration.GetSection(nameof(RateLimitConfiguration)));
            services.Configure<FileServiceConfiguration>(Configuration.GetSection(nameof(FileServiceConfiguration)));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger();

            services.AddScoped<Repository.AppContext>();
            services.AddScoped<IBookFileRepository, BookFileRepository>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBorrowRepository, BorrowRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<RedisProvider>();
            services.AddSingleton(option =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<BookProfile>();
                    cfg.AddProfile<AddbookProfile>();
                    cfg.AddProfile<CategoryProfile>();
                    cfg.AddProfile<UserProfile>();
                    cfg.AddProfile<BorrowProfile>();
                });
                return config.CreateMapper();
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerExtention();
            app.UseRequesFilter();
            app.UseMvc();

        }
    }
}
