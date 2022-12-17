namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("examinationEquipment")]
    public partial class examinationEquipment
    {
        [Key]
        [Column("examinationEquipment")]
        [StringLength(50)]
        public string examinationEquipment1 { get; set; }

        [StringLength(50)]
        public string examinationEquipmentStatus { get; set; }
    }
}
