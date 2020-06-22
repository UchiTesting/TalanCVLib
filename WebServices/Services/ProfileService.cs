using DBEntities;
using DBModel_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;

namespace WebServices
{
    public class ProfileService : IProfileService
    {
        public List<ProfileModel> GetProfiles()
        {
            try
            {
                using (DBContext c = new DBContext())
                {
                    
                    var users = c.Profiles.Select(p => new ProfileModel { ProfileID = p.ProfileID, LastName = p.LastName, FisrtName = p.FisrtName, Gender = (Gender)p.Gender , Adress = p.Adress, BirthOfDate = p.BirthOfDate }).ToList();
                    return users;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //#endif
        public void PostProfile(ProfileModel p)
        {
            try
            {
                
                using (DBContext c = new DBContext())
                {
                    string genre = p.Gender.ToString();
                    var g = Enum.TryParse(genre, out DBEntities.Gender gnr);
                    var profile =  new DBEntities.Profile { ProfileID = p.ProfileID, LastName = p.LastName, FisrtName = p.FisrtName, Gender = gnr, Adress=p.Adress, BirthOfDate = p.BirthOfDate };

                    c.Profiles.Add(profile);
                    c.SaveChanges();
                    
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void PostDeleteProfile(ProfileModel p)
        {
            try
            {
                using (DBContext c = new DBContext())
                {

                    var getprofile = (from profil in c.Profiles
                                      where profil.ProfileID == p.ProfileID
                                      select profil).FirstOrDefault();
                    
                    c.Profiles.Remove(getprofile);
                    c.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PostEditProfile(ProfileModel p)
        {
            try
            {
                using (DBContext c = new DBContext())
                {

                    var getprofile = (from profil in c.Profiles
                                      where profil.ProfileID == p.ProfileID
                                      select profil).FirstOrDefault();

                    string genre = p.Gender.ToString();
                    var g = Enum.TryParse(genre, out DBEntities.Gender gnr);

                    getprofile.FisrtName = p.FisrtName;
                    getprofile.LastName = p.LastName;
                    getprofile.Gender = gnr;
                    getprofile.Adress = p.Adress;
                    getprofile.BirthOfDate = p.BirthOfDate;
                    c.Entry(getprofile).State = EntityState.Modified;
                    c.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        

        public ProfileModel GetProfileByID(int? Id)
        {
            using (DBContext c = new DBContext())
            {
                
                var getprofile = c.Profiles
                    .Where(u => u.ProfileID == Id)
                    .Select(p => new ProfileModel { ProfileID = p.ProfileID, LastName = p.LastName, FisrtName = p.FisrtName, Gender = (Gender)p.Gender, Adress = p.Adress, BirthOfDate = p.BirthOfDate })
                    .FirstOrDefault();
                return getprofile;
            }
        }
    }
}