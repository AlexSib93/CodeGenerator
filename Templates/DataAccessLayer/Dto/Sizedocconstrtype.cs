using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idconstructiontype", Name = "idx_sizedocconstrtype_idconstructiontype")]
    [Index("idembrasuretype", Name = "idx_sizedocconstrtype_idembrasuretype")]
    [Index("idproductiontype", Name = "idx_sizedocconstrtype_idproductiontype")]
    [Index("idsizedoc", Name = "idx_sizedocconstrtype_idsizedoc")]
    public partial class sizedocconstrtype
    {
        [Key]
        public int idsizedocconstrtype { get; set; }
        public int? idsizedoc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idconstructiontype { get; set; }
        public int? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue { get; set; }
        public int? idembrasuretype { get; set; }
        public bool? numpos { get; set; }
        public int? thick { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? idproductiontype { get; set; }

        [ForeignKey("idconstructiontype")]
        [InverseProperty("sizedocconstrtype")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idembrasuretype")]
        [InverseProperty("sizedocconstrtype")]
        public virtual embrasuretype? idembrasuretypeNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("sizedocconstrtype")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
        [ForeignKey("idsizedoc")]
        [InverseProperty("sizedocconstrtype")]
        public virtual sizedoc? idsizedocNavigation { get; set; }
    }
}
