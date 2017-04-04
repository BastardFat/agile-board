using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BastardFat.AgileBoard.YetAnother.Database.Tables;
using Npgsql;

namespace BastardFat.AgileBoard.YetAnother.Database
{
    public class MainDBContext : DbContext
    {
        static MainDBContext()
        {
            System.Data.Entity.Database.SetInitializer(new DbInitializer());
        }

        public MainDBContext() : base("DefaultConnection") { }

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