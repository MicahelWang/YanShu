namespace WeChatPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int GroupID { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
