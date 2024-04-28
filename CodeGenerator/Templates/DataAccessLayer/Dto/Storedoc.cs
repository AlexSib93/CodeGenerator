using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("dtcre", Name = "idx_storedoc_dtcre")]
    [Index("idcustomer", Name = "idx_storedoc_idcustomer")]
    [Index("iddocoper", Name = "idx_storedoc_iddocoper")]
    [Index("iddocstate", Name = "idx_storedoc_iddocstate")]
    [Index("idorder", Name = "idx_storedoc_idorder")]
    [Index("idpeople", Name = "idx_storedoc_idpeople")]
    [Index("idseller", Name = "idx_storedoc_idseller")]
    [Index("idstoredepart1", Name = "idx_storedoc_idstoredepart1")]
    [Index("idstoredepart2", Name = "idx_storedoc_idstoredepart2")]
    [Index("idstoredocgroup", Name = "idx_storedoc_idstoredocgroup")]
    public partial class storedoc
    {
        public storedoc()
        {
            delivdocpos = new HashSet<delivdocpos>();
            optimdoc = new HashSet<optimdoc>();
            productiondocpos = new HashSet<productiondocpos>();
            rotoxhouse = new HashSet<rotoxhouse>();
            storedocpos = new HashSet<storedocpos>();
            storedocsign = new HashSet<storedocsign>();
        }

        [Key]
        public int idstoredoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? logincre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        public int? qupos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        public int? idcustomer { get; set; }
        public int? idstoredocgroup { get; set; }
        public int? idstoredepart1 { get; set; }
        public int? idstoredepart2 { get; set; }
        public int? iddocoper { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? iddocstate { get; set; }
        public bool? reg { get; set; }
        public int? idorder { get; set; }
        public bool withnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sumnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? nds { get; set; }
        public int? idseller { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? outname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? outdate { get; set; }

        [ForeignKey("iddocoper")]
        [InverseProperty("storedoc")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("storedoc")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("storedoc")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("storedoc")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("storedoc")]
        public virtual seller? idsellerNavigation { get; set; }
        [ForeignKey("idstoredepart1")]
        [InverseProperty("storedocidstoredepart1Navigation")]
        public virtual storedepart? idstoredepart1Navigation { get; set; }
        [ForeignKey("idstoredepart2")]
        [InverseProperty("storedocidstoredepart2Navigation")]
        public virtual storedepart? idstoredepart2Navigation { get; set; }
        [ForeignKey("idstoredocgroup")]
        [InverseProperty("storedoc")]
        public virtual storedocgroup? idstoredocgroupNavigation { get; set; }
        [InverseProperty("idstoredocNavigation")]
        public virtual ICollection<delivdocpos> delivdocpos { get; set; }
        [InverseProperty("idstoredocNavigation")]
        public virtual ICollection<optimdoc> optimdoc { get; set; }
        [InverseProperty("idstoredocNavigation")]
        public virtual ICollection<productiondocpos> productiondocpos { get; set; }
        [InverseProperty("idstoredocNavigation")]
        public virtual ICollection<rotoxhouse> rotoxhouse { get; set; }
        [InverseProperty("idstoredocNavigation")]
        public virtual ICollection<storedocpos> storedocpos { get; set; }
        [InverseProperty("idstoredocNavigation")]
        public virtual ICollection<storedocsign> storedocsign { get; set; }
    }
}
