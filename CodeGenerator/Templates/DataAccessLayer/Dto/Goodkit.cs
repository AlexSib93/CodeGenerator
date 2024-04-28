using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodkit__676AFEE5", IsUnique = true)]
    [Index("idgoodkitgroup", Name = "idx_goodkit_idgoodkitgroup")]
    public partial class goodkit
    {
        public goodkit()
        {
            goodkitdetail = new HashSet<goodkitdetail>();
        }

        [Key]
        public int idgoodkit { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? kitgroup { get; set; }
        public int? idgoodkitgroup { get; set; }
        public short? ismy { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idgoodkitgroup")]
        [InverseProperty("goodkit")]
        public virtual goodkitgroup? idgoodkitgroupNavigation { get; set; }
        [InverseProperty("idgoodkitNavigation")]
        public virtual ICollection<goodkitdetail> goodkitdetail { get; set; }
    }
}
