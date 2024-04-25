using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idaddregion", Name = "idx_addarea_idaddregion")]
    public partial class addarea
    {
        public addarea()
        {
            addcity = new HashSet<addcity>();
        }

        [Key]
        public int idaddarea { get; set; }
        public int? idaddregion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        public Guid guid { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? kladrcode { get; set; }
        public int? postindex { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? shortname { get; set; }

        [ForeignKey("idaddregion")]
        [InverseProperty("addarea")]
        public virtual addregion? idaddregionNavigation { get; set; }
        [InverseProperty("idaddareaNavigation")]
        public virtual ICollection<addcity> addcity { get; set; }
    }
}
