using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("barcode", Name = "idx_equipmentglass_barcode")]
    [Index("idequipmentdoc", Name = "idx_equipmentglass_idequipmentdoc")]
    [Index("idmanufactdoc", Name = "idx_equipmentglass_idmanufactdoc")]
    [Index("idorder", Name = "idx_equipmentglass_idorder")]
    [Index("idorderitem", Name = "idx_equipmentglass_idorderitem")]
    [Index("width", Name = "idx_equipmentglass_width")]
    public partial class equipmentglass
    {
        [Key]
        public int idequipmentglass { get; set; }
        public int? idequipmentdoc { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        public int? orderitemnum { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? marking { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? cart { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? thickness { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? part { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? posgroup { get; set; }
        public int? idmanufactdoc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public int? idmanufactdocpos { get; set; }

        [ForeignKey("idequipmentdoc")]
        [InverseProperty("equipmentglass")]
        public virtual equipmentdoc? idequipmentdocNavigation { get; set; }
    }
}
