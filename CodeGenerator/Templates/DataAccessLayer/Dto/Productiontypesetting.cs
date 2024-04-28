using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__productiontypese__4515E6E1", IsUnique = true)]
    [Index("idproductiontype", Name = "idx_productiontypesetting_idproductiontype")]
    [Index("idsetting", Name = "idx_productiontypesetting_idsetting")]
    public partial class productiontypesetting
    {
        [Key]
        public int idproductiontypesetting { get; set; }
        public int idproductiontype { get; set; }
        public int idsetting { get; set; }
        [Column(TypeName = "text")]
        public string? txtvalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? intvalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? intvalue2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idproductiontype")]
        [InverseProperty("productiontypesetting")]
        public virtual productiontype idproductiontypeNavigation { get; set; } = null!;
        [ForeignKey("idsetting")]
        [InverseProperty("productiontypesetting")]
        public virtual setting idsettingNavigation { get; set; } = null!;
    }
}
