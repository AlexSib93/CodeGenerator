using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_optimdocgoodout_idgood")]
    [Index("idgoodbuffer", Name = "idx_optimdocgoodout_idgoodbuffer")]
    [Index("idoptimdoc", Name = "idx_optimdocgoodout_idoptimdoc")]
    [Index("idoptimdocpic", Name = "idx_optimdocgoodout_idoptimdocpic")]
    public partial class optimdocgoodout
    {
        public optimdocgoodout()
        {
            optimdocgoodin = new HashSet<optimdocgoodin>();
        }

        [Key]
        public int idoptimdocgoodout { get; set; }
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

        [ForeignKey("idgood")]
        [InverseProperty("optimdocgoodout")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idgoodbuffer")]
        [InverseProperty("optimdocgoodout")]
        public virtual goodbuffer? idgoodbufferNavigation { get; set; }
        [ForeignKey("idoptimdoc")]
        [InverseProperty("optimdocgoodout")]
        public virtual optimdoc? idoptimdocNavigation { get; set; }
        [InverseProperty("idoptimdocgoodoutNavigation")]
        public virtual ICollection<optimdocgoodin> optimdocgoodin { get; set; }
    }
}
