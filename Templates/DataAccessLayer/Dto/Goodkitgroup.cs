using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodkitgroup__0036ACAF", IsUnique = true)]
    [Index("parentid", Name = "idx_goodkitgroup_parentid")]
    public partial class goodkitgroup
    {
        public goodkitgroup()
        {
            goodkit = new HashSet<goodkit>();
        }

        [Key]
        public int idgoodkitgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Видимость группы для добавления
        /// </summary>
        public short? isvisible { get; set; }

        [InverseProperty("idgoodkitgroupNavigation")]
        public virtual ICollection<goodkit> goodkit { get; set; }
    }
}
