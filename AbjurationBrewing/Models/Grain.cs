namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.Grains")]
    public partial class Grain
    {
        public int GrainId { get; set; }

        public decimal? GristPercentage { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
