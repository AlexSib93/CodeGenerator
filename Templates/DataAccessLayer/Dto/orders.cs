using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorder", Name = "_dta_index_orders_5_309576141__K1")]
    [Index("idorder", Name = "_dta_index_orders_5_309576141__K1_16")]
    [Index("idorder", "deleted", Name = "_dta_index_orders_5_309576141__K1_K4")]
    [Index("idorder", "deleted", Name = "_dta_index_orders_5_309576141__K1_K4_16")]
    [Index("deleted", Name = "_dta_index_orders_5_309576141__K4")]
    [Index("deleted", "idorder", Name = "_dta_index_orders_5_309576141__K4_K1_16")]
    [Index("guid", Name = "idx_orders_guid")]
    [Index("guid", Name = "idx_orders_guid_unique", IsUnique = true)]
    [Index("idaddress", Name = "idx_orders_idaddress")]
    [Index("idagree", Name = "idx_orders_idagree")]
    [Index("idagreement", Name = "idx_orders_idagreement")]
    [Index("idcustomer", Name = "idx_orders_idcustomer")]
    [Index("idcustomer2", Name = "idx_orders_idcustomer2")]
    [Index("idcustomer3", Name = "idx_orders_idcustomer3")]
    [Index("iddepartment", Name = "idx_orders_iddepartment")]
    [Index("iddestanation", Name = "idx_orders_iddestanation")]
    [Index("iddiscard", Name = "idx_orders_iddiscard")]
    [Index("iddocoper", Name = "idx_orders_iddocoper")]
    [Index("iddocstate", Name = "idx_orders_iddocstate")]
    [Index("idordersgroup", Name = "idx_orders_idordersgroup")]
    [Index("idpeople", Name = "idx_orders_idpeople")]
    [Index("idpeopledesigner", Name = "idx_orders_idpeopledesigner")]
    [Index("idseller", Name = "idx_orders_idseller")]
    [Index("idvalut", Name = "idx_orders_idvalut")]
    [Index("idversion", Name = "idx_orders_idversion")]
    [Index("idparent", Name = "ind_orders_idparent")]
    public partial class orders
    {
        public orders()
        {
            delivdoc = new HashSet<delivdoc>();
            delivdocpos = new HashSet<delivdocpos>();
            finparamcalc = new HashSet<finparamcalc>();
            goodost = new HashSet<goodost>();
            installdoc = new HashSet<installdoc>();
            installdocgoodservice = new HashSet<installdocgoodservice>();
            manufactdocnopyramid = new HashSet<manufactdocnopyramid>();
            manufactdocorder = new HashSet<manufactdocorder>();
            model = new HashSet<model>();
            modelpic = new HashSet<modelpic>();
            optimdoc = new HashSet<optimdoc>();
            optimdocpos = new HashSet<optimdocpos>();
            orderbudget = new HashSet<orderbudget>();
            orderdiraction = new HashSet<orderdiraction>();
            orderdiscard = new HashSet<orderdiscard>();
            ordererror = new HashSet<ordererror>();
            orderfile = new HashSet<orderfile>();
            ordergood = new HashSet<ordergood>();
            ordergoodservice = new HashSet<ordergoodservice>();
            orderitem = new HashSet<orderitem>();
            orderpricechange = new HashSet<orderpricechange>();
            ordersetting = new HashSet<ordersetting>();
            ordersign = new HashSet<ordersign>();
            paymentdoc = new HashSet<paymentdoc>();
            pollexecuting = new HashSet<pollexecuting>();
            respower = new HashSet<respower>();
            servicedocidorderNavigation = new HashSet<servicedoc>();
            servicedocidorderdestNavigation = new HashSet<servicedoc>();
            sizedoc = new HashSet<sizedoc>();
            storedoc = new HashSet<storedoc>();
            supplydoc = new HashSet<supplydoc>();
        }

        [Key]
        public int idorder { get; set; }
        public int? idpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? logincre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idordersgroup { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        public int? idversion { get; set; }
        public int? idcustomer { get; set; }
        public int? iddocoper { get; set; }
        public int? qupos { get; set; }
        public int? idvalut { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? agreename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? agreedate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? iddestanation { get; set; }
        public int? idseller { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? address { get; set; }
        public short? floor { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? contact { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? phone { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "text")]
        public string? addtext { get; set; }
        public short? saved { get; set; }
        public short? saved2 { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idaddress { get; set; }
        public int? iddiscard { get; set; }
        public int? idcustomer2 { get; set; }
        public int? idcustomer3 { get; set; }
        /// <summary>
        /// Сотрудник 2
        /// </summary>
        public int? idpeople2 { get; set; }
        /// <summary>
        /// Сотрудник 3
        /// </summary>
        public int? idpeople3 { get; set; }
        /// <summary>
        /// Сотрудник 4
        /// </summary>
        public int? idpeople4 { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Unicode(false)]
        public string? addinfo { get; set; }
        [Unicode(false)]
        public string? supplyinfo { get; set; }
        [Unicode(false)]
        public string? productinfo { get; set; }
        [Unicode(false)]
        public string? transportinfo { get; set; }
        [Unicode(false)]
        public string? installinfo { get; set; }
        [Unicode(false)]
        public string? sizeinfo { get; set; }
        public int? iddepartment { get; set; }
        public int? idsourceinfo { get; set; }
        public int? idadvertisingaction { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr5 { get; set; }
        public int? idparent { get; set; }
        public int? iddocstate { get; set; }
        public int? idagree { get; set; }
        public int? idpeopledesigner { get; set; }
        public int? idagreement { get; set; }

        [ForeignKey("idaddress")]
        [InverseProperty("orders")]
        public virtual address? idaddressNavigation { get; set; }
        [ForeignKey("idagree")]
        [InverseProperty("orders")]
        public virtual agree? idagreeNavigation { get; set; }
        [ForeignKey("idagreement")]
        [InverseProperty("orders")]
        public virtual agreement? idagreementNavigation { get; set; }
        [ForeignKey("idcustomer2")]
        [InverseProperty("ordersidcustomer2Navigation")]
        public virtual customer? idcustomer2Navigation { get; set; }
        [ForeignKey("idcustomer3")]
        [InverseProperty("ordersidcustomer3Navigation")]
        public virtual customer? idcustomer3Navigation { get; set; }
        [ForeignKey("idcustomer")]
        [InverseProperty("ordersidcustomerNavigation")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddepartment")]
        [InverseProperty("orders")]
        public virtual department? iddepartmentNavigation { get; set; }
        [ForeignKey("iddestanation")]
        [InverseProperty("orders")]
        public virtual destanation? iddestanationNavigation { get; set; }
        [ForeignKey("iddiscard")]
        [InverseProperty("orders")]
        public virtual discard? iddiscardNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("orders")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("orders")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idordersgroup")]
        [InverseProperty("orders")]
        public virtual ordersgroup? idordersgroupNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("ordersidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeopledesigner")]
        [InverseProperty("ordersidpeopledesignerNavigation")]
        public virtual people? idpeopledesignerNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("orders")]
        public virtual seller? idsellerNavigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("orders")]
        public virtual valut? idvalutNavigation { get; set; }
        [ForeignKey("idversion")]
        [InverseProperty("orders")]
        public virtual versions? idversionNavigation { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<delivdocpos> delivdocpos { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<finparamcalc> finparamcalc { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<goodost> goodost { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<installdoc> installdoc { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<installdocgoodservice> installdocgoodservice { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<manufactdocnopyramid> manufactdocnopyramid { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<manufactdocorder> manufactdocorder { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<model> model { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<modelpic> modelpic { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<optimdoc> optimdoc { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<optimdocpos> optimdocpos { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<orderbudget> orderbudget { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<orderdiraction> orderdiraction { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<orderdiscard> orderdiscard { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<ordererror> ordererror { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<orderfile> orderfile { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<ordergood> ordergood { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<ordergoodservice> ordergoodservice { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<orderitem> orderitem { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<orderpricechange> orderpricechange { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<ordersetting> ordersetting { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<ordersign> ordersign { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<pollexecuting> pollexecuting { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<respower> respower { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<servicedoc> servicedocidorderNavigation { get; set; }
        [InverseProperty("idorderdestNavigation")]
        public virtual ICollection<servicedoc> servicedocidorderdestNavigation { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<sizedoc> sizedoc { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<storedoc> storedoc { get; set; }
        [InverseProperty("idorderNavigation")]
        public virtual ICollection<supplydoc> supplydoc { get; set; }
    }
}
