using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WeChatPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    [Serializable]
    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public DateTime? UpdatedDate { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public int? UpdatedBy { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public int Status { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public virtual User User { get; set; }
    }
}
