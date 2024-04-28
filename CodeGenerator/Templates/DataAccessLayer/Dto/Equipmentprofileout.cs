using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idequipmentdoc", Name = "idx_equipmentprofileout_idequipmentdoc")]
    [Index("idequipmentprofilein", Name = "idx_equipmentprofileout_idequipmentprofilein")]
    [Index("idmanufactdoc", Name = "idx_equipmentprofileout_idmanufactdoc")]
    public partial class equipmentprofileout
    {
        [Key]
        public int idequipmentprofileout { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? profilemarking { get; set; }
        public int? idequipmentprofilein { get; set; }
        public int? len { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? posgroup { get; set; }
        public short? numpos { get; set; }
        public int? idmanufactdoc { get; set; }
        public byte[]? picture { get; set; }
        public int? worklen { get; set; }
        public int? whiplen { get; set; }
        public int? whip { get; set; }
        public int? whiptype { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public int? whiposttype { get; set; }
        public int? idequipmentdoc { get; set; }

        [ForeignKey("idequipmentdoc")]
        [InverseProperty("equipmentprofileout")]
        public virtual equipmentdoc? idequipmentdocNavigation { get; set; }
        [ForeignKey("idmanufactdoc")]
        [InverseProperty("equipmentprofileout")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
    }
}
