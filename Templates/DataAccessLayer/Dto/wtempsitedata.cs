using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class wtempsitedata
    {
        [Unicode(false)]
        public string? uid { get; set; }
        [Unicode(false)]
        public string? data { get; set; }
    }
}
