namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("visitRecord")]
    public partial class visitRecord
    {
        [Key]
        [StringLength(50)]
        public string IDNumber { get; set; }

        public DateTime time { get; set; }

        public bool isVisit { get; set; }

        public double? temperature { get; set; }

        [StringLength(50)]
        public string healthCodeStatus { get; set; }
    }
}
