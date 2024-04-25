using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcar", Name = "idx_cartariff_idcar")]
    [Index("idtariff", Name = "idx_cartariff_idtariff")]
    public partial class cartariff
    {
        [Key]
        public int idcartariff { get; set; }
        public int? idcar { get; set; }
        public int? idtariff { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idcar")]
        [InverseProperty("cartariff")]
        public virtual car? idcarNavigation { get; set; }
        [ForeignKey("idtariff")]
        [InverseProperty("cartariff")]
        public virtual tariff? idtariffNavigation { get; set; }
    }
}
