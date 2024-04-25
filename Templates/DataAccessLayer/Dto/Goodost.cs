using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_goodost_idgood")]
    [Index("idmanufactdoc", Name = "idx_goodost_idmanufactdoc")]
    [Index("idorder", Name = "idx_goodost_idorder")]
    [Index("idstoredepart", Name = "idx_goodost_idstoredepart")]
    public partial class goodost
    {
        [Key]
        public int idgoodost { get; set; }
        public int? idgood { get; set; }
        public int? idorder { get; set; }
        public int? idmanufactdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtreg { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? val { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valnew { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valold { get; set; }
        public int? idstoredepart { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("goodost")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idmanufactdoc")]
        [InverseProperty("goodost")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("goodost")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idstoredepart")]
        [InverseProperty("goodost")]
        public virtual storedepart? idstoredepartNavigation { get; set; }
    }
}
