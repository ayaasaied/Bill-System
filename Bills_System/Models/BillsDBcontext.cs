using Bills.Models;
using Microsoft.EntityFrameworkCore;

namespace Bills.Data
{
    public class BillsDBcontext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
               .Property(b => b.Created)
               .HasDefaultValueSql("getdate()");
        }
        public BillsDBcontext()
        { }
        public BillsDBcontext(DbContextOptions options) : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-F568GJP\\SQLEXPRESS;Initial Catalog=Bills;Integrated Security=True");
        }
        public DbSet<Company> Company { get; set; }

        public DbSet<Client> Client { get; set; }
        public DbSet<Item> Item { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<SalesDetalis> SalesDetalis { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<Unit> Unit { get; set; }
    }

}
