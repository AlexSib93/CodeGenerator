using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class customertyperel
    {
        public customertyperel()
        {
            customerrel = new HashSet<customerrel>();
        }

        [Key]
        public int idcustomertyperel { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public byte[]? picture { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idcustomertyperelNavigation")]
        public virtual ICollection<customerrel> customerrel { get; set; }
    }
}
