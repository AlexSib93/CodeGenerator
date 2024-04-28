using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idaddcityregion", Name = "idx_addstreet_idaddcityregion")]
    public partial class addstreet
    {
        public addstreet()
        {
            addbuild = new HashSet<addbuild>();
        }

        [Key]
        public int idaddstreet { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idaddcityregion { get; set; }
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

        [ForeignKey("idaddcityregion")]
        [InverseProperty("addstreet")]
        public virtual addcityregion? idaddcityregionNavigation { get; set; }
        [InverseProperty("idaddstreetNavigation")]
        public virtual ICollection<addbuild> addbuild { get; set; }
    }
}
