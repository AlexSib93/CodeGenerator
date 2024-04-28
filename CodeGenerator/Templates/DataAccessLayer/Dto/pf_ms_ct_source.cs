using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idconstructiontype", Name = "idx_pf_ms_ct_source_idconstructiontype")]
    [Index("idpf_ms", Name = "idx_pf_ms_ct_source_idpf_ms")]
    public partial class pf_ms_ct_source
    {
        [Key]
        public int idpf_ms_ct_source { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idpf_ms { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idconstructiontype")]
        [InverseProperty("pf_ms_ct_source")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idpf_ms")]
        [InverseProperty("pf_ms_ct_source")]
        public virtual pf_ms? idpf_msNavigation { get; set; }
    }
}
