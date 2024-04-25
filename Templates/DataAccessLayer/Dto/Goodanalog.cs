using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodanalog__61B2258F", IsUnique = true)]
    [Index("idcolor1", Name = "idx_goodanalog_idcolor1")]
    [Index("idcolor2", Name = "idx_goodanalog_idcolor2")]
    [Index("idgood", Name = "idx_goodanalog_idgood")]
    [Index("idgoodanaloggroup", Name = "idx_goodanalog_idgoodanaloggroup")]
    public partial class goodanalog
    {
        public goodanalog()
        {
            goodanalogdetail = new HashSet<goodanalogdetail>();
        }

        [Key]
        public int idgoodanalog { get; set; }
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
        public string? analoggroup { get; set; }
        public int? idgoodanaloggroup { get; set; }
        public Guid guid { get; set; }
        public int? idgood { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }

        [ForeignKey("idcolor1")]
        [InverseProperty("goodanalogidcolor1Navigation")]
        public virtual color? idcolor1Navigation { get; set; }
        [ForeignKey("idcolor2")]
        [InverseProperty("goodanalogidcolor2Navigation")]
        public virtual color? idcolor2Navigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("goodanalog")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idgoodanaloggroup")]
        [InverseProperty("goodanalog")]
        public virtual goodanaloggroup? idgoodanaloggroupNavigation { get; set; }
        [InverseProperty("idgoodanalogNavigation")]
        public virtual ICollection<goodanalogdetail> goodanalogdetail { get; set; }
    }
}
