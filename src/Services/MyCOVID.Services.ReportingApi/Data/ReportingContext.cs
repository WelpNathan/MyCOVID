using Microsoft.EntityFrameworkCore;
using MyCOVID.Services.ReportingApi.Model;

namespace MyCOVID.Services.ReportingApi.Data
{
    public class ReportingContext : DbContext
    {
        public ReportingContext (DbContextOptions<ReportingContext> options) : base(options)
        {
        }
        
        public DbSet<Block> Blocks { get; set; }
        
    }
}