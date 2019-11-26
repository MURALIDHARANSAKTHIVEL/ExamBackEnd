using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Business.Orchestration;
using Exam.Business.Repository;
using Exam.Contract.Data;
using Exam.Contract.DBconfig;
using Exam.Contract.IOrchestration;
using Exam.Contract.IRepository;
using Exam.Data.Implementation;
using Exam.DataAccess.sql.sqlImplementation;
using Exam.DataAccess.sql.sqlInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Exam.Gateway
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

            services.Configure<DbConfig>(Configuration.GetSection("AppSettings").GetSection("DbConfiguration"));

            services.AddSingleton<IExamOrchestration, ExamOrchestration>();
            services.AddSingleton<IExamRepository, ExamRepository>();
            services.AddSingleton<IExamAccess, ExamAccess>();
            services.AddSingleton<ISqlDataAccess, SqlDataAccess>();



            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    
                    );



        

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
