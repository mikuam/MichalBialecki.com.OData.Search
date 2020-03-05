using System.Threading.Tasks;

namespace MichalBialecki.com.OData.SmartSearch.Web
{
    public interface IProfileService
    {
        Task<int> AddProfiles(int count);
    }
}