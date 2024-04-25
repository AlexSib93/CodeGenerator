using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_productiontypegrant
    {
        public int idproductiontype { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontypegroup { get; set; }
        public byte[]? picture { get; set; }
        public Guid guid { get; set; }
        public int? idproductiontypegroup { get; set; }
        public int? typ { get; set; }
        public int? idconstructiontype { get; set; }
        public bool isactive { get; set; }
        public int? idmeasure { get; set; }
        public int? idpower { get; set; }
        public int? idcolorgroupcustom { get; set; }
        public bool? onlytemplate { get; set; }
        public int? idpricechange { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name_strkey { get; set; }
        public int? idproductiontypegrant { get; set; }
        public int idpeoplegroup { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontypegroup_name { get; set; }
        public bool _grant { get; set; }
    }
}
