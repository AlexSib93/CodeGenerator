using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmodel", Name = "idx_modelparamcalc_idmodel")]
    [Index("idmodelparam", Name = "idx_modelparamcalc_idmodelparam")]
    [Index("idmodelparamvalue", Name = "idx_modelparamcalc_idmodelparamvalue")]
    [Index("idmodelparamvalue2", Name = "idx_modelparamcalc_idmodelparamvalue2")]
    [Index("idmodelpart", Name = "idx_modelparamcalc_idmodelpart")]
    [Index("idorder", Name = "idx_modelparamcalc_idorder")]
    [Index("idorderitem", Name = "idx_modelparamcalc_idorderitem")]
    public partial class modelparamcalc
    {
        [Key]
        public int idmodelparamcalc { get; set; }
        public int? idmodelparam { get; set; }
        public int? idmodelpart { get; set; }
        public int? idmodel { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue2 { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue2 { get; set; }
        public bool? visible { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idmodelparamvalue2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        public int? id { get; set; }

        [ForeignKey("idmodel")]
        [InverseProperty("modelparamcalc")]
        public virtual model? idmodelNavigation { get; set; }
        [ForeignKey("idmodelparam")]
        [InverseProperty("modelparamcalc")]
        public virtual modelparam? idmodelparamNavigation { get; set; }
        [ForeignKey("idmodelparamvalue2")]
        [InverseProperty("modelparamcalcidmodelparamvalue2Navigation")]
        public virtual modelparamvalue? idmodelparamvalue2Navigation { get; set; }
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("modelparamcalcidmodelparamvalueNavigation")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idmodelpart")]
        [InverseProperty("modelparamcalc")]
        public virtual modelpart? idmodelpartNavigation { get; set; }
    }
}
