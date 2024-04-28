using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__modelparam__2C4A3917", IsUnique = true)]
    [Index("idcolor", Name = "idx_modelparam_idcolor")]
    [Index("idmodelparamgroup", Name = "idx_modelparam_idmodelparamgroup")]
    [Index("idmodelpart", Name = "idx_modelparam_idmodelpart")]
    [Index("idmodelpartroot", Name = "idx_modelparam_idmodelpartroot")]
    [Index("idversion", Name = "idx_modelparam_idversion")]
    public partial class modelparam
    {
        public modelparam()
        {
            modelparamcalc = new HashSet<modelparamcalc>();
            modelparamcondition = new HashSet<modelparamcondition>();
            modelparamvalue = new HashSet<modelparamvalue>();
            pf_glassidmodelparam1Navigation = new HashSet<pf_glass>();
            pf_glassidmodelparam2Navigation = new HashSet<pf_glass>();
            pf_msidmodelparam1Navigation = new HashSet<pf_ms>();
            pf_msidmodelparam2Navigation = new HashSet<pf_ms>();
            pf_ptidmodelparam1Navigation = new HashSet<pf_pt>();
            pf_ptidmodelparam2Navigation = new HashSet<pf_pt>();
            productiontypeparam = new HashSet<productiontypeparam>();
            templateparam = new HashSet<templateparam>();
        }

        [Key]
        public int idmodelparam { get; set; }
        public int? idmodelpart { get; set; }
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
        public short? saved { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idversion { get; set; }
        public int? numpos { get; set; }
        public int? idmodelpartroot { get; set; }
        public short? onlyfromlist { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? constrtypelist { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? systemlist { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? opentypelist { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? unvisiblestrvalue { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? unvisiblestrvalue2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? unvisibleintvalue { get; set; }
        public bool? isdesignerprocess { get; set; }
        /// <summary>
        /// Группа параметров
        /// </summary>
        public int? idmodelparamgroup { get; set; }
        /// <summary>
        /// Для построителя
        /// </summary>
        [Required]
        public bool? tomodel { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? furnsystemlist { get; set; }
        public bool? isstr1 { get; set; }
        public bool? isstr2 { get; set; }
        public bool? isint1 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? namestr1 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? namestr2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? nameint1 { get; set; }
        public bool? iscolor { get; set; }
        public int? idcolor { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? namecolor { get; set; }
        [Unicode(false)]
        public string? colorfilter { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? nameint2 { get; set; }
        public bool? isint2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? groupname { get; set; }
        public bool? useunvisible { get; set; }
        [StringLength(128)]
        public string? name_strkey { get; set; }
        [StringLength(128)]
        public string? strvalue_strkey { get; set; }
        [StringLength(128)]
        public string? strvalue2_strkey { get; set; }
        [StringLength(512)]
        public string? unvisiblestrvalue_strkey { get; set; }
        [StringLength(512)]
        public string? unvisiblestrvalue2_strkey { get; set; }
        public bool? ui_visible { get; set; }
        public int? sortorder { get; set; }

        [ForeignKey("idcolor")]
        [InverseProperty("modelparam")]
        public virtual color? idcolorNavigation { get; set; }
        [ForeignKey("idmodelparamgroup")]
        [InverseProperty("modelparam")]
        public virtual modelparamgroup? idmodelparamgroupNavigation { get; set; }
        [ForeignKey("idmodelpart")]
        [InverseProperty("modelparam")]
        public virtual modelpart? idmodelpartNavigation { get; set; }
        [ForeignKey("idversion")]
        [InverseProperty("modelparam")]
        public virtual versions? idversionNavigation { get; set; }
        [InverseProperty("idmodelparamNavigation")]
        public virtual ICollection<modelparamcalc> modelparamcalc { get; set; }
        [InverseProperty("idmodelparamNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idmodelparamNavigation")]
        public virtual ICollection<modelparamvalue> modelparamvalue { get; set; }
        [InverseProperty("idmodelparam1Navigation")]
        public virtual ICollection<pf_glass> pf_glassidmodelparam1Navigation { get; set; }
        [InverseProperty("idmodelparam2Navigation")]
        public virtual ICollection<pf_glass> pf_glassidmodelparam2Navigation { get; set; }
        [InverseProperty("idmodelparam1Navigation")]
        public virtual ICollection<pf_ms> pf_msidmodelparam1Navigation { get; set; }
        [InverseProperty("idmodelparam2Navigation")]
        public virtual ICollection<pf_ms> pf_msidmodelparam2Navigation { get; set; }
        [InverseProperty("idmodelparam1Navigation")]
        public virtual ICollection<pf_pt> pf_ptidmodelparam1Navigation { get; set; }
        [InverseProperty("idmodelparam2Navigation")]
        public virtual ICollection<pf_pt> pf_ptidmodelparam2Navigation { get; set; }
        [InverseProperty("idmodelparamNavigation")]
        public virtual ICollection<productiontypeparam> productiontypeparam { get; set; }
        [InverseProperty("idmodelparamNavigation")]
        public virtual ICollection<templateparam> templateparam { get; set; }
    }
}
