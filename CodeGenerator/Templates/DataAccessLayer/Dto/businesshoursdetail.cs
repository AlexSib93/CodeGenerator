using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idbusinesshours", Name = "idx_businesshoursdetail_idbusinesshours")]
    public partial class businesshoursdetail
    {
        [Key]
        public int idbusinesshoursdetail { get; set; }
        public int idbusinesshours { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dtstart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dtend { get; set; }
        public int type { get; set; }

        [ForeignKey("idbusinesshours")]
        [InverseProperty("businesshoursdetail")]
        public virtual businesshours idbusinesshoursNavigation { get; set; } = null!;
    }
}
