using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_departmentmember
    {
        public int iddepartmentmember { get; set; }
        public int? iddepartment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? department_name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? department_comment { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? department_addstr { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? department_addint { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string people_fio { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? people_name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? people_middlename { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? people_lastname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? people_postname { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? people_tabno { get; set; }
    }
}
