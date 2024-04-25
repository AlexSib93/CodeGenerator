using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__modelscript__33EB5ADF", IsUnique = true)]
    [Index("idmodelpart", Name = "idx_modelscript_idmodelpart")]
    [Index("idversion", Name = "idx_modelscript_idversion")]
    public partial class modelscript
    {
        [Key]
        public int idmodelscript { get; set; }
        public int? idmodelpart { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "text")]
        public string? comment { get; set; }
        public byte[]? dll { get; set; }
        public short? compiled { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? scriptgroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcompile { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "text")]
        public string? codescript { get; set; }
        public short? activescript { get; set; }
        public int? idversion { get; set; }
        public Guid guid { get; set; }
        public byte[]? pdb { get; set; }

        [ForeignKey("idmodelpart")]
        [InverseProperty("modelscript")]
        public virtual modelpart? idmodelpartNavigation { get; set; }
        [ForeignKey("idversion")]
        [InverseProperty("modelscript")]
        public virtual versions? idversionNavigation { get; set; }
    }
}
