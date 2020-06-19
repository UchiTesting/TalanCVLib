namespace DBWeb.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profiles
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Gender { get; set; }

        public string Nationality { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Zip { get; set; }

        public int CityId { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int Role { get; set; }

        public string PhotoUrl { get; set; }
    }
}
