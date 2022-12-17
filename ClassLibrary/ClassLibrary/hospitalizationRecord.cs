namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hospitalizationRecord")]
    public partial class hospitalizationRecord
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long patientID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime admissionTime { get; set; }

        public DateTime dischargeTime { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int bedNumber { get; set; }
    }
}
