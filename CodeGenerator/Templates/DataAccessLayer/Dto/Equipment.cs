using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idequipmentgroup", Name = "idx_equipment_idequipmentgroup")]
    public partial class equipment
    {
        [Key]
        public int idequipment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? factory { get; set; }
        [Column(TypeName = "text")]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "text")]
        public string? codescript { get; set; }
        public short? isactive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? scriptversoin { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? savepath { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? filemask { get; set; }
        public int? numpos { get; set; }
        public byte[]? dll { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? savefile { get; set; }
        public int? idequipmentgroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcompile { get; set; }
        public bool? compiled { get; set; }
        public Guid guid { get; set; }
        public byte[]? pdb { get; set; }

        [ForeignKey("idequipmentgroup")]
        [InverseProperty("equipment")]
        public virtual equipmentgroup? idequipmentgroupNavigation { get; set; }
    }
}
