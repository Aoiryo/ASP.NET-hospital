namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class user
    {
        [Key]
        [StringLength(50)]
        public string IDNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        public long roleID { get; set; }
    }
}
