using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_poll
    {
        public int idpoll { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpollgroup { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? group { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? pollgroup_name { get; set; }
    }
}
