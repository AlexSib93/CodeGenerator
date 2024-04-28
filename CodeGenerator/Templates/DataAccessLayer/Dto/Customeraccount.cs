using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customeraccount_idcustomer")]
    public partial class customeraccount
    {
        [Key]
        public int idcustomeraccount { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? rs { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? cs { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? bik { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? bank { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcustomer { get; set; }
        public Guid guid { get; set; }
        public bool? ismain { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customeraccount")]
        public virtual customer? idcustomerNavigation { get; set; }
    }
}
