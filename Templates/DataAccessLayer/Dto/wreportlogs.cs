using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class wreportlogs
    {
        [Key]
        public int idlog { get; set; }
        public int idpeople { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string user_name { get; set; } = null!;
        [StringLength(500)]
        [Unicode(false)]
        public string action { get; set; } = null!;
        [StringLength(500)]
        [Unicode(false)]
        public string ip { get; set; } = null!;
        [StringLength(500)]
        [Unicode(false)]
        public string page { get; set; } = null!;
        [StringLength(500)]
        [Unicode(false)]
        public string http_user_agent { get; set; } = null!;
        [StringLength(500)]
        [Unicode(false)]
        public string login { get; set; } = null!;
        [StringLength(500)]
        [Unicode(false)]
        public string pass { get; set; } = null!;
        public int remember { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? date { get; set; }
        public int? online_time { get; set; }
    }
}
