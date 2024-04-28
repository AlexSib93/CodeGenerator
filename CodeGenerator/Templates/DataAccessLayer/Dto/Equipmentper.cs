using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idequipmentdoc", Name = "idx_equipmentper_idequipmentdoc")]
    [Index("idmanufactdoc", Name = "idx_equipmentper_idmanufactdoc")]
    [Index("idorder", Name = "idx_equipmentper_idorder")]
    [Index("idorderitem", Name = "idx_equipmentper_idorderitem")]
    [Index("width", Name = "idx_equipmentper_width")]
    public partial class equipmentper
    {
        public equipmentper()
        {
            equipmentprofile = new HashSet<equipmentprofile>();
        }

        [Key]
        public int idequipmentper { get; set; }
        public int? idequipmentdoc { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? profiletype { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? posgroup { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? cart { get; set; }
        public int? orderitemnum { get; set; }
        public int? idmanufactdoc { get; set; }
        public int? orderitemnumpos { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }

        [InverseProperty("idequipmentperNavigation")]
        public virtual ICollection<equipmentprofile> equipmentprofile { get; set; }
    }
}
