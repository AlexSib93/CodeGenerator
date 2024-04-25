using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class customerform
    {
        public customerform()
        {
            customer = new HashSet<customer>();
        }

        [Key]
        public int idcustomerform { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? shortname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idcustomerformNavigation")]
        public virtual ICollection<customer> customer { get; set; }
    }
}
