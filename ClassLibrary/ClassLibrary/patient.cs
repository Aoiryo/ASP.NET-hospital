namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("patient")]
    public partial class patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long patientID { get; set; }

        [Required]
        [StringLength(50)]
        public string IDNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public bool gender { get; set; }

        public int? age { get; set; }

        [StringLength(50)]
        public string contactInformation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }
    }
}
