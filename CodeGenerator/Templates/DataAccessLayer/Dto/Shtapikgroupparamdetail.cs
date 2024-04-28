using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor", Name = "idx_shtapikgroupparamdetail_idcolor")]
    [Index("idcoloraccordance", Name = "idx_shtapikgroupparamdetail_idcoloraccordance")]
    [Index("idconstructiontype", Name = "idx_shtapikgroupparamdetail_idconstructiontype")]
    [Index("idmodelparamvalue", Name = "idx_shtapikgroupparamdetail_idmodelparamvalue")]
    [Index("idshtapikgroupdetail", Name = "idx_shtapikgroupparamdetail_idshtapikgroupdetail")]
    [Index("idvariantparamtype", Name = "idx_shtapikgroupparamdetail_idvariantparamtype")]
    [Index("idvariantparamtypevalue", Name = "idx_shtapikgroupparamdetail_idvariantparamtypevalue")]
    public partial class shtapikgroupparamdetail
    {
        [Key]
        public int idshtapikgroupparamdetail { get; set; }
        public int? idvariantparamtype { get; set; }
        public int? idvariantparamtypevalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? numvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        public int? idcolor { get; set; }
        public int idshtapikgroupdetail { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idcoloraccordance { get; set; }
        public int? idconstructiontype { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idcolor")]
        [InverseProperty("shtapikgroupparamdetail")]
        public virtual color? idcolorNavigation { get; set; }
        [ForeignKey("idcoloraccordance")]
        [InverseProperty("shtapikgroupparamdetail")]
        public virtual coloraccordance? idcoloraccordanceNavigation { get; set; }
        [ForeignKey("idconstructiontype")]
        [InverseProperty("shtapikgroupparamdetail")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("shtapikgroupparamdetail")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idshtapikgroupdetail")]
        [InverseProperty("shtapikgroupparamdetail")]
        public virtual shtapikgroupdetail idshtapikgroupdetailNavigation { get; set; } = null!;
        [ForeignKey("idvariantparamtype")]
        [InverseProperty("shtapikgroupparamdetail")]
        public virtual variantparamtype? idvariantparamtypeNavigation { get; set; }
        [ForeignKey("idvariantparamtypevalue")]
        [InverseProperty("shtapikgroupparamdetail")]
        public virtual variantparamtypevalue? idvariantparamtypevalueNavigation { get; set; }
    }
}
