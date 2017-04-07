using System;
using System.Data.Entity;
using BastardFat.ThirdVersion.Models.Database;
using Npgsql;

namespace BastardFat.ThirdVersion.DatabaseInteraction.Context
{
    public class MainDbContext : DbContext
    {
        static MainDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public MainDbContext() : base("DefaultConnection") { }

        public DbSet<StudyPlace> StudyPlaces { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<People> Peoples { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<WorkPlace>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<StudyPlace>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<People>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<People>()
                .HasRequired(m => m.StudyPlace)
                .WithMany(t => t.Peoples)
                .HasForeignKey(m => m.StudyPlaceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<People>()
                .HasRequired(m => m.WorkPlace)
                .WithMany(t => t.Peoples)
                .HasForeignKey(m => m.WorkPlaceId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        //public new void Dispose()
        //{
        //    System.Diagnostics.Debug.WriteLine("DbContext disposed!");
        //    base.Dispose();
        //}

        class NpgsqlConfiguration : DbConfiguration
        {
            public NpgsqlConfiguration()
            {
                SetProviderServices("Npgsql", NpgsqlServices.Instance);
                SetProviderFactory("Npgsql", NpgsqlFactory.Instance);
                SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
            }
        }
    }
}