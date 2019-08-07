using Microsoft.EntityFrameworkCore;

namespace CMDAPI.Models
{
    public class CommandContext:DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options): base (options)
        {

        }

        public DbSet<User> User {get; set;}
    }
}