using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcar", Name = "idx_manufactdoccar_idcar")]
    [Index("idmanufactdoc", Name = "idx_manufactdoccar_idmanufactdoc")]
    [Index("idpeople", Name = "idx_manufactdoccar_idpeople")]
    public partial class manufactdoccar
    {
        public manufactdoccar()
        {
            delivdoc = new HashSet<delivdoc>();
            manufactdocpyramid = new HashSet<manufactdocpyramid>();
            manufactdocpyramidpos = new HashSet<manufactdocpyramidpos>();
        }

        [Key]
        public int idmanufactdoccar { get; set; }
        public int? idmanufactdoc { get; set; }
        public int? idcar { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short? numpos { get; set; }
        public byte[]? picture { get; set; }
        public int? idroute { get; set; }
        public int? idpeople { get; set; }
        public int run { get; set; }
        [Column(TypeName = "numeric(15, 3)")]
        public decimal? mileage { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? cost { get; set; }

        [ForeignKey("idcar")]
        [InverseProperty("manufactdoccar")]
        public virtual car? idcarNavigation { get; set; }
        [ForeignKey("idmanufactdoc")]
        [InverseProperty("manufactdoccar")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("manufactdoccar")]
        public virtual people? idpeopleNavigation { get; set; }
        [InverseProperty("idmanufactdoccarNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
        [InverseProperty("idmanufactdoccarNavigation")]
        public virtual ICollection<manufactdocpyramid> manufactdocpyramid { get; set; }
        [InverseProperty("idmanufactdoccarNavigation")]
        public virtual ICollection<manufactdocpyramidpos> manufactdocpyramidpos { get; set; }
    }
}
