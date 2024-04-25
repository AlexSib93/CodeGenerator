using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmailinglistsettings", Name = "idx_mailinglist_idmailinglistsettings")]
    [Index("idreport", Name = "idx_mailinglist_idreport")]
    [Index("name", Name = "idx_name")]
    public partial class mailinglist
    {
        public mailinglist()
        {
            mailinglistondemand = new HashSet<mailinglistondemand>();
            mailinglistusers = new HashSet<mailinglistusers>();
        }

        [Key]
        public int idmailinglist { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        public int type { get; set; }
        public int? idreport { get; set; }
        public int? filetype { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? title { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? filename { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? defaulttext { get; set; }
        public int? idmailinglistsettings { get; set; }
        public bool isactive { get; set; }
        public bool? monday { get; set; }
        public bool? tuesday { get; set; }
        public bool? wednesday { get; set; }
        public bool? thursday { get; set; }
        public bool? friday { get; set; }
        public bool? saturday { get; set; }
        public bool? sunday { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? timepoint1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? timepoint2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? timepoint3 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Unicode(false)]
        public string? query { get; set; }

        [ForeignKey("idmailinglistsettings")]
        [InverseProperty("mailinglist")]
        public virtual mailinglistsettings? idmailinglistsettingsNavigation { get; set; }
        [ForeignKey("idreport")]
        [InverseProperty("mailinglist")]
        public virtual report? idreportNavigation { get; set; }
        [InverseProperty("idmailinglistNavigation")]
        public virtual ICollection<mailinglistondemand> mailinglistondemand { get; set; }
        [InverseProperty("idmailinglistNavigation")]
        public virtual ICollection<mailinglistusers> mailinglistusers { get; set; }
    }
}
