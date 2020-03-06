using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MichalBialecki.com.OData.SmartSearch.Data.Models;
using Microsoft.AspNet.OData;
using Microsoft.EntityFrameworkCore;

namespace MichalBialecki.com.OData.SmartSearch.Web.Controllers
{
    public class ProfilesController : ControllerBase
    {
        private readonly ILocalDBContext _localDbContext;

        public ProfilesController(ILocalDBContext localDbContext)
        {
            _localDbContext = localDbContext;
        }

        [HttpGet]
        [EnableQuery()]
        public IQueryable<Profile> Get()
        {
            return _localDbContext.Profiles.AsNoTracking().AsQueryable();
        }
    }
}
