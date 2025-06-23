using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Data
{
    public class MyDbContext: DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
    }
}
