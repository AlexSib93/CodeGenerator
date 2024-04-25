using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_goodbuffer_idgood")]
    [Index("idoptimdocin", Name = "idx_goodbuffer_idoptimdocin")]
    [Index("idoptimdocout", Name = "idx_goodbuffer_idoptimdocout")]
    [Index("idorderitem", Name = "idx_goodbuffer_idorderitem")]
    [Index("idstoredepart", Name = "idx_goodbuffer_idstoredepart")]
    public partial class goodbuffer
    {
        public goodbuffer()
        {
            optimdocgoodin = new HashSet<optimdocgoodin>();
            optimdocgoodout = new HashSet<optimdocgoodout>();
            optimdocpic = new HashSet<optimdocpic>();
        }

        [Key]
        public int idgoodbuffer { get; set; }
        public int? idgood { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? thick { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? marking { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? status { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? profilemarking { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public int? idmanufactdocin { get; set; }
        public int? idmanufactdocout { get; set; }
        public int? idoptimdocin { get; set; }
        public int? idoptimdocout { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? row { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? cell { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idstoredepart { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("goodbuffer")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("goodbuffer")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [ForeignKey("idstoredepart")]
        [InverseProperty("goodbuffer")]
        public virtual storedepart? idstoredepartNavigation { get; set; }
        [InverseProperty("idgoodbufferNavigation")]
        public virtual ICollection<optimdocgoodin> optimdocgoodin { get; set; }
        [InverseProperty("idgoodbufferNavigation")]
        public virtual ICollection<optimdocgoodout> optimdocgoodout { get; set; }
        [InverseProperty("idgoodbufferNavigation")]
        public virtual ICollection<optimdocpic> optimdocpic { get; set; }
    }
}
