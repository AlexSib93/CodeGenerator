using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class commongroupgrant
    {
        [Key]
        public int idcommongroupgrant { get; set; }
        public int idcommongrouptype { get; set; }
        public int idcommongroup { get; set; }
        public int? idpeople { get; set; }
        public int? idpeoplegroup { get; set; }
        public bool allow { get; set; }
        public bool dany { get; set; }
        public Guid guid { get; set; }
    }
}
