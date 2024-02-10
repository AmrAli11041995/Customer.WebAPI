using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
//using Customer.Core.DomainModels;
namespace Customer.Infrastructure.DBContext
{
    public class AppDBContext : DbContext
    {
        private HttpContext _httpContext { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }
        public DbSet<Customer.Core.DomainModels.Customer> Customers { get; set; }
        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // add your connection string and create this DB 
            optionsBuilder.UseSqlServer("Server=.;Database=CusmerDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}