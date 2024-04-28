using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Состав подразделений
    /// </summary>
    [Index("iddepartment", Name = "idx_departmentmember_iddepartment")]
    [Index("idpeople", Name = "idx_departmentmember_idpeople")]
    public partial class departmentmember
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iddepartmentmember { get; set; }
        /// <summary>
        /// Ссылка на подразделение
        /// </summary>
        public int? iddepartment { get; set; }
        /// <summary>
        /// Ссылка на сотрудника
        /// </summary>
        public int? idpeople { get; set; }
        /// <summary>
        /// Дата удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("iddepartment")]
        [InverseProperty("departmentmember")]
        public virtual department? iddepartmentNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("departmentmember")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
