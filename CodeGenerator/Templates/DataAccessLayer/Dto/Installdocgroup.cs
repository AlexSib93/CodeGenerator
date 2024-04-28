using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_installdocgroup_parentid")]
    public partial class installdocgroup
    {
        public installdocgroup()
        {
            installdoc = new HashSet<installdoc>();
        }

        [Key]
        public int idinstalldocgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "text")]
        public string? filtertext { get; set; }
        public int? numpos { get; set; }
        public short? isload { get; set; }

        [InverseProperty("idinstalldocgroupNavigation")]
        public virtual ICollection<installdoc> installdoc { get; set; }
    }
}
