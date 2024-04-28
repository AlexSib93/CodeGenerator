using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_view_need_good
    {
        public int? idorder { get; set; }
        public int? idgood { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? qustore { get; set; }
        [Unicode(false)]
        public string? source { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_need { get; set; }
        [Unicode(false)]
        public string? doc_name { get; set; }
        public int? idpower { get; set; }
        public int? idproductionsite { get; set; }
        public int? idavailabilitygroup { get; set; }
        public int? deliverytime { get; set; }
    }
}
