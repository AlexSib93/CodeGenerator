using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ_preference_guid", IsUnique = true)]
    public partial class preference
    {
        public preference()
        {
            destanation = new HashSet<destanation>();
        }

        [Key]
        public int idpreference { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? rowvariate { get; set; }
        public int? widthvariate { get; set; }
        public int? heightvariate { get; set; }
        public int? grouping { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? stack { get; set; }
        public bool? multigroup { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idpreferenceNavigation")]
        public virtual ICollection<destanation> destanation { get; set; }
    }
}
