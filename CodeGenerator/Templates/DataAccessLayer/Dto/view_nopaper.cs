﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_nopaper
    {
        public int idnopaper { get; set; }
        public int? idorderitem { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? typ { get; set; }
        public short? ship { get; set; }
        public short? defect { get; set; }
        public short? nodefect { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? qu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtship { get; set; }
        public int? quship { get; set; }
        public int? idpeople1 { get; set; }
        public int? idpeople2 { get; set; }
        public int? idpeople3 { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people1_fio { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people2_fio { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people3_fio { get; set; }
    }
}