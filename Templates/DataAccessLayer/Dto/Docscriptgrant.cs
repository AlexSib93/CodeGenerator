using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocappearance", Name = "idx_docscriptgrant_iddocappearance")]
    [Index("idpeoplegroup", Name = "idx_docscriptgrant_idpeoplegroup")]
    public partial class docscriptgrant
    {
        [Key]
        public int iddocscriptgrant { get; set; }
        public int? iddocscript { get; set; }
        public int? idpeoplegroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? iddocappearance { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("iddocappearance")]
        [InverseProperty("docscriptgrant")]
        public virtual docappearance? iddocappearanceNavigation { get; set; }
        [ForeignKey("idpeoplegroup")]
        [InverseProperty("docscriptgrant")]
        public virtual peoplegroup? idpeoplegroupNavigation { get; set; }
    }
}
