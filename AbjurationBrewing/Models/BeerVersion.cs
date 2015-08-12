namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.BeerVersions")]
    public partial class BeerVersion
    {
        public BeerVersion()
        {
            GrainsToBeers = new HashSet<GrainsToBeer>();
            HopsToBeers = new HashSet<HopsToBeer>();
            SpiceOthers = new HashSet<SpiceOther>();
            BeerGroups = new HashSet<BeerGroup>();
            Yeasts = new HashSet<Yeast>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BeerId { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal VersionNum { get; set; }

        public decimal? OG { get; set; }

        public decimal? FG { get; set; }

        public decimal? SRM { get; set; }

        public decimal? IBU { get; set; }

        public decimal? ABV { get; set; }

        public short? BoilTime { get; set; }

        public string Description { get; set; }

        public virtual Beer Beer { get; set; }

        public virtual ICollection<GrainsToBeer> GrainsToBeers { get; set; }

        public virtual ICollection<HopsToBeer> HopsToBeers { get; set; }

        public virtual ICollection<SpiceOther> SpiceOthers { get; set; }

        public virtual ICollection<BeerGroup> BeerGroups { get; set; }

        public virtual ICollection<Yeast> Yeasts { get; set; }
    }
}
