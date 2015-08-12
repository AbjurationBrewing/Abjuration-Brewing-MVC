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
        public Yeast()
        {
            BeerVersions = new HashSet<BeerVersion>();
        }

        public short YeastId { get; set; }

        [StringLength(10)]
        public string Abbreviation { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<BeerVersion> BeerVersions { get; set; }
    }
}
