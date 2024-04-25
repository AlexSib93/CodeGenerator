using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("name", Name = "idx_name")]
    public partial class mailinglistsettings
    {
        public mailinglistsettings()
        {
            mailinglist = new HashSet<mailinglist>();
        }

        [Key]
        public int idmailinglistsettings { get; set; }
        public int type { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        public int? gatetype { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? address { get; set; }
        public int? port { get; set; }
        public bool usessl { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string login { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string password { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string? emailfrom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idmailinglistsettingsNavigation")]
        public virtual ICollection<mailinglist> mailinglist { get; set; }
    }
}
