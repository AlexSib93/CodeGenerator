﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_delivdocdiraction
    {
        public int iddelivdocdiraction { get; set; }
        public int? iddelivdoc { get; set; }
        public int? iddiraction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeopleedit { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? diraction_name { get; set; }
        public int? diraction_numpos { get; set; }
        public int? diraction_duration { get; set; }
        public short? diraction_autosave { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
    }
}
