using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_equipmentdocfile
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
        [StringLength(128)]
        [Unicode(false)]
        public string? equipment_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? equipment_marking { get; set; }
        public int? equipment_numpos { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? equipment_savepath { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? equipment_filemask { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? equipment_savefile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? equipmentdoc_dtdoc { get; set; }
    }
}
