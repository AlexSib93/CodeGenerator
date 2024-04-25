using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_supplydoc_idcustomer")]
    [Index("idcustomer2", Name = "idx_supplydoc_idcustomer2")]
    [Index("iddocoper", Name = "idx_supplydoc_iddocoper")]
    [Index("iddocstate", Name = "idx_supplydoc_iddocstate")]
    [Index("idorder", Name = "idx_supplydoc_idorder")]
    [Index("idpeople", Name = "idx_supplydoc_idpeople")]
    [Index("idseller", Name = "idx_supplydoc_idseller")]
    [Index("idsupplydocgroup", Name = "idx_supplydoc_idsupplydocgroup")]
    [Index("idvalut", Name = "idx_supplydoc_idvalut")]
    public partial class supplydoc
    {
        public supplydoc()
        {
            paymentdoc = new HashSet<paymentdoc>();
            supplydocgoodservice = new HashSet<supplydocgoodservice>();
            supplydocpos = new HashSet<supplydocpos>();
            supplydocsign = new HashSet<supplydocsign>();
        }

        [Key]
        public int idsupplydoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        public int? iddocoper { get; set; }
        public int? idcustomer { get; set; }
        public int? idsupplydocgroup { get; set; }
        public int? idorder { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        public int? iddocstate { get; set; }
        public int? idcustomer2 { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public bool withnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sumnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? nds { get; set; }
        public int? idseller { get; set; }

        [ForeignKey("idcustomer2")]
        [InverseProperty("supplydocidcustomer2Navigation")]
        public virtual customer? idcustomer2Navigation { get; set; }
        [ForeignKey("idcustomer")]
        [InverseProperty("supplydocidcustomerNavigation")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("supplydoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("supplydoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("supplydoc")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("supplydoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("supplydoc")]
        public virtual seller? idsellerNavigation { get; set; }
        [ForeignKey("idsupplydocgroup")]
        [InverseProperty("supplydoc")]
        public virtual supplydocgroup? idsupplydocgroupNavigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("supplydoc")]
        public virtual valut? idvalutNavigation { get; set; }
        [InverseProperty("idsupplydocNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
        [InverseProperty("idsupplydocNavigation")]
        public virtual ICollection<supplydocgoodservice> supplydocgoodservice { get; set; }
        [InverseProperty("idsupplydocNavigation")]
        public virtual ICollection<supplydocpos> supplydocpos { get; set; }
        [InverseProperty("idsupplydocNavigation")]
        public virtual ICollection<supplydocsign> supplydocsign { get; set; }
    }
}
