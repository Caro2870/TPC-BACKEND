﻿using System;
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
            //Constraints of Student
            builder.Entity<Student>().HasKey(p => p.Id);   //PK
            builder.Entity<Student>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Student>().Property(p => p.CycleNumber).IsRequired();
            builder.Entity<Student>().Property(p => p.FirstName).IsRequired().HasMaxLength(35);   //PK
            builder.Entity<Student>().Property(p => p.LastName).IsRequired().HasMaxLength(60);   //PK
            builder.Entity<Student>().Property(p => p.Mail).IsRequired();   //PK
            builder.Entity<Student>().Property(p => p.PhoneNumber).HasMaxLength(15);   //PK
            //Constraints of Suggestion
            builder.Entity<Suggestion>().HasKey(p => p.Id);   //PK
            builder.Entity<Suggestion>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Suggestion>().Property(p => p.Message).IsRequired().HasMaxLength(400);
            //Constraints of Training
            builder.Entity<Training>().HasKey(p => p.Id);   //PK
            builder.Entity<Training>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //Constraints of TrainingTutor
            builder.Entity<TrainingTutor>().HasKey(p => p.TrainingId);   //PK
            builder.Entity<TrainingTutor>().HasKey(p => p.TutorId);   //PK
            builder.Entity<TrainingTutor>().Property(p => p.Assistance).IsRequired();
            //Constraints of Tutor
            builder.Entity<Tutor>().HasKey(p => p.Id);   //PK
            builder.Entity<Tutor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tutor>().Property(p => p.FirstName).IsRequired().HasMaxLength(35);   //PK
            builder.Entity<Tutor>().Property(p => p.LastName).IsRequired().HasMaxLength(60);   //PK
            builder.Entity<Tutor>().Property(p => p.Mail).IsRequired();   //PK
            builder.Entity<Tutor>().Property(p => p.PhoneNumber).HasMaxLength(15);   //PK
            //Constraints of University
            builder.Entity<University>().HasKey(p => p.Id);   //PK
            builder.Entity<University>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<University>().Property(p => p.UniversityName).IsRequired().HasMaxLength(50);
            //Constraints of User
            builder.Entity<User>().HasKey(p => p.Id);   //PK
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Mail).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.PhoneNumber).IsRequired();
            //Constraints of UserCourse
            builder.Entity<UserCourse>().HasKey(p => p.CourseId);   //PK
            builder.Entity<UserCourse>().HasKey(p => p.UserId);  //GeneraKey

            /*
            Example of Relationship
            1 a muchos
            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            Muchos a muchos
            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId);

            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.TagId);



            */

            //Relationships of Lesson
            builder.Entity<Lesson>()
                .HasMany(a => a.LessonStudents)
                .WithOne(b => b.Lesson)
                .HasForeignKey(p => p.LessonId);
            //Relationships of LessonType
            builder.Entity<LessonType>()
                .HasOne(a => a.Lesson)
                .WithOne(b => b.LessonType)
                .HasForeignKey<Lesson>(a => a.LessonTypeId);
            //Relationships of Account
            builder.Entity<Account>()
                    .HasOne(a => a.User)
                    .WithOne(b => b.Account)
                    .HasForeignKey<User>(p => p.AccountId);
            //Relationships of Training
            builder.Entity<Training>()
                .HasMany(a => a.TrainingTutors)
                .WithOne(b => b.Training)
                .HasForeignKey(p => p.TrainingId);
            //Relationships of Student
            builder.Entity<Student>()
                .HasMany(a => a.LessonStudents)
                .WithOne(b => b.Student)
                .HasForeignKey(p => p.StudentId);
            //Relationships of Tutor
            builder.Entity<Tutor>()
                .HasMany(a => a.TrainingTutors)
                .WithOne(b => b.Tutor)
                .HasForeignKey(p => p.TutorId);
            builder.Entity<Tutor>()
               .HasMany(a => a.Lessons)
               .WithOne(b => b.Tutor)
               .HasForeignKey(p => p.TutorId);
            //Relationships of Carrer
            builder.Entity<Carrer>()
                .HasMany(a => a.Students)
                .WithOne(b => b.Career)
                .HasForeignKey(p => p.CareerId);
            //Relationships of Schedule
            builder.Entity<Schedule>()
                .HasMany(a => a.Meetings)
                .WithOne(b => b.Schedule)
                .HasForeignKey(p => p.ScheduleId);

        }
    }
}
