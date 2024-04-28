using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__people__37BBEBC3", IsUnique = true)]
    [Index("idpeoplepost", Name = "idx_people_idpeoplepost")]
    [Index("middlename", Name = "idx_people_middlename")]
    public partial class people : IRemovable
    {
        public people()
        {
            agree = new HashSet<agree>();
            cashbox = new HashSet<cashbox>();
            coatdoc = new HashSet<coatdoc>();
            coatdocsign = new HashSet<coatdocsign>();
            customerdiractionidpeopleNavigation = new HashSet<customerdiraction>();
            customerdiractionidpeopleeditNavigation = new HashSet<customerdiraction>();
            customerdiractionidpeopleсreateNavigation = new HashSet<customerdiraction>();
            customeridpeople2Navigation = new HashSet<customer>();
            customeridpeople3Navigation = new HashSet<customer>();
            customeridpeople4Navigation = new HashSet<customer>();
            customeridpeopleNavigation = new HashSet<customer>();
            customerpeople = new HashSet<customerpeople>();
            customerpricechangehistory = new HashSet<customerpricechangehistory>();
            customerpricepolicyhistory = new HashSet<customerpricepolicyhistory>();
            customerrel = new HashSet<customerrel>();
            customersign = new HashSet<customersign>();
            delivdocdiractionidpeopleNavigation = new HashSet<delivdocdiraction>();
            delivdocdiractionidpeopleeditNavigation = new HashSet<delivdocdiraction>();
            delivdocdiractionpeople = new HashSet<delivdocdiractionpeople>();
            delivdocidpeople2Navigation = new HashSet<delivdoc>();
            delivdocidpeopleNavigation = new HashSet<delivdoc>();
            delivdocpeopleidpeople2Navigation = new HashSet<delivdocpeople>();
            delivdocpeopleidpeopleNavigation = new HashSet<delivdocpeople>();
            delivdocsign = new HashSet<delivdocsign>();
            departmentmember = new HashSet<departmentmember>();
            discard = new HashSet<discard>();
            doclock = new HashSet<doclock>();
            docwork = new HashSet<docwork>();
            docworkpeople = new HashSet<docworkpeople>();
            equipmentdoc = new HashSet<equipmentdoc>();
            goodpricehistory = new HashSet<goodpricehistory>();
            installdocdiractionidpeopleNavigation = new HashSet<installdocdiraction>();
            installdocdiractionidpeopleeditNavigation = new HashSet<installdocdiraction>();
            installdocdiractionpeople = new HashSet<installdocdiractionpeople>();
            installdocidpeople2Navigation = new HashSet<installdoc>();
            installdocidpeople3Navigation = new HashSet<installdoc>();
            installdocidpeopleNavigation = new HashSet<installdoc>();
            installdocsign = new HashSet<installdocsign>();
            mailinglistondemand = new HashSet<mailinglistondemand>();
            mailinglistusers = new HashSet<mailinglistusers>();
            manufactdiractionpeople = new HashSet<manufactdiractionpeople>();
            manufactdoc = new HashSet<manufactdoc>();
            manufactdoccar = new HashSet<manufactdoccar>();
            manufactdocsign = new HashSet<manufactdocsign>();
            messagesidpeople2Navigation = new HashSet<messages>();
            messagesidpeopleNavigation = new HashSet<messages>();
            optimdoc = new HashSet<optimdoc>();
            optimdocdiractionidpeopleNavigation = new HashSet<optimdocdiraction>();
            optimdocdiractionidpeopleeditNavigation = new HashSet<optimdocdiraction>();
            optimdocdiractionidpeopleexecNavigation = new HashSet<optimdocdiraction>();
            optimdocdiractionpeople = new HashSet<optimdocdiractionpeople>();
            optimdocsign = new HashSet<optimdocsign>();
            orderdiraction = new HashSet<orderdiraction>();
            orderdiractionpeople = new HashSet<orderdiractionpeople>();
            ordersidpeopleNavigation = new HashSet<orders>();
            ordersidpeopledesignerNavigation = new HashSet<orders>();
            ordersign = new HashSet<ordersign>();
            paymentdoc = new HashSet<paymentdoc>();
            paymentdocsign = new HashSet<paymentdocsign>();
            peopledate = new HashSet<peopledate>();
            peoplegrouplist = new HashSet<peoplegrouplist>();
            peopleparam = new HashSet<peopleparam>();
            pollexecutingdiraction = new HashSet<pollexecutingdiraction>();
            pollexecutingidpeopleNavigation = new HashSet<pollexecuting>();
            pollexecutingidpeoplecreateNavigation = new HashSet<pollexecuting>();
            pollexecutingsign = new HashSet<pollexecutingsign>();
            pricelist = new HashSet<pricelist>();
            productiondoc = new HashSet<productiondoc>();
            productiondocsign = new HashSet<productiondocsign>();
            respoweridpeople2Navigation = new HashSet<respower>();
            respoweridpeopleNavigation = new HashSet<respower>();
            revisiongp = new HashSet<revisiongp>();
            revisiongpitem = new HashSet<revisiongpitem>();
            servicedepartmentpeople = new HashSet<servicedepartmentpeople>();
            servicedocdiraction = new HashSet<servicedocdiraction>();
            servicedocsign = new HashSet<servicedocsign>();
            servicereason = new HashSet<servicereason>();
            sizedoc = new HashSet<sizedoc>();
            sizedocdiractionidpeopleNavigation = new HashSet<sizedocdiraction>();
            sizedocdiractionidpeopleeditNavigation = new HashSet<sizedocdiraction>();
            sizedocdiractionidpeopleexecNavigation = new HashSet<sizedocdiraction>();
            sizedocdiractionpeople = new HashSet<sizedocdiractionpeople>();
            storedepart = new HashSet<storedepart>();
            storedoc = new HashSet<storedoc>();
            storedocsign = new HashSet<storedocsign>();
            supplydoc = new HashSet<supplydoc>();
            supplydocdiraction = new HashSet<supplydocdiraction>();
            supplydocsign = new HashSet<supplydocsign>();
            techdoc = new HashSet<techdoc>();
            techdocdiraction = new HashSet<techdocdiraction>();
            techdocsign = new HashSet<techdocsign>();
            wdlog = new HashSet<wdlog>();
            work = new HashSet<work>();
            workoper = new HashSet<workoper>();
            workpeople = new HashSet<workpeople>();
        }

        [Key]
        public int idpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? lastname { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? middlename { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? passport { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? address { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? phone { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? peoplegroup { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? userpassword { get; set; }
        public short? isadmin { get; set; }
        public short? oneconnect { get; set; }
        public short? alienorder { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? userlogin { get; set; }
        public int? idpeoplepost { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addinfo { get; set; }
        /// <summary>
        /// Ссылка на отдел
        /// </summary>
        public int? iddepartment { get; set; }
        /// <summary>
        /// Переносить в дилерскую версию
        /// </summary>
        public bool? indealerbase { get; set; }
        public Guid guid { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? email { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public bool? iscrypt { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? tabno { get; set; }
        public bool? ad_authorization { get; set; }
        public string Fio => $@"{lastname} {name} {middlename}".Trim();

        [ForeignKey("idpeoplepost")]
        [InverseProperty("people")]
        public virtual peoplepost? idpeoplepostNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<agree> agree { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<cashbox> cashbox { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<coatdoc> coatdoc { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<coatdocsign> coatdocsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<customerdiraction> customerdiractionidpeopleNavigation { get; set; }
        [InverseProperty("idpeopleeditNavigation")]
        public virtual ICollection<customerdiraction> customerdiractionidpeopleeditNavigation { get; set; }
        [InverseProperty("idpeopleсreateNavigation")]
        public virtual ICollection<customerdiraction> customerdiractionidpeopleсreateNavigation { get; set; }
        [InverseProperty("idpeople2Navigation")]
        public virtual ICollection<customer> customeridpeople2Navigation { get; set; }
        [InverseProperty("idpeople3Navigation")]
        public virtual ICollection<customer> customeridpeople3Navigation { get; set; }
        [InverseProperty("idpeople4Navigation")]
        public virtual ICollection<customer> customeridpeople4Navigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<customer> customeridpeopleNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<customerpeople> customerpeople { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<customerpricechangehistory> customerpricechangehistory { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<customerpricepolicyhistory> customerpricepolicyhistory { get; set; }
        [InverseProperty("idpeopleeditNavigation")]
        public virtual ICollection<customerrel> customerrel { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<customersign> customersign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<delivdocdiraction> delivdocdiractionidpeopleNavigation { get; set; }
        [InverseProperty("idpeopleeditNavigation")]
        public virtual ICollection<delivdocdiraction> delivdocdiractionidpeopleeditNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<delivdocdiractionpeople> delivdocdiractionpeople { get; set; }
        [InverseProperty("idpeople2Navigation")]
        public virtual ICollection<delivdoc> delivdocidpeople2Navigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<delivdoc> delivdocidpeopleNavigation { get; set; }
        [InverseProperty("idpeople2Navigation")]
        public virtual ICollection<delivdocpeople> delivdocpeopleidpeople2Navigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<delivdocpeople> delivdocpeopleidpeopleNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<delivdocsign> delivdocsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<departmentmember> departmentmember { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<discard> discard { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<doclock> doclock { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<docwork> docwork { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<docworkpeople> docworkpeople { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<equipmentdoc> equipmentdoc { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<goodpricehistory> goodpricehistory { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<installdocdiraction> installdocdiractionidpeopleNavigation { get; set; }
        [InverseProperty("idpeopleeditNavigation")]
        public virtual ICollection<installdocdiraction> installdocdiractionidpeopleeditNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<installdocdiractionpeople> installdocdiractionpeople { get; set; }
        [InverseProperty("idpeople2Navigation")]
        public virtual ICollection<installdoc> installdocidpeople2Navigation { get; set; }
        [InverseProperty("idpeople3Navigation")]
        public virtual ICollection<installdoc> installdocidpeople3Navigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<installdoc> installdocidpeopleNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<installdocsign> installdocsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<mailinglistondemand> mailinglistondemand { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<mailinglistusers> mailinglistusers { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<manufactdiractionpeople> manufactdiractionpeople { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<manufactdoc> manufactdoc { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<manufactdoccar> manufactdoccar { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<manufactdocsign> manufactdocsign { get; set; }
        [InverseProperty("idpeople2Navigation")]
        public virtual ICollection<messages> messagesidpeople2Navigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<messages> messagesidpeopleNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<optimdoc> optimdoc { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<optimdocdiraction> optimdocdiractionidpeopleNavigation { get; set; }
        [InverseProperty("idpeopleeditNavigation")]
        public virtual ICollection<optimdocdiraction> optimdocdiractionidpeopleeditNavigation { get; set; }
        [InverseProperty("idpeopleexecNavigation")]
        public virtual ICollection<optimdocdiraction> optimdocdiractionidpeopleexecNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<optimdocdiractionpeople> optimdocdiractionpeople { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<optimdocsign> optimdocsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<orderdiraction> orderdiraction { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<orderdiractionpeople> orderdiractionpeople { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<orders> ordersidpeopleNavigation { get; set; }
        [InverseProperty("idpeopledesignerNavigation")]
        public virtual ICollection<orders> ordersidpeopledesignerNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<ordersign> ordersign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<paymentdocsign> paymentdocsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<peopledate> peopledate { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<peoplegrouplist> peoplegrouplist { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<peopleparam> peopleparam { get; set; }
        [InverseProperty("idpeopleсreateNavigation")]
        public virtual ICollection<pollexecutingdiraction> pollexecutingdiraction { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<pollexecuting> pollexecutingidpeopleNavigation { get; set; }
        [InverseProperty("idpeoplecreateNavigation")]
        public virtual ICollection<pollexecuting> pollexecutingidpeoplecreateNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<pollexecutingsign> pollexecutingsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<pricelist> pricelist { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<productiondoc> productiondoc { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<productiondocsign> productiondocsign { get; set; }
        [InverseProperty("idpeople2Navigation")]
        public virtual ICollection<respower> respoweridpeople2Navigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<respower> respoweridpeopleNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<revisiongp> revisiongp { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<revisiongpitem> revisiongpitem { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<servicedepartmentpeople> servicedepartmentpeople { get; set; }
        [InverseProperty("idpeopleexecNavigation")]
        public virtual ICollection<servicedocdiraction> servicedocdiraction { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<servicedocsign> servicedocsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<servicereason> servicereason { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<sizedoc> sizedoc { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<sizedocdiraction> sizedocdiractionidpeopleNavigation { get; set; }
        [InverseProperty("idpeopleeditNavigation")]
        public virtual ICollection<sizedocdiraction> sizedocdiractionidpeopleeditNavigation { get; set; }
        [InverseProperty("idpeopleexecNavigation")]
        public virtual ICollection<sizedocdiraction> sizedocdiractionidpeopleexecNavigation { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<sizedocdiractionpeople> sizedocdiractionpeople { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<storedepart> storedepart { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<storedoc> storedoc { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<storedocsign> storedocsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<supplydoc> supplydoc { get; set; }
        [InverseProperty("idpeopleсreateNavigation")]
        public virtual ICollection<supplydocdiraction> supplydocdiraction { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<supplydocsign> supplydocsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<techdoc> techdoc { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<techdocdiraction> techdocdiraction { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<techdocsign> techdocsign { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<wdlog> wdlog { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<work> work { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<workoper> workoper { get; set; }
        [InverseProperty("idpeopleNavigation")]
        public virtual ICollection<workpeople> workpeople { get; set; }
    }
}
