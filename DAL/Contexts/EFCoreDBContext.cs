using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Contexts
{
    public class EFCoreDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }

        public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
