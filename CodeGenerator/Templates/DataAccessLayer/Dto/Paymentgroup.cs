using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class paymentgroup
    {
        public paymentgroup()
        {
            paymentdoc = new HashSet<paymentdoc>();
        }

        [Key]
        public int idpaymentgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idpaymentgroupNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
    }
}
