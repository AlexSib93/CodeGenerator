using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idaddress", Name = "idx_delivdoc_idaddress")]
    [Index("idcar", Name = "idx_delivdoc_idcar")]
    [Index("idcustomer", Name = "idx_delivdoc_idcustomer")]
    [Index("iddelivdocgroup", Name = "idx_delivdoc_iddelivdocgroup")]
    [Index("iddestanation", Name = "idx_delivdoc_iddestanation")]
    [Index("iddocoper", Name = "idx_delivdoc_iddocoper")]
    [Index("iddocstate", Name = "idx_delivdoc_iddocstate")]
    [Index("idmanufactdoccar", Name = "idx_delivdoc_idmanufactdoccar")]
    [Index("idorder", Name = "idx_delivdoc_idorder")]
    [Index("idpeople", Name = "idx_delivdoc_idpeople")]
    [Index("idpeople2", Name = "idx_delivdoc_idpeople2")]
    [Index("idstoredepart", Name = "idx_delivdoc_idstoredepart")]
    [Index("idtariff", Name = "idx_delivdoc_idtariff")]
    [Index("parentid", Name = "idx_delivdoc_parentid")]
    public partial class delivdoc
    {
        public delivdoc()
        {
            Inverseparent = new HashSet<delivdoc>();
            delivdocdiraction = new HashSet<delivdocdiraction>();
            delivdocfile = new HashSet<delivdocfile>();
            delivdocpeople = new HashSet<delivdocpeople>();
            delivdocpos = new HashSet<delivdocpos>();
            delivdocsign = new HashSet<delivdocsign>();
        }

        [Key]
        public int iddelivdoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? iddelivdocgroup { get; set; }
        public int? idpeople { get; set; }
        public int? iddocoper { get; set; }
        public int? idcustomer { get; set; }
        public int? idpeople2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idorder { get; set; }
        public int? iddestanation { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? address { get; set; }
        public int? idaddress { get; set; }
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
        public int? idcar { get; set; }
        public int? idpeopleexp { get; set; }
        public int? idpeopledrv { get; set; }
        public int? iddocstate { get; set; }
        public short? ride { get; set; }
        public int? idmanufactdoccar { get; set; }
        public int? parentid { get; set; }
        public int? idstoredepart { get; set; }
        public int? idtariff { get; set; }

        [ForeignKey("idaddress")]
        [InverseProperty("delivdoc")]
        public virtual address? idaddressNavigation { get; set; }
        [ForeignKey("idcar")]
        [InverseProperty("delivdoc")]
        public virtual car? idcarNavigation { get; set; }
        [ForeignKey("idcustomer")]
        [InverseProperty("delivdoc")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddelivdocgroup")]
        [InverseProperty("delivdoc")]
        public virtual delivdocgroup? iddelivdocgroupNavigation { get; set; }
        [ForeignKey("iddestanation")]
        [InverseProperty("delivdoc")]
        public virtual destanation? iddestanationNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("delivdoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("delivdoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idmanufactdoccar")]
        [InverseProperty("delivdoc")]
        public virtual manufactdoccar? idmanufactdoccarNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("delivdoc")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpeople2")]
        [InverseProperty("delivdocidpeople2Navigation")]
        public virtual people? idpeople2Navigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("delivdocidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idstoredepart")]
        [InverseProperty("delivdoc")]
        public virtual storedepart? idstoredepartNavigation { get; set; }
        [ForeignKey("idtariff")]
        [InverseProperty("delivdoc")]
        public virtual tariff? idtariffNavigation { get; set; }
        [ForeignKey("parentid")]
        [InverseProperty("Inverseparent")]
        public virtual delivdoc? parent { get; set; }
        [InverseProperty("parent")]
        public virtual ICollection<delivdoc> Inverseparent { get; set; }
        [InverseProperty("iddelivdocNavigation")]
        public virtual ICollection<delivdocdiraction> delivdocdiraction { get; set; }
        [InverseProperty("iddelivdocNavigation")]
        public virtual ICollection<delivdocfile> delivdocfile { get; set; }
        [InverseProperty("iddelivdocNavigation")]
        public virtual ICollection<delivdocpeople> delivdocpeople { get; set; }
        [InverseProperty("iddelivdocNavigation")]
        public virtual ICollection<delivdocpos> delivdocpos { get; set; }
        [InverseProperty("iddelivdocNavigation")]
        public virtual ICollection<delivdocsign> delivdocsign { get; set; }
    }
}
