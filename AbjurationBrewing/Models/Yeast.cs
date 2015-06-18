namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.Yeasts")]
    public partial class Yeast
    {
        public int YeastId { get; set; }

        [StringLength(25)]
        public string Abbreviation { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
