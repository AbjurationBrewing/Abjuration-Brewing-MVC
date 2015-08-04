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
            Grains = new HashSet<Grain>();
            Hops = new HashSet<Hop>();
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

        public int? BoilTime { get; set; }

        public string Description { get; set; }

        public virtual Beer Beer { get; set; }

        public virtual ICollection<Grain> Grains { get; set; }

        public virtual ICollection<Hop> Hops { get; set; }

        public virtual ICollection<Yeast> Yeasts { get; set; }
    }
}