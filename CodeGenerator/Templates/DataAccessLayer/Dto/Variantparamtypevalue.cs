using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idvariantparamtype", Name = "idx_variantparamtypevalue_idvariantparamtype")]
    public partial class variantparamtypevalue
    {
        public variantparamtypevalue()
        {
            insertionparam = new HashSet<insertionparam>();
            insertionparamdetail = new HashSet<insertionparamdetail>();
            modelparamcondition = new HashSet<modelparamcondition>();
            shtapikgroupparamdetail = new HashSet<shtapikgroupparamdetail>();
            variantparam = new HashSet<variantparam>();
            variantparamdetail = new HashSet<variantparamdetail>();
        }

        [Key]
        public int idvariantparamtypevalue { get; set; }
        public int idvariantparamtype { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;

        [ForeignKey("idvariantparamtype")]
        [InverseProperty("variantparamtypevalue")]
        public virtual variantparamtype idvariantparamtypeNavigation { get; set; } = null!;
        [InverseProperty("idvariantparamtypevalueNavigation")]
        public virtual ICollection<insertionparam> insertionparam { get; set; }
        [InverseProperty("idvariantparamtypevalueNavigation")]
        public virtual ICollection<insertionparamdetail> insertionparamdetail { get; set; }
        [InverseProperty("idvariantparamtypevalueNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idvariantparamtypevalueNavigation")]
        public virtual ICollection<shtapikgroupparamdetail> shtapikgroupparamdetail { get; set; }
        [InverseProperty("idvariantparamtypevalueNavigation")]
        public virtual ICollection<variantparam> variantparam { get; set; }
        [InverseProperty("idvariantparamtypevalueNavigation")]
        public virtual ICollection<variantparamdetail> variantparamdetail { get; set; }
    }
}
