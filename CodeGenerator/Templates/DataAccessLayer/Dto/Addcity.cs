using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idaddarea", Name = "idx_addcity_idaddarea")]
    public partial class addcity
    {
        public addcity()
        {
            addcityregion = new HashSet<addcityregion>();
        }

        [Key]
        public int idaddcity { get; set; }
        public int? idaddarea { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Сокращённое наименование
        /// </summary>
        [StringLength(128)]
        [Unicode(false)]
        public string? shortname { get; set; }
        public Guid guid { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? kladrcode { get; set; }
        public int? postindex { get; set; }

        [ForeignKey("idaddarea")]
        [InverseProperty("addcity")]
        public virtual addarea? idaddareaNavigation { get; set; }
        [InverseProperty("idaddcityNavigation")]
        public virtual ICollection<addcityregion> addcityregion { get; set; }
    }
}
