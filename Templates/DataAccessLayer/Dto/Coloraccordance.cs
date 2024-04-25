using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor", Name = "idx_coloraccordance_idcolor")]
    public partial class coloraccordance
    {
        public coloraccordance()
        {
            coloraccordancedetail = new HashSet<coloraccordancedetail>();
            insertionparamdetail = new HashSet<insertionparamdetail>();
            modelparamcondition = new HashSet<modelparamcondition>();
            pf_ptidcoloraccordance1Navigation = new HashSet<pf_pt>();
            pf_ptidcoloraccordance2Navigation = new HashSet<pf_pt>();
            shtapikgroupparamdetail = new HashSet<shtapikgroupparamdetail>();
            variantparamdetail = new HashSet<variantparamdetail>();
        }

        [Key]
        public int idcoloraccordance { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        public int? idcolor { get; set; }
        public bool fromsource { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idcolor")]
        [InverseProperty("coloraccordance")]
        public virtual color? idcolorNavigation { get; set; }
        [InverseProperty("idcoloraccordanceNavigation")]
        public virtual ICollection<coloraccordancedetail> coloraccordancedetail { get; set; }
        [InverseProperty("idcoloraccordanceNavigation")]
        public virtual ICollection<insertionparamdetail> insertionparamdetail { get; set; }
        [InverseProperty("idcoloraccordanceNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idcoloraccordance1Navigation")]
        public virtual ICollection<pf_pt> pf_ptidcoloraccordance1Navigation { get; set; }
        [InverseProperty("idcoloraccordance2Navigation")]
        public virtual ICollection<pf_pt> pf_ptidcoloraccordance2Navigation { get; set; }
        [InverseProperty("idcoloraccordanceNavigation")]
        public virtual ICollection<shtapikgroupparamdetail> shtapikgroupparamdetail { get; set; }
        [InverseProperty("idcoloraccordanceNavigation")]
        public virtual ICollection<variantparamdetail> variantparamdetail { get; set; }
    }
}
