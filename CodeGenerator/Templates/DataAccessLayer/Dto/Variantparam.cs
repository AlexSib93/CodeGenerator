using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor", Name = "idx_variantparam_idcolor")]
    [Index("idconstructiontype", Name = "idx_variantparam_idconstructiontype")]
    [Index("idmodelparamvalue", Name = "idx_variantparam_idmodelparamvalue")]
    [Index("idvariant", Name = "idx_variantparam_idvariant")]
    [Index("idvariantparamtype", Name = "idx_variantparam_idvariantparamtype")]
    [Index("idvariantparamtypevalue", Name = "idx_variantparam_idvariantparamtypevalue")]
    public partial class variantparam
    {
        [Key]
        public int idvariantparam { get; set; }
        public int? idvariantparamtype { get; set; }
        public int? idvariantparamtypevalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? numvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        public int? idcolor { get; set; }
        public int? idvariant { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idconstructiontype { get; set; }

        [ForeignKey("idcolor")]
        [InverseProperty("variantparam")]
        public virtual color? idcolorNavigation { get; set; }
        [ForeignKey("idconstructiontype")]
        [InverseProperty("variantparam")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("variantparam")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idvariant")]
        [InverseProperty("variantparam")]
        public virtual variant? idvariantNavigation { get; set; }
        [ForeignKey("idvariantparamtype")]
        [InverseProperty("variantparam")]
        public virtual variantparamtype? idvariantparamtypeNavigation { get; set; }
        [ForeignKey("idvariantparamtypevalue")]
        [InverseProperty("variantparam")]
        public virtual variantparamtypevalue? idvariantparamtypevalueNavigation { get; set; }
    }
}
