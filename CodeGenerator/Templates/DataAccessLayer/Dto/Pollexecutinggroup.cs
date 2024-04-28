using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_pollexecutinggroup_parentid")]
    public partial class pollexecutinggroup
    {
        public pollexecutinggroup()
        {
            pollexecuting = new HashSet<pollexecuting>();
        }

        [Key]
        public int idpollexecutinggroup { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? typ { get; set; }
        [Unicode(false)]
        public string? filtertext { get; set; }
        public int? numpos { get; set; }
        public bool? isload { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }

        [InverseProperty("idpollexecutinggroupNavigation")]
        public virtual ICollection<pollexecuting> pollexecuting { get; set; }
    }
}
