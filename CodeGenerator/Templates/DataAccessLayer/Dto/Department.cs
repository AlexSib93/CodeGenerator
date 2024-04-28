using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Таблица отделов
    /// </summary>
    [Index("parentid", Name = "idx_department_parentid")]
    public partial class department
    {
        public department()
        {
            departmentmember = new HashSet<departmentmember>();
            messages = new HashSet<messages>();
            orders = new HashSet<orders>();
            peopledate = new HashSet<peopledate>();
            servicedepartment = new HashSet<servicedepartment>();
            servicedoc = new HashSet<servicedoc>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iddepartment { get; set; }
        /// <summary>
        /// Нименование отдела
        /// </summary>
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Дополнительная строка
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? addstr { get; set; }
        /// <summary>
        /// Дополнительное число
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addint { get; set; }
        /// <summary>
        /// Дата удаления записи
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? parentid { get; set; }
        public int? numpos { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addint2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addint3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addint4 { get; set; }

        [InverseProperty("iddepartmentNavigation")]
        public virtual ICollection<departmentmember> departmentmember { get; set; }
        [InverseProperty("iddepartmentNavigation")]
        public virtual ICollection<messages> messages { get; set; }
        [InverseProperty("iddepartmentNavigation")]
        public virtual ICollection<orders> orders { get; set; }
        [InverseProperty("iddepartmentNavigation")]
        public virtual ICollection<peopledate> peopledate { get; set; }
        [InverseProperty("iddepartmentNavigation")]
        public virtual ICollection<servicedepartment> servicedepartment { get; set; }
        [InverseProperty("iddepartmentNavigation")]
        public virtual ICollection<servicedoc> servicedoc { get; set; }
    }
}
