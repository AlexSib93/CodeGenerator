using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idagreement", Name = "idx_customeragreement_idagreement")]
    [Index("idcustomer", Name = "idx_customeragreement_idcustomer")]
    public partial class customeragreement
    {
        [Key]
        public int idcustomeragreement { get; set; }
        public int? idcustomer { get; set; }
        public int? idagreement { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? agreement { get; set; }
        public bool? ismain { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? seller { get; set; }

        [ForeignKey("idagreement")]
        [InverseProperty("customeragreement")]
        public virtual agreement? idagreementNavigation { get; set; }
        [ForeignKey("idcustomer")]
        [InverseProperty("customeragreement")]
        public virtual customer? idcustomerNavigation { get; set; }
    }
}
