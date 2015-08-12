namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.Untappd")]
    public partial class Untappd
    {
        public int UntappdId { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Html { get; set; }
    }
}
