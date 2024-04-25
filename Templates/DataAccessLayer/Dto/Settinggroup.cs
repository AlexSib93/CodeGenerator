using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__settinggroup__116138B1", IsUnique = true)]
    [Index("parentid", Name = "idx_settinggroup_parentid")]
    public partial class settinggroup
    {
        public settinggroup()
        {
            setting = new HashSet<setting>();
        }

        [Key]
        public int idsettinggroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? isactive { get; set; }
        public int? parentid { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idsettinggroupNavigation")]
        public virtual ICollection<setting> setting { get; set; }
    }
}
