namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.Hops")]
    public partial class Hop
    {
        public int HopId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public decimal? IBU { get; set; }

        [StringLength(50)]
        public string AdditionTime { get; set; }
    }
}
