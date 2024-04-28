using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class pollanswer
    {
        public pollanswer()
        {
            pollrelation = new HashSet<pollrelation>();
        }

        [Key]
        public int idpollanswer { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? answer { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weightanswer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idpollanswerNavigation")]
        public virtual ICollection<pollrelation> pollrelation { get; set; }
    }
}
