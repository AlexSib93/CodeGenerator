using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmanufactdoc", Name = "idx_equipmentdoc_idmanufactdoc")]
    [Index("idpeople", Name = "idx_equipmentdoc_idpeople")]
    public partial class equipmentdoc
    {
        public equipmentdoc()
        {
            equipmentglass = new HashSet<equipmentglass>();
            equipmentprofile = new HashSet<equipmentprofile>();
            equipmentprofilein = new HashSet<equipmentprofilein>();
            equipmentprofileout = new HashSet<equipmentprofileout>();
        }

        [Key]
        public int idequipmentdoc { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idpeople { get; set; }
        public int? idmanufactdoc { get; set; }

        [ForeignKey("idmanufactdoc")]
        [InverseProperty("equipmentdoc")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("equipmentdoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [InverseProperty("idequipmentdocNavigation")]
        public virtual ICollection<equipmentglass> equipmentglass { get; set; }
        [InverseProperty("idequipmentdocNavigation")]
        public virtual ICollection<equipmentprofile> equipmentprofile { get; set; }
        [InverseProperty("idequipmentdocNavigation")]
        public virtual ICollection<equipmentprofilein> equipmentprofilein { get; set; }
        [InverseProperty("idequipmentdocNavigation")]
        public virtual ICollection<equipmentprofileout> equipmentprofileout { get; set; }
    }
}
