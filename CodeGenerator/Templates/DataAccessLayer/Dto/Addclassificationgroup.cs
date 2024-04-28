using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_addclassificationgroup_parentid")]
    public partial class addclassificationgroup
    {
        public addclassificationgroup()
        {
            addclassification = new HashSet<addclassification>();
        }

        [Key]
        public int idaddclassificationgroup { get; set; }
        public int? parentid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? isactive { get; set; }

        [InverseProperty("idaddclassificationgroupNavigation")]
        public virtual ICollection<addclassification> addclassification { get; set; }
    }
}
