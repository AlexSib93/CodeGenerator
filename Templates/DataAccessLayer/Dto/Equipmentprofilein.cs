using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idequipmentdoc", Name = "idx_equipmentprofilein_idequipmentdoc")]
    [Index("idmanufactdoc", Name = "idx_equipmentprofilein_idmanufactdoc")]
    public partial class equipmentprofilein
    {
        [Key]
        public int idequipmentprofilein { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? profilemarking { get; set; }
        public int? len { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? posgroup { get; set; }
        public int? ost { get; set; }
        public short? numpos { get; set; }
        public int? idmanufactdoc { get; set; }
        public int? idequipmentdoc { get; set; }

        [ForeignKey("idequipmentdoc")]
        [InverseProperty("equipmentprofilein")]
        public virtual equipmentdoc? idequipmentdocNavigation { get; set; }
        [ForeignKey("idmanufactdoc")]
        [InverseProperty("equipmentprofilein")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
    }
}
