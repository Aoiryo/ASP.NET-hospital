namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bed")]
    public partial class bed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bedNumber { get; set; }

        public int roomNumber { get; set; }

        [StringLength(50)]
        public string bedStatus { get; set; }
    }
}
