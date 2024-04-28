using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodservicegroup__6582B673", IsUnique = true)]
    [Index("parentid", Name = "idx_goodservicegroup_parentid")]
    public partial class goodservicegroup
    {
        public goodservicegroup()
        {
            goodservice = new HashSet<goodservice>();
        }

        [Key]
        public int idgoodservicegroup { get; set; }
        public int? parentid { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? name { get; set; }
        public short? isactive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }

        [InverseProperty("idgoodservicegroupNavigation")]
        public virtual ICollection<goodservice> goodservice { get; set; }
    }
}
