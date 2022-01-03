using LenderApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LenderApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //creating a new db set inside the application

        public DbSet<Item> Items { get; set; }
    }
}
