using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor1", Name = "idx_pf_ms_idcolor1")]
    [Index("idcolor2", Name = "idx_pf_ms_idcolor2")]
    [Index("idconstructiontype", Name = "idx_pf_ms_idconstructiontype")]
    [Index("idglass", Name = "idx_pf_ms_idglass")]
    [Index("idmodelparam1", Name = "idx_pf_ms_idmodelparam1")]
    [Index("idmodelparam2", Name = "idx_pf_ms_idmodelparam2")]
    [Index("idmodelparamvalue", Name = "idx_pf_ms_idmodelparamvalue")]
    [Index("idproductiontype", Name = "idx_pf_ms_idproductiontype")]
    [Index("idsystem_furniture", Name = "idx_pf_ms_idsystem_furniture")]
    [Index("idsystem_profile", Name = "idx_pf_ms_idsystem_profile")]
    public partial class pf_ms
    {
        public pf_ms()
        {
            pf_ms_ct_source = new HashSet<pf_ms_ct_source>();
            pf_ms_mp_filtr = new HashSet<pf_ms_mp_filtr>();
            pf_ms_mp_set = new HashSet<pf_ms_mp_set>();
        }

        [Key]
        public int idpf_ms { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idproductiontype { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idsystem_profile { get; set; }
        public int? idsystem_furniture { get; set; }
        public int? step_w { get; set; }
        public int? step_h { get; set; }
        public bool? carrier { get; set; }
        [Column(TypeName = "numeric(5, 1)")]
        public decimal? add_w { get; set; }
        [Column(TypeName = "numeric(5, 1)")]
        public decimal? add_h { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idmodelparamvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idglass { get; set; }
        public bool? align_stv_imp { get; set; }
        public bool? set_open_type { get; set; }
        public int? min_w { get; set; }
        public int? min_h { get; set; }
        public int? max_w { get; set; }
        public int? max_h { get; set; }
        public int? qu_w { get; set; }
        public int? qu_h { get; set; }
        public int? idmodelparam1 { get; set; }
        public int? idmodelparam2 { get; set; }

        [ForeignKey("idcolor1")]
        [InverseProperty("pf_msidcolor1Navigation")]
        public virtual color? idcolor1Navigation { get; set; }
        [ForeignKey("idcolor2")]
        [InverseProperty("pf_msidcolor2Navigation")]
        public virtual color? idcolor2Navigation { get; set; }
        [ForeignKey("idconstructiontype")]
        [InverseProperty("pf_ms")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idglass")]
        [InverseProperty("pf_ms")]
        public virtual glass? idglassNavigation { get; set; }
        [ForeignKey("idmodelparam1")]
        [InverseProperty("pf_msidmodelparam1Navigation")]
        public virtual modelparam? idmodelparam1Navigation { get; set; }
        [ForeignKey("idmodelparam2")]
        [InverseProperty("pf_msidmodelparam2Navigation")]
        public virtual modelparam? idmodelparam2Navigation { get; set; }
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("pf_ms")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("pf_ms")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
        [ForeignKey("idsystem_furniture")]
        [InverseProperty("pf_msidsystem_furnitureNavigation")]
        public virtual system? idsystem_furnitureNavigation { get; set; }
        [ForeignKey("idsystem_profile")]
        [InverseProperty("pf_msidsystem_profileNavigation")]
        public virtual system? idsystem_profileNavigation { get; set; }
        [InverseProperty("idpf_msNavigation")]
        public virtual ICollection<pf_ms_ct_source> pf_ms_ct_source { get; set; }
        [InverseProperty("idpf_msNavigation")]
        public virtual ICollection<pf_ms_mp_filtr> pf_ms_mp_filtr { get; set; }
        [InverseProperty("idpf_msNavigation")]
        public virtual ICollection<pf_ms_mp_set> pf_ms_mp_set { get; set; }
    }
}
