namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.BeerIterations")]
    public partial class BeerIteration
    {
        [Key]
        [Column(Order = 0)]
        public decimal BeerVersion { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BeerId { get; set; }

        [Key]
        [Column("BeerIteration", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BeerIteration1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BrewDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }

        public virtual BeerVersion BeerVersion1 { get; set; }

        public virtual Beer Beer { get; set; }
    }
}
