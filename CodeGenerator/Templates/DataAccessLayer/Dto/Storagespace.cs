using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idstoredepart", Name = "idx_storagespace_idstoredepart")]
    public partial class storagespace
    {
        public storagespace()
        {
            good = new HashSet<good>();
            goodcolorparam = new HashSet<goodcolorparam>();
            rotoxhouseidstoragespace2Navigation = new HashSet<rotoxhouse>();
            rotoxhouseidstoragespaceNavigation = new HashSet<rotoxhouse>();
            storedocpos = new HashSet<storedocpos>();
        }

        [Key]
        public int idstoragespace { get; set; }
        public int idstoredepart { get; set; }
        public int? idparent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? row { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? cell { get; set; }
        public int? min_width { get; set; }
        public int? min_height { get; set; }
        public int? max_width { get; set; }
        public int? max_height { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? barcode { get; set; }

        [ForeignKey("idstoredepart")]
        [InverseProperty("storagespace")]
        public virtual storedepart idstoredepartNavigation { get; set; } = null!;
        [ForeignKey("idparent")]
        public virtual storagespace idparentNavigation { get; set; } = null!;
        [InverseProperty("idstoragespaceNavigation")]
        public virtual ICollection<good> good { get; set; }
        [InverseProperty("idstoragespaceNavigation")]
        public virtual ICollection<goodcolorparam> goodcolorparam { get; set; }
        [InverseProperty("idstoragespace2Navigation")]
        public virtual ICollection<rotoxhouse> rotoxhouseidstoragespace2Navigation { get; set; }
        [InverseProperty("idstoragespaceNavigation")]
        public virtual ICollection<rotoxhouse> rotoxhouseidstoragespaceNavigation { get; set; }
        [InverseProperty("idstoragespaceNavigation")]
        public virtual ICollection<storedocpos> storedocpos { get; set; }
    }
}
