namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.GrainsToBeers")]
    public partial class GrainsToBeer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short GrainId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BeerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal VersionNum { get; set; }

        public decimal? GristPercentage { get; set; }

        public virtual BeerVersion BeerVersion { get; set; }

        public virtual Grain Grain { get; set; }
    }
}
