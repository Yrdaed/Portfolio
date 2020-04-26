using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<User> Users { get; set; }
    }
}