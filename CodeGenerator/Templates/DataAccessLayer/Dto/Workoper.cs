using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_workoper_idpeople")]
    [Index("idwork", Name = "idx_workoper_idwork")]
    public partial class workoper
    {
        public workoper()
        {
            docwork = new HashSet<docwork>();
            insertiondetail = new HashSet<insertiondetail>();
            shtapikgroupdetail = new HashSet<shtapikgroupdetail>();
            variantdetail = new HashSet<variantdetail>();
        }

        [Key]
        public int idworkoper { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idwork { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? worktime { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price5 { get; set; }
        public Guid guid { get; set; }
        public int? idvalut1 { get; set; }
        public int? idvalut2 { get; set; }
        public int? idvalut3 { get; set; }
        public int? idvalut4 { get; set; }
        public int? idvalut5 { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("workoper")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idwork")]
        [InverseProperty("workoper")]
        public virtual work? idworkNavigation { get; set; }
        [InverseProperty("idworkoperNavigation")]
        public virtual ICollection<docwork> docwork { get; set; }
        [InverseProperty("idworkoperNavigation")]
        public virtual ICollection<insertiondetail> insertiondetail { get; set; }
        [InverseProperty("idworkoperNavigation")]
        public virtual ICollection<shtapikgroupdetail> shtapikgroupdetail { get; set; }
        [InverseProperty("idworkoperNavigation")]
        public virtual ICollection<variantdetail> variantdetail { get; set; }
    }
}
