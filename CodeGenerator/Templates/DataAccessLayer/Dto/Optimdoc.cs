using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_optimdoc_idcustomer")]
    [Index("iddocoper", Name = "idx_optimdoc_iddocoper")]
    [Index("iddocstate", Name = "idx_optimdoc_iddocstate")]
    [Index("idmanufactdoc", Name = "idx_optimdoc_idmanufactdoc")]
    [Index("idoptimdocgroup", Name = "idx_optimdoc_idoptimdocgroup")]
    [Index("idorder", Name = "idx_optimdoc_idorder")]
    [Index("idpeople", Name = "idx_optimdoc_idpeople")]
    [Index("idstoredoc", Name = "idx_optimdoc_idstoredoc")]
    public partial class optimdoc
    {
        public optimdoc()
        {
            optimdocdiraction = new HashSet<optimdocdiraction>();
            optimdocgoodin = new HashSet<optimdocgoodin>();
            optimdocgoodout = new HashSet<optimdocgoodout>();
            optimdocpic = new HashSet<optimdocpic>();
            optimdocpos = new HashSet<optimdocpos>();
            optimdocsign = new HashSet<optimdocsign>();
        }

        [Key]
        public int idoptimdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? iddocoper { get; set; }
        public int? idcustomer { get; set; }
        public int? idpeople { get; set; }
        public int? idorder { get; set; }
        public int? idmanufactdoc { get; set; }
        public int? idstoredoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idoptimdocgroup { get; set; }
        public int? iddocstate { get; set; }
        public int? posgroup { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("optimdoc")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("optimdoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("optimdoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idoptimdocgroup")]
        [InverseProperty("optimdoc")]
        public virtual optimdocgroup? idoptimdocgroupNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("optimdoc")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("optimdoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idstoredoc")]
        [InverseProperty("optimdoc")]
        public virtual storedoc? idstoredocNavigation { get; set; }
        [InverseProperty("idoptimdocNavigation")]
        public virtual ICollection<optimdocdiraction> optimdocdiraction { get; set; }
        [InverseProperty("idoptimdocNavigation")]
        public virtual ICollection<optimdocgoodin> optimdocgoodin { get; set; }
        [InverseProperty("idoptimdocNavigation")]
        public virtual ICollection<optimdocgoodout> optimdocgoodout { get; set; }
        [InverseProperty("idoptimdocNavigation")]
        public virtual ICollection<optimdocpic> optimdocpic { get; set; }
        [InverseProperty("idoptimdocNavigation")]
        public virtual ICollection<optimdocpos> optimdocpos { get; set; }
        [InverseProperty("idoptimdocNavigation")]
        public virtual ICollection<optimdocsign> optimdocsign { get; set; }
    }
}
