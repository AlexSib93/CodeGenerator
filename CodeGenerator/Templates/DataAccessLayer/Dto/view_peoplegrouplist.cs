using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_peoplegrouplist
    {
        public int idpeoplegrouplist { get; set; }
        public int? idpeople { get; set; }
        public int? idpeoplegroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? people_name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? people_lastname { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? people_middlename { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? people_passport { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? people_adress { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? people_phone { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? people_peoplegroup { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? people_comment { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? people_userpassword { get; set; }
        public short? people_isadmin { get; set; }
        public short? people_oneconnect { get; set; }
        public short? people_alienorder { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? people_userlogin { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? peoplegroup_name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? people_email { get; set; }
    }
}
