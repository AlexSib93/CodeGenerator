using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmodelparamvalue", Name = "idx_pf_ms_mp_filtr_idmodelparamvalue")]
    [Index("idpf_ms", Name = "idx_pf_ms_mp_filtr_idpf_ms")]
    public partial class pf_ms_mp_filtr
    {
        [Key]
        public int idpf_ms_mp_filtr { get; set; }
        public int? idpf_ms { get; set; }
        public int? idmodelparamvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Required]
        public bool? isvalue1 { get; set; }

        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("pf_ms_mp_filtr")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idpf_ms")]
        [InverseProperty("pf_ms_mp_filtr")]
        public virtual pf_ms? idpf_msNavigation { get; set; }
    }
}
