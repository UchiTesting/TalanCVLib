using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DBEntities
{
    public class DBContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Hobbie> Hobbies { get; set; }

    }
}
