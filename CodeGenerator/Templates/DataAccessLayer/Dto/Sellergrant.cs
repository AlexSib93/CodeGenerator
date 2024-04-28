using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class sellergrant
    {
        [Key]
        public int idsellergrant { get; set; }
        public int idpeoplegroup { get; set; }
        public int idseller { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool grant { get; set; }
        public Guid guid { get; set; }
    }
}
