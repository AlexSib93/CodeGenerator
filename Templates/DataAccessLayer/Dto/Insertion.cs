using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idglasselement", Name = "idx_insertion_idglasselement")]
    [Index("idsystemdetail", Name = "idx_insertion_idsystemdetail")]
    public partial class insertion
    {
        public insertion()
        {
            insertiondetail = new HashSet<insertiondetail>();
            insertionparam = new HashSet<insertionparam>();
            shtapikgroupprofile = new HashSet<shtapikgroupprofile>();
        }

        [Key]
        public int idinsertion { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idsystemdetail { get; set; }
        public bool def { get; set; }
        public bool sure { get; set; }
        [StringLength(10)]
        public string? id { get; set; }
        public int? idglasselement { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }

        [ForeignKey("idglasselement")]
        [InverseProperty("insertion")]
        public virtual glasselement? idglasselementNavigation { get; set; }
        [ForeignKey("idsystemdetail")]
        [InverseProperty("insertion")]
        public virtual systemdetail? idsystemdetailNavigation { get; set; }
        [InverseProperty("idinsertionNavigation")]
        public virtual ICollection<insertiondetail> insertiondetail { get; set; }
        [InverseProperty("idinsertionNavigation")]
        public virtual ICollection<insertionparam> insertionparam { get; set; }
        [InverseProperty("idinsertionNavigation")]
        public virtual ICollection<shtapikgroupprofile> shtapikgroupprofile { get; set; }
    }
}
