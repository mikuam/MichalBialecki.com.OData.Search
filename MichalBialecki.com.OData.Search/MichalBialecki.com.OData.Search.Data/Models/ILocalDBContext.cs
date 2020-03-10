using Microsoft.EntityFrameworkCore;

namespace MichalBialecki.com.OData.Search.Data.Models
{
    public interface ILocalDBContext
    {
        public DbContext Instance { get; }

        public DbSet<Profile> Profiles { get; set; }
    }
}
