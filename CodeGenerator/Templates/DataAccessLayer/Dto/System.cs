using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idversion", Name = "idx_system_idversion")]
    public partial class system
    {
        public system()
        {
            constructiontypedetail = new HashSet<constructiontypedetail>();
            good = new HashSet<good>();
            modelparamcondition = new HashSet<modelparamcondition>();
            pf_glassidsystem_furnitureNavigation = new HashSet<pf_glass>();
            pf_glassidsystem_profileNavigation = new HashSet<pf_glass>();
            pf_msidsystem_furnitureNavigation = new HashSet<pf_ms>();
            pf_msidsystem_profileNavigation = new HashSet<pf_ms>();
            productiontypesystems = new HashSet<productiontypesystems>();
            systemdetail = new HashSet<systemdetail>();
        }

        [Key]
        public int idsystem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idversion { get; set; }
        public int? numpos { get; set; }
        public int? serial { get; set; }
        public int? isactive { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? vars { get; set; }
        public Guid guid { get; set; }
        public int? systemtype { get; set; }
        [Required]
        public bool? allow_pov { get; set; }
        [Required]
        public bool? allow_povotk { get; set; }
        [Required]
        public bool? allow_otk { get; set; }
        [Required]
        public bool? allow_podv { get; set; }
        [Required]
        public bool? allow_razd { get; set; }
        [Required]
        public bool? allow_mayatnik { get; set; }
        [Required]
        public bool? allow_gluhoe { get; set; }
        [Required]
        public bool? allow_centre_handle { get; set; }
        [Required]
        public bool? allow_any_handle { get; set; }
        [Required]
        public bool? allow_fix_handle { get; set; }
        [Required]
        public bool? allow_stv_in_stv { get; set; }
        public bool allow_sered_podves { get; set; }
        public bool allow_pod_razd { get; set; }
        public bool allow_skladnoe { get; set; }
        [StringLength(128)]
        public string? name_strkey { get; set; }
        public bool? allow_pod_pov { get; set; }

        [ForeignKey("idversion")]
        [InverseProperty("system")]
        public virtual versions? idversionNavigation { get; set; }
        [InverseProperty("idsystemNavigation")]
        public virtual ICollection<constructiontypedetail> constructiontypedetail { get; set; }
        [InverseProperty("idsystemNavigation")]
        public virtual ICollection<good> good { get; set; }
        [InverseProperty("idsystemNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idsystem_furnitureNavigation")]
        public virtual ICollection<pf_glass> pf_glassidsystem_furnitureNavigation { get; set; }
        [InverseProperty("idsystem_profileNavigation")]
        public virtual ICollection<pf_glass> pf_glassidsystem_profileNavigation { get; set; }
        [InverseProperty("idsystem_furnitureNavigation")]
        public virtual ICollection<pf_ms> pf_msidsystem_furnitureNavigation { get; set; }
        [InverseProperty("idsystem_profileNavigation")]
        public virtual ICollection<pf_ms> pf_msidsystem_profileNavigation { get; set; }
        [InverseProperty("idsystemNavigation")]
        public virtual ICollection<productiontypesystems> productiontypesystems { get; set; }
        [InverseProperty("idsystemNavigation")]
        public virtual ICollection<systemdetail> systemdetail { get; set; }
    }
}
