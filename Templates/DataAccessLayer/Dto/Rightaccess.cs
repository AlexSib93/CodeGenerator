using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    [Index("idpeoplegroup", Name = "idx_rightaccess_idpeoplegroup")]
    public partial class rightaccess
    {
        [StringLength(128)]
        [Unicode(false)]
        public string? formname { get; set; }
        [Column(TypeName = "xml")]
        public string? data { get; set; }
        public int? idpeoplegroup { get; set; }
    }
}
