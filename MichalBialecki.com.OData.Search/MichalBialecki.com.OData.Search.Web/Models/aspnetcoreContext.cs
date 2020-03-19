using Microsoft.EntityFrameworkCore;

namespace MichalBialecki.com.OData.Search.Web.Models
{
    public partial class aspnetcoreContext : DbContext
    {
        public aspnetcoreContext(DbContextOptions<aspnetcoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Profile> Profiles { get; set; }
    }
}
