using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idconstructiontype", Name = "idx_pf_pt_ct_source_idconstructiontype")]
    [Index("idpf_pt", Name = "idx_pf_pt_ct_source_idpf_pt")]
    public partial class pf_pt_ct_source
    {
        [Key]
        public int idpf_pt_ct_source { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idpf_pt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idconstructiontype")]
        [InverseProperty("pf_pt_ct_source")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idpf_pt")]
        [InverseProperty("pf_pt_ct_source")]
        public virtual pf_pt? idpf_ptNavigation { get; set; }
    }
}
