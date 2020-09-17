using SocialNetwork_2.Dto.Profile;
using System.Threading.Tasks;

namespace SocialNetwork_2.Interfaces
{
    public interface IProfileService
    {
        GetProfileByIdDto GetProfileById(int id);
        Task<GetProfileByIdDto> GetProfileByIdAsync(int id);
    }
}
