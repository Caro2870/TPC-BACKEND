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

            //Constraints of Coordinator
            builder.Entity<Coordinator>().HasKey(p => p.Id);   //PK
            builder.Entity<Coordinator>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Coordinator>().Property(p => p.FirstName).IsRequired().HasMaxLength(35);   //PK
            builder.Entity<Coordinator>().Property(p => p.LastName).IsRequired().HasMaxLength(60);   //PK
            builder.Entity<Coordinator>().Property(p => p.Mail).IsRequired();   //PK
            builder.Entity<Coordinator>().Property(p => p.PhoneNumber).HasMaxLength(15);   //PK
            //Constraints of Course
            builder.Entity<Course>().HasKey(p => p.Id);   //PK
            builder.Entity<Course>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Course>().Property(p => p.Name).IsRequired().HasMaxLength(50);   //PK

            //Constraints of Faculty
            builder.Entity<Faculty>().HasKey(p => p.Id);   //PK
            builder.Entity<Faculty>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Faculty>().Property(p => p.Name).IsRequired().HasMaxLength(80);
            builder.Entity<Faculty>().Property(p => p.Description).IsRequired().HasMaxLength(400);
            //Constraints of Lesson
            builder.Entity<Lesson>().HasKey(p => p.Id);   //PK
            builder.Entity<Lesson>().HasKey(p => p.TutorId);   //PK
            builder.Entity<Lesson>().HasKey(p => p.LessonTypeId);   //PK
            builder.Entity<Lesson>().HasKey(p => p.CourseId);   //PK
            builder.Entity<Lesson>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Lesson>().Property(p => p.Vacants).IsRequired();  //GeneraKey
            //Constraints of LessonStudent
            builder.Entity<LessonStudent>().HasKey(p => p.LessonId);   //PK
            builder.Entity<LessonStudent>().HasKey(p => p.StudentId);   //PK
            builder.Entity<LessonStudent>().Property(p => p.Topic).IsRequired();
            builder.Entity<LessonStudent>().Property(p => p.Comment).IsRequired().HasMaxLength(200);
            builder.Entity<LessonStudent>().Property(p => p.Qualification).IsRequired();
            builder.Entity<LessonStudent>().Property(p => p.Complaint).IsRequired();
            builder.Entity<LessonStudent>().Property(p => p.Assistance).IsRequired();
             //Constraints of LessonType
            builder.Entity<LessonType>().HasKey(p => p.Id);   //PK
            builder.Entity<LessonType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<LessonType>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            //Constraints of MailMessage
            builder.Entity<MailMessage>().HasKey(p => p.Id);   //PK
            builder.Entity<MailMessage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<MailMessage>().Property(p => p.Message).IsRequired().HasMaxLength(400);
            builder.Entity<MailMessage>().Property(p => p.DocumentLink).IsRequired().HasMaxLength(150);
            //Constraints of Meeting
            builder.Entity<Meeting>().HasKey(p => p.Id);   //PK
            builder.Entity<Meeting>().HasKey(p => p.ScheduleId);   //PK
            builder.Entity<Meeting>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Meeting>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Entity<Meeting>().Property(p => p.MeetingLink).IsRequired().HasMaxLength(150);
            builder.Entity<Meeting>().Property(p => p.ResourceLink).IsRequired().HasMaxLength(150);
            //Constraints of Notification
            builder.Entity<Notification>().HasKey(p => p.Id);   //PK
            builder.Entity<Notification>().HasKey(p => p.NotificationTypeId);   //PK
            builder.Entity<Notification>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Notification>().Property(p => p.Link).IsRequired().HasMaxLength(150);
            builder.Entity<Notification>().Property(p => p.SendDate).IsRequired();
            //Constraints of NotificationType
            builder.Entity<NotificationType>().HasKey(p => p.Id);   //PK
            builder.Entity<NotificationType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<NotificationType>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            //Constraints of NotificationUser
            builder.Entity<NotificationUser>().HasKey(p => p.NotificationId);   //PK
            builder.Entity<NotificationUser>().HasKey(p => p.UserId);   //PK
            //Constraints of Schedule
            builder.Entity<Schedule>().HasKey(p => p.Id);   //PK
            builder.Entity<Schedule>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Schedule>().Property(p => p.StartDate).IsRequired();
            builder.Entity<Schedule>().Property(p => p.EndDate).IsRequired();
        }
    }
}
