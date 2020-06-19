using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel_DAL;

namespace WebServices
{
    public interface IUserService
    {
        UserModel GetUser();
        List<UserModel> GetUsers();
        UserModel GetUser(UserModel user);
        bool UserExist(UserModel user);
    }
}
