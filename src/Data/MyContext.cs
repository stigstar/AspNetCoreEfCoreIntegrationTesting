using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Value> Values { get; set; }
    }
}