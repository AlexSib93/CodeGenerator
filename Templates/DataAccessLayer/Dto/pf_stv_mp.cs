using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmodelparamvalue", Name = "idx_pf_stv_mp_idmodelparamvalue")]
    [Index("idpf_stv", Name = "idx_pf_stv_mp_idpf_stv")]
    public partial class pf_stv_mp
    {
        [Key]
        public int idpf_stv_mp { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idpf_stv { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("pf_stv_mp")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idpf_stv")]
        [InverseProperty("pf_stv_mp")]
        public virtual pf_stv? idpf_stvNavigation { get; set; }
    }
}
