using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmodelparamcondition", Name = "idx_modelparamconditiondetail_idmodelparamcondition")]
    [Index("idmodelparamconditiondetail", Name = "idx_modelparamconditiondetail_idmodelparamconditiondetail")]
    [Index("idmodelparamvalue", Name = "idx_modelparamconditiondetail_idmodelparamvalue")]
    public partial class modelparamconditiondetail
    {
        [Key]
        public int idmodelparamconditiondetail { get; set; }
        public int? idmodelparamcondition { get; set; }
        public int? idmodelparamvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idmodelparamcondition")]
        [InverseProperty("modelparamconditiondetail")]
        public virtual modelparamcondition? idmodelparamconditionNavigation { get; set; }
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("modelparamconditiondetail")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
    }
}
