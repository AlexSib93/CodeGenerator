using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idaddress", Name = "idx_servicedoc_idaddress")]
    [Index("iddepartment", Name = "idx_servicedoc_iddepartment")]
    [Index("iddestanation", Name = "idx_servicedoc_iddestanation")]
    [Index("iddocstate", Name = "idx_servicedoc_iddocstate")]
    [Index("idorder", Name = "idx_servicedoc_idorder")]
    [Index("idorderdest", Name = "idx_servicedoc_idorderdest")]
    [Index("idservicedocgroup", Name = "idx_servicedoc_idservicedocgroup")]
    [Index("parentid", Name = "idx_servicedoc_parentid")]
    public partial class servicedoc
    {
        public servicedoc()
        {
            paymentdoc = new HashSet<paymentdoc>();
            respower = new HashSet<respower>();
            servicedepartment = new HashSet<servicedepartment>();
            servicedepartmentpeople = new HashSet<servicedepartmentpeople>();
            servicedocdiraction = new HashSet<servicedocdiraction>();
            servicedocpos = new HashSet<servicedocpos>();
            servicedocsign = new HashSet<servicedocsign>();
        }

        [Key]
        public int idservicedoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        public int? idpeople { get; set; }
        public int? idcustomer { get; set; }
        public int? iddocoper { get; set; }
        public int? idservicereason { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? contact { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? phone { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? address { get; set; }
        public int? idservicedocgroup { get; set; }
        public int? idorder { get; set; }
        /// <summary>
        /// Ссылка на адрес в справочнике адресов
        /// </summary>
        public int? idaddress { get; set; }
        /// <summary>
        /// Ссылка на заказ-результат
        /// </summary>
        public int? idorderdest { get; set; }
        /// <summary>
        /// Ссылка на виновное подразделение
        /// </summary>
        public int? iddepartment { get; set; }
        /// <summary>
        /// Документ-родитель
        /// </summary>
        public int? parentid { get; set; }
        public int? iddocstate { get; set; }
        public int? iddestanation { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }
        public int? addint4 { get; set; }
        public int? addint5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum5 { get; set; }
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [Unicode(false)]
        public string? addstr5 { get; set; }
        [Unicode(false)]
        public string? resolution { get; set; }

        [ForeignKey("idaddress")]
        [InverseProperty("servicedoc")]
        public virtual address? idaddressNavigation { get; set; }
        [ForeignKey("iddepartment")]
        [InverseProperty("servicedoc")]
        public virtual department? iddepartmentNavigation { get; set; }
        [ForeignKey("iddestanation")]
        [InverseProperty("servicedoc")]
        public virtual destanation? iddestanationNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("servicedoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("servicedocidorderNavigation")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderdest")]
        [InverseProperty("servicedocidorderdestNavigation")]
        public virtual orders? idorderdestNavigation { get; set; }
        [ForeignKey("idservicedocgroup")]
        [InverseProperty("servicedoc")]
        public virtual servicedocgroup? idservicedocgroupNavigation { get; set; }
        [InverseProperty("idservicedocNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
        [InverseProperty("idservicedocNavigation")]
        public virtual ICollection<respower> respower { get; set; }
        [InverseProperty("idservicedocNavigation")]
        public virtual ICollection<servicedepartment> servicedepartment { get; set; }
        [InverseProperty("idservicedocNavigation")]
        public virtual ICollection<servicedepartmentpeople> servicedepartmentpeople { get; set; }
        [InverseProperty("idservicedocNavigation")]
        public virtual ICollection<servicedocdiraction> servicedocdiraction { get; set; }
        [InverseProperty("idservicedocNavigation")]
        public virtual ICollection<servicedocpos> servicedocpos { get; set; }
        [InverseProperty("idservicedocNavigation")]
        public virtual ICollection<servicedocsign> servicedocsign { get; set; }
    }
}
