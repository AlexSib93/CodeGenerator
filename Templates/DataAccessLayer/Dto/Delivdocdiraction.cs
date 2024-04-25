using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddelivdoc", Name = "idx_delivdocdiraction_iddelivdoc")]
    [Index("iddiraction", Name = "idx_delivdocdiraction_iddiraction")]
    [Index("idpeople", Name = "idx_delivdocdiraction_idpeople")]
    [Index("idpeopleedit", Name = "idx_delivdocdiraction_idpeopleedit")]
    public partial class delivdocdiraction
    {
        public delivdocdiraction()
        {
            delivdocdiractionpeople = new HashSet<delivdocdiractionpeople>();
        }

        [Key]
        public int iddelivdocdiraction { get; set; }
        public int? iddelivdoc { get; set; }
        public int? iddiraction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeopleedit { get; set; }

        [ForeignKey("iddelivdoc")]
        [InverseProperty("delivdocdiraction")]
        public virtual delivdoc? iddelivdocNavigation { get; set; }
        [ForeignKey("iddiraction")]
        [InverseProperty("delivdocdiraction")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("delivdocdiractionidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeopleedit")]
        [InverseProperty("delivdocdiractionidpeopleeditNavigation")]
        public virtual people? idpeopleeditNavigation { get; set; }
        [InverseProperty("iddelivdocdiractionNavigation")]
        public virtual ICollection<delivdocdiractionpeople> delivdocdiractionpeople { get; set; }
    }
}
