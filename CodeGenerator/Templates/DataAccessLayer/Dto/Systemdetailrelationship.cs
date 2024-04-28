using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idsystemdetail1", "idsystemdetail2", "deleted", Name = "U_systemdetailrelationship_relationship", IsUnique = true)]
    public partial class systemdetailrelationship
    {
        [Key]
        public int idsystemdetailrelationship { get; set; }
        public int idsystemdetail1 { get; set; }
        public int idsystemdetail2 { get; set; }
        public int? indent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idsystemdetail1")]
        [InverseProperty("systemdetailrelationshipidsystemdetail1Navigation")]
        public virtual systemdetail idsystemdetail1Navigation { get; set; } = null!;
        [ForeignKey("idsystemdetail2")]
        [InverseProperty("systemdetailrelationshipidsystemdetail2Navigation")]
        public virtual systemdetail idsystemdetail2Navigation { get; set; } = null!;
    }
}
