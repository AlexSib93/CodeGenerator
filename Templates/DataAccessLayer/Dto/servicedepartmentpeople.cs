using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_servicedepartmentpeople_idpeople")]
    [Index("idservicedepartment", Name = "idx_servicedepartmentpeople_idservicedepartment")]
    [Index("idservicedoc", Name = "idx_servicedepartmentpeople_idservicedoc")]
    public partial class servicedepartmentpeople
    {
        [Key]
        public int idservicedepartmentpeople { get; set; }
        public int? idservicedoc { get; set; }
        public int? idservicedepartment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpeople { get; set; }
        public short? perc { get; set; }
        public short? smbase { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("servicedepartmentpeople")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idservicedepartment")]
        [InverseProperty("servicedepartmentpeople")]
        public virtual servicedepartment? idservicedepartmentNavigation { get; set; }
        [ForeignKey("idservicedoc")]
        [InverseProperty("servicedepartmentpeople")]
        public virtual servicedoc? idservicedocNavigation { get; set; }
    }
}
