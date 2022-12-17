namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("injectingEquipment")]
    public partial class injectingEquipment
    {
        [Key]
        [Column("injectingEquipment")]
        [StringLength(50)]
        public string injectingEquipment1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        public int? injectingEquipmentRemainingQuantity { get; set; }

        [StringLength(50)]
        public string location { get; set; }
    }
}
