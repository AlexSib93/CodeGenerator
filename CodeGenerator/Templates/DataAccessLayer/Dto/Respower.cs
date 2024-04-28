using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorder", Name = "idx_respower_idorder")]
    [Index("idorderitem", Name = "idx_respower_idorderitem")]
    [Index("idpeople", Name = "idx_respower_idpeople")]
    [Index("idpeople2", Name = "idx_respower_idpeople2")]
    [Index("idpower", Name = "idx_respower_idpower")]
    [Index("idservicedoc", Name = "idx_respower_idservicedoc")]
    public partial class respower
    {
        [Key]
        public int idrespower { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        public int? idpower { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? val { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        public int? idpeople2 { get; set; }
        public int? idorder { get; set; }
        public int? idservicedoc { get; set; }
        public int? idorderitem { get; set; }
        public int? orderitemnum { get; set; }

        [ForeignKey("idorder")]
        [InverseProperty("respower")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("respower")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [ForeignKey("idpeople2")]
        [InverseProperty("respoweridpeople2Navigation")]
        public virtual people? idpeople2Navigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("respoweridpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpower")]
        [InverseProperty("respower")]
        public virtual power? idpowerNavigation { get; set; }
        [ForeignKey("idservicedoc")]
        [InverseProperty("respower")]
        public virtual servicedoc? idservicedocNavigation { get; set; }
    }
}
