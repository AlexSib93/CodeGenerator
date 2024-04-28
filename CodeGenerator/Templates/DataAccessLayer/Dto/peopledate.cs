using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddepartment", Name = "idx_peopledate_iddepartment")]
    [Index("idpeople", Name = "idx_peopledate_idpeople")]
    public partial class peopledate
    {
        public peopledate()
        {
            peopledatetime = new HashSet<peopledatetime>();
        }

        [Key]
        public int idpeopledate { get; set; }
        public int iddepartment { get; set; }
        public int idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime date { get; set; }
        [Column(TypeName = "numeric(5, 1)")]
        public decimal? ktu { get; set; }

        [ForeignKey("iddepartment")]
        [InverseProperty("peopledate")]
        public virtual department iddepartmentNavigation { get; set; } = null!;
        [ForeignKey("idpeople")]
        [InverseProperty("peopledate")]
        public virtual people idpeopleNavigation { get; set; } = null!;
        [InverseProperty("idpeopledateNavigation")]
        public virtual ICollection<peopledatetime> peopledatetime { get; set; }
    }
}
