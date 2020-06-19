using DBModel_DAL;
using System.Collections.Generic;

namespace WebServices
{
    public interface IProfileService
    {
        ProfileModel GetProfile();
        List<ProfileModel> GetProfiles();
        //Profile GetProfile(Profile profile);
        //bool ProfileExist(Profile profile);
        //Task<ProfileModel> GetCivilStateByIdAsync(int? id);
        //Task<IEnumerable<ProfileModel>> GetAllCivilStatesAsync();
        //Task<int> CreateAsync(ProfileModel civilStateToAdd);
        //Task<int> UpdateAsync(int id, ProfileModel civilStateToUpdate);
        //Task<bool> RemoveCivilStateAsync(int civilStateId);
    }
}
