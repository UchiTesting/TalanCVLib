using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DBEntities
{
    public enum Gender { Homme, Femme }
    public class Profile
    {
        public int ProfileID { get; set; }
        public string FisrtName { get; set; }
        [Required, StringLength(60, MinimumLength = 1)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Adress { get; set; }
        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthOfDate { get; set; }
        public virtual ICollection<Hobbie> Hobbies { get; set; }



    }
    
}