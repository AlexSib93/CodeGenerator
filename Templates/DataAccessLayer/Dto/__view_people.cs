using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class __view_people
    {
        public int? idpeople { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string people_fio { get; set; } = null!;
    }
}
