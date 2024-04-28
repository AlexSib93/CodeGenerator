using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__pyramid__5A1103C7", IsUnique = true)]
    [Index("idcar", Name = "idx_pyramid_idcar")]
    [Index("idproductionsite", Name = "idx_pyramid_idproductionsite")]
    public partial class pyramid
    {
        public pyramid()
        {
            destanation = new HashSet<destanation>();
        }

        [Key]
        public int idpyramid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? numpos { get; set; }
        public int? qurow { get; set; }
        public int? rowlen { get; set; }
        public Guid guid { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? depth { get; set; }
        public int? maxwiwidth { get; set; }
        public int? weight { get; set; }
        public int? selfdepth { get; set; }
        public int? maxrowwidth { get; set; }
        public int? idcar { get; set; }
        public bool doublesided { get; set; }
        public int? qufirstrow { get; set; }
        public int? maxheightfirstrow { get; set; }
        public byte state { get; set; }
        public int? idproductionsite { get; set; }
        public int? priority { get; set; }

        [ForeignKey("idcar")]
        [InverseProperty("pyramid")]
        public virtual car? idcarNavigation { get; set; }
        [ForeignKey("idproductionsite")]
        [InverseProperty("pyramid")]
        public virtual productionsite? idproductionsiteNavigation { get; set; }
        [InverseProperty("idpyram")]
        public virtual ICollection<destanation> destanation { get; set; }
    }
}
