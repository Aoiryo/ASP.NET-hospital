namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("medicalPersonnelExaminationEquipment")]
    public partial class medicalPersonnelExaminationEquipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string examinationEquipment { get; set; }

        public long medicalPersonnelID { get; set; }
    }
}
