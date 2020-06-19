namespace DBWeb.CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBTalan : DbContext
    {
        public DBTalan()
            : base("name=DBTalan")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<CivilStates> CivilStates { get; set; }
        public virtual DbSet<Profiles> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
