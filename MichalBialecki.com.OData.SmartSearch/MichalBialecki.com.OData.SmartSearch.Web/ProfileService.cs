using MichalBialecki.com.OData.SmartSearch.Data;

namespace MichalBialecki.com.OData.SmartSearch.Web
{
    public class ProfileService : IProfileService
    {
        public int AddProfiles(int count)
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

                // insert

                generatedProfiles += numberOfProfilesToInsert;
            }


            return generatedProfiles;
        }
    }
}
