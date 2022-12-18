namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("scheduling")]
    public partial class scheduling
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long medicalPersonnelID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime dutyTime { get; set; }

        [StringLength(50)]
        public string dutyPlace { get; set; }

        [StringLength(50)]
        public string schedulingStatus { get; set; }

        [StringLength(2)]
        public string timeDetail { get; set; }
    }
}
