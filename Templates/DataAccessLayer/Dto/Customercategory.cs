using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class customercategory
    {
        public customercategory()
        {
            customer = new HashSet<customer>();
        }

        [Key]
        public int idcustomercategory { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? value1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? value2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? value3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? value4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? value5 { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idcustomercategoryNavigation")]
        public virtual ICollection<customer> customer { get; set; }
    }
}
