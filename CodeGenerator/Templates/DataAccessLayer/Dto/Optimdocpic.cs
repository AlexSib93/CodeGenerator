using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_optimdocpic_idgood")]
    [Index("idgoodbuffer", Name = "idx_optimdocpic_idgoodbuffer")]
    [Index("idoptimdoc", Name = "idx_optimdocpic_idoptimdoc")]
    [Index("idoptimdocgoodin", Name = "idx_optimdocpic_idoptimdocgoodin")]
    [Index("parentid", Name = "idx_optimdocpic_parentid")]
    public partial class optimdocpic
    {
        public optimdocpic()
        {
            Inverseparent = new HashSet<optimdocpic>();
        }

        [Key]
        public int idoptimdocpic { get; set; }
        public int? idoptimdoc { get; set; }
        public int? idgood { get; set; }
        public byte[]? picture { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idgoodbuffer { get; set; }
        public int? idoptimdocgoodin { get; set; }
        public int? whiplen { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        /// <summary>
        /// Сериализованный результат оптимизации
        /// </summary>
        [Column("class")]
        public byte[]? _class { get; set; }
        public int? typ { get; set; }
        public int? thickost { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public short? numpos { get; set; }
        public int? parentid { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("optimdocpic")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idgoodbuffer")]
        [InverseProperty("optimdocpic")]
        public virtual goodbuffer? idgoodbufferNavigation { get; set; }
        [ForeignKey("idoptimdoc")]
        [InverseProperty("optimdocpic")]
        public virtual optimdoc? idoptimdocNavigation { get; set; }
        [ForeignKey("idoptimdocgoodin")]
        [InverseProperty("optimdocpic")]
        public virtual optimdocgoodin? idoptimdocgoodinNavigation { get; set; }
        [ForeignKey("parentid")]
        [InverseProperty("Inverseparent")]
        public virtual optimdocpic? parent { get; set; }
        [InverseProperty("parent")]
        public virtual ICollection<optimdocpic> Inverseparent { get; set; }
    }
}
