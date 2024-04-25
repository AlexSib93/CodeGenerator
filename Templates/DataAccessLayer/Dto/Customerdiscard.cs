using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customerdiscard_idcustomer")]
    [Index("iddiscard", Name = "idx_customerdiscard_iddiscard")]
    public partial class customerdiscard
    {
        [Key]
        public int idcustomerdiscard { get; set; }
        public int? idcustomer { get; set; }
        public int? iddiscard { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerdiscard")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddiscard")]
        [InverseProperty("customerdiscard")]
        public virtual discard? iddiscardNavigation { get; set; }
    }
}
