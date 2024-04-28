using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor", Name = "idx_insertionparamdetail_idcolor")]
    [Index("idcoloraccordance", Name = "idx_insertionparamdetail_idcoloraccordance")]
    [Index("idconstructiontype", Name = "idx_insertionparamdetail_idconstructiontype")]
    [Index("idinsertiondetail", Name = "idx_insertionparamdetail_idinsertiondetail")]
    [Index("idmodelparamvalue", Name = "idx_insertionparamdetail_idmodelparamvalue")]
    [Index("idsystemdetail", Name = "idx_insertionparamdetail_idsystemdetail")]
    [Index("idvariantparamtype", Name = "idx_insertionparamdetail_idvariantparamtype")]
    [Index("idvariantparamtypevalue", Name = "idx_insertionparamdetail_idvariantparamtypevalue")]
    public partial class insertionparamdetail
    {
        [Key]
        public int idinsertionparamdetail { get; set; }
        public int? idvariantparamtype { get; set; }
        public int? idvariantparamtypevalue { get; set; }
        [Column(TypeName = "numeric(18, 9)")]
        public decimal? numvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        public int? idcolor { get; set; }
        public int idinsertiondetail { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idsystemdetail { get; set; }
        public int? idcoloraccordance { get; set; }
        public int? idconstructiontype { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? reverse { get; set; }

        [ForeignKey("idcolor")]
        [InverseProperty("insertionparamdetail")]
        public virtual color? idcolorNavigation { get; set; }
        [ForeignKey("idcoloraccordance")]
        [InverseProperty("insertionparamdetail")]
        public virtual coloraccordance? idcoloraccordanceNavigation { get; set; }
        [ForeignKey("idconstructiontype")]
        [InverseProperty("insertionparamdetail")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idinsertiondetail")]
        [InverseProperty("insertionparamdetail")]
        public virtual insertiondetail idinsertiondetailNavigation { get; set; } = null!;
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("insertionparamdetail")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idsystemdetail")]
        [InverseProperty("insertionparamdetail")]
        public virtual systemdetail? idsystemdetailNavigation { get; set; }
        [ForeignKey("idvariantparamtype")]
        [InverseProperty("insertionparamdetail")]
        public virtual variantparamtype? idvariantparamtypeNavigation { get; set; }
        [ForeignKey("idvariantparamtypevalue")]
        [InverseProperty("insertionparamdetail")]
        public virtual variantparamtypevalue? idvariantparamtypevalueNavigation { get; set; }
    }
}
