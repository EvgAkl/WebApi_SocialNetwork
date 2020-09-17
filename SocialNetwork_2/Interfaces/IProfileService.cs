using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork_2.Dto;

namespace SocialNetwork_2.Interfaces
{
    public interface IProfileService
    {
        GetProfileByIdDto GetProfileById(int id);
    }
}
