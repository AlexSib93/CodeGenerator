using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__sizedoc__7C661BCB", IsUnique = true)]
    [Index("idaddress", Name = "idx_sizedoc_idaddress")]
    [Index("idcustomer", Name = "idx_sizedoc_idcustomer")]
    [Index("iddestanation", Name = "idx_sizedoc_iddestanation")]
    [Index("iddocoper", Name = "idx_sizedoc_iddocoper")]
    [Index("iddocstate", Name = "idx_sizedoc_iddocstate")]
    [Index("idorder", Name = "idx_sizedoc_idorder")]
    [Index("idpeople", Name = "idx_sizedoc_idpeople")]
    [Index("idpeople2", Name = "idx_sizedoc_idpeople2")]
    [Index("idsizedocgroup", Name = "idx_sizedoc_idsizedocgroup")]
    public partial class sizedoc
    {
        public sizedoc()
        {
            sizedocconstrtype = new HashSet<sizedocconstrtype>();
            sizedocdiraction = new HashSet<sizedocdiraction>();
            sizedocfile = new HashSet<sizedocfile>();
        }

        [Key]
        public int idsizedoc { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idpeople { get; set; }
        public int? idcustomer { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? iddocoper { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        public int? qupos { get; set; }
        public int? idpeople2 { get; set; }
        public short? isordered { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? iddestanation { get; set; }
        public int? idorder { get; set; }
        public int? idsizedocgroup { get; set; }
        public short? isplaned { get; set; }
        public short? isover { get; set; }
        public short? isredirect { get; set; }
        /// <summary>
        /// Ссылка на адрес
        /// </summary>
        public int? idaddress { get; set; }
        /// <summary>
        /// Текстовый адрес
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? address { get; set; }
        public Guid guid { get; set; }
        /// <summary>
        /// Контактное лицо(например хомяк)
        /// </summary>
        [Unicode(false)]
        public string? contact { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        [Unicode(false)]
        public string? phone { get; set; }
        /// <summary>
        /// Домофон
        /// </summary>
        [Unicode(false)]
        public string? speackerphone { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        /// <summary>
        /// Дата изменения
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        /// <summary>
        /// Демиург
        /// </summary>
        public int? idpeoplecreate { get; set; }
        /// <summary>
        /// Искуситель
        /// </summary>
        public int? idpeopleedit { get; set; }
        public int? iddocstate { get; set; }

        [ForeignKey("idaddress")]
        [InverseProperty("sizedoc")]
        public virtual address? idaddressNavigation { get; set; }
        [ForeignKey("idcustomer")]
        [InverseProperty("sizedoc")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddestanation")]
        [InverseProperty("sizedoc")]
        public virtual destanation? iddestanationNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("sizedoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("sizedoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("sizedoc")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("sizedoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsizedocgroup")]
        [InverseProperty("sizedoc")]
        public virtual sizedocgroup? idsizedocgroupNavigation { get; set; }
        [InverseProperty("idsizedocNavigation")]
        public virtual ICollection<sizedocconstrtype> sizedocconstrtype { get; set; }
        [InverseProperty("idsizedocNavigation")]
        public virtual ICollection<sizedocdiraction> sizedocdiraction { get; set; }
        [InverseProperty("idsizedocNavigation")]
        public virtual ICollection<sizedocfile> sizedocfile { get; set; }
    }
}
