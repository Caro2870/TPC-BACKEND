using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TPC_UPC.API.Extensions;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Persistence.Contexts
{   // ajustes de la definicion del modelo
    public class AppDbContext: DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<   Account         > Accounts { get; set;}
        public DbSet<   Career          > Carrers { get; set; }
        public DbSet<   Coordinator     > Coordinators { get; set; }
        public DbSet<   Course          > Courses { get; set; }
        public DbSet<   Faculty         > Faculties { get; set; }
        public DbSet<   Lesson          > Lessons { get; set; }
        public DbSet<   LessonStudent   > LessonStudents { get; set; }
        public DbSet<   LessonType      > LessonTypes { get; set; }
        public DbSet<   MailMessage     > MailMessages { get; set; }
        public DbSet<   Meeting         > Meetings { get; set; }
        public DbSet<   Notification    > Notifications { get; set; }
        public DbSet<   NotificationType    > NotificationTypes { get; set; }
        public DbSet<   NotificationUser    > NotificationUsers { get; set; }
        public DbSet<   Schedule           > Schedules { get; set; }
        public DbSet<   Student         > Students { get; set; }
        public DbSet<   Suggestion      > Suggestions { get; set; }
        public DbSet<   Training        > Trainings { get; set; }
        public DbSet<   TrainingTutor   > TrainingTutors { get; set; }
        public DbSet<   Tutor           > Tutors { get; set; }
        public DbSet<   University      > Universities { get; set; }
        public DbSet<   User            > Users { get; set; }
        public DbSet<   UserCourse      >  UserCourses{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            //Building Entities
             builder.Entity<Account         >().ToTable("Accounts");
             builder.Entity<Career          >().ToTable("Carrers");
             builder.Entity<Coordinator     >().ToTable("Coordinators")       ;
             builder.Entity<Course          >().ToTable("Courses")            ;
             builder.Entity<Faculty         >().ToTable("Faculties")          ;
             builder.Entity<Lesson          >().ToTable("Lessons")            ;
             builder.Entity<LessonStudent   >().ToTable("LessonStudents")     ;
             builder.Entity<LessonType      >().ToTable("LessonTypes")        ;
             builder.Entity<MailMessage     >().ToTable("MailMessages")       ;
             builder.Entity<Meeting         >().ToTable("Meetings")           ;
             builder.Entity<Notification    >().ToTable("Notifications")      ;
             builder.Entity<NotificationType>().ToTable("NotificationTypes")  ;
             builder.Entity<NotificationUser>().ToTable("NotificationUsers")  ;
             builder.Entity<Schedule        >().ToTable("Schedules")          ;
             builder.Entity<Student         >().ToTable("Students")           ;
             builder.Entity<Suggestion      >().ToTable("Suggestions")        ;
             builder.Entity<Training        >().ToTable("Trainings")          ;
             builder.Entity<TrainingTutor   >().ToTable("TrainingTutors")     ;
             builder.Entity<Tutor           >().ToTable("Tutors")             ;
             builder.Entity<University      >().ToTable("Universities")       ;
             builder.Entity<User            >().ToTable("Users")              ;
             builder.Entity<UserCourse      >().ToTable("UserCourses")        ;

            //Constraints of Account
            builder.Entity<Account>().HasKey(p => p.Id);   //PK
            builder.Entity<Account>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Account>().Property(p => p.AccountName).IsRequired().HasMaxLength(50);
            builder.Entity<Account>().Property(p => p.Password).IsRequired().HasMaxLength(50);
            //Constraints of Carrer
            builder.Entity<Career>().HasKey(p => p.Id);   //PK
            builder.Entity<Career>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Career>().Property(p => p.CarrerName).IsRequired().HasMaxLength(80); 


        }
    }
}
