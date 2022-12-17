namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("medicalHistory")]
    public partial class medicalHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long patientID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime diagnosisTime { get; set; }

        [Required]
        [StringLength(50)]
        public string department { get; set; }

        public long medicalPersonnelID { get; set; }

        public string diagnosisResult { get; set; }
    }
}
