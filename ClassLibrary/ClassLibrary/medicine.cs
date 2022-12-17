namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("medicine")]
    public partial class medicine
    {
        [Key]
        [Column("medicine")]
        [StringLength(50)]
        public string medicine1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        public int? medicineRemainingQuantity { get; set; }

        [StringLength(50)]
        public string location { get; set; }
    }
}
