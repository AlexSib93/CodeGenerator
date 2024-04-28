using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddoc", Name = "idx_doclock_iddoc")]
    [Index("iddocoper", Name = "idx_doclock_iddocoper")]
    [Index("idpeople", Name = "idx_doclock_idpeople")]
    public partial class doclock
    {
        [Key]
        public int iddoclock { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtlock { get; set; }
        public int? idpeople { get; set; }
        public int? iddoc { get; set; }
        public int? typ { get; set; }
        public int? iddocoper { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? iddocappearance { get; set; }

        [ForeignKey("iddocoper")]
        [InverseProperty("doclock")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("doclock")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
