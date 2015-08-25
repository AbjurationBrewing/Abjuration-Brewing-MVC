namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.BeerGroups")]
    public partial class BeerGroup
    {
        public BeerGroup()
        {
            BeerVersionsInGroups = new HashSet<BeerVersionsInGroup>();
        }

        public short BeerGroupId { get; set; }

        [StringLength(25)]
        public string BeerGroupName { get; set; }

        public virtual ICollection<BeerVersionsInGroup> BeerVersionsInGroups { get; set; }
    }
}
