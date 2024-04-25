using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__setting__72DCB191", IsUnique = true)]
    [Index("idsettinggroup", Name = "idx_setting_idsettinggroup")]
    public partial class setting
    {
        public setting()
        {
            ordersetting = new HashSet<ordersetting>();
            productiontypesetting = new HashSet<productiontypesetting>();
        }

        [Key]
        public int idsetting { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? intvalue { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "text")]
        public string? txtvalue { get; set; }
        public byte[]? blbvalue { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? groupname { get; set; }
        public int? idsettinggroup { get; set; }
        public byte[]? namecrypt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        public Guid guid { get; set; }
        public bool? addorder { get; set; }
        public bool? addmodel { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? intvalue2 { get; set; }
        public byte[]? strvaluecrypt { get; set; }
        public byte[]? txtvaluecrypt { get; set; }
        public byte[]? commentcrypt { get; set; }
        public byte[]? customtable { get; set; }

        [ForeignKey("idsettinggroup")]
        [InverseProperty("setting")]
        public virtual settinggroup? idsettinggroupNavigation { get; set; }
        [InverseProperty("idsettingNavigation")]
        public virtual ICollection<ordersetting> ordersetting { get; set; }
        [InverseProperty("idsettingNavigation")]
        public virtual ICollection<productiontypesetting> productiontypesetting { get; set; }
    }
}
