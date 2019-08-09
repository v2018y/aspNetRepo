using Microsoft.EntityFrameworkCore;

namespace CMDAPI.Models
{
    public class CommandContext:DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options): base (options)
        {

        }

        public DbSet<User> User {get; set;}
        public DbSet<FoodItem> FoodItem {get; set;}
        public DbSet<FoodQty> FoodQty {get; set;}
        public DbSet<HTable> HTable {get; set;}
        public DbSet<Invoice> Invoice {get; set;}

    }
}