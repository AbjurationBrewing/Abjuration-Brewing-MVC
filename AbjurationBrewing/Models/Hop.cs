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
        public Hop()
        {
            HopsToBeers = new HashSet<HopsToBeer>();
        }

        public short HopId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<HopsToBeer> HopsToBeers { get; set; }
    }
}
