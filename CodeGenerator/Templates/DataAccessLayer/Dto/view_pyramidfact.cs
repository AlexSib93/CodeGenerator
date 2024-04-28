using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pyramidfact
    {
        public int idpyramidfact { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? qubag { get; set; }
        public int? idpeople { get; set; }
        public int? idpeople2 { get; set; }
        public int? iddestanation { get; set; }
        public int? idpyramid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtbegin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtend { get; set; }
        public int? idpeople3 { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio2 { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio3 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? pyramid_name { get; set; }
    }
}
