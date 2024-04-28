using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_customergroup_parentid")]
    public partial class customergroup
    {
        public customergroup()
        {
            customer = new HashSet<customer>();
        }

        [Key]
        public int idcustomergroup { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idaw { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "text")]
        public string? filtertext { get; set; }
        public int? numpos { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        public Guid guid { get; set; }
        public bool? indealerbase { get; set; }
        public bool? isload { get; set; }

        [InverseProperty("idcustomergroupNavigation")]
        public virtual ICollection<customer> customer { get; set; }
    }
}
