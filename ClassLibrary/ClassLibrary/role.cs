namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("role")]
    public partial class role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long roleID { get; set; }

        [Column("role")]
        [StringLength(50)]
        public string role1 { get; set; }

        [StringLength(50)]
        public string roleDescription { get; set; }
    }
}
