using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idglass", Name = "idx_pf_glass_source_glass_idglass")]
    [Index("idpf_glass", Name = "idx_pf_glass_source_glass_idpf_glass")]
    public partial class pf_glass_source_glass
    {
        [Key]
        public int idpf_glass_source_glass { get; set; }
        public int? idglass { get; set; }
        public int? idpf_glass { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idglass")]
        [InverseProperty("pf_glass_source_glass")]
        public virtual glass? idglassNavigation { get; set; }
        [ForeignKey("idpf_glass")]
        [InverseProperty("pf_glass_source_glass")]
        public virtual pf_glass? idpf_glassNavigation { get; set; }
    }
}
