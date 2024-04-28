using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class temp_STREET
    {
        [StringLength(40)]
        [Unicode(false)]
        public string? NAME { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? SOCR { get; set; }
        [StringLength(17)]
        [Unicode(false)]
        public string? CODE { get; set; }
        [StringLength(6)]
        [Unicode(false)]
        public string? INDEX { get; set; }
        [StringLength(4)]
        [Unicode(false)]
        public string? GNINMB { get; set; }
        [StringLength(4)]
        [Unicode(false)]
        public string? UNO { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string? OCATD { get; set; }
    }
}
