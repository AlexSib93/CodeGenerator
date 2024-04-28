using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorderitem", Name = "idx_servicedocpos_idorderitem")]
    [Index("idservicedoc", Name = "idx_servicedocpos_idservicedoc")]
    [Index("idservicereason", Name = "idx_servicedocpos_idservicereason")]
    public partial class servicedocpos
    {
        public servicedocpos()
        {
            servicedocsign = new HashSet<servicedocsign>();
        }

        [Key]
        public int idservicedocpos { get; set; }
        public int? idservicedoc { get; set; }
        public int? numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idservicereason { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }
        public int? addint4 { get; set; }
        public int? addint5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum5 { get; set; }
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [Unicode(false)]
        public string? addstr5 { get; set; }
        public int? orderitemnum { get; set; }

        [ForeignKey("idorderitem")]
        [InverseProperty("servicedocpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [ForeignKey("idservicedoc")]
        [InverseProperty("servicedocpos")]
        public virtual servicedoc? idservicedocNavigation { get; set; }
        [ForeignKey("idservicereason")]
        [InverseProperty("servicedocpos")]
        public virtual servicereason? idservicereasonNavigation { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<servicedocsign> servicedocsign { get; set; }
    }
}
