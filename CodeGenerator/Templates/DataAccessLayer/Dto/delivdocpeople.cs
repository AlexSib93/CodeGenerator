using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddelivdoc", Name = "idx_delivdocpeople_iddelivdoc")]
    [Index("idpeople", Name = "idx_delivdocpeople_idpeople")]
    [Index("idpeople2", Name = "idx_delivdocpeople_idpeople2")]
    public partial class delivdocpeople
    {
        [Key]
        public int iddelivdocpeople { get; set; }
        public int? iddelivdoc { get; set; }
        public int? idpeople { get; set; }
        public int? idpeople2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt2 { get; set; }

        [ForeignKey("iddelivdoc")]
        [InverseProperty("delivdocpeople")]
        public virtual delivdoc? iddelivdocNavigation { get; set; }
        [ForeignKey("idpeople2")]
        [InverseProperty("delivdocpeopleidpeople2Navigation")]
        public virtual people? idpeople2Navigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("delivdocpeopleidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
