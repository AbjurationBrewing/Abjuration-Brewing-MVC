namespace Abjuration.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
        }

        public virtual DbSet<Untappd> Untappds { get; set; }
        public virtual DbSet<BeerIteration> BeerIterations { get; set; }
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<BeerVersion> BeerVersions { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Grain> Grains { get; set; }
        public virtual DbSet<Hop> Hops { get; set; }
        public virtual DbSet<Yeast> Yeasts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Beer>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.OG)
                .HasPrecision(18, 4);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.FG)
                .HasPrecision(18, 4);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.SRM)
                .HasPrecision(18, 1);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.IBU)
                .HasPrecision(18, 1);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BeerVersion>()
                .HasMany(e => e.BeerIterations)
                .WithRequired(e => e.BeerVersion1)
                .HasForeignKey(e => new { e.BeerVersion, e.BeerId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grain>()
                .Property(e => e.GristPercentage)
                .HasPrecision(18, 1);

            modelBuilder.Entity<Grain>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hop>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hop>()
                .Property(e => e.IBU)
                .HasPrecision(18, 1);

            modelBuilder.Entity<Hop>()
                .Property(e => e.AdditionTime)
                .IsUnicode(false);

            modelBuilder.Entity<Yeast>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<Yeast>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
