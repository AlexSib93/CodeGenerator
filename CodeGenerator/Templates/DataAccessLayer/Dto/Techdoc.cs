using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_techdoc_idcustomer")]
    [Index("iddocoper", Name = "idx_techdoc_iddocoper")]
    [Index("iddocstate", Name = "idx_techdoc_iddocstate")]
    [Index("idpeople", Name = "idx_techdoc_idpeople")]
    [Index("idtechdocgroup", Name = "idx_techdoc_idtechdocgroup")]
    public partial class techdoc
    {
        public techdoc()
        {
            techdocdiraction = new HashSet<techdocdiraction>();
            techdocpos = new HashSet<techdocpos>();
            techdocsign = new HashSet<techdocsign>();
        }

        [Key]
        public int idtechdoc { get; set; }
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
        public int? idtechdocgroup { get; set; }
        public int? iddocstate { get; set; }
        public int? idorder { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("techdoc")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("techdoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("techdoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("techdoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idtechdocgroup")]
        [InverseProperty("techdoc")]
        public virtual techdocgroup? idtechdocgroupNavigation { get; set; }
        [InverseProperty("idtechdocNavigation")]
        public virtual ICollection<techdocdiraction> techdocdiraction { get; set; }
        [InverseProperty("idtechdocNavigation")]
        public virtual ICollection<techdocpos> techdocpos { get; set; }
        [InverseProperty("idtechdocNavigation")]
        public virtual ICollection<techdocsign> techdocsign { get; set; }
    }
}
