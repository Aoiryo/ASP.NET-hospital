namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("medicalPersonnel")]
    public partial class medicalPersonnel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long medicalPersonnelID { get; set; }

        [Required]
        [StringLength(50)]
        public string IDNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public bool isExpert { get; set; }

        [StringLength(50)]
        public string introduction { get; set; }

        [StringLength(50)]
        public string job { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        public bool isDimission { get; set; }

        public bool gender { get; set; }

        public int? age { get; set; }

        [StringLength(50)]
        public string contactInformation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }
    }
}
