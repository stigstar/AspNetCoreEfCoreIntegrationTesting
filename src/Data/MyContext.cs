using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Value> Values { get; set; }
    }
}