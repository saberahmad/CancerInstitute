using CancerInstitute.Models;
using Microsoft.EntityFrameworkCore;

namespace CancerInstitute.Repository
{   
    public class CancerDBContext: DbContext
    {
        public DbSet<Palindrome> Palindromes { get; set; }

        public CancerDBContext ()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CancerDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
