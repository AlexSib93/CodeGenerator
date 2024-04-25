using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiraction", Name = "idx_supplydocdiraction_iddiraction")]
    [Index("idpeopleсreate", Name = "idx_supplydocdiraction_idpeopleсreate")]
    public partial class supplydocdiraction
    {
        [Key]
        public int idsupplydocdiraction { get; set; }
        public int idsupplydoc { get; set; }
        public int iddiraction { get; set; }
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

        [ForeignKey("iddiraction")]
        [InverseProperty("supplydocdiraction")]
        public virtual diraction iddiractionNavigation { get; set; } = null!;
        [ForeignKey("idpeopleсreate")]
        [InverseProperty("supplydocdiraction")]
        public virtual people? idpeopleсreateNavigation { get; set; }
    }
}
