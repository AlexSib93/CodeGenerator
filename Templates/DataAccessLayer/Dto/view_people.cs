using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_people
    {
        public int idpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? lastname { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? middlename { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? passport { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? address { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? phone { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? peoplegroup { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? userpassword { get; set; }
        public short? isadmin { get; set; }
        public short? oneconnect { get; set; }
        public short? alienorder { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? userlogin { get; set; }
        public int? idpeoplepost { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addinfo { get; set; }
        public int? iddepartment { get; set; }
        public bool? indealerbase { get; set; }
        public Guid guid { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string fio { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? peoplegroup_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? peoplepost_name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? email { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public bool? iscrypt { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? tabno { get; set; }
        public bool? ad_authorization { get; set; }
    }
}
