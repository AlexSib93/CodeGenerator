using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__docscriptgroup__39A43435", IsUnique = true)]
    [Index("parentid", Name = "idx_docscriptgroup_parentid")]
    public partial class docscriptgroup
    {
        public docscriptgroup()
        {
            docscript = new HashSet<docscript>();
        }

        [Key]
        public int iddocscriptgroup { get; set; }
        public int? parentid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public short? isactive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        /// <summary>
        /// Номер по порядку
        /// </summary>
        public int? numpos { get; set; }

        [InverseProperty("iddocscriptgroupNavigation")]
        public virtual ICollection<docscript> docscript { get; set; }
    }
}
