using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idstoredepartchild", Name = "idx_storedepartrel_idstoredepartchild")]
    [Index("idstoredepartparent", Name = "idx_storedepartrel_idstoredepartparent")]
    public partial class storedepartrel
    {
        [Key]
        public int idstoredepartrel { get; set; }
        public int? idstoredepartparent { get; set; }
        public int? idstoredepartchild { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idstoredepartchild")]
        [InverseProperty("storedepartrelidstoredepartchildNavigation")]
        public virtual storedepart? idstoredepartchildNavigation { get; set; }
        [ForeignKey("idstoredepartparent")]
        [InverseProperty("storedepartrelidstoredepartparentNavigation")]
        public virtual storedepart? idstoredepartparentNavigation { get; set; }
    }
}
