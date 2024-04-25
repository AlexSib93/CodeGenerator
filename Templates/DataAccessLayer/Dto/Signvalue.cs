using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__signvalue__3F5D0D8B", IsUnique = true)]
    [Index("idsign", Name = "idx_signvalue_idsign")]
    public partial class signvalue
    {
        public signvalue()
        {
            delivdocsign = new HashSet<delivdocsign>();
            installdocsign = new HashSet<installdocsign>();
            manufactdocsign = new HashSet<manufactdocsign>();
            optimdocsign = new HashSet<optimdocsign>();
            ordersign = new HashSet<ordersign>();
            signgrant = new HashSet<signgrant>();
            techdocsign = new HashSet<techdocsign>();
        }

        [Key]
        public int idsignvalue { get; set; }
        public int? idsign { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idsign")]
        [InverseProperty("signvalue")]
        public virtual sign? idsignNavigation { get; set; }
        [InverseProperty("idsignvalueNavigation")]
        public virtual ICollection<delivdocsign> delivdocsign { get; set; }
        [InverseProperty("idsignvalueNavigation")]
        public virtual ICollection<installdocsign> installdocsign { get; set; }
        [InverseProperty("idsignvalueNavigation")]
        public virtual ICollection<manufactdocsign> manufactdocsign { get; set; }
        [InverseProperty("idsignvalueNavigation")]
        public virtual ICollection<optimdocsign> optimdocsign { get; set; }
        [InverseProperty("idsignvalueNavigation")]
        public virtual ICollection<ordersign> ordersign { get; set; }
        [InverseProperty("idsignvalueNavigation")]
        public virtual ICollection<signgrant> signgrant { get; set; }
        [InverseProperty("idsignvalueNavigation")]
        public virtual ICollection<techdocsign> techdocsign { get; set; }
    }
}
