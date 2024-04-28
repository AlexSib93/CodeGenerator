using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcoatdoc", Name = "idx_coatdocpos_idcoatdoc")]
    [Index("idgood", Name = "idx_coatdocpos_idgood")]
    public partial class coatdocpos
    {
        [Key]
        public int idcoatdocpos { get; set; }
        public int? idcoatdoc { get; set; }
        public int? idgood { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        public int? numpos { get; set; }

        [ForeignKey("idcoatdoc")]
        [InverseProperty("coatdocpos")]
        public virtual coatdoc? idcoatdocNavigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("coatdocpos")]
        public virtual good? idgoodNavigation { get; set; }
    }
}
