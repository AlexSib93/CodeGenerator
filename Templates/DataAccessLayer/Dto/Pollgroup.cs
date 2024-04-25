using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_pollgroup_parentid")]
    public partial class pollgroup
    {
        public pollgroup()
        {
            poll = new HashSet<poll>();
        }

        [Key]
        public int idpollgroup { get; set; }
        public int? parentid { get; set; }
        public int? numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? typ { get; set; }
        [Unicode(false)]
        public string? filtertext { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public bool? isactive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idpollgroupNavigation")]
        public virtual ICollection<poll> poll { get; set; }
    }
}
