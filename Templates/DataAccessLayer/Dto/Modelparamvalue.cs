using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__modelparamvalue__1EBB33CF", IsUnique = true)]
    [Index("idmodelparam", Name = "idx_modelparamvalue_idmodelparam")]
    [Index("idvectorpicture", Name = "idx_modelparamvalue_idvectorpicture")]
    public partial class modelparamvalue
    {
        public modelparamvalue()
        {
            insertionparam = new HashSet<insertionparam>();
            insertionparamdetail = new HashSet<insertionparamdetail>();
            modelparamcalcidmodelparamvalue2Navigation = new HashSet<modelparamcalc>();
            modelparamcalcidmodelparamvalueNavigation = new HashSet<modelparamcalc>();
            modelparamcondition = new HashSet<modelparamcondition>();
            modelparamconditiondetail = new HashSet<modelparamconditiondetail>();
            pf_ms = new HashSet<pf_ms>();
            pf_ms_mp_filtr = new HashSet<pf_ms_mp_filtr>();
            pf_ms_mp_set = new HashSet<pf_ms_mp_set>();
            pf_pt_mp_filtr = new HashSet<pf_pt_mp_filtr>();
            pf_pt_mp_set = new HashSet<pf_pt_mp_set>();
            pf_stv_mp = new HashSet<pf_stv_mp>();
            productiontypeparamidmodelparamvalue2Navigation = new HashSet<productiontypeparam>();
            productiontypeparamidmodelparamvalueNavigation = new HashSet<productiontypeparam>();
            shtapikgroupparamdetail = new HashSet<shtapikgroupparamdetail>();
            variantparam = new HashSet<variantparam>();
            variantparamdetail = new HashSet<variantparamdetail>();
        }

        [Key]
        public int idmodelparamvalue { get; set; }
        public int? idmodelparam { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? onlyint { get; set; }
        public short? onlystr { get; set; }
        public short? onlystr2 { get; set; }
        public Guid guid { get; set; }
        public int? numpos { get; set; }
        public int? idvectorpicture { get; set; }
        [StringLength(128)]
        public string? strvalue_strkey { get; set; }
        [StringLength(128)]
        public string? strvalue2_strkey { get; set; }

        [ForeignKey("idmodelparam")]
        [InverseProperty("modelparamvalue")]
        public virtual modelparam? idmodelparamNavigation { get; set; }
        [ForeignKey("idvectorpicture")]
        [InverseProperty("modelparamvalue")]
        public virtual vectorpicture? idvectorpictureNavigation { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<insertionparam> insertionparam { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<insertionparamdetail> insertionparamdetail { get; set; }
        [InverseProperty("idmodelparamvalue2Navigation")]
        public virtual ICollection<modelparamcalc> modelparamcalcidmodelparamvalue2Navigation { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<modelparamcalc> modelparamcalcidmodelparamvalueNavigation { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<modelparamconditiondetail> modelparamconditiondetail { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<pf_ms> pf_ms { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<pf_ms_mp_filtr> pf_ms_mp_filtr { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<pf_ms_mp_set> pf_ms_mp_set { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<pf_pt_mp_filtr> pf_pt_mp_filtr { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<pf_pt_mp_set> pf_pt_mp_set { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<pf_stv_mp> pf_stv_mp { get; set; }
        [InverseProperty("idmodelparamvalue2Navigation")]
        public virtual ICollection<productiontypeparam> productiontypeparamidmodelparamvalue2Navigation { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<productiontypeparam> productiontypeparamidmodelparamvalueNavigation { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<shtapikgroupparamdetail> shtapikgroupparamdetail { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<variantparam> variantparam { get; set; }
        [InverseProperty("idmodelparamvalueNavigation")]
        public virtual ICollection<variantparamdetail> variantparamdetail { get; set; }
    }
}
