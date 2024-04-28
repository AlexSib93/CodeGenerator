using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmanufactdoc", Name = "idx_manufactdocpyramid_idmanufactdoc")]
    [Index("idmanufactdoccar", Name = "idx_manufactdocpyramid_idmanufactdoccar")]
    [Index("idmanufactdocpos", Name = "idx_manufactdocpyramid_idmanufactdocpos")]
    public partial class manufactdocpyramid
    {
        public manufactdocpyramid()
        {
            manufactdocpyramidpos = new HashSet<manufactdocpyramidpos>();
            rotoxhouse = new HashSet<rotoxhouse>();
        }

        [Key]
        public int idmanufactdocpyramid { get; set; }
        public int? idpyramid { get; set; }
        public int? idmanufactdocpos { get; set; }
        public int? idmanufactdoc { get; set; }
        public int? numpyramid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idmanufactdoccar { get; set; }
        public byte[]? picture { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public short side { get; set; }

        [ForeignKey("idmanufactdoc")]
        [InverseProperty("manufactdocpyramid")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
        [ForeignKey("idmanufactdoccar")]
        [InverseProperty("manufactdocpyramid")]
        public virtual manufactdoccar? idmanufactdoccarNavigation { get; set; }
        [ForeignKey("idmanufactdocpos")]
        [InverseProperty("manufactdocpyramid")]
        public virtual manufactdocpos? idmanufactdocposNavigation { get; set; }
        [InverseProperty("idmanufactdocpyram")]
        public virtual ICollection<manufactdocpyramidpos> manufactdocpyramidpos { get; set; }
        [InverseProperty("idmanufactdocpyram")]
        public virtual ICollection<rotoxhouse> rotoxhouse { get; set; }
    }
}
