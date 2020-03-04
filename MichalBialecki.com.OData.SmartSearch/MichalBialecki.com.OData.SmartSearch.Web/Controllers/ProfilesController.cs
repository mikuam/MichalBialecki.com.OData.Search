using Microsoft.AspNetCore.Mvc;

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
        public int GenerateProfiles(int count = 1000)
        {
            var profilesAdded = _profileService.AddProfiles(count);

            return profilesAdded;
        }
    }
}
