using Microsoft.EntityFrameworkCore;

namespace HusRumFastigheter.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)

        {

        }
        
    }
}
