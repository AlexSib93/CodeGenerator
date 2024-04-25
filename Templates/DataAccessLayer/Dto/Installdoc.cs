using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idaddress", Name = "idx_installdoc_idaddress")]
    [Index("idcustomer", Name = "idx_installdoc_idcustomer")]
    [Index("iddestanation", Name = "idx_installdoc_iddestanation")]
    [Index("iddocoper", Name = "idx_installdoc_iddocoper")]
    [Index("iddocstate", Name = "idx_installdoc_iddocstate")]
    [Index("idinstalldocgroup", Name = "idx_installdoc_idinstalldocgroup")]
    [Index("idorder", Name = "idx_installdoc_idorder")]
    [Index("idpeople", Name = "idx_installdoc_idpeople")]
    [Index("idpeople2", Name = "idx_installdoc_idpeople2")]
    [Index("idpeople3", Name = "idx_installdoc_idpeople3")]
    public partial class installdoc
    {
        public installdoc()
        {
            installdocdiraction = new HashSet<installdocdiraction>();
            installdocfile = new HashSet<installdocfile>();
            installdocgoodservice = new HashSet<installdocgoodservice>();
            installdocpos = new HashSet<installdocpos>();
            installdocsign = new HashSet<installdocsign>();
        }

        [Key]
        public int idinstalldoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        public int? iddocoper { get; set; }
        public int? idcustomer { get; set; }
        public int? idinstalldocgroup { get; set; }
        public int? idorder { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? address { get; set; }
        public int? idaddress { get; set; }
        public int? idpeople2 { get; set; }
        public int? iddestanation { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        public int? qupos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue { get; set; }
        /// <summary>
        /// Контактное лицо
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? contact { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? iddocstate { get; set; }
        public int? orderinstall { get; set; }
        public int? idpeople3 { get; set; }

        [ForeignKey("idaddress")]
        [InverseProperty("installdoc")]
        public virtual address? idaddressNavigation { get; set; }
        [ForeignKey("idcustomer")]
        [InverseProperty("installdoc")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddestanation")]
        [InverseProperty("installdoc")]
        public virtual destanation? iddestanationNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("installdoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("installdoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idinstalldocgroup")]
        [InverseProperty("installdoc")]
        public virtual installdocgroup? idinstalldocgroupNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("installdoc")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpeople2")]
        [InverseProperty("installdocidpeople2Navigation")]
        public virtual people? idpeople2Navigation { get; set; }
        [ForeignKey("idpeople3")]
        [InverseProperty("installdocidpeople3Navigation")]
        public virtual people? idpeople3Navigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("installdocidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [InverseProperty("idinstalldocNavigation")]
        public virtual ICollection<installdocdiraction> installdocdiraction { get; set; }
        [InverseProperty("idinstalldocNavigation")]
        public virtual ICollection<installdocfile> installdocfile { get; set; }
        [InverseProperty("idinstalldocNavigation")]
        public virtual ICollection<installdocgoodservice> installdocgoodservice { get; set; }
        [InverseProperty("idinstalldocNavigation")]
        public virtual ICollection<installdocpos> installdocpos { get; set; }
        [InverseProperty("idinstalldocNavigation")]
        public virtual ICollection<installdocsign> installdocsign { get; set; }
    }
}
