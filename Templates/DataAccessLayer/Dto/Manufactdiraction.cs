using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiraction", Name = "idx_manufactdiraction_iddiraction")]
    [Index("idmanufactdoc", Name = "idx_manufactdiraction_idmanufactdoc")]
    public partial class manufactdiraction
    {
        [Key]
        public int idmanufactdiraction { get; set; }
        public int? iddiraction { get; set; }
        public int? idmanufactdoc { get; set; }
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

        [ForeignKey("iddiraction")]
        [InverseProperty("manufactdiraction")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("idmanufactdoc")]
        [InverseProperty("manufactdiraction")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
    }
}
