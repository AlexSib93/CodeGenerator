using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocoper", Name = "idx_storedepartdocoper_iddocoper")]
    [Index("idstoredepart", Name = "idx_storedepartdocoper_idstoredepart")]
    public partial class storedepartdocoper
    {
        [Key]
        public int idstoredepartdocoper { get; set; }
        public int? idstoredepart { get; set; }
        public int? iddocoper { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("iddocoper")]
        [InverseProperty("storedepartdocoper")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("idstoredepart")]
        [InverseProperty("storedepartdocoper")]
        public virtual storedepart? idstoredepartNavigation { get; set; }
    }
}
