using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_manufactdiractionpeople_idpeople")]
    public partial class manufactdiractionpeople
    {
        [Key]
        public int idmanufactdiractionpeople { get; set; }
        public int? idmanufactdiraction { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idmanufactdoc { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("manufactdiractionpeople")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
