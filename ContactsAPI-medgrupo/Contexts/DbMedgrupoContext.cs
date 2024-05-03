using ContactsAPI_medgrupo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace ContactsAPI_medgrupo.Contexts
{
    public class DbMedgrupoContext : DbContext
    {
        public DbMedgrupoContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=db-medgrupo;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        

        public DbSet<Contact> Contacts { get; set;}
    }
}
