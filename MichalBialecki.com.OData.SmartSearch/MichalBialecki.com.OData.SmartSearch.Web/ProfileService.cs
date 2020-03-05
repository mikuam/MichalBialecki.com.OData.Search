using System;
using System.Threading.Tasks;
using MichalBialecki.com.OData.SmartSearch.Data;
using MichalBialecki.com.OData.SmartSearch.Data.Models;

namespace MichalBialecki.com.OData.SmartSearch.Web
{
    public class ProfileService : IProfileService
    {
        private readonly ILocalDBContext localDbContext;

        public ProfileService(ILocalDBContext _localDbContext)
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
                await localDbContext.Instance.SaveChangesAsync();

                generatedProfiles += numberOfProfilesToInsert;
            }

            return generatedProfiles;
        }
    }
}
