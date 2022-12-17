namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("department")]
    public partial class department
    {
        [Key]
        [Column("department")]
        [StringLength(50)]
        public string department1 { get; set; }

        [StringLength(50)]
        public string openTime { get; set; }

        public int? registrationSourceQuantity { get; set; }

        public int? registeredPersonsQuantity { get; set; }

        public TimeSpan? expectedWaitingTime { get; set; }
    }
}
