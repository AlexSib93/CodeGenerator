using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_commongroupgrant
    {
        public int idcommongroupgrant { get; set; }
        public int idcommongrouptype { get; set; }
        public int idcommongroup { get; set; }
        public int? idpeople { get; set; }
        public int? idpeoplegroup { get; set; }
        public bool allow { get; set; }
        public bool dany { get; set; }
        public Guid guid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string peoplegroup_name { get; set; } = null!;
        [StringLength(194)]
        [Unicode(false)]
        public string people_fio { get; set; } = null!;
    }
}
