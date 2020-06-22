using System;
using System.Collections.Generic;


namespace DBModel_DAL
{
    
    public class ProfileModel
    {
        public int ProfileID { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Adress { get; set; }
        public DateTime BirthOfDate { get; set; }
    }
}
