using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idproductiontype", Name = "idx_productiontypetemplate_idproductiontype")]
    public partial class productiontypetemplate
    {
        [Key]
        public int idproductiontypetemplate { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idproductiontype { get; set; }
        public byte[]? model { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public byte[]? picture { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? thick { get; set; }
        [Unicode(false)]
        public string? comment2 { get; set; }
        [Unicode(false)]
        public string? comment3 { get; set; }

        [ForeignKey("idproductiontype")]
        [InverseProperty("productiontypetemplate")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
    }
}
