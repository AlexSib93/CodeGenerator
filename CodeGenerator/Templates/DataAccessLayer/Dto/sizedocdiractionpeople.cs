using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_sizedocdiractionpeople_idpeople")]
    [Index("idsizedocdiraction", Name = "idx_sizedocdiractionpeople_idsizedocdiraction")]
    public partial class sizedocdiractionpeople
    {
        [Key]
        public int idsizedocdiractionpeople { get; set; }
        public int? idsizedocdiraction { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idsizedoc { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("sizedocdiractionpeople")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsizedocdiraction")]
        [InverseProperty("sizedocdiractionpeople")]
        public virtual sizedocdiraction? idsizedocdiractionNavigation { get; set; }
    }
}
