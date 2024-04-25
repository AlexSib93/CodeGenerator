using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("barcode", Name = "idx_equipmentprofile_barcode")]
    [Index("idequipmentdoc", Name = "idx_equipmentprofile_idequipmentdoc")]
    [Index("idequipmentglass", Name = "idx_equipmentprofile_idequipmentglass")]
    [Index("idequipmentper", Name = "idx_equipmentprofile_idequipmentper")]
    [Index("idequipmentprofilein", Name = "idx_equipmentprofile_idequipmentprofilein")]
    [Index("idmanufactdoc", Name = "idx_equipmentprofile_idmanufactdoc")]
    [Index("idorder", Name = "idx_equipmentprofile_idorder")]
    [Index("idorderitem", Name = "idx_equipmentprofile_idorderitem")]
    [Index("profileside", Name = "idx_equipmentprofile_profileside")]
    public partial class equipmentprofile
    {
        [Key]
        public int idequipmentprofile { get; set; }
        public int? idequipmentdoc { get; set; }
        public int? idmanufactdoc { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? posgroup { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? profilemarking { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? steelmarking { get; set; }
        public int? profilelen { get; set; }
        public int? steellen { get; set; }
        public int? numpos { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? ordername { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? orderitemname { get; set; }
        public int? orderitemnum { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? profileside { get; set; }
        public int? handlepos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? profilecart { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? glasscart { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? shtapikcart { get; set; }
        public int? idequipmentper { get; set; }
        public int? numposbalka { get; set; }
        public int? numposbalkapos { get; set; }
        public int? whip { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strnum { get; set; }
        public int? idequipmentglass { get; set; }
        public int? sortnum { get; set; }
        public int? whipost { get; set; }
        public int? idequipmentprofilein { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? barcode { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorin { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorout { get; set; }
        public int? orderitemnumpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? agreename { get; set; }
        public int? optimsort { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? profiletype { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? customername { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? destanation { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? globalid { get; set; }
        public int? whiposttype { get; set; }
        public int? idmanufactdocpos { get; set; }

        [ForeignKey("idequipmentdoc")]
        [InverseProperty("equipmentprofile")]
        public virtual equipmentdoc? idequipmentdocNavigation { get; set; }
        [ForeignKey("idequipmentper")]
        [InverseProperty("equipmentprofile")]
        public virtual equipmentper? idequipmentperNavigation { get; set; }
    }
}
