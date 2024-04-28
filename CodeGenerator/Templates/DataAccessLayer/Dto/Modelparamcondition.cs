using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor", Name = "idx_modelparamcondition_idcolor")]
    [Index("idcoloraccordance", Name = "idx_modelparamcondition_idcoloraccordance")]
    [Index("idconstructiontype", Name = "idx_modelparamcondition_idconstructiontype")]
    [Index("idmodelparam", Name = "idx_modelparamcondition_idmodelparam")]
    [Index("idmodelparamvalue", Name = "idx_modelparamcondition_idmodelparamvalue")]
    [Index("idproductiontype", Name = "idx_modelparamcondition_idproductiontype")]
    [Index("idsystem", Name = "idx_modelparamcondition_idsystem")]
    [Index("idsystemdetail", Name = "idx_modelparamcondition_idsystemdetail")]
    [Index("idvariantparamtype", Name = "idx_modelparamcondition_idvariantparamtype")]
    [Index("idvariantparamtypevalue", Name = "idx_modelparamcondition_idvariantparamtypevalue")]
    [Index("parentid", Name = "idx_modelparamcondition_parentid")]
    public partial class modelparamcondition
    {
        public modelparamcondition()
        {
            modelparamconditiondetail = new HashSet<modelparamconditiondetail>();
        }

        [Key]
        public int idmodelparamcondition { get; set; }
        public int? parentid { get; set; }
        public int? idmodelparam { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idsystemdetail { get; set; }
        public int? idvariantparamtype { get; set; }
        public int? idvariantparamtypevalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? numvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        public int? idcolor { get; set; }
        public int? idcoloraccordance { get; set; }
        public int? idsystem { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idproductiontype { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? invert { get; set; }
        public int? numpos { get; set; }

        [ForeignKey("idcolor")]
        [InverseProperty("modelparamcondition")]
        public virtual color? idcolorNavigation { get; set; }
        [ForeignKey("idcoloraccordance")]
        [InverseProperty("modelparamcondition")]
        public virtual coloraccordance? idcoloraccordanceNavigation { get; set; }
        [ForeignKey("idconstructiontype")]
        [InverseProperty("modelparamcondition")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idmodelparam")]
        [InverseProperty("modelparamcondition")]
        public virtual modelparam? idmodelparamNavigation { get; set; }
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("modelparamcondition")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("modelparamcondition")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
        [ForeignKey("idsystem")]
        [InverseProperty("modelparamcondition")]
        public virtual system? idsystemNavigation { get; set; }
        [ForeignKey("idsystemdetail")]
        [InverseProperty("modelparamcondition")]
        public virtual systemdetail? idsystemdetailNavigation { get; set; }
        [ForeignKey("idvariantparamtype")]
        [InverseProperty("modelparamcondition")]
        public virtual variantparamtype? idvariantparamtypeNavigation { get; set; }
        [ForeignKey("idvariantparamtypevalue")]
        [InverseProperty("modelparamcondition")]
        public virtual variantparamtypevalue? idvariantparamtypevalueNavigation { get; set; }
        [InverseProperty("idmodelparamconditionNavigation")]
        public virtual ICollection<modelparamconditiondetail> modelparamconditiondetail { get; set; }
    }
}
