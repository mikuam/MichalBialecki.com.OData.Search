using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MichalBialecki.com.OData.Search.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfilesGeneratorController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfilesGeneratorController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<int> GenerateProfiles(int count = 1000)
        {
            var profilesAdded = await _profileService.AddProfiles(count);

            return profilesAdded;
        }
    }
}
