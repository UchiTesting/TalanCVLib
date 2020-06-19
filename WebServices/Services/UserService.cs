using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBModel_DAL;
using DBEntities;

namespace WebServices
{
    public class UserService : IUserService
    {
        //#if DEBUG
        public UserModel GetUser()
        {
            try
            {
                using (DBContext c = new DBContext())
                {
                    var user = c.Users
                        .Select(p => new UserModel { ID = p.UserID, Nom = p.Nom, Prenom = p.Prenom })
                        .FirstOrDefault();

                    return user;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //#endif
        public List<UserModel> GetUsers()
        {
            try
            {
                using (DBContext c = new DBContext())
                {
                    var users = c.Users
                        .Select(p => new UserModel { ID = p.UserID, Nom = p.Nom, Prenom = p.Prenom })
                        .ToList();
                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public UserModel GetUser(UserModel user)
        {
            if (user.ID != 0)
            {
                using (DBContext c = new DBContext())
                {
                    var getuser = c.Users
                        .Where(u => u.UserID == user.ID)
                        .Select(p => new UserModel { ID = p.UserID, Nom = p.Nom, Prenom = p.Prenom })
                        .FirstOrDefault();
                    return getuser;
                }
            }

            if (!string.IsNullOrEmpty(user.Nom))
            {
                using (DBContext c = new DBContext())
                {
                    var getuser = c.Users.Where(u => u.Nom == user.Nom)
                        .Select(p => new UserModel { ID = p.UserID, Nom = p.Nom, Prenom = p.Prenom, Role = Roles.Admin })
                        .FirstOrDefault();
                    return getuser;
                }
            }
            else
                using (DBContext c = new DBContext())
                {
                    var getuser = c.Users
                        .Select(p => new UserModel { ID = p.UserID, Nom = p.Nom, Prenom = p.Prenom, Role = Roles.Admin })
                        .FirstOrDefault();
                    return getuser;
                }
        }

        public UserModel GetUserByID(int Id)
        {
            using (DBContext c = new DBContext())
            {
                var getuser = c.Users.Where(u => u.UserID == Id)
                    .Select(p => new UserModel { ID = p.UserID, Nom = p.Nom, Prenom = p.Prenom })
                    .FirstOrDefault();
                return getuser;
            }
        }

        public bool UserExist(UserModel user)
        {
            try
            {
                using (DBContext c = new DBContext())
                {
                    return c.Users.Any(u => u.Email == user.Email && u.Password == user.Password);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserModel> SearchUser(UserModel user)
        {
            using (DBContext c = new DBContext())
            {
                //10 personnes
                var users = c.Users.Select(u => new UserModel() { Prenom = u.Prenom, Nom = u.Nom }).AsQueryable();
                if (!string.IsNullOrEmpty(user.Prenom))
                {
                    // 5 personnes
                    users = users.Where(u => u.Prenom.Contains(user.Prenom)).AsQueryable();
                }
                if (!string.IsNullOrEmpty(user.Nom))
                {
                    //2 personnes
                    users = users.Where(u => u.Nom.Contains(user.Nom)).AsQueryable();
                }
                return users.ToList();
            }

        }
    }
}
