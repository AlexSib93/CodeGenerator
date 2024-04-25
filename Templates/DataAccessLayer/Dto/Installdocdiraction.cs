using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiraction", Name = "idx_installdocdiraction_iddiraction")]
    [Index("idinstalldoc", Name = "idx_installdocdiraction_idinstalldoc")]
    [Index("idpeople", Name = "idx_installdocdiraction_idpeople")]
    [Index("idpeopleedit", Name = "idx_installdocdiraction_idpeopleedit")]
    public partial class installdocdiraction
    {
        public installdocdiraction()
        {
            installdocdiractionpeople = new HashSet<installdocdiractionpeople>();
        }

        [Key]
        public int idinstalldocdiraction { get; set; }
        public int? idinstalldoc { get; set; }
        public int? iddiraction { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
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

        [ForeignKey("iddiraction")]
        [InverseProperty("installdocdiraction")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("idinstalldoc")]
        [InverseProperty("installdocdiraction")]
        public virtual installdoc? idinstalldocNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("installdocdiractionidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeopleedit")]
        [InverseProperty("installdocdiractionidpeopleeditNavigation")]
        public virtual people? idpeopleeditNavigation { get; set; }
        [InverseProperty("idinstalldocdiractionNavigation")]
        public virtual ICollection<installdocdiractionpeople> installdocdiractionpeople { get; set; }
    }
}
