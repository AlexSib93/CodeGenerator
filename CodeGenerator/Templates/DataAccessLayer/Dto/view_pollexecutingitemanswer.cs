using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pollexecutingitemanswer
    {
        public int idpollexecutingitemanswer { get; set; }
        public int? idpollexecutingitem { get; set; }
        public int? idpollrelation { get; set; }
        public bool? checkedstate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? pollanswer_answer { get; set; }
        public int? idpoll { get; set; }
        public int? idpollexecuting { get; set; }
    }
}
