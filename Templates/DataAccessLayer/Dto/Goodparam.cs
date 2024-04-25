using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodparam__1531C995", IsUnique = true)]
    [Index("idgood", Name = "idx_goodparam_idgood")]
    [Index("idparam", Name = "idx_goodparam_idparam")]
    public partial class goodparam
    {
        [Key]
        public int idgoodparam { get; set; }
        public int? idgood { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? paramgroup { get; set; }
        public int? idparam { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public int? idgoodparamname { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("goodparam")]
        public virtual good? idgoodNavigation { get; set; }
    }
}
