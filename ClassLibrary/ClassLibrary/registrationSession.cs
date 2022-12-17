namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("registrationSession")]
    public partial class registrationSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long registrationSessionID { get; set; }

        public long registrationPersonnelID { get; set; }

        public long patientID { get; set; }

        [Required]
        [StringLength(50)]
        public string registrationType { get; set; }

        [Required]
        [StringLength(50)]
        public string registrationObject { get; set; }

        public DateTime sessionTime { get; set; }

        public bool isStart { get; set; }

        [Required]
        [StringLength(50)]
        public string department { get; set; }
    }
}
