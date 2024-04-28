using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__paymentdoc__4ACEC037", IsUnique = true)]
    [Index("idcustomer", Name = "idx_payment_idcustomer")]
    [Index("iddocoper", Name = "idx_payment_iddocoper")]
    [Index("idorder", Name = "idx_payment_idorder")]
    [Index("idpaymentgroup", Name = "idx_payment_idpaymentgroup")]
    [Index("idpeople", Name = "idx_payment_idpeople")]
    [Index("idcashbox", Name = "idx_paymentdoc_idcashbox")]
    [Index("iddocstate", Name = "idx_paymentdoc_iddocstate")]
    [Index("idpaymentdocgroup", Name = "idx_paymentdoc_idpaymentdocgroup")]
    [Index("idseller", Name = "idx_paymentdoc_idseller")]
    [Index("idservicedoc", Name = "idx_paymentdoc_idservicedoc")]
    [Index("idsupplydoc", Name = "idx_paymentdoc_idsupplydoc")]
    [Index("idvalut", Name = "idx_paymentdoc_idvalut")]
    [Index("parentid", Name = "idx_paymentdoc_parentid")]
    public partial class paymentdoc
    {
        public paymentdoc()
        {
            paymentdocsign = new HashSet<paymentdocsign>();
        }

        [Key]
        public int idpaymentdoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        public int? idcustomer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? logincre { get; set; }
        public int? idorder { get; set; }
        public int? idpaymentgroup { get; set; }
        public int? iddocoper { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idpaymentdocgroup { get; set; }
        public int? idseller { get; set; }
        public Guid guid { get; set; }
        public int? idpeople2 { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? addstr { get; set; }
        public int? iddocstate { get; set; }
        public int? parentid { get; set; }
        public bool? saved { get; set; }
        public int? idsupplydoc { get; set; }
        public int? idservicedoc { get; set; }
        public int? idcashbox { get; set; }

        [ForeignKey("idcashbox")]
        [InverseProperty("paymentdoc")]
        public virtual cashbox? idcashboxNavigation { get; set; }
        [ForeignKey("idcustomer")]
        [InverseProperty("paymentdoc")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("paymentdoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("paymentdoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("paymentdoc")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpaymentdocgroup")]
        [InverseProperty("paymentdoc")]
        public virtual paymentdocgroup? idpaymentdocgroupNavigation { get; set; }
        [ForeignKey("idpaymentgroup")]
        [InverseProperty("paymentdoc")]
        public virtual paymentgroup? idpaymentgroupNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("paymentdoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("paymentdoc")]
        public virtual seller? idsellerNavigation { get; set; }
        [ForeignKey("idservicedoc")]
        [InverseProperty("paymentdoc")]
        public virtual servicedoc? idservicedocNavigation { get; set; }
        [ForeignKey("idsupplydoc")]
        [InverseProperty("paymentdoc")]
        public virtual supplydoc? idsupplydocNavigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("paymentdoc")]
        public virtual valut? idvalutNavigation { get; set; }
        [InverseProperty("idpaymentdocNavigation")]
        public virtual ICollection<paymentdocsign> paymentdocsign { get; set; }
    }
}
