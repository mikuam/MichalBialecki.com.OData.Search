using System.Threading.Tasks;
using MichalBialecki.com.OData.Search.Web.Models;
using MichalBialecki.com.OData.Search.Web.Profiles;

namespace MichalBialecki.com.OData.Search.Web
{
    public class ProfileService : IProfileService
    {
        private readonly aspnetcoreContext localDbContext;

        public ProfileService(aspnetcoreContext _localDbContext)
        {
            localDbContext = _localDbContext;
        }

        public async Task<int> AddProfiles(int count)
        {
            var profileGenerator = new ProfileGenerator();

            var batchSize = 1000;
            var generatedProfiles = 0;

            while (generatedProfiles < count)
            {
                var numberOfProfilesToInsert = count - generatedProfiles < batchSize
                    ? count - generatedProfiles
                    : batchSize;

                var profiles = profileGenerator.GenerateProfiles(numberOfProfilesToInsert);

                localDbContext.Profiles.AddRange(profiles);
                await localDbContext.SaveChangesAsync();

                generatedProfiles += numberOfProfilesToInsert;
            }

            return generatedProfiles;
        }
    }
}
