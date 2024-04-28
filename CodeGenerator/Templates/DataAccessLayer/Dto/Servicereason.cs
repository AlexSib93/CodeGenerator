using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_servicereason_idpeople")]
    public partial class servicereason
    {
        public servicereason()
        {
            servicedocpos = new HashSet<servicedocpos>();
        }

        [Key]
        public int idservicereason { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? numpos { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? reasoncode { get; set; }
        public int? idpeople { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? group { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("servicereason")]
        public virtual people? idpeopleNavigation { get; set; }
        [InverseProperty("idservicereasonNavigation")]
        public virtual ICollection<servicedocpos> servicedocpos { get; set; }
    }
}
