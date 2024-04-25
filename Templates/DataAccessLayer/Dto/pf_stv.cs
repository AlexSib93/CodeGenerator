using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idconstructiontype", Name = "idx_pf_stv_idconstructiontype")]
    [Index("idglass", Name = "idx_pf_stv_idglass")]
    [Index("idproductiontype", Name = "idx_pf_stv_idproductiontype")]
    public partial class pf_stv
    {
        public pf_stv()
        {
            pf_stv_ct_source = new HashSet<pf_stv_ct_source>();
            pf_stv_mp = new HashSet<pf_stv_mp>();
        }

        [Key]
        public int idpf_stv { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idproductiontype { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idglass { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idconstructiontype")]
        [InverseProperty("pf_stv")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idglass")]
        [InverseProperty("pf_stv")]
        public virtual glass? idglassNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("pf_stv")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
        [InverseProperty("idpf_stvNavigation")]
        public virtual ICollection<pf_stv_ct_source> pf_stv_ct_source { get; set; }
        [InverseProperty("idpf_stvNavigation")]
        public virtual ICollection<pf_stv_mp> pf_stv_mp { get; set; }
    }
}
