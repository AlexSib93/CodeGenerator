using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_cashbox_idpeople")]
    public partial class cashbox
    {
        public cashbox()
        {
            paymentdoc = new HashSet<paymentdoc>();
        }

        [Key]
        public int idcashbox { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("cashbox")]
        public virtual people? idpeopleNavigation { get; set; }
        [InverseProperty("idcashboxNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
    }
}
