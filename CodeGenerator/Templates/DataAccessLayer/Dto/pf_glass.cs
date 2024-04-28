using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor1", Name = "idx_pf_glass_idcolor1")]
    [Index("idcolor2", Name = "idx_pf_glass_idcolor2")]
    [Index("idconstructiontype", Name = "idx_pf_glass_idconstructiontype")]
    [Index("idmodelparam1", Name = "idx_pf_glass_idmodelparam1")]
    [Index("idmodelparam2", Name = "idx_pf_glass_idmodelparam2")]
    [Index("idproductiontype", Name = "idx_pf_glass_idproductiontype")]
    [Index("idsystem_furniture", Name = "idx_pf_glass_idsystem_furniture")]
    [Index("idsystem_profile", Name = "idx_pf_glass_idsystem_profile")]
    public partial class pf_glass
    {
        public pf_glass()
        {
            pf_glass_ct_source = new HashSet<pf_glass_ct_source>();
            pf_glass_source_ge = new HashSet<pf_glass_source_ge>();
            pf_glass_source_glass = new HashSet<pf_glass_source_glass>();
        }

        [Key]
        public int idpf_glass { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idproductiontype { get; set; }
        public int? idconstructiontype { get; set; }
        public bool? constructor { get; set; }
        public int? idsystem_profile { get; set; }
        public int? idsystem_furniture { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idmodelparam1 { get; set; }
        public int? idmodelparam2 { get; set; }

        [ForeignKey("idcolor1")]
        [InverseProperty("pf_glassidcolor1Navigation")]
        public virtual color? idcolor1Navigation { get; set; }
        [ForeignKey("idcolor2")]
        [InverseProperty("pf_glassidcolor2Navigation")]
        public virtual color? idcolor2Navigation { get; set; }
        [ForeignKey("idconstructiontype")]
        [InverseProperty("pf_glass")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idmodelparam1")]
        [InverseProperty("pf_glassidmodelparam1Navigation")]
        public virtual modelparam? idmodelparam1Navigation { get; set; }
        [ForeignKey("idmodelparam2")]
        [InverseProperty("pf_glassidmodelparam2Navigation")]
        public virtual modelparam? idmodelparam2Navigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("pf_glass")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
        [ForeignKey("idsystem_furniture")]
        [InverseProperty("pf_glassidsystem_furnitureNavigation")]
        public virtual system? idsystem_furnitureNavigation { get; set; }
        [ForeignKey("idsystem_profile")]
        [InverseProperty("pf_glassidsystem_profileNavigation")]
        public virtual system? idsystem_profileNavigation { get; set; }
        [InverseProperty("idpf_glassNavigation")]
        public virtual ICollection<pf_glass_ct_source> pf_glass_ct_source { get; set; }
        [InverseProperty("idpf_glassNavigation")]
        public virtual ICollection<pf_glass_source_ge> pf_glass_source_ge { get; set; }
        [InverseProperty("idpf_glassNavigation")]
        public virtual ICollection<pf_glass_source_glass> pf_glass_source_glass { get; set; }
    }
}
