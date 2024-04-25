using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__measure__301AC9FB", IsUnique = true)]
    public partial class measure
    {
        public measure()
        {
            good = new HashSet<good>();
            goodmeasure = new HashSet<goodmeasure>();
            productiontype = new HashSet<productiontype>();
        }

        [Key]
        public int idmeasure { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? factor { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? shortname { get; set; }
        public int? typ { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idmeasureNavigation")]
        public virtual ICollection<good> good { get; set; }
        [InverseProperty("idmeasureNavigation")]
        public virtual ICollection<goodmeasure> goodmeasure { get; set; }
        [InverseProperty("idmeasureNavigation")]
        public virtual ICollection<productiontype> productiontype { get; set; }
    }
}
