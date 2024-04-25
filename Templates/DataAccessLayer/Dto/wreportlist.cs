using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class wreportlist
    {
        [StringLength(50)]
        [Unicode(false)]
        public string? idreport { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? category { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? is_category { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? page_path { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? create_date { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? sort { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? is_lock { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? is_disabled { get; set; }
    }
}
