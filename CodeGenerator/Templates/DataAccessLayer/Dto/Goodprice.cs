using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_goodprice_idgood")]
    public partial class goodprice
    {
        [Key]
        public int idgoodprice { get; set; }
        public int? idgood { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price5 { get; set; }
        public int? idvalut { get; set; }
        public int? idvalut2 { get; set; }
        public int? idvalut3 { get; set; }
        public int? idvalut4 { get; set; }
        public int? idvalut5 { get; set; }
        public int? idpeopleedit { get; set; }
        public Guid? guid { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("goodprice")]
        public virtual good? idgoodNavigation { get; set; }
    }
}
