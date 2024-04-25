using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_orderdiractionpeople
    {
        public int idorderdiractionpeople { get; set; }
        public int? idorderdiraction { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idorder { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string people_fio { get; set; } = null!;
    }
}
