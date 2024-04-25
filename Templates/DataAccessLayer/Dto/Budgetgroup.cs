using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_budgetgroup_parentid")]
    public partial class budgetgroup
    {
        public budgetgroup()
        {
            budget = new HashSet<budget>();
        }

        [Key]
        public int idbudgetgroup { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idbudgetgroupNavigation")]
        public virtual ICollection<budget> budget { get; set; }
    }
}
