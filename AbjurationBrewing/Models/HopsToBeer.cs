namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.HopsToBeers")]
    public partial class HopsToBeer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short HopId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BeerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal VersionNum { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(25)]
        public string AdditionTime { get; set; }

        public decimal? IBU { get; set; }

        public short? Sequence { get; set; }

        public virtual BeerVersion BeerVersion { get; set; }

        public virtual Hop Hop { get; set; }
    }
}
