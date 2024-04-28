using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class wreportaccess
    {
        public int? idreport { get; set; }
        public int? idpeoplegroup { get; set; }
        public int? idpeople { get; set; }
        public int idreportaccess { get; set; }
    }
}
