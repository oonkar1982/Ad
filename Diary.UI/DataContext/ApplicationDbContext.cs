using Diary.UI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.UI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Lawsuit> Lawsuits { get; set; }
        public DbSet<Hearing> Hearings { get; set; }
        public DbSet<Court> Court { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Messagerecipient> Recipient { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country>Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CaseCategory> CaseCategories { get; set; }
        public DbSet<StringMap> StringMap { get; set; }
        public DbSet<Document> Documents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

        }
    }
}
    

