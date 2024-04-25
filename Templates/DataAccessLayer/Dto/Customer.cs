using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__customer__1CD2EB5D", IsUnique = true)]
    [Index("idaddclassification1", Name = "idx_customer_idaddclassification1")]
    [Index("idaddclassification2", Name = "idx_customer_idaddclassification2")]
    [Index("idaddclassification3", Name = "idx_customer_idaddclassification3")]
    [Index("idaddclassification4", Name = "idx_customer_idaddclassification4")]
    [Index("idaddclassification5", Name = "idx_customer_idaddclassification5")]
    [Index("idaddress", Name = "idx_customer_idaddress")]
    [Index("idaddresslegal", Name = "idx_customer_idaddresslegal")]
    [Index("idagreement", Name = "idx_customer_idagreement")]
    [Index("idcustomercategory", Name = "idx_customer_idcustomercategory")]
    [Index("idcustomerform", Name = "idx_customer_idcustomerform")]
    [Index("idcustomergroup", Name = "idx_customer_idcustomergroup")]
    [Index("iddestanation", Name = "idx_customer_iddestanation")]
    [Index("iddocoper", Name = "idx_customer_iddocoper")]
    [Index("iddocstate", Name = "idx_customer_iddocstate")]
    [Index("idpeople", Name = "idx_customer_idpeople")]
    [Index("idpeople2", Name = "idx_customer_idpeople2")]
    [Index("idpeople3", Name = "idx_customer_idpeople3")]
    [Index("idpeople4", Name = "idx_customer_idpeople4")]
    [Index("idseller", Name = "idx_customer_idseller")]
    [Index("idsourceinfo", Name = "idx_customer_idsourceinfo")]
    [Index("idvalut", Name = "idx_customer_idvalut")]
    [Index("parentid", Name = "idx_customer_parentid")]
    public partial class customer
    {
        public customer()
        {
            agree = new HashSet<agree>();
            coatdoc = new HashSet<coatdoc>();
            customeraccount = new HashSet<customeraccount>();
            customeraddress = new HashSet<customeraddress>();
            customeragreement = new HashSet<customeragreement>();
            customerclaim = new HashSet<customerclaim>();
            customerdestanation = new HashSet<customerdestanation>();
            customerdiraction = new HashSet<customerdiraction>();
            customerdiscard = new HashSet<customerdiscard>();
            customerevent = new HashSet<customerevent>();
            customerfile = new HashSet<customerfile>();
            customerpeople = new HashSet<customerpeople>();
            customerplan = new HashSet<customerplan>();
            customerpricechange = new HashSet<customerpricechange>();
            customerpricechangehistory = new HashSet<customerpricechangehistory>();
            customerpricepolicy = new HashSet<customerpricepolicy>();
            customerpricepolicyhistory = new HashSet<customerpricepolicyhistory>();
            customerrelidcustomerchildNavigation = new HashSet<customerrel>();
            customerrelidcustomerparentNavigation = new HashSet<customerrel>();
            customersign = new HashSet<customersign>();
            delivdoc = new HashSet<delivdoc>();
            destanationcustomer = new HashSet<destanationcustomer>();
            installdoc = new HashSet<installdoc>();
            mailinglistondemand = new HashSet<mailinglistondemand>();
            mailinglistusers = new HashSet<mailinglistusers>();
            manufactdoc = new HashSet<manufactdoc>();
            optimdoc = new HashSet<optimdoc>();
            ordersidcustomer2Navigation = new HashSet<orders>();
            ordersidcustomer3Navigation = new HashSet<orders>();
            ordersidcustomerNavigation = new HashSet<orders>();
            paymentdoc = new HashSet<paymentdoc>();
            pollexecutingidcustomer2Navigation = new HashSet<pollexecuting>();
            pollexecutingidcustomerNavigation = new HashSet<pollexecuting>();
            pricelist = new HashSet<pricelist>();
            sizedoc = new HashSet<sizedoc>();
            supplydocidcustomer2Navigation = new HashSet<supplydoc>();
            supplydocidcustomerNavigation = new HashSet<supplydoc>();
            techdoc = new HashSet<techdoc>();
        }

        [Key]
        public int idcustomer { get; set; }
        public int? idcustomergroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? inn { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? okonh { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? okpo { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? web { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? address { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? bik { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? account { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? kaccount { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? contactpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phone { get; set; }
        public int? face { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "text")]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount { get; set; }
        public int? iddestanation { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? credit { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? directorfio { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? directorfounding { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? firstname { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? middlename { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? lastname { get; set; }
        public int? idaddress { get; set; }
        /// <summary>
        /// Серия паспорта
        /// </summary>
        [StringLength(10)]
        [Unicode(false)]
        public string? passportseries { get; set; }
        /// <summary>
        /// Номер паспорта
        /// </summary>
        [StringLength(10)]
        [Unicode(false)]
        public string? passportnum { get; set; }
        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? passportexit { get; set; }
        /// <summary>
        /// Дата выдачи паспорт
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? passportdate { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? birthday { get; set; }
        /// <summary>
        /// Телефон мобильный
        /// </summary>
        [StringLength(128)]
        [Unicode(false)]
        public string? phonemobile { get; set; }
        /// <summary>
        /// Телефон домашний
        /// </summary>
        [StringLength(128)]
        [Unicode(false)]
        public string? phonehome { get; set; }
        /// <summary>
        /// Ссылка на юр.адрес из КЛАДР
        /// </summary>
        public int? idaddresslegal { get; set; }
        /// <summary>
        /// Юр.адрес
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? addresslegal { get; set; }
        /// <summary>
        /// Ссылка на источник информации
        /// </summary>
        public int? idsourceinfo { get; set; }
        public int? idaw { get; set; }
        public int? idseller { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? bank { get; set; }
        public Guid guid { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? email { get; set; }
        public int? idcustomercategory { get; set; }
        /// <summary>
        /// Альтернативное наименование контрагента
        /// </summary>
        [StringLength(256)]
        [Unicode(false)]
        public string? name2 { get; set; }
        /// <summary>
        /// Краткое наименование контрагента
        /// </summary>
        [StringLength(256)]
        [Unicode(false)]
        public string? name3 { get; set; }
        public int? idcustomerform { get; set; }
        public int? idpeople { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? ogrn { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount6 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount7 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount8 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount9 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount10 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount11 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount12 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        public int? idpeoplecre { get; set; }
        public int? iddocoper { get; set; }
        [Unicode(false)]
        public string? addstr { get; set; }
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [Unicode(false)]
        public string? addstr5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum5 { get; set; }
        public int? addint { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? directorposition { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? auditorfio { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtbirth { get; set; }
        [StringLength(4)]
        [Unicode(false)]
        public string? passportserial { get; set; }
        public int? passportnumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? passportdtissue { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? passportissued { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? contact { get; set; }
        public int? parentid { get; set; }
        public int? iddocstate { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? kpp { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? okato { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phone2 { get; set; }
        public int? idaddclassification1 { get; set; }
        public int? idaddclassification2 { get; set; }
        public int? idaddclassification3 { get; set; }
        public int? idaddclassification4 { get; set; }
        public int? idaddclassification5 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public bool? addbit1 { get; set; }
        public bool? addbit2 { get; set; }
        public bool? indealerbase { get; set; }
        public int? idagreement { get; set; }
        public int? idpeople2 { get; set; }
        public int? idpeople3 { get; set; }
        public int? idpeople4 { get; set; }
        public int? idvalut { get; set; }

        [ForeignKey("idaddclassification1")]
        [InverseProperty("customeridaddclassification1Navigation")]
        public virtual addclassification? idaddclassification1Navigation { get; set; }
        [ForeignKey("idaddclassification2")]
        [InverseProperty("customeridaddclassification2Navigation")]
        public virtual addclassification? idaddclassification2Navigation { get; set; }
        [ForeignKey("idaddclassification3")]
        [InverseProperty("customeridaddclassification3Navigation")]
        public virtual addclassification? idaddclassification3Navigation { get; set; }
        [ForeignKey("idaddclassification4")]
        [InverseProperty("customeridaddclassification4Navigation")]
        public virtual addclassification? idaddclassification4Navigation { get; set; }
        [ForeignKey("idaddclassification5")]
        [InverseProperty("customeridaddclassification5Navigation")]
        public virtual addclassification? idaddclassification5Navigation { get; set; }
        [ForeignKey("idaddress")]
        [InverseProperty("customeridaddressNavigation")]
        public virtual address? idaddressNavigation { get; set; }
        [ForeignKey("idaddresslegal")]
        [InverseProperty("customeridaddresslegalNavigation")]
        public virtual address? idaddresslegalNavigation { get; set; }
        [ForeignKey("idagreement")]
        [InverseProperty("customer")]
        public virtual agreement? idagreementNavigation { get; set; }
        [ForeignKey("idcustomercategory")]
        [InverseProperty("customer")]
        public virtual customercategory? idcustomercategoryNavigation { get; set; }
        [ForeignKey("idcustomerform")]
        [InverseProperty("customer")]
        public virtual customerform? idcustomerformNavigation { get; set; }
        [ForeignKey("idcustomergroup")]
        [InverseProperty("customer")]
        public virtual customergroup? idcustomergroupNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("customer")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("customer")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idpeople2")]
        [InverseProperty("customeridpeople2Navigation")]
        public virtual people? idpeople2Navigation { get; set; }
        [ForeignKey("idpeople3")]
        [InverseProperty("customeridpeople3Navigation")]
        public virtual people? idpeople3Navigation { get; set; }
        [ForeignKey("idpeople4")]
        [InverseProperty("customeridpeople4Navigation")]
        public virtual people? idpeople4Navigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("customeridpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("customer")]
        public virtual seller? idsellerNavigation { get; set; }
        [ForeignKey("idsourceinfo")]
        [InverseProperty("customer")]
        public virtual sourceinfo? idsourceinfoNavigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("customer")]
        public virtual valut? idvalutNavigation { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<agree> agree { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<coatdoc> coatdoc { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customeraccount> customeraccount { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customeraddress> customeraddress { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customeragreement> customeragreement { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerclaim> customerclaim { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerdestanation> customerdestanation { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerdiraction> customerdiraction { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerdiscard> customerdiscard { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerevent> customerevent { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerfile> customerfile { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerpeople> customerpeople { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerplan> customerplan { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerpricechange> customerpricechange { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerpricechangehistory> customerpricechangehistory { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerpricepolicy> customerpricepolicy { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customerpricepolicyhistory> customerpricepolicyhistory { get; set; }
        [InverseProperty("idcustomerchildNavigation")]
        public virtual ICollection<customerrel> customerrelidcustomerchildNavigation { get; set; }
        [InverseProperty("idcustomerparentNavigation")]
        public virtual ICollection<customerrel> customerrelidcustomerparentNavigation { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<customersign> customersign { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<destanationcustomer> destanationcustomer { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<installdoc> installdoc { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<mailinglistondemand> mailinglistondemand { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<mailinglistusers> mailinglistusers { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<manufactdoc> manufactdoc { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<optimdoc> optimdoc { get; set; }
        [InverseProperty("idcustomer2Navigation")]
        public virtual ICollection<orders> ordersidcustomer2Navigation { get; set; }
        [InverseProperty("idcustomer3Navigation")]
        public virtual ICollection<orders> ordersidcustomer3Navigation { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<orders> ordersidcustomerNavigation { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
        [InverseProperty("idcustomer2Navigation")]
        public virtual ICollection<pollexecuting> pollexecutingidcustomer2Navigation { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<pollexecuting> pollexecutingidcustomerNavigation { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<pricelist> pricelist { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<sizedoc> sizedoc { get; set; }
        [InverseProperty("idcustomer2Navigation")]
        public virtual ICollection<supplydoc> supplydocidcustomer2Navigation { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<supplydoc> supplydocidcustomerNavigation { get; set; }
        [InverseProperty("idcustomerNavigation")]
        public virtual ICollection<techdoc> techdoc { get; set; }
    }
}
