using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    [Index("idequipment", Name = "idx_equipmentdocfile_idequipment")]
    [Index("idequipmentdoc", Name = "idx_equipmentdocfile_idequipmentdoc")]
    public partial class equipmentdocfile
    {
        public int? idequipmentdocfile { get; set; }
        public int? idequipment { get; set; }
        [Column(TypeName = "text")]
        public string? workfile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idequipmentdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? savefile { get; set; }

        [ForeignKey("idequipment")]
        public virtual equipment? idequipmentNavigation { get; set; }
        [ForeignKey("idequipmentdoc")]
        public virtual equipmentdoc? idequipmentdocNavigation { get; set; }
    }
}
