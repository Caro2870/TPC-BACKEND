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

        }
    }
}
