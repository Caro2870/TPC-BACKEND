using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Extensions;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Persistence.Contexts
{   // ajustes de la definicion del modelo
    public class AppDbContext: DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set;}
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<MailMessage> MailMessages { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            //
            //University Entity
            builder.Entity<University>().ToTable("Universities");
            //Constraints
            builder.Entity<University>().HasKey(p => p.Id);   //PK
            builder.Entity<University>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<University>().Property(p => p.UniversityName).IsRequired().HasMaxLength(50);

            // relations

            builder.Entity<University>().
                HasOne(a => a.Account)
                .WithOne(b => b.University)
                .HasForeignKey<Account>(b => b.UniversityId);

            //seed data

            builder.Entity<University>().HasData
                (
                new University { Id = 101, UniversityName ="UPC" },
                 new University { Id = 102, UniversityName ="UPN"}
                );

            //

            //Account Entity
            builder.Entity<Account>().ToTable("Accounts");
            //Constraints
            builder.Entity<Account>().HasKey(p => p.Id);   //PK
            builder.Entity<Account>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Account>().Property(p => p.AccountName).IsRequired().HasMaxLength(50);
            builder.Entity<Account>().Property(p => p.Password).IsRequired().HasMaxLength(50);

            // relations

            builder.Entity<Account>().
                HasOne(a => a.User)
                .WithOne(b => b.Account)
                .HasForeignKey<User>(b => b.AccountId);

            //seed data

            builder.Entity<Account>().HasData
                (
                new Account { Id = 101, AccountName= "notidea" , Password ="123122"},
                 new Account { Id = 102, AccountName = "notideax2", Password = "43242" }
                );


            //

           // User Entity
            builder.Entity<User>().ToTable("Users");

            //Constraints
            builder.Entity<User>().HasKey(p => p.Id);   //PK
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Mail).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.PhoneNumber).IsRequired();


            // Relationships

            // Un usuario tiene muchos suggestions y suggestion tiene un usuario el FK lo tiene UserId;
            builder.Entity<User>().HasMany(a => a.Suggestions).WithOne(b => b.User)
                .HasForeignKey(p => p.UserId);


                         

            builder.Entity<User>().
               HasOne(a => a.Coordinator)
               .WithOne(b => b.User)
               .HasForeignKey<User>(b => b.Id);



            //Seed Data
            builder.Entity<User>().HasData
                (
                new User { Id = 101, FirstName = "Carolina", LastName = "Villegas", Mail = "carol.vi28@gmail.com", PhoneNumber = "+51 920 236 307" },
                 new User { Id = 102, FirstName = "Jessica", LastName = "Fernandez", Mail = "Jessica@gmail.com", PhoneNumber = "+51 923 126 407" }
                );



            //

            // User Suggestion
            builder.Entity<Suggestion>().ToTable("Suggestions");

            //Constraints
            builder.Entity<Suggestion>().HasKey(p => p.Id);   //PK
            builder.Entity<Suggestion>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Suggestion>().Property(p => p.Message).IsRequired().HasMaxLength(400);

            //Seed Data
            builder.Entity<Suggestion>().HasData
                (
                new Suggestion { Id = 101, Message="hola tengo sueño odio aqui"},
                 new Suggestion { Id = 102, Message = "NoOoOoOoOo" }
                );

            //

            // User Faculty
            builder.Entity<Faculty>().ToTable("Faculties");

            //Constraints
            builder.Entity<Faculty>().HasKey(p => p.Id);   //PK
            builder.Entity<Faculty>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<Faculty>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Faculty>().Property(p => p.Description).IsRequired().HasMaxLength(400);


            // Relationships

            // Una facultada tiene muchos coordinadores y coordinador tiene una facultad el FK lo tiene facultyId;
            builder.Entity<Faculty>().HasMany(a => a.Coordinators).WithOne(b => b.Faculty)
                .HasForeignKey(p => p.FacultyId);

            //Seed Data
            builder.Entity<Faculty>().HasData
                (
                new Faculty { Id = 101, Name ="Letras", Description = "hola tengo sueño odio aqui" },
                 new Faculty { Id = 102, Name ="Ciencia", Description = "NoOoOoOoOo" }
                );



            // Coordinator Table
            builder.Entity<Coordinator>().ToTable("Coordinators");
            builder.Entity<Coordinator>().HasKey(p => p.Id);   //PK

            //relations

            //un coordinador tiene muchos mail messages y un mailmessage pertenece a un coordinador el fk lo tiene coordinatorid
            builder.Entity<Coordinator>().HasMany(a => a.MailMessages).WithOne(b => b.Coordinator)
               .HasForeignKey(p => p.CoordinatorId);

            //

            // Mailmessage table

            builder.Entity<MailMessage>().ToTable("MailMessages");

            //Constraints
            builder.Entity<MailMessage>().HasKey(p => p.Id);   //PK
            builder.Entity<MailMessage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();  //GeneraKey
            builder.Entity<MailMessage>().Property(p => p.message).IsRequired().HasMaxLength(30);
            builder.Entity<MailMessage>().Property(p => p.documentlink).IsRequired().HasMaxLength(30);


            //Seed Data
            builder.Entity<MailMessage>().HasData
                (
                new MailMessage { Id = 101, message = "AAAAAAAAAAA", documentlink = "holatengosueñoodioaqui.pdf" },
                 new MailMessage { Id = 102, message = "Cienciaaasdas", documentlink = "NoOoOoOoOo.doc" }
                );

        }
    }
}
