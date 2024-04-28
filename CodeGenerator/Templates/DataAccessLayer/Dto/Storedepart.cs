using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idavailabilitygroup", Name = "idx_storedepart_idavailabilitygroup")]
    [Index("idpeople", Name = "idx_storedepart_idpeople")]
    [Index("idproductionsite", Name = "idx_storedepart_idproductionsite")]
    public partial class storedepart
    {
        public storedepart()
        {
            coatdoc = new HashSet<coatdoc>();
            delivdoc = new HashSet<delivdoc>();
            good = new HashSet<good>();
            goodbuffer = new HashSet<goodbuffer>();
            goodcolorparam = new HashSet<goodcolorparam>();
            goodost = new HashSet<goodost>();
            revisiongp = new HashSet<revisiongp>();
            rotoxhouse = new HashSet<rotoxhouse>();
            storagespace = new HashSet<storagespace>();
            storedepartdocoper = new HashSet<storedepartdocoper>();
            storedepartrelidstoredepartchildNavigation = new HashSet<storedepartrel>();
            storedepartrelidstoredepartparentNavigation = new HashSet<storedepartrel>();
            storedocidstoredepart1Navigation = new HashSet<storedoc>();
            storedocidstoredepart2Navigation = new HashSet<storedoc>();
        }

        [Key]
        public int idstoredepart { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpeople { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? departgroup { get; set; }
        public Guid guid { get; set; }
        public int? idproductionsite { get; set; }
        public int? idavailabilitygroup { get; set; }
        public int? typ { get; set; }

        [ForeignKey("idavailabilitygroup")]
        [InverseProperty("storedepart")]
        public virtual availabilitygroup? idavailabilitygroupNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("storedepart")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idproductionsite")]
        [InverseProperty("storedepart")]
        public virtual productionsite? idproductionsiteNavigation { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<coatdoc> coatdoc { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<good> good { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<goodbuffer> goodbuffer { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<goodcolorparam> goodcolorparam { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<goodost> goodost { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<revisiongp> revisiongp { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<rotoxhouse> rotoxhouse { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<storagespace> storagespace { get; set; }
        [InverseProperty("idstoredepartNavigation")]
        public virtual ICollection<storedepartdocoper> storedepartdocoper { get; set; }
        [InverseProperty("idstoredepartchildNavigation")]
        public virtual ICollection<storedepartrel> storedepartrelidstoredepartchildNavigation { get; set; }
        [InverseProperty("idstoredepartparentNavigation")]
        public virtual ICollection<storedepartrel> storedepartrelidstoredepartparentNavigation { get; set; }
        [InverseProperty("idstoredepart1Navigation")]
        public virtual ICollection<storedoc> storedocidstoredepart1Navigation { get; set; }
        [InverseProperty("idstoredepart2Navigation")]
        public virtual ICollection<storedoc> storedocidstoredepart2Navigation { get; set; }
    }
}
