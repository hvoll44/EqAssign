using EqAssign.Models;
using System.Data.Entity;

namespace EqAssign.Models
{
    public class MyDBContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<Equipment> Equipment { get; set; }// My domain models
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<ModelType> ModelTypes { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public MyDBContext()
        {

        }
    }
}