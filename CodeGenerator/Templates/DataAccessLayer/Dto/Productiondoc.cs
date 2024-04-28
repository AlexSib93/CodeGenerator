using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocoper", Name = "idx_productiondoc_iddocoper")]
    [Index("iddocstate", Name = "idx_productiondoc_iddocstate")]
    [Index("idpeople", Name = "idx_productiondoc_idpeople")]
    [Index("idproductiondocgroup", Name = "idx_productiondoc_idproductiondocgroup")]
    public partial class productiondoc
    {
        public productiondoc()
        {
            productiondocpos = new HashSet<productiondocpos>();
            productiondocsign = new HashSet<productiondocsign>();
        }

        [Key]
        public int idproductiondoc { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        public int? iddocoper { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        public int? qupos { get; set; }
        public int? idproductiondocgroup { get; set; }
        public int? idcustomer { get; set; }
        public int? idstoredepart1 { get; set; }
        public int? idstoredepart2 { get; set; }
        public int? iddocstate { get; set; }

        [ForeignKey("iddocoper")]
        [InverseProperty("productiondoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("productiondoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("productiondoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idproductiondocgroup")]
        [InverseProperty("productiondoc")]
        public virtual productiondocgroup? idproductiondocgroupNavigation { get; set; }
        [InverseProperty("idproductiondocNavigation")]
        public virtual ICollection<productiondocpos> productiondocpos { get; set; }
        [InverseProperty("idproductiondocNavigation")]
        public virtual ICollection<productiondocsign> productiondocsign { get; set; }
    }
}
