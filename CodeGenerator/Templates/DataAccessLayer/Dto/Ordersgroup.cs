using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_ordersgroup_parentid")]
    public partial class ordersgroup
    {
        public ordersgroup()
        {
            orders = new HashSet<orders>();
        }

        [Key]
        public int idordersgroup { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "text")]
        public string? filtertext { get; set; }
        public int? numpos { get; set; }
        public short? isload { get; set; }
        public bool? indealerbase { get; set; }

        [InverseProperty("idordersgroupNavigation")]
        public virtual ICollection<orders> orders { get; set; }
    }
}
