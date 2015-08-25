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

        public virtual DbSet<BeerGroup> BeerGroups { get; set; }
        public virtual DbSet<BeerIteration> BeerIterations { get; set; }
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<BeerVersion> BeerVersions { get; set; }
        public virtual DbSet<BeerVersionsInGroup> BeerVersionsInGroups { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Grain> Grains { get; set; }
        public virtual DbSet<GrainsToBeer> GrainsToBeers { get; set; }
        public virtual DbSet<Hop> Hops { get; set; }
        public virtual DbSet<HopsToBeer> HopsToBeers { get; set; }
        public virtual DbSet<SpiceOther> SpiceOthers { get; set; }
        public virtual DbSet<Untappd> Untappds { get; set; }
        public virtual DbSet<Yeast> Yeasts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerGroup>()
                .Property(e => e.BeerGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<BeerIteration>()
                .Property(e => e.VersionNum)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Beer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Beer>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.VersionNum)
                .HasPrecision(5, 2);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.OG)
                .HasPrecision(4, 3);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.FG)
                .HasPrecision(4, 3);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.SRM)
                .HasPrecision(4, 1);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.IBU)
                .HasPrecision(5, 1);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.ABV)
                .HasPrecision(5, 2);

            modelBuilder.Entity<BeerVersion>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BeerVersion>()
                .HasMany(e => e.BeerVersionsInGroups)
                .WithRequired(e => e.BeerVersion)
                .HasForeignKey(e => new { e.BeerId, e.VersionNum });

            modelBuilder.Entity<BeerVersion>()
                .HasMany(e => e.GrainsToBeers)
                .WithRequired(e => e.BeerVersion)
                .HasForeignKey(e => new { e.BeerId, e.VersionNum });

            modelBuilder.Entity<BeerVersion>()
                .HasMany(e => e.HopsToBeers)
                .WithRequired(e => e.BeerVersion)
                .HasForeignKey(e => new { e.BeerId, e.VersionNum });

            modelBuilder.Entity<BeerVersion>()
                .HasMany(e => e.SpiceOthers)
                .WithRequired(e => e.BeerVersion)
                .HasForeignKey(e => new { e.BeerId, e.VersionNum });

            modelBuilder.Entity<BeerVersion>()
                .HasMany(e => e.Yeasts)
                .WithMany(e => e.BeerVersions)
                .Map(m => m.ToTable("YeastsToBeers", "abjurationUser").MapLeftKey(new[] { "BeerId", "VersionNum" }).MapRightKey("YeastId"));

            modelBuilder.Entity<BeerVersionsInGroup>()
                .Property(e => e.VersionNum)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Grain>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<GrainsToBeer>()
                .Property(e => e.VersionNum)
                .HasPrecision(5, 2);

            modelBuilder.Entity<GrainsToBeer>()
                .Property(e => e.GristPercentage)
                .HasPrecision(4, 1);

            modelBuilder.Entity<Hop>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<HopsToBeer>()
                .Property(e => e.VersionNum)
                .HasPrecision(5, 2);

            modelBuilder.Entity<HopsToBeer>()
                .Property(e => e.AdditionTime)
                .IsUnicode(false);

            modelBuilder.Entity<HopsToBeer>()
                .Property(e => e.IBU)
                .HasPrecision(5, 1);

            modelBuilder.Entity<SpiceOther>()
                .Property(e => e.VersionNum)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SpiceOther>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SpiceOther>()
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
