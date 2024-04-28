using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomerparent", "idcustomerchild", Name = "customerrel_unique", IsUnique = true)]
    [Index("idcustomertyperel", Name = "idx_customerrel_idcustomertyperel")]
    [Index("idpeopleedit", Name = "idx_customerrel_idpeopleedit")]
    public partial class customerrel
    {
        [Key]
        public int idcustomerrel { get; set; }
        public int idcustomerparent { get; set; }
        public int idcustomerchild { get; set; }
        public int idcustomertyperel { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeopleedit { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr5 { get; set; }
        public bool? ismaster { get; set; }

        [ForeignKey("idcustomerchild")]
        [InverseProperty("customerrelidcustomerchildNavigation")]
        public virtual customer idcustomerchildNavigation { get; set; } = null!;
        [ForeignKey("idcustomerparent")]
        [InverseProperty("customerrelidcustomerparentNavigation")]
        public virtual customer idcustomerparentNavigation { get; set; } = null!;
        [ForeignKey("idcustomertyperel")]
        [InverseProperty("customerrel")]
        public virtual customertyperel idcustomertyperelNavigation { get; set; } = null!;
        [ForeignKey("idpeopleedit")]
        [InverseProperty("customerrel")]
        public virtual people? idpeopleeditNavigation { get; set; }
    }
}
