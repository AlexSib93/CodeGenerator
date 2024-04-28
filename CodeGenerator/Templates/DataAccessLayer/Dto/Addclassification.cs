using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idaddclassificationgroup", Name = "idx_addclassification_idaddclassificationgroup")]
    public partial class addclassification
    {
        public addclassification()
        {
            customeridaddclassification1Navigation = new HashSet<customer>();
            customeridaddclassification2Navigation = new HashSet<customer>();
            customeridaddclassification3Navigation = new HashSet<customer>();
            customeridaddclassification4Navigation = new HashSet<customer>();
            customeridaddclassification5Navigation = new HashSet<customer>();
            selleridaddclassification1Navigation = new HashSet<seller>();
            selleridaddclassification2Navigation = new HashSet<seller>();
            selleridaddclassification3Navigation = new HashSet<seller>();
            selleridaddclassification4Navigation = new HashSet<seller>();
            selleridaddclassification5Navigation = new HashSet<seller>();
        }

        [Key]
        public int idaddclassification { get; set; }
        public int? idaddclassificationgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numval { get; set; }
        public int? intval { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? strval { get; set; }

        [ForeignKey("idaddclassificationgroup")]
        [InverseProperty("addclassification")]
        public virtual addclassificationgroup? idaddclassificationgroupNavigation { get; set; }
        [InverseProperty("idaddclassification1Navigation")]
        public virtual ICollection<customer> customeridaddclassification1Navigation { get; set; }
        [InverseProperty("idaddclassification2Navigation")]
        public virtual ICollection<customer> customeridaddclassification2Navigation { get; set; }
        [InverseProperty("idaddclassification3Navigation")]
        public virtual ICollection<customer> customeridaddclassification3Navigation { get; set; }
        [InverseProperty("idaddclassification4Navigation")]
        public virtual ICollection<customer> customeridaddclassification4Navigation { get; set; }
        [InverseProperty("idaddclassification5Navigation")]
        public virtual ICollection<customer> customeridaddclassification5Navigation { get; set; }
        [InverseProperty("idaddclassification1Navigation")]
        public virtual ICollection<seller> selleridaddclassification1Navigation { get; set; }
        [InverseProperty("idaddclassification2Navigation")]
        public virtual ICollection<seller> selleridaddclassification2Navigation { get; set; }
        [InverseProperty("idaddclassification3Navigation")]
        public virtual ICollection<seller> selleridaddclassification3Navigation { get; set; }
        [InverseProperty("idaddclassification4Navigation")]
        public virtual ICollection<seller> selleridaddclassification4Navigation { get; set; }
        [InverseProperty("idaddclassification5Navigation")]
        public virtual ICollection<seller> selleridaddclassification5Navigation { get; set; }
    }
}
