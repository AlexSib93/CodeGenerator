using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class reportkit
    {
        public reportkit()
        {
            reportkitdetail = new HashSet<reportkitdetail>();
        }

        [Key]
        public int idreportkit { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idreportkitNavigation")]
        public virtual ICollection<reportkitdetail> reportkitdetail { get; set; }
    }
}
