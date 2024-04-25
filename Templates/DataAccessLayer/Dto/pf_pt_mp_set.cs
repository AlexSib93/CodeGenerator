using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmodelparamvalue", Name = "idx_pf_pt_mp_set_idmodelparamvalue")]
    [Index("idpf_pt", Name = "idx_pf_pt_mp_set_idpf_pt")]
    public partial class pf_pt_mp_set
    {
        [Key]
        public int idpf_pt_mp_set { get; set; }
        public int? idpf_pt { get; set; }
        public int? idmodelparamvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("pf_pt_mp_set")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idpf_pt")]
        [InverseProperty("pf_pt_mp_set")]
        public virtual pf_pt? idpf_ptNavigation { get; set; }
    }
}
