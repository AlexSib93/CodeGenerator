using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idconstructiontype", Name = "idx_pf_stv_ct_source_idconstructiontype")]
    [Index("idpf_stv", Name = "idx_pf_stv_ct_source_idpf_stv")]
    public partial class pf_stv_ct_source
    {
        [Key]
        public int idpf_stv_ct_source { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idpf_stv { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idconstructiontype")]
        [InverseProperty("pf_stv_ct_source")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idpf_stv")]
        [InverseProperty("pf_stv_ct_source")]
        public virtual pf_stv? idpf_stvNavigation { get; set; }
    }
}
