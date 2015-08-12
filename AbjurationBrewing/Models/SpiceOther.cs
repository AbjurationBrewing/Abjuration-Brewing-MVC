namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.SpiceOthers")]
    public partial class SpiceOther
    {
        public short SpiceOtherId { get; set; }

        public int BeerId { get; set; }

        public decimal VersionNum { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(25)]
        public string AdditionTime { get; set; }

        public virtual BeerVersion BeerVersion { get; set; }
    }
}
