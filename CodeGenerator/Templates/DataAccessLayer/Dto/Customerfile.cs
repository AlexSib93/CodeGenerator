using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customerfile_idcustomer")]
    public partial class customerfile
    {
        [Key]
        public int idcustomerfile { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? path { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public byte[]? filebyte { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcustomer { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerfile")]
        public virtual customer? idcustomerNavigation { get; set; }
    }
}
