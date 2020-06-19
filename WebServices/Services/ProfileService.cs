using DBEntities;
using DBModel_DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebServices
{
    public class ProfileService : IProfileService
    {
        public ProfileModel GetProfile()
        {
            try
            {
                using (DBContext c = new DBContext())
                {
                    var user = c.Profiles.Select(p => new ProfileModel { ProfileID = p.ProfileID, LastName = p.LastName, FisrtName = p.FisrtName }).FirstOrDefault();
                    return user;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //#endif
        public List<ProfileModel> GetProfiles()
        {
            try
            {
                using (DBContext c = new DBContext())
                {
                    var users = c.Profiles.Select(p => new ProfileModel { ProfileID = p.ProfileID, LastName = p.LastName, FisrtName = p.FisrtName }).ToList();
                    return users;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}