﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.EntityFrameworkCore;
using MichalBialecki.com.OData.Search.Web.Models;

namespace MichalBialecki.com.OData.Search.Web.Profiles
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly aspnetcoreContext _localDbContext;

        private readonly IProfileService _profileService;

        public ProfilesController(aspnetcoreContext localDbContext, IProfileService profileService)
        {
            _localDbContext = localDbContext;
            _profileService = profileService;
        }

        [HttpGet]
        [EnableQuery()]
        public IQueryable<Profile> Get()
        {
            return _localDbContext.Profiles.AsNoTracking().AsQueryable();
        }

        [HttpPost]
        [Route("GenerateProfiles")]
        public async Task<int> GenerateProfiles(int count = 1000)
        {
            var profilesAdded = await _profileService.AddProfiles(count);

            return profilesAdded;
        }
    }
}
