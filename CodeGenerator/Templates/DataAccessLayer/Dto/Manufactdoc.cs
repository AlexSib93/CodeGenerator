using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("dtcreate", Name = "idx_manufactdoc_dtcreate")]
    [Index("idcustomer", Name = "idx_manufactdoc_idcustomer")]
    [Index("iddocoper", Name = "idx_manufactdoc_iddocoper")]
    [Index("iddocstate", Name = "idx_manufactdoc_iddocstate")]
    [Index("idmanufactdocgroup", Name = "idx_manufactdoc_idmanufactdocgroup")]
    [Index("idpeople", Name = "idx_manufactdoc_idpeople")]
    public partial class manufactdoc
    {
        public manufactdoc()
        {
            equipmentdoc = new HashSet<equipmentdoc>();
            equipmentprofilein = new HashSet<equipmentprofilein>();
            equipmentprofileout = new HashSet<equipmentprofileout>();
            goodost = new HashSet<goodost>();
            manufactdiraction = new HashSet<manufactdiraction>();
            manufactdoccar = new HashSet<manufactdoccar>();
            manufactdocgoodin = new HashSet<manufactdocgoodin>();
            manufactdocnopyramid = new HashSet<manufactdocnopyramid>();
            manufactdocorder = new HashSet<manufactdocorder>();
            manufactdocpos = new HashSet<manufactdocpos>();
            manufactdocpyramid = new HashSet<manufactdocpyramid>();
            manufactdocpyramidpos = new HashSet<manufactdocpyramidpos>();
            manufactdocsign = new HashSet<manufactdocsign>();
        }

        [Key]
        public int idmanufactdoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idpeople { get; set; }
        public int? qupos { get; set; }
        public int? idmanufactdocgroup { get; set; }
        public int? iddocoper { get; set; }
        public int? flownum { get; set; }
        /// <summary>
        /// Ссылка на сотрудника, редактировавшего заказ
        /// </summary>
        public int? idpeopleedit { get; set; }
        /// <summary>
        /// Дата создания задания
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        /// <summary>
        /// Дата редактирования задания
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        /// <summary>
        /// Количество порций
        /// </summary>
        public int? qugroup { get; set; }
        public int? shiftnum { get; set; }
        public int? workshopnum { get; set; }
        public int? partnum { get; set; }
        public int? iddocstate { get; set; }
        [Column("class")]
        public byte[]? _class { get; set; }
        public int? idcustomer { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("manufactdoc")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("manufactdoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("manufactdoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idmanufactdocgroup")]
        [InverseProperty("manufactdoc")]
        public virtual manufactdocgroup? idmanufactdocgroupNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("manufactdoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<equipmentdoc> equipmentdoc { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<equipmentprofilein> equipmentprofilein { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<equipmentprofileout> equipmentprofileout { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<goodost> goodost { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<manufactdiraction> manufactdiraction { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<manufactdoccar> manufactdoccar { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<manufactdocgoodin> manufactdocgoodin { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<manufactdocnopyramid> manufactdocnopyramid { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<manufactdocorder> manufactdocorder { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<manufactdocpos> manufactdocpos { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<manufactdocpyramid> manufactdocpyramid { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<manufactdocpyramidpos> manufactdocpyramidpos { get; set; }
        [InverseProperty("idmanufactdocNavigation")]
        public virtual ICollection<manufactdocsign> manufactdocsign { get; set; }
    }
}
