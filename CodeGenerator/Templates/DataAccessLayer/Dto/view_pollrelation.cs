using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pollrelation
    {
        public int idpollrelation { get; set; }
        public int? idpollquestion { get; set; }
        public int? idpollanswer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? parentid { get; set; }
        public int? numpos { get; set; }
        public int? idpoll { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? pollquestion_question { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? pollanswer_answer { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
    }
}
