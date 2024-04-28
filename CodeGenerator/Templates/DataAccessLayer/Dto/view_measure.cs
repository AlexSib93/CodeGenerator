using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_measure
    {
        public int idmeasure { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? factor { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? shortname { get; set; }
        public int? typ { get; set; }
        public Guid guid { get; set; }
        [StringLength(14)]
        [Unicode(false)]
        public string? measure_typ { get; set; }
    }
}
