using Microsoft.EntityFrameworkCore;
using MvcTriton.Models;

namespace MvcTriton.Data
{
    public class MvcTritonContext : DbContext
    {
        public MvcTritonContext (DbContextOptions<MvcTritonContext> options)
            : base(options)
        {
        }

        public DbSet<Branch> Movie { get; set; }

        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<Waybill> Waybill { get; set; }
        public object Branch { get; internal set; }
    }
}