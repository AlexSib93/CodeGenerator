using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pollexecutingitem
    {
        public int idpollexecutingitem { get; set; }
        public int? idpollexecuting { get; set; }
        public int? idpollrelation { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        public bool? checkvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? pollquestion_question { get; set; }
        [Unicode(false)]
        public string? pollquestion_explanation { get; set; }
        public int? idpoll { get; set; }
        public bool? pollquestion_obligatory { get; set; }
        public byte[]? pollquestion_picture { get; set; }
        [Unicode(false)]
        public string? pollquestion_query { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? pollquestion_typeanswer { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? pollexecuting_name { get; set; }
        public int? pollrelation_numpos { get; set; }
        public bool? show_row { get; set; }
        [Unicode(false)]
        public string? sum_answer { get; set; }
    }
}
