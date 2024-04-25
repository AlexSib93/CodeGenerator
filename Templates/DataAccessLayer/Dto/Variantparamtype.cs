using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class variantparamtype
    {
        public variantparamtype()
        {
            insertionparam = new HashSet<insertionparam>();
            insertionparamdetail = new HashSet<insertionparamdetail>();
            modelparamcondition = new HashSet<modelparamcondition>();
            shtapikgroupparamdetail = new HashSet<shtapikgroupparamdetail>();
            variantparam = new HashSet<variantparam>();
            variantparamdetail = new HashSet<variantparamdetail>();
            variantparamtypevalue = new HashSet<variantparamtypevalue>();
        }

        [Key]
        public int idvariantparamtype { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        public int numpos { get; set; }
        public bool allow_1 { get; set; }
        public bool allow_2 { get; set; }
        public bool allow_3 { get; set; }
        public bool allow_4 { get; set; }
        public bool allow_gp { get; set; }
        public bool allow_st { get; set; }
        public byte type { get; set; }
        [StringLength(1024)]
        [Unicode(false)]
        public string? comment { get; set; }
        public bool allow_ins { get; set; }
        public bool allow_insd { get; set; }
        public bool allow_shtg { get; set; }
        public bool allow_m2 { get; set; }
        public bool allow_mp { get; set; }

        [InverseProperty("idvariantparamtypeNavigation")]
        public virtual ICollection<insertionparam> insertionparam { get; set; }
        [InverseProperty("idvariantparamtypeNavigation")]
        public virtual ICollection<insertionparamdetail> insertionparamdetail { get; set; }
        [InverseProperty("idvariantparamtypeNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idvariantparamtypeNavigation")]
        public virtual ICollection<shtapikgroupparamdetail> shtapikgroupparamdetail { get; set; }
        [InverseProperty("idvariantparamtypeNavigation")]
        public virtual ICollection<variantparam> variantparam { get; set; }
        [InverseProperty("idvariantparamtypeNavigation")]
        public virtual ICollection<variantparamdetail> variantparamdetail { get; set; }
        [InverseProperty("idvariantparamtypeNavigation")]
        public virtual ICollection<variantparamtypevalue> variantparamtypevalue { get; set; }
    }
}
