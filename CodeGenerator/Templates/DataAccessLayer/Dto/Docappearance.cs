using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class docappearance
    {
        public docappearance()
        {
            docgroupgrant = new HashSet<docgroupgrant>();
            docscriptgrant = new HashSet<docscriptgrant>();
            docstate = new HashSet<docstate>();
        }

        [Key]
        public int iddocappearance { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? tablename { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("iddocappearanceNavigation")]
        public virtual ICollection<docgroupgrant> docgroupgrant { get; set; }
        [InverseProperty("iddocappearanceNavigation")]
        public virtual ICollection<docscriptgrant> docscriptgrant { get; set; }
        [InverseProperty("iddocappearanceNavigation")]
        public virtual ICollection<docstate> docstate { get; set; }
    }
}
