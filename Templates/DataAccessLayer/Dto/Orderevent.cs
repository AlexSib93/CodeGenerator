using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__orderevent__05EF8605", IsUnique = true)]
    [Index("idordereventgroup", Name = "idx_orderevent_idordereventgroup")]
    public partial class orderevent
    {
        [Key]
        public int idorderevent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public byte[]? dll { get; set; }
        [Column(TypeName = "text")]
        public string? codescript { get; set; }
        public int? numpos { get; set; }
        public short? compiled { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcompile { get; set; }
        public int? idordereventgroup { get; set; }
        public Guid guid { get; set; }
        public byte[]? pdb { get; set; }

        [ForeignKey("idordereventgroup")]
        [InverseProperty("orderevent")]
        public virtual ordereventgroup? idordereventgroupNavigation { get; set; }
    }
}
