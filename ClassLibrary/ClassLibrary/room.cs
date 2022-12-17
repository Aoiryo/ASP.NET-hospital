namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("room")]
    public partial class room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roomNumber { get; set; }

        [StringLength(50)]
        public string roomType { get; set; }

        public int? bedQuantity { get; set; }
    }
}
