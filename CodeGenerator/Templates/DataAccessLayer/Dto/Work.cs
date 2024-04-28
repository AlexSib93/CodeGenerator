using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_work_idpeople")]
    [Index("idworkgroup", Name = "idx_work_idworkgroup")]
    public partial class work
    {
        public work()
        {
            docwork = new HashSet<docwork>();
            workoper = new HashSet<workoper>();
            workpeople = new HashSet<workpeople>();
        }

        [Key]
        public int idwork { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? workgroup { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idworkgroup { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("work")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idworkgroup")]
        [InverseProperty("work")]
        public virtual workgroup? idworkgroupNavigation { get; set; }
        [InverseProperty("idworkNavigation")]
        public virtual ICollection<docwork> docwork { get; set; }
        [InverseProperty("idworkNavigation")]
        public virtual ICollection<workoper> workoper { get; set; }
        [InverseProperty("idworkNavigation")]
        public virtual ICollection<workpeople> workpeople { get; set; }
    }
}
