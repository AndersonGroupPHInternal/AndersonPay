using AndersonPayEntity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AndersonPayContext
{
    public class Context : DbContext
    {
        public Context() : base("AndersonPay")
        {
            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        //To Do: Use Capital Letters on non private properties

        public DbSet<EArchive> Archives { get; set; }
        public DbSet<EEmployee> Employees { get; set; }
        public DbSet<EFileDetail> FileDetails { get; set; }
        public DbSet<EInvoice> Invoices { get; set; }
        public DbSet<EJobs> jobs { get; set; }
        public DbSet<EManpowerFile> ManpowerFiles { get; set; }
        public DbSet<EManpower> Manpowers { get; set; }
        public DbSet<EService> Services { get; set; }
        public DbSet<EClientEmail> ClientEmail { get; set; }
        public DbSet<ETypeOfService> Typeofservices { get; set; }
        public DbSet<EClient> Client { get; set; }
        public DbSet<ETaxType> TaxType { get; set; }
        public DbSet<EPayment> Payment { get; set; }
        public DbSet<ECurrencyCode> CurrencyCode { get; set; }
        public DbSet<ECompanyAddress> CompanyAddress { get; set; }

    }
}
