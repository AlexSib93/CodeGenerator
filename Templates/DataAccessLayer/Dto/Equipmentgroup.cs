using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_equipmentgroup_parentid")]
    public partial class equipmentgroup
    {
        public equipmentgroup()
        {
            Inverseparent = new HashSet<equipmentgroup>();
            equipment = new HashSet<equipment>();
        }

        [Key]
        public int idequipmentgroup { get; set; }
        public int? parentid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("parentid")]
        [InverseProperty("Inverseparent")]
        public virtual equipmentgroup? parent { get; set; }
        [InverseProperty("parent")]
        public virtual ICollection<equipmentgroup> Inverseparent { get; set; }
        [InverseProperty("idequipmentgroupNavigation")]
        public virtual ICollection<equipment> equipment { get; set; }
    }
}
