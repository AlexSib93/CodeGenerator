using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idaddress", Name = "idx_customeraddress_idaddress")]
    [Index("idcustomer", Name = "idx_customeraddress_idcustomer")]
    public partial class customeraddress
    {
        [Key]
        public int idcustomeraddress { get; set; }
        public int? idcustomer { get; set; }
        public int? idaddress { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? address { get; set; }

        [ForeignKey("idaddress")]
        [InverseProperty("customeraddress")]
        public virtual address? idaddressNavigation { get; set; }
        [ForeignKey("idcustomer")]
        [InverseProperty("customeraddress")]
        public virtual customer? idcustomerNavigation { get; set; }
    }
}
