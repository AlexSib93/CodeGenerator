using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor", Name = "idx_insertionparam_idcolor")]
    [Index("idconstructiontype", Name = "idx_insertionparam_idconstructiontype")]
    [Index("iderror", Name = "idx_insertionparam_iderror")]
    [Index("idinsertion", Name = "idx_insertionparam_idinsertion")]
    [Index("idmodelparamvalue", Name = "idx_insertionparam_idmodelparamvalue")]
    [Index("idsystemdetail", Name = "idx_insertionparam_idsystemdetail")]
    [Index("idvariantparamtype", Name = "idx_insertionparam_idvariantparamtype")]
    [Index("idvariantparamtypevalue", Name = "idx_insertionparam_idvariantparamtypevalue")]
    public partial class insertionparam
    {
        [Key]
        public int idinsertionparam { get; set; }
        public int? idvariantparamtype { get; set; }
        public int? idvariantparamtypevalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? numvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        public int? idcolor { get; set; }
        public int? idinsertion { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idsystemdetail { get; set; }
        public int? iderror { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? reverse { get; set; }
        public int? idconstructiontype { get; set; }

        [ForeignKey("idcolor")]
        [InverseProperty("insertionparam")]
        public virtual color? idcolorNavigation { get; set; }
        [ForeignKey("idconstructiontype")]
        [InverseProperty("insertionparam")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("iderror")]
        [InverseProperty("insertionparam")]
        public virtual error? iderrorNavigation { get; set; }
        [ForeignKey("idinsertion")]
        [InverseProperty("insertionparam")]
        public virtual insertion? idinsertionNavigation { get; set; }
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("insertionparam")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idsystemdetail")]
        [InverseProperty("insertionparam")]
        public virtual systemdetail? idsystemdetailNavigation { get; set; }
        [ForeignKey("idvariantparamtype")]
        [InverseProperty("insertionparam")]
        public virtual variantparamtype? idvariantparamtypeNavigation { get; set; }
        [ForeignKey("idvariantparamtypevalue")]
        [InverseProperty("insertionparam")]
        public virtual variantparamtypevalue? idvariantparamtypevalueNavigation { get; set; }
    }
}
