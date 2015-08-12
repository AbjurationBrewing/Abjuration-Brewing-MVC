namespace Abjuration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("abjurationUser.Errors")]
    public partial class Error
    {
        public long ErrorId { get; set; }

        public DateTime? ErrorOn { get; set; }

        public string ErrorIn { get; set; }

        public string ErrorDetail { get; set; }

        public int? LoginId { get; set; }
    }
}
