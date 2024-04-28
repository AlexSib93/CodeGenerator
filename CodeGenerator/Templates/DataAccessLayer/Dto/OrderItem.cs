using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolorin", Name = "idx_orderitem_idcolorin")]
    [Index("idcolorout", Name = "idx_orderitem_idcolorout")]
    [Index("idgood", Name = "idx_orderitem_idgood")]
    [Index("idmodel", Name = "idx_orderitem_idmodel")]
    [Index("idorder", Name = "idx_orderitem_idorder")]
    [Index("idpower", Name = "idx_orderitem_idpower")]
    [Index("idproductiontype", Name = "idx_orderitem_idproductiontype")]
    [Index("idversion", Name = "idx_orderitem_idversion")]
    [Index("parentid", Name = "idx_orderitem_parentid")]
    [Index("width", Name = "idx_orderitem_width")]
    public partial class orderitem
    {
        public orderitem()
        {
            delivdocpos = new HashSet<delivdocpos>();
            finparamcalc = new HashSet<finparamcalc>();
            goodbuffer = new HashSet<goodbuffer>();
            installdocgoodservice = new HashSet<installdocgoodservice>();
            installdocpos = new HashSet<installdocpos>();
            manufactdocpos = new HashSet<manufactdocpos>();
            manufactdocpyramidpos = new HashSet<manufactdocpyramidpos>();
            model = new HashSet<model>();
            modelpic = new HashSet<modelpic>();
            nopaper = new HashSet<nopaper>();
            optimdocpos = new HashSet<optimdocpos>();
            ordererror = new HashSet<ordererror>();
            ordergood = new HashSet<ordergood>();
            ordergoodservice = new HashSet<ordergoodservice>();
            productiondocpos = new HashSet<productiondocpos>();
            respower = new HashSet<respower>();
            rotoxhouse = new HashSet<rotoxhouse>();
            servicedocpos = new HashSet<servicedocpos>();
            storedocpos = new HashSet<storedocpos>();
            supplydocpos = new HashSet<supplydocpos>();
            techdocpos = new HashSet<techdocpos>();
        }

        [Key]
        public int idorderitem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idorder { get; set; }
        public int? idmodel { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? part { get; set; }
        public int? idgood { get; set; }
        public int? numpos { get; set; }
        /// <summary>
        /// Тип записи. 0-Доп.материал, 1-2D модель, 2-3D модель, 3-Продукция
        /// </summary>
        public short? typ { get; set; }
        public int? idversion { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? sqr { get; set; }
        public short? isglass { get; set; }
        public short? ismoskit { get; set; }
        public short? isaddgood { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue { get; set; }
        public short? isstandart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue3 { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? constrnum { get; set; }
        public int? idprofsys { get; set; }
        public int? idfurnsys { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idcolorin { get; set; }
        public int? idcolorout { get; set; }
        public int? quready { get; set; }
        public short? isready { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? quinmanufact { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase4 { get; set; }
        public int? parentid { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idproductiontype { get; set; }
        public int? idorderitemold { get; set; }
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
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum6 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum7 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum8 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        public int? addint { get; set; }
        public int? addint2 { get; set; }
        public int? idgoodkitdetail { get; set; }
        public int? idgoodkit { get; set; }
        public bool? hide { get; set; }
        public int? idpower { get; set; }
        public bool? ispf { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? assemblyunit { get; set; }

        [ForeignKey("idcolorin")]
        [InverseProperty("orderitemidcolorinNavigation")]
        public virtual color? idcolorinNavigation { get; set; }
        [ForeignKey("idcolorout")]
        [InverseProperty("orderitemidcoloroutNavigation")]
        public virtual color? idcoloroutNavigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("orderitem")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("orderitem")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpower")]
        [InverseProperty("orderitem")]
        public virtual power? idpowerNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("orderitem")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
        [ForeignKey("idversion")]
        [InverseProperty("orderitem")]
        public virtual versions? idversionNavigation { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<delivdocpos> delivdocpos { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<finparamcalc> finparamcalc { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<goodbuffer> goodbuffer { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<installdocgoodservice> installdocgoodservice { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<installdocpos> installdocpos { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<manufactdocpos> manufactdocpos { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<manufactdocpyramidpos> manufactdocpyramidpos { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<model> model { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<modelpic> modelpic { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<nopaper> nopaper { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<optimdocpos> optimdocpos { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<ordererror> ordererror { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<ordergood> ordergood { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<ordergoodservice> ordergoodservice { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<productiondocpos> productiondocpos { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<respower> respower { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<rotoxhouse> rotoxhouse { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<servicedocpos> servicedocpos { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<storedocpos> storedocpos { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<supplydocpos> supplydocpos { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<techdocpos> techdocpos { get; set; }
    }
}
