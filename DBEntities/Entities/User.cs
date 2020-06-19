using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBEntities
{
    
    public partial class User
    {
        public User()
        {
            
        }
        public int UserID { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        [StringLength(250)]
        public string Nom { get; set; }

        [StringLength(250)]
        public string Prenom { get; set; }

        [StringLength(250)]
        public string Pseudo { get; set; }

        public DateTime Created { get; set; }


    }
}
