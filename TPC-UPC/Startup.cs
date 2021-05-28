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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Persistence.Contexts;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Persistence.Repositories;
using TPC_UPC.Services;

namespace TPC_UPC
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

            //Database Connection Configuration

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Dependency Injection Configuration
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICareerRepository, CareerRepository>();
            services.AddScoped<ICoordinatorRepository, CoordinatorRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ILessonStudentRepository, LessonStudentRepository>();
            services.AddScoped<ILessonTypeRepository, LessonTypeRepository>();
            services.AddScoped<IMailMessageRepository, MailMessageRepository>();
            services.AddScoped<IMeetingRepository, MeetingRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationTypeRepository, NotificationTypeRepository>();
            services.AddScoped<INotificationUserRepository, NotificationUserRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISuggestionRepository, SuggestionRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<ITutorRepository, TutorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IUserCourseRepository, UserCourseRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICareerService, CareerService>();
            services.AddScoped<ICoordinatorService, CoordinatorService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ILessonStudentService, LessonStudentService>();
            services.AddScoped<ILessonTypeService, LessonTypeService>();
            services.AddScoped<IMailMessageService, MailMessageService>();
            services.AddScoped<IMeetingService, MeetingService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationTypeService, NotificationTypeService>();
            services.AddScoped<INotificationUserService, NotificationUserService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISuggestionService, SuggestionService>();
            //services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITutorService, TutorService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<IUserCourseService, UserCourseService>();

            //Apply endpoints naming convention

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TPC_UPC", Version = "v1" });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TPC_UPC v1"));

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
