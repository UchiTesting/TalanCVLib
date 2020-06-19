using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebServices
{
    public interface IHobbieService
    {
        Hobbie GetHobbie();
        List<Hobbie> GetHobbies(Profile profile);
        //Hobbie GetHobbie(Hobbie hobbie);
        //bool HobbieExist(Hobbie hobbie);
    }
}
