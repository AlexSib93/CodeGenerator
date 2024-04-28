using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_paymentdocgroup_parentid")]
    public partial class paymentdocgroup
    {
        public paymentdocgroup()
        {
            paymentdoc = new HashSet<paymentdoc>();
        }

        [Key]
        public int idpaymentdocgroup { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? parentid { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "text")]
        public string? filtertext { get; set; }
        public short? isload { get; set; }
        public int? numpos { get; set; }

        [InverseProperty("idpaymentdocgroupNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
    }
}
