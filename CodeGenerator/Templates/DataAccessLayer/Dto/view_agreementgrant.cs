using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_agreementgrant
    {
        public int idagreement { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtstart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtend { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idseller { get; set; }
        public int? idvalut { get; set; }
        public int? idagreementgrant { get; set; }
        public int idpeoplegroup { get; set; }
        public bool _grant { get; set; }
    }
}
