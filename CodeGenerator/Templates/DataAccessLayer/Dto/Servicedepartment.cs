using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddepartment", Name = "idx_servicedepartment_iddepartment")]
    [Index("idservicedoc", Name = "idx_servicedepartment_idservicedoc")]
    public partial class servicedepartment
    {
        public servicedepartment()
        {
            servicedepartmentpeople = new HashSet<servicedepartmentpeople>();
        }

        [Key]
        public int idservicedepartment { get; set; }
        public int idservicedoc { get; set; }
        public int? iddepartment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 3)")]
        public decimal? perc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 3)")]
        public decimal? smbase { get; set; }

        [ForeignKey("iddepartment")]
        [InverseProperty("servicedepartment")]
        public virtual department? iddepartmentNavigation { get; set; }
        [ForeignKey("idservicedoc")]
        [InverseProperty("servicedepartment")]
        public virtual servicedoc idservicedocNavigation { get; set; } = null!;
        [InverseProperty("idservicedepartmentNavigation")]
        public virtual ICollection<servicedepartmentpeople> servicedepartmentpeople { get; set; }
    }
}
