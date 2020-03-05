using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MichalBialecki.com.OData.SmartSearch.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
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
