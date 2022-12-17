namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("medicalPersonnelMedicine")]
    public partial class medicalPersonnelMedicine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public long medicalPersonnelID { get; set; }

        [Required]
        [StringLength(50)]
        public string medicine { get; set; }
    }
}
