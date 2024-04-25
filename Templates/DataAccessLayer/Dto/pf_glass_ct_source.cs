using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idconstructiontype", Name = "idx_pf_glass_ct_source_idconstructiontype")]
    [Index("idpf_glass", Name = "idx_pf_glass_ct_source_idpf_glass")]
    public partial class pf_glass_ct_source
    {
        [Key]
        public int idpf_glass_ct_source { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idpf_glass { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idconstructiontype")]
        [InverseProperty("pf_glass_ct_source")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idpf_glass")]
        [InverseProperty("pf_glass_ct_source")]
        public virtual pf_glass? idpf_glassNavigation { get; set; }
    }
}
