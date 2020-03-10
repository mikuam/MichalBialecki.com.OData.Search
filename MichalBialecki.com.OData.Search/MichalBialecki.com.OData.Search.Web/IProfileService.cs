using System.Threading.Tasks;

namespace MichalBialecki.com.OData.Search.Web
{
    public interface IProfileService
    {
        Task<int> AddProfiles(int count);
    }
}