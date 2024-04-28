using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_optimdocgoodin_idgood")]
    [Index("idgoodbuffer", Name = "idx_optimdocgoodin_idgoodbuffer")]
    [Index("idoptimdoc", Name = "idx_optimdocgoodin_idoptimdoc")]
    [Index("idoptimdocgoodout", Name = "idx_optimdocgoodin_idoptimdocgoodout")]
    [Index("parentid", Name = "idx_optimdocgoodin_parentid")]
    public partial class optimdocgoodin
    {
        public optimdocgoodin()
        {
            Inverseparent = new HashSet<optimdocgoodin>();
            optimdocpic = new HashSet<optimdocpic>();
        }

        [Key]
        public int idoptimdocgoodin { get; set; }
        public int? idgood { get; set; }
        public int? idgoodbuffer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idoptimdoc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? idcolorin { get; set; }
        public int? idcolorout { get; set; }
        public int? idcolorbase { get; set; }
        public int? idoptimdocpic { get; set; }
        public int? idoptimdocgoodout { get; set; }
        public int? parentid { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("optimdocgoodin")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idgoodbuffer")]
        [InverseProperty("optimdocgoodin")]
        public virtual goodbuffer? idgoodbufferNavigation { get; set; }
        [ForeignKey("idoptimdoc")]
        [InverseProperty("optimdocgoodin")]
        public virtual optimdoc? idoptimdocNavigation { get; set; }
        [ForeignKey("idoptimdocgoodout")]
        [InverseProperty("optimdocgoodin")]
        public virtual optimdocgoodout? idoptimdocgoodoutNavigation { get; set; }
        [ForeignKey("parentid")]
        [InverseProperty("Inverseparent")]
        public virtual optimdocgoodin? parent { get; set; }
        [InverseProperty("parent")]
        public virtual ICollection<optimdocgoodin> Inverseparent { get; set; }
        [InverseProperty("idoptimdocgoodinNavigation")]
        public virtual ICollection<optimdocpic> optimdocpic { get; set; }
    }
}
