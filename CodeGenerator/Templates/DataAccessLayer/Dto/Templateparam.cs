using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmodelparam", Name = "idx_templateparam_idmodelparam")]
    [Index("idmodelpart", Name = "idx_templateparam_idmodelpart")]
    [Index("idtemplate", Name = "idx_templateparam_idtemplate")]
    public partial class templateparam
    {
        [Key]
        public int idtemplateparam { get; set; }
        public int? idmodelparam { get; set; }
        public int? idmodelpart { get; set; }
        public int? idtemplate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idmodelparam")]
        [InverseProperty("templateparam")]
        public virtual modelparam? idmodelparamNavigation { get; set; }
        [ForeignKey("idmodelpart")]
        [InverseProperty("templateparam")]
        public virtual modelpart? idmodelpartNavigation { get; set; }
        [ForeignKey("idtemplate")]
        [InverseProperty("templateparam")]
        public virtual template? idtemplateNavigation { get; set; }
    }
}
