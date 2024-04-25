using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__systemdetailrel__74C4FA03", IsUnique = true)]
    [Index("idsystemdetail", Name = "idx_systemdetailrel_idsystemdetail")]
    [Index("idsystemdetail2", Name = "idx_systemdetailrel_idsystemdetail2")]
    [Index("idversion", Name = "idx_systemdetailrel_idversion")]
    public partial class systemdetailrel
    {
        [Key]
        public int idsystemdetailrel { get; set; }
        public int? idsystemdetail { get; set; }
        public int? idsystemdetail2 { get; set; }
        public int? idversion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idsystemdetail2")]
        [InverseProperty("systemdetailrelidsystemdetail2Navigation")]
        public virtual systemdetail? idsystemdetail2Navigation { get; set; }
        [ForeignKey("idsystemdetail")]
        [InverseProperty("systemdetailrelidsystemdetailNavigation")]
        public virtual systemdetail? idsystemdetailNavigation { get; set; }
        [ForeignKey("idversion")]
        [InverseProperty("systemdetailrel")]
        public virtual versions? idversionNavigation { get; set; }
    }
}
