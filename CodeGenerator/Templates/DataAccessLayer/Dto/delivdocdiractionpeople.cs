using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddelivdocdiraction", Name = "idx_delivdocdiractionpeople_iddelivdocdiraction")]
    [Index("idpeople", Name = "idx_delivdocdiractionpeople_idpeople")]
    public partial class delivdocdiractionpeople
    {
        [Key]
        public int iddelivdocdiractionpeople { get; set; }
        public int? iddelivdocdiraction { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? iddelivdoc { get; set; }

        [ForeignKey("iddelivdocdiraction")]
        [InverseProperty("delivdocdiractionpeople")]
        public virtual delivdocdiraction? iddelivdocdiractionNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("delivdocdiractionpeople")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
