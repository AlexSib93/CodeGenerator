using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__glassdetail__07D7CE77", IsUnique = true)]
    [Index("idglass", Name = "idx_glassdetail_idglass")]
    [Index("idglasselement", Name = "idx_glassdetail_idglasselement")]
    [Index("idgood", Name = "idx_glassdetail_idgood")]
    public partial class glassdetail
    {
        [Key]
        public int idglassdetail { get; set; }
        public int? idglass { get; set; }
        public int? idgood { get; set; }
        public short? typ { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public int? idglasselement { get; set; }

        [ForeignKey("idglass")]
        [InverseProperty("glassdetail")]
        public virtual glass? idglassNavigation { get; set; }
        [ForeignKey("idglasselement")]
        [InverseProperty("glassdetail")]
        public virtual glasselement? idglasselementNavigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("glassdetail")]
        public virtual good? idgoodNavigation { get; set; }
    }
}
