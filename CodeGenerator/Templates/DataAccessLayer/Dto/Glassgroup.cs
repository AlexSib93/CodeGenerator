using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__glassgroup__04073D93", IsUnique = true)]
    [Index("parentid", Name = "idx_glassgroup_parentid")]
    public partial class glassgroup
    {
        public glassgroup()
        {
            glass = new HashSet<glass>();
        }

        [Key]
        public int idglassgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? parentid { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idglassgroupNavigation")]
        public virtual ICollection<glass> glass { get; set; }
    }
}
