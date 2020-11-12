using SocialNetwork_2.Dto.Profile;
using System.Threading.Tasks;

namespace SocialNetwork_2.Interfaces
{
    public interface IProfileService
    {
        GetProfileDto GetProfileById(int id);
        Task<GetProfileDto> GetProfileByIdAsync(int id);
        GetProfileDto AddProfile(AddProfileDto addProfileDto);
        Task<GetProfileDto> AddProfileAsync(AddProfileDto addProfileDto);
        void UpdateProfile(UpdateProfileDto updateProfileDto);
        Task UpdateProfileAsync(UpdateProfileDto updateProfileDto);
    }
}
