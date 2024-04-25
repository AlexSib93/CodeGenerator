using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodtype__021EF521", IsUnique = true)]
    public partial class goodtype
    {
        public goodtype()
        {
            good = new HashSet<good>();
        }

        [Key]
        public int idgoodtype { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? numpos2 { get; set; }
        public int? numpos3 { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idgoodtypeNavigation")]
        public virtual ICollection<good> good { get; set; }
    }
}
