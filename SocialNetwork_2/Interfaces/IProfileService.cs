using SocialNetwork_2.Dto.Profile;
using System.Threading.Tasks;

namespace SocialNetwork_2.Interfaces
{
    public interface IProfileService
    {
        GetProfileDto GetProfileById(int id);
        Task<GetProfileDto> GetProfileByIdAsync(int id);
    }
}
