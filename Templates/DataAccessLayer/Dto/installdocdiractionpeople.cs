using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idinstalldocdiraction", Name = "idx_installdocdiractionpeople_idinstalldocdiraction")]
    [Index("idpeople", Name = "idx_installdocdiractionpeople_idpeople")]
    public partial class installdocdiractionpeople
    {
        [Key]
        public int idinstalldocdiractionpeople { get; set; }
        public int? idinstalldocdiraction { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idinstalldoc { get; set; }

        [ForeignKey("idinstalldocdiraction")]
        [InverseProperty("installdocdiractionpeople")]
        public virtual installdocdiraction? idinstalldocdiractionNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("installdocdiractionpeople")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
