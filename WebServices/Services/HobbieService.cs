using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebServices
{
    public class HobbieService : IHobbieService
    {
        public Hobbie GetHobbie()
        {
            try
            {
                using (DBContext c = new DBContext())
                {
                    var hobbie = c.Hobbies.Select(p => new Hobbie { HobbieID = p.HobbieID, Description = p.Description }).FirstOrDefault();
                    return hobbie;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //#endif
        public List<Hobbie> GetHobbies(Profile profile)
        {
            try
            {
                using (DBContext c = new DBContext())
                {
                    //Profile profil = new Profile();
                    var profil = (from pro in c.Profiles
                                 where pro.ProfileID == profile.ProfileID
                                 select pro).FirstOrDefault();
                    List<Hobbie> hobbies = new List<Hobbie>();
                    foreach (Hobbie h in profil.Hobbies)
                    {
                        hobbies.Add(h);
                    }
                    return hobbies;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //    public Hobbie GetHobbie(Hobbie hobbie)
        //    {
        //        if (hobbie.HobbieID != 0)
        //        {

        //            using (CVDBContext c = new CVDBContext())
        //            {
        //                var gethobbies = c.Hobbies.Where(u => u.Id == user.ID).Select(p => new UserModel { ID = p.Id, Nom = p.Nom, Prenom = p.Prenom, Role = Roles.Administrator }).FirstOrDefault();
        //                return getuser;

        //            }
        //        }

        //        if (!string.IsNullOrEmpty(user.Nom))
        //        {
        //            using (Context c = new Context())
        //            {
        //                var getuser = c.UserTable.Where(u => u.Nom == user.Nom).Select(p => new UserModel { ID = p.Id, Nom = p.Nom, Prenom = p.Prenom, Role = Roles.Administrator }).FirstOrDefault();
        //                return getuser;

        //            }
        //        }
        //        else
        //            using (Context c = new Context())
        //            {
        //                var getuser = c.UserTable.Select(p => new UserModel { ID = p.Id, Nom = p.Nom, Prenom = p.Prenom, Role = Roles.Administrator }).FirstOrDefault();
        //                return getuser;

        //            }
        //    }
        //}
    }
}