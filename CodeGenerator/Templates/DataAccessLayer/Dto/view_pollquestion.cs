using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pollquestion
    {
        public int idpollquestion { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? question { get; set; }
        [Unicode(false)]
        public string? explanation { get; set; }
        public byte[]? picture { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? typeanswer { get; set; }
        [Unicode(false)]
        public string? query { get; set; }
        public bool? obligatory { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpoll { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? poll_name { get; set; }
    }
}
