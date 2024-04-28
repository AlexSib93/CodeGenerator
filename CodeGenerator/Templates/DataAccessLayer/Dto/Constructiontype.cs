using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__constructiontype__5DE194AB", IsUnique = true)]
    [Index("idversion", Name = "idx_constructiontype_idversion")]
    public partial class constructiontype
    {
        public constructiontype()
        {
            constructiontypedetail = new HashSet<constructiontypedetail>();
            insertionparam = new HashSet<insertionparam>();
            insertionparamdetail = new HashSet<insertionparamdetail>();
            modelparamcondition = new HashSet<modelparamcondition>();
            pf_glass = new HashSet<pf_glass>();
            pf_glass_ct_source = new HashSet<pf_glass_ct_source>();
            pf_ms = new HashSet<pf_ms>();
            pf_ms_ct_source = new HashSet<pf_ms_ct_source>();
            pf_pt_ct_source = new HashSet<pf_pt_ct_source>();
            pf_stv = new HashSet<pf_stv>();
            pf_stv_ct_source = new HashSet<pf_stv_ct_source>();
            productiontype = new HashSet<productiontype>();
            productiontypeconstruction = new HashSet<productiontypeconstruction>();
            shtapikgroupparamdetail = new HashSet<shtapikgroupparamdetail>();
            sizedocconstrtype = new HashSet<sizedocconstrtype>();
            variantparam = new HashSet<variantparam>();
            variantparamdetail = new HashSet<variantparamdetail>();
        }

        [Key]
        public int idconstructiontype { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idversion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? numpos { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }
        public int? openview { get; set; }
        [StringLength(64)]
        public string? name_strkey { get; set; }

        [ForeignKey("idversion")]
        [InverseProperty("constructiontype")]
        public virtual versions? idversionNavigation { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<constructiontypedetail> constructiontypedetail { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<insertionparam> insertionparam { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<insertionparamdetail> insertionparamdetail { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<pf_glass> pf_glass { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<pf_glass_ct_source> pf_glass_ct_source { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<pf_ms> pf_ms { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<pf_ms_ct_source> pf_ms_ct_source { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<pf_pt_ct_source> pf_pt_ct_source { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<pf_stv> pf_stv { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<pf_stv_ct_source> pf_stv_ct_source { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<productiontype> productiontype { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<productiontypeconstruction> productiontypeconstruction { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<shtapikgroupparamdetail> shtapikgroupparamdetail { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<sizedocconstrtype> sizedocconstrtype { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<variantparam> variantparam { get; set; }
        [InverseProperty("idconstructiontypeNavigation")]
        public virtual ICollection<variantparamdetail> variantparamdetail { get; set; }
    }
}
