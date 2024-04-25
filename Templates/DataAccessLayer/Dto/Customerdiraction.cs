using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customerdiraction_idcustomer")]
    [Index("iddiraction", Name = "idx_customerdiraction_iddiraction")]
    [Index("idpeople", Name = "idx_customerdiraction_idpeople")]
    [Index("idpeopleedit", Name = "idx_customerdiraction_idpeopleedit")]
    [Index("idpeopleсreate", Name = "idx_customerdiraction_idpeopleсreate")]
    public partial class customerdiraction
    {
        [Key]
        public int idcustomerdiraction { get; set; }
        public int? idcustomer { get; set; }
        public int? iddiraction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? idpeopleсreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerdiraction")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddiraction")]
        [InverseProperty("customerdiraction")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("customerdiractionidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeopleedit")]
        [InverseProperty("customerdiractionidpeopleeditNavigation")]
        public virtual people? idpeopleeditNavigation { get; set; }
        [ForeignKey("idpeopleсreate")]
        [InverseProperty("customerdiractionidpeopleсreateNavigation")]
        public virtual people? idpeopleсreateNavigation { get; set; }
    }
}
