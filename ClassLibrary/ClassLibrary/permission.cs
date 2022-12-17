namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("permission")]
    public partial class permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long permissionID { get; set; }

        [Column("permission")]
        [StringLength(50)]
        public string permission1 { get; set; }

        [StringLength(50)]
        public string permissionDescription { get; set; }

        public long parentPermissionID { get; set; }
    }
}
