namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.BeerVersionsInGroups")]
    public partial class BeerVersionsInGroup
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BeerId { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal VersionNum { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short BeerGroupId { get; set; }

        public short? Sequnce { get; set; }

        public virtual BeerGroup BeerGroup { get; set; }

        public virtual BeerVersion BeerVersion { get; set; }
    }
}
