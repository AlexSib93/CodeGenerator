using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__valut__1AEAA2EB", IsUnique = true)]
    public partial class valut
    {
        public valut()
        {
            advertisingaction = new HashSet<advertisingaction>();
            agreement = new HashSet<agreement>();
            customer = new HashSet<customer>();
            good = new HashSet<good>();
            goodcolorgrouppriceidvalut2Navigation = new HashSet<goodcolorgroupprice>();
            goodcolorgrouppriceidvalutNavigation = new HashSet<goodcolorgroupprice>();
            goodpricehistory = new HashSet<goodpricehistory>();
            goodserviceidvalut1Navigation = new HashSet<goodservice>();
            goodserviceidvalut2Navigation = new HashSet<goodservice>();
            goodserviceidvalut3Navigation = new HashSet<goodservice>();
            goodserviceidvalut4Navigation = new HashSet<goodservice>();
            goodserviceidvalut5Navigation = new HashSet<goodservice>();
            orderpricechange = new HashSet<orderpricechange>();
            orders = new HashSet<orders>();
            paymentdoc = new HashSet<paymentdoc>();
            pricelistpricechange = new HashSet<pricelistpricechange>();
            supplydoc = new HashSet<supplydoc>();
            valutrateidvalut2Navigation = new HashSet<valutrate>();
            valutrateidvalutNavigation = new HashSet<valutrate>();
        }

        [Key]
        public int idvalut { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? shortname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? isbase { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<advertisingaction> advertisingaction { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<agreement> agreement { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<customer> customer { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<good> good { get; set; }
        [InverseProperty("idvalut2Navigation")]
        public virtual ICollection<goodcolorgroupprice> goodcolorgrouppriceidvalut2Navigation { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<goodcolorgroupprice> goodcolorgrouppriceidvalutNavigation { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<goodpricehistory> goodpricehistory { get; set; }
        [InverseProperty("idvalut1Navigation")]
        public virtual ICollection<goodservice> goodserviceidvalut1Navigation { get; set; }
        [InverseProperty("idvalut2Navigation")]
        public virtual ICollection<goodservice> goodserviceidvalut2Navigation { get; set; }
        [InverseProperty("idvalut3Navigation")]
        public virtual ICollection<goodservice> goodserviceidvalut3Navigation { get; set; }
        [InverseProperty("idvalut4Navigation")]
        public virtual ICollection<goodservice> goodserviceidvalut4Navigation { get; set; }
        [InverseProperty("idvalut5Navigation")]
        public virtual ICollection<goodservice> goodserviceidvalut5Navigation { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<orderpricechange> orderpricechange { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<orders> orders { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<pricelistpricechange> pricelistpricechange { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<supplydoc> supplydoc { get; set; }
        [InverseProperty("idvalut2Navigation")]
        public virtual ICollection<valutrate> valutrateidvalut2Navigation { get; set; }
        [InverseProperty("idvalutNavigation")]
        public virtual ICollection<valutrate> valutrateidvalutNavigation { get; set; }
    }
}
