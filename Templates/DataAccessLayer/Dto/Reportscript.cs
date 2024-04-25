using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class reportscript
    {
        public reportscript()
        {
            report = new HashSet<report>();
        }

        [Key]
        public int idreportscript { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? activescript { get; set; }
        [Column(TypeName = "text")]
        public string? codescript { get; set; }
        public short? compiled { get; set; }
        public byte[]? dll { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? scriptgroup { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcompile { get; set; }
        public Guid guid { get; set; }
        public byte[]? pdb { get; set; }

        [InverseProperty("idreportscriptNavigation")]
        public virtual ICollection<report> report { get; set; }
    }
}
