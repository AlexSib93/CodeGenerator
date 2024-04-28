using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__pricechangegroup__3B8C7CA7", IsUnique = true)]
    [Index("parentid", Name = "idx_pricechangegroup_parentid")]
    public partial class pricechangegroup
    {
        public pricechangegroup()
        {
            pricechange = new HashSet<pricechange>();
        }

        [Key]
        public int idpricechangegroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }

        [InverseProperty("idpricechangegroupNavigation")]
        public virtual ICollection<pricechange> pricechange { get; set; }
    }
}
