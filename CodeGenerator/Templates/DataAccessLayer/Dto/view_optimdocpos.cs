using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_optimdocpos
    {
        public int idoptimdocpos { get; set; }
        public int? idoptimdoc { get; set; }
        public int? idgood { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        public int? numpos { get; set; }
        public int? numpos2 { get; set; }
        public int? idmodelcalc { get; set; }
        public int? idoptimdocpic { get; set; }
        public int? idorderitem { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idordergood { get; set; }
        public int? cart { get; set; }
        public int? cell { get; set; }
        public int? orderitemnum { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? profilemarking { get; set; }
        public int? idgoodoptim { get; set; }
        public int? idmanufactdocpos { get; set; }
        public short? numwhip { get; set; }
        public short? numpair { get; set; }
        public short? numposbalka { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public int? numpos3 { get; set; }
        public int? idorder { get; set; }
        public short? isready { get; set; }
        public int? row { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? good_waste { get; set; }
        public int? good_idgoodoptim { get; set; }
        public int? goodoptim_whiplen { get; set; }
        public int? goodoptim_worklen { get; set; }
        public int? goodoptim_worklen_width { get; set; }
        public int? goodoptim_worklen_height { get; set; }
        public int? goodoptim_step { get; set; }
        public int? goodoptim_freza { get; set; }
        public int? goodoptim_buffer { get; set; }
        public int? goodoptim_dl { get; set; }
        public int? goodoptim_dr { get; set; }
        public int? goodoptim_dt { get; set; }
        public int? goodoptim_db { get; set; }
        public int? goodoptim_drez { get; set; }
        public int? goodoptim_maxrez { get; set; }
        public short? goodoptim_typ { get; set; }
        public int? goodoptim_width { get; set; }
        public int? goodoptim_height { get; set; }
        public short? goodoptim_canrotate { get; set; }
        public int? goodoptim_typerez { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color1_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color2_name { get; set; }
        public int? optim_type { get; set; }
        public int? max_workrests { get; set; }
        public short? goodoptim_typeoptimend { get; set; }
        public short? goodoptim_dopuskoptim { get; set; }
        public int? goodoptim_ostmin { get; set; }
        public int? goodoptim_ostmax { get; set; }
        public int? goodoptim_minost { get; set; }
        public byte? goodoptim_quality { get; set; }
    }
}
