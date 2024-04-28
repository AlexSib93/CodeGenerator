using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_coatdoc_idcustomer")]
    [Index("iddocoper", Name = "idx_coatdoc_iddocoper")]
    [Index("iddocstate", Name = "idx_coatdoc_iddocstate")]
    [Index("idpeople", Name = "idx_coatdoc_idpeople")]
    [Index("idstoredepart", Name = "idx_coatdoc_idstoredepart")]
    public partial class coatdoc
    {
        public coatdoc()
        {
            coatdocpos = new HashSet<coatdocpos>();
            coatdocsign = new HashSet<coatdocsign>();
        }

        [Key]
        public int idcoatdoc { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        public int? idcustomer { get; set; }
        public int? idpeople { get; set; }
        public int? iddocoper { get; set; }
        public int? idstoredepart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        public int? qumarking { get; set; }
        public int? quwhip { get; set; }
        public int? iddocstate { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("coatdoc")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("coatdoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("coatdoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("coatdoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idstoredepart")]
        [InverseProperty("coatdoc")]
        public virtual storedepart? idstoredepartNavigation { get; set; }
        [InverseProperty("idcoatdocNavigation")]
        public virtual ICollection<coatdocpos> coatdocpos { get; set; }
        [InverseProperty("idcoatdocNavigation")]
        public virtual ICollection<coatdocsign> coatdocsign { get; set; }
    }
}
