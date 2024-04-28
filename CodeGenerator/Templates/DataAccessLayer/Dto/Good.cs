using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__good__4E9F511B", IsUnique = true)]
    [Index("idcolor1", Name = "idx_good_idcolor1")]
    [Index("idcolor2", Name = "idx_good_idcolor2")]
    [Index("idcolorgroupcustom", Name = "idx_good_idcolorgroupcustom")]
    [Index("idgoodgroup", Name = "idx_good_idgoodgroup")]
    [Index("idgoodoptim", Name = "idx_good_idgoodoptim")]
    [Index("idgoodpricegroup", Name = "idx_good_idgoodpricegroup")]
    [Index("idgoodtype", Name = "idx_good_idgoodtype")]
    [Index("idmeasure", Name = "idx_good_idmeasure")]
    [Index("idstoragespace", Name = "idx_good_idstoragespace")]
    [Index("idstoredepart", Name = "idx_good_idstoredepart")]
    [Index("idsystem", Name = "idx_good_idsystem")]
    [Index("idvalut", Name = "idx_good_idvalut")]
    [Index("width", Name = "idx_good_width")]
    public partial class good
    {
        public good()
        {
            coatdocpos = new HashSet<coatdocpos>();
            delivdocpos = new HashSet<delivdocpos>();
            glassdetail = new HashSet<glassdetail>();
            goodanalog = new HashSet<goodanalog>();
            goodanalogdetail = new HashSet<goodanalogdetail>();
            goodbuffer = new HashSet<goodbuffer>();
            goodcolorgroupprice = new HashSet<goodcolorgroupprice>();
            goodcolorparam = new HashSet<goodcolorparam>();
            goodkitdetail = new HashSet<goodkitdetail>();
            goodmeasure = new HashSet<goodmeasure>();
            goodost = new HashSet<goodost>();
            goodparam = new HashSet<goodparam>();
            goodprice = new HashSet<goodprice>();
            goodpricehistory = new HashSet<goodpricehistory>();
            insertiondetail = new HashSet<insertiondetail>();
            installdocpos = new HashSet<installdocpos>();
            manufactdocpos = new HashSet<manufactdocpos>();
            modelcalc = new HashSet<modelcalc>();
            optimdocgoodin = new HashSet<optimdocgoodin>();
            optimdocgoodout = new HashSet<optimdocgoodout>();
            optimdocpic = new HashSet<optimdocpic>();
            optimdocpos = new HashSet<optimdocpos>();
            ordergood = new HashSet<ordergood>();
            orderitem = new HashSet<orderitem>();
            shtapikgroupdetail = new HashSet<shtapikgroupdetail>();
            storedocposidgood2Navigation = new HashSet<storedocpos>();
            storedocposidgoodNavigation = new HashSet<storedocpos>();
            supplydocposidgood2Navigation = new HashSet<supplydocpos>();
            supplydocposidgoodNavigation = new HashSet<supplydocpos>();
            techdocpos = new HashSet<techdocpos>();
            variantdetail = new HashSet<variantdetail>();
        }

        [Key]
        public int idgood { get; set; }
        public int? idmeasure { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? typ { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? extmarking { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? thick { get; set; }
        public int? idgoodgroup { get; set; }
        public short? usehouse { get; set; }
        public short? ismy { get; set; }
        public int? thickness { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        public int? idsystem { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? waste { get; set; }
        public int? idvalut { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idgoodtype { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minost { get; set; }
        public byte[]? price1crypt { get; set; }
        public int? idgoodpricegroup { get; set; }
        public int? idgoodoptim { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price5 { get; set; }
        public int? idvalut2 { get; set; }
        public int? idvalut3 { get; set; }
        public int? idvalut4 { get; set; }
        public int? idvalut5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? packing { get; set; }
        public int? idgoodtype2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        /// <summary>
        /// Ссылка на склад хранения
        /// </summary>
        public int? idstoredepart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr2 { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? waste2 { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? waste3 { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? waste4 { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? waste5 { get; set; }
        public short? showinnopaper { get; set; }
        public int? idcolorgroupcustom { get; set; }
        public int? idcustomer { get; set; }
        public short? replenishment { get; set; }
        public byte[]? picture { get; set; }
        public short? deliverytime { get; set; }
        public bool? reserve { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxost { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minost2 { get; set; }
        public int? idstoragespace { get; set; }
        public short? purchase { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? rank1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? rank2 { get; set; }

        [ForeignKey("idcolorgroupcustom")]
        [InverseProperty("good")]
        public virtual colorgroupcustom? idcolorgroupcustomNavigation { get; set; }
        [ForeignKey("idgoodgroup")]
        [InverseProperty("good")]
        public virtual goodgroup? idgoodgroupNavigation { get; set; }
        [ForeignKey("idgoodoptim")]
        [InverseProperty("good")]
        public virtual goodoptim? idgoodoptimNavigation { get; set; }
        [ForeignKey("idgoodpricegroup")]
        [InverseProperty("good")]
        public virtual goodpricegroup? idgoodpricegroupNavigation { get; set; }
        [ForeignKey("idgoodtype")]
        [InverseProperty("good")]
        public virtual goodtype? idgoodtypeNavigation { get; set; }
        [ForeignKey("idmeasure")]
        [InverseProperty("good")]
        public virtual measure? idmeasureNavigation { get; set; }
        [ForeignKey("idstoragespace")]
        [InverseProperty("good")]
        public virtual storagespace? idstoragespaceNavigation { get; set; }
        [ForeignKey("idstoredepart")]
        [InverseProperty("good")]
        public virtual storedepart? idstoredepartNavigation { get; set; }
        [ForeignKey("idsystem")]
        [InverseProperty("good")]
        public virtual system? idsystemNavigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("good")]
        public virtual valut? idvalutNavigation { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<coatdocpos> coatdocpos { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<delivdocpos> delivdocpos { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<glassdetail> glassdetail { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodanalog> goodanalog { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodanalogdetail> goodanalogdetail { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodbuffer> goodbuffer { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodcolorgroupprice> goodcolorgroupprice { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodcolorparam> goodcolorparam { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodkitdetail> goodkitdetail { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodmeasure> goodmeasure { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodost> goodost { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodparam> goodparam { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodprice> goodprice { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<goodpricehistory> goodpricehistory { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<insertiondetail> insertiondetail { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<installdocpos> installdocpos { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<manufactdocpos> manufactdocpos { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<modelcalc> modelcalc { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<optimdocgoodin> optimdocgoodin { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<optimdocgoodout> optimdocgoodout { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<optimdocpic> optimdocpic { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<optimdocpos> optimdocpos { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<ordergood> ordergood { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<orderitem> orderitem { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<shtapikgroupdetail> shtapikgroupdetail { get; set; }
        [InverseProperty("idgood2Navigation")]
        public virtual ICollection<storedocpos> storedocposidgood2Navigation { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<storedocpos> storedocposidgoodNavigation { get; set; }
        [InverseProperty("idgood2Navigation")]
        public virtual ICollection<supplydocpos> supplydocposidgood2Navigation { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<supplydocpos> supplydocposidgoodNavigation { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<techdocpos> techdocpos { get; set; }
        [InverseProperty("idgoodNavigation")]
        public virtual ICollection<variantdetail> variantdetail { get; set; }
    }
}
