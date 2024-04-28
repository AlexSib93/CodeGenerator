using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_pricelistgroup_parentid")]
    public partial class pricelistgroup
    {
        public pricelistgroup()
        {
            pricelist = new HashSet<pricelist>();
        }

        [Key]
        public int idpricelistgroup { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "text")]
        public string? filtertext { get; set; }
        public int? numpos { get; set; }
        public short? isload { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }

        [InverseProperty("idpricelistgroupNavigation")]
        public virtual ICollection<pricelist> pricelist { get; set; }
    }
}
