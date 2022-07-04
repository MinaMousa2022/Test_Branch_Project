namespace Branch_project.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbContexta : DbContext
    {
        public DbContexta()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<files_Branch> files_Branch { get; set; }
        public virtual DbSet<files_Curr> files_Curr { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<files_Branch>()
                .Property(e => e.tel1)
                .IsUnicode(false);

            modelBuilder.Entity<files_Branch>()
                .Property(e => e.tel2)
                .IsUnicode(false);

            modelBuilder.Entity<files_Branch>()
                .Property(e => e.fax)
                .IsUnicode(false);

            modelBuilder.Entity<files_Branch>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<files_Curr>()
                .Property(e => e.currrate)
                .HasPrecision(10, 6);

            modelBuilder.Entity<files_Curr>()
                .Property(e => e.operation)
                .IsUnicode(false);

            modelBuilder.Entity<files_Curr>()
                .Property(e => e.Mfactor)
                .HasPrecision(10, 6);
        }
    }
}
