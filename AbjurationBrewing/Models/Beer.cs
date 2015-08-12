namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.Beers")]
    public partial class Beer
    {
        public Beer()
        {
            BeerIterations = new HashSet<BeerIteration>();
            BeerVersions = new HashSet<BeerVersion>();
        }

        public int BeerId { get; set; }

        [StringLength(75)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Abbreviation { get; set; }

        public virtual ICollection<BeerIteration> BeerIterations { get; set; }

        public virtual ICollection<BeerVersion> BeerVersions { get; set; }
    }
}
