using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcoloraccordance1", Name = "idx_pf_pt_idcoloraccordance1")]
    [Index("idcoloraccordance2", Name = "idx_pf_pt_idcoloraccordance2")]
    [Index("idmodelparam1", Name = "idx_pf_pt_idmodelparam1")]
    [Index("idmodelparam2", Name = "idx_pf_pt_idmodelparam2")]
    [Index("idproductiontype", Name = "idx_pf_pt_idproductiontype")]
    [Index("idsystemdetail", Name = "idx_pf_pt_idsystemdetail")]
    public partial class pf_pt
    {
        public pf_pt()
        {
            pf_pt_ct_source = new HashSet<pf_pt_ct_source>();
            pf_pt_mp_filtr = new HashSet<pf_pt_mp_filtr>();
            pf_pt_mp_set = new HashSet<pf_pt_mp_set>();
        }

        [Key]
        public int idpf_pt { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idproductiontype { get; set; }
        [Column(TypeName = "numeric(5, 1)")]
        public decimal? add_t { get; set; }
        [Column(TypeName = "numeric(5, 1)")]
        public decimal? add_w { get; set; }
        [Column(TypeName = "numeric(5, 1)")]
        public decimal? add_h { get; set; }
        public int? rulecolor1 { get; set; }
        public int? idcoloraccordance1 { get; set; }
        public int? rulecolor2 { get; set; }
        public int? idcoloraccordance2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? typ { get; set; }
        public int? idsystemdetail { get; set; }
        public int? idmodelparam1 { get; set; }
        public int? idmodelparam2 { get; set; }
        [Required]
        public bool? hide { get; set; }

        [ForeignKey("idcoloraccordance1")]
        [InverseProperty("pf_ptidcoloraccordance1Navigation")]
        public virtual coloraccordance? idcoloraccordance1Navigation { get; set; }
        [ForeignKey("idcoloraccordance2")]
        [InverseProperty("pf_ptidcoloraccordance2Navigation")]
        public virtual coloraccordance? idcoloraccordance2Navigation { get; set; }
        [ForeignKey("idmodelparam1")]
        [InverseProperty("pf_ptidmodelparam1Navigation")]
        public virtual modelparam? idmodelparam1Navigation { get; set; }
        [ForeignKey("idmodelparam2")]
        [InverseProperty("pf_ptidmodelparam2Navigation")]
        public virtual modelparam? idmodelparam2Navigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("pf_pt")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
        [ForeignKey("idsystemdetail")]
        [InverseProperty("pf_pt")]
        public virtual systemdetail? idsystemdetailNavigation { get; set; }
        [InverseProperty("idpf_ptNavigation")]
        public virtual ICollection<pf_pt_ct_source> pf_pt_ct_source { get; set; }
        [InverseProperty("idpf_ptNavigation")]
        public virtual ICollection<pf_pt_mp_filtr> pf_pt_mp_filtr { get; set; }
        [InverseProperty("idpf_ptNavigation")]
        public virtual ICollection<pf_pt_mp_set> pf_pt_mp_set { get; set; }
    }
}
