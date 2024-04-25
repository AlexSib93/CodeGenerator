using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocoper", Name = "idx_signgrant_iddocoper")]
    [Index("idpeoplegroup", Name = "idx_signgrant_idpeoplegroup")]
    [Index("idsign", Name = "idx_signgrant_idsign")]
    [Index("idsignvalue", Name = "idx_signgrant_idsignvalue")]
    public partial class signgrant
    {
        [Key]
        public int idsigngrant { get; set; }
        public int? idsign { get; set; }
        public int? idpeoplegroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idsignvalue { get; set; }
        public int? iddocoper { get; set; }
        public bool? isadd { get; set; }
        public bool? isremove { get; set; }
        public bool? iseditcomment { get; set; }
        public bool? iseditstr { get; set; }
        public bool? iseditint { get; set; }
        public bool? isedit { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("iddocoper")]
        [InverseProperty("signgrant")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("idpeoplegroup")]
        [InverseProperty("signgrant")]
        public virtual peoplegroup? idpeoplegroupNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("signgrant")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idsignvalue")]
        [InverseProperty("signgrant")]
        public virtual signvalue? idsignvalueNavigation { get; set; }
    }
}
