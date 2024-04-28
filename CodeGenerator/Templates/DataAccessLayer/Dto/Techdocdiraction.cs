using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiraction", Name = "idx_techdocdiraction_iddiraction")]
    [Index("idpeople", Name = "idx_techdocdiraction_idpeople")]
    [Index("idtechdoc", Name = "idx_techdocdiraction_idtechdoc")]
    public partial class techdocdiraction
    {
        [Key]
        public int idtechdocdiraction { get; set; }
        public int? idtechdoc { get; set; }
        public int? iddiraction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        public int? idpeople { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeopleedit { get; set; }
        public int? idpeoplecreate { get; set; }

        [ForeignKey("iddiraction")]
        [InverseProperty("techdocdiraction")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("techdocdiraction")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idtechdoc")]
        [InverseProperty("techdocdiraction")]
        public virtual techdoc? idtechdocNavigation { get; set; }
    }
}
