using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customerevent_idcustomer")]
    public partial class customerevent
    {
        [Key]
        public int idcustomerevent { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcustomer { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerevent")]
        public virtual customer? idcustomerNavigation { get; set; }
    }
}
