using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class reg_order
    {
        public int idorder { get; set; }
        public int idgood { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_need { get; set; }
        public int? idproductionsite { get; set; }
        public int? idavailabilitygroup { get; set; }
        public int? deliverytime { get; set; }

        [ForeignKey("idavailabilitygroup")]
        public virtual availabilitygroup? idavailabilitygroupNavigation { get; set; }
        [ForeignKey("idcolor1")]
        public virtual color? idcolor1Navigation { get; set; }
        [ForeignKey("idcolor2")]
        public virtual color? idcolor2Navigation { get; set; }
        [ForeignKey("idgood")]
        public virtual good idgoodNavigation { get; set; } = null!;
        [ForeignKey("idorder")]
        public virtual orders idorderNavigation { get; set; } = null!;
        [ForeignKey("idproductionsite")]
        public virtual productionsite? idproductionsiteNavigation { get; set; }
    }
}
