using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmeasure", Name = "idx_goodmeasure_idmeasure")]
    [Index("idgood", Name = "ix_goodmeasure_idgood")]
    public partial class goodmeasure
    {
        public goodmeasure()
        {
            storedocpos = new HashSet<storedocpos>();
            supplydocpos = new HashSet<supplydocpos>();
        }

        [Key]
        public int idgoodmeasure { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? k { get; set; }
        public int? idmeasure { get; set; }
        public int? idgood { get; set; }
        public bool def { get; set; }
        public bool def2 { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("goodmeasure")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idmeasure")]
        [InverseProperty("goodmeasure")]
        public virtual measure? idmeasureNavigation { get; set; }
        [InverseProperty("idgoodmeasureNavigation")]
        public virtual ICollection<storedocpos> storedocpos { get; set; }
        [InverseProperty("idgoodmeasureNavigation")]
        public virtual ICollection<supplydocpos> supplydocpos { get; set; }
    }
}
