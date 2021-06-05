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
        public DbSet<   Student         > Students { get; set; }
        public DbSet<   Suggestion      > Suggestions { get; set; }
        public DbSet<   Training        > Trainings { get; set; }
        public DbSet<   TrainingTutor   > TrainingTutors { get; set; }
        public DbSet<   Tutor           > Tutors { get; set; }
        public DbSet<   University      > Universities { get; set; }
        public DbSet<   User            > Users { get; set; }
        public DbSet<   UserCourse      >  UserCourses{ get; set; }
        public DbSet<CareerCourse> CareerCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            //Building Entities
             builder.Entity<Account         >().ToTable("Accounts");
             builder.Entity<Career          >().ToTable("Careers");
             builder.Entity<Coordinator     >().ToTable("Coordinators")       ;
             builder.Entity<Course          >().ToTable("Courses")            ;
             builder.Entity<Faculty         >().ToTable("Faculties")          ;
             builder.Entity<Lesson>().ToTable("Lessons");            ;
             builder.Entity<LessonStudent   >().ToTable("LessonStudents")     ;
             builder.Entity<LessonType      >().ToTable("LessonTypes")        ;
             builder.Entity<MailMessage     >().ToTable("MailMessages")       ;
             builder.Entity<Meeting         >().ToTable("Meetings")           ;
             builder.Entity<Notification    >().ToTable("Notifications")      ;
             builder.Entity<NotificationType>().ToTable("NotificationTypes")  ;
             builder.Entity<NotificationUser>().ToTable("NotificationUsers")  ;
             builder.Entity<Student         >().ToTable("Students")           ;
             builder.Entity<Suggestion      >().ToTable("Suggestions")        ;
             builder.Entity<Training        >().ToTable("Trainings")          ;
             builder.Entity<TrainingTutor   >().ToTable("TrainingTutors")     ;
             builder.Entity<Tutor>().ToTable("Tutors")             ;
             builder.Entity<University>().ToTable("Universities")       ;
             builder.Entity<User>().ToTable("Users");
             builder.Entity<UserCourse>().ToTable("UserCourses");
             builder.Entity<CareerCourse>().ToTable("CareerCourses");

            //Constraints of User
            builder.Entity<User>().HasKey(p => p.Id);   //PK
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Mail).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.PhoneNumber).IsRequired();

            //Constraints of Account
            builder.Entity<Account>().HasKey(p => p.Id);   //PK
            builder.Entity<Account>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Account>().Property(p => p.AccountName).IsRequired().HasMaxLength(50);
            builder.Entity<Account>().Property(p => p.Password).IsRequired().HasMaxLength(50);
            //Constraints of Carrer
            builder.Entity<Career>().HasKey(p => p.Id);   //PK
            builder.Entity<Career>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Career>().Property(p => p.CareerName).IsRequired().HasMaxLength(80); 
            //Constraints of Coordinator

            builder.Entity<Coordinator>().Property(p => p.FirstName).IsRequired().HasMaxLength(35);   //PK
            builder.Entity<Coordinator>().Property(p => p.LastName).IsRequired().HasMaxLength(60);   //PK
            builder.Entity<Coordinator>().Property(p => p.Mail).IsRequired();   //PK
            builder.Entity<Coordinator>().Property(p => p.PhoneNumber).HasMaxLength(15);   //PK
            //Constraints of Course
            builder.Entity<Course>().HasKey(p => p.Id);   //PK
            builder.Entity<Course>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Course>().Property(p => p.Name).IsRequired().HasMaxLength(50);   //PK
            builder.Entity<Course>().Property(p => p.Credits).IsRequired();
            //Constraints of Faculty
            builder.Entity<Faculty>().HasKey(p => p.Id);   //PK
            builder.Entity<Faculty>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Faculty>().Property(p => p.Name).IsRequired().HasMaxLength(80);
            builder.Entity<Faculty>().Property(p => p.Description).IsRequired().HasMaxLength(400);


            //Constraints of Lesson
            builder.Entity<Lesson>().Property(p => p.Vacants).IsRequired();  //GeneraKey
            builder.Entity<Lesson>().Property(p => p.CourseId).IsRequired();
            builder.Entity<Lesson>().Property(p => p.TutorId).IsRequired();
            builder.Entity<Lesson>().Property(p => p.LessonTypeId).IsRequired();
            builder.Entity<Lesson>().Property(p => p.Contador);


            /*--------LUCAS------------------------------*/
            //Constraints of LessonStudent
            builder.Entity<LessonStudent>().HasKey(p => new { p.LessonId, p.StudentId});   //PK
            builder.Entity<LessonStudent>().Property(p => p.Topic).IsRequired();
            builder.Entity<LessonStudent>().Property(p => p.Comment).HasMaxLength(200);
            builder.Entity<LessonStudent>().Property(p => p.Qualification);
            builder.Entity<LessonStudent>().Property(p => p.Complaint);
            builder.Entity<LessonStudent>().Property(p => p.Assistance);
             //Constraints of LessonType
            builder.Entity<LessonType>().HasKey(p => p.Id);   //PK
            builder.Entity<LessonType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<LessonType>().Property(p => p.LessonTypeName).IsRequired().HasMaxLength(100);
            //Constraints of MailMessage
            builder.Entity<MailMessage>().HasKey(p => p.Id);   //PK
            builder.Entity<MailMessage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<MailMessage>().Property(p => p.Message).IsRequired().HasMaxLength(400);
            builder.Entity<MailMessage>().Property(p => p.DocumentLink).IsRequired().HasMaxLength(150);
            //Constraints of Meeting
            builder.Entity<Meeting>().HasKey(p => p.Id);   //PK -> YATA
            builder.Entity<Meeting>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Meeting>().Property(p => p.StartDate);
            builder.Entity<Meeting>().Property(p => p.EndDate);
            builder.Entity<Meeting>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Entity<Meeting>().Property(p => p.MeetingLink).IsRequired().HasMaxLength(150);
            builder.Entity<Meeting>().Property(p => p.ResourceLink).IsRequired().HasMaxLength(150);
            //Constraints of Notification
            builder.Entity<Notification>().HasKey(p => p.Id);   //PK
            builder.Entity<Notification>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Notification>().Property(p => p.Link).IsRequired().HasMaxLength(150);
            builder.Entity<Notification>().Property(p => p.SendDate).IsRequired();
            //Constraints of NotificationType
            builder.Entity<NotificationType>().HasKey(p => p.Id);   //PK
            builder.Entity<NotificationType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<NotificationType>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            //Constraints of NotificationUser
            builder.Entity<NotificationUser>().HasKey(p => new { p.NotificationId, p.UserId });   //PK
            
            /*----------------LUCAS------------------------------*/
            
            //Constraints of Student
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
            builder.Entity<Training>().Property(p => p.StartDate);
            builder.Entity<Training>().Property(p => p.EndDate);
            builder.Entity<Training>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Entity<Training>().Property(p => p.MeetingLink).IsRequired().HasMaxLength(150);
            builder.Entity<Training>().Property(p => p.ResourceLink).IsRequired().HasMaxLength(150);
            builder.Entity<Training>().Property(p => p.CoordinatorId).IsRequired();

            //Constraints of TrainingTutor
            builder.Entity<TrainingTutor>().HasKey(p => new { p.TrainingId, p.TutorId });   //PK
            //builder.Entity<TrainingTutor>().HasKey(p => p.TrainingId);   //PK
            //builder.Entity<TrainingTutor>().HasKey(p => p.TutorId);   //PK
            builder.Entity<TrainingTutor>().Property(p => p.Assistance).IsRequired();

            //Constraints of Tutor
            builder.Entity<Tutor>().Property(p => p.FirstName).IsRequired().HasMaxLength(35);   //PK
            builder.Entity<Tutor>().Property(p => p.LastName).IsRequired().HasMaxLength(60);   //PK
            builder.Entity<Tutor>().Property(p => p.Mail).IsRequired();   //PK
            builder.Entity<Tutor>().Property(p => p.PhoneNumber).HasMaxLength(15);   //PK

            //Constraints of University
            builder.Entity<University>().HasKey(p => p.Id);   //PK
            builder.Entity<University>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<University>().Property(p => p.UniversityName).IsRequired().HasMaxLength(50);

            //Constraints of UserCourse
            builder.Entity<UserCourse>().HasKey(pt => new { pt.UserId, pt.CourseId });   //PK

            //Constraints of CareerCourse
            builder.Entity<CareerCourse>().HasKey(pt => new { pt.CareerId, pt.CourseId });   //PK

            //Relationships of UserCourse
            builder.Entity<UserCourse>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserCourses)
                .HasForeignKey(pt => pt.UserId);

            builder.Entity<UserCourse>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.UserCourses)
                .HasForeignKey(pt => pt.CourseId);



            //Relationships of CareerCourse
            builder.Entity<CareerCourse>()
                .HasOne(pt => pt.Career)
                .WithMany(p => p.CareerCourses)
                .HasForeignKey(pt => pt.CareerId);

            builder.Entity<CareerCourse>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CareerCourses)
                .HasForeignKey(pt => pt.CourseId);

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
            //hemos cambiado esto
            builder.Entity<LessonType>()
                .HasMany(a => a.Lessons)
                .WithOne(b => b.LessonType)
                .HasForeignKey(a => a.LessonTypeId);
            //Relationships of Account
            builder.Entity<Account>()
                    .HasOne(a => a.User)
                    .WithOne(b => b.Account)
                    .HasForeignKey<User>(p => p.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);
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
            builder.Entity<Career>()
                .HasMany(a => a.Students)
                .WithOne(b => b.Career)
                .HasForeignKey(p => p.CareerId);
      

            builder.Entity<Career>()
                  .HasMany(a => a.CareerCourses)
                  .WithOne(b => b.Career)
                  .HasForeignKey(p => p.CareerId);

            //Relationships of Faculty
            builder.Entity<Faculty>()
                .HasMany(a => a.Tutors)
                .WithOne(b => b.Faculty)
                .HasForeignKey(p => p.FacultyId);

            builder.Entity<Faculty>()
                .HasMany(a => a.Coordinators)
                .WithOne(b => b.Faculty)
                .HasForeignKey(p => p.FacultyId);
            //Relationships of Coordinator
            builder.Entity<Coordinator>()
                .HasMany(a => a.MailMessages)
                .WithOne(b => b.Coordinator)
                .HasForeignKey(p => p.CoordinatorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Coordinator>()
                .HasMany(a => a.Trainings)
                .WithOne(b => b.Coordinator)
                .HasForeignKey(p => p.CoordinatorId);
            //Relationships of University
            builder.Entity<University>()
                    .HasMany(a => a.Accounts)
                    .WithOne(b => b.University)
                    .HasForeignKey(b => b.UniversityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Faculty>()
                .HasMany(a => a.Careers)
                .WithOne(b => b.Faculty)
                .HasForeignKey(b => b.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Career>()
               .HasMany(a => a.Students)
               .WithOne(b => b.Career)
               .HasForeignKey(p => p.CareerId);
            //builder.Entity<University>()
            //        .HasMany(a => a.Faculties)
            //        .WithOne(b => b.University)
            //        .HasForeignKey(b => b.UniversityId);
            builder.Entity<University>()
                   .HasMany(a => a.Faculties)
                   .WithOne(b => b.University)
                   .HasForeignKey(b => b.UniversityId);
            //Relationships of User
            builder.Entity<User>()
                .HasMany(a => a.Suggestions)
                .WithOne(b => b.User)
                .HasForeignKey(p => p.UserId);

            builder.Entity<User>()
                .HasMany(a => a.NotificationUsers)
                .WithOne(b => b.User)
                .HasForeignKey(p => p.UserId);
            builder.Entity<Course>()
                .HasMany(a => a.CareerCourses)
                .WithOne(b => b.Course)
                .HasForeignKey(p => p.CourseId);


            //Relationships of Notification
            builder.Entity<Notification>()
                .HasMany(a => a.NotificationUsers)
                .WithOne(b => b.Notification)
                .HasForeignKey(p => p.NotificationId);
            //Relationships of NotificationType
            builder.Entity<NotificationType>()
                .HasMany(a => a.Notifications)
                .WithOne(b => b.NotificationType)
                .HasForeignKey(p => p.NotificationTypeId);
            //Relationships of Course
            builder.Entity<Course>()
               .HasMany(a => a.Lessons)
               .WithOne(b => b.Course)
               .HasForeignKey(p => p.CourseId);
            /*builder.Entity<NotificationUser>()
                .HasOne(a => a.User)
                .WithMany(b => b.NotificationUsers)
                .HasForeignKey(a => a.UserId);
            builder.Entity<NotificationUser>()
                .HasOne(a => a.Notification)
                .WithMany(b => b.NotificationUsers)
                .HasForeignKey(a => a.NotificationId);*/
            builder.Entity<University>().HasData
                   (
                   new University { Id = 101, UniversityName = "UPC" },
                    new University { Id = 102, UniversityName = "UPN" }
                   );
            //a
            builder.Entity<Account>().HasData
                    (
                    new Account { Id = 102, AccountName = "tutor01", Password = "123122", UniversityId = 101 },
                     new Account { Id = 101, AccountName = "student01", Password = "43242", UniversityId = 101 },
                     new Account { Id = 103, AccountName = "coordinator01", Password = "35353", UniversityId = 101 },
                     new Account { Id = 104, AccountName = "student02", Password = "5559", UniversityId = 101 }
                    );
            builder.Entity<Student>().HasData
                (
                new Student
                {
                    Id = 101,
                    FirstName = "Camila",
                    LastName = "Torre",
                    Mail = "camila@gmail.com",
                    PhoneNumber = "5698665",
                    AccountId = 101,
                    CycleNumber = 2,
                    CareerId = 1
                },
                new Student
                {
                    Id = 104,
                    FirstName = "Alessandra",
                    LastName = "Vargas",
                    Mail = "ale@gmail.com",
                    PhoneNumber = "51515",
                    AccountId = 104,
                    CycleNumber = 2,
                    CareerId = 1
                }
                );
            builder.Entity<Tutor>().HasData
                (
                new Tutor
                {
                    Id = 102,
                    FirstName = "Jose",
                    LastName = "Melendez",
                    Mail = "jose@gmail.com",
                    PhoneNumber = "66588965",
                    AccountId = 102,
                    FacultyId = 1
                }
                ) ;
            builder.Entity<Coordinator>().HasData
                (
                new Coordinator
                {
                    Id = 103,
                    FirstName = "Ricardo",
                    LastName = "Gonzales",
                    Mail = "pcsirgon@gmail.com",
                    PhoneNumber = "9986626",
                    AccountId = 103,
                    FacultyId = 1
                }
                );
            builder.Entity<Career>().HasData
                (
                    new Career { Id =1, CareerName="Ingenieria de Software",FacultyId=1}
                );
            builder.Entity<Suggestion>().HasData
                    (
                    new Suggestion { Id = 101, Message = "Increible clase", UserId=101 },
                     new Suggestion { Id = 102, Message = "Buena clase", UserId=101 }
                    );
            builder.Entity<Faculty>().HasData
                    (
                    new Faculty { Id = 1, Name = "Letras", Description = "departamento de letras",UniversityId=101 },
                     new Faculty { Id = 2, Name = "Ciencia", Description = "departamento de ciencias",UniversityId=101 }
                    );
            builder.Entity<MailMessage>().HasData
                    (
                    new MailMessage { Id = 101, Message = "Bienvenidos 2021", DocumentLink = "bienve.pdf", CoordinatorId=103 },
                     new MailMessage { Id = 102, Message = "Bienvenidos 2022", DocumentLink = "bienve.doc", CoordinatorId =103 }
                    );
            builder.Entity<LessonType>().HasData
                (
                new LessonType { Id=1, LessonTypeName="Tutoria", StudentsQuantity=30},
                new LessonType { Id=2, LessonTypeName="Taller", StudentsQuantity =3}
                );
            builder.Entity<Lesson>().HasData
                (
                new Lesson { 
                    Id = 1, Description = "", MeetingLink = "https://googlemeet.com", 
                    
                    ResourceLink = "blob://resource.pdf", LessonTypeId = 2, TutorId=102, CourseId = 1, Vacants=30 }
                );
            builder.Entity<Training>().HasData
                (
                new Training
                {
                    Id = 2,
                    Description = "",
                    MeetingLink = "https://googlemeet002.com",
                    ResourceLink = "blob://resource002.pdf",
                    CoordinatorId = 103
                }
                );
            builder.Entity<Course>().HasData
                (
                new Course { Id = 1, Name = "Programacion 1", Credits=6 }
                );
            builder.Entity<NotificationType>().HasData
                   (
                   new NotificationType { Id = 801, Description = "Recordatorio de que la clase esta por comenzar" },
                   new NotificationType { Id = 802, Description = "Solicitud de confirmacion de asistencia a una tutoria realizada por un amigo/a" },
                   new NotificationType { Id = 803, Description = "Material compartido enviado por el tutor" },
                   new NotificationType { Id = 804, Description = "Modificacion de horario de una sesion" },
                   new NotificationType { Id = 806, Description = "Aviso enviado por el coordinador" }

                   );

            builder.Entity<Notification>().HasData
                    (
                    new Notification { Id = 901, NotificationTypeId = 801, Link = "Nueva notificacion" },
                    new Notification { Id = 902, NotificationTypeId = 801, Link = "dasda" },
                    new Notification { Id = 903, NotificationTypeId = 801, Link = "cxcqscadas" }
                    );
            builder.Entity<NotificationUser>().HasData
                    (
                    new NotificationUser { NotificationId = 901, UserId = 101 },
                    new NotificationUser { NotificationId = 902, UserId = 101 },
                    new NotificationUser { NotificationId = 903, UserId = 102 }
                    );
        }
    }
}
