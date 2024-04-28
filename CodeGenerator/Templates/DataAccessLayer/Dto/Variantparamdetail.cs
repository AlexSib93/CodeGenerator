using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor", Name = "idx_variantparamdetail_idcolor")]
    [Index("idcoloraccordance", Name = "idx_variantparamdetail_idcoloraccordance")]
    [Index("idconstructiontype", Name = "idx_variantparamdetail_idconstructiontype")]
    [Index("idmodelparamvalue", Name = "idx_variantparamdetail_idmodelparamvalue")]
    [Index("idvariantdetail", Name = "idx_variantparamdetail_idvariantdetail")]
    [Index("idvariantparamtype", Name = "idx_variantparamdetail_idvariantparamtype")]
    [Index("idvariantparamtypevalue", Name = "idx_variantparamdetail_idvariantparamtypevalue")]
    public partial class variantparamdetail
    {
        [Key]
        public int idvariantparamdetail { get; set; }
        public int? idvariantparamtype { get; set; }
        public int? idvariantparamtypevalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? numvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        public int? idcolor { get; set; }
        public int idvariantdetail { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idcoloraccordance { get; set; }
        public int? idconstructiontype { get; set; }

        [ForeignKey("idcolor")]
        [InverseProperty("variantparamdetail")]
        public virtual color? idcolorNavigation { get; set; }
        [ForeignKey("idcoloraccordance")]
        [InverseProperty("variantparamdetail")]
        public virtual coloraccordance? idcoloraccordanceNavigation { get; set; }
        [ForeignKey("idconstructiontype")]
        [InverseProperty("variantparamdetail")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("variantparamdetail")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idvariantdetail")]
        [InverseProperty("variantparamdetail")]
        public virtual variantdetail idvariantdetailNavigation { get; set; } = null!;
        [ForeignKey("idvariantparamtype")]
        [InverseProperty("variantparamdetail")]
        public virtual variantparamtype? idvariantparamtypeNavigation { get; set; }
        [ForeignKey("idvariantparamtypevalue")]
        [InverseProperty("variantparamdetail")]
        public virtual variantparamtypevalue? idvariantparamtypevalueNavigation { get; set; }
    }
}
