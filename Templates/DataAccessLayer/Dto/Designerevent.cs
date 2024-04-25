using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__designerevent__0F78F03F", IsUnique = true)]
    public partial class designerevent
    {
        [Key]
        public int iddesignerevent { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public short? isactive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcompile { get; set; }
        public short? compiled { get; set; }
        [Column(TypeName = "text")]
        public string? codescript { get; set; }
        public byte[]? dll { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public Guid guid { get; set; }
        public byte[]? pdb { get; set; }
    }
}
