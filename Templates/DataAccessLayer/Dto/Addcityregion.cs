using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idaddcity", Name = "idx_addcityregion_idaddcity")]
    public partial class addcityregion
    {
        public addcityregion()
        {
            addbuild = new HashSet<addbuild>();
            addstreet = new HashSet<addstreet>();
        }

        [Key]
        public int idaddcityregion { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idaddcity { get; set; }
        public Guid guid { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? kladrcode { get; set; }
        public int? postindex { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? shortname { get; set; }

        [ForeignKey("idaddcity")]
        [InverseProperty("addcityregion")]
        public virtual addcity? idaddcityNavigation { get; set; }
        [InverseProperty("idaddcityregionNavigation")]
        public virtual ICollection<addbuild> addbuild { get; set; }
        [InverseProperty("idaddcityregionNavigation")]
        public virtual ICollection<addstreet> addstreet { get; set; }
    }
}
