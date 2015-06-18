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
            BeerIterations = new HashSet<BeerIteration>();
        }

        [Key]
        [Column("BeerVersion", Order = 0)]
        public decimal BeerVersion1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BeerId { get; set; }

        public decimal? OG { get; set; }

        public decimal? FG { get; set; }

        public decimal? SRM { get; set; }

        public decimal? IBU { get; set; }

        public decimal? ABV { get; set; }

        public int? BoilTime { get; set; }

        public string Description { get; set; }

        public virtual ICollection<BeerIteration> BeerIterations { get; set; }

        public virtual Beer Beer { get; set; }
    }
}
