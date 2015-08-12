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
        public Grain()
        {
            GrainsToBeers = new HashSet<GrainsToBeer>();
        }

        public short GrainId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<GrainsToBeer> GrainsToBeers { get; set; }
    }
}
