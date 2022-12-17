namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long orderNumber { get; set; }

        public long registrationSessionID { get; set; }

        public long medicalPersonnelID { get; set; }

        public DateTime orderTime { get; set; }

        [Required]
        public string orderDetail { get; set; }

        [Column(TypeName = "money")]
        public decimal payment { get; set; }

        [Required]
        [StringLength(50)]
        public string orderType { get; set; }

        [Required]
        [StringLength(50)]
        public string orderStatus { get; set; }
    }
}
