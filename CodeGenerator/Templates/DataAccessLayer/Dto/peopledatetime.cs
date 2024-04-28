using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeopledate", Name = "idx_peopledatetime_idpeopledate")]
    public partial class peopledatetime
    {
        [Key]
        public int idpeopledatetime { get; set; }
        public int idpeopledate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dtstart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dtend { get; set; }
        public int type { get; set; }

        [ForeignKey("idpeopledate")]
        [InverseProperty("peopledatetime")]
        public virtual peopledate idpeopledateNavigation { get; set; } = null!;
    }
}
