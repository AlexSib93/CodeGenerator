using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_productiontypeconstruction
    {
        public int? idproductiontypeconstruction { get; set; }
        public int? idproductiontype { get; set; }
        public int? idconstructiontype { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontype_name { get; set; }
        public int productiontype_idproductiontype { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? constructiontype_name { get; set; }
        public int constructiontype_idconstructiontype { get; set; }
        public int system_type { get; set; }
        public int? system_numpos { get; set; }
        public int _active { get; set; }
    }
}
