using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorder", "iddiraction", "dtcreate", Name = "idx_lastval")]
    [Index("factdate", Name = "idx_orderdiraction_factdate")]
    [Index("iddiraction", Name = "idx_orderdiraction_iddiraction")]
    [Index("idorder", Name = "idx_orderdiraction_idorder")]
    [Index("idpeople", Name = "idx_orderdiraction_idpeople")]
    [Index("idpeopleedit", Name = "idx_orderdiraction_idpeople2")]
    [Index("idorderitem", Name = "idx_orderdiraction_orderitem")]
    [Index("plandate", Name = "idx_orderdiraction_plandate")]
    public partial class orderdiraction
    {
        public orderdiraction()
        {
            orderdiractionpeople = new HashSet<orderdiractionpeople>();
        }

        [Key]
        public int idorderdiraction { get; set; }
        public int? iddiraction { get; set; }
        public int? idorder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeopleedit { get; set; }
        public int? idpeople3 { get; set; }
        public int? idorderitem { get; set; }
        public int? orderitemnum { get; set; }
        public int? workshop { get; set; }
        public int? poolnum { get; set; }
        public int? posgroup { get; set; }
        public int? poolnumcustom { get; set; }
        public int? duration { get; set; }
        public int? sortnum { get; set; }

        [ForeignKey("iddiraction")]
        [InverseProperty("orderdiraction")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("orderdiraction")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("orderdiraction")]
        public virtual people? idpeopleNavigation { get; set; }
        [InverseProperty("idorderdiractionNavigation")]
        public virtual ICollection<orderdiractionpeople> orderdiractionpeople { get; set; }
    }
}
