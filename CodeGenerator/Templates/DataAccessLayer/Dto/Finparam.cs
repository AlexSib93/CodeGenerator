using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__finparam__46FE2F53", IsUnique = true)]
    [Index("idfinparamgroup", Name = "idx_finparam_idfinparamgroup")]
    [Index("idversion", Name = "idx_finparam_idversion")]
    public partial class finparam
    {
        public finparam()
        {
            finparamcalc = new HashSet<finparamcalc>();
            power = new HashSet<power>();
        }

        [Key]
        public int idfinparam { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "text")]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? typ { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? paramgroup { get; set; }
        public int? numpos { get; set; }
        public short? activeparam { get; set; }
        public int? idversion { get; set; }
        public int? idfinparamgroup { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idfinparamgroup")]
        [InverseProperty("finparam")]
        public virtual finparamgroup? idfinparamgroupNavigation { get; set; }
        [InverseProperty("idfinparamNavigation")]
        public virtual ICollection<finparamcalc> finparamcalc { get; set; }
        [InverseProperty("idfinparamNavigation")]
        public virtual ICollection<power> power { get; set; }
    }
}
