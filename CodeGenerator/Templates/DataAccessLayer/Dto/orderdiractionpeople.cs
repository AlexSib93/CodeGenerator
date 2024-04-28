using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorderdiraction", Name = "idx_orderdiractionpeople_idorderdiraction")]
    [Index("idpeople", Name = "idx_orderdiractionpeople_idpeople")]
    public partial class orderdiractionpeople
    {
        [Key]
        public int idorderdiractionpeople { get; set; }
        public int? idorderdiraction { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idorder { get; set; }

        [ForeignKey("idorderdiraction")]
        [InverseProperty("orderdiractionpeople")]
        public virtual orderdiraction? idorderdiractionNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("orderdiractionpeople")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
