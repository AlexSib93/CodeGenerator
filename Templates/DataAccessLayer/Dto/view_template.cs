using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_template
    {
        public int idtemplate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idtemplategroup { get; set; }
        public byte[]? classnative { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? typ { get; set; }
        public byte[]? picture { get; set; }
        public int? idproductiontype { get; set; }
        public int? idprofilesystem { get; set; }
        public int? idfurnituresystem { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontype_name { get; set; }
        public int? productiontype_typ { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? profilesystem_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? furnituresystem_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color1_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color2_name { get; set; }
        public int? templatetype { get; set; }
        public int? idparent { get; set; }
    }
}
