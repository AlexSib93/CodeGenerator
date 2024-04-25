using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class shtapikgroup
    {
        public shtapikgroup()
        {
            shtapikgroupdetail = new HashSet<shtapikgroupdetail>();
            shtapikgroupprofile = new HashSet<shtapikgroupprofile>();
        }

        [Key]
        public int idshtapikgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        public bool outside { get; set; }
        public bool inside { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? allowthickness { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idshtapikgroupNavigation")]
        public virtual ICollection<shtapikgroupdetail> shtapikgroupdetail { get; set; }
        [InverseProperty("idshtapikgroupNavigation")]
        public virtual ICollection<shtapikgroupprofile> shtapikgroupprofile { get; set; }
    }
}
