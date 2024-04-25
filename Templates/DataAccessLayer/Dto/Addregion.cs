using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class addregion
    {
        public addregion()
        {
            addarea = new HashSet<addarea>();
        }

        [Key]
        public int idaddregion { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? kladrcode { get; set; }
        public int? postindex { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? shortname { get; set; }

        [InverseProperty("idaddregionNavigation")]
        public virtual ICollection<addarea> addarea { get; set; }
    }
}
