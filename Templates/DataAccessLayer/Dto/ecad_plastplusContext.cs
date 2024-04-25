using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Dto
{
    public partial class ecad_plastplusContext : DbContext
    {
        public ecad_plastplusContext()
        {
        }

        public ecad_plastplusContext(DbContextOptions<ecad_plastplusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; } = null!;
        public virtual DbSet<__view_people> __view_people { get; set; } = null!;
        public virtual DbSet<action> action { get; set; } = null!;
        public virtual DbSet<actiongroup> actiongroup { get; set; } = null!;
        public virtual DbSet<actionhistory> actionhistory { get; set; } = null!;
        public virtual DbSet<addarea> addarea { get; set; } = null!;
        public virtual DbSet<addbuild> addbuild { get; set; } = null!;
        public virtual DbSet<addcity> addcity { get; set; } = null!;
        public virtual DbSet<addcityregion> addcityregion { get; set; } = null!;
        public virtual DbSet<addclassification> addclassification { get; set; } = null!;
        public virtual DbSet<addclassificationgroup> addclassificationgroup { get; set; } = null!;
        public virtual DbSet<addregion> addregion { get; set; } = null!;
        public virtual DbSet<address> address { get; set; } = null!;
        public virtual DbSet<addstreet> addstreet { get; set; } = null!;
        public virtual DbSet<advertisingaction> advertisingaction { get; set; } = null!;
        public virtual DbSet<advertisingactiongroup> advertisingactiongroup { get; set; } = null!;
        public virtual DbSet<agree> agree { get; set; } = null!;
        public virtual DbSet<agreement> agreement { get; set; } = null!;
        public virtual DbSet<agreementcondition> agreementcondition { get; set; } = null!;
        public virtual DbSet<agreementconditionrel> agreementconditionrel { get; set; } = null!;
        public virtual DbSet<agreementgrant> agreementgrant { get; set; } = null!;
        public virtual DbSet<alu_cityregion> alu_cityregion { get; set; } = null!;
        public virtual DbSet<availabilitygroup> availabilitygroup { get; set; } = null!;
        public virtual DbSet<budget> budget { get; set; } = null!;
        public virtual DbSet<budgetgroup> budgetgroup { get; set; } = null!;
        public virtual DbSet<businesshours> businesshours { get; set; } = null!;
        public virtual DbSet<businesshoursdetail> businesshoursdetail { get; set; } = null!;
        public virtual DbSet<calcerror> calcerror { get; set; } = null!;
        public virtual DbSet<car> car { get; set; } = null!;
        public virtual DbSet<carmarking> carmarking { get; set; } = null!;
        public virtual DbSet<carmarkingroute> carmarkingroute { get; set; } = null!;
        public virtual DbSet<cartariff> cartariff { get; set; } = null!;
        public virtual DbSet<cashbox> cashbox { get; set; } = null!;
        public virtual DbSet<coatdoc> coatdoc { get; set; } = null!;
        public virtual DbSet<coatdocgroup> coatdocgroup { get; set; } = null!;
        public virtual DbSet<coatdocpos> coatdocpos { get; set; } = null!;
        public virtual DbSet<coatdocsign> coatdocsign { get; set; } = null!;
        public virtual DbSet<color> color { get; set; } = null!;
        public virtual DbSet<coloraccordance> coloraccordance { get; set; } = null!;
        public virtual DbSet<coloraccordancedetail> coloraccordancedetail { get; set; } = null!;
        public virtual DbSet<colorgroup> colorgroup { get; set; } = null!;
        public virtual DbSet<colorgroupcustom> colorgroupcustom { get; set; } = null!;
        public virtual DbSet<colorgroupprice> colorgroupprice { get; set; } = null!;
        public virtual DbSet<colorgrouppriceitem> colorgrouppriceitem { get; set; } = null!;
        public virtual DbSet<commongroupgrant> commongroupgrant { get; set; } = null!;
        public virtual DbSet<connection> connection { get; set; } = null!;
        public virtual DbSet<connectortype> connectortype { get; set; } = null!;
        public virtual DbSet<constructiontype> constructiontype { get; set; } = null!;
        public virtual DbSet<constructiontypedetail> constructiontypedetail { get; set; } = null!;
        public virtual DbSet<customer> customer { get; set; } = null!;
        public virtual DbSet<customeraccount> customeraccount { get; set; } = null!;
        public virtual DbSet<customeraddress> customeraddress { get; set; } = null!;
        public virtual DbSet<customeragreement> customeragreement { get; set; } = null!;
        public virtual DbSet<customercategory> customercategory { get; set; } = null!;
        public virtual DbSet<customerclaim> customerclaim { get; set; } = null!;
        public virtual DbSet<customerdestanation> customerdestanation { get; set; } = null!;
        public virtual DbSet<customerdiraction> customerdiraction { get; set; } = null!;
        public virtual DbSet<customerdiscard> customerdiscard { get; set; } = null!;
        public virtual DbSet<customerevent> customerevent { get; set; } = null!;
        public virtual DbSet<customerfile> customerfile { get; set; } = null!;
        public virtual DbSet<customerform> customerform { get; set; } = null!;
        public virtual DbSet<customergroup> customergroup { get; set; } = null!;
        public virtual DbSet<customergroupgrant> customergroupgrant { get; set; } = null!;
        public virtual DbSet<customerpeople> customerpeople { get; set; } = null!;
        public virtual DbSet<customerplan> customerplan { get; set; } = null!;
        public virtual DbSet<customerpricechange> customerpricechange { get; set; } = null!;
        public virtual DbSet<customerpricechangehistory> customerpricechangehistory { get; set; } = null!;
        public virtual DbSet<customerpricepolicy> customerpricepolicy { get; set; } = null!;
        public virtual DbSet<customerpricepolicyhistory> customerpricepolicyhistory { get; set; } = null!;
        public virtual DbSet<customerrel> customerrel { get; set; } = null!;
        public virtual DbSet<customerrelation> customerrelation { get; set; } = null!;
        public virtual DbSet<customersign> customersign { get; set; } = null!;
        public virtual DbSet<customertyperel> customertyperel { get; set; } = null!;
        public virtual DbSet<delivdoc> delivdoc { get; set; } = null!;
        public virtual DbSet<delivdocdiraction> delivdocdiraction { get; set; } = null!;
        public virtual DbSet<delivdocdiractionpeople> delivdocdiractionpeople { get; set; } = null!;
        public virtual DbSet<delivdocfile> delivdocfile { get; set; } = null!;
        public virtual DbSet<delivdocgroup> delivdocgroup { get; set; } = null!;
        public virtual DbSet<delivdocpeople> delivdocpeople { get; set; } = null!;
        public virtual DbSet<delivdocpos> delivdocpos { get; set; } = null!;
        public virtual DbSet<delivdocsign> delivdocsign { get; set; } = null!;
        public virtual DbSet<department> department { get; set; } = null!;
        public virtual DbSet<departmentmember> departmentmember { get; set; } = null!;
        public virtual DbSet<designerevent> designerevent { get; set; } = null!;
        public virtual DbSet<destanation> destanation { get; set; } = null!;
        public virtual DbSet<destanationcustomer> destanationcustomer { get; set; } = null!;
        public virtual DbSet<destanationplan> destanationplan { get; set; } = null!;
        public virtual DbSet<destanationroute> destanationroute { get; set; } = null!;
        public virtual DbSet<destanationseller> destanationseller { get; set; } = null!;
        public virtual DbSet<diraction> diraction { get; set; } = null!;
        public virtual DbSet<diractiongrant> diractiongrant { get; set; } = null!;
        public virtual DbSet<diractiongroup> diractiongroup { get; set; } = null!;
        public virtual DbSet<discard> discard { get; set; } = null!;
        public virtual DbSet<discardgroup> discardgroup { get; set; } = null!;
        public virtual DbSet<docappearance> docappearance { get; set; } = null!;
        public virtual DbSet<docgroupgrant> docgroupgrant { get; set; } = null!;
        public virtual DbSet<doclock> doclock { get; set; } = null!;
        public virtual DbSet<docoper> docoper { get; set; } = null!;
        public virtual DbSet<docopergrant> docopergrant { get; set; } = null!;
        public virtual DbSet<docrelation> docrelation { get; set; } = null!;
        public virtual DbSet<docscript> docscript { get; set; } = null!;
        public virtual DbSet<docscriptgrant> docscriptgrant { get; set; } = null!;
        public virtual DbSet<docscriptgroup> docscriptgroup { get; set; } = null!;
        public virtual DbSet<docsign> docsign { get; set; } = null!;
        public virtual DbSet<docstate> docstate { get; set; } = null!;
        public virtual DbSet<docwork> docwork { get; set; } = null!;
        public virtual DbSet<docworkpeople> docworkpeople { get; set; } = null!;
        public virtual DbSet<embrasuretype> embrasuretype { get; set; } = null!;
        public virtual DbSet<embrasuretypegroup> embrasuretypegroup { get; set; } = null!;
        public virtual DbSet<equipment> equipment { get; set; } = null!;
        public virtual DbSet<equipmentdoc> equipmentdoc { get; set; } = null!;
        public virtual DbSet<equipmentdocfile> equipmentdocfile { get; set; } = null!;
        public virtual DbSet<equipmentglass> equipmentglass { get; set; } = null!;
        public virtual DbSet<equipmentgroup> equipmentgroup { get; set; } = null!;
        public virtual DbSet<equipmentper> equipmentper { get; set; } = null!;
        public virtual DbSet<equipmentprofile> equipmentprofile { get; set; } = null!;
        public virtual DbSet<equipmentprofilein> equipmentprofilein { get; set; } = null!;
        public virtual DbSet<equipmentprofileout> equipmentprofileout { get; set; } = null!;
        public virtual DbSet<error> error { get; set; } = null!;
        public virtual DbSet<errorgroup> errorgroup { get; set; } = null!;
        public virtual DbSet<errortype> errortype { get; set; } = null!;
        public virtual DbSet<files> files { get; set; } = null!;
        public virtual DbSet<finparam> finparam { get; set; } = null!;
        public virtual DbSet<finparamcalc> finparamcalc { get; set; } = null!;
        public virtual DbSet<finparamgroup> finparamgroup { get; set; } = null!;
        public virtual DbSet<furniture> furniture { get; set; } = null!;
        public virtual DbSet<furnituregoodkit> furnituregoodkit { get; set; } = null!;
        public virtual DbSet<furnituremarking> furnituremarking { get; set; } = null!;
        public virtual DbSet<ganttchart> ganttchart { get; set; } = null!;
        public virtual DbSet<generator> generator { get; set; } = null!;
        public virtual DbSet<glass> glass { get; set; } = null!;
        public virtual DbSet<glassdetail> glassdetail { get; set; } = null!;
        public virtual DbSet<glasselement> glasselement { get; set; } = null!;
        public virtual DbSet<glasselementgroup> glasselementgroup { get; set; } = null!;
        public virtual DbSet<glassgroup> glassgroup { get; set; } = null!;
        public virtual DbSet<good> good { get; set; } = null!;
        public virtual DbSet<goodanalog> goodanalog { get; set; } = null!;
        public virtual DbSet<goodanalogdetail> goodanalogdetail { get; set; } = null!;
        public virtual DbSet<goodanaloggroup> goodanaloggroup { get; set; } = null!;
        public virtual DbSet<goodbuffer> goodbuffer { get; set; } = null!;
        public virtual DbSet<goodcolorgroupprice> goodcolorgroupprice { get; set; } = null!;
        public virtual DbSet<goodcolorparam> goodcolorparam { get; set; } = null!;
        public virtual DbSet<goodgroup> goodgroup { get; set; } = null!;
        public virtual DbSet<goodkit> goodkit { get; set; } = null!;
        public virtual DbSet<goodkitdetail> goodkitdetail { get; set; } = null!;
        public virtual DbSet<goodkitgroup> goodkitgroup { get; set; } = null!;
        public virtual DbSet<goodmeasure> goodmeasure { get; set; } = null!;
        public virtual DbSet<goodoptim> goodoptim { get; set; } = null!;
        public virtual DbSet<goodost> goodost { get; set; } = null!;
        public virtual DbSet<goodparam> goodparam { get; set; } = null!;
        public virtual DbSet<goodparamname> goodparamname { get; set; } = null!;
        public virtual DbSet<goodprice> goodprice { get; set; } = null!;
        public virtual DbSet<goodpricegroup> goodpricegroup { get; set; } = null!;
        public virtual DbSet<goodpricehistory> goodpricehistory { get; set; } = null!;
        public virtual DbSet<goodservice> goodservice { get; set; } = null!;
        public virtual DbSet<goodservicegroup> goodservicegroup { get; set; } = null!;
        public virtual DbSet<goodtype> goodtype { get; set; } = null!;
        public virtual DbSet<imp_1> imp_1 { get; set; } = null!;
        public virtual DbSet<import_data> import_data { get; set; } = null!;
        public virtual DbSet<insertion> insertion { get; set; } = null!;
        public virtual DbSet<insertiondetail> insertiondetail { get; set; } = null!;
        public virtual DbSet<insertionparam> insertionparam { get; set; } = null!;
        public virtual DbSet<insertionparamdetail> insertionparamdetail { get; set; } = null!;
        public virtual DbSet<installdoc> installdoc { get; set; } = null!;
        public virtual DbSet<installdocdiraction> installdocdiraction { get; set; } = null!;
        public virtual DbSet<installdocdiractionpeople> installdocdiractionpeople { get; set; } = null!;
        public virtual DbSet<installdocfile> installdocfile { get; set; } = null!;
        public virtual DbSet<installdocgoodservice> installdocgoodservice { get; set; } = null!;
        public virtual DbSet<installdocgroup> installdocgroup { get; set; } = null!;
        public virtual DbSet<installdocpos> installdocpos { get; set; } = null!;
        public virtual DbSet<installdocsign> installdocsign { get; set; } = null!;
        public virtual DbSet<localization> localization { get; set; } = null!;
        public virtual DbSet<localizedstring> localizedstring { get; set; } = null!;
        public virtual DbSet<mailinglist> mailinglist { get; set; } = null!;
        public virtual DbSet<mailinglistondemand> mailinglistondemand { get; set; } = null!;
        public virtual DbSet<mailinglistsettings> mailinglistsettings { get; set; } = null!;
        public virtual DbSet<mailinglistusers> mailinglistusers { get; set; } = null!;
        public virtual DbSet<manufactdiraction> manufactdiraction { get; set; } = null!;
        public virtual DbSet<manufactdiractionpeople> manufactdiractionpeople { get; set; } = null!;
        public virtual DbSet<manufactdoc> manufactdoc { get; set; } = null!;
        public virtual DbSet<manufactdoccar> manufactdoccar { get; set; } = null!;
        public virtual DbSet<manufactdocgoodin> manufactdocgoodin { get; set; } = null!;
        public virtual DbSet<manufactdocgroup> manufactdocgroup { get; set; } = null!;
        public virtual DbSet<manufactdocnopyramid> manufactdocnopyramid { get; set; } = null!;
        public virtual DbSet<manufactdocorder> manufactdocorder { get; set; } = null!;
        public virtual DbSet<manufactdocpos> manufactdocpos { get; set; } = null!;
        public virtual DbSet<manufactdocpyramid> manufactdocpyramid { get; set; } = null!;
        public virtual DbSet<manufactdocpyramidpos> manufactdocpyramidpos { get; set; } = null!;
        public virtual DbSet<manufactdocsign> manufactdocsign { get; set; } = null!;
        public virtual DbSet<manufactsign> manufactsign { get; set; } = null!;
        public virtual DbSet<markingfilter> markingfilter { get; set; } = null!;
        public virtual DbSet<markingfilterdetail> markingfilterdetail { get; set; } = null!;
        public virtual DbSet<markingfiltertype> markingfiltertype { get; set; } = null!;
        public virtual DbSet<measure> measure { get; set; } = null!;
        public virtual DbSet<messages> messages { get; set; } = null!;
        public virtual DbSet<messagetype> messagetype { get; set; } = null!;
        public virtual DbSet<model> model { get; set; } = null!;
        public virtual DbSet<modelcalc> modelcalc { get; set; } = null!;
        public virtual DbSet<modelparam> modelparam { get; set; } = null!;
        public virtual DbSet<modelparamcalc> modelparamcalc { get; set; } = null!;
        public virtual DbSet<modelparamcondition> modelparamcondition { get; set; } = null!;
        public virtual DbSet<modelparamconditiondetail> modelparamconditiondetail { get; set; } = null!;
        public virtual DbSet<modelparamgroup> modelparamgroup { get; set; } = null!;
        public virtual DbSet<modelparamvalue> modelparamvalue { get; set; } = null!;
        public virtual DbSet<modelpart> modelpart { get; set; } = null!;
        public virtual DbSet<modelpic> modelpic { get; set; } = null!;
        public virtual DbSet<modelscript> modelscript { get; set; } = null!;
        public virtual DbSet<nopaper> nopaper { get; set; } = null!;
        public virtual DbSet<optimdoc> optimdoc { get; set; } = null!;
        public virtual DbSet<optimdocdiraction> optimdocdiraction { get; set; } = null!;
        public virtual DbSet<optimdocdiractionpeople> optimdocdiractionpeople { get; set; } = null!;
        public virtual DbSet<optimdocgoodin> optimdocgoodin { get; set; } = null!;
        public virtual DbSet<optimdocgoodout> optimdocgoodout { get; set; } = null!;
        public virtual DbSet<optimdocgroup> optimdocgroup { get; set; } = null!;
        public virtual DbSet<optimdocpic> optimdocpic { get; set; } = null!;
        public virtual DbSet<optimdocpos> optimdocpos { get; set; } = null!;
        public virtual DbSet<optimdocsign> optimdocsign { get; set; } = null!;
        public virtual DbSet<orderbudget> orderbudget { get; set; } = null!;
        public virtual DbSet<orderdiraction> orderdiraction { get; set; } = null!;
        public virtual DbSet<orderdiractionpeople> orderdiractionpeople { get; set; } = null!;
        public virtual DbSet<orderdiscard> orderdiscard { get; set; } = null!;
        public virtual DbSet<ordererror> ordererror { get; set; } = null!;
        public virtual DbSet<orderevent> orderevent { get; set; } = null!;
        public virtual DbSet<ordereventgroup> ordereventgroup { get; set; } = null!;
        public virtual DbSet<orderfile> orderfile { get; set; } = null!;
        public virtual DbSet<ordergood> ordergood { get; set; } = null!;
        public virtual DbSet<ordergoodservice> ordergoodservice { get; set; } = null!;
        public virtual DbSet<orderitem> orderitem { get; set; } = null!;
        public virtual DbSet<orderpricechange> orderpricechange { get; set; } = null!;
        public virtual DbSet<orders> orders { get; set; } = null!;
        public virtual DbSet<ordersetting> ordersetting { get; set; } = null!;
        public virtual DbSet<ordersgroup> ordersgroup { get; set; } = null!;
        public virtual DbSet<ordersign> ordersign { get; set; } = null!;
        public virtual DbSet<payment> payment { get; set; } = null!;
        public virtual DbSet<paymentdoc> paymentdoc { get; set; } = null!;
        public virtual DbSet<paymentdocgroup> paymentdocgroup { get; set; } = null!;
        public virtual DbSet<paymentdocsign> paymentdocsign { get; set; } = null!;
        public virtual DbSet<paymentgroup> paymentgroup { get; set; } = null!;
        public virtual DbSet<people> people { get; set; } = null!;
        public virtual DbSet<peopledate> peopledate { get; set; } = null!;
        public virtual DbSet<peopledatetime> peopledatetime { get; set; } = null!;
        public virtual DbSet<peoplegroup> peoplegroup { get; set; } = null!;
        public virtual DbSet<peoplegrouplist> peoplegrouplist { get; set; } = null!;
        public virtual DbSet<peopleparam> peopleparam { get; set; } = null!;
        public virtual DbSet<peopleparamtype> peopleparamtype { get; set; } = null!;
        public virtual DbSet<peoplepost> peoplepost { get; set; } = null!;
        public virtual DbSet<peoplepostgroup> peoplepostgroup { get; set; } = null!;
        public virtual DbSet<pf_glass> pf_glass { get; set; } = null!;
        public virtual DbSet<pf_glass_ct_source> pf_glass_ct_source { get; set; } = null!;
        public virtual DbSet<pf_glass_source_ge> pf_glass_source_ge { get; set; } = null!;
        public virtual DbSet<pf_glass_source_glass> pf_glass_source_glass { get; set; } = null!;
        public virtual DbSet<pf_ms> pf_ms { get; set; } = null!;
        public virtual DbSet<pf_ms_ct_source> pf_ms_ct_source { get; set; } = null!;
        public virtual DbSet<pf_ms_mp_filtr> pf_ms_mp_filtr { get; set; } = null!;
        public virtual DbSet<pf_ms_mp_set> pf_ms_mp_set { get; set; } = null!;
        public virtual DbSet<pf_pt> pf_pt { get; set; } = null!;
        public virtual DbSet<pf_pt_ct_source> pf_pt_ct_source { get; set; } = null!;
        public virtual DbSet<pf_pt_mp_filtr> pf_pt_mp_filtr { get; set; } = null!;
        public virtual DbSet<pf_pt_mp_set> pf_pt_mp_set { get; set; } = null!;
        public virtual DbSet<pf_stv> pf_stv { get; set; } = null!;
        public virtual DbSet<pf_stv_ct_source> pf_stv_ct_source { get; set; } = null!;
        public virtual DbSet<pf_stv_mp> pf_stv_mp { get; set; } = null!;
        public virtual DbSet<pg_1c_view_customer> pg_1c_view_customer { get; set; } = null!;
        public virtual DbSet<pg_1c_view_deliv> pg_1c_view_deliv { get; set; } = null!;
        public virtual DbSet<pg_1c_view_delivpos> pg_1c_view_delivpos { get; set; } = null!;
        public virtual DbSet<pg_1c_view_gp> pg_1c_view_gp { get; set; } = null!;
        public virtual DbSet<pg_1c_view_gp_head> pg_1c_view_gp_head { get; set; } = null!;
        public virtual DbSet<pg_1c_view_orderinfo> pg_1c_view_orderinfo { get; set; } = null!;
        public virtual DbSet<pg_1c_view_orderpos> pg_1c_view_orderpos { get; set; } = null!;
        public virtual DbSet<pg_1c_view_pay> pg_1c_view_pay { get; set; } = null!;
        public virtual DbSet<pg_1c_view_store> pg_1c_view_store { get; set; } = null!;
        public virtual DbSet<pg_1c_view_storepos> pg_1c_view_storepos { get; set; } = null!;
        public virtual DbSet<pg_1c_view_supply> pg_1c_view_supply { get; set; } = null!;
        public virtual DbSet<pg_1c_view_supplypos> pg_1c_view_supplypos { get; set; } = null!;
        public virtual DbSet<pg_lamin_condition> pg_lamin_condition { get; set; } = null!;
        public virtual DbSet<pg_view_need_good> pg_view_need_good { get; set; } = null!;
        public virtual DbSet<pg_view_payment> pg_view_payment { get; set; } = null!;
        public virtual DbSet<picture> picture { get; set; } = null!;
        public virtual DbSet<poll> poll { get; set; } = null!;
        public virtual DbSet<pollanswer> pollanswer { get; set; } = null!;
        public virtual DbSet<pollexecuting> pollexecuting { get; set; } = null!;
        public virtual DbSet<pollexecutingdiraction> pollexecutingdiraction { get; set; } = null!;
        public virtual DbSet<pollexecutinggroup> pollexecutinggroup { get; set; } = null!;
        public virtual DbSet<pollexecutingitem> pollexecutingitem { get; set; } = null!;
        public virtual DbSet<pollexecutingitemanswer> pollexecutingitemanswer { get; set; } = null!;
        public virtual DbSet<pollexecutingsign> pollexecutingsign { get; set; } = null!;
        public virtual DbSet<pollgroup> pollgroup { get; set; } = null!;
        public virtual DbSet<pollquestion> pollquestion { get; set; } = null!;
        public virtual DbSet<pollrelation> pollrelation { get; set; } = null!;
        public virtual DbSet<power> power { get; set; } = null!;
        public virtual DbSet<powergrant> powergrant { get; set; } = null!;
        public virtual DbSet<powerplan> powerplan { get; set; } = null!;
        public virtual DbSet<powerrel> powerrel { get; set; } = null!;
        public virtual DbSet<preference> preference { get; set; } = null!;
        public virtual DbSet<pricechange> pricechange { get; set; } = null!;
        public virtual DbSet<pricechangegrant> pricechangegrant { get; set; } = null!;
        public virtual DbSet<pricechangegroup> pricechangegroup { get; set; } = null!;
        public virtual DbSet<pricelist> pricelist { get; set; } = null!;
        public virtual DbSet<pricelistgoodservice> pricelistgoodservice { get; set; } = null!;
        public virtual DbSet<pricelistgroup> pricelistgroup { get; set; } = null!;
        public virtual DbSet<pricelistitem> pricelistitem { get; set; } = null!;
        public virtual DbSet<pricelistmodel> pricelistmodel { get; set; } = null!;
        public virtual DbSet<pricelistpricechange> pricelistpricechange { get; set; } = null!;
        public virtual DbSet<productiondoc> productiondoc { get; set; } = null!;
        public virtual DbSet<productiondocgroup> productiondocgroup { get; set; } = null!;
        public virtual DbSet<productiondocpos> productiondocpos { get; set; } = null!;
        public virtual DbSet<productiondocsign> productiondocsign { get; set; } = null!;
        public virtual DbSet<productionsite> productionsite { get; set; } = null!;
        public virtual DbSet<productiontype> productiontype { get; set; } = null!;
        public virtual DbSet<productiontypeconstruction> productiontypeconstruction { get; set; } = null!;
        public virtual DbSet<productiontypegrant> productiontypegrant { get; set; } = null!;
        public virtual DbSet<productiontypegroup> productiontypegroup { get; set; } = null!;
        public virtual DbSet<productiontypeparam> productiontypeparam { get; set; } = null!;
        public virtual DbSet<productiontypesetting> productiontypesetting { get; set; } = null!;
        public virtual DbSet<productiontypesystems> productiontypesystems { get; set; } = null!;
        public virtual DbSet<productiontypetemplate> productiontypetemplate { get; set; } = null!;
        public virtual DbSet<pyramid> pyramid { get; set; } = null!;
        public virtual DbSet<pyramidfact> pyramidfact { get; set; } = null!;
        public virtual DbSet<pyramidfactpos> pyramidfactpos { get; set; } = null!;
        public virtual DbSet<reg_inost> reg_inost { get; set; } = null!;
        public virtual DbSet<reg_inost_log> reg_inost_log { get; set; } = null!;
        public virtual DbSet<reg_mf> reg_mf { get; set; } = null!;
        public virtual DbSet<reg_mf_log> reg_mf_log { get; set; } = null!;
        public virtual DbSet<reg_order> reg_order { get; set; } = null!;
        public virtual DbSet<reg_ost> reg_ost { get; set; } = null!;
        public virtual DbSet<reg_ost_log> reg_ost_log { get; set; } = null!;
        public virtual DbSet<reg_ost_wl> reg_ost_wl { get; set; } = null!;
        public virtual DbSet<reg_ost_wl_log> reg_ost_wl_log { get; set; } = null!;
        public virtual DbSet<report> report { get; set; } = null!;
        public virtual DbSet<reportdocoper> reportdocoper { get; set; } = null!;
        public virtual DbSet<reportgroup> reportgroup { get; set; } = null!;
        public virtual DbSet<reportkit> reportkit { get; set; } = null!;
        public virtual DbSet<reportkitdetail> reportkitdetail { get; set; } = null!;
        public virtual DbSet<reportsave> reportsave { get; set; } = null!;
        public virtual DbSet<reportscript> reportscript { get; set; } = null!;
        public virtual DbSet<respower> respower { get; set; } = null!;
        public virtual DbSet<revisiongp> revisiongp { get; set; } = null!;
        public virtual DbSet<revisiongpitem> revisiongpitem { get; set; } = null!;
        public virtual DbSet<rightaccess> rightaccess { get; set; } = null!;
        public virtual DbSet<rotoxflugel> rotoxflugel { get; set; } = null!;
        public virtual DbSet<rotoxhouse> rotoxhouse { get; set; } = null!;
        public virtual DbSet<route> route { get; set; } = null!;
        public virtual DbSet<seller> seller { get; set; } = null!;
        public virtual DbSet<sellerdestanation> sellerdestanation { get; set; } = null!;
        public virtual DbSet<sellergrant> sellergrant { get; set; } = null!;
        public virtual DbSet<sellergroup> sellergroup { get; set; } = null!;
        public virtual DbSet<sellerpricechange> sellerpricechange { get; set; } = null!;
        public virtual DbSet<servicedepartment> servicedepartment { get; set; } = null!;
        public virtual DbSet<servicedepartmentpeople> servicedepartmentpeople { get; set; } = null!;
        public virtual DbSet<servicedoc> servicedoc { get; set; } = null!;
        public virtual DbSet<servicedocdiraction> servicedocdiraction { get; set; } = null!;
        public virtual DbSet<servicedocgroup> servicedocgroup { get; set; } = null!;
        public virtual DbSet<servicedocpos> servicedocpos { get; set; } = null!;
        public virtual DbSet<servicedocsign> servicedocsign { get; set; } = null!;
        public virtual DbSet<servicereason> servicereason { get; set; } = null!;
        public virtual DbSet<setting> setting { get; set; } = null!;
        public virtual DbSet<settinggroup> settinggroup { get; set; } = null!;
        public virtual DbSet<shtapikgroup> shtapikgroup { get; set; } = null!;
        public virtual DbSet<shtapikgroupdetail> shtapikgroupdetail { get; set; } = null!;
        public virtual DbSet<shtapikgroupparamdetail> shtapikgroupparamdetail { get; set; } = null!;
        public virtual DbSet<shtapikgroupprofile> shtapikgroupprofile { get; set; } = null!;
        public virtual DbSet<sign> sign { get; set; } = null!;
        public virtual DbSet<signgrant> signgrant { get; set; } = null!;
        public virtual DbSet<signgroup> signgroup { get; set; } = null!;
        public virtual DbSet<signvalue> signvalue { get; set; } = null!;
        public virtual DbSet<sizedoc> sizedoc { get; set; } = null!;
        public virtual DbSet<sizedocconstrtype> sizedocconstrtype { get; set; } = null!;
        public virtual DbSet<sizedocdiraction> sizedocdiraction { get; set; } = null!;
        public virtual DbSet<sizedocdiractionpeople> sizedocdiractionpeople { get; set; } = null!;
        public virtual DbSet<sizedocfile> sizedocfile { get; set; } = null!;
        public virtual DbSet<sizedocgroup> sizedocgroup { get; set; } = null!;
        public virtual DbSet<sizedocsign> sizedocsign { get; set; } = null!;
        public virtual DbSet<sourceinfo> sourceinfo { get; set; } = null!;
        public virtual DbSet<sourceinfogroup> sourceinfogroup { get; set; } = null!;
        public virtual DbSet<storagespace> storagespace { get; set; } = null!;
        public virtual DbSet<storedepart> storedepart { get; set; } = null!;
        public virtual DbSet<storedepartdocoper> storedepartdocoper { get; set; } = null!;
        public virtual DbSet<storedepartrel> storedepartrel { get; set; } = null!;
        public virtual DbSet<storedoc> storedoc { get; set; } = null!;
        public virtual DbSet<storedocgroup> storedocgroup { get; set; } = null!;
        public virtual DbSet<storedocpos> storedocpos { get; set; } = null!;
        public virtual DbSet<storedocsign> storedocsign { get; set; } = null!;
        public virtual DbSet<supplydoc> supplydoc { get; set; } = null!;
        public virtual DbSet<supplydocdiraction> supplydocdiraction { get; set; } = null!;
        public virtual DbSet<supplydocgoodservice> supplydocgoodservice { get; set; } = null!;
        public virtual DbSet<supplydocgroup> supplydocgroup { get; set; } = null!;
        public virtual DbSet<supplydocpos> supplydocpos { get; set; } = null!;
        public virtual DbSet<supplydocsign> supplydocsign { get; set; } = null!;
        public virtual DbSet<sysconnect> sysconnect { get; set; } = null!;
        public virtual DbSet<sysevent> sysevent { get; set; } = null!;
        public virtual DbSet<sysinfo> sysinfo { get; set; } = null!;
        public virtual DbSet<system> system { get; set; } = null!;
        public virtual DbSet<systemdetail> systemdetail { get; set; } = null!;
        public virtual DbSet<systemdetailrel> systemdetailrel { get; set; } = null!;
        public virtual DbSet<systemdetailrelationship> systemdetailrelationship { get; set; } = null!;
        public virtual DbSet<sysupdate> sysupdate { get; set; } = null!;
        public virtual DbSet<tablefiles> tablefiles { get; set; } = null!;
        public virtual DbSet<tariff> tariff { get; set; } = null!;
        public virtual DbSet<techdoc> techdoc { get; set; } = null!;
        public virtual DbSet<techdocdiraction> techdocdiraction { get; set; } = null!;
        public virtual DbSet<techdocgroup> techdocgroup { get; set; } = null!;
        public virtual DbSet<techdocpos> techdocpos { get; set; } = null!;
        public virtual DbSet<techdocsign> techdocsign { get; set; } = null!;
        public virtual DbSet<temp_KLADR> temp_KLADR { get; set; } = null!;
        public virtual DbSet<temp_STREET> temp_STREET { get; set; } = null!;
        public virtual DbSet<template> template { get; set; } = null!;
        public virtual DbSet<templategroup> templategroup { get; set; } = null!;
        public virtual DbSet<templateparam> templateparam { get; set; } = null!;
        public virtual DbSet<tig_view_diraction> tig_view_diraction { get; set; } = null!;
        public virtual DbSet<tig_view_diraction_date> tig_view_diraction_date { get; set; } = null!;
        public virtual DbSet<trash> trash { get; set; } = null!;
        public virtual DbSet<valut> valut { get; set; } = null!;
        public virtual DbSet<valutrate> valutrate { get; set; } = null!;
        public virtual DbSet<variant> variant { get; set; } = null!;
        public virtual DbSet<variantdetail> variantdetail { get; set; } = null!;
        public virtual DbSet<variantparam> variantparam { get; set; } = null!;
        public virtual DbSet<variantparamdetail> variantparamdetail { get; set; } = null!;
        public virtual DbSet<variantparamtype> variantparamtype { get; set; } = null!;
        public virtual DbSet<variantparamtypevalue> variantparamtypevalue { get; set; } = null!;
        public virtual DbSet<varianttype> varianttype { get; set; } = null!;
        public virtual DbSet<vectorpicture> vectorpicture { get; set; } = null!;
        public virtual DbSet<vectorpicturedetail> vectorpicturedetail { get; set; } = null!;
        public virtual DbSet<versions> versions { get; set; } = null!;
        public virtual DbSet<view_actionhistory> view_actionhistory { get; set; } = null!;
        public virtual DbSet<view_activ_goodkitgroup> view_activ_goodkitgroup { get; set; } = null!;
        public virtual DbSet<view_addarea> view_addarea { get; set; } = null!;
        public virtual DbSet<view_addbuild> view_addbuild { get; set; } = null!;
        public virtual DbSet<view_addcity> view_addcity { get; set; } = null!;
        public virtual DbSet<view_addcityregion> view_addcityregion { get; set; } = null!;
        public virtual DbSet<view_address> view_address { get; set; } = null!;
        public virtual DbSet<view_address_forfind> view_address_forfind { get; set; } = null!;
        public virtual DbSet<view_addstreet> view_addstreet { get; set; } = null!;
        public virtual DbSet<view_adresselement> view_adresselement { get; set; } = null!;
        public virtual DbSet<view_advertisingaction> view_advertisingaction { get; set; } = null!;
        public virtual DbSet<view_agree> view_agree { get; set; } = null!;
        public virtual DbSet<view_agreementgrant> view_agreementgrant { get; set; } = null!;
        public virtual DbSet<view_allgoodfrommodel> view_allgoodfrommodel { get; set; } = null!;
        public virtual DbSet<view_allgoodfromorder> view_allgoodfromorder { get; set; } = null!;
        public virtual DbSet<view_allgoodfromorderprice> view_allgoodfromorderprice { get; set; } = null!;
        public virtual DbSet<view_alu_cityregion> view_alu_cityregion { get; set; } = null!;
        public virtual DbSet<view_car> view_car { get; set; } = null!;
        public virtual DbSet<view_carmarking> view_carmarking { get; set; } = null!;
        public virtual DbSet<view_cashbox> view_cashbox { get; set; } = null!;
        public virtual DbSet<view_coatdoc> view_coatdoc { get; set; } = null!;
        public virtual DbSet<view_coatdocpos> view_coatdocpos { get; set; } = null!;
        public virtual DbSet<view_coatdocsign> view_coatdocsign { get; set; } = null!;
        public virtual DbSet<view_color> view_color { get; set; } = null!;
        public virtual DbSet<view_commongroupgrant> view_commongroupgrant { get; set; } = null!;
        public virtual DbSet<view_constructiontype> view_constructiontype { get; set; } = null!;
        public virtual DbSet<view_customer> view_customer { get; set; } = null!;
        public virtual DbSet<view_customerdestanation> view_customerdestanation { get; set; } = null!;
        public virtual DbSet<view_customerdiraction> view_customerdiraction { get; set; } = null!;
        public virtual DbSet<view_customerdiscard> view_customerdiscard { get; set; } = null!;
        public virtual DbSet<view_customergroupgrant> view_customergroupgrant { get; set; } = null!;
        public virtual DbSet<view_customerpeople> view_customerpeople { get; set; } = null!;
        public virtual DbSet<view_customerpricechange> view_customerpricechange { get; set; } = null!;
        public virtual DbSet<view_customerpricechangehistory> view_customerpricechangehistory { get; set; } = null!;
        public virtual DbSet<view_customerpricepolicy> view_customerpricepolicy { get; set; } = null!;
        public virtual DbSet<view_customerpricepolicyhistory> view_customerpricepolicyhistory { get; set; } = null!;
        public virtual DbSet<view_customerrel> view_customerrel { get; set; } = null!;
        public virtual DbSet<view_customersign> view_customersign { get; set; } = null!;
        public virtual DbSet<view_delivdoc> view_delivdoc { get; set; } = null!;
        public virtual DbSet<view_delivdocdiraction> view_delivdocdiraction { get; set; } = null!;
        public virtual DbSet<view_delivdocdiractionpeople> view_delivdocdiractionpeople { get; set; } = null!;
        public virtual DbSet<view_delivdocpeople> view_delivdocpeople { get; set; } = null!;
        public virtual DbSet<view_delivdocpos> view_delivdocpos { get; set; } = null!;
        public virtual DbSet<view_delivdocsign> view_delivdocsign { get; set; } = null!;
        public virtual DbSet<view_departmentmember> view_departmentmember { get; set; } = null!;
        public virtual DbSet<view_destanation> view_destanation { get; set; } = null!;
        public virtual DbSet<view_destanationcustomer> view_destanationcustomer { get; set; } = null!;
        public virtual DbSet<view_destanationseller> view_destanationseller { get; set; } = null!;
        public virtual DbSet<view_diractiongrant_data> view_diractiongrant_data { get; set; } = null!;
        public virtual DbSet<view_diractiongroup_from_grants> view_diractiongroup_from_grants { get; set; } = null!;
        public virtual DbSet<view_discard> view_discard { get; set; } = null!;
        public virtual DbSet<view_docgroupgrant> view_docgroupgrant { get; set; } = null!;
        public virtual DbSet<view_doclock> view_doclock { get; set; } = null!;
        public virtual DbSet<view_docoper> view_docoper { get; set; } = null!;
        public virtual DbSet<view_docopergrant> view_docopergrant { get; set; } = null!;
        public virtual DbSet<view_docscriptgrant> view_docscriptgrant { get; set; } = null!;
        public virtual DbSet<view_docsign> view_docsign { get; set; } = null!;
        public virtual DbSet<view_docstate> view_docstate { get; set; } = null!;
        public virtual DbSet<view_docwork> view_docwork { get; set; } = null!;
        public virtual DbSet<view_docworkpeople> view_docworkpeople { get; set; } = null!;
        public virtual DbSet<view_dopgood_fromorder> view_dopgood_fromorder { get; set; } = null!;
        public virtual DbSet<view_equipmentdoc> view_equipmentdoc { get; set; } = null!;
        public virtual DbSet<view_equipmentdocfile> view_equipmentdocfile { get; set; } = null!;
        public virtual DbSet<view_equipmentdocfile1> view_equipmentdocfile1 { get; set; } = null!;
        public virtual DbSet<view_equipmentglass> view_equipmentglass { get; set; } = null!;
        public virtual DbSet<view_error> view_error { get; set; } = null!;
        public virtual DbSet<view_errorgroup> view_errorgroup { get; set; } = null!;
        public virtual DbSet<view_errortype> view_errortype { get; set; } = null!;
        public virtual DbSet<view_files> view_files { get; set; } = null!;
        public virtual DbSet<view_finparamcalc> view_finparamcalc { get; set; } = null!;
        public virtual DbSet<view_glass> view_glass { get; set; } = null!;
        public virtual DbSet<view_glassdetail> view_glassdetail { get; set; } = null!;
        public virtual DbSet<view_good> view_good { get; set; } = null!;
        public virtual DbSet<view_goodanalogdetail> view_goodanalogdetail { get; set; } = null!;
        public virtual DbSet<view_goodbuffer> view_goodbuffer { get; set; } = null!;
        public virtual DbSet<view_goodcolorgroupprice> view_goodcolorgroupprice { get; set; } = null!;
        public virtual DbSet<view_goodcolorparam> view_goodcolorparam { get; set; } = null!;
        public virtual DbSet<view_goodkitdetail> view_goodkitdetail { get; set; } = null!;
        public virtual DbSet<view_goodmeasure> view_goodmeasure { get; set; } = null!;
        public virtual DbSet<view_goodoptim> view_goodoptim { get; set; } = null!;
        public virtual DbSet<view_goodost> view_goodost { get; set; } = null!;
        public virtual DbSet<view_goodprice> view_goodprice { get; set; } = null!;
        public virtual DbSet<view_goodservice> view_goodservice { get; set; } = null!;
        public virtual DbSet<view_installdoc> view_installdoc { get; set; } = null!;
        public virtual DbSet<view_installdocdiraction> view_installdocdiraction { get; set; } = null!;
        public virtual DbSet<view_installdocdiractionpeople> view_installdocdiractionpeople { get; set; } = null!;
        public virtual DbSet<view_installdocgoodservice> view_installdocgoodservice { get; set; } = null!;
        public virtual DbSet<view_installdocpos> view_installdocpos { get; set; } = null!;
        public virtual DbSet<view_installdocsign> view_installdocsign { get; set; } = null!;
        public virtual DbSet<view_manufactdiraction> view_manufactdiraction { get; set; } = null!;
        public virtual DbSet<view_manufactdiractionpeople> view_manufactdiractionpeople { get; set; } = null!;
        public virtual DbSet<view_manufactdoc> view_manufactdoc { get; set; } = null!;
        public virtual DbSet<view_manufactdocmodelpic> view_manufactdocmodelpic { get; set; } = null!;
        public virtual DbSet<view_manufactdocpos> view_manufactdocpos { get; set; } = null!;
        public virtual DbSet<view_manufactdocpos_plan> view_manufactdocpos_plan { get; set; } = null!;
        public virtual DbSet<view_manufactdocpyramid> view_manufactdocpyramid { get; set; } = null!;
        public virtual DbSet<view_manufactdocsign> view_manufactdocsign { get; set; } = null!;
        public virtual DbSet<view_manufactsign> view_manufactsign { get; set; } = null!;
        public virtual DbSet<view_markingfilterdetail> view_markingfilterdetail { get; set; } = null!;
        public virtual DbSet<view_measure> view_measure { get; set; } = null!;
        public virtual DbSet<view_message> view_message { get; set; } = null!;
        public virtual DbSet<view_model> view_model { get; set; } = null!;
        public virtual DbSet<view_modelcalc> view_modelcalc { get; set; } = null!;
        public virtual DbSet<view_modelparam> view_modelparam { get; set; } = null!;
        public virtual DbSet<view_modelparamcalc> view_modelparamcalc { get; set; } = null!;
        public virtual DbSet<view_modelpic> view_modelpic { get; set; } = null!;
        public virtual DbSet<view_modelscript> view_modelscript { get; set; } = null!;
        public virtual DbSet<view_nopaper> view_nopaper { get; set; } = null!;
        public virtual DbSet<view_optimdoc> view_optimdoc { get; set; } = null!;
        public virtual DbSet<view_optimdocdiraction> view_optimdocdiraction { get; set; } = null!;
        public virtual DbSet<view_optimdocdiractionpeople> view_optimdocdiractionpeople { get; set; } = null!;
        public virtual DbSet<view_optimdocgoodin> view_optimdocgoodin { get; set; } = null!;
        public virtual DbSet<view_optimdocgoodout> view_optimdocgoodout { get; set; } = null!;
        public virtual DbSet<view_optimdocpic> view_optimdocpic { get; set; } = null!;
        public virtual DbSet<view_optimdocpos> view_optimdocpos { get; set; } = null!;
        public virtual DbSet<view_optimdocsign> view_optimdocsign { get; set; } = null!;
        public virtual DbSet<view_orderbudget> view_orderbudget { get; set; } = null!;
        public virtual DbSet<view_orderdiraction> view_orderdiraction { get; set; } = null!;
        public virtual DbSet<view_orderdiractionpeople> view_orderdiractionpeople { get; set; } = null!;
        public virtual DbSet<view_ordererror> view_ordererror { get; set; } = null!;
        public virtual DbSet<view_ordergood> view_ordergood { get; set; } = null!;
        public virtual DbSet<view_ordergoodservice> view_ordergoodservice { get; set; } = null!;
        public virtual DbSet<view_orderitem> view_orderitem { get; set; } = null!;
        public virtual DbSet<view_orderitem_model> view_orderitem_model { get; set; } = null!;
        public virtual DbSet<view_orderitem_ordergood> view_orderitem_ordergood { get; set; } = null!;
        public virtual DbSet<view_orderitem_pc_good> view_orderitem_pc_good { get; set; } = null!;
        public virtual DbSet<view_orderpricechange> view_orderpricechange { get; set; } = null!;
        public virtual DbSet<view_orders> view_orders { get; set; } = null!;
        public virtual DbSet<view_orders_pricechange> view_orders_pricechange { get; set; } = null!;
        public virtual DbSet<view_ordersign> view_ordersign { get; set; } = null!;
        public virtual DbSet<view_ordersmodelpic> view_ordersmodelpic { get; set; } = null!;
        public virtual DbSet<view_payment> view_payment { get; set; } = null!;
        public virtual DbSet<view_paymentdoc> view_paymentdoc { get; set; } = null!;
        public virtual DbSet<view_paymentdocsign> view_paymentdocsign { get; set; } = null!;
        public virtual DbSet<view_people> view_people { get; set; } = null!;
        public virtual DbSet<view_peoplegrouplist> view_peoplegrouplist { get; set; } = null!;
        public virtual DbSet<view_pok_diraction_date> view_pok_diraction_date { get; set; } = null!;
        public virtual DbSet<view_poll> view_poll { get; set; } = null!;
        public virtual DbSet<view_pollanswer> view_pollanswer { get; set; } = null!;
        public virtual DbSet<view_pollexecuting> view_pollexecuting { get; set; } = null!;
        public virtual DbSet<view_pollexecutingdiraction> view_pollexecutingdiraction { get; set; } = null!;
        public virtual DbSet<view_pollexecutingitem> view_pollexecutingitem { get; set; } = null!;
        public virtual DbSet<view_pollexecutingitemanswer> view_pollexecutingitemanswer { get; set; } = null!;
        public virtual DbSet<view_pollexecutingsign> view_pollexecutingsign { get; set; } = null!;
        public virtual DbSet<view_pollquestion> view_pollquestion { get; set; } = null!;
        public virtual DbSet<view_pollrelation> view_pollrelation { get; set; } = null!;
        public virtual DbSet<view_power> view_power { get; set; } = null!;
        public virtual DbSet<view_powergrant> view_powergrant { get; set; } = null!;
        public virtual DbSet<view_pricechange> view_pricechange { get; set; } = null!;
        public virtual DbSet<view_pricechangegrant> view_pricechangegrant { get; set; } = null!;
        public virtual DbSet<view_pricelist> view_pricelist { get; set; } = null!;
        public virtual DbSet<view_pricelistgoodservice> view_pricelistgoodservice { get; set; } = null!;
        public virtual DbSet<view_pricelistpricechange> view_pricelistpricechange { get; set; } = null!;
        public virtual DbSet<view_productiondoc> view_productiondoc { get; set; } = null!;
        public virtual DbSet<view_productiondocpos> view_productiondocpos { get; set; } = null!;
        public virtual DbSet<view_productiondocsign> view_productiondocsign { get; set; } = null!;
        public virtual DbSet<view_productiontype> view_productiontype { get; set; } = null!;
        public virtual DbSet<view_productiontypeconstruction> view_productiontypeconstruction { get; set; } = null!;
        public virtual DbSet<view_productiontypegrant> view_productiontypegrant { get; set; } = null!;
        public virtual DbSet<view_productiontypegroup> view_productiontypegroup { get; set; } = null!;
        public virtual DbSet<view_productiontypeparam> view_productiontypeparam { get; set; } = null!;
        public virtual DbSet<view_productiontypesetting> view_productiontypesetting { get; set; } = null!;
        public virtual DbSet<view_productiontypesystems> view_productiontypesystems { get; set; } = null!;
        public virtual DbSet<view_pyramid> view_pyramid { get; set; } = null!;
        public virtual DbSet<view_pyramidfact> view_pyramidfact { get; set; } = null!;
        public virtual DbSet<view_pyramidfactpos> view_pyramidfactpos { get; set; } = null!;
        public virtual DbSet<view_report> view_report { get; set; } = null!;
        public virtual DbSet<view_reportkitdetail> view_reportkitdetail { get; set; } = null!;
        public virtual DbSet<view_reportsave> view_reportsave { get; set; } = null!;
        public virtual DbSet<view_respower> view_respower { get; set; } = null!;
        public virtual DbSet<view_seller> view_seller { get; set; } = null!;
        public virtual DbSet<view_sellerdestanation> view_sellerdestanation { get; set; } = null!;
        public virtual DbSet<view_sellergrant> view_sellergrant { get; set; } = null!;
        public virtual DbSet<view_sellerpricechange> view_sellerpricechange { get; set; } = null!;
        public virtual DbSet<view_servicedepartment> view_servicedepartment { get; set; } = null!;
        public virtual DbSet<view_servicedepartmentpeople> view_servicedepartmentpeople { get; set; } = null!;
        public virtual DbSet<view_servicedoc> view_servicedoc { get; set; } = null!;
        public virtual DbSet<view_servicedocdiraction> view_servicedocdiraction { get; set; } = null!;
        public virtual DbSet<view_servicedocpos> view_servicedocpos { get; set; } = null!;
        public virtual DbSet<view_servicedocsign> view_servicedocsign { get; set; } = null!;
        public virtual DbSet<view_servicereason> view_servicereason { get; set; } = null!;
        public virtual DbSet<view_setting> view_setting { get; set; } = null!;
        public virtual DbSet<view_signgrant_data> view_signgrant_data { get; set; } = null!;
        public virtual DbSet<view_signgroup_from_grants> view_signgroup_from_grants { get; set; } = null!;
        public virtual DbSet<view_signvalue> view_signvalue { get; set; } = null!;
        public virtual DbSet<view_sizedoc> view_sizedoc { get; set; } = null!;
        public virtual DbSet<view_sizedocconstrtype> view_sizedocconstrtype { get; set; } = null!;
        public virtual DbSet<view_sizedocdiraction> view_sizedocdiraction { get; set; } = null!;
        public virtual DbSet<view_sizedocdiractionpeople> view_sizedocdiractionpeople { get; set; } = null!;
        public virtual DbSet<view_sizedocsign> view_sizedocsign { get; set; } = null!;
        public virtual DbSet<view_storedepart> view_storedepart { get; set; } = null!;
        public virtual DbSet<view_storedoc> view_storedoc { get; set; } = null!;
        public virtual DbSet<view_storedocpos> view_storedocpos { get; set; } = null!;
        public virtual DbSet<view_storedocsign> view_storedocsign { get; set; } = null!;
        public virtual DbSet<view_supplydoc> view_supplydoc { get; set; } = null!;
        public virtual DbSet<view_supplydocdiraction> view_supplydocdiraction { get; set; } = null!;
        public virtual DbSet<view_supplydocgoodservice> view_supplydocgoodservice { get; set; } = null!;
        public virtual DbSet<view_supplydocpos> view_supplydocpos { get; set; } = null!;
        public virtual DbSet<view_supplydocsign> view_supplydocsign { get; set; } = null!;
        public virtual DbSet<view_sysconnect> view_sysconnect { get; set; } = null!;
        public virtual DbSet<view_systemdetail> view_systemdetail { get; set; } = null!;
        public virtual DbSet<view_systemdetailrel> view_systemdetailrel { get; set; } = null!;
        public virtual DbSet<view_systemdetailrelation> view_systemdetailrelation { get; set; } = null!;
        public virtual DbSet<view_systemdetailrelationship> view_systemdetailrelationship { get; set; } = null!;
        public virtual DbSet<view_techdoc> view_techdoc { get; set; } = null!;
        public virtual DbSet<view_techdocdiraction> view_techdocdiraction { get; set; } = null!;
        public virtual DbSet<view_techdocpos> view_techdocpos { get; set; } = null!;
        public virtual DbSet<view_techdocsign> view_techdocsign { get; set; } = null!;
        public virtual DbSet<view_template> view_template { get; set; } = null!;
        public virtual DbSet<view_templateparam> view_templateparam { get; set; } = null!;
        public virtual DbSet<view_tig_diraction> view_tig_diraction { get; set; } = null!;
        public virtual DbSet<view_valutrate> view_valutrate { get; set; } = null!;
        public virtual DbSet<view_vectorpicture> view_vectorpicture { get; set; } = null!;
        public virtual DbSet<view_versions> view_versions { get; set; } = null!;
        public virtual DbSet<view_wdlog> view_wdlog { get; set; } = null!;
        public virtual DbSet<view_work> view_work { get; set; } = null!;
        public virtual DbSet<view_workgroup> view_workgroup { get; set; } = null!;
        public virtual DbSet<view_workoper> view_workoper { get; set; } = null!;
        public virtual DbSet<view_workpeople> view_workpeople { get; set; } = null!;
        public virtual DbSet<wdlog> wdlog { get; set; } = null!;
        public virtual DbSet<work> work { get; set; } = null!;
        public virtual DbSet<workgroup> workgroup { get; set; } = null!;
        public virtual DbSet<workoper> workoper { get; set; } = null!;
        public virtual DbSet<workpeople> workpeople { get; set; } = null!;
        public virtual DbSet<wreportaccess> wreportaccess { get; set; } = null!;
        public virtual DbSet<wreportlist> wreportlist { get; set; } = null!;
        public virtual DbSet<wreportlocation> wreportlocation { get; set; } = null!;
        public virtual DbSet<wreportlogs> wreportlogs { get; set; } = null!;
        public virtual DbSet<wreportsensor> wreportsensor { get; set; } = null!;
        public virtual DbSet<wreportsettings> wreportsettings { get; set; } = null!;
        public virtual DbSet<wreporttemperature> wreporttemperature { get; set; } = null!;
        public virtual DbSet<wreporttemperature2> wreporttemperature2 { get; set; } = null!;
        public virtual DbSet<wreporttest> wreporttest { get; set; } = null!;
        public virtual DbSet<wreportwoper> wreportwoper { get; set; } = null!;
        public virtual DbSet<wreportworks> wreportworks { get; set; } = null!;
        public virtual DbSet<wtempsitedata> wtempsitedata { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Password=6Sijz5bHA;Persist Security Info=True;User ID=StepanIvanov;Initial Catalog=ecad_plastplus;Data Source=localhost\\SQLSERVER;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<__view_people>(entity =>
            {
                entity.ToView("__view_people");
            });

            modelBuilder.Entity<action>(entity =>
            {
                entity.Property(e => e.idaction).ValueGeneratedNever();
            });

            modelBuilder.Entity<actiongroup>(entity =>
            {
                entity.Property(e => e.idactiongroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<actionhistory>(entity =>
            {
                entity.Property(e => e.idactionhistory).ValueGeneratedNever();
            });

            modelBuilder.Entity<addarea>(entity =>
            {
                entity.Property(e => e.idaddarea).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idaddregionNavigation)
                    .WithMany(p => p.addarea)
                    .HasForeignKey(d => d.idaddregion)
                    .HasConstraintName("FK_addarea_addregion");
            });

            modelBuilder.Entity<addbuild>(entity =>
            {
                entity.HasComment("Таблица зданий");

                entity.Property(e => e.idaddbuild)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.deleted).HasComment("Признак удаления");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idaddcityregion).HasComment("Ссылка на район города(в некоторых городах улица может проходить через несколько районов города)");

                entity.Property(e => e.idaddstreet).HasComment("Ссылка на улицу");

                entity.Property(e => e.name).HasComment("Номер здания");

                entity.HasOne(d => d.idaddcityregionNavigation)
                    .WithMany(p => p.addbuild)
                    .HasForeignKey(d => d.idaddcityregion)
                    .HasConstraintName("FK_addbuild_addcityregion");

                entity.HasOne(d => d.idaddstreetNavigation)
                    .WithMany(p => p.addbuild)
                    .HasForeignKey(d => d.idaddstreet)
                    .HasConstraintName("FK_addbuild_addstreet");
            });

            modelBuilder.Entity<addcity>(entity =>
            {
                entity.Property(e => e.idaddcity).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.shortname).HasComment("Сокращённое наименование");

                entity.HasOne(d => d.idaddareaNavigation)
                    .WithMany(p => p.addcity)
                    .HasForeignKey(d => d.idaddarea)
                    .HasConstraintName("FK_addcity_addarea");
            });

            modelBuilder.Entity<addcityregion>(entity =>
            {
                entity.Property(e => e.idaddcityregion).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idaddcityNavigation)
                    .WithMany(p => p.addcityregion)
                    .HasForeignKey(d => d.idaddcity)
                    .HasConstraintName("FK_addcityregion_addcity");
            });

            modelBuilder.Entity<addclassification>(entity =>
            {
                entity.Property(e => e.idaddclassification).ValueGeneratedNever();

                entity.HasOne(d => d.idaddclassificationgroupNavigation)
                    .WithMany(p => p.addclassification)
                    .HasForeignKey(d => d.idaddclassificationgroup)
                    .HasConstraintName("FK_addclassification_addclassificationgroup");
            });

            modelBuilder.Entity<addclassificationgroup>(entity =>
            {
                entity.Property(e => e.idaddclassificationgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<addregion>(entity =>
            {
                entity.Property(e => e.idaddregion).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<address>(entity =>
            {
                entity.HasComment("Справочник адресов");

                entity.Property(e => e.idaddress)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.addinfo).HasComment("Дополнительная информация");

                entity.Property(e => e.apartment).HasComment("Квартира");

                entity.Property(e => e.build).HasComment("№ дома");

                entity.Property(e => e.building).HasComment("Корпус, строение, индекс...");

                entity.Property(e => e.deleted).HasComment("Признак удалённости");

                entity.Property(e => e.doorway).HasComment("Подъезд");

                entity.Property(e => e.floor).HasComment("Этаж");

                entity.Property(e => e.freightlift).HasComment("Наличие грузового лифта");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idaddarea).HasComment("Ссылка на край/область");

                entity.Property(e => e.idaddcity).HasComment("Ссылка на город");

                entity.Property(e => e.idaddcityregion).HasComment("Ссылка на район города");

                entity.Property(e => e.idaddregion).HasComment("Ссылка на регион");

                entity.Property(e => e.idaddstreet).HasComment("Ссылка на улицу");

                entity.Property(e => e.passengerlift).HasComment("Наличие пассажирского лифта");
            });

            modelBuilder.Entity<addstreet>(entity =>
            {
                entity.Property(e => e.idaddstreet).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idaddcityregionNavigation)
                    .WithMany(p => p.addstreet)
                    .HasForeignKey(d => d.idaddcityregion)
                    .HasConstraintName("FK_addstreet_addcityregion");
            });

            modelBuilder.Entity<advertisingaction>(entity =>
            {
                entity.HasComment("Справочник рекламных акций");

                entity.Property(e => e.idadvertisingaction)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Удалена");

                entity.Property(e => e.dtfinish).HasComment("Дата окончания");

                entity.Property(e => e.dtstart).HasComment("Дата начала");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idadvertisingactiongroup).HasComment("Ссылка на группу");

                entity.Property(e => e.name).HasComment("Наименование акции");

                entity.Property(e => e.perc).HasComment("Процент");

                entity.Property(e => e.sm).HasComment("Сумма");

                entity.HasOne(d => d.idadvertisingactiongroupNavigation)
                    .WithMany(p => p.advertisingaction)
                    .HasForeignKey(d => d.idadvertisingactiongroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_advertisingaction_advertisingactiongroup");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.advertisingaction)
                    .HasForeignKey(d => d.idvalut)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_advertisingaction_valut");
            });

            modelBuilder.Entity<advertisingactiongroup>(entity =>
            {
                entity.HasComment("Группы рекламных акций");

                entity.Property(e => e.idadvertisingactiongroup)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Удалена");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.name).HasComment("Наименование группы");

                entity.Property(e => e.parentid).HasComment("Ссылка на родителя");
            });

            modelBuilder.Entity<agree>(entity =>
            {
                entity.Property(e => e.idagree).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.agree)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_agree_customer");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.agree)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_agree_people");
            });

            modelBuilder.Entity<agreement>(entity =>
            {
                entity.Property(e => e.idagreement).ValueGeneratedNever();

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.agreement)
                    .HasForeignKey(d => d.idseller)
                    .HasConstraintName("FK_agreement_seller");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.agreement)
                    .HasForeignKey(d => d.idvalut)
                    .HasConstraintName("FK_agreement_valut");
            });

            modelBuilder.Entity<agreementcondition>(entity =>
            {
                entity.Property(e => e.idagreementcondition).ValueGeneratedNever();
            });

            modelBuilder.Entity<agreementconditionrel>(entity =>
            {
                entity.Property(e => e.idagreementconditionrel).ValueGeneratedNever();

                entity.HasOne(d => d.idagreementNavigation)
                    .WithMany(p => p.agreementconditionrel)
                    .HasForeignKey(d => d.idagreement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_agreementconditionrel_agreement");

                entity.HasOne(d => d.idagreementconditionNavigation)
                    .WithMany(p => p.agreementconditionrel)
                    .HasForeignKey(d => d.idagreementcondition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_agreementconditionrel_agreementcondition");
            });

            modelBuilder.Entity<agreementgrant>(entity =>
            {
                entity.Property(e => e.idagreementgrant).ValueGeneratedNever();

                entity.HasOne(d => d.idagreementNavigation)
                    .WithMany(p => p.agreementgrant)
                    .HasForeignKey(d => d.idagreement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_agreementgrant_agreement");

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.agreementgrant)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_agreementgrant_peoplegroup");
            });

            modelBuilder.Entity<alu_cityregion>(entity =>
            {
                entity.Property(e => e.idaddcityregion).ValueGeneratedNever();

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.alu_cityregion)
                    .HasForeignKey(d => d.iddestanation)
                    .HasConstraintName("FK_alu_cityregion_destanation");
            });

            modelBuilder.Entity<availabilitygroup>(entity =>
            {
                entity.Property(e => e.idavailabilitygroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<budget>(entity =>
            {
                entity.Property(e => e.idbudget).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idbudgetgroupNavigation)
                    .WithMany(p => p.budget)
                    .HasForeignKey(d => d.idbudgetgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_budget_budgetgroup");
            });

            modelBuilder.Entity<budgetgroup>(entity =>
            {
                entity.Property(e => e.idbudgetgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<businesshours>(entity =>
            {
                entity.Property(e => e.idbusinesshours).ValueGeneratedNever();
            });

            modelBuilder.Entity<businesshoursdetail>(entity =>
            {
                entity.Property(e => e.idbusinesshoursdetail).ValueGeneratedNever();

                entity.HasOne(d => d.idbusinesshoursNavigation)
                    .WithMany(p => p.businesshoursdetail)
                    .HasForeignKey(d => d.idbusinesshours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_businesshoursdetail_businesshours");
            });

            modelBuilder.Entity<calcerror>(entity =>
            {
                entity.Property(e => e.idcalcerror).ValueGeneratedNever();

                entity.HasOne(d => d.iderrorNavigation)
                    .WithMany(p => p.calcerror)
                    .HasForeignKey(d => d.iderror)
                    .HasConstraintName("FK_calcerror_error");
            });

            modelBuilder.Entity<car>(entity =>
            {
                entity.HasComment("Справочник автомобилей");

                entity.Property(e => e.idcar)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Дата и время удаления");

                entity.Property(e => e.guid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Глобальный идентификатор для репликации");

                entity.Property(e => e.idcarmarking).HasComment("Ссылка на марку автомобиля");

                entity.Property(e => e.idpyramid).HasComment("Ссылка на пирамиду");

                entity.Property(e => e.name).HasComment("Наименование");

                entity.Property(e => e.statesign).HasComment("Гос.номер");

                entity.HasOne(d => d.idcarmarkingNavigation)
                    .WithMany(p => p.car)
                    .HasForeignKey(d => d.idcarmarking)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_car_carmarking");

                entity.HasOne(d => d.idproductionsiteNavigation)
                    .WithMany(p => p.car)
                    .HasForeignKey(d => d.idproductionsite)
                    .HasConstraintName("FK_car_idproductionsite");

                entity.HasOne(d => d.idtariffNavigation)
                    .WithMany(p => p.car)
                    .HasForeignKey(d => d.idtariff)
                    .HasConstraintName("FK_car_idtariff");
            });

            modelBuilder.Entity<carmarking>(entity =>
            {
                entity.HasComment("Справочник марок автомобилей");

                entity.Property(e => e.idcarmarking)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Дата и время удаления");

                entity.Property(e => e.guid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Глобальный идентификатор для репликации");

                entity.Property(e => e.name).HasComment("Наименование");
            });

            modelBuilder.Entity<carmarkingroute>(entity =>
            {
                entity.Property(e => e.idcarmarkingroute).ValueGeneratedNever();

                entity.HasOne(d => d.idcarmarkingNavigation)
                    .WithMany(p => p.carmarkingroute)
                    .HasForeignKey(d => d.idcarmarking)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_carmarkingroute_carmarking");

                entity.HasOne(d => d.idrouteNavigation)
                    .WithMany(p => p.carmarkingroute)
                    .HasForeignKey(d => d.idroute)
                    .HasConstraintName("FK_carmarkingroute_route");
            });

            modelBuilder.Entity<cartariff>(entity =>
            {
                entity.Property(e => e.idcartariff).ValueGeneratedNever();

                entity.HasOne(d => d.idcarNavigation)
                    .WithMany(p => p.cartariff)
                    .HasForeignKey(d => d.idcar)
                    .HasConstraintName("FK_cartariff_car");

                entity.HasOne(d => d.idtariffNavigation)
                    .WithMany(p => p.cartariff)
                    .HasForeignKey(d => d.idtariff)
                    .HasConstraintName("FK_cartariff_tariff");
            });

            modelBuilder.Entity<cashbox>(entity =>
            {
                entity.Property(e => e.idcashbox).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.cashbox)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_cashbox_people");
            });

            modelBuilder.Entity<coatdoc>(entity =>
            {
                entity.Property(e => e.idcoatdoc).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.coatdoc)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_coatdoc_customer");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.coatdoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_coatdoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.coatdoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_coatdoc_docstate");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.coatdoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_coatdoc_people");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.coatdoc)
                    .HasForeignKey(d => d.idstoredepart)
                    .HasConstraintName("FK_coatdoc_storedepart");
            });

            modelBuilder.Entity<coatdocgroup>(entity =>
            {
                entity.Property(e => e.idcoatdocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<coatdocpos>(entity =>
            {
                entity.Property(e => e.idcoatdocpos).ValueGeneratedNever();

                entity.HasOne(d => d.idcoatdocNavigation)
                    .WithMany(p => p.coatdocpos)
                    .HasForeignKey(d => d.idcoatdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_coatdocpos_coatdoc");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.coatdocpos)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_coatdocpos_good");
            });

            modelBuilder.Entity<coatdocsign>(entity =>
            {
                entity.Property(e => e.idcoatdocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idcoatdocNavigation)
                    .WithMany(p => p.coatdocsign)
                    .HasForeignKey(d => d.idcoatdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_coatdocsign_coatdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.coatdocsign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_coatdocsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.coatdocsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_coatdocsign_sign");
            });

            modelBuilder.Entity<color>(entity =>
            {
                entity.Property(e => e.idcolor).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcolorgroupNavigation)
                    .WithMany(p => p.color)
                    .HasForeignKey(d => d.idcolorgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_color_colorgroup");
            });

            modelBuilder.Entity<coloraccordance>(entity =>
            {
                entity.Property(e => e.idcoloraccordance).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorNavigation)
                    .WithMany(p => p.coloraccordance)
                    .HasForeignKey(d => d.idcolor)
                    .HasConstraintName("FK_coloraccordance_color");
            });

            modelBuilder.Entity<coloraccordancedetail>(entity =>
            {
                entity.Property(e => e.idcoloraccordancedetail).ValueGeneratedNever();

                entity.HasOne(d => d.idcoloraccordanceNavigation)
                    .WithMany(p => p.coloraccordancedetail)
                    .HasForeignKey(d => d.idcoloraccordance)
                    .HasConstraintName("FK_coloraccordancedetail_coloraccordance");

                entity.HasOne(d => d.idcolordestNavigation)
                    .WithMany(p => p.coloraccordancedetailidcolordestNavigation)
                    .HasForeignKey(d => d.idcolordest)
                    .HasConstraintName("FK_coloraccordancedetail_color_dest");

                entity.HasOne(d => d.idcolorsourceNavigation)
                    .WithMany(p => p.coloraccordancedetailidcolorsourceNavigation)
                    .HasForeignKey(d => d.idcolorsource)
                    .HasConstraintName("FK_coloraccordancedetail_color_sorce");

                entity.HasOne(d => d.idcolorsource2Navigation)
                    .WithMany(p => p.coloraccordancedetailidcolorsource2Navigation)
                    .HasForeignKey(d => d.idcolorsource2)
                    .HasConstraintName("FK_coloraccordancedetail_color_source2");
            });

            modelBuilder.Entity<colorgroup>(entity =>
            {
                entity.Property(e => e.idcolorgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<colorgroupcustom>(entity =>
            {
                entity.Property(e => e.idcolorgroupcustom).ValueGeneratedNever();
            });

            modelBuilder.Entity<colorgroupprice>(entity =>
            {
                entity.Property(e => e.idcolorgroupprice).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorgroupcustomNavigation)
                    .WithMany(p => p.colorgroupprice)
                    .HasForeignKey(d => d.idcolorgroupcustom)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_colorgroupprice_colorgroupcustom");
            });

            modelBuilder.Entity<colorgrouppriceitem>(entity =>
            {
                entity.Property(e => e.idcolorgrouppriceitem).ValueGeneratedNever();

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany(p => p.colorgrouppriceitemidcolor1Navigation)
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_colorgrouppriceitem_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany(p => p.colorgrouppriceitemidcolor2Navigation)
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_colorgrouppriceitem_color2");

                entity.HasOne(d => d.idcolorgrouppriceNavigation)
                    .WithMany(p => p.colorgrouppriceitem)
                    .HasForeignKey(d => d.idcolorgroupprice)
                    .HasConstraintName("FK_colorgrouppriceitem_colorgroupprice");
            });

            modelBuilder.Entity<commongroupgrant>(entity =>
            {
                entity.Property(e => e.idcommongroupgrant).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<connection>(entity =>
            {
                entity.Property(e => e.idconnection).ValueGeneratedNever();

                entity.HasOne(d => d.idsystemdetail1Navigation)
                    .WithMany(p => p.connectionidsystemdetail1Navigation)
                    .HasForeignKey(d => d.idsystemdetail1)
                    .HasConstraintName("FK_connection_systemdetail1");

                entity.HasOne(d => d.idsystemdetail2Navigation)
                    .WithMany(p => p.connectionidsystemdetail2Navigation)
                    .HasForeignKey(d => d.idsystemdetail2)
                    .HasConstraintName("FK_connection_systemdetail2");
            });

            modelBuilder.Entity<connectortype>(entity =>
            {
                entity.Property(e => e.idconnectortype).ValueGeneratedNever();
            });

            modelBuilder.Entity<constructiontype>(entity =>
            {
                entity.Property(e => e.idconstructiontype).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.constructiontype)
                    .HasForeignKey(d => d.idversion)
                    .HasConstraintName("FK_constructiontype_versions");
            });

            modelBuilder.Entity<constructiontypedetail>(entity =>
            {
                entity.Property(e => e.idconstructiontypedetail).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.constructiontypedetail)
                    .HasForeignKey(d => d.idconstructiontype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_constructiontypedetail_constructiontype");

                entity.HasOne(d => d.idmodelpartNavigation)
                    .WithMany(p => p.constructiontypedetail)
                    .HasForeignKey(d => d.idmodelpart)
                    .HasConstraintName("FK_constructiontypedetail_modelpart");

                entity.HasOne(d => d.idsystemNavigation)
                    .WithMany(p => p.constructiontypedetail)
                    .HasForeignKey(d => d.idsystem)
                    .HasConstraintName("FK_constructiontypedetail_system");

                entity.HasOne(d => d.idsystemdetailNavigation)
                    .WithMany(p => p.constructiontypedetail)
                    .HasForeignKey(d => d.idsystemdetail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_constructiontypedetail_systemdetail");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.constructiontypedetail)
                    .HasForeignKey(d => d.idversion)
                    .HasConstraintName("FK_constructiontypedetail_versions");
            });

            modelBuilder.Entity<customer>(entity =>
            {
                entity.HasKey(e => e.idcustomer)
                    .HasName("pk_customer");

                entity.Property(e => e.idcustomer)
                    .ValueGeneratedNever()
                    .HasComment("");

                entity.Property(e => e.addresslegal).HasComment("Юр.адрес");

                entity.Property(e => e.birthday).HasComment("Дата рождения");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idaddresslegal).HasComment("Ссылка на юр.адрес из КЛАДР");

                entity.Property(e => e.idsourceinfo).HasComment("Ссылка на источник информации");

                entity.Property(e => e.name2).HasComment("Альтернативное наименование контрагента");

                entity.Property(e => e.name3).HasComment("Краткое наименование контрагента");

                entity.Property(e => e.passportdate).HasComment("Дата выдачи паспорт");

                entity.Property(e => e.passportexit).HasComment("Кем выдан паспорт");

                entity.Property(e => e.passportnum).HasComment("Номер паспорта");

                entity.Property(e => e.passportseries).HasComment("Серия паспорта");

                entity.Property(e => e.phonehome).HasComment("Телефон домашний");

                entity.Property(e => e.phonemobile).HasComment("Телефон мобильный");

                entity.HasOne(d => d.idaddclassification1Navigation)
                    .WithMany(p => p.customeridaddclassification1Navigation)
                    .HasForeignKey(d => d.idaddclassification1)
                    .HasConstraintName("FK_customer_addclassification1");

                entity.HasOne(d => d.idaddclassification2Navigation)
                    .WithMany(p => p.customeridaddclassification2Navigation)
                    .HasForeignKey(d => d.idaddclassification2)
                    .HasConstraintName("FK_customer_addclassification2");

                entity.HasOne(d => d.idaddclassification3Navigation)
                    .WithMany(p => p.customeridaddclassification3Navigation)
                    .HasForeignKey(d => d.idaddclassification3)
                    .HasConstraintName("FK_customer_addclassification3");

                entity.HasOne(d => d.idaddclassification4Navigation)
                    .WithMany(p => p.customeridaddclassification4Navigation)
                    .HasForeignKey(d => d.idaddclassification4)
                    .HasConstraintName("FK_customer_addclassification4");

                entity.HasOne(d => d.idaddclassification5Navigation)
                    .WithMany(p => p.customeridaddclassification5Navigation)
                    .HasForeignKey(d => d.idaddclassification5)
                    .HasConstraintName("FK_customer_addclassification5");

                entity.HasOne(d => d.idaddressNavigation)
                    .WithMany(p => p.customeridaddressNavigation)
                    .HasForeignKey(d => d.idaddress)
                    .HasConstraintName("FK_customer_address");

                entity.HasOne(d => d.idaddresslegalNavigation)
                    .WithMany(p => p.customeridaddresslegalNavigation)
                    .HasForeignKey(d => d.idaddresslegal)
                    .HasConstraintName("FK_customer_address_legal");

                entity.HasOne(d => d.idagreementNavigation)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.idagreement)
                    .HasConstraintName("FK_customer_agreement");

                entity.HasOne(d => d.idcustomercategoryNavigation)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.idcustomercategory)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customer_customercategory");

                entity.HasOne(d => d.idcustomerformNavigation)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.idcustomerform)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_customer_customerform");

                entity.HasOne(d => d.idcustomergroupNavigation)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.idcustomergroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customer_customergroup");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.iddocoper)
                    .HasConstraintName("FK_customer_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_customer_docstate");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.customeridpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_customer_people");

                entity.HasOne(d => d.idpeople2Navigation)
                    .WithMany(p => p.customeridpeople2Navigation)
                    .HasForeignKey(d => d.idpeople2)
                    .HasConstraintName("FK_customer_idpeople2");

                entity.HasOne(d => d.idpeople3Navigation)
                    .WithMany(p => p.customeridpeople3Navigation)
                    .HasForeignKey(d => d.idpeople3)
                    .HasConstraintName("FK_customer_idpeople3");

                entity.HasOne(d => d.idpeople4Navigation)
                    .WithMany(p => p.customeridpeople4Navigation)
                    .HasForeignKey(d => d.idpeople4)
                    .HasConstraintName("FK_customer_idpeople4");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.idseller)
                    .HasConstraintName("FK_customer_seller");

                entity.HasOne(d => d.idsourceinfoNavigation)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.idsourceinfo)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_customer_sourceinfo");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.idvalut)
                    .HasConstraintName("FK_customer_idvalut");
            });

            modelBuilder.Entity<customeraccount>(entity =>
            {
                entity.Property(e => e.idcustomeraccount).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customeraccount)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customeraccount_customer");
            });

            modelBuilder.Entity<customeraddress>(entity =>
            {
                entity.Property(e => e.idcustomeraddress).ValueGeneratedNever();

                entity.HasOne(d => d.idaddressNavigation)
                    .WithMany(p => p.customeraddress)
                    .HasForeignKey(d => d.idaddress)
                    .HasConstraintName("FK_customeraddress_address");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customeraddress)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_customeraddress_customer");
            });

            modelBuilder.Entity<customeragreement>(entity =>
            {
                entity.Property(e => e.idcustomeragreement).ValueGeneratedNever();

                entity.HasOne(d => d.idagreementNavigation)
                    .WithMany(p => p.customeragreement)
                    .HasForeignKey(d => d.idagreement)
                    .HasConstraintName("FK_customeragreement_agreement");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customeragreement)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_customeragreement_customer");
            });

            modelBuilder.Entity<customercategory>(entity =>
            {
                entity.Property(e => e.idcustomercategory).ValueGeneratedNever();
            });

            modelBuilder.Entity<customerclaim>(entity =>
            {
                entity.Property(e => e.idcustomerclaim).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerclaim)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerclaim_customer");
            });

            modelBuilder.Entity<customerdestanation>(entity =>
            {
                entity.Property(e => e.idcustomerdestanation).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerdestanation)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_customerdestanation_customer");

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.customerdestanation)
                    .HasForeignKey(d => d.iddestanation)
                    .HasConstraintName("FK_customerdestanation_destanation");
            });

            modelBuilder.Entity<customerdiraction>(entity =>
            {
                entity.Property(e => e.idcustomerdiraction).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerdiraction)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_customerdiraction_customer");

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.customerdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .HasConstraintName("FK_customerdiraction_diraction");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.customerdiractionidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_customerdiraction_people");

                entity.HasOne(d => d.idpeopleeditNavigation)
                    .WithMany(p => p.customerdiractionidpeopleeditNavigation)
                    .HasForeignKey(d => d.idpeopleedit)
                    .HasConstraintName("FK_customerdiraction_people_edit");

                entity.HasOne(d => d.idpeopleсreateNavigation)
                    .WithMany(p => p.customerdiractionidpeopleсreateNavigation)
                    .HasForeignKey(d => d.idpeopleсreate)
                    .HasConstraintName("FK_customerdiraction_people_create");
            });

            modelBuilder.Entity<customerdiscard>(entity =>
            {
                entity.Property(e => e.idcustomerdiscard).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerdiscard)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerdiscard_customer");

                entity.HasOne(d => d.iddiscardNavigation)
                    .WithMany(p => p.customerdiscard)
                    .HasForeignKey(d => d.iddiscard)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerdiscard_discard");
            });

            modelBuilder.Entity<customerevent>(entity =>
            {
                entity.Property(e => e.idcustomerevent).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerevent)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerevent_customer");
            });

            modelBuilder.Entity<customerfile>(entity =>
            {
                entity.Property(e => e.idcustomerfile).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerfile)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerfile_customer");
            });

            modelBuilder.Entity<customerform>(entity =>
            {
                entity.Property(e => e.idcustomerform).ValueGeneratedNever();
            });

            modelBuilder.Entity<customergroup>(entity =>
            {
                entity.HasKey(e => e.idcustomergroup)
                    .HasName("pk_customergroup");

                entity.Property(e => e.idcustomergroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<customergroupgrant>(entity =>
            {
                entity.HasComment("Таблица прав на группы документов");

                entity.Property(e => e.idcustomergroupgrant)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.allow).HasComment("Разрешить доступ");

                entity.Property(e => e.dany).HasComment("Запретить доступ");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idcustomergroup).HasComment("Группа контрагентов");

                entity.Property(e => e.idpeople).HasComment("Пользователь");

                entity.Property(e => e.idpeoplegroup).HasComment("Группа пользователей");
            });

            modelBuilder.Entity<customerpeople>(entity =>
            {
                entity.Property(e => e.idcustomerpeople).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idpeoplepost).HasComment("Должность сотрудника");

                entity.Property(e => e.ismain).HasComment("Основной сотрудник");

                entity.Property(e => e.numpos).HasComment("Номер по порядку");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerpeople)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerpeople_customer");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.customerpeople)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_customerpeople_people");

                entity.HasOne(d => d.idpeoplepostNavigation)
                    .WithMany(p => p.customerpeople)
                    .HasForeignKey(d => d.idpeoplepost)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_customerpeople_peoplepost");
            });

            modelBuilder.Entity<customerplan>(entity =>
            {
                entity.Property(e => e.idcustomerplan).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerplan)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerplan_customer");
            });

            modelBuilder.Entity<customerpricechange>(entity =>
            {
                entity.HasComment("Скидки\\наценки контрагентов");

                entity.Property(e => e.idcustomerpricechange)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.guid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Глобальный идентификатор");

                entity.Property(e => e.idcustomer).HasComment("Ссылка на контрагента");

                entity.Property(e => e.idpricechange).HasComment("Ссылка на скидку\\наценку");

                entity.Property(e => e.idseller).HasComment("Ссылка на продавца");

                entity.Property(e => e.price1).HasComment("Значение скидки\\наценки");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerpricechange)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerpricechange_customer");

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.customerpricechange)
                    .HasForeignKey(d => d.idpricechange)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerpricechange_pricechange");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.customerpricechange)
                    .HasForeignKey(d => d.idseller)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customerpricechange_seller");
            });

            modelBuilder.Entity<customerpricechangehistory>(entity =>
            {
                entity.Property(e => e.idcustomerpricechangehistory).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerpricechangehistory)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_customerpricechangehistory_customer");

                entity.HasOne(d => d.idcustomerpricechangeNavigation)
                    .WithMany(p => p.customerpricechangehistory)
                    .HasForeignKey(d => d.idcustomerpricechange)
                    .HasConstraintName("FK_customerpricechangehistory_customerpricechange");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.customerpricechangehistory)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_customerpricechangehistory_people");

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.customerpricechangehistory)
                    .HasForeignKey(d => d.idpricechange)
                    .HasConstraintName("FK_customerpricechangehistory_pricechange");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.customerpricechangehistory)
                    .HasForeignKey(d => d.idseller)
                    .HasConstraintName("FK_customerpricechangehistory_seller");
            });

            modelBuilder.Entity<customerpricepolicy>(entity =>
            {
                entity.Property(e => e.idcustomerpricepolicy).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerpricepolicy)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_customerpricepolicy_customer");

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.customerpricepolicy)
                    .HasForeignKey(d => d.idpricechange)
                    .HasConstraintName("FK_customerpricepolicy_pricechange");
            });

            modelBuilder.Entity<customerpricepolicyhistory>(entity =>
            {
                entity.Property(e => e.idcustomerpricepolicyhistory).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customerpricepolicyhistory)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_customerpricepolicyhistory_customer");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.customerpricepolicyhistory)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_customerpricepolicyhistory_people");

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.customerpricepolicyhistory)
                    .HasForeignKey(d => d.idpricechange)
                    .HasConstraintName("FK_customerpricepolicyhistory_pricechange");
            });

            modelBuilder.Entity<customerrel>(entity =>
            {
                entity.Property(e => e.idcustomerrel).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerchildNavigation)
                    .WithMany(p => p.customerrelidcustomerchildNavigation)
                    .HasForeignKey(d => d.idcustomerchild)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customerrel_customer_child");

                entity.HasOne(d => d.idcustomerparentNavigation)
                    .WithMany(p => p.customerrelidcustomerparentNavigation)
                    .HasForeignKey(d => d.idcustomerparent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customerrel_customer_parent");

                entity.HasOne(d => d.idcustomertyperelNavigation)
                    .WithMany(p => p.customerrel)
                    .HasForeignKey(d => d.idcustomertyperel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customerrel_customertyperel");

                entity.HasOne(d => d.idpeopleeditNavigation)
                    .WithMany(p => p.customerrel)
                    .HasForeignKey(d => d.idpeopleedit)
                    .HasConstraintName("FK_customerrel_people");
            });

            modelBuilder.Entity<customerrelation>(entity =>
            {
                entity.Property(e => e.idcustomerrelation).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<customersign>(entity =>
            {
                entity.Property(e => e.idcustomersign).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.customersign)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customersign_customer");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.customersign)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_customersign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.customersign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_customersign_sign");
            });

            modelBuilder.Entity<customertyperel>(entity =>
            {
                entity.Property(e => e.idcustomertyperel).ValueGeneratedNever();
            });

            modelBuilder.Entity<delivdoc>(entity =>
            {
                entity.HasKey(e => e.iddelivdoc)
                    .HasName("PK_delivdoc_1");

                entity.Property(e => e.iddelivdoc).ValueGeneratedNever();

                entity.Property(e => e.contact).HasComment("Контактное лицо");

                entity.Property(e => e.phone).HasComment("Телефон");

                entity.HasOne(d => d.idaddressNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.idaddress)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdoc_address");

                entity.HasOne(d => d.idcarNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.idcar)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdoc_car");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdoc_customer");

                entity.HasOne(d => d.iddelivdocgroupNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.iddelivdocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdoc_delivdocgroup");

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.iddestanation)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdoc_destanation");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_delivdoc_docstate");

                entity.HasOne(d => d.idmanufactdoccarNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.idmanufactdoccar)
                    .HasConstraintName("FK_delivdoc_manufactdoccar");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdoc_orders");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.delivdocidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdoc_people");

                entity.HasOne(d => d.idpeople2Navigation)
                    .WithMany(p => p.delivdocidpeople2Navigation)
                    .HasForeignKey(d => d.idpeople2)
                    .HasConstraintName("FK_delivdoc_people1");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.idstoredepart)
                    .HasConstraintName("FK_delivdoc_storedepart");

                entity.HasOne(d => d.idtariffNavigation)
                    .WithMany(p => p.delivdoc)
                    .HasForeignKey(d => d.idtariff)
                    .HasConstraintName("FK_delivdoc_idtariff");

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentid)
                    .HasConstraintName("FK_delivdoc_parentid");
            });

            modelBuilder.Entity<delivdocdiraction>(entity =>
            {
                entity.Property(e => e.iddelivdocdiraction).ValueGeneratedNever();

                entity.HasOne(d => d.iddelivdocNavigation)
                    .WithMany(p => p.delivdocdiraction)
                    .HasForeignKey(d => d.iddelivdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocdiraction_delivdoc");

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.delivdocdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocdiraction_diraction");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.delivdocdiractionidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdocdiraction_people");

                entity.HasOne(d => d.idpeopleeditNavigation)
                    .WithMany(p => p.delivdocdiractionidpeopleeditNavigation)
                    .HasForeignKey(d => d.idpeopleedit)
                    .HasConstraintName("FK_delivdocdiraction_people2");
            });

            modelBuilder.Entity<delivdocdiractionpeople>(entity =>
            {
                entity.Property(e => e.iddelivdocdiractionpeople).ValueGeneratedNever();

                entity.HasOne(d => d.iddelivdocdiractionNavigation)
                    .WithMany(p => p.delivdocdiractionpeople)
                    .HasForeignKey(d => d.iddelivdocdiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocdiractionpeople_delivdocdiraction");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.delivdocdiractionpeople)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_delivdocdiractionpeople_people");
            });

            modelBuilder.Entity<delivdocfile>(entity =>
            {
                entity.Property(e => e.iddelivdocfile).ValueGeneratedNever();

                entity.HasOne(d => d.iddelivdocNavigation)
                    .WithMany(p => p.delivdocfile)
                    .HasForeignKey(d => d.iddelivdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocfile_delivdoc");
            });

            modelBuilder.Entity<delivdocgroup>(entity =>
            {
                entity.HasKey(e => e.iddelivdocgroup)
                    .HasName("PK_delivdoc");

                entity.Property(e => e.iddelivdocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<delivdocpeople>(entity =>
            {
                entity.Property(e => e.iddelivdocpeople).ValueGeneratedNever();

                entity.HasOne(d => d.iddelivdocNavigation)
                    .WithMany(p => p.delivdocpeople)
                    .HasForeignKey(d => d.iddelivdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocpeople_delivdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.delivdocpeopleidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdocpeople_people");

                entity.HasOne(d => d.idpeople2Navigation)
                    .WithMany(p => p.delivdocpeopleidpeople2Navigation)
                    .HasForeignKey(d => d.idpeople2)
                    .HasConstraintName("FK_delivdocpeople_people1");
            });

            modelBuilder.Entity<delivdocpos>(entity =>
            {
                entity.HasIndex(e => e.iddelivdoc, "idx_delivdocpos_iddelivdoc")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.idgood, "idx_delivdocpos_idgood")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.idmodelcalc, "idx_delivdocpos_idmodelcalc")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.idordergood, "idx_delivdocpos_idordergood")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.idorderitem, "idx_delivdocpos_idorderitem")
                    .HasFillFactor(80);

                entity.Property(e => e.iddelivdocpos).ValueGeneratedNever();

                entity.HasOne(d => d.iddelivdocNavigation)
                    .WithMany(p => p.delivdocpos)
                    .HasForeignKey(d => d.iddelivdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocpos_delivdoc");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.delivdocpos)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocpos_good");

                entity.HasOne(d => d.idmanufactdocposNavigation)
                    .WithMany(p => p.delivdocpos)
                    .HasForeignKey(d => d.idmanufactdocpos)
                    .HasConstraintName("FK_delivdocpos_manufactdocpos");

                entity.HasOne(d => d.idmodelcalcNavigation)
                    .WithMany(p => p.delivdocpos)
                    .HasForeignKey(d => d.idmodelcalc)
                    .HasConstraintName("FK_delivdocpos_modelcalc");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.delivdocpos)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_delivdocpos_order");

                entity.HasOne(d => d.idordergoodNavigation)
                    .WithMany(p => p.delivdocpos)
                    .HasForeignKey(d => d.idordergood)
                    .HasConstraintName("FK_delivdocpos_ordergood");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.delivdocpos)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocpos_orderitem");

                entity.HasOne(d => d.idstoredocNavigation)
                    .WithMany(p => p.delivdocpos)
                    .HasForeignKey(d => d.idstoredoc)
                    .HasConstraintName("FK_delivdocpos_storedoc");
            });

            modelBuilder.Entity<delivdocsign>(entity =>
            {
                entity.Property(e => e.iddelivdocsign).ValueGeneratedNever();

                entity.HasOne(d => d.iddelivdocNavigation)
                    .WithMany(p => p.delivdocsign)
                    .HasForeignKey(d => d.iddelivdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocsign_delivdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.delivdocsign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_delivdocsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.delivdocsign)
                    .HasForeignKey(d => d.idsign)
                    .HasConstraintName("FK_delivdocsign_sign");

                entity.HasOne(d => d.idsignvalueNavigation)
                    .WithMany(p => p.delivdocsign)
                    .HasForeignKey(d => d.idsignvalue)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_delivdocsign_signvalue");
            });

            modelBuilder.Entity<department>(entity =>
            {
                entity.HasComment("Таблица отделов");

                entity.Property(e => e.iddepartment)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.addint).HasComment("Дополнительное число");

                entity.Property(e => e.addstr).HasComment("Дополнительная строка");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Дата удаления записи");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.name).HasComment("Нименование отдела");
            });

            modelBuilder.Entity<departmentmember>(entity =>
            {
                entity.HasComment("Состав подразделений");

                entity.Property(e => e.iddepartmentmember)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.deleted).HasComment("Дата удаления");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.iddepartment).HasComment("Ссылка на подразделение");

                entity.Property(e => e.idpeople).HasComment("Ссылка на сотрудника");

                entity.HasOne(d => d.iddepartmentNavigation)
                    .WithMany(p => p.departmentmember)
                    .HasForeignKey(d => d.iddepartment)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_departmentmember_department");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.departmentmember)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_departmentmember_people");
            });

            modelBuilder.Entity<designerevent>(entity =>
            {
                entity.Property(e => e.iddesignerevent).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<destanation>(entity =>
            {
                entity.Property(e => e.iddestanation).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idpreferenceNavigation)
                    .WithMany(p => p.destanation)
                    .HasForeignKey(d => d.idpreference)
                    .HasConstraintName("FK_destanation_preference");

                entity.HasOne(d => d.idproductionsiteNavigation)
                    .WithMany(p => p.destanation)
                    .HasForeignKey(d => d.idproductionsite)
                    .HasConstraintName("FK_destanation_productionsite");

                entity.HasOne(d => d.idpyram)
                    .WithMany(p => p.destanation)
                    .HasForeignKey(d => d.idpyramid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_destanation_pyramid");

                entity.HasOne(d => d.idrouteNavigation)
                    .WithMany(p => p.destanation)
                    .HasForeignKey(d => d.idroute)
                    .HasConstraintName("FK_destanation_route");
            });

            modelBuilder.Entity<destanationcustomer>(entity =>
            {
                entity.Property(e => e.iddestanationcustomer).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.destanationcustomer)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_destanationcustomer_customer");

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.destanationcustomer)
                    .HasForeignKey(d => d.iddestanation)
                    .HasConstraintName("FK_destanationcustomer_destanation");
            });

            modelBuilder.Entity<destanationplan>(entity =>
            {
                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.destanationplan)
                    .HasForeignKey(d => d.iddestanation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_destanationplan_destanation");
            });

            modelBuilder.Entity<destanationroute>(entity =>
            {
                entity.Property(e => e.iddestanationroute).ValueGeneratedNever();

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.destanationroute)
                    .HasForeignKey(d => d.iddestanation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_destanationroute_destanation");

                entity.HasOne(d => d.idrouteNavigation)
                    .WithMany(p => p.destanationroute)
                    .HasForeignKey(d => d.idroute)
                    .HasConstraintName("FK_destanationroute_route");
            });

            modelBuilder.Entity<destanationseller>(entity =>
            {
                entity.Property(e => e.iddestanationseller).ValueGeneratedNever();

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.destanationseller)
                    .HasForeignKey(d => d.iddestanation)
                    .HasConstraintName("FK_destanationseller_destanationseller");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.destanationseller)
                    .HasForeignKey(d => d.idseller)
                    .HasConstraintName("FK_destanationseller_seller");
            });

            modelBuilder.Entity<diraction>(entity =>
            {
                entity.HasKey(e => e.iddiraction)
                    .HasName("pk_diraction");

                entity.Property(e => e.iddiraction).ValueGeneratedNever();

                entity.Property(e => e.addtooptimdoc).HasDefaultValueSql("((0))");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.iddiractiongroupNavigation)
                    .WithMany(p => p.diraction)
                    .HasForeignKey(d => d.iddiractiongroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_diraction_diractiongroup");
            });

            modelBuilder.Entity<diractiongrant>(entity =>
            {
                entity.HasComment("Права на этапы");

                entity.Property(e => e.iddiractiongrant)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.deleted).HasComment("Признак удаления");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.iddiraction).HasComment("Ссылка на этап");

                entity.Property(e => e.iddocoper).HasComment("Ссылка на тип документа");

                entity.Property(e => e.idpeoplegroup).HasComment("Ссылка на группу пользователей");

                entity.Property(e => e.isadd).HasComment("Права на добавление");

                entity.Property(e => e.iseditcomment).HasComment("Права на редактирование комментария");

                entity.Property(e => e.iseditexecutor).HasComment("Права на редактирование исполнителей");

                entity.Property(e => e.iseditfact).HasComment("Права на редактирование фактической даты");

                entity.Property(e => e.iseditplan).HasComment("Права на редактирование плановой даты");

                entity.Property(e => e.isremove).HasComment("Права на удаление");

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.diractiongrant)
                    .HasForeignKey(d => d.iddiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_diractiongrant_diraction");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.diractiongrant)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_diractiongrant_docoper");

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.diractiongrant)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_diractiongrant_peoplegroup");
            });

            modelBuilder.Entity<diractiongroup>(entity =>
            {
                entity.Property(e => e.iddiractiongroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<discard>(entity =>
            {
                entity.Property(e => e.iddiscard).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.iddiscardgroupNavigation)
                    .WithMany(p => p.discard)
                    .HasForeignKey(d => d.iddiscardgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_discard_discardgroup");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.discard)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_discard_people");
            });

            modelBuilder.Entity<discardgroup>(entity =>
            {
                entity.HasComment("Группы дисконтных карт");

                entity.Property(e => e.iddiscardgroup)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Удалена");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.name).HasComment("Наименование группы");

                entity.Property(e => e.parentid).HasComment("Ссылка на родителя");

                entity.Property(e => e.perc).HasComment("Процент скидки");

                entity.Property(e => e.sm).HasComment("Сумма скидки");
            });

            modelBuilder.Entity<docappearance>(entity =>
            {
                entity.Property(e => e.iddocappearance).ValueGeneratedNever();
            });

            modelBuilder.Entity<docgroupgrant>(entity =>
            {
                entity.HasComment("Таблица прав на группы документов");

                entity.Property(e => e.iddocgroupgrant)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.allow).HasComment("Разрешить доступ");

                entity.Property(e => e.dany).HasComment("Запретить доступ");

                entity.Property(e => e.iddocappearance).HasComment("Вид документа");

                entity.Property(e => e.idpeople).HasComment("Пользователь");

                entity.Property(e => e.idpeoplegroup).HasComment("Группа пользователей");

                entity.HasOne(d => d.iddocappearanceNavigation)
                    .WithMany(p => p.docgroupgrant)
                    .HasForeignKey(d => d.iddocappearance)
                    .HasConstraintName("FK_docgroupgrant_docappearance");
            });

            modelBuilder.Entity<doclock>(entity =>
            {
                entity.Property(e => e.iddoclock).ValueGeneratedNever();

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.doclock)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_doclock_docoper");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.doclock)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_doclock_people");
            });

            modelBuilder.Entity<docoper>(entity =>
            {
                entity.HasKey(e => e.iddocoper)
                    .HasName("pk_docoper");

                entity.Property(e => e.iddocoper).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.indealerbase).HasComment("Переносить в дилерскую версию");

                entity.HasOne(d => d.idproductionsiteNavigation)
                    .WithMany(p => p.docoper)
                    .HasForeignKey(d => d.idproductionsite)
                    .HasConstraintName("FK_docoper_productionsite");
            });

            modelBuilder.Entity<docopergrant>(entity =>
            {
                entity.Property(e => e.iddocopergrant).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.docopergrant)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_docopergrant_docoper");

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.docopergrant)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_docopergrant_peoplegroup");
            });

            modelBuilder.Entity<docrelation>(entity =>
            {
                entity.HasComment("Таблица связей между документами");

                entity.Property(e => e.iddocrelation)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.deleted).HasComment("Дата удаления связи");

                entity.Property(e => e.idchilddoc).HasComment("Ссылка на документ потомок");

                entity.Property(e => e.iddocappearancechild).HasComment("Вид документа потомка");

                entity.Property(e => e.iddocappearanceparent).HasComment("Вид документа родителя");

                entity.Property(e => e.idparentdoc).HasComment("Ссылка на документ родитель");
            });

            modelBuilder.Entity<docscript>(entity =>
            {
                entity.Property(e => e.iddocscript).ValueGeneratedNever();

                entity.Property(e => e.indealerbase).HasComment("Переносить в дилерскую версию");

                entity.HasOne(d => d.iddocscriptgroupNavigation)
                    .WithMany(p => p.docscript)
                    .HasForeignKey(d => d.iddocscriptgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_docscript_docscriptgroup");
            });

            modelBuilder.Entity<docscriptgrant>(entity =>
            {
                entity.Property(e => e.iddocscriptgrant).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.iddocappearanceNavigation)
                    .WithMany(p => p.docscriptgrant)
                    .HasForeignKey(d => d.iddocappearance)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_docscriptgrant_doсoper");

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.docscriptgrant)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_docscriptgrant_peoplegroup");
            });

            modelBuilder.Entity<docscriptgroup>(entity =>
            {
                entity.Property(e => e.iddocscriptgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.numpos).HasComment("Номер по порядку");
            });

            modelBuilder.Entity<docsign>(entity =>
            {
                entity.ToView("docsign");
            });

            modelBuilder.Entity<docstate>(entity =>
            {
                entity.Property(e => e.iddocstate).ValueGeneratedNever();

                entity.HasOne(d => d.iddocappearanceNavigation)
                    .WithMany(p => p.docstate)
                    .HasForeignKey(d => d.iddocappearance)
                    .HasConstraintName("FK_docstate_docappearance");
            });

            modelBuilder.Entity<docwork>(entity =>
            {
                entity.Property(e => e.iddocwork).ValueGeneratedNever();

                entity.Property(e => e.dtcreate).HasComment("Дата и время создания");

                entity.Property(e => e.dtedit).HasComment("Дата и время изменения");

                entity.Property(e => e.iddocitem).HasComment("Ссылка на позицию документа");

                entity.Property(e => e.idpeople).HasComment("Ссылка на сотрудника создавшего работу");

                entity.Property(e => e.idpeopleedit).HasComment("Ссылка на сотрудника изменившего работу");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.docwork)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_docwork_people");

                entity.HasOne(d => d.idworkNavigation)
                    .WithMany(p => p.docwork)
                    .HasForeignKey(d => d.idwork)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_docwork_work");

                entity.HasOne(d => d.idworkoperNavigation)
                    .WithMany(p => p.docwork)
                    .HasForeignKey(d => d.idworkoper)
                    .HasConstraintName("FK_docwork_workoper");
            });

            modelBuilder.Entity<docworkpeople>(entity =>
            {
                entity.HasComment("Таблица исполнителей работ по документу");

                entity.Property(e => e.iddocworkpeople)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.deleted).HasComment("Дата и время удаления");

                entity.Property(e => e.iddocwork).HasComment("Ссылка на работу документа");

                entity.Property(e => e.idpeople).HasComment("Ссылка на исполнителя(справочник сотрудников)");

                entity.HasOne(d => d.iddocworkNavigation)
                    .WithMany(p => p.docworkpeople)
                    .HasForeignKey(d => d.iddocwork)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_docworkpeople_docwork");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.docworkpeople)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_docworkpeople_people");
            });

            modelBuilder.Entity<embrasuretype>(entity =>
            {
                entity.HasComment("Справочник типов проёмов");

                entity.Property(e => e.idembrasuretype)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Признак удаления");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idembrasuretypegroup).HasComment("Ссылка на группу");

                entity.Property(e => e.name).HasComment("Наименование типа проёма");

                entity.Property(e => e.shortname).HasComment("Сокращённое наименование");

                entity.HasOne(d => d.idembrasuretypegroupNavigation)
                    .WithMany(p => p.embrasuretype)
                    .HasForeignKey(d => d.idembrasuretypegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_embrasuretype_embrasuretypegroup");
            });

            modelBuilder.Entity<embrasuretypegroup>(entity =>
            {
                entity.HasComment("Группы типов проёмов");

                entity.Property(e => e.idembrasuretypegroup)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Признак удалённости");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.isactive)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Активность группы");

                entity.Property(e => e.name).HasComment("Наименование");

                entity.Property(e => e.parentid).HasComment("Ссылка на родительскую группу");
            });

            modelBuilder.Entity<equipment>(entity =>
            {
                entity.Property(e => e.idequipment).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idequipmentgroupNavigation)
                    .WithMany(p => p.equipment)
                    .HasForeignKey(d => d.idequipmentgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_equipment_equipmentgroup");
            });

            modelBuilder.Entity<equipmentdoc>(entity =>
            {
                entity.Property(e => e.idequipmentdoc).ValueGeneratedNever();

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.equipmentdoc)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_equipmentdoc_manufactdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.equipmentdoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_equipmentdoc_people");
            });

            modelBuilder.Entity<equipmentdocfile>(entity =>
            {
                entity.HasOne(d => d.idequipmentNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idequipment)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_equipmentdocfile_equipment");

                entity.HasOne(d => d.idequipmentdocNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idequipmentdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_equipmentdocfile_equipmentdoc");
            });

            modelBuilder.Entity<equipmentglass>(entity =>
            {
                entity.Property(e => e.idequipmentglass).ValueGeneratedNever();

                entity.HasOne(d => d.idequipmentdocNavigation)
                    .WithMany(p => p.equipmentglass)
                    .HasForeignKey(d => d.idequipmentdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_equipmentglass_equipmentdoc");
            });

            modelBuilder.Entity<equipmentgroup>(entity =>
            {
                entity.Property(e => e.idequipmentgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentid)
                    .HasConstraintName("FK_equipmentgroup_equipmentgroup");
            });

            modelBuilder.Entity<equipmentper>(entity =>
            {
                entity.Property(e => e.idequipmentper).ValueGeneratedNever();
            });

            modelBuilder.Entity<equipmentprofile>(entity =>
            {
                entity.Property(e => e.idequipmentprofile).ValueGeneratedNever();

                entity.HasOne(d => d.idequipmentdocNavigation)
                    .WithMany(p => p.equipmentprofile)
                    .HasForeignKey(d => d.idequipmentdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_equipmentprofile_equipmentdoc");

                entity.HasOne(d => d.idequipmentperNavigation)
                    .WithMany(p => p.equipmentprofile)
                    .HasForeignKey(d => d.idequipmentper)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_equipmentprofile_equipmentper");
            });

            modelBuilder.Entity<equipmentprofilein>(entity =>
            {
                entity.HasKey(e => e.idequipmentprofilein)
                    .HasName("PK_equpmentprofilein");

                entity.Property(e => e.idequipmentprofilein).ValueGeneratedNever();

                entity.HasOne(d => d.idequipmentdocNavigation)
                    .WithMany(p => p.equipmentprofilein)
                    .HasForeignKey(d => d.idequipmentdoc)
                    .HasConstraintName("FK_equipmentprofilein_idequipmentdoc");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.equipmentprofilein)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_equipmentprofilein_manufactdoc");
            });

            modelBuilder.Entity<equipmentprofileout>(entity =>
            {
                entity.Property(e => e.idequipmentprofileout).ValueGeneratedNever();

                entity.HasOne(d => d.idequipmentdocNavigation)
                    .WithMany(p => p.equipmentprofileout)
                    .HasForeignKey(d => d.idequipmentdoc)
                    .HasConstraintName("FK_equipmentprofileout_idequipmentdoc");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.equipmentprofileout)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_equipmentprofileout_manufactdoc");
            });

            modelBuilder.Entity<error>(entity =>
            {
                entity.HasComment("Справочник ошибок расчётов");

                entity.Property(e => e.iderror)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.code).HasComment("Код ошибки");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Дата и время удаления");

                entity.Property(e => e.guid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Глобальный идентификатор для репликации");

                entity.Property(e => e.iderrorgroup).HasComment("Ссылка на группу");

                entity.Property(e => e.iderrortype).HasComment("Ссылка на тип");

                entity.Property(e => e.issave)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Сохранять в заказе");

                entity.Property(e => e.message1).HasComment("Сообщение 1 об ошибке");

                entity.Property(e => e.message2).HasComment("Сообщение 2 об ошибке");

                entity.Property(e => e.message3).HasComment("Сообщение 3 об ошибке");

                entity.Property(e => e.name).HasComment("Наименование ошибки");

                entity.Property(e => e.picture).HasComment("Иллюстрация");

                entity.Property(e => e.showtype)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Тип отображения. 0-не отображать,1-message1,2-message2,3-message3");

                entity.HasOne(d => d.iderrorgroupNavigation)
                    .WithMany(p => p.error)
                    .HasForeignKey(d => d.iderrorgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_error_errorgroup");

                entity.HasOne(d => d.iderrortypeNavigation)
                    .WithMany(p => p.error)
                    .HasForeignKey(d => d.iderrortype)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_error_errortype");
            });

            modelBuilder.Entity<errorgroup>(entity =>
            {
                entity.HasComment("Группы ошибок");

                entity.Property(e => e.iderrorgroup)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Дата и время удаления");

                entity.Property(e => e.guid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Глобальный идентификатор для репликации");

                entity.Property(e => e.name).HasComment("Наименование");

                entity.Property(e => e.parentid).HasComment("Ссылка на родителя");
            });

            modelBuilder.Entity<errortype>(entity =>
            {
                entity.HasComment("Справочник типов ошибок расчётов");

                entity.Property(e => e.iderrortype)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Дата и время удаления");

                entity.Property(e => e.guid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Глобальный идентификатор для репликации");

                entity.Property(e => e.name).HasComment("Наименование типа ошибки");
            });

            modelBuilder.Entity<files>(entity =>
            {
                entity.HasKey(e => e.idfiles)
                    .HasName("PK_file");

                entity.Property(e => e.idfiles).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.files)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_files_docstate");
            });

            modelBuilder.Entity<finparam>(entity =>
            {
                entity.HasKey(e => e.idfinparam)
                    .HasName("finparam_pkey");

                entity.Property(e => e.idfinparam).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idfinparamgroupNavigation)
                    .WithMany(p => p.finparam)
                    .HasForeignKey(d => d.idfinparamgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_finparam_finparamgroup");
            });

            modelBuilder.Entity<finparamcalc>(entity =>
            {
                entity.HasKey(e => e.idfinparamcalc)
                    .HasName("finparamcalc_pkey");

                entity.Property(e => e.idfinparamcalc).ValueGeneratedNever();

                entity.HasOne(d => d.idfinparamNavigation)
                    .WithMany(p => p.finparamcalc)
                    .HasForeignKey(d => d.idfinparam)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_finparamcalc_finparam");

                entity.HasOne(d => d.idmodelNavigation)
                    .WithMany(p => p.finparamcalc)
                    .HasForeignKey(d => d.idmodel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_finparamcalc_model");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.finparamcalc)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_finparamcalc_orders");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.finparamcalc)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_finparamcalc_orderitem");
            });

            modelBuilder.Entity<finparamgroup>(entity =>
            {
                entity.Property(e => e.idfinparamgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<furniture>(entity =>
            {
                entity.Property(e => e.idfurniture).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<furnituregoodkit>(entity =>
            {
                entity.HasKey(e => e.idfurnituregoodkit)
                    .HasName("PK_furnituredetail");

                entity.Property(e => e.idfurnituregoodkit).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<furnituremarking>(entity =>
            {
                entity.Property(e => e.idfurnituremarking).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ganttchart>(entity =>
            {
                entity.Property(e => e.idganttchart).ValueGeneratedNever();
            });

            modelBuilder.Entity<generator>(entity =>
            {
                entity.Property(e => e.idgen).ValueGeneratedNever();
            });

            modelBuilder.Entity<glass>(entity =>
            {
                entity.Property(e => e.idglass).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idglassgroupNavigation)
                    .WithMany(p => p.glass)
                    .HasForeignKey(d => d.idglassgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_glass_glassgroup");
            });

            modelBuilder.Entity<glassdetail>(entity =>
            {
                entity.Property(e => e.idglassdetail).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idglassNavigation)
                    .WithMany(p => p.glassdetail)
                    .HasForeignKey(d => d.idglass)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_glassdetail_glass");

                entity.HasOne(d => d.idglasselementNavigation)
                    .WithMany(p => p.glassdetail)
                    .HasForeignKey(d => d.idglasselement)
                    .HasConstraintName("FK_glassdetail_glasselement");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.glassdetail)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_glassdetail_good");
            });

            modelBuilder.Entity<glasselement>(entity =>
            {
                entity.Property(e => e.idglasselement).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idglasselementgroupNavigation)
                    .WithMany(p => p.glasselement)
                    .HasForeignKey(d => d.idglasselementgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_glasselement_glasselementgroup");
            });

            modelBuilder.Entity<glasselementgroup>(entity =>
            {
                entity.Property(e => e.idglasselementgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<glassgroup>(entity =>
            {
                entity.Property(e => e.idglassgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<good>(entity =>
            {
                entity.HasKey(e => e.idgood)
                    .HasName("pk_good");

                entity.Property(e => e.idgood).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idstoredepart).HasComment("Ссылка на склад хранения");

                entity.Property(e => e.showinnopaper).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.idcolorgroupcustomNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idcolorgroupcustom)
                    .HasConstraintName("FK_good_colorgroupcustom");

                entity.HasOne(d => d.idgoodgroupNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idgoodgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_good_goodgroup");

                entity.HasOne(d => d.idgoodoptimNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idgoodoptim)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_good_goodoptim");

                entity.HasOne(d => d.idgoodpricegroupNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idgoodpricegroup)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_good_goodpricegroup");

                entity.HasOne(d => d.idgoodtypeNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idgoodtype)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_good_goodtype");

                entity.HasOne(d => d.idmeasureNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idmeasure)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_good_measure");

                entity.HasOne(d => d.idstoragespaceNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idstoragespace)
                    .HasConstraintName("FK_good_storagespace");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_good_storedepart");

                entity.HasOne(d => d.idsystemNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idsystem)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_good_system");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.good)
                    .HasForeignKey(d => d.idvalut)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_good_valut");
            });

            modelBuilder.Entity<goodanalog>(entity =>
            {
                entity.HasKey(e => e.idgoodanalog)
                    .HasName("goodanalog_pkey");

                entity.Property(e => e.idgoodanalog).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany(p => p.goodanalogidcolor1Navigation)
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_goodanalog_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany(p => p.goodanalogidcolor2Navigation)
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_goodanalog_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodanalog)
                    .HasForeignKey(d => d.idgood)
                    .HasConstraintName("FK_goodanalog_good");

                entity.HasOne(d => d.idgoodanaloggroupNavigation)
                    .WithMany(p => p.goodanalog)
                    .HasForeignKey(d => d.idgoodanaloggroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodanalog_goodanaloggroup");
            });

            modelBuilder.Entity<goodanalogdetail>(entity =>
            {
                entity.HasKey(e => e.idgoodanalogdetail)
                    .HasName("goodanalogdetail_pkey");

                entity.Property(e => e.idgoodanalogdetail).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodanalogdetail)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodanalogdetail_good");

                entity.HasOne(d => d.idgoodanalogNavigation)
                    .WithMany(p => p.goodanalogdetail)
                    .HasForeignKey(d => d.idgoodanalog)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodanalogdetail_goodanalog");
            });

            modelBuilder.Entity<goodanaloggroup>(entity =>
            {
                entity.Property(e => e.idgoodanaloggroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<goodbuffer>(entity =>
            {
                entity.Property(e => e.idgoodbuffer).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodbuffer)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodbuffer_good");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.goodbuffer)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_goodbuffer_orderitem");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.goodbuffer)
                    .HasForeignKey(d => d.idstoredepart)
                    .HasConstraintName("FK_goodbuffer_storedepart");
            });

            modelBuilder.Entity<goodcolorgroupprice>(entity =>
            {
                entity.Property(e => e.idgoodcolorgroupprice).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorgrouppriceNavigation)
                    .WithMany(p => p.goodcolorgroupprice)
                    .HasForeignKey(d => d.idcolorgroupprice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_goodcolorgroupprice_colorgroupprice");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodcolorgroupprice)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_goodcolorgroupprice_good");

                entity.HasOne(d => d.idgoodpricegroupNavigation)
                    .WithMany(p => p.goodcolorgroupprice)
                    .HasForeignKey(d => d.idgoodpricegroup)
                    .HasConstraintName("FK_goodcolorgroupprice_goodpricegroup");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.goodcolorgrouppriceidvalutNavigation)
                    .HasForeignKey(d => d.idvalut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_goodcolorgroupprice_valut");

                entity.HasOne(d => d.idvalut2Navigation)
                    .WithMany(p => p.goodcolorgrouppriceidvalut2Navigation)
                    .HasForeignKey(d => d.idvalut2)
                    .HasConstraintName("FK__goodcolor__idval__681C93FE");
            });

            modelBuilder.Entity<goodcolorparam>(entity =>
            {
                entity.Property(e => e.idgoodcolorparam).ValueGeneratedNever();

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany(p => p.goodcolorparamidcolor1Navigation)
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_goodcolorparam_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany(p => p.goodcolorparamidcolor2Navigation)
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_goodcolorparam_color2");

                entity.HasOne(d => d.idcolorgrouppriceNavigation)
                    .WithMany(p => p.goodcolorparam)
                    .HasForeignKey(d => d.idcolorgroupprice)
                    .HasConstraintName("FK_goodcolorparam_colorgroupprice");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodcolorparam)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_goodcolorparam_good");

                entity.HasOne(d => d.idgoodoptimNavigation)
                    .WithMany(p => p.goodcolorparam)
                    .HasForeignKey(d => d.idgoodoptim)
                    .HasConstraintName("FK_goodcolorparam_goodoptim");

                entity.HasOne(d => d.idstoragespaceNavigation)
                    .WithMany(p => p.goodcolorparam)
                    .HasForeignKey(d => d.idstoragespace)
                    .HasConstraintName("FK_goodcolorparam_storagespace");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.goodcolorparam)
                    .HasForeignKey(d => d.idstoredepart)
                    .HasConstraintName("FK_goodcolorparam_storedepart");
            });

            modelBuilder.Entity<goodgroup>(entity =>
            {
                entity.HasKey(e => e.idgoodgroup)
                    .HasName("pk_goodgroup");

                entity.Property(e => e.idgoodgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<goodkit>(entity =>
            {
                entity.HasKey(e => e.idgoodkit)
                    .HasName("goodkit_pkey");

                entity.Property(e => e.idgoodkit).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idgoodkitgroupNavigation)
                    .WithMany(p => p.goodkit)
                    .HasForeignKey(d => d.idgoodkitgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodkit_goodkitgroup");
            });

            modelBuilder.Entity<goodkitdetail>(entity =>
            {
                entity.HasKey(e => e.idgoodkitdetail)
                    .HasName("goodkitdetail_pkey");

                entity.Property(e => e.idgoodkitdetail).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idcolor1).HasComment("Цвет 1");

                entity.Property(e => e.idcolor2).HasComment("Цвет 2");

                entity.Property(e => e.sqr).HasComment("Площадь");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodkitdetail)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodkitdetail_good");

                entity.HasOne(d => d.idgoodkitNavigation)
                    .WithMany(p => p.goodkitdetail)
                    .HasForeignKey(d => d.idgoodkit)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodkitdetail_goodkit");
            });

            modelBuilder.Entity<goodkitgroup>(entity =>
            {
                entity.Property(e => e.idgoodkitgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.isvisible).HasComment("Видимость группы для добавления");
            });

            modelBuilder.Entity<goodmeasure>(entity =>
            {
                entity.Property(e => e.idgoodmeasure).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodmeasure)
                    .HasForeignKey(d => d.idgood)
                    .HasConstraintName("FK_goodmeasure_good");

                entity.HasOne(d => d.idmeasureNavigation)
                    .WithMany(p => p.goodmeasure)
                    .HasForeignKey(d => d.idmeasure)
                    .HasConstraintName("FK_goodmeasure_measure");
            });

            modelBuilder.Entity<goodoptim>(entity =>
            {
                entity.Property(e => e.idgoodoptim).ValueGeneratedNever();

                entity.Property(e => e.canrotate).HasComment("Не вращать кусочки");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.optimstyle).HasDefaultValueSql("((1))");

                entity.Property(e => e.quality).HasDefaultValueSql("((2))");

                entity.Property(e => e.typerez).HasComment("Тип резов (вертикальные = 0, горизонтальные = 1, смешанные = 2)");
            });

            modelBuilder.Entity<goodost>(entity =>
            {
                entity.Property(e => e.idgoodost).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodost)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodost_good");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.goodost)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodost_manufactdoc");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.goodost)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodost_orders");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.goodost)
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodost_storedepart");
            });

            modelBuilder.Entity<goodparam>(entity =>
            {
                entity.HasKey(e => e.idgoodparam)
                    .HasName("goodparam_pkey");

                entity.Property(e => e.idgoodparam).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodparam)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodparam_good");
            });

            modelBuilder.Entity<goodparamname>(entity =>
            {
                entity.Property(e => e.idgoodparamname).ValueGeneratedNever();
            });

            modelBuilder.Entity<goodprice>(entity =>
            {
                entity.HasKey(e => e.idgoodprice)
                    .HasName("goodprice_pkey");

                entity.Property(e => e.idgoodprice).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodprice)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodprice_good");
            });

            modelBuilder.Entity<goodpricegroup>(entity =>
            {
                entity.Property(e => e.idgoodpricegroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<goodpricehistory>(entity =>
            {
                entity.Property(e => e.idgoodpricehistory).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorgrouppriceNavigation)
                    .WithMany(p => p.goodpricehistory)
                    .HasForeignKey(d => d.idcolorgroupprice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_goodpricehistory_colorgroupprice");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.goodpricehistory)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_goodpricehistory_good");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.goodpricehistory)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_goodpricehistory_people");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.goodpricehistory)
                    .HasForeignKey(d => d.idvalut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_goodpricehistory_valut");
            });

            modelBuilder.Entity<goodservice>(entity =>
            {
                entity.Property(e => e.idgoodservice).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ismy).HasComment("Своя услуга");

                entity.HasOne(d => d.idgoodservicegroupNavigation)
                    .WithMany(p => p.goodservice)
                    .HasForeignKey(d => d.idgoodservicegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goodservice_goodservicegroup");

                entity.HasOne(d => d.idvalut1Navigation)
                    .WithMany(p => p.goodserviceidvalut1Navigation)
                    .HasForeignKey(d => d.idvalut1)
                    .HasConstraintName("FK_goodservice_valut");

                entity.HasOne(d => d.idvalut2Navigation)
                    .WithMany(p => p.goodserviceidvalut2Navigation)
                    .HasForeignKey(d => d.idvalut2)
                    .HasConstraintName("FK_goodservice_valut1");

                entity.HasOne(d => d.idvalut3Navigation)
                    .WithMany(p => p.goodserviceidvalut3Navigation)
                    .HasForeignKey(d => d.idvalut3)
                    .HasConstraintName("FK_goodservice_valut2");

                entity.HasOne(d => d.idvalut4Navigation)
                    .WithMany(p => p.goodserviceidvalut4Navigation)
                    .HasForeignKey(d => d.idvalut4)
                    .HasConstraintName("FK_goodservice_valut3");

                entity.HasOne(d => d.idvalut5Navigation)
                    .WithMany(p => p.goodserviceidvalut5Navigation)
                    .HasForeignKey(d => d.idvalut5)
                    .HasConstraintName("FK_goodservice_valut4");
            });

            modelBuilder.Entity<goodservicegroup>(entity =>
            {
                entity.Property(e => e.idgoodservicegroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<goodtype>(entity =>
            {
                entity.Property(e => e.idgoodtype).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<insertion>(entity =>
            {
                entity.Property(e => e.idinsertion).ValueGeneratedNever();

                entity.Property(e => e.id).IsFixedLength();

                entity.HasOne(d => d.idglasselementNavigation)
                    .WithMany(p => p.insertion)
                    .HasForeignKey(d => d.idglasselement)
                    .HasConstraintName("FK_insertion_glasselement");

                entity.HasOne(d => d.idsystemdetailNavigation)
                    .WithMany(p => p.insertion)
                    .HasForeignKey(d => d.idsystemdetail)
                    .HasConstraintName("FK_insertion_insertion");
            });

            modelBuilder.Entity<insertiondetail>(entity =>
            {
                entity.Property(e => e.idinsertiondetail).ValueGeneratedNever();

                entity.HasOne(d => d.iderrorNavigation)
                    .WithMany(p => p.insertiondetail)
                    .HasForeignKey(d => d.iderror)
                    .HasConstraintName("FK_insertiondetail_iderror");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.insertiondetail)
                    .HasForeignKey(d => d.idgood)
                    .HasConstraintName("FK_insertiondetail_good");

                entity.HasOne(d => d.idinsertionNavigation)
                    .WithMany(p => p.insertiondetail)
                    .HasForeignKey(d => d.idinsertion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_insertiondetail_insertion");

                entity.HasOne(d => d.idworkoperNavigation)
                    .WithMany(p => p.insertiondetail)
                    .HasForeignKey(d => d.idworkoper)
                    .HasConstraintName("FK_insertiondetail_idworkoper");
            });

            modelBuilder.Entity<insertionparam>(entity =>
            {
                entity.Property(e => e.idinsertionparam).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorNavigation)
                    .WithMany(p => p.insertionparam)
                    .HasForeignKey(d => d.idcolor)
                    .HasConstraintName("FK_insertionparam_color");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.insertionparam)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_insertionparam_idconstructiontype");

                entity.HasOne(d => d.iderrorNavigation)
                    .WithMany(p => p.insertionparam)
                    .HasForeignKey(d => d.iderror)
                    .HasConstraintName("FK_insertionparam_error");

                entity.HasOne(d => d.idinsertionNavigation)
                    .WithMany(p => p.insertionparam)
                    .HasForeignKey(d => d.idinsertion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_insertionparam_insertion");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.insertionparam)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_insertionparam_modelparamvalue");

                entity.HasOne(d => d.idsystemdetailNavigation)
                    .WithMany(p => p.insertionparam)
                    .HasForeignKey(d => d.idsystemdetail)
                    .HasConstraintName("FK_insertionparam_systemdetail");

                entity.HasOne(d => d.idvariantparamtypeNavigation)
                    .WithMany(p => p.insertionparam)
                    .HasForeignKey(d => d.idvariantparamtype)
                    .HasConstraintName("FK_insertionparam_variantparamtype");

                entity.HasOne(d => d.idvariantparamtypevalueNavigation)
                    .WithMany(p => p.insertionparam)
                    .HasForeignKey(d => d.idvariantparamtypevalue)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_insertionparam_variantparamtypevalue");
            });

            modelBuilder.Entity<insertionparamdetail>(entity =>
            {
                entity.Property(e => e.idinsertionparamdetail).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorNavigation)
                    .WithMany(p => p.insertionparamdetail)
                    .HasForeignKey(d => d.idcolor)
                    .HasConstraintName("FK_insertionparamdetail_color");

                entity.HasOne(d => d.idcoloraccordanceNavigation)
                    .WithMany(p => p.insertionparamdetail)
                    .HasForeignKey(d => d.idcoloraccordance)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_insertionparamdetail_coloraccordance");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.insertionparamdetail)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_insertionparamdetail_constructiontype");

                entity.HasOne(d => d.idinsertiondetailNavigation)
                    .WithMany(p => p.insertionparamdetail)
                    .HasForeignKey(d => d.idinsertiondetail)
                    .HasConstraintName("FK_insertionparamdetail_insertiondetail");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.insertionparamdetail)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_insertionparamdetail_modelparamvalue");

                entity.HasOne(d => d.idsystemdetailNavigation)
                    .WithMany(p => p.insertionparamdetail)
                    .HasForeignKey(d => d.idsystemdetail)
                    .HasConstraintName("FK_insertionparamdetail_systemdetail");

                entity.HasOne(d => d.idvariantparamtypeNavigation)
                    .WithMany(p => p.insertionparamdetail)
                    .HasForeignKey(d => d.idvariantparamtype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_insertionparamdetail_variantparamtype");

                entity.HasOne(d => d.idvariantparamtypevalueNavigation)
                    .WithMany(p => p.insertionparamdetail)
                    .HasForeignKey(d => d.idvariantparamtypevalue)
                    .HasConstraintName("FK_insertionparamdetail_variantparamtypevalue");
            });

            modelBuilder.Entity<installdoc>(entity =>
            {
                entity.Property(e => e.idinstalldoc).ValueGeneratedNever();

                entity.Property(e => e.contact).HasComment("Контактное лицо");

                entity.Property(e => e.phone).HasComment("Телефон");

                entity.HasOne(d => d.idaddressNavigation)
                    .WithMany(p => p.installdoc)
                    .HasForeignKey(d => d.idaddress)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_installdoc_address");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.installdoc)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_installdoc_customer");

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.installdoc)
                    .HasForeignKey(d => d.iddestanation)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_installdoc_destanation");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.installdoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_installdoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.installdoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_installdoc_docstate");

                entity.HasOne(d => d.idinstalldocgroupNavigation)
                    .WithMany(p => p.installdoc)
                    .HasForeignKey(d => d.idinstalldocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdoc_installdocgroup");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.installdoc)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_installdoc_orders");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.installdocidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_installdoc_people");

                entity.HasOne(d => d.idpeople2Navigation)
                    .WithMany(p => p.installdocidpeople2Navigation)
                    .HasForeignKey(d => d.idpeople2)
                    .HasConstraintName("FK_installdoc_people1");

                entity.HasOne(d => d.idpeople3Navigation)
                    .WithMany(p => p.installdocidpeople3Navigation)
                    .HasForeignKey(d => d.idpeople3)
                    .HasConstraintName("FK_installdoc_people3");
            });

            modelBuilder.Entity<installdocdiraction>(entity =>
            {
                entity.Property(e => e.idinstalldocdiraction).ValueGeneratedNever();

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.installdocdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_installdocdiraction_diraction");

                entity.HasOne(d => d.idinstalldocNavigation)
                    .WithMany(p => p.installdocdiraction)
                    .HasForeignKey(d => d.idinstalldoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocdiraction_installdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.installdocdiractionidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_installdocdiraction_people");

                entity.HasOne(d => d.idpeopleeditNavigation)
                    .WithMany(p => p.installdocdiractionidpeopleeditNavigation)
                    .HasForeignKey(d => d.idpeopleedit)
                    .HasConstraintName("FK_installdocdiraction_people2");
            });

            modelBuilder.Entity<installdocdiractionpeople>(entity =>
            {
                entity.Property(e => e.idinstalldocdiractionpeople).ValueGeneratedNever();

                entity.HasOne(d => d.idinstalldocdiractionNavigation)
                    .WithMany(p => p.installdocdiractionpeople)
                    .HasForeignKey(d => d.idinstalldocdiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocdiractionpeople_installdocdiraction");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.installdocdiractionpeople)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_installdocdiractionpeople_people");
            });

            modelBuilder.Entity<installdocfile>(entity =>
            {
                entity.Property(e => e.idinstalldocfile).ValueGeneratedNever();

                entity.HasOne(d => d.idinstalldocNavigation)
                    .WithMany(p => p.installdocfile)
                    .HasForeignKey(d => d.idinstalldoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocfile_installdoc");
            });

            modelBuilder.Entity<installdocgoodservice>(entity =>
            {
                entity.Property(e => e.idinstalldocgoodservice).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodserviceNavigation)
                    .WithMany(p => p.installdocgoodservice)
                    .HasForeignKey(d => d.idgoodservice)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocgoodservice_goodservice");

                entity.HasOne(d => d.idinstalldocNavigation)
                    .WithMany(p => p.installdocgoodservice)
                    .HasForeignKey(d => d.idinstalldoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocgoodservice_installdocs");

                entity.HasOne(d => d.idinstalldocposNavigation)
                    .WithMany(p => p.installdocgoodservice)
                    .HasForeignKey(d => d.idinstalldocpos)
                    .HasConstraintName("FK_installdocgoodservice_installdocpos");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.installdocgoodservice)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocgoodservice_orders");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.installdocgoodservice)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_installdocgoodservice_orderitem");
            });

            modelBuilder.Entity<installdocgroup>(entity =>
            {
                entity.Property(e => e.idinstalldocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<installdocpos>(entity =>
            {
                entity.Property(e => e.idinstalldocpos).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.installdocpos)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocpos_good");

                entity.HasOne(d => d.idinstalldocNavigation)
                    .WithMany(p => p.installdocpos)
                    .HasForeignKey(d => d.idinstalldoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocpos_installdoc");

                entity.HasOne(d => d.idmodelNavigation)
                    .WithMany(p => p.installdocpos)
                    .HasForeignKey(d => d.idmodel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocpos_model");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.installdocpos)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_installdocpos_orderitem");
            });

            modelBuilder.Entity<installdocsign>(entity =>
            {
                entity.Property(e => e.idinstalldocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idinstalldocNavigation)
                    .WithMany(p => p.installdocsign)
                    .HasForeignKey(d => d.idinstalldoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_installdocsign_installdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.installdocsign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_installdocsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.installdocsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_installdocsign_sign");

                entity.HasOne(d => d.idsignvalueNavigation)
                    .WithMany(p => p.installdocsign)
                    .HasForeignKey(d => d.idsignvalue)
                    .HasConstraintName("FK_installdocsign_signvalue");
            });

            modelBuilder.Entity<localizedstring>(entity =>
            {
                entity.HasKey(e => e.idlocalizedstring)
                    .IsClustered(false);

                entity.HasIndex(e => e.code, "Index_Code")
                    .IsClustered();

                entity.Property(e => e.idlocalizedstring).ValueGeneratedNever();
            });

            modelBuilder.Entity<mailinglist>(entity =>
            {
                entity.Property(e => e.idmailinglist).ValueGeneratedNever();

                entity.HasOne(d => d.idmailinglistsettingsNavigation)
                    .WithMany(p => p.mailinglist)
                    .HasForeignKey(d => d.idmailinglistsettings)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_mailinglist_smtpsettings");

                entity.HasOne(d => d.idreportNavigation)
                    .WithMany(p => p.mailinglist)
                    .HasForeignKey(d => d.idreport)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_mailinglist_report");
            });

            modelBuilder.Entity<mailinglistondemand>(entity =>
            {
                entity.Property(e => e.idmailinglistondemand).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.mailinglistondemand)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_mailinglistondemand_customer");

                entity.HasOne(d => d.idmailinglistNavigation)
                    .WithMany(p => p.mailinglistondemand)
                    .HasForeignKey(d => d.idmailinglist)
                    .HasConstraintName("FK_mailinglistondemand_mailinglist");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.mailinglistondemand)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_mailinglistondemand_people");
            });

            modelBuilder.Entity<mailinglistsettings>(entity =>
            {
                entity.HasKey(e => e.idmailinglistsettings)
                    .HasName("PK_smtpsettings");

                entity.Property(e => e.idmailinglistsettings).ValueGeneratedNever();
            });

            modelBuilder.Entity<mailinglistusers>(entity =>
            {
                entity.Property(e => e.idmailinglistusers).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.mailinglistusers)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_mailinglistusers_customer");

                entity.HasOne(d => d.idmailinglistNavigation)
                    .WithMany(p => p.mailinglistusers)
                    .HasForeignKey(d => d.idmailinglist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mailinglistusers_mailinglist");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.mailinglistusers)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_mailinglistusers_people");
            });

            modelBuilder.Entity<manufactdiraction>(entity =>
            {
                entity.HasKey(e => e.idmanufactdiraction)
                    .HasName("pk_manufactdiraction");

                entity.Property(e => e.idmanufactdiraction).ValueGeneratedNever();

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.manufactdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdiraction_diraction");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.manufactdiraction)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdiraction_manufactdoc");
            });

            modelBuilder.Entity<manufactdiractionpeople>(entity =>
            {
                entity.HasKey(e => e.idmanufactdiractionpeople)
                    .HasName("PK_manufactdocdiractionpeople");

                entity.Property(e => e.idmanufactdiractionpeople).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.manufactdiractionpeople)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_manufactdocdiractionpeople_people");
            });

            modelBuilder.Entity<manufactdoc>(entity =>
            {
                entity.Property(e => e.idmanufactdoc).ValueGeneratedNever();

                entity.Property(e => e.dtcreate).HasComment("Дата создания задания");

                entity.Property(e => e.dtedit).HasComment("Дата редактирования задания");

                entity.Property(e => e.idpeopleedit).HasComment("Ссылка на сотрудника, редактировавшего заказ");

                entity.Property(e => e.qugroup).HasComment("Количество порций");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.manufactdoc)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_manufactdoc_customer");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.manufactdoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_manufactdoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.manufactdoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_manufactdoc_docstate");

                entity.HasOne(d => d.idmanufactdocgroupNavigation)
                    .WithMany(p => p.manufactdoc)
                    .HasForeignKey(d => d.idmanufactdocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdoc_manufactdocgroup");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.manufactdoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_manufactdoc_people");
            });

            modelBuilder.Entity<manufactdoccar>(entity =>
            {
                entity.Property(e => e.idmanufactdoccar).ValueGeneratedNever();

                entity.Property(e => e.run).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.idcarNavigation)
                    .WithMany(p => p.manufactdoccar)
                    .HasForeignKey(d => d.idcar)
                    .HasConstraintName("FK_manufactdoccar_car");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.manufactdoccar)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .HasConstraintName("FK_manufactdoccar_manufactdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.manufactdoccar)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_manufactdoccar_people");
            });

            modelBuilder.Entity<manufactdocgoodin>(entity =>
            {
                entity.HasComment("Входящие остатки производственного задания");

                entity.Property(e => e.idmanufactdocgoodin)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Признак удаления");

                entity.Property(e => e.height).HasComment("Высота");

                entity.Property(e => e.idmanufactdoc).HasComment("Ссылка на производственное задание");

                entity.Property(e => e.marking).HasComment("Артикул материала");

                entity.Property(e => e.qu).HasComment("Количество");

                entity.Property(e => e.thick).HasComment("Длина");

                entity.Property(e => e.width).HasComment("Ширина");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.manufactdocgoodin)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdocgoodin_manufactdoc");
            });

            modelBuilder.Entity<manufactdocgroup>(entity =>
            {
                entity.Property(e => e.idmanufactdocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<manufactdocnopyramid>(entity =>
            {
                entity.Property(e => e.idmanufactdocnopyramid).ValueGeneratedNever();

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.manufactdocnopyramid)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_manufactdocnopyramid_manufactdoc");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.manufactdocnopyramid)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_manufactdocnopyramid_orders");
            });

            modelBuilder.Entity<manufactdocorder>(entity =>
            {
                entity.Property(e => e.idmanufactdocorder).ValueGeneratedNever();

                entity.HasOne(d => d.idcarNavigation)
                    .WithMany(p => p.manufactdocorder)
                    .HasForeignKey(d => d.idcar)
                    .HasConstraintName("FK_manufactdocorder_car");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.manufactdocorder)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .HasConstraintName("FK_manufactdocorder_manufactdoc");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.manufactdocorder)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_manufactdocorder_orders");
            });

            modelBuilder.Entity<manufactdocpos>(entity =>
            {
                entity.Property(e => e.idmanufactdocpos).ValueGeneratedNever();

                entity.Property(e => e.idordergood).HasComment("Ссылка на материал к позиции");

                entity.Property(e => e.quready).HasComment("Количество изготовленных");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.manufactdocpos)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdocpos_good");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.manufactdocpos)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdocpos_manufactdoc");

                entity.HasOne(d => d.idordergoodNavigation)
                    .WithMany(p => p.manufactdocpos)
                    .HasForeignKey(d => d.idordergood)
                    .HasConstraintName("FK_manufactdocpos_ordergood");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.manufactdocpos)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdocpos_orderitem");
            });

            modelBuilder.Entity<manufactdocpyramid>(entity =>
            {
                entity.Property(e => e.idmanufactdocpyramid).ValueGeneratedNever();

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.manufactdocpyramid)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .HasConstraintName("FK_manufactdocpyramid_manufactdoc");

                entity.HasOne(d => d.idmanufactdoccarNavigation)
                    .WithMany(p => p.manufactdocpyramid)
                    .HasForeignKey(d => d.idmanufactdoccar)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdocpyramid_manufactdoccar");

                entity.HasOne(d => d.idmanufactdocposNavigation)
                    .WithMany(p => p.manufactdocpyramid)
                    .HasForeignKey(d => d.idmanufactdocpos)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdocpyramid_manufactdocpos");
            });

            modelBuilder.Entity<manufactdocpyramidpos>(entity =>
            {
                entity.HasKey(e => e.idmanufactdocpyramidpos)
                    .HasName("PK_manufctpos");

                entity.Property(e => e.idmanufactdocpyramidpos).ValueGeneratedNever();

                entity.Property(e => e.active).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.manufactdocpyramidpos)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .HasConstraintName("FK_manufactdocpyramidpos_manufactdoc");

                entity.HasOne(d => d.idmanufactdoccarNavigation)
                    .WithMany(p => p.manufactdocpyramidpos)
                    .HasForeignKey(d => d.idmanufactdoccar)
                    .HasConstraintName("FK_manufactdocpyramidpos_manufactdoccar");

                entity.HasOne(d => d.idmanufactdocpyram)
                    .WithMany(p => p.manufactdocpyramidpos)
                    .HasForeignKey(d => d.idmanufactdocpyramid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactdocpyramidpos_manufactdocpyramid");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.manufactdocpyramidpos)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_manufactdocpyramidpos_orderitem");
            });

            modelBuilder.Entity<manufactdocsign>(entity =>
            {
                entity.HasKey(e => e.idmanufactdocsign)
                    .HasName("pk_manufactsign");

                entity.Property(e => e.idmanufactdocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany(p => p.manufactdocsign)
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactsign_manufactdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.manufactdocsign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_manufactsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.manufactdocsign)
                    .HasForeignKey(d => d.idsign)
                    .HasConstraintName("FK_manufactsign_sign");

                entity.HasOne(d => d.idsignvalueNavigation)
                    .WithMany(p => p.manufactdocsign)
                    .HasForeignKey(d => d.idsignvalue)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_manufactsign_signvalue");
            });

            modelBuilder.Entity<manufactsign>(entity =>
            {
                entity.ToView("manufactsign");
            });

            modelBuilder.Entity<markingfilter>(entity =>
            {
                entity.Property(e => e.idmarkingfilter).ValueGeneratedNever();
            });

            modelBuilder.Entity<markingfilterdetail>(entity =>
            {
                entity.Property(e => e.idmarkingfilterdetail).ValueGeneratedNever();
            });

            modelBuilder.Entity<markingfiltertype>(entity =>
            {
                entity.Property(e => e.idmarkingfiltertype).ValueGeneratedNever();
            });

            modelBuilder.Entity<measure>(entity =>
            {
                entity.HasKey(e => e.idmeasure)
                    .HasName("pk_measure");

                entity.Property(e => e.idmeasure).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<messages>(entity =>
            {
                entity.Property(e => e.idmessage).ValueGeneratedNever();

                entity.HasOne(d => d.iddepartmentNavigation)
                    .WithMany(p => p.messages)
                    .HasForeignKey(d => d.iddepartment)
                    .HasConstraintName("FK_messages_department");

                entity.HasOne(d => d.idmessagetypeNavigation)
                    .WithMany(p => p.messages)
                    .HasForeignKey(d => d.idmessagetype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_messages_messagetype");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.messagesidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_messages_people");

                entity.HasOne(d => d.idpeople2Navigation)
                    .WithMany(p => p.messagesidpeople2Navigation)
                    .HasForeignKey(d => d.idpeople2)
                    .HasConstraintName("FK_messages_people1");
            });

            modelBuilder.Entity<messagetype>(entity =>
            {
                entity.Property(e => e.idmessagetype).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<model>(entity =>
            {
                entity.HasKey(e => e.idmodel)
                    .HasName("pk_model");

                entity.Property(e => e.idmodel).ValueGeneratedNever();

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.model)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_model_orders");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.model)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_model_orderitem");
            });

            modelBuilder.Entity<modelcalc>(entity =>
            {
                entity.HasKey(e => e.idmodelcalc)
                    .HasName("pk_modelcalc");

                entity.Property(e => e.idmodelcalc).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.modelcalc)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_modelcalc_good");

                entity.HasOne(d => d.idmodelNavigation)
                    .WithMany(p => p.modelcalc)
                    .HasForeignKey(d => d.idmodel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_modelcalc_model");
            });

            modelBuilder.Entity<modelparam>(entity =>
            {
                entity.HasKey(e => e.idmodelparam)
                    .HasName("pk_modelparam");

                entity.Property(e => e.idmodelparam).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idmodelparamgroup).HasComment("Группа параметров");

                entity.Property(e => e.iscolor).HasDefaultValueSql("((0))");

                entity.Property(e => e.isint1).HasDefaultValueSql("((0))");

                entity.Property(e => e.isstr1).HasDefaultValueSql("((0))");

                entity.Property(e => e.isstr2).HasDefaultValueSql("((0))");

                entity.Property(e => e.tomodel)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Для построителя");

                entity.HasOne(d => d.idcolorNavigation)
                    .WithMany(p => p.modelparam)
                    .HasForeignKey(d => d.idcolor)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_modelparam_color");

                entity.HasOne(d => d.idmodelparamgroupNavigation)
                    .WithMany(p => p.modelparam)
                    .HasForeignKey(d => d.idmodelparamgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_modelparam_modelparamgroup");

                entity.HasOne(d => d.idmodelpartNavigation)
                    .WithMany(p => p.modelparam)
                    .HasForeignKey(d => d.idmodelpart)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_modelparam_modelpart");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.modelparam)
                    .HasForeignKey(d => d.idversion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_modelparam_version");
            });

            modelBuilder.Entity<modelparamcalc>(entity =>
            {
                entity.HasKey(e => e.idmodelparamcalc)
                    .HasName("pk_modelparamcalc");

                entity.Property(e => e.idmodelparamcalc).ValueGeneratedNever();

                entity.HasOne(d => d.idmodelNavigation)
                    .WithMany(p => p.modelparamcalc)
                    .HasForeignKey(d => d.idmodel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_modelparamcalc_model");

                entity.HasOne(d => d.idmodelparamNavigation)
                    .WithMany(p => p.modelparamcalc)
                    .HasForeignKey(d => d.idmodelparam)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_modelparamcalc_modelparam");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.modelparamcalcidmodelparamvalueNavigation)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_modelparamcalc_modelparamvalue");

                entity.HasOne(d => d.idmodelparamvalue2Navigation)
                    .WithMany(p => p.modelparamcalcidmodelparamvalue2Navigation)
                    .HasForeignKey(d => d.idmodelparamvalue2)
                    .HasConstraintName("FK_modelparamcalc_modelparamvalue2");

                entity.HasOne(d => d.idmodelpartNavigation)
                    .WithMany(p => p.modelparamcalc)
                    .HasForeignKey(d => d.idmodelpart)
                    .HasConstraintName("FK_modelparamcalc_modelpart");
            });

            modelBuilder.Entity<modelparamcondition>(entity =>
            {
                entity.Property(e => e.idmodelparamcondition).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idcolor)
                    .HasConstraintName("FK_modelparamcondition_color");

                entity.HasOne(d => d.idcoloraccordanceNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idcoloraccordance)
                    .HasConstraintName("FK_modelparamcondition_coloraccordance");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_modelparamcondition_constructiontype");

                entity.HasOne(d => d.idmodelparamNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idmodelparam)
                    .HasConstraintName("FK_modelparamcondition_modelparam");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_modelparamcondition_modelparamvalue");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_modelparamcondition_productiontype");

                entity.HasOne(d => d.idsystemNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idsystem)
                    .HasConstraintName("FK_modelparamcondition_system");

                entity.HasOne(d => d.idsystemdetailNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idsystemdetail)
                    .HasConstraintName("FK_modelparamcondition_systemdetail");

                entity.HasOne(d => d.idvariantparamtypeNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idvariantparamtype)
                    .HasConstraintName("FK_modelparamcondition_variantparamtype");

                entity.HasOne(d => d.idvariantparamtypevalueNavigation)
                    .WithMany(p => p.modelparamcondition)
                    .HasForeignKey(d => d.idvariantparamtypevalue)
                    .HasConstraintName("FK_modelparamcondition_variantparamtypevalue");
            });

            modelBuilder.Entity<modelparamconditiondetail>(entity =>
            {
                entity.Property(e => e.idmodelparamconditiondetail).ValueGeneratedNever();

                entity.HasOne(d => d.idmodelparamconditionNavigation)
                    .WithMany(p => p.modelparamconditiondetail)
                    .HasForeignKey(d => d.idmodelparamcondition)
                    .HasConstraintName("FK_modelparamconditiondetail_modelparamcondition");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.modelparamconditiondetail)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_modelparamconditiondetail_modelparamvalue");
            });

            modelBuilder.Entity<modelparamgroup>(entity =>
            {
                entity.HasComment("Группы характеристик");

                entity.Property(e => e.idmodelparamgroup)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Дата удаления");

                entity.Property(e => e.guid).HasComment("Глобальный идентификатор для репликации");

                entity.Property(e => e.name).HasComment("Наименование");

                entity.Property(e => e.parentid).HasComment("Ссылка на родительскую группу");
            });

            modelBuilder.Entity<modelparamvalue>(entity =>
            {
                entity.HasKey(e => e.idmodelparamvalue)
                    .HasName("pk_modelparamvalue");

                entity.Property(e => e.idmodelparamvalue).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idmodelparamNavigation)
                    .WithMany(p => p.modelparamvalue)
                    .HasForeignKey(d => d.idmodelparam)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_modelparamvalue_modelparam");

                entity.HasOne(d => d.idvectorpictureNavigation)
                    .WithMany(p => p.modelparamvalue)
                    .HasForeignKey(d => d.idvectorpicture)
                    .HasConstraintName("FK_modelparamvalue_vectorpicture");
            });

            modelBuilder.Entity<modelpart>(entity =>
            {
                entity.HasKey(e => e.idmodelpart)
                    .HasName("pk_modelpart");

                entity.Property(e => e.idmodelpart).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.modelpart)
                    .HasForeignKey(d => d.idversion)
                    .HasConstraintName("FK_modelpart_versions");
            });

            modelBuilder.Entity<modelpic>(entity =>
            {
                entity.Property(e => e.idmodelpic).ValueGeneratedNever();

                entity.Property(e => e.typ).HasComment("Тип записи. 0-Картинки для списка конструкций в заказе, 1-Картинки для списка заказов, 2-Картинки непрямоугольных заполнений, 3-Картинки декоративных раскладок");

                entity.HasOne(d => d.idmodelNavigation)
                    .WithMany(p => p.modelpic)
                    .HasForeignKey(d => d.idmodel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_modelpic_model");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.modelpic)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_modelpic_orders");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.modelpic)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_modelpic_orderitem");
            });

            modelBuilder.Entity<modelscript>(entity =>
            {
                entity.HasKey(e => e.idmodelscript)
                    .HasName("pk_modelscript");

                entity.Property(e => e.idmodelscript).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idmodelpartNavigation)
                    .WithMany(p => p.modelscript)
                    .HasForeignKey(d => d.idmodelpart)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_modelscript_modelpart");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.modelscript)
                    .HasForeignKey(d => d.idversion)
                    .HasConstraintName("FK_modelscript_version");
            });

            modelBuilder.Entity<nopaper>(entity =>
            {
                entity.Property(e => e.idnopaper).ValueGeneratedNever();

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.nopaper)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_nopaper_orderitem");
            });

            modelBuilder.Entity<optimdoc>(entity =>
            {
                entity.Property(e => e.idoptimdoc).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.optimdoc)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_optimdoc_customer");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.optimdoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_optimdoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.optimdoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_optimdoc_docstate");

                entity.HasOne(d => d.idoptimdocgroupNavigation)
                    .WithMany(p => p.optimdoc)
                    .HasForeignKey(d => d.idoptimdocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdoc_optimdocgroup");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.optimdoc)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_optimdoc_orders");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.optimdoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_optimdoc_people");

                entity.HasOne(d => d.idstoredocNavigation)
                    .WithMany(p => p.optimdoc)
                    .HasForeignKey(d => d.idstoredoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdoc_storedoc");
            });

            modelBuilder.Entity<optimdocdiraction>(entity =>
            {
                entity.Property(e => e.idoptimdocdiraction).ValueGeneratedNever();

                entity.Property(e => e.dtcreate).HasComment("Дата создания этапа");

                entity.Property(e => e.dtedit).HasComment("Дата редактирования этапа");

                entity.Property(e => e.idpeople).HasComment("Пользователь, создавший этап");

                entity.Property(e => e.idpeopleedit).HasComment("Пользователь, редактировавший этап");

                entity.Property(e => e.idpeopleexec).HasComment("Исполнитель этапа");

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.optimdocdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocdiraction_diraction");

                entity.HasOne(d => d.idoptimdocNavigation)
                    .WithMany(p => p.optimdocdiraction)
                    .HasForeignKey(d => d.idoptimdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocdiraction_optimdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.optimdocdiractionidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_optimdocdiraction_people");

                entity.HasOne(d => d.idpeopleeditNavigation)
                    .WithMany(p => p.optimdocdiractionidpeopleeditNavigation)
                    .HasForeignKey(d => d.idpeopleedit)
                    .HasConstraintName("FK_optimdocdiraction_people1");

                entity.HasOne(d => d.idpeopleexecNavigation)
                    .WithMany(p => p.optimdocdiractionidpeopleexecNavigation)
                    .HasForeignKey(d => d.idpeopleexec)
                    .HasConstraintName("FK_optimdocdiraction_people2");
            });

            modelBuilder.Entity<optimdocdiractionpeople>(entity =>
            {
                entity.Property(e => e.idoptimdocdiractionpeople).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.optimdocdiractionpeople)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_optimdocdiractionpeople_people");
            });

            modelBuilder.Entity<optimdocgoodin>(entity =>
            {
                entity.Property(e => e.idoptimdocgoodin).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.optimdocgoodin)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocgoodin_good");

                entity.HasOne(d => d.idgoodbufferNavigation)
                    .WithMany(p => p.optimdocgoodin)
                    .HasForeignKey(d => d.idgoodbuffer)
                    .HasConstraintName("FK_optimdocgoodin_goodbuffer");

                entity.HasOne(d => d.idoptimdocNavigation)
                    .WithMany(p => p.optimdocgoodin)
                    .HasForeignKey(d => d.idoptimdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocgoodin_optimdoc");

                entity.HasOne(d => d.idoptimdocgoodoutNavigation)
                    .WithMany(p => p.optimdocgoodin)
                    .HasForeignKey(d => d.idoptimdocgoodout)
                    .HasConstraintName("FK_optimdocgoodin_optimdocgoodout");

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentid)
                    .HasConstraintName("FK_optimdocgoodin_optimdocgoodin");
            });

            modelBuilder.Entity<optimdocgoodout>(entity =>
            {
                entity.Property(e => e.idoptimdocgoodout).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.optimdocgoodout)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocgoodout_good");

                entity.HasOne(d => d.idgoodbufferNavigation)
                    .WithMany(p => p.optimdocgoodout)
                    .HasForeignKey(d => d.idgoodbuffer)
                    .HasConstraintName("FK_optimdocgoodout_goodbuffer");

                entity.HasOne(d => d.idoptimdocNavigation)
                    .WithMany(p => p.optimdocgoodout)
                    .HasForeignKey(d => d.idoptimdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocgoodout_optimdoc");
            });

            modelBuilder.Entity<optimdocgroup>(entity =>
            {
                entity.Property(e => e.idoptimdocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<optimdocpic>(entity =>
            {
                entity.Property(e => e.idoptimdocpic).ValueGeneratedNever();

                entity.Property(e => e._class).HasComment("Сериализованный результат оптимизации");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.optimdocpic)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocpic_good");

                entity.HasOne(d => d.idgoodbufferNavigation)
                    .WithMany(p => p.optimdocpic)
                    .HasForeignKey(d => d.idgoodbuffer)
                    .HasConstraintName("FK_optimdocpic_goodbuffer");

                entity.HasOne(d => d.idoptimdocNavigation)
                    .WithMany(p => p.optimdocpic)
                    .HasForeignKey(d => d.idoptimdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocpic_optimdoc");

                entity.HasOne(d => d.idoptimdocgoodinNavigation)
                    .WithMany(p => p.optimdocpic)
                    .HasForeignKey(d => d.idoptimdocgoodin)
                    .HasConstraintName("FK_optimdocpic_optimdocgoodin");

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentid)
                    .HasConstraintName("FK_optimdocpic_optimdocpic");
            });

            modelBuilder.Entity<optimdocpos>(entity =>
            {
                entity.Property(e => e.idoptimdocpos).ValueGeneratedNever();

                entity.Property(e => e.idorderitem).HasComment("Позиция заказа");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.optimdocpos)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocpos_good");

                entity.HasOne(d => d.idmanufactdocposNavigation)
                    .WithMany(p => p.optimdocpos)
                    .HasForeignKey(d => d.idmanufactdocpos)
                    .HasConstraintName("FK_optimdocpos_manufactdocpos");

                entity.HasOne(d => d.idmodelcalcNavigation)
                    .WithMany(p => p.optimdocpos)
                    .HasForeignKey(d => d.idmodelcalc)
                    .HasConstraintName("FK_optimdocpos_modelcalc");

                entity.HasOne(d => d.idoptimdocNavigation)
                    .WithMany(p => p.optimdocpos)
                    .HasForeignKey(d => d.idoptimdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocpos_optimdoc");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.optimdocpos)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_optimdocpos_order");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.optimdocpos)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocpos_orderitem");
            });

            modelBuilder.Entity<optimdocsign>(entity =>
            {
                entity.Property(e => e.idoptimdocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idoptimdocNavigation)
                    .WithMany(p => p.optimdocsign)
                    .HasForeignKey(d => d.idoptimdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_optimdocsign_optimdoc");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.optimdocsign)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_optimdocsign_optimdocpos");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.optimdocsign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_optimdocsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.optimdocsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_optimdocsign_sign");

                entity.HasOne(d => d.idsignvalueNavigation)
                    .WithMany(p => p.optimdocsign)
                    .HasForeignKey(d => d.idsignvalue)
                    .HasConstraintName("FK_optimdocsign_signvalue");
            });

            modelBuilder.Entity<orderbudget>(entity =>
            {
                entity.Property(e => e.idorderbudget).ValueGeneratedNever();

                entity.HasOne(d => d.idbudgetNavigation)
                    .WithMany(p => p.orderbudget)
                    .HasForeignKey(d => d.idbudget)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_orderbudget_budget");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.orderbudget)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_orderbudget_orders");
            });

            modelBuilder.Entity<orderdiraction>(entity =>
            {
                entity.HasKey(e => e.idorderdiraction)
                    .HasName("pk_orderdiraction");

                entity.Property(e => e.idorderdiraction).ValueGeneratedNever();

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.orderdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_orderdiraction_diraction");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.orderdiraction)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_orderdiraction_orders");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.orderdiraction)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orderdiraction_people");
            });

            modelBuilder.Entity<orderdiractionpeople>(entity =>
            {
                entity.HasKey(e => e.idorderdiractionpeople)
                    .HasName("PK_diractionpeople");

                entity.Property(e => e.idorderdiractionpeople).ValueGeneratedNever();

                entity.HasOne(d => d.idorderdiractionNavigation)
                    .WithMany(p => p.orderdiractionpeople)
                    .HasForeignKey(d => d.idorderdiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_orderdiractionpeople_orderdiraction");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.orderdiractionpeople)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_orderdiractionpeople_people");
            });

            modelBuilder.Entity<orderdiscard>(entity =>
            {
                entity.Property(e => e.idorderdiscard).ValueGeneratedNever();

                entity.HasOne(d => d.iddiscardNavigation)
                    .WithMany(p => p.orderdiscard)
                    .HasForeignKey(d => d.iddiscard)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orderdiscard_discard");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.orderdiscard)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orderdiscard_orders");
            });

            modelBuilder.Entity<ordererror>(entity =>
            {
                entity.Property(e => e.idordererror).ValueGeneratedNever();

                entity.Property(e => e.modelpart).HasComment("Часть модели");

                entity.HasOne(d => d.iderrorNavigation)
                    .WithMany(p => p.ordererror)
                    .HasForeignKey(d => d.iderror)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ordererror_error");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.ordererror)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_ordererror_orders");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.ordererror)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_ordererror_orderitem");
            });

            modelBuilder.Entity<orderevent>(entity =>
            {
                entity.Property(e => e.idorderevent).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idordereventgroupNavigation)
                    .WithMany(p => p.orderevent)
                    .HasForeignKey(d => d.idordereventgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_orderevent_ordereventgroup");
            });

            modelBuilder.Entity<ordereventgroup>(entity =>
            {
                entity.Property(e => e.idordereventgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<orderfile>(entity =>
            {
                entity.Property(e => e.idorderfile).ValueGeneratedNever();

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.orderfile)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_orderfile_orders");
            });

            modelBuilder.Entity<ordergood>(entity =>
            {
                entity.Property(e => e.idordergood).ValueGeneratedNever();

                entity.Property(e => e.quinmanufact).HasComment("Количество в производственном задании");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.ordergood)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ordergood_good");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.ordergood)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_ordergood_orders");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.ordergood)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ordergood_orderitem");
            });

            modelBuilder.Entity<ordergoodservice>(entity =>
            {
                entity.Property(e => e.idordergoodservice).ValueGeneratedNever();

                entity.Property(e => e.date1).HasComment("Дата 1(смысл на усмотрение компании)");

                entity.Property(e => e.date2).HasComment("Дата 2(смысл на усмотрение компании)");

                entity.Property(e => e.date3).HasComment("Дата 3(смысл на усмотрение компании)");

                entity.HasOne(d => d.idgoodserviceNavigation)
                    .WithMany(p => p.ordergoodservice)
                    .HasForeignKey(d => d.idgoodservice)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ordergoodservice_goodservice");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.ordergoodservice)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ordergoodservice_orders");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.ordergoodservice)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_ordergoodservice_orderitem");
            });

            modelBuilder.Entity<orderitem>(entity =>
            {
                entity.HasKey(e => e.idorderitem)
                    .HasName("pk_orderitem");

                entity.Property(e => e.idorderitem).ValueGeneratedNever();

                entity.Property(e => e.typ).HasComment("Тип записи. 0-Доп.материал, 1-2D модель, 2-3D модель, 3-Продукция");

                entity.HasOne(d => d.idcolorinNavigation)
                    .WithMany(p => p.orderitemidcolorinNavigation)
                    .HasForeignKey(d => d.idcolorin)
                    .HasConstraintName("FK_orderitem_color");

                entity.HasOne(d => d.idcoloroutNavigation)
                    .WithMany(p => p.orderitemidcoloroutNavigation)
                    .HasForeignKey(d => d.idcolorout)
                    .HasConstraintName("FK_orderitem_color1");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.orderitem)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orderitem_good");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.orderitem)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_orderitem_orders");

                entity.HasOne(d => d.idpowerNavigation)
                    .WithMany(p => p.orderitem)
                    .HasForeignKey(d => d.idpower)
                    .HasConstraintName("FK_orderitem_power");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.orderitem)
                    .HasForeignKey(d => d.idproductiontype)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orderitem_produtiontype");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.orderitem)
                    .HasForeignKey(d => d.idversion)
                    .HasConstraintName("FK_orderitem_versions");
            });

            modelBuilder.Entity<orderpricechange>(entity =>
            {
                entity.Property(e => e.idorderpricechange).ValueGeneratedNever();

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.orderpricechange)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_orderpricechange_orders");

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.orderpricechange)
                    .HasForeignKey(d => d.idpricechange)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_orderpricechange_pricechange");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.orderpricechange)
                    .HasForeignKey(d => d.idvalut)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orderpricechange_valut");
            });

            modelBuilder.Entity<orders>(entity =>
            {
                entity.HasKey(e => e.idorder)
                    .HasName("pk_order");

                entity.Property(e => e.idorder).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idpeople2).HasComment("Сотрудник 2");

                entity.Property(e => e.idpeople3).HasComment("Сотрудник 3");

                entity.Property(e => e.idpeople4).HasComment("Сотрудник 4");

                entity.HasOne(d => d.idaddressNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.idaddress)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_address");

                entity.HasOne(d => d.idagreeNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.idagree)
                    .HasConstraintName("FK_orders_agree");

                entity.HasOne(d => d.idagreementNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.idagreement)
                    .HasConstraintName("FK_orders_agreement");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.ordersidcustomerNavigation)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_customer");

                entity.HasOne(d => d.idcustomer2Navigation)
                    .WithMany(p => p.ordersidcustomer2Navigation)
                    .HasForeignKey(d => d.idcustomer2)
                    .HasConstraintName("FK_orders_customer1");

                entity.HasOne(d => d.idcustomer3Navigation)
                    .WithMany(p => p.ordersidcustomer3Navigation)
                    .HasForeignKey(d => d.idcustomer3)
                    .HasConstraintName("FK_orders_customer2");

                entity.HasOne(d => d.iddepartmentNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.iddepartment)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_department");

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.iddestanation)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_destanation");

                entity.HasOne(d => d.iddiscardNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.iddiscard)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_discard");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_orders_docstate");

                entity.HasOne(d => d.idordersgroupNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.idordersgroup)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_ordersgroup");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.ordersidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_people");

                entity.HasOne(d => d.idpeopledesignerNavigation)
                    .WithMany(p => p.ordersidpeopledesignerNavigation)
                    .HasForeignKey(d => d.idpeopledesigner)
                    .HasConstraintName("FK_orders_peopledesigner");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.idseller)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_seller");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.idvalut)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_valut");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.orders)
                    .HasForeignKey(d => d.idversion)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_version");
            });

            modelBuilder.Entity<ordersetting>(entity =>
            {
                entity.Property(e => e.idordersetting).ValueGeneratedNever();

                entity.HasOne(d => d.idmodelNavigation)
                    .WithMany(p => p.ordersetting)
                    .HasForeignKey(d => d.idmodel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ordersetting_model");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.ordersetting)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_ordersetting_orders");

                entity.HasOne(d => d.idsettingNavigation)
                    .WithMany(p => p.ordersetting)
                    .HasForeignKey(d => d.idsetting)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ordersetting_setting");
            });

            modelBuilder.Entity<ordersgroup>(entity =>
            {
                entity.HasKey(e => e.idordersgroup)
                    .HasName("ordersgroup_pkey");

                entity.Property(e => e.idordersgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<ordersign>(entity =>
            {
                entity.HasKey(e => e.idordersign)
                    .HasName("pk_ordersign");

                entity.Property(e => e.idordersign).ValueGeneratedNever();

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.ordersign)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ordersign_orders");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.ordersign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ordersign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.ordersign)
                    .HasForeignKey(d => d.idsign)
                    .HasConstraintName("ordersign_fk1");

                entity.HasOne(d => d.idsignvalueNavigation)
                    .WithMany(p => p.ordersign)
                    .HasForeignKey(d => d.idsignvalue)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_ordersign_3");
            });

            modelBuilder.Entity<payment>(entity =>
            {
                entity.ToView("payment");
            });

            modelBuilder.Entity<paymentdoc>(entity =>
            {
                entity.HasKey(e => e.idpaymentdoc)
                    .HasName("payment_pkey");

                entity.Property(e => e.idpaymentdoc).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcashboxNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idcashbox)
                    .HasConstraintName("FK_paymentdoc_cashbox");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_payment_customer");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_payment_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_paymentdoc_docstate");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_payment_orders");

                entity.HasOne(d => d.idpaymentdocgroupNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idpaymentdocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_payment_paymentdocgroup");

                entity.HasOne(d => d.idpaymentgroupNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idpaymentgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_payment_paymentgroup");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_paymentdoc_people");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idseller)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_payment_seller");

                entity.HasOne(d => d.idservicedocNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idservicedoc)
                    .HasConstraintName("FK_paymentdoc_servicedoc");

                entity.HasOne(d => d.idsupplydocNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idsupplydoc)
                    .HasConstraintName("FK_paymentdoc_supplydoc");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.paymentdoc)
                    .HasForeignKey(d => d.idvalut)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_payment_valut");
            });

            modelBuilder.Entity<paymentdocgroup>(entity =>
            {
                entity.Property(e => e.idpaymentdocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<paymentdocsign>(entity =>
            {
                entity.Property(e => e.idpaymentdocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idpaymentdocNavigation)
                    .WithMany(p => p.paymentdocsign)
                    .HasForeignKey(d => d.idpaymentdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_paymentdocsign_paymentdoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.paymentdocsign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_paymentdocsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.paymentdocsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_paymentdocsign_sign");
            });

            modelBuilder.Entity<paymentgroup>(entity =>
            {
                entity.HasKey(e => e.idpaymentgroup)
                    .HasName("paymentgroup_pkey");

                entity.Property(e => e.idpaymentgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<people>(entity =>
            {
                entity.HasKey(e => e.idpeople)
                    .HasName("pk_people");

                entity.Property(e => e.idpeople).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.iddepartment).HasComment("Ссылка на отдел");

                entity.Property(e => e.indealerbase).HasComment("Переносить в дилерскую версию");

                entity.HasOne(d => d.idpeoplepostNavigation)
                    .WithMany(p => p.people)
                    .HasForeignKey(d => d.idpeoplepost)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_people_peoplepost");
            });

            modelBuilder.Entity<peopledate>(entity =>
            {
                entity.Property(e => e.idpeopledate).ValueGeneratedNever();

                entity.HasOne(d => d.iddepartmentNavigation)
                    .WithMany(p => p.peopledate)
                    .HasForeignKey(d => d.iddepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_peopledate_department");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.peopledate)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_peopledate_people");
            });

            modelBuilder.Entity<peopledatetime>(entity =>
            {
                entity.Property(e => e.idpeopledatetime).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopledateNavigation)
                    .WithMany(p => p.peopledatetime)
                    .HasForeignKey(d => d.idpeopledate)
                    .HasConstraintName("FK_peopledatetime_peopledate");
            });

            modelBuilder.Entity<peoplegroup>(entity =>
            {
                entity.Property(e => e.idpeoplegroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.indealerbase).HasComment("Переносить в дилерскую версию");
            });

            modelBuilder.Entity<peoplegrouplist>(entity =>
            {
                entity.Property(e => e.idpeoplegrouplist).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.peoplegrouplist)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_peoplegrouplist_people");

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.peoplegrouplist)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_peoplegrouplist_peoplegroup");
            });

            modelBuilder.Entity<peopleparam>(entity =>
            {
                entity.Property(e => e.idpeopleparam).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.peopleparam)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_peopleparam_people");

                entity.HasOne(d => d.idpeopleparamtypeNavigation)
                    .WithMany(p => p.peopleparam)
                    .HasForeignKey(d => d.idpeopleparamtype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_peopleparam_peopleparamtype");
            });

            modelBuilder.Entity<peopleparamtype>(entity =>
            {
                entity.Property(e => e.idpeopleparamtype).ValueGeneratedNever();
            });

            modelBuilder.Entity<peoplepost>(entity =>
            {
                entity.Property(e => e.idpeoplepost).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idpeoplepostgroup).HasComment("Ссылка на группу должностей");

                entity.HasOne(d => d.idpeoplepostgroupNavigation)
                    .WithMany(p => p.peoplepost)
                    .HasForeignKey(d => d.idpeoplepostgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_peoplepost_peoplepostgroup");
            });

            modelBuilder.Entity<peoplepostgroup>(entity =>
            {
                entity.HasComment("Группы должностей");

                entity.Property(e => e.idpeoplepostgroup)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Признак удалённости");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.name).HasComment("Наименование группы");

                entity.Property(e => e.parentid).HasComment("Ссылка на верхний уровень");
            });

            modelBuilder.Entity<pf_glass>(entity =>
            {
                entity.Property(e => e.idpf_glass).ValueGeneratedNever();

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany(p => p.pf_glassidcolor1Navigation)
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_pf_glass_color");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany(p => p.pf_glassidcolor2Navigation)
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_pf_glass_color1");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.pf_glass)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_pf_glass_constructiontype");

                entity.HasOne(d => d.idmodelparam1Navigation)
                    .WithMany(p => p.pf_glassidmodelparam1Navigation)
                    .HasForeignKey(d => d.idmodelparam1)
                    .HasConstraintName("FK_pf_glass_modelparam");

                entity.HasOne(d => d.idmodelparam2Navigation)
                    .WithMany(p => p.pf_glassidmodelparam2Navigation)
                    .HasForeignKey(d => d.idmodelparam2)
                    .HasConstraintName("FK_pf_glass_modelparam1");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.pf_glass)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_pf_glass_productiontype");

                entity.HasOne(d => d.idsystem_furnitureNavigation)
                    .WithMany(p => p.pf_glassidsystem_furnitureNavigation)
                    .HasForeignKey(d => d.idsystem_furniture)
                    .HasConstraintName("FK_pf_glass_system_furniture");

                entity.HasOne(d => d.idsystem_profileNavigation)
                    .WithMany(p => p.pf_glassidsystem_profileNavigation)
                    .HasForeignKey(d => d.idsystem_profile)
                    .HasConstraintName("FK_pf_glass_system_profile");
            });

            modelBuilder.Entity<pf_glass_ct_source>(entity =>
            {
                entity.Property(e => e.idpf_glass_ct_source).ValueGeneratedNever();

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.pf_glass_ct_source)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_pf_glass_ct_source_constructiontype");

                entity.HasOne(d => d.idpf_glassNavigation)
                    .WithMany(p => p.pf_glass_ct_source)
                    .HasForeignKey(d => d.idpf_glass)
                    .HasConstraintName("FK_pf_glass_ct_source_pf_glass");
            });

            modelBuilder.Entity<pf_glass_source_ge>(entity =>
            {
                entity.Property(e => e.idpf_glass_source_ge).ValueGeneratedNever();

                entity.HasOne(d => d.idglasselementNavigation)
                    .WithMany(p => p.pf_glass_source_ge)
                    .HasForeignKey(d => d.idglasselement)
                    .HasConstraintName("FK_pf_glass_source_ge_glasselement");

                entity.HasOne(d => d.idpf_glassNavigation)
                    .WithMany(p => p.pf_glass_source_ge)
                    .HasForeignKey(d => d.idpf_glass)
                    .HasConstraintName("FK_pf_glass_source_ge_pf_glass");
            });

            modelBuilder.Entity<pf_glass_source_glass>(entity =>
            {
                entity.Property(e => e.idpf_glass_source_glass).ValueGeneratedNever();

                entity.HasOne(d => d.idglassNavigation)
                    .WithMany(p => p.pf_glass_source_glass)
                    .HasForeignKey(d => d.idglass)
                    .HasConstraintName("FK_pf_glass_source_glass_glass");

                entity.HasOne(d => d.idpf_glassNavigation)
                    .WithMany(p => p.pf_glass_source_glass)
                    .HasForeignKey(d => d.idpf_glass)
                    .HasConstraintName("FK_pf_glass_source_glass_pf_glass");
            });

            modelBuilder.Entity<pf_ms>(entity =>
            {
                entity.Property(e => e.idpf_ms).ValueGeneratedNever();

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany(p => p.pf_msidcolor1Navigation)
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_pf_ms_color");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany(p => p.pf_msidcolor2Navigation)
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_pf_ms_color1");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.pf_ms)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_pf_ms_constructiontype");

                entity.HasOne(d => d.idglassNavigation)
                    .WithMany(p => p.pf_ms)
                    .HasForeignKey(d => d.idglass)
                    .HasConstraintName("FK_pf_ms_glass");

                entity.HasOne(d => d.idmodelparam1Navigation)
                    .WithMany(p => p.pf_msidmodelparam1Navigation)
                    .HasForeignKey(d => d.idmodelparam1)
                    .HasConstraintName("FK_pf_ms_idmodelparam1");

                entity.HasOne(d => d.idmodelparam2Navigation)
                    .WithMany(p => p.pf_msidmodelparam2Navigation)
                    .HasForeignKey(d => d.idmodelparam2)
                    .HasConstraintName("FK_pf_ms_idmodelparam2");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.pf_ms)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_pf_ms_modelparamvalue");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.pf_ms)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_pf_ms_productiontype");

                entity.HasOne(d => d.idsystem_furnitureNavigation)
                    .WithMany(p => p.pf_msidsystem_furnitureNavigation)
                    .HasForeignKey(d => d.idsystem_furniture)
                    .HasConstraintName("FK_pf_ms_system");

                entity.HasOne(d => d.idsystem_profileNavigation)
                    .WithMany(p => p.pf_msidsystem_profileNavigation)
                    .HasForeignKey(d => d.idsystem_profile)
                    .HasConstraintName("FK_pf_ms_system1");
            });

            modelBuilder.Entity<pf_ms_ct_source>(entity =>
            {
                entity.Property(e => e.idpf_ms_ct_source).ValueGeneratedNever();

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.pf_ms_ct_source)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_pf_ms_ct_source_constructiontype");

                entity.HasOne(d => d.idpf_msNavigation)
                    .WithMany(p => p.pf_ms_ct_source)
                    .HasForeignKey(d => d.idpf_ms)
                    .HasConstraintName("FK_pf_ms_ct_source_pf_ms");
            });

            modelBuilder.Entity<pf_ms_mp_filtr>(entity =>
            {
                entity.HasKey(e => e.idpf_ms_mp_filtr)
                    .HasName("PK_pf_ms_mp");

                entity.Property(e => e.idpf_ms_mp_filtr).ValueGeneratedNever();

                entity.Property(e => e.isvalue1).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.pf_ms_mp_filtr)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_pf_ms_mp_modelparamvalue");

                entity.HasOne(d => d.idpf_msNavigation)
                    .WithMany(p => p.pf_ms_mp_filtr)
                    .HasForeignKey(d => d.idpf_ms)
                    .HasConstraintName("FK_pf_ms_mp_pf_ms");
            });

            modelBuilder.Entity<pf_ms_mp_set>(entity =>
            {
                entity.Property(e => e.idpf_ms_mp_set).ValueGeneratedNever();

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.pf_ms_mp_set)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_pf_ms_mp_set_modelparamvalue");

                entity.HasOne(d => d.idpf_msNavigation)
                    .WithMany(p => p.pf_ms_mp_set)
                    .HasForeignKey(d => d.idpf_ms)
                    .HasConstraintName("FK_pf_ms_mp_set_pf_ms");
            });

            modelBuilder.Entity<pf_pt>(entity =>
            {
                entity.Property(e => e.idpf_pt).ValueGeneratedNever();

                entity.Property(e => e.hide).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.idcoloraccordance1Navigation)
                    .WithMany(p => p.pf_ptidcoloraccordance1Navigation)
                    .HasForeignKey(d => d.idcoloraccordance1)
                    .HasConstraintName("FK_pf_pt_coloraccordance1");

                entity.HasOne(d => d.idcoloraccordance2Navigation)
                    .WithMany(p => p.pf_ptidcoloraccordance2Navigation)
                    .HasForeignKey(d => d.idcoloraccordance2)
                    .HasConstraintName("FK_pf_pt_coloraccordance2");

                entity.HasOne(d => d.idmodelparam1Navigation)
                    .WithMany(p => p.pf_ptidmodelparam1Navigation)
                    .HasForeignKey(d => d.idmodelparam1)
                    .HasConstraintName("FK_pf_pt_idmodelparam1");

                entity.HasOne(d => d.idmodelparam2Navigation)
                    .WithMany(p => p.pf_ptidmodelparam2Navigation)
                    .HasForeignKey(d => d.idmodelparam2)
                    .HasConstraintName("FK_pf_pt_idmodelparam2");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.pf_pt)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_pf_pt_productiontype");

                entity.HasOne(d => d.idsystemdetailNavigation)
                    .WithMany(p => p.pf_pt)
                    .HasForeignKey(d => d.idsystemdetail)
                    .HasConstraintName("FK_pf_pt_systemdetail");
            });

            modelBuilder.Entity<pf_pt_ct_source>(entity =>
            {
                entity.Property(e => e.idpf_pt_ct_source).ValueGeneratedNever();

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.pf_pt_ct_source)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_pf_pt_ct_source_constructiontype");

                entity.HasOne(d => d.idpf_ptNavigation)
                    .WithMany(p => p.pf_pt_ct_source)
                    .HasForeignKey(d => d.idpf_pt)
                    .HasConstraintName("FK_pf_pt_ct_source_pf_pt");
            });

            modelBuilder.Entity<pf_pt_mp_filtr>(entity =>
            {
                entity.Property(e => e.idpf_pt_mp_filtr).ValueGeneratedNever();

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.pf_pt_mp_filtr)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_pf_pt_mp_modelparamvalue");

                entity.HasOne(d => d.idpf_ptNavigation)
                    .WithMany(p => p.pf_pt_mp_filtr)
                    .HasForeignKey(d => d.idpf_pt)
                    .HasConstraintName("FK_pf_pt_mp_pf_pt");
            });

            modelBuilder.Entity<pf_pt_mp_set>(entity =>
            {
                entity.Property(e => e.idpf_pt_mp_set).ValueGeneratedNever();

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.pf_pt_mp_set)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_pf_pt_mp_set_modelparamvalue");

                entity.HasOne(d => d.idpf_ptNavigation)
                    .WithMany(p => p.pf_pt_mp_set)
                    .HasForeignKey(d => d.idpf_pt)
                    .HasConstraintName("FK_pf_pt_mp_set_pf_pt");
            });

            modelBuilder.Entity<pf_stv>(entity =>
            {
                entity.Property(e => e.idpf_stv).ValueGeneratedNever();

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.pf_stv)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_pf_stv_constructiontype");

                entity.HasOne(d => d.idglassNavigation)
                    .WithMany(p => p.pf_stv)
                    .HasForeignKey(d => d.idglass)
                    .HasConstraintName("FK_pf_stv_glass");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.pf_stv)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_pf_stv_productiontype");
            });

            modelBuilder.Entity<pf_stv_ct_source>(entity =>
            {
                entity.Property(e => e.idpf_stv_ct_source).ValueGeneratedNever();

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.pf_stv_ct_source)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_pf_stv_ct_source_constructiontype");

                entity.HasOne(d => d.idpf_stvNavigation)
                    .WithMany(p => p.pf_stv_ct_source)
                    .HasForeignKey(d => d.idpf_stv)
                    .HasConstraintName("FK_pf_stv_ct_source_pf_stv");
            });

            modelBuilder.Entity<pf_stv_mp>(entity =>
            {
                entity.Property(e => e.idpf_stv_mp).ValueGeneratedNever();

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.pf_stv_mp)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_pf_stv_mp_modelparamvalue");

                entity.HasOne(d => d.idpf_stvNavigation)
                    .WithMany(p => p.pf_stv_mp)
                    .HasForeignKey(d => d.idpf_stv)
                    .HasConstraintName("FK_pf_stv_mp_pf_stv");
            });

            modelBuilder.Entity<pg_1c_view_customer>(entity =>
            {
                entity.ToView("pg_1c_view_customer");
            });

            modelBuilder.Entity<pg_1c_view_deliv>(entity =>
            {
                entity.ToView("pg_1c_view_deliv");
            });

            modelBuilder.Entity<pg_1c_view_delivpos>(entity =>
            {
                entity.ToView("pg_1c_view_delivpos");
            });

            modelBuilder.Entity<pg_1c_view_gp>(entity =>
            {
                entity.ToView("pg_1c_view_gp");
            });

            modelBuilder.Entity<pg_1c_view_gp_head>(entity =>
            {
                entity.ToView("pg_1c_view_gp_head");
            });

            modelBuilder.Entity<pg_1c_view_orderinfo>(entity =>
            {
                entity.ToView("pg_1c_view_orderinfo");
            });

            modelBuilder.Entity<pg_1c_view_orderpos>(entity =>
            {
                entity.ToView("pg_1c_view_orderpos");
            });

            modelBuilder.Entity<pg_1c_view_pay>(entity =>
            {
                entity.ToView("pg_1c_view_pay");
            });

            modelBuilder.Entity<pg_1c_view_store>(entity =>
            {
                entity.ToView("pg_1c_view_store");
            });

            modelBuilder.Entity<pg_1c_view_storepos>(entity =>
            {
                entity.ToView("pg_1c_view_storepos");
            });

            modelBuilder.Entity<pg_1c_view_supply>(entity =>
            {
                entity.ToView("pg_1c_view_supply");
            });

            modelBuilder.Entity<pg_1c_view_supplypos>(entity =>
            {
                entity.ToView("pg_1c_view_supplypos");
            });

            modelBuilder.Entity<pg_lamin_condition>(entity =>
            {
                entity.Property(e => e.color_name).IsFixedLength();
            });

            modelBuilder.Entity<pg_view_need_good>(entity =>
            {
                entity.ToView("pg_view_need_good");
            });

            modelBuilder.Entity<pg_view_payment>(entity =>
            {
                entity.ToView("pg_view_payment");
            });

            modelBuilder.Entity<picture>(entity =>
            {
                entity.Property(e => e.idpicture).ValueGeneratedNever();
            });

            modelBuilder.Entity<poll>(entity =>
            {
                entity.Property(e => e.idpoll).ValueGeneratedNever();

                entity.HasOne(d => d.idpollgroupNavigation)
                    .WithMany(p => p.poll)
                    .HasForeignKey(d => d.idpollgroup)
                    .HasConstraintName("FK_poll_pollgroup");
            });

            modelBuilder.Entity<pollanswer>(entity =>
            {
                entity.Property(e => e.idpollanswer).ValueGeneratedNever();
            });

            modelBuilder.Entity<pollexecuting>(entity =>
            {
                entity.Property(e => e.idpollexecuting).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.pollexecutingidcustomerNavigation)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_pollexecuting_customer");

                entity.HasOne(d => d.idcustomer2Navigation)
                    .WithMany(p => p.pollexecutingidcustomer2Navigation)
                    .HasForeignKey(d => d.idcustomer2)
                    .HasConstraintName("FK_pollexecuting_customer2");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.pollexecuting)
                    .HasForeignKey(d => d.iddocoper)
                    .HasConstraintName("FK_pollexecuting_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.pollexecuting)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_pollexecuting_docstate");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.pollexecuting)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_pollexecuting_orders");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.pollexecutingidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_pollexecuting_people");

                entity.HasOne(d => d.idpeoplecreateNavigation)
                    .WithMany(p => p.pollexecutingidpeoplecreateNavigation)
                    .HasForeignKey(d => d.idpeoplecreate)
                    .HasConstraintName("FK_pollexecuting_people_cre");

                entity.HasOne(d => d.idpollNavigation)
                    .WithMany(p => p.pollexecuting)
                    .HasForeignKey(d => d.idpoll)
                    .HasConstraintName("FK_pollexecuting_poll");

                entity.HasOne(d => d.idpollexecutinggroupNavigation)
                    .WithMany(p => p.pollexecuting)
                    .HasForeignKey(d => d.idpollexecutinggroup)
                    .HasConstraintName("FK_pollexecuting_pollexecutinggroup");
            });

            modelBuilder.Entity<pollexecutingdiraction>(entity =>
            {
                entity.Property(e => e.idpollexecutingdiraction).ValueGeneratedNever();

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.pollexecutingdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .HasConstraintName("FK_pollexecutingdiraction_diraction");

                entity.HasOne(d => d.idpeopleсreateNavigation)
                    .WithMany(p => p.pollexecutingdiraction)
                    .HasForeignKey(d => d.idpeopleсreate)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_pollexecutingdiraction_people");

                entity.HasOne(d => d.idpollexecutingNavigation)
                    .WithMany(p => p.pollexecutingdiraction)
                    .HasForeignKey(d => d.idpollexecuting)
                    .HasConstraintName("FK_pollexecutingdiraction_pollexecuting");
            });

            modelBuilder.Entity<pollexecutinggroup>(entity =>
            {
                entity.Property(e => e.idpollexecutinggroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<pollexecutingitem>(entity =>
            {
                entity.Property(e => e.idpollexecutingitem).ValueGeneratedNever();

                entity.HasOne(d => d.idpollexecutingNavigation)
                    .WithMany(p => p.pollexecutingitem)
                    .HasForeignKey(d => d.idpollexecuting)
                    .HasConstraintName("FK_pollexecutingitem_pollexecuting");

                entity.HasOne(d => d.idpollrelationNavigation)
                    .WithMany(p => p.pollexecutingitem)
                    .HasForeignKey(d => d.idpollrelation)
                    .HasConstraintName("FK_pollexecutingitem_pollrelation");
            });

            modelBuilder.Entity<pollexecutingitemanswer>(entity =>
            {
                entity.Property(e => e.idpollexecutingitemanswer).ValueGeneratedNever();

                entity.HasOne(d => d.idpollexecutingitemNavigation)
                    .WithMany(p => p.pollexecutingitemanswer)
                    .HasForeignKey(d => d.idpollexecutingitem)
                    .HasConstraintName("FK_pollexecutingitemanswer_pollexecutingitem");

                entity.HasOne(d => d.idpollrelationNavigation)
                    .WithMany(p => p.pollexecutingitemanswer)
                    .HasForeignKey(d => d.idpollrelation)
                    .HasConstraintName("FK_pollexecutingitemanswer_pollrelation");
            });

            modelBuilder.Entity<pollexecutingsign>(entity =>
            {
                entity.Property(e => e.idpollexecutingsign).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.pollexecutingsign)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_pollexecutingsign_people");

                entity.HasOne(d => d.idpollexecutingNavigation)
                    .WithMany(p => p.pollexecutingsign)
                    .HasForeignKey(d => d.idpollexecuting)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pollexecutingsign_pollexecuting");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.pollexecutingsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_pollexecutingsign_sign");
            });

            modelBuilder.Entity<pollgroup>(entity =>
            {
                entity.Property(e => e.idpollgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<pollquestion>(entity =>
            {
                entity.Property(e => e.idpollquestion).ValueGeneratedNever();

                entity.HasOne(d => d.idpollNavigation)
                    .WithMany(p => p.pollquestion)
                    .HasForeignKey(d => d.idpoll)
                    .HasConstraintName("FK_pollquestion_poll");
            });

            modelBuilder.Entity<pollrelation>(entity =>
            {
                entity.Property(e => e.idpollrelation).ValueGeneratedNever();

                entity.HasOne(d => d.idpollanswerNavigation)
                    .WithMany(p => p.pollrelation)
                    .HasForeignKey(d => d.idpollanswer)
                    .HasConstraintName("FK_pollrelation_pollanswer");

                entity.HasOne(d => d.idpollquestionNavigation)
                    .WithMany(p => p.pollrelation)
                    .HasForeignKey(d => d.idpollquestion)
                    .HasConstraintName("FK_pollrelation_pollquestion");
            });

            modelBuilder.Entity<power>(entity =>
            {
                entity.Property(e => e.idpower).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.iddiraction1Navigation)
                    .WithMany(p => p.poweriddiraction1Navigation)
                    .HasForeignKey(d => d.iddiraction1)
                    .HasConstraintName("FK_power_diraction1");

                entity.HasOne(d => d.iddiraction2Navigation)
                    .WithMany(p => p.poweriddiraction2Navigation)
                    .HasForeignKey(d => d.iddiraction2)
                    .HasConstraintName("FK_power_diraction2");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.power)
                    .HasForeignKey(d => d.iddocoper)
                    .HasConstraintName("FK_power_iddocoper");

                entity.HasOne(d => d.idfinparamNavigation)
                    .WithMany(p => p.power)
                    .HasForeignKey(d => d.idfinparam)
                    .HasConstraintName("FK_power_finparam");

                entity.HasOne(d => d.idganttchartNavigation)
                    .WithMany(p => p.power)
                    .HasForeignKey(d => d.idganttchart)
                    .HasConstraintName("FK_power_ganttchart");

                entity.HasOne(d => d.idproductionsiteNavigation)
                    .WithMany(p => p.power)
                    .HasForeignKey(d => d.idproductionsite)
                    .HasConstraintName("FK_power_productionsite");
            });

            modelBuilder.Entity<powergrant>(entity =>
            {
                entity.Property(e => e.idpowergrant).ValueGeneratedNever();

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.powergrant)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_powergrant_peoplegroup");

                entity.HasOne(d => d.idpowerNavigation)
                    .WithMany(p => p.powergrant)
                    .HasForeignKey(d => d.idpower)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_powergrant_power");
            });

            modelBuilder.Entity<powerplan>(entity =>
            {
                entity.Property(e => e.idpowerplan).ValueGeneratedNever();

                entity.HasOne(d => d.idpowerNavigation)
                    .WithMany(p => p.powerplan)
                    .HasForeignKey(d => d.idpower)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_powerplan_power");
            });

            modelBuilder.Entity<powerrel>(entity =>
            {
                entity.Property(e => e.idpowerrel).ValueGeneratedNever();

                entity.HasOne(d => d.idpowermasterNavigation)
                    .WithMany(p => p.powerrelidpowermasterNavigation)
                    .HasForeignKey(d => d.idpowermaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_powerrel_master_power");

                entity.HasOne(d => d.idpowerslaveNavigation)
                    .WithMany(p => p.powerrelidpowerslaveNavigation)
                    .HasForeignKey(d => d.idpowerslave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_powerrel_slave_power");
            });

            modelBuilder.Entity<preference>(entity =>
            {
                entity.Property(e => e.idpreference).ValueGeneratedNever();
            });

            modelBuilder.Entity<pricechange>(entity =>
            {
                entity.Property(e => e.idpricechange).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.indealerbase).HasComment("Переносить в дилерскую версию");

                entity.Property(e => e.visibledealer).HasComment("Видимость в дилерской версии");

                entity.HasOne(d => d.idpricechangegroupNavigation)
                    .WithMany(p => p.pricechange)
                    .HasForeignKey(d => d.idpricechangegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricechange_pricechangegroup");
            });

            modelBuilder.Entity<pricechangegrant>(entity =>
            {
                entity.HasComment("Права на скидки и наценки");

                entity.Property(e => e.idpricechangegrant)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.deleted).HasComment("Признак удаления");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idpeoplegroup).HasComment("Скидка на группу пользователей");

                entity.Property(e => e.idpricechange).HasComment("Ссылка на скидку");

                entity.Property(e => e.isedit).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.pricechangegrant)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricechangegrant_peoplegroup");

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.pricechangegrant)
                    .HasForeignKey(d => d.idpricechange)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricechangegrant_pricechange");
            });

            modelBuilder.Entity<pricechangegroup>(entity =>
            {
                entity.Property(e => e.idpricechangegroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<pricelist>(entity =>
            {
                entity.Property(e => e.idpricelist).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.pricelist)
                    .HasForeignKey(d => d.idcustomer)
                    .HasConstraintName("FK_pricelist_customer");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.pricelist)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_pricelist_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.pricelist)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_pricelist_docstate");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.pricelist)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricelist_people");

                entity.HasOne(d => d.idpricelistgroupNavigation)
                    .WithMany(p => p.pricelist)
                    .HasForeignKey(d => d.idpricelistgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricelist_pricelistgroup");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.pricelist)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_pricelist_productiontype");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.pricelist)
                    .HasForeignKey(d => d.idseller)
                    .HasConstraintName("FK_pricelist_seller");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.pricelist)
                    .HasForeignKey(d => d.idversion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricelist_versions");
            });

            modelBuilder.Entity<pricelistgoodservice>(entity =>
            {
                entity.Property(e => e.idpricelistgoodservice).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodserviceNavigation)
                    .WithMany(p => p.pricelistgoodservice)
                    .HasForeignKey(d => d.idgoodservice)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricelistgoodservice_goodservice");

                entity.HasOne(d => d.idpricelistNavigation)
                    .WithMany(p => p.pricelistgoodservice)
                    .HasForeignKey(d => d.idpricelist)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricelistgoodservice_orders");

                entity.HasOne(d => d.idpricelistitemNavigation)
                    .WithMany(p => p.pricelistgoodservice)
                    .HasForeignKey(d => d.idpricelistitem)
                    .HasConstraintName("FK_pricelistgoodservice_orderitem");
            });

            modelBuilder.Entity<pricelistgroup>(entity =>
            {
                entity.Property(e => e.idpricelistgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<pricelistitem>(entity =>
            {
                entity.Property(e => e.idpricelistitem).ValueGeneratedNever();

                entity.HasOne(d => d.idpricelistNavigation)
                    .WithMany(p => p.pricelistitem)
                    .HasForeignKey(d => d.idpricelist)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricelistitem_pricelist");
            });

            modelBuilder.Entity<pricelistmodel>(entity =>
            {
                entity.HasKey(e => e.idpricelistmodel)
                    .HasName("pk_pricelistmodel");

                entity.Property(e => e.idpricelistmodel).ValueGeneratedNever();
            });

            modelBuilder.Entity<pricelistpricechange>(entity =>
            {
                entity.Property(e => e.idpricelistpricechange).ValueGeneratedNever();

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.pricelistpricechange)
                    .HasForeignKey(d => d.idpricechange)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricelistpricechange_pricechange");

                entity.HasOne(d => d.idpricelistNavigation)
                    .WithMany(p => p.pricelistpricechange)
                    .HasForeignKey(d => d.idpricelist)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_pricelistpricechange_pricelist");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.pricelistpricechange)
                    .HasForeignKey(d => d.idvalut)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_pricelistpricechange_valut");
            });

            modelBuilder.Entity<productiondoc>(entity =>
            {
                entity.Property(e => e.idproductiondoc).ValueGeneratedNever();

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.productiondoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiondoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.productiondoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_productiondoc_docstate");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.productiondoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_productiondoc_people");

                entity.HasOne(d => d.idproductiondocgroupNavigation)
                    .WithMany(p => p.productiondoc)
                    .HasForeignKey(d => d.idproductiondocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiondoc_group");
            });

            modelBuilder.Entity<productiondocgroup>(entity =>
            {
                entity.Property(e => e.idproductiondocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<productiondocpos>(entity =>
            {
                entity.Property(e => e.idproductiondocpos).ValueGeneratedNever();

                entity.HasOne(d => d.idmanufactdocposNavigation)
                    .WithMany(p => p.productiondocpos)
                    .HasForeignKey(d => d.idmanufactdocpos)
                    .HasConstraintName("FK_productiondocpos_manufactdocpos");

                entity.HasOne(d => d.idmodelNavigation)
                    .WithMany(p => p.productiondocpos)
                    .HasForeignKey(d => d.idmodel)
                    .HasConstraintName("FK_productiondocpos_model");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.productiondocpos)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiondocpos_orderitem");

                entity.HasOne(d => d.idproductiondocNavigation)
                    .WithMany(p => p.productiondocpos)
                    .HasForeignKey(d => d.idproductiondoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiondocpos_productiondoc");

                entity.HasOne(d => d.idstoredocNavigation)
                    .WithMany(p => p.productiondocpos)
                    .HasForeignKey(d => d.idstoredoc)
                    .HasConstraintName("FK_productiondocpos_storedoc");
            });

            modelBuilder.Entity<productiondocsign>(entity =>
            {
                entity.Property(e => e.idproductiondocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.productiondocsign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_productiondocsign_people");

                entity.HasOne(d => d.idproductiondocNavigation)
                    .WithMany(p => p.productiondocsign)
                    .HasForeignKey(d => d.idproductiondoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiondocsign_productiondoc");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.productiondocsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_productiondocsign_sign");
            });

            modelBuilder.Entity<productionsite>(entity =>
            {
                entity.Property(e => e.idproductionsite).ValueGeneratedNever();
            });

            modelBuilder.Entity<productiontype>(entity =>
            {
                entity.Property(e => e.idproductiontype).ValueGeneratedNever();

                entity.Property(e => e.idproductiontypegroup).HasComment("Ссылка на группу типов продукции");

                entity.Property(e => e.isactive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.idcolorgroupcustomNavigation)
                    .WithMany(p => p.productiontype)
                    .HasForeignKey(d => d.idcolorgroupcustom)
                    .HasConstraintName("FK_productiontype_colorgroupcustom");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.productiontype)
                    .HasForeignKey(d => d.idconstructiontype)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_productiontype_constructiontype");

                entity.HasOne(d => d.idmeasureNavigation)
                    .WithMany(p => p.productiontype)
                    .HasForeignKey(d => d.idmeasure)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiontype_measure");

                entity.HasOne(d => d.idpowerNavigation)
                    .WithMany(p => p.productiontype)
                    .HasForeignKey(d => d.idpower)
                    .HasConstraintName("FK_productiontype_power");

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.productiontype)
                    .HasForeignKey(d => d.idpricechange)
                    .HasConstraintName("FK_productiontype_pricechange");

                entity.HasOne(d => d.idproductiontypegroupNavigation)
                    .WithMany(p => p.productiontype)
                    .HasForeignKey(d => d.idproductiontypegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiontype_productiontypegroup");
            });

            modelBuilder.Entity<productiontypeconstruction>(entity =>
            {
                entity.HasComment("Таблица связей продукции с типами конструкций");

                entity.Property(e => e.idproductiontypeconstruction)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.deleted).HasComment("Дата и время удаления");

                entity.Property(e => e.idconstructiontype).HasComment("Ссылка тип конструкции");

                entity.Property(e => e.idproductiontype).HasComment("Ссылка на тип продукции");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.productiontypeconstruction)
                    .HasForeignKey(d => d.idconstructiontype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiontypeconstruction_constructiontype");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.productiontypeconstruction)
                    .HasForeignKey(d => d.idproductiontype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiontypeconstruction_productiontype");
            });

            modelBuilder.Entity<productiontypegrant>(entity =>
            {
                entity.Property(e => e.idproductiontypegrant).ValueGeneratedNever();

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.productiontypegrant)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiontypegrant_peoplegroup");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.productiontypegrant)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_productiontypegrant_productiontype");
            });

            modelBuilder.Entity<productiontypegroup>(entity =>
            {
                entity.HasComment("Группы типов продукции");

                entity.Property(e => e.idproductiontypegroup)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Дата и время удаления");

                entity.Property(e => e.guid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Глобальный идентификатор для репликации");

                entity.Property(e => e.name).HasComment("Наименование");

                entity.Property(e => e.numpos).HasComment("Номер по порядку");

                entity.Property(e => e.parentid).HasComment("Ссылка на родителя");
            });

            modelBuilder.Entity<productiontypeparam>(entity =>
            {
                entity.HasComment("Параметры типов продукции");

                entity.Property(e => e.idproductiontypeparam)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.deleted).HasComment("Дата удаления");

                entity.Property(e => e.guid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Глобальный идентификатор для репликации");

                entity.Property(e => e.idmodelparam).HasComment("Ссылка на параметр");

                entity.Property(e => e.idproductiontype).HasComment("Ссылка на тип продукции");

                entity.HasOne(d => d.idmodelparamNavigation)
                    .WithMany(p => p.productiontypeparam)
                    .HasForeignKey(d => d.idmodelparam)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiontypeparam_modelparam");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.productiontypeparamidmodelparamvalueNavigation)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_productiontypeparam_idmodelparamvalue");

                entity.HasOne(d => d.idmodelparamvalue2Navigation)
                    .WithMany(p => p.productiontypeparamidmodelparamvalue2Navigation)
                    .HasForeignKey(d => d.idmodelparamvalue2)
                    .HasConstraintName("FK_productiontypeparam_idmodelparamvalue2");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.productiontypeparam)
                    .HasForeignKey(d => d.idproductiontype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiontypeparam_productiontype");
            });

            modelBuilder.Entity<productiontypesetting>(entity =>
            {
                entity.HasKey(e => e.idproductiontypesetting)
                    .HasName("productiontypesetting_pkey");

                entity.Property(e => e.idproductiontypesetting).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.productiontypesetting)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_productiontypesetting_productiontype");

                entity.HasOne(d => d.idsettingNavigation)
                    .WithMany(p => p.productiontypesetting)
                    .HasForeignKey(d => d.idsetting)
                    .HasConstraintName("FK_productiontypesetting_setting");
            });

            modelBuilder.Entity<productiontypesystems>(entity =>
            {
                entity.HasComment("Таблица связей продукции с системами профиля, фурнитуры, типами конструкций etc.");

                entity.Property(e => e.idproductiontypesystems)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.deleted).HasComment("Дата и время удаления");

                entity.Property(e => e.idproductiontype).HasComment("Ссылка на тип продукции");

                entity.Property(e => e.idsystem).HasComment("Ссылка на связанное значение в системах");

                entity.HasOne(d => d.idcolorgroupcustomNavigation)
                    .WithMany(p => p.productiontypesystems)
                    .HasForeignKey(d => d.idcolorgroupcustom)
                    .HasConstraintName("FK_productiontypesystems_idcolorgroupcustom");

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.productiontypesystems)
                    .HasForeignKey(d => d.idpricechange)
                    .HasConstraintName("FK_pricechange_productiontypesystems");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.productiontypesystems)
                    .HasForeignKey(d => d.idproductiontype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiontypesystems_productiontype");

                entity.HasOne(d => d.idsystemNavigation)
                    .WithMany(p => p.productiontypesystems)
                    .HasForeignKey(d => d.idsystem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_productiontypesystems_system");
            });

            modelBuilder.Entity<productiontypetemplate>(entity =>
            {
                entity.Property(e => e.idproductiontypetemplate).ValueGeneratedNever();

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.productiontypetemplate)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_productiontypetemplate_productiontype");
            });

            modelBuilder.Entity<pyramid>(entity =>
            {
                entity.Property(e => e.idpyramid).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idcarNavigation)
                    .WithMany(p => p.pyramid)
                    .HasForeignKey(d => d.idcar)
                    .HasConstraintName("FK_pyramid_car");

                entity.HasOne(d => d.idproductionsiteNavigation)
                    .WithMany(p => p.pyramid)
                    .HasForeignKey(d => d.idproductionsite)
                    .HasConstraintName("FK_pyramid_productionsite");
            });

            modelBuilder.Entity<pyramidfact>(entity =>
            {
                entity.Property(e => e.idpyramidfact).ValueGeneratedNever();
            });

            modelBuilder.Entity<pyramidfactpos>(entity =>
            {
                entity.Property(e => e.idpyramidfactpos).ValueGeneratedNever();
            });

            modelBuilder.Entity<reg_inost>(entity =>
            {
                entity.HasIndex(e => new { e.dt, e.idstoredepart, e.idgood, e.idcolor1, e.idcolor2 }, "IX_reg_inost")
                    .IsUnique()
                    .IsClustered();

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_reg_inost_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_reg_inost_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_inost_good");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_inost_storedepart");
            });

            modelBuilder.Entity<reg_inost_log>(entity =>
            {
                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_reg_inost_log_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_reg_inost_log_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_inost_log_good");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_inost_log_storedepart");
            });

            modelBuilder.Entity<reg_mf>(entity =>
            {
                entity.HasIndex(e => new { e.idmanufactdoc, e.idgood, e.idcolor1, e.idcolor2, e.idstoredepart }, "IX_reg_mf")
                    .IsUnique()
                    .IsClustered();

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_reg_mf_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_reg_mf_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_mf_good");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_mf_manufactdoc");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_mf_storedepart");
            });

            modelBuilder.Entity<reg_mf_log>(entity =>
            {
                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_reg_mf_log_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_reg_mf_log_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_mf_log_good");

                entity.HasOne(d => d.idmanufactdocNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idmanufactdoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_mf_log_manufactdoc");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_mf_log_storedepart");
            });

            modelBuilder.Entity<reg_order>(entity =>
            {
                entity.HasOne(d => d.idavailabilitygroupNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idavailabilitygroup)
                    .HasConstraintName("FK_reg_order_availabilitygroup");

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_reg_order_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_reg_order_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_order_good");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_order_orders");

                entity.HasOne(d => d.idproductionsiteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idproductionsite)
                    .HasConstraintName("FK_reg_order_productionsite");
            });

            modelBuilder.Entity<reg_ost>(entity =>
            {
                entity.HasIndex(e => new { e.dt, e.idstoredepart, e.idgood, e.idcolor1, e.idcolor2 }, "IX_reg_ost")
                    .IsUnique()
                    .IsClustered();

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_reg_ost_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_reg_ost_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_ost_good");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_ost_storedepart");
            });

            modelBuilder.Entity<reg_ost_log>(entity =>
            {
                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_reg_ost_log_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_reg_ost_log_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_ost_log_good");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_ost_log_storedepart");
            });

            modelBuilder.Entity<reg_ost_wl>(entity =>
            {
                entity.HasIndex(e => new { e.dt, e.idstoredepart, e.idgood, e.idcolor1, e.idcolor2 }, "IX_reg_ost_wl")
                    .IsUnique()
                    .IsClustered();

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_reg_ost_wl_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_reg_ost_wl_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_ost_wl_good");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_ost_wl_storedepart");
            });

            modelBuilder.Entity<reg_ost_wl_log>(entity =>
            {
                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_reg_ost_wl_log_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_reg_ost_wl_log_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_ost_wl_log_good");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_ost_wl_log_storedepart");
            });

            modelBuilder.Entity<report>(entity =>
            {
                entity.HasKey(e => e.idreport)
                    .HasName("pk_report");

                entity.Property(e => e.idreport).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.indealerbase).HasComment("Переносить в дилерскую версию");

                entity.HasOne(d => d.idreportgroupNavigation)
                    .WithMany(p => p.report)
                    .HasForeignKey(d => d.idreportgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_report_reportgroup");

                entity.HasOne(d => d.idreportscriptNavigation)
                    .WithMany(p => p.report)
                    .HasForeignKey(d => d.idreportscript)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_report_reportscript");
            });

            modelBuilder.Entity<reportdocoper>(entity =>
            {
                entity.Property(e => e.idreportdocoper).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.reportdocoper)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_reportdocoper_docoper");

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.reportdocoper)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_reportdocoper_peoplegroup");

                entity.HasOne(d => d.idreportNavigation)
                    .WithMany(p => p.reportdocoper)
                    .HasForeignKey(d => d.idreport)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_reportdocoper_report");
            });

            modelBuilder.Entity<reportgroup>(entity =>
            {
                entity.Property(e => e.idreportgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<reportkit>(entity =>
            {
                entity.Property(e => e.idreportkit).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<reportkitdetail>(entity =>
            {
                entity.Property(e => e.idreportkitdetail).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idreportNavigation)
                    .WithMany(p => p.reportkitdetail)
                    .HasForeignKey(d => d.idreport)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_reportkitdetail_report");

                entity.HasOne(d => d.idreportkitNavigation)
                    .WithMany(p => p.reportkitdetail)
                    .HasForeignKey(d => d.idreportkit)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_reportkitdetail_reportkitdetail");
            });

            modelBuilder.Entity<reportsave>(entity =>
            {
                entity.HasKey(e => e.idreportsave)
                    .HasName("pk_reportsave");

                entity.Property(e => e.idreportsave).ValueGeneratedNever();

                entity.HasOne(d => d.idreportNavigation)
                    .WithMany(p => p.reportsave)
                    .HasForeignKey(d => d.idreport)
                    .HasConstraintName("fk_reportsave_1");
            });

            modelBuilder.Entity<reportscript>(entity =>
            {
                entity.Property(e => e.idreportscript).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<respower>(entity =>
            {
                entity.Property(e => e.idrespower).ValueGeneratedNever();

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.respower)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_respower_orders");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.respower)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_respower_orderitem");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.respoweridpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_respower_people");

                entity.HasOne(d => d.idpeople2Navigation)
                    .WithMany(p => p.respoweridpeople2Navigation)
                    .HasForeignKey(d => d.idpeople2)
                    .HasConstraintName("FK_respower_people1");

                entity.HasOne(d => d.idpowerNavigation)
                    .WithMany(p => p.respower)
                    .HasForeignKey(d => d.idpower)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_respower_power");

                entity.HasOne(d => d.idservicedocNavigation)
                    .WithMany(p => p.respower)
                    .HasForeignKey(d => d.idservicedoc)
                    .HasConstraintName("FK_respower_servicedoc");
            });

            modelBuilder.Entity<revisiongp>(entity =>
            {
                entity.Property(e => e.idrevisiongp).ValueGeneratedNever();

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.revisiongp)
                    .HasForeignKey(d => d.iddocoper)
                    .HasConstraintName("FK_revisiongp_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.revisiongp)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_revisiongp_docstate");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.revisiongp)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_revisiongp_people");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.revisiongp)
                    .HasForeignKey(d => d.idstoredepart)
                    .HasConstraintName("FK_revisiongp_storedepart");
            });

            modelBuilder.Entity<revisiongpitem>(entity =>
            {
                entity.HasKey(e => e.idrevisiongpitem)
                    .HasName("PK_revisionitem");

                entity.Property(e => e.idrevisiongpitem).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.revisiongpitem)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_revisiongpitem_people");

                entity.HasOne(d => d.idrevisiongpNavigation)
                    .WithMany(p => p.revisiongpitem)
                    .HasForeignKey(d => d.idrevisiongp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_revisiongpitem_revisiongp");

                entity.HasOne(d => d.idrotoxhouseNavigation)
                    .WithMany(p => p.revisiongpitem)
                    .HasForeignKey(d => d.idrotoxhouse)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_revisiongpitem_rotoxhouse");
            });

            modelBuilder.Entity<rotoxflugel>(entity =>
            {
                entity.Property(e => e.idrotoxflugel).ValueGeneratedNever();
            });

            modelBuilder.Entity<rotoxhouse>(entity =>
            {
                entity.HasComment("Склад готовой продукции");

                entity.Property(e => e.idrotoxhouse)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.cell).HasComment("Ячейка склада");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.dtin).HasComment("Дата прихода");

                entity.Property(e => e.dtout).HasComment("Дата расхода");

                entity.Property(e => e.idorderitem).HasComment("Позиция заказа");

                entity.Property(e => e.idpeople1).HasComment("Мастер производство");

                entity.Property(e => e.idpeople2).HasComment("Мастер ОТК");

                entity.Property(e => e.idpeople3).HasComment("Принял на склад");

                entity.Property(e => e.idpeople4).HasComment("Отгрузил со склада");

                entity.Property(e => e.idpeople5).HasComment("Прочее (на усмотрение компаний)");

                entity.Property(e => e.row).HasComment("Строка склада");

                entity.Property(e => e.state).HasComment("Состояние ячейки");

                entity.HasOne(d => d.idmanufactdocposNavigation)
                    .WithMany(p => p.rotoxhouse)
                    .HasForeignKey(d => d.idmanufactdocpos)
                    .HasConstraintName("FK_rotoxhouse_manufactdocpos");

                entity.HasOne(d => d.idmanufactdocpyram)
                    .WithMany(p => p.rotoxhouse)
                    .HasForeignKey(d => d.idmanufactdocpyramid)
                    .HasConstraintName("FK_rotoxhouse_manufactdocpyramid");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.rotoxhouse)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_rotoxhouse_orderitem");

                entity.HasOne(d => d.idstoragespaceNavigation)
                    .WithMany(p => p.rotoxhouseidstoragespaceNavigation)
                    .HasForeignKey(d => d.idstoragespace)
                    .HasConstraintName("FK_rotoxhouse_storagespace");

                entity.HasOne(d => d.idstoragespace2Navigation)
                    .WithMany(p => p.rotoxhouseidstoragespace2Navigation)
                    .HasForeignKey(d => d.idstoragespace2)
                    .HasConstraintName("FK_rotoxhouse_storagespace2");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.rotoxhouse)
                    .HasForeignKey(d => d.idstoredepart)
                    .HasConstraintName("FK_rotoxhouse_storedepart");

                entity.HasOne(d => d.idstoredocNavigation)
                    .WithMany(p => p.rotoxhouse)
                    .HasForeignKey(d => d.idstoredoc)
                    .HasConstraintName("FK_rotoxhouse_storedoc");
            });

            modelBuilder.Entity<route>(entity =>
            {
                entity.Property(e => e.idroute).ValueGeneratedNever();

                entity.HasOne(d => d.idproductionsiteNavigation)
                    .WithMany(p => p.route)
                    .HasForeignKey(d => d.idproductionsite)
                    .HasConstraintName("FK_route_idproductionsite");
            });

            modelBuilder.Entity<seller>(entity =>
            {
                entity.Property(e => e.idseller).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idaddclassification1Navigation)
                    .WithMany(p => p.selleridaddclassification1Navigation)
                    .HasForeignKey(d => d.idaddclassification1)
                    .HasConstraintName("FK_seller_addclassification1");

                entity.HasOne(d => d.idaddclassification2Navigation)
                    .WithMany(p => p.selleridaddclassification2Navigation)
                    .HasForeignKey(d => d.idaddclassification2)
                    .HasConstraintName("FK_seller_addclassification2");

                entity.HasOne(d => d.idaddclassification3Navigation)
                    .WithMany(p => p.selleridaddclassification3Navigation)
                    .HasForeignKey(d => d.idaddclassification3)
                    .HasConstraintName("FK_seller_addclassification3");

                entity.HasOne(d => d.idaddclassification4Navigation)
                    .WithMany(p => p.selleridaddclassification4Navigation)
                    .HasForeignKey(d => d.idaddclassification4)
                    .HasConstraintName("FK_seller_addclassification4");

                entity.HasOne(d => d.idaddclassification5Navigation)
                    .WithMany(p => p.selleridaddclassification5Navigation)
                    .HasForeignKey(d => d.idaddclassification5)
                    .HasConstraintName("FK_seller_addclassification5");

                entity.HasOne(d => d.idsellergroupNavigation)
                    .WithMany(p => p.seller)
                    .HasForeignKey(d => d.idsellergroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_seller_sellergroup");
            });

            modelBuilder.Entity<sellerdestanation>(entity =>
            {
                entity.Property(e => e.idsellerdestanation).ValueGeneratedNever();

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.sellerdestanation)
                    .HasForeignKey(d => d.iddestanation)
                    .HasConstraintName("FK_sellerdestanation_destanation");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.sellerdestanation)
                    .HasForeignKey(d => d.idseller)
                    .HasConstraintName("FK_sellerdestanation_seller");
            });

            modelBuilder.Entity<sellergrant>(entity =>
            {
                entity.Property(e => e.idsellergrant).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<sellergroup>(entity =>
            {
                entity.Property(e => e.idsellergroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<sellerpricechange>(entity =>
            {
                entity.Property(e => e.idsellerpricechange).ValueGeneratedNever();

                entity.HasOne(d => d.idpricechangeNavigation)
                    .WithMany(p => p.sellerpricechange)
                    .HasForeignKey(d => d.idpricechange)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sellerpricechange_pricechange");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.sellerpricechange)
                    .HasForeignKey(d => d.idseller)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sellerpricechange_sellerpricechange");
            });

            modelBuilder.Entity<servicedepartment>(entity =>
            {
                entity.Property(e => e.idservicedepartment).ValueGeneratedNever();

                entity.HasOne(d => d.iddepartmentNavigation)
                    .WithMany(p => p.servicedepartment)
                    .HasForeignKey(d => d.iddepartment)
                    .HasConstraintName("FK_servicedepartment_department");

                entity.HasOne(d => d.idservicedocNavigation)
                    .WithMany(p => p.servicedepartment)
                    .HasForeignKey(d => d.idservicedoc)
                    .HasConstraintName("FK_servicedepartment_servicedoc");
            });

            modelBuilder.Entity<servicedepartmentpeople>(entity =>
            {
                entity.Property(e => e.idservicedepartmentpeople).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.servicedepartmentpeople)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_servicedepartmentpeople_people");

                entity.HasOne(d => d.idservicedepartmentNavigation)
                    .WithMany(p => p.servicedepartmentpeople)
                    .HasForeignKey(d => d.idservicedepartment)
                    .HasConstraintName("FK_servicedepartmentpeople_servicedepartment");

                entity.HasOne(d => d.idservicedocNavigation)
                    .WithMany(p => p.servicedepartmentpeople)
                    .HasForeignKey(d => d.idservicedoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_servicedepartmentpeople_servicedoc");
            });

            modelBuilder.Entity<servicedoc>(entity =>
            {
                entity.Property(e => e.idservicedoc).ValueGeneratedNever();

                entity.Property(e => e.idaddress).HasComment("Ссылка на адрес в справочнике адресов");

                entity.Property(e => e.iddepartment).HasComment("Ссылка на виновное подразделение");

                entity.Property(e => e.idorderdest).HasComment("Ссылка на заказ-результат");

                entity.Property(e => e.parentid).HasComment("Документ-родитель");

                entity.HasOne(d => d.idaddressNavigation)
                    .WithMany(p => p.servicedoc)
                    .HasForeignKey(d => d.idaddress)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_servicedoc_address");

                entity.HasOne(d => d.iddepartmentNavigation)
                    .WithMany(p => p.servicedoc)
                    .HasForeignKey(d => d.iddepartment)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_servicedoc_department");

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.servicedoc)
                    .HasForeignKey(d => d.iddestanation)
                    .HasConstraintName("FK_servicedoc_destanation");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.servicedoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_servicedoc_docstate");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.servicedocidorderNavigation)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_servicedoc_orders");

                entity.HasOne(d => d.idorderdestNavigation)
                    .WithMany(p => p.servicedocidorderdestNavigation)
                    .HasForeignKey(d => d.idorderdest)
                    .HasConstraintName("FK_servicedoc_ordersdest");

                entity.HasOne(d => d.idservicedocgroupNavigation)
                    .WithMany(p => p.servicedoc)
                    .HasForeignKey(d => d.idservicedocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_servicedoc_servicedocgroup");
            });

            modelBuilder.Entity<servicedocdiraction>(entity =>
            {
                entity.HasComment("Этапы документа \"Сервис и гарантия\"");

                entity.Property(e => e.idservicedocdiraction)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий к этапу");

                entity.Property(e => e.deleted).HasComment("Дата удаления этапа");

                entity.Property(e => e.dtcreate).HasComment("Дата создания этапа");

                entity.Property(e => e.dtedit).HasComment("Дата редактирования этапа");

                entity.Property(e => e.factdate).HasComment("Фактическая дата выполнения этапа");

                entity.Property(e => e.iddiraction).HasComment("Ссылка на этап");

                entity.Property(e => e.idpeople).HasComment("Сотрудник создавший этап");

                entity.Property(e => e.idpeopleedit).HasComment("Сотрудник редактировавший этап");

                entity.Property(e => e.idpeopleexec).HasComment("Исполнитель этапа");

                entity.Property(e => e.idservicedoc).HasComment("Ссылка на документ сервиса");

                entity.Property(e => e.plandate).HasComment("Плановая дата выполнения этапа");

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.servicedocdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_servicedocdiraction_diraction");

                entity.HasOne(d => d.idpeopleexecNavigation)
                    .WithMany(p => p.servicedocdiraction)
                    .HasForeignKey(d => d.idpeopleexec)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_servicedocdiraction_people");

                entity.HasOne(d => d.idservicedocNavigation)
                    .WithMany(p => p.servicedocdiraction)
                    .HasForeignKey(d => d.idservicedoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_servicedocdiraction_servicedoc");
            });

            modelBuilder.Entity<servicedocgroup>(entity =>
            {
                entity.Property(e => e.idservicedocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<servicedocpos>(entity =>
            {
                entity.Property(e => e.idservicedocpos).ValueGeneratedNever();

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.servicedocpos)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_servicedocpos_orderitem");

                entity.HasOne(d => d.idservicedocNavigation)
                    .WithMany(p => p.servicedocpos)
                    .HasForeignKey(d => d.idservicedoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_servicedocpos_servicedoc");

                entity.HasOne(d => d.idservicereasonNavigation)
                    .WithMany(p => p.servicedocpos)
                    .HasForeignKey(d => d.idservicereason)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_servicedocpos_servicereason");
            });

            modelBuilder.Entity<servicedocsign>(entity =>
            {
                entity.Property(e => e.idservicedocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.servicedocsign)
                    .HasForeignKey(d => d.idorderitem)
                    .HasConstraintName("FK_servicedocsign_servicedocpos");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.servicedocsign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_servicedocsign_people");

                entity.HasOne(d => d.idservicedocNavigation)
                    .WithMany(p => p.servicedocsign)
                    .HasForeignKey(d => d.idservicedoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_servicedocsign_servicedoc");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.servicedocsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_servicedocsign_sign");
            });

            modelBuilder.Entity<servicereason>(entity =>
            {
                entity.Property(e => e.idservicereason).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.servicereason)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_servicereason_people");
            });

            modelBuilder.Entity<setting>(entity =>
            {
                entity.HasKey(e => e.idsetting)
                    .HasName("setting_pkey");

                entity.Property(e => e.idsetting).ValueGeneratedNever();

                entity.Property(e => e.addmodel).HasDefaultValueSql("((0))");

                entity.Property(e => e.addorder).HasDefaultValueSql("((0))");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idsettinggroupNavigation)
                    .WithMany(p => p.setting)
                    .HasForeignKey(d => d.idsettinggroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_setting_settinggroup");
            });

            modelBuilder.Entity<settinggroup>(entity =>
            {
                entity.Property(e => e.idsettinggroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<shtapikgroup>(entity =>
            {
                entity.Property(e => e.idshtapikgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<shtapikgroupdetail>(entity =>
            {
                entity.Property(e => e.idshtapikgroupdetail).ValueGeneratedNever();

                entity.HasOne(d => d.iderrorNavigation)
                    .WithMany(p => p.shtapikgroupdetail)
                    .HasForeignKey(d => d.iderror)
                    .HasConstraintName("FK_shtapikgroupdetail_iderror");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.shtapikgroupdetail)
                    .HasForeignKey(d => d.idgood)
                    .HasConstraintName("FK_shtapikgroupdetail_good");

                entity.HasOne(d => d.idshtapikgroupNavigation)
                    .WithMany(p => p.shtapikgroupdetail)
                    .HasForeignKey(d => d.idshtapikgroup)
                    .HasConstraintName("FK_shtapikgroupdetail_shtapikgroup");

                entity.HasOne(d => d.idworkoperNavigation)
                    .WithMany(p => p.shtapikgroupdetail)
                    .HasForeignKey(d => d.idworkoper)
                    .HasConstraintName("FK_shtapikgroupdetail_idworkoper");
            });

            modelBuilder.Entity<shtapikgroupparamdetail>(entity =>
            {
                entity.Property(e => e.idshtapikgroupparamdetail).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorNavigation)
                    .WithMany(p => p.shtapikgroupparamdetail)
                    .HasForeignKey(d => d.idcolor)
                    .HasConstraintName("FK_shtapikgroupparamdetail_color");

                entity.HasOne(d => d.idcoloraccordanceNavigation)
                    .WithMany(p => p.shtapikgroupparamdetail)
                    .HasForeignKey(d => d.idcoloraccordance)
                    .HasConstraintName("FK_shtapikgroupparamdetail_coloraccordance");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.shtapikgroupparamdetail)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_shtapikgroupparamdetail_constructiontype");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.shtapikgroupparamdetail)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_shtapikgroupparamdetail_modelparamvalue");

                entity.HasOne(d => d.idshtapikgroupdetailNavigation)
                    .WithMany(p => p.shtapikgroupparamdetail)
                    .HasForeignKey(d => d.idshtapikgroupdetail)
                    .HasConstraintName("FK_shtapikgroupparamdetail_shtapikgroupdetail");

                entity.HasOne(d => d.idvariantparamtypeNavigation)
                    .WithMany(p => p.shtapikgroupparamdetail)
                    .HasForeignKey(d => d.idvariantparamtype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_variantparam_shtapikgroupparamtypedetail");

                entity.HasOne(d => d.idvariantparamtypevalueNavigation)
                    .WithMany(p => p.shtapikgroupparamdetail)
                    .HasForeignKey(d => d.idvariantparamtypevalue)
                    .HasConstraintName("FK_shtapikgroupparamdetail_variantparamtypevalue");
            });

            modelBuilder.Entity<shtapikgroupprofile>(entity =>
            {
                entity.Property(e => e.idshtapikgroupprofile).ValueGeneratedNever();

                entity.HasOne(d => d.idinsertionNavigation)
                    .WithMany(p => p.shtapikgroupprofile)
                    .HasForeignKey(d => d.idinsertion)
                    .HasConstraintName("FK_shtapikgroupprofile_insertion");

                entity.HasOne(d => d.idshtapikgroupNavigation)
                    .WithMany(p => p.shtapikgroupprofile)
                    .HasForeignKey(d => d.idshtapikgroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shtapikgroupprofile_shtapikgroup");

                entity.HasOne(d => d.idsystemdetailNavigation)
                    .WithMany(p => p.shtapikgroupprofile)
                    .HasForeignKey(d => d.idsystemdetail)
                    .HasConstraintName("FK_shtapikgroupprofile_systemdetail");
            });

            modelBuilder.Entity<sign>(entity =>
            {
                entity.HasKey(e => e.idsign)
                    .HasName("pk_sing");

                entity.Property(e => e.idsign).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idsigngroupNavigation)
                    .WithMany(p => p.sign)
                    .HasForeignKey(d => d.idsigngroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sign_signgroup");
            });

            modelBuilder.Entity<signgrant>(entity =>
            {
                entity.Property(e => e.idsigngrant).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.isedit).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.signgrant)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_signgrant_docoper");

                entity.HasOne(d => d.idpeoplegroupNavigation)
                    .WithMany(p => p.signgrant)
                    .HasForeignKey(d => d.idpeoplegroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_signgrant_peoplegroup");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.signgrant)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_signgrant_sign");

                entity.HasOne(d => d.idsignvalueNavigation)
                    .WithMany(p => p.signgrant)
                    .HasForeignKey(d => d.idsignvalue)
                    .HasConstraintName("FK_signgrant_signvalue");
            });

            modelBuilder.Entity<signgroup>(entity =>
            {
                entity.Property(e => e.idsigngroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<signvalue>(entity =>
            {
                entity.HasKey(e => e.idsignvalue)
                    .HasName("pk_signvalue");

                entity.Property(e => e.idsignvalue).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.signvalue)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("signvalue_fk");
            });

            modelBuilder.Entity<sizedoc>(entity =>
            {
                entity.Property(e => e.idsizedoc).ValueGeneratedNever();

                entity.Property(e => e.address).HasComment("Текстовый адрес");

                entity.Property(e => e.contact).HasComment("Контактное лицо(например хомяк)");

                entity.Property(e => e.dtcre).HasComment("Дата создания");

                entity.Property(e => e.dtedit).HasComment("Дата изменения");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idaddress).HasComment("Ссылка на адрес");

                entity.Property(e => e.idpeoplecreate).HasComment("Демиург");

                entity.Property(e => e.idpeopleedit).HasComment("Искуситель");

                entity.Property(e => e.phone).HasComment("Телефон");

                entity.Property(e => e.speackerphone).HasComment("Домофон");

                entity.HasOne(d => d.idaddressNavigation)
                    .WithMany(p => p.sizedoc)
                    .HasForeignKey(d => d.idaddress)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_sizedoc_address");

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.sizedoc)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sizedoc_customer");

                entity.HasOne(d => d.iddestanationNavigation)
                    .WithMany(p => p.sizedoc)
                    .HasForeignKey(d => d.iddestanation)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_sizedoc_destanation");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.sizedoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_sizedoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.sizedoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_sizedoc_docstate");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.sizedoc)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_sizedoc_orders");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.sizedoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sizedoc_people");

                entity.HasOne(d => d.idsizedocgroupNavigation)
                    .WithMany(p => p.sizedoc)
                    .HasForeignKey(d => d.idsizedocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sizedoc_sizedocgroup");
            });

            modelBuilder.Entity<sizedocconstrtype>(entity =>
            {
                entity.HasKey(e => e.idsizedocconstrtype)
                    .HasName("PK_sizedocconstruction");

                entity.Property(e => e.idsizedocconstrtype).ValueGeneratedNever();

                entity.Property(e => e.numpos).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.sizedocconstrtype)
                    .HasForeignKey(d => d.idconstructiontype)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_sizedocconstruction_constructiontype");

                entity.HasOne(d => d.idembrasuretypeNavigation)
                    .WithMany(p => p.sizedocconstrtype)
                    .HasForeignKey(d => d.idembrasuretype)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_sizedocconstrtype_embrasuretype");

                entity.HasOne(d => d.idproductiontypeNavigation)
                    .WithMany(p => p.sizedocconstrtype)
                    .HasForeignKey(d => d.idproductiontype)
                    .HasConstraintName("FK_sizedocconstrtype_productiontype");

                entity.HasOne(d => d.idsizedocNavigation)
                    .WithMany(p => p.sizedocconstrtype)
                    .HasForeignKey(d => d.idsizedoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sizedocconstruction_sizedoc");
            });

            modelBuilder.Entity<sizedocdiraction>(entity =>
            {
                entity.Property(e => e.idsizedocdiraction).ValueGeneratedNever();

                entity.Property(e => e.dtcreate).HasComment("Дата создания этапа");

                entity.Property(e => e.dtedit).HasComment("Дата редактирования этапа");

                entity.Property(e => e.idpeople).HasComment("Пользователь, создавший этап");

                entity.Property(e => e.idpeopleedit).HasComment("Пользователь, редактировавший этап");

                entity.Property(e => e.idpeopleexec).HasComment("Исполнитель этапа");

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.sizedocdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sizedocdiraction_diraction");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.sizedocdiractionidpeopleNavigation)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_sizedocdiraction_people");

                entity.HasOne(d => d.idpeopleeditNavigation)
                    .WithMany(p => p.sizedocdiractionidpeopleeditNavigation)
                    .HasForeignKey(d => d.idpeopleedit)
                    .HasConstraintName("FK_sizedocdiraction_people1");

                entity.HasOne(d => d.idpeopleexecNavigation)
                    .WithMany(p => p.sizedocdiractionidpeopleexecNavigation)
                    .HasForeignKey(d => d.idpeopleexec)
                    .HasConstraintName("FK_sizedocdiraction_people2");

                entity.HasOne(d => d.idsizedocNavigation)
                    .WithMany(p => p.sizedocdiraction)
                    .HasForeignKey(d => d.idsizedoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sizedocdiraction_sizedoc");
            });

            modelBuilder.Entity<sizedocdiractionpeople>(entity =>
            {
                entity.Property(e => e.idsizedocdiractionpeople).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.sizedocdiractionpeople)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_sizedocdiractionpeople_people");

                entity.HasOne(d => d.idsizedocdiractionNavigation)
                    .WithMany(p => p.sizedocdiractionpeople)
                    .HasForeignKey(d => d.idsizedocdiraction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sizedocdiractionpeople_sizedocdiraction");
            });

            modelBuilder.Entity<sizedocfile>(entity =>
            {
                entity.Property(e => e.idsizedocfile).ValueGeneratedNever();

                entity.HasOne(d => d.idsizedocNavigation)
                    .WithMany(p => p.sizedocfile)
                    .HasForeignKey(d => d.idsizedoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sizedocfile_sizedocfile");
            });

            modelBuilder.Entity<sizedocgroup>(entity =>
            {
                entity.Property(e => e.idsizedocgroup).ValueGeneratedNever();

                entity.Property(e => e.comment).HasComment("Комментарий");
            });

            modelBuilder.Entity<sizedocsign>(entity =>
            {
                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_sizedocsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idsign)
                    .HasConstraintName("FK_sizedocsign_sign");

                entity.HasOne(d => d.idsignvalueNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idsignvalue)
                    .HasConstraintName("FK_sizedocsign_signvalue");

                entity.HasOne(d => d.idsizedocNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.idsizedoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sizedocsign_sizedoc");
            });

            modelBuilder.Entity<sourceinfo>(entity =>
            {
                entity.HasComment("Справочник иточников информации");

                entity.Property(e => e.idsourceinfo)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Признак удалённости");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.idsourceinfogroup).HasComment("Ссылка на группу");

                entity.Property(e => e.name).HasComment("Наименование");

                entity.HasOne(d => d.idsourceinfogroupNavigation)
                    .WithMany(p => p.sourceinfo)
                    .HasForeignKey(d => d.idsourceinfogroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_sourceinfo_sourceinfogroup");
            });

            modelBuilder.Entity<sourceinfogroup>(entity =>
            {
                entity.HasComment("Группы источников информации");

                entity.Property(e => e.idsourceinfogroup)
                    .ValueGeneratedNever()
                    .HasComment("Первичный ключ");

                entity.Property(e => e.comment).HasComment("Комментарий");

                entity.Property(e => e.deleted).HasComment("Признак удалённости");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.isactive).HasComment("Активность группы");

                entity.Property(e => e.name).HasComment("Наименование");

                entity.Property(e => e.parentid).HasComment("Ссылка на родителя");
            });

            modelBuilder.Entity<storagespace>(entity =>
            {
                entity.Property(e => e.idstoragespace).ValueGeneratedNever();

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.storagespace)
                    .HasForeignKey(d => d.idstoredepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_storagespace_storedepart");
            });

            modelBuilder.Entity<storedepart>(entity =>
            {
                entity.HasKey(e => e.idstoredepart)
                    .HasName("storedepart_pkey");

                entity.Property(e => e.idstoredepart).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idavailabilitygroupNavigation)
                    .WithMany(p => p.storedepart)
                    .HasForeignKey(d => d.idavailabilitygroup)
                    .HasConstraintName("FK_storedepart_availabilitygroup");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.storedepart)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_storedepart_people");

                entity.HasOne(d => d.idproductionsiteNavigation)
                    .WithMany(p => p.storedepart)
                    .HasForeignKey(d => d.idproductionsite)
                    .HasConstraintName("FK_storedepart_productionsite");
            });

            modelBuilder.Entity<storedepartdocoper>(entity =>
            {
                entity.Property(e => e.idstoredepartdocoper).ValueGeneratedNever();

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.storedepartdocoper)
                    .HasForeignKey(d => d.iddocoper)
                    .HasConstraintName("FK_storedepartdocoper_docoper");

                entity.HasOne(d => d.idstoredepartNavigation)
                    .WithMany(p => p.storedepartdocoper)
                    .HasForeignKey(d => d.idstoredepart)
                    .HasConstraintName("FK_storedepartdocoper_storedepart");
            });

            modelBuilder.Entity<storedepartrel>(entity =>
            {
                entity.Property(e => e.idstoredepartrel).ValueGeneratedNever();

                entity.HasOne(d => d.idstoredepartchildNavigation)
                    .WithMany(p => p.storedepartrelidstoredepartchildNavigation)
                    .HasForeignKey(d => d.idstoredepartchild)
                    .HasConstraintName("FK_storedepartrelchild_storedepart");

                entity.HasOne(d => d.idstoredepartparentNavigation)
                    .WithMany(p => p.storedepartrelidstoredepartparentNavigation)
                    .HasForeignKey(d => d.idstoredepartparent)
                    .HasConstraintName("FK_storedepartrelparent_storedepart");
            });

            modelBuilder.Entity<storedoc>(entity =>
            {
                entity.HasKey(e => e.idstoredoc)
                    .HasName("storedoc_pkey");

                entity.Property(e => e.idstoredoc).ValueGeneratedNever();

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.storedoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_storedoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.storedoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_storedoc_docstate");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.storedoc)
                    .HasForeignKey(d => d.idorder)
                    .HasConstraintName("FK_storedoc_orders");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.storedoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_storedoc_people");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.storedoc)
                    .HasForeignKey(d => d.idseller)
                    .HasConstraintName("FK_storedoc_seller");

                entity.HasOne(d => d.idstoredepart1Navigation)
                    .WithMany(p => p.storedocidstoredepart1Navigation)
                    .HasForeignKey(d => d.idstoredepart1)
                    .HasConstraintName("storedoc_fk3");

                entity.HasOne(d => d.idstoredepart2Navigation)
                    .WithMany(p => p.storedocidstoredepart2Navigation)
                    .HasForeignKey(d => d.idstoredepart2)
                    .HasConstraintName("storedoc_fk4");

                entity.HasOne(d => d.idstoredocgroupNavigation)
                    .WithMany(p => p.storedoc)
                    .HasForeignKey(d => d.idstoredocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("storedoc_fk2");
            });

            modelBuilder.Entity<storedocgroup>(entity =>
            {
                entity.HasKey(e => e.idstoredocgroup)
                    .HasName("storedocgroup_pkey");

                entity.Property(e => e.idstoredocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<storedocpos>(entity =>
            {
                entity.HasKey(e => e.idstoredocpos)
                    .HasName("storedocpos_pkey");

                entity.Property(e => e.idstoredocpos).ValueGeneratedNever();

                entity.HasOne(d => d.idcolor1Navigation)
                    .WithMany(p => p.storedocposidcolor1Navigation)
                    .HasForeignKey(d => d.idcolor1)
                    .HasConstraintName("FK_storedocpos_color1");

                entity.HasOne(d => d.idcolor2Navigation)
                    .WithMany(p => p.storedocposidcolor2Navigation)
                    .HasForeignKey(d => d.idcolor2)
                    .HasConstraintName("FK_storedocpos_color2");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.storedocposidgoodNavigation)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_storedocpos_good");

                entity.HasOne(d => d.idgood2Navigation)
                    .WithMany(p => p.storedocposidgood2Navigation)
                    .HasForeignKey(d => d.idgood2)
                    .HasConstraintName("FK_storedocpos_good2");

                entity.HasOne(d => d.idgoodmeasureNavigation)
                    .WithMany(p => p.storedocpos)
                    .HasForeignKey(d => d.idgoodmeasure)
                    .HasConstraintName("FK_storedocpos_goodmeasure");

                entity.HasOne(d => d.idmanufactdocposNavigation)
                    .WithMany(p => p.storedocpos)
                    .HasForeignKey(d => d.idmanufactdocpos)
                    .HasConstraintName("FK_storedocpos_manufactdocpos");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.storedocpos)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_storedocpos_orderitem");

                entity.HasOne(d => d.idproductiondocposNavigation)
                    .WithMany(p => p.storedocpos)
                    .HasForeignKey(d => d.idproductiondocpos)
                    .HasConstraintName("FK_storedocpos_productiondocpos");

                entity.HasOne(d => d.idstoragespaceNavigation)
                    .WithMany(p => p.storedocpos)
                    .HasForeignKey(d => d.idstoragespace)
                    .HasConstraintName("FK_storedocpos_storagespace");

                entity.HasOne(d => d.idstoredocNavigation)
                    .WithMany(p => p.storedocpos)
                    .HasForeignKey(d => d.idstoredoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("storedocpos_fk");

                entity.HasOne(d => d.idsupplydocposNavigation)
                    .WithMany(p => p.storedocpos)
                    .HasForeignKey(d => d.idsupplydocpos)
                    .HasConstraintName("FK_storedocpos_supplydocpos");

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentid)
                    .HasConstraintName("FK_storedocpos_parentid");
            });

            modelBuilder.Entity<storedocsign>(entity =>
            {
                entity.Property(e => e.idstoredocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.storedocsign)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_storedocsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.storedocsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_storedocsign_sign");

                entity.HasOne(d => d.idstoredocNavigation)
                    .WithMany(p => p.storedocsign)
                    .HasForeignKey(d => d.idstoredoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_storedocsign_storedoc");

                entity.HasOne(d => d.idstoredocposNavigation)
                    .WithMany(p => p.storedocsign)
                    .HasForeignKey(d => d.idstoredocpos)
                    .HasConstraintName("FK_storedocsign_storedocpos");
            });

            modelBuilder.Entity<supplydoc>(entity =>
            {
                entity.Property(e => e.idsupplydoc).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.supplydocidcustomerNavigation)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_supplydoc_customer");

                entity.HasOne(d => d.idcustomer2Navigation)
                    .WithMany(p => p.supplydocidcustomer2Navigation)
                    .HasForeignKey(d => d.idcustomer2)
                    .HasConstraintName("FK_supplydoc_idcustomer2");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.supplydoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_supplydoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.supplydoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_supplydoc_docstate");

                entity.HasOne(d => d.idorderNavigation)
                    .WithMany(p => p.supplydoc)
                    .HasForeignKey(d => d.idorder)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_orders_supplydoc");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.supplydoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_supplydoc_people");

                entity.HasOne(d => d.idsellerNavigation)
                    .WithMany(p => p.supplydoc)
                    .HasForeignKey(d => d.idseller)
                    .HasConstraintName("FK_supplydoc_seller");

                entity.HasOne(d => d.idsupplydocgroupNavigation)
                    .WithMany(p => p.supplydoc)
                    .HasForeignKey(d => d.idsupplydocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_supplydoc_supplydocgroup");

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.supplydoc)
                    .HasForeignKey(d => d.idvalut)
                    .HasConstraintName("FK_supplydoc_valut");
            });

            modelBuilder.Entity<supplydocdiraction>(entity =>
            {
                entity.Property(e => e.idsupplydocdiraction).ValueGeneratedNever();

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.supplydocdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .HasConstraintName("FK_supplydocdiraction_diraction");

                entity.HasOne(d => d.idpeopleсreateNavigation)
                    .WithMany(p => p.supplydocdiraction)
                    .HasForeignKey(d => d.idpeopleсreate)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_supplydocdiraction_people");
            });

            modelBuilder.Entity<supplydocgoodservice>(entity =>
            {
                entity.Property(e => e.idsupplydocgoodservice).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodserviceNavigation)
                    .WithMany(p => p.supplydocgoodservice)
                    .HasForeignKey(d => d.idgoodservice)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_supplydocgoodservice_goodservice");

                entity.HasOne(d => d.idsupplydocNavigation)
                    .WithMany(p => p.supplydocgoodservice)
                    .HasForeignKey(d => d.idsupplydoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_supplydocgoodservice_supplydoc");
            });

            modelBuilder.Entity<supplydocgroup>(entity =>
            {
                entity.Property(e => e.idsupplydocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<supplydocpos>(entity =>
            {
                entity.Property(e => e.idsupplydocpos).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.supplydocposidgoodNavigation)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_supplydocpos_good");

                entity.HasOne(d => d.idgood2Navigation)
                    .WithMany(p => p.supplydocposidgood2Navigation)
                    .HasForeignKey(d => d.idgood2)
                    .HasConstraintName("FK_supplydocpos_good2");

                entity.HasOne(d => d.idgoodmeasureNavigation)
                    .WithMany(p => p.supplydocpos)
                    .HasForeignKey(d => d.idgoodmeasure)
                    .HasConstraintName("FK_supplydocpos_goodmeasure");

                entity.HasOne(d => d.idmanufactdocposNavigation)
                    .WithMany(p => p.supplydocpos)
                    .HasForeignKey(d => d.idmanufactdocpos)
                    .HasConstraintName("FK_supplydocpos_manufactdocpos");

                entity.HasOne(d => d.idmodelNavigation)
                    .WithMany(p => p.supplydocpos)
                    .HasForeignKey(d => d.idmodel)
                    .HasConstraintName("FK_supplydocpos_model");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.supplydocpos)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_supplydocpos_orderitem");

                entity.HasOne(d => d.idsupplydocNavigation)
                    .WithMany(p => p.supplydocpos)
                    .HasForeignKey(d => d.idsupplydoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_supplydocpos_supplydoc");

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentid)
                    .HasConstraintName("FK_supplydocpos_supplydocpos");
            });

            modelBuilder.Entity<supplydocsign>(entity =>
            {
                entity.Property(e => e.idsupplydocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.supplydocsign)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_supplydocsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.supplydocsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_supplydocsign_sign");

                entity.HasOne(d => d.idsupplydocNavigation)
                    .WithMany(p => p.supplydocsign)
                    .HasForeignKey(d => d.idsupplydoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_supplydocsign_supplydoc");

                entity.HasOne(d => d.idsupplydocposNavigation)
                    .WithMany(p => p.supplydocsign)
                    .HasForeignKey(d => d.idsupplydocpos)
                    .HasConstraintName("FK_supplydocsign_supplydocpos");
            });

            modelBuilder.Entity<sysconnect>(entity =>
            {
                entity.Property(e => e.idsysconnect).ValueGeneratedNever();
            });

            modelBuilder.Entity<sysevent>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<sysinfo>(entity =>
            {
                entity.HasKey(e => e.idsysinfo)
                    .HasName("sysinfo_pkey");

                entity.Property(e => e.idsysinfo).ValueGeneratedNever();
            });

            modelBuilder.Entity<system>(entity =>
            {
                entity.HasKey(e => e.idsystem)
                    .HasName("system_pkey");

                entity.Property(e => e.idsystem).ValueGeneratedNever();

                entity.Property(e => e.allow_any_handle).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_centre_handle).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_fix_handle).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_gluhoe).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_mayatnik).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_otk).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_podv).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_pov).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_povotk).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_razd).HasDefaultValueSql("((1))");

                entity.Property(e => e.allow_stv_in_stv).HasDefaultValueSql("((1))");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.systemtype).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.system)
                    .HasForeignKey(d => d.idversion)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_system_versions");
            });

            modelBuilder.Entity<systemdetail>(entity =>
            {
                entity.HasKey(e => e.idsystemdetail)
                    .HasName("systemdetail_pkey");

                entity.Property(e => e.idsystemdetail).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.sqr1).HasComment("Ламинация внутренняя");

                entity.Property(e => e.sqr2).HasComment("Ламинация внешняя");

                entity.HasOne(d => d.idconnectortypeNavigation)
                    .WithMany(p => p.systemdetail)
                    .HasForeignKey(d => d.idconnectortype)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_systemdetail_connectortype");

                entity.HasOne(d => d.idmodelpartNavigation)
                    .WithMany(p => p.systemdetail)
                    .HasForeignKey(d => d.idmodelpart)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_systemdetail_modelpart");

                entity.HasOne(d => d.idsystemNavigation)
                    .WithMany(p => p.systemdetail)
                    .HasForeignKey(d => d.idsystem)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_systemdetail_system");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.systemdetail)
                    .HasForeignKey(d => d.idversion)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_systemdetail_version");
            });

            modelBuilder.Entity<systemdetailrel>(entity =>
            {
                entity.Property(e => e.idsystemdetailrel).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idsystemdetailNavigation)
                    .WithMany(p => p.systemdetailrelidsystemdetailNavigation)
                    .HasForeignKey(d => d.idsystemdetail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_systemdetailrel_systemdetail");

                entity.HasOne(d => d.idsystemdetail2Navigation)
                    .WithMany(p => p.systemdetailrelidsystemdetail2Navigation)
                    .HasForeignKey(d => d.idsystemdetail2)
                    .HasConstraintName("FK_systemdetailrel_systemdetail1");

                entity.HasOne(d => d.idversionNavigation)
                    .WithMany(p => p.systemdetailrel)
                    .HasForeignKey(d => d.idversion)
                    .HasConstraintName("FK_systemdetailrel_versions");
            });

            modelBuilder.Entity<systemdetailrelationship>(entity =>
            {
                entity.Property(e => e.idsystemdetailrelationship).ValueGeneratedNever();

                entity.HasOne(d => d.idsystemdetail1Navigation)
                    .WithMany(p => p.systemdetailrelationshipidsystemdetail1Navigation)
                    .HasForeignKey(d => d.idsystemdetail1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_systemdetailrelationship_systemdetail1");

                entity.HasOne(d => d.idsystemdetail2Navigation)
                    .WithMany(p => p.systemdetailrelationshipidsystemdetail2Navigation)
                    .HasForeignKey(d => d.idsystemdetail2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_systemdetailrelationship_systemdetail2");
            });

            modelBuilder.Entity<sysupdate>(entity =>
            {
                entity.Property(e => e.idsysupdate).ValueGeneratedNever();
            });

            modelBuilder.Entity<tablefiles>(entity =>
            {
                entity.Property(e => e.idtablefiles).ValueGeneratedNever();
            });

            modelBuilder.Entity<tariff>(entity =>
            {
                entity.Property(e => e.idtariff).ValueGeneratedNever();
            });

            modelBuilder.Entity<techdoc>(entity =>
            {
                entity.HasKey(e => e.idtechdoc)
                    .HasName("PK_techdocdoc");

                entity.Property(e => e.idtechdoc).ValueGeneratedNever();

                entity.HasOne(d => d.idcustomerNavigation)
                    .WithMany(p => p.techdoc)
                    .HasForeignKey(d => d.idcustomer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_techdoc_customer");

                entity.HasOne(d => d.iddocoperNavigation)
                    .WithMany(p => p.techdoc)
                    .HasForeignKey(d => d.iddocoper)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_techdoc_docoper");

                entity.HasOne(d => d.iddocstateNavigation)
                    .WithMany(p => p.techdoc)
                    .HasForeignKey(d => d.iddocstate)
                    .HasConstraintName("FK_techdoc_docstate");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.techdoc)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_techdoc_people");

                entity.HasOne(d => d.idtechdocgroupNavigation)
                    .WithMany(p => p.techdoc)
                    .HasForeignKey(d => d.idtechdocgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_techdoc_techdocgroup");
            });

            modelBuilder.Entity<techdocdiraction>(entity =>
            {
                entity.Property(e => e.idtechdocdiraction).ValueGeneratedNever();

                entity.HasOne(d => d.iddiractionNavigation)
                    .WithMany(p => p.techdocdiraction)
                    .HasForeignKey(d => d.iddiraction)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_techdocdiraction_diraction");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.techdocdiraction)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_techdocdiraction_people");

                entity.HasOne(d => d.idtechdocNavigation)
                    .WithMany(p => p.techdocdiraction)
                    .HasForeignKey(d => d.idtechdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_techdocdiraction_techdoc");
            });

            modelBuilder.Entity<techdocgroup>(entity =>
            {
                entity.HasKey(e => e.idtechdocgroup)
                    .HasName("PK_techdocdocgroup");

                entity.Property(e => e.idtechdocgroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<techdocpos>(entity =>
            {
                entity.HasKey(e => e.idtechdocpos)
                    .HasName("PK_techdocdocpos");

                entity.Property(e => e.idtechdocpos).ValueGeneratedNever();

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.techdocpos)
                    .HasForeignKey(d => d.idgood)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_techdocpos_good");

                entity.HasOne(d => d.idmanufactdocposNavigation)
                    .WithMany(p => p.techdocpos)
                    .HasForeignKey(d => d.idmanufactdocpos)
                    .HasConstraintName("FK_techdocpos_manufactdocpos");

                entity.HasOne(d => d.idmodelNavigation)
                    .WithMany(p => p.techdocpos)
                    .HasForeignKey(d => d.idmodel)
                    .HasConstraintName("FK_techdocpos_model");

                entity.HasOne(d => d.idorderitemNavigation)
                    .WithMany(p => p.techdocpos)
                    .HasForeignKey(d => d.idorderitem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_techdocpos_orderitem");

                entity.HasOne(d => d.idtechdocNavigation)
                    .WithMany(p => p.techdocpos)
                    .HasForeignKey(d => d.idtechdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_techdocpos_techdoc");
            });

            modelBuilder.Entity<techdocsign>(entity =>
            {
                entity.Property(e => e.idtechdocsign).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.techdocsign)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_techdocsign_people");

                entity.HasOne(d => d.idsignNavigation)
                    .WithMany(p => p.techdocsign)
                    .HasForeignKey(d => d.idsign)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_techdocsign_sign");

                entity.HasOne(d => d.idsignvalueNavigation)
                    .WithMany(p => p.techdocsign)
                    .HasForeignKey(d => d.idsignvalue)
                    .HasConstraintName("FK_techdocsign_signvalue");

                entity.HasOne(d => d.idtechdocNavigation)
                    .WithMany(p => p.techdocsign)
                    .HasForeignKey(d => d.idtechdoc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_techdocsign_techdoc");
            });

            modelBuilder.Entity<template>(entity =>
            {
                entity.HasKey(e => e.idtemplate)
                    .HasName("PK_template1");

                entity.Property(e => e.idtemplate).ValueGeneratedNever();

                entity.Property(e => e.idproductiontype).HasComment("Тип продукции");

                entity.HasOne(d => d.idtemplategroupNavigation)
                    .WithMany(p => p.template)
                    .HasForeignKey(d => d.idtemplategroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_template_templategroup");
            });

            modelBuilder.Entity<templategroup>(entity =>
            {
                entity.HasKey(e => e.idtemplategroup)
                    .HasName("PK_template");

                entity.Property(e => e.idtemplategroup).ValueGeneratedNever();
            });

            modelBuilder.Entity<templateparam>(entity =>
            {
                entity.HasKey(e => e.idtemplateparam)
                    .HasName("pk_templateparamcalc");

                entity.Property(e => e.idtemplateparam).ValueGeneratedNever();

                entity.HasOne(d => d.idmodelparamNavigation)
                    .WithMany(p => p.templateparam)
                    .HasForeignKey(d => d.idmodelparam)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_templateparam_modelparam");

                entity.HasOne(d => d.idmodelpartNavigation)
                    .WithMany(p => p.templateparam)
                    .HasForeignKey(d => d.idmodelpart)
                    .HasConstraintName("FK_templateparam_modelpart");

                entity.HasOne(d => d.idtemplateNavigation)
                    .WithMany(p => p.templateparam)
                    .HasForeignKey(d => d.idtemplate)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_templateparam_template");
            });

            modelBuilder.Entity<tig_view_diraction>(entity =>
            {
                entity.ToView("tig_view_diraction");
            });

            modelBuilder.Entity<tig_view_diraction_date>(entity =>
            {
                entity.ToView("tig_view_diraction_date");
            });

            modelBuilder.Entity<trash>(entity =>
            {
                entity.Property(e => e.idtrash).ValueGeneratedNever();
            });

            modelBuilder.Entity<valut>(entity =>
            {
                entity.Property(e => e.idvalut).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<valutrate>(entity =>
            {
                entity.Property(e => e.idvalutrate).ValueGeneratedNever();

                entity.HasOne(d => d.idvalutNavigation)
                    .WithMany(p => p.valutrateidvalutNavigation)
                    .HasForeignKey(d => d.idvalut)
                    .HasConstraintName("FK_valutrate_valut");

                entity.HasOne(d => d.idvalut2Navigation)
                    .WithMany(p => p.valutrateidvalut2Navigation)
                    .HasForeignKey(d => d.idvalut2)
                    .HasConstraintName("FK_valutrate_valut1");
            });

            modelBuilder.Entity<variant>(entity =>
            {
                entity.Property(e => e.idvariant).ValueGeneratedNever();

                entity.HasOne(d => d.idconnectionNavigation)
                    .WithMany(p => p.variant)
                    .HasForeignKey(d => d.idconnection)
                    .HasConstraintName("FK_variant_connection");

                entity.HasOne(d => d.idvarianttypeNavigation)
                    .WithMany(p => p.variant)
                    .HasForeignKey(d => d.idvarianttype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_variant_varianttype");
            });

            modelBuilder.Entity<variantdetail>(entity =>
            {
                entity.Property(e => e.idvariantdetail).ValueGeneratedNever();

                entity.HasOne(d => d.iderrorNavigation)
                    .WithMany(p => p.variantdetail)
                    .HasForeignKey(d => d.iderror)
                    .HasConstraintName("FK_variantdetail_iderror");

                entity.HasOne(d => d.idgoodNavigation)
                    .WithMany(p => p.variantdetail)
                    .HasForeignKey(d => d.idgood)
                    .HasConstraintName("FK_variantdetail_good");

                entity.HasOne(d => d.idvariantNavigation)
                    .WithMany(p => p.variantdetail)
                    .HasForeignKey(d => d.idvariant)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_variantdetail_variant");

                entity.HasOne(d => d.idworkoperNavigation)
                    .WithMany(p => p.variantdetail)
                    .HasForeignKey(d => d.idworkoper)
                    .HasConstraintName("FK_variantdetail_idworkoper");
            });

            modelBuilder.Entity<variantparam>(entity =>
            {
                entity.Property(e => e.idvariantparam).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorNavigation)
                    .WithMany(p => p.variantparam)
                    .HasForeignKey(d => d.idcolor)
                    .HasConstraintName("FK_variantparam_color");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.variantparam)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_variantparam_constructiontype");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.variantparam)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_variantparam_modelparamvalue");

                entity.HasOne(d => d.idvariantNavigation)
                    .WithMany(p => p.variantparam)
                    .HasForeignKey(d => d.idvariant)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_variantparam_variant");

                entity.HasOne(d => d.idvariantparamtypeNavigation)
                    .WithMany(p => p.variantparam)
                    .HasForeignKey(d => d.idvariantparamtype)
                    .HasConstraintName("FK_variantparam_variantparamtype");

                entity.HasOne(d => d.idvariantparamtypevalueNavigation)
                    .WithMany(p => p.variantparam)
                    .HasForeignKey(d => d.idvariantparamtypevalue)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_variantparam_variantparamtypevalue");
            });

            modelBuilder.Entity<variantparamdetail>(entity =>
            {
                entity.Property(e => e.idvariantparamdetail).ValueGeneratedNever();

                entity.HasOne(d => d.idcolorNavigation)
                    .WithMany(p => p.variantparamdetail)
                    .HasForeignKey(d => d.idcolor)
                    .HasConstraintName("FK_variantparamdetail_color");

                entity.HasOne(d => d.idcoloraccordanceNavigation)
                    .WithMany(p => p.variantparamdetail)
                    .HasForeignKey(d => d.idcoloraccordance)
                    .HasConstraintName("FK_variantparamdetail_coloraccordance");

                entity.HasOne(d => d.idconstructiontypeNavigation)
                    .WithMany(p => p.variantparamdetail)
                    .HasForeignKey(d => d.idconstructiontype)
                    .HasConstraintName("FK_variantparamdetail_constructiontype");

                entity.HasOne(d => d.idmodelparamvalueNavigation)
                    .WithMany(p => p.variantparamdetail)
                    .HasForeignKey(d => d.idmodelparamvalue)
                    .HasConstraintName("FK_variantparamdetail_modelparamvalue");

                entity.HasOne(d => d.idvariantdetailNavigation)
                    .WithMany(p => p.variantparamdetail)
                    .HasForeignKey(d => d.idvariantdetail)
                    .HasConstraintName("FK_variantparamdetail_variantdetail");

                entity.HasOne(d => d.idvariantparamtypeNavigation)
                    .WithMany(p => p.variantparamdetail)
                    .HasForeignKey(d => d.idvariantparamtype)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_variantparam_variantparamtypedetail");

                entity.HasOne(d => d.idvariantparamtypevalueNavigation)
                    .WithMany(p => p.variantparamdetail)
                    .HasForeignKey(d => d.idvariantparamtypevalue)
                    .HasConstraintName("FK_variantparamdetail_variantparamtypevalue");
            });

            modelBuilder.Entity<variantparamtype>(entity =>
            {
                entity.Property(e => e.idvariantparamtype).ValueGeneratedNever();
            });

            modelBuilder.Entity<variantparamtypevalue>(entity =>
            {
                entity.Property(e => e.idvariantparamtypevalue).ValueGeneratedNever();

                entity.HasOne(d => d.idvariantparamtypeNavigation)
                    .WithMany(p => p.variantparamtypevalue)
                    .HasForeignKey(d => d.idvariantparamtype)
                    .HasConstraintName("FK_variantparamtypevalue_variantparamtypevalue");
            });

            modelBuilder.Entity<varianttype>(entity =>
            {
                entity.Property(e => e.idvarianttype).ValueGeneratedNever();
            });

            modelBuilder.Entity<vectorpicture>(entity =>
            {
                entity.Property(e => e.idvectorpicture).ValueGeneratedNever();
            });

            modelBuilder.Entity<vectorpicturedetail>(entity =>
            {
                entity.Property(e => e.idvectorpicturedetail).ValueGeneratedNever();

                entity.HasOne(d => d.idvectorpictureNavigation)
                    .WithMany(p => p.vectorpicturedetail)
                    .HasForeignKey(d => d.idvectorpicture)
                    .HasConstraintName("FK_vectorpicturedetail_vectorpicture");
            });

            modelBuilder.Entity<versions>(entity =>
            {
                entity.HasKey(e => e.idversion)
                    .HasName("version_pkey");

                entity.Property(e => e.idversion).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<view_actionhistory>(entity =>
            {
                entity.ToView("view_actionhistory");
            });

            modelBuilder.Entity<view_activ_goodkitgroup>(entity =>
            {
                entity.ToView("view_activ_goodkitgroup");
            });

            modelBuilder.Entity<view_addarea>(entity =>
            {
                entity.ToView("view_addarea");
            });

            modelBuilder.Entity<view_addbuild>(entity =>
            {
                entity.ToView("view_addbuild");
            });

            modelBuilder.Entity<view_addcity>(entity =>
            {
                entity.ToView("view_addcity");
            });

            modelBuilder.Entity<view_addcityregion>(entity =>
            {
                entity.ToView("view_addcityregion");
            });

            modelBuilder.Entity<view_address>(entity =>
            {
                entity.ToView("view_address");
            });

            modelBuilder.Entity<view_address_forfind>(entity =>
            {
                entity.ToView("view_address_forfind");
            });

            modelBuilder.Entity<view_addstreet>(entity =>
            {
                entity.ToView("view_addstreet");
            });

            modelBuilder.Entity<view_adresselement>(entity =>
            {
                entity.ToView("view_adresselement");
            });

            modelBuilder.Entity<view_advertisingaction>(entity =>
            {
                entity.ToView("view_advertisingaction");
            });

            modelBuilder.Entity<view_agree>(entity =>
            {
                entity.ToView("view_agree");
            });

            modelBuilder.Entity<view_agreementgrant>(entity =>
            {
                entity.ToView("view_agreementgrant");
            });

            modelBuilder.Entity<view_allgoodfrommodel>(entity =>
            {
                entity.ToView("view_allgoodfrommodel");
            });

            modelBuilder.Entity<view_allgoodfromorder>(entity =>
            {
                entity.ToView("view_allgoodfromorder");
            });

            modelBuilder.Entity<view_allgoodfromorderprice>(entity =>
            {
                entity.ToView("view_allgoodfromorderprice");
            });

            modelBuilder.Entity<view_alu_cityregion>(entity =>
            {
                entity.ToView("view_alu_cityregion");
            });

            modelBuilder.Entity<view_car>(entity =>
            {
                entity.ToView("view_car");
            });

            modelBuilder.Entity<view_carmarking>(entity =>
            {
                entity.ToView("view_carmarking");
            });

            modelBuilder.Entity<view_cashbox>(entity =>
            {
                entity.ToView("view_cashbox");
            });

            modelBuilder.Entity<view_coatdoc>(entity =>
            {
                entity.ToView("view_coatdoc");
            });

            modelBuilder.Entity<view_coatdocpos>(entity =>
            {
                entity.ToView("view_coatdocpos");
            });

            modelBuilder.Entity<view_coatdocsign>(entity =>
            {
                entity.ToView("view_coatdocsign");
            });

            modelBuilder.Entity<view_color>(entity =>
            {
                entity.ToView("view_color");
            });

            modelBuilder.Entity<view_commongroupgrant>(entity =>
            {
                entity.ToView("view_commongroupgrant");
            });

            modelBuilder.Entity<view_constructiontype>(entity =>
            {
                entity.ToView("view_constructiontype");
            });

            modelBuilder.Entity<view_customer>(entity =>
            {
                entity.ToView("view_customer");
            });

            modelBuilder.Entity<view_customerdestanation>(entity =>
            {
                entity.ToView("view_customerdestanation");
            });

            modelBuilder.Entity<view_customerdiraction>(entity =>
            {
                entity.ToView("view_customerdiraction");
            });

            modelBuilder.Entity<view_customerdiscard>(entity =>
            {
                entity.ToView("view_customerdiscard");
            });

            modelBuilder.Entity<view_customergroupgrant>(entity =>
            {
                entity.ToView("view_customergroupgrant");
            });

            modelBuilder.Entity<view_customerpeople>(entity =>
            {
                entity.ToView("view_customerpeople");
            });

            modelBuilder.Entity<view_customerpricechange>(entity =>
            {
                entity.ToView("view_customerpricechange");
            });

            modelBuilder.Entity<view_customerpricechangehistory>(entity =>
            {
                entity.ToView("view_customerpricechangehistory");
            });

            modelBuilder.Entity<view_customerpricepolicy>(entity =>
            {
                entity.ToView("view_customerpricepolicy");
            });

            modelBuilder.Entity<view_customerpricepolicyhistory>(entity =>
            {
                entity.ToView("view_customerpricepolicyhistory");
            });

            modelBuilder.Entity<view_customerrel>(entity =>
            {
                entity.ToView("view_customerrel");
            });

            modelBuilder.Entity<view_customersign>(entity =>
            {
                entity.ToView("view_customersign");
            });

            modelBuilder.Entity<view_delivdoc>(entity =>
            {
                entity.ToView("view_delivdoc");
            });

            modelBuilder.Entity<view_delivdocdiraction>(entity =>
            {
                entity.ToView("view_delivdocdiraction");
            });

            modelBuilder.Entity<view_delivdocdiractionpeople>(entity =>
            {
                entity.ToView("view_delivdocdiractionpeople");
            });

            modelBuilder.Entity<view_delivdocpeople>(entity =>
            {
                entity.ToView("view_delivdocpeople");
            });

            modelBuilder.Entity<view_delivdocpos>(entity =>
            {
                entity.ToView("view_delivdocpos");
            });

            modelBuilder.Entity<view_delivdocsign>(entity =>
            {
                entity.ToView("view_delivdocsign");
            });

            modelBuilder.Entity<view_departmentmember>(entity =>
            {
                entity.ToView("view_departmentmember");
            });

            modelBuilder.Entity<view_destanation>(entity =>
            {
                entity.ToView("view_destanation");
            });

            modelBuilder.Entity<view_destanationcustomer>(entity =>
            {
                entity.ToView("view_destanationcustomer");
            });

            modelBuilder.Entity<view_destanationseller>(entity =>
            {
                entity.ToView("view_destanationseller");
            });

            modelBuilder.Entity<view_diractiongrant_data>(entity =>
            {
                entity.ToView("view_diractiongrant_data");
            });

            modelBuilder.Entity<view_diractiongroup_from_grants>(entity =>
            {
                entity.ToView("view_diractiongroup_from_grants");
            });

            modelBuilder.Entity<view_discard>(entity =>
            {
                entity.ToView("view_discard");
            });

            modelBuilder.Entity<view_docgroupgrant>(entity =>
            {
                entity.ToView("view_docgroupgrant");
            });

            modelBuilder.Entity<view_doclock>(entity =>
            {
                entity.ToView("view_doclock");
            });

            modelBuilder.Entity<view_docoper>(entity =>
            {
                entity.ToView("view_docoper");
            });

            modelBuilder.Entity<view_docopergrant>(entity =>
            {
                entity.ToView("view_docopergrant");
            });

            modelBuilder.Entity<view_docscriptgrant>(entity =>
            {
                entity.ToView("view_docscriptgrant");
            });

            modelBuilder.Entity<view_docsign>(entity =>
            {
                entity.ToView("view_docsign");
            });

            modelBuilder.Entity<view_docstate>(entity =>
            {
                entity.ToView("view_docstate");
            });

            modelBuilder.Entity<view_docwork>(entity =>
            {
                entity.ToView("view_docwork");
            });

            modelBuilder.Entity<view_docworkpeople>(entity =>
            {
                entity.ToView("view_docworkpeople");
            });

            modelBuilder.Entity<view_dopgood_fromorder>(entity =>
            {
                entity.ToView("view_dopgood_fromorder");
            });

            modelBuilder.Entity<view_equipmentdoc>(entity =>
            {
                entity.ToView("view_equipmentdoc");
            });

            modelBuilder.Entity<view_equipmentdocfile>(entity =>
            {
                entity.ToView("view_equipmentdocfile");
            });

            modelBuilder.Entity<view_equipmentdocfile1>(entity =>
            {
                entity.ToView("view_equipmentdocfile1");
            });

            modelBuilder.Entity<view_equipmentglass>(entity =>
            {
                entity.ToView("view_equipmentglass");
            });

            modelBuilder.Entity<view_error>(entity =>
            {
                entity.ToView("view_error");
            });

            modelBuilder.Entity<view_errorgroup>(entity =>
            {
                entity.ToView("view_errorgroup");
            });

            modelBuilder.Entity<view_errortype>(entity =>
            {
                entity.ToView("view_errortype");
            });

            modelBuilder.Entity<view_files>(entity =>
            {
                entity.ToView("view_files");
            });

            modelBuilder.Entity<view_finparamcalc>(entity =>
            {
                entity.ToView("view_finparamcalc");
            });

            modelBuilder.Entity<view_glass>(entity =>
            {
                entity.ToView("view_glass");
            });

            modelBuilder.Entity<view_glassdetail>(entity =>
            {
                entity.ToView("view_glassdetail");
            });

            modelBuilder.Entity<view_good>(entity =>
            {
                entity.ToView("view_good");
            });

            modelBuilder.Entity<view_goodanalogdetail>(entity =>
            {
                entity.ToView("view_goodanalogdetail");
            });

            modelBuilder.Entity<view_goodbuffer>(entity =>
            {
                entity.ToView("view_goodbuffer");
            });

            modelBuilder.Entity<view_goodcolorgroupprice>(entity =>
            {
                entity.ToView("view_goodcolorgroupprice");
            });

            modelBuilder.Entity<view_goodcolorparam>(entity =>
            {
                entity.ToView("view_goodcolorparam");
            });

            modelBuilder.Entity<view_goodkitdetail>(entity =>
            {
                entity.ToView("view_goodkitdetail");
            });

            modelBuilder.Entity<view_goodmeasure>(entity =>
            {
                entity.ToView("view_goodmeasure");
            });

            modelBuilder.Entity<view_goodoptim>(entity =>
            {
                entity.ToView("view_goodoptim");
            });

            modelBuilder.Entity<view_goodost>(entity =>
            {
                entity.ToView("view_goodost");
            });

            modelBuilder.Entity<view_goodprice>(entity =>
            {
                entity.ToView("view_goodprice");
            });

            modelBuilder.Entity<view_goodservice>(entity =>
            {
                entity.ToView("view_goodservice");
            });

            modelBuilder.Entity<view_installdoc>(entity =>
            {
                entity.ToView("view_installdoc");
            });

            modelBuilder.Entity<view_installdocdiraction>(entity =>
            {
                entity.ToView("view_installdocdiraction");
            });

            modelBuilder.Entity<view_installdocdiractionpeople>(entity =>
            {
                entity.ToView("view_installdocdiractionpeople");
            });

            modelBuilder.Entity<view_installdocgoodservice>(entity =>
            {
                entity.ToView("view_installdocgoodservice");
            });

            modelBuilder.Entity<view_installdocpos>(entity =>
            {
                entity.ToView("view_installdocpos");
            });

            modelBuilder.Entity<view_installdocsign>(entity =>
            {
                entity.ToView("view_installdocsign");
            });

            modelBuilder.Entity<view_manufactdiraction>(entity =>
            {
                entity.ToView("view_manufactdiraction");
            });

            modelBuilder.Entity<view_manufactdiractionpeople>(entity =>
            {
                entity.ToView("view_manufactdiractionpeople");
            });

            modelBuilder.Entity<view_manufactdoc>(entity =>
            {
                entity.ToView("view_manufactdoc");
            });

            modelBuilder.Entity<view_manufactdocmodelpic>(entity =>
            {
                entity.ToView("view_manufactdocmodelpic");
            });

            modelBuilder.Entity<view_manufactdocpos>(entity =>
            {
                entity.ToView("view_manufactdocpos");
            });

            modelBuilder.Entity<view_manufactdocpos_plan>(entity =>
            {
                entity.ToView("view_manufactdocpos_plan");
            });

            modelBuilder.Entity<view_manufactdocpyramid>(entity =>
            {
                entity.ToView("view_manufactdocpyramid");
            });

            modelBuilder.Entity<view_manufactdocsign>(entity =>
            {
                entity.ToView("view_manufactdocsign");
            });

            modelBuilder.Entity<view_manufactsign>(entity =>
            {
                entity.ToView("view_manufactsign");
            });

            modelBuilder.Entity<view_markingfilterdetail>(entity =>
            {
                entity.ToView("view_markingfilterdetail");
            });

            modelBuilder.Entity<view_measure>(entity =>
            {
                entity.ToView("view_measure");
            });

            modelBuilder.Entity<view_message>(entity =>
            {
                entity.ToView("view_message");
            });

            modelBuilder.Entity<view_model>(entity =>
            {
                entity.ToView("view_model");
            });

            modelBuilder.Entity<view_modelcalc>(entity =>
            {
                entity.ToView("view_modelcalc");
            });

            modelBuilder.Entity<view_modelparam>(entity =>
            {
                entity.ToView("view_modelparam");
            });

            modelBuilder.Entity<view_modelparamcalc>(entity =>
            {
                entity.ToView("view_modelparamcalc");
            });

            modelBuilder.Entity<view_modelpic>(entity =>
            {
                entity.ToView("view_modelpic");
            });

            modelBuilder.Entity<view_modelscript>(entity =>
            {
                entity.ToView("view_modelscript");
            });

            modelBuilder.Entity<view_nopaper>(entity =>
            {
                entity.ToView("view_nopaper");
            });

            modelBuilder.Entity<view_optimdoc>(entity =>
            {
                entity.ToView("view_optimdoc");
            });

            modelBuilder.Entity<view_optimdocdiraction>(entity =>
            {
                entity.ToView("view_optimdocdiraction");
            });

            modelBuilder.Entity<view_optimdocdiractionpeople>(entity =>
            {
                entity.ToView("view_optimdocdiractionpeople");
            });

            modelBuilder.Entity<view_optimdocgoodin>(entity =>
            {
                entity.ToView("view_optimdocgoodin");
            });

            modelBuilder.Entity<view_optimdocgoodout>(entity =>
            {
                entity.ToView("view_optimdocgoodout");
            });

            modelBuilder.Entity<view_optimdocpic>(entity =>
            {
                entity.ToView("view_optimdocpic");
            });

            modelBuilder.Entity<view_optimdocpos>(entity =>
            {
                entity.ToView("view_optimdocpos");
            });

            modelBuilder.Entity<view_optimdocsign>(entity =>
            {
                entity.ToView("view_optimdocsign");
            });

            modelBuilder.Entity<view_orderbudget>(entity =>
            {
                entity.ToView("view_orderbudget");
            });

            modelBuilder.Entity<view_orderdiraction>(entity =>
            {
                entity.ToView("view_orderdiraction");
            });

            modelBuilder.Entity<view_orderdiractionpeople>(entity =>
            {
                entity.ToView("view_orderdiractionpeople");
            });

            modelBuilder.Entity<view_ordererror>(entity =>
            {
                entity.ToView("view_ordererror");
            });

            modelBuilder.Entity<view_ordergood>(entity =>
            {
                entity.ToView("view_ordergood");
            });

            modelBuilder.Entity<view_ordergoodservice>(entity =>
            {
                entity.ToView("view_ordergoodservice");
            });

            modelBuilder.Entity<view_orderitem>(entity =>
            {
                entity.ToView("view_orderitem");
            });

            modelBuilder.Entity<view_orderitem_model>(entity =>
            {
                entity.ToView("view_orderitem_model");
            });

            modelBuilder.Entity<view_orderitem_ordergood>(entity =>
            {
                entity.ToView("view_orderitem_ordergood");
            });

            modelBuilder.Entity<view_orderitem_pc_good>(entity =>
            {
                entity.ToView("view_orderitem_pc_good");
            });

            modelBuilder.Entity<view_orderpricechange>(entity =>
            {
                entity.ToView("view_orderpricechange");
            });

            modelBuilder.Entity<view_orders>(entity =>
            {
                entity.ToView("view_orders");
            });

            modelBuilder.Entity<view_orders_pricechange>(entity =>
            {
                entity.ToView("view_orders_pricechange");
            });

            modelBuilder.Entity<view_ordersign>(entity =>
            {
                entity.ToView("view_ordersign");
            });

            modelBuilder.Entity<view_ordersmodelpic>(entity =>
            {
                entity.ToView("view_ordersmodelpic");
            });

            modelBuilder.Entity<view_payment>(entity =>
            {
                entity.ToView("view_payment");
            });

            modelBuilder.Entity<view_paymentdoc>(entity =>
            {
                entity.ToView("view_paymentdoc");
            });

            modelBuilder.Entity<view_paymentdocsign>(entity =>
            {
                entity.ToView("view_paymentdocsign");
            });

            modelBuilder.Entity<view_people>(entity =>
            {
                entity.ToView("view_people");
            });

            modelBuilder.Entity<view_peoplegrouplist>(entity =>
            {
                entity.ToView("view_peoplegrouplist");
            });

            modelBuilder.Entity<view_pok_diraction_date>(entity =>
            {
                entity.ToView("view_pok_diraction_date");
            });

            modelBuilder.Entity<view_poll>(entity =>
            {
                entity.ToView("view_poll");
            });

            modelBuilder.Entity<view_pollanswer>(entity =>
            {
                entity.ToView("view_pollanswer");
            });

            modelBuilder.Entity<view_pollexecuting>(entity =>
            {
                entity.ToView("view_pollexecuting");
            });

            modelBuilder.Entity<view_pollexecutingdiraction>(entity =>
            {
                entity.ToView("view_pollexecutingdiraction");
            });

            modelBuilder.Entity<view_pollexecutingitem>(entity =>
            {
                entity.ToView("view_pollexecutingitem");
            });

            modelBuilder.Entity<view_pollexecutingitemanswer>(entity =>
            {
                entity.ToView("view_pollexecutingitemanswer");
            });

            modelBuilder.Entity<view_pollexecutingsign>(entity =>
            {
                entity.ToView("view_pollexecutingsign");
            });

            modelBuilder.Entity<view_pollquestion>(entity =>
            {
                entity.ToView("view_pollquestion");
            });

            modelBuilder.Entity<view_pollrelation>(entity =>
            {
                entity.ToView("view_pollrelation");
            });

            modelBuilder.Entity<view_power>(entity =>
            {
                entity.ToView("view_power");
            });

            modelBuilder.Entity<view_powergrant>(entity =>
            {
                entity.ToView("view_powergrant");
            });

            modelBuilder.Entity<view_pricechange>(entity =>
            {
                entity.ToView("view_pricechange");
            });

            modelBuilder.Entity<view_pricechangegrant>(entity =>
            {
                entity.ToView("view_pricechangegrant");
            });

            modelBuilder.Entity<view_pricelist>(entity =>
            {
                entity.ToView("view_pricelist");
            });

            modelBuilder.Entity<view_pricelistgoodservice>(entity =>
            {
                entity.ToView("view_pricelistgoodservice");
            });

            modelBuilder.Entity<view_pricelistpricechange>(entity =>
            {
                entity.ToView("view_pricelistpricechange");
            });

            modelBuilder.Entity<view_productiondoc>(entity =>
            {
                entity.ToView("view_productiondoc");
            });

            modelBuilder.Entity<view_productiondocpos>(entity =>
            {
                entity.ToView("view_productiondocpos");
            });

            modelBuilder.Entity<view_productiondocsign>(entity =>
            {
                entity.ToView("view_productiondocsign");
            });

            modelBuilder.Entity<view_productiontype>(entity =>
            {
                entity.ToView("view_productiontype");
            });

            modelBuilder.Entity<view_productiontypeconstruction>(entity =>
            {
                entity.ToView("view_productiontypeconstruction");
            });

            modelBuilder.Entity<view_productiontypegrant>(entity =>
            {
                entity.ToView("view_productiontypegrant");
            });

            modelBuilder.Entity<view_productiontypegroup>(entity =>
            {
                entity.ToView("view_productiontypegroup");
            });

            modelBuilder.Entity<view_productiontypeparam>(entity =>
            {
                entity.ToView("view_productiontypeparam");
            });

            modelBuilder.Entity<view_productiontypesetting>(entity =>
            {
                entity.ToView("view_productiontypesetting");
            });

            modelBuilder.Entity<view_productiontypesystems>(entity =>
            {
                entity.ToView("view_productiontypesystems");
            });

            modelBuilder.Entity<view_pyramid>(entity =>
            {
                entity.ToView("view_pyramid");
            });

            modelBuilder.Entity<view_pyramidfact>(entity =>
            {
                entity.ToView("view_pyramidfact");
            });

            modelBuilder.Entity<view_pyramidfactpos>(entity =>
            {
                entity.ToView("view_pyramidfactpos");
            });

            modelBuilder.Entity<view_report>(entity =>
            {
                entity.ToView("view_report");
            });

            modelBuilder.Entity<view_reportkitdetail>(entity =>
            {
                entity.ToView("view_reportkitdetail");
            });

            modelBuilder.Entity<view_reportsave>(entity =>
            {
                entity.ToView("view_reportsave");
            });

            modelBuilder.Entity<view_respower>(entity =>
            {
                entity.ToView("view_respower");
            });

            modelBuilder.Entity<view_seller>(entity =>
            {
                entity.ToView("view_seller");
            });

            modelBuilder.Entity<view_sellerdestanation>(entity =>
            {
                entity.ToView("view_sellerdestanation");
            });

            modelBuilder.Entity<view_sellergrant>(entity =>
            {
                entity.ToView("view_sellergrant");
            });

            modelBuilder.Entity<view_sellerpricechange>(entity =>
            {
                entity.ToView("view_sellerpricechange");
            });

            modelBuilder.Entity<view_servicedepartment>(entity =>
            {
                entity.ToView("view_servicedepartment");
            });

            modelBuilder.Entity<view_servicedepartmentpeople>(entity =>
            {
                entity.ToView("view_servicedepartmentpeople");
            });

            modelBuilder.Entity<view_servicedoc>(entity =>
            {
                entity.ToView("view_servicedoc");
            });

            modelBuilder.Entity<view_servicedocdiraction>(entity =>
            {
                entity.ToView("view_servicedocdiraction");
            });

            modelBuilder.Entity<view_servicedocpos>(entity =>
            {
                entity.ToView("view_servicedocpos");
            });

            modelBuilder.Entity<view_servicedocsign>(entity =>
            {
                entity.ToView("view_servicedocsign");
            });

            modelBuilder.Entity<view_servicereason>(entity =>
            {
                entity.ToView("view_servicereason");
            });

            modelBuilder.Entity<view_setting>(entity =>
            {
                entity.ToView("view_setting");
            });

            modelBuilder.Entity<view_signgrant_data>(entity =>
            {
                entity.ToView("view_signgrant_data");
            });

            modelBuilder.Entity<view_signgroup_from_grants>(entity =>
            {
                entity.ToView("view_signgroup_from_grants");
            });

            modelBuilder.Entity<view_signvalue>(entity =>
            {
                entity.ToView("view_signvalue");
            });

            modelBuilder.Entity<view_sizedoc>(entity =>
            {
                entity.ToView("view_sizedoc");
            });

            modelBuilder.Entity<view_sizedocconstrtype>(entity =>
            {
                entity.ToView("view_sizedocconstrtype");
            });

            modelBuilder.Entity<view_sizedocdiraction>(entity =>
            {
                entity.ToView("view_sizedocdiraction");
            });

            modelBuilder.Entity<view_sizedocdiractionpeople>(entity =>
            {
                entity.ToView("view_sizedocdiractionpeople");
            });

            modelBuilder.Entity<view_sizedocsign>(entity =>
            {
                entity.ToView("view_sizedocsign");
            });

            modelBuilder.Entity<view_storedepart>(entity =>
            {
                entity.ToView("view_storedepart");
            });

            modelBuilder.Entity<view_storedoc>(entity =>
            {
                entity.ToView("view_storedoc");
            });

            modelBuilder.Entity<view_storedocpos>(entity =>
            {
                entity.ToView("view_storedocpos");
            });

            modelBuilder.Entity<view_storedocsign>(entity =>
            {
                entity.ToView("view_storedocsign");
            });

            modelBuilder.Entity<view_supplydoc>(entity =>
            {
                entity.ToView("view_supplydoc");
            });

            modelBuilder.Entity<view_supplydocdiraction>(entity =>
            {
                entity.ToView("view_supplydocdiraction");
            });

            modelBuilder.Entity<view_supplydocgoodservice>(entity =>
            {
                entity.ToView("view_supplydocgoodservice");
            });

            modelBuilder.Entity<view_supplydocpos>(entity =>
            {
                entity.ToView("view_supplydocpos");
            });

            modelBuilder.Entity<view_supplydocsign>(entity =>
            {
                entity.ToView("view_supplydocsign");
            });

            modelBuilder.Entity<view_sysconnect>(entity =>
            {
                entity.ToView("view_sysconnect");
            });

            modelBuilder.Entity<view_systemdetail>(entity =>
            {
                entity.ToView("view_systemdetail");
            });

            modelBuilder.Entity<view_systemdetailrel>(entity =>
            {
                entity.ToView("view_systemdetailrel");
            });

            modelBuilder.Entity<view_systemdetailrelation>(entity =>
            {
                entity.ToView("view_systemdetailrelation");
            });

            modelBuilder.Entity<view_systemdetailrelationship>(entity =>
            {
                entity.ToView("view_systemdetailrelationship");
            });

            modelBuilder.Entity<view_techdoc>(entity =>
            {
                entity.ToView("view_techdoc");
            });

            modelBuilder.Entity<view_techdocdiraction>(entity =>
            {
                entity.ToView("view_techdocdiraction");
            });

            modelBuilder.Entity<view_techdocpos>(entity =>
            {
                entity.ToView("view_techdocpos");
            });

            modelBuilder.Entity<view_techdocsign>(entity =>
            {
                entity.ToView("view_techdocsign");
            });

            modelBuilder.Entity<view_template>(entity =>
            {
                entity.ToView("view_template");
            });

            modelBuilder.Entity<view_templateparam>(entity =>
            {
                entity.ToView("view_templateparam");
            });

            modelBuilder.Entity<view_tig_diraction>(entity =>
            {
                entity.ToView("view_tig_diraction");
            });

            modelBuilder.Entity<view_valutrate>(entity =>
            {
                entity.ToView("view_valutrate");
            });

            modelBuilder.Entity<view_vectorpicture>(entity =>
            {
                entity.ToView("view_vectorpicture");
            });

            modelBuilder.Entity<view_versions>(entity =>
            {
                entity.ToView("view_versions");
            });

            modelBuilder.Entity<view_wdlog>(entity =>
            {
                entity.ToView("view_wdlog");
            });

            modelBuilder.Entity<view_work>(entity =>
            {
                entity.ToView("view_work");
            });

            modelBuilder.Entity<view_workgroup>(entity =>
            {
                entity.ToView("view_workgroup");
            });

            modelBuilder.Entity<view_workoper>(entity =>
            {
                entity.ToView("view_workoper");
            });

            modelBuilder.Entity<view_workpeople>(entity =>
            {
                entity.ToView("view_workpeople");
            });

            modelBuilder.Entity<wdlog>(entity =>
            {
                entity.Property(e => e.idwdlog).ValueGeneratedNever();

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.wdlog)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_wdlog_people");
            });

            modelBuilder.Entity<work>(entity =>
            {
                entity.Property(e => e.idwork).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.work)
                    .HasForeignKey(d => d.idpeople)
                    .HasConstraintName("FK_work_people");

                entity.HasOne(d => d.idworkgroupNavigation)
                    .WithMany(p => p.work)
                    .HasForeignKey(d => d.idworkgroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_work_workgroup");
            });

            modelBuilder.Entity<workgroup>(entity =>
            {
                entity.Property(e => e.idworkgroup).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<workoper>(entity =>
            {
                entity.Property(e => e.idworkoper).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.workoper)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_workoper_people");

                entity.HasOne(d => d.idworkNavigation)
                    .WithMany(p => p.workoper)
                    .HasForeignKey(d => d.idwork)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_workoper_work");
            });

            modelBuilder.Entity<workpeople>(entity =>
            {
                entity.Property(e => e.idworkpeople).ValueGeneratedNever();

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.idpeopleNavigation)
                    .WithMany(p => p.workpeople)
                    .HasForeignKey(d => d.idpeople)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_workpeople_people");

                entity.HasOne(d => d.idworkNavigation)
                    .WithMany(p => p.workpeople)
                    .HasForeignKey(d => d.idwork)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_workpeople_work");
            });

            modelBuilder.Entity<wreportaccess>(entity =>
            {
                entity.Property(e => e.idreportaccess).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<wreportlogs>(entity =>
            {
                entity.HasKey(e => e.idlog)
                    .HasName("PK__wreportl__07BE4DF83F7494D1");

                entity.Property(e => e.action).HasDefaultValueSql("('')");

                entity.Property(e => e.date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.http_user_agent).HasDefaultValueSql("('')");

                entity.Property(e => e.ip).HasDefaultValueSql("('')");

                entity.Property(e => e.login).HasDefaultValueSql("('')");

                entity.Property(e => e.online_time)
                    .HasDefaultValueSql("('0')")
                    .HasComment("");

                entity.Property(e => e.page).HasDefaultValueSql("('')");

                entity.Property(e => e.pass).HasDefaultValueSql("('')");

                entity.Property(e => e.user_name).HasDefaultValueSql("('')");
            });

            modelBuilder.HasSequence<int>("gen_actionhistory");

            modelBuilder.HasSequence<int>("gen_addarea").StartsAt(22);

            modelBuilder.HasSequence<int>("gen_addbuild");

            modelBuilder.HasSequence<int>("gen_addcity").StartsAt(806);

            modelBuilder.HasSequence<int>("gen_addcityregion");

            modelBuilder.HasSequence<int>("gen_addclassification").StartsAt(59);

            modelBuilder.HasSequence<int>("gen_addclassificationgroup").StartsAt(11);

            modelBuilder.HasSequence<int>("gen_addregion").StartsAt(24);

            modelBuilder.HasSequence<int>("gen_address");

            modelBuilder.HasSequence<int>("gen_addstreet").StartsAt(202651);

            modelBuilder.HasSequence<int>("gen_advertisingaction").StartsAt(45);

            modelBuilder.HasSequence<int>("gen_advertisingactiongroup").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_agree");

            modelBuilder.HasSequence<int>("gen_agreement").StartsAt(57);

            modelBuilder.HasSequence<int>("gen_agreementcondition").StartsAt(7);

            modelBuilder.HasSequence<int>("gen_agreementconditionrel").StartsAt(94);

            modelBuilder.HasSequence<int>("gen_agreementgrant").StartsAt(38);

            modelBuilder.HasSequence<int>("gen_availabilitygroup").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_budget");

            modelBuilder.HasSequence<int>("gen_budgetgroup");

            modelBuilder.HasSequence<int>("gen_businesshours").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_businesshoursdetail").StartsAt(5);

            modelBuilder.HasSequence<int>("gen_calcerror").StartsAt(13);

            modelBuilder.HasSequence<int>("gen_car").StartsAt(37);

            modelBuilder.HasSequence<int>("gen_carmarking").StartsAt(12);

            modelBuilder.HasSequence<int>("gen_carmarkingroute").StartsAt(567);

            modelBuilder.HasSequence<int>("gen_cartariff").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_cashbox").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_coatdoc");

            modelBuilder.HasSequence<int>("gen_coatdocgroup");

            modelBuilder.HasSequence<int>("gen_coatdocpos");

            modelBuilder.HasSequence<int>("gen_coatdocsign");

            modelBuilder.HasSequence<int>("gen_color").StartsAt(20336557);

            modelBuilder.HasSequence<int>("gen_coloraccordance").StartsAt(16);

            modelBuilder.HasSequence<int>("gen_coloraccordancedetail").StartsAt(426);

            modelBuilder.HasSequence<int>("gen_colorgroup").StartsAt(1019);

            modelBuilder.HasSequence<int>("gen_colorgroupcustom").StartsAt(79);

            modelBuilder.HasSequence<int>("gen_colorgroupprice").StartsAt(973);

            modelBuilder.HasSequence<int>("gen_colorgrouppriceitem").StartsAt(8722);

            modelBuilder.HasSequence<int>("gen_commongroupgrant").StartsAt(1861);

            modelBuilder.HasSequence<int>("gen_connection").StartsAt(2721);

            modelBuilder.HasSequence<int>("gen_connectortype").StartsAt(15);

            modelBuilder.HasSequence<int>("gen_constructiontype").StartsAt(54);

            modelBuilder.HasSequence<int>("gen_constructiontypedetail").StartsAt(37952);

            modelBuilder.HasSequence<int>("gen_customer").StartsAt(50795);

            modelBuilder.HasSequence<int>("gen_customeraccount");

            modelBuilder.HasSequence<int>("gen_customeraddress");

            modelBuilder.HasSequence<int>("gen_customeragreement").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_customercategory");

            modelBuilder.HasSequence<int>("gen_customerclaim");

            modelBuilder.HasSequence<int>("gen_customerdestanation");

            modelBuilder.HasSequence<int>("gen_customerdiraction");

            modelBuilder.HasSequence<int>("gen_customerdiscard");

            modelBuilder.HasSequence<int>("gen_customerevent");

            modelBuilder.HasSequence<int>("gen_customerfile");

            modelBuilder.HasSequence<int>("gen_customerform");

            modelBuilder.HasSequence<int>("gen_customergroup").StartsAt(22);

            modelBuilder.HasSequence<int>("gen_customergroupgrant");

            modelBuilder.HasSequence<int>("gen_customerpeople");

            modelBuilder.HasSequence<int>("gen_customerplan");

            modelBuilder.HasSequence<int>("gen_customerpricechange");

            modelBuilder.HasSequence<int>("gen_customerpricechangehistory");

            modelBuilder.HasSequence<int>("gen_customerpricepolicy");

            modelBuilder.HasSequence<int>("gen_customerpricepolicyhistory");

            modelBuilder.HasSequence<int>("gen_customerrel");

            modelBuilder.HasSequence<int>("gen_customerrelation");

            modelBuilder.HasSequence<int>("gen_customersign");

            modelBuilder.HasSequence<int>("gen_customertyperel").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_delivdoc");

            modelBuilder.HasSequence<int>("gen_delivdocdiraction");

            modelBuilder.HasSequence<int>("gen_delivdocdiractionpeople");

            modelBuilder.HasSequence<int>("gen_delivdocfile");

            modelBuilder.HasSequence<int>("gen_delivdocgroup").StartsAt(9);

            modelBuilder.HasSequence<int>("gen_delivdocpeople");

            modelBuilder.HasSequence<int>("gen_delivdocpos");

            modelBuilder.HasSequence<int>("gen_delivdocsign");

            modelBuilder.HasSequence<int>("gen_department").StartsAt(182);

            modelBuilder.HasSequence<int>("gen_departmentmember").StartsAt(888);

            modelBuilder.HasSequence<int>("gen_designerevent").StartsAt(14);

            modelBuilder.HasSequence<int>("gen_destanation").StartsAt(149);

            modelBuilder.HasSequence<int>("gen_destanationcustomer");

            modelBuilder.HasSequence<int>("gen_destanationroute").StartsAt(269);

            modelBuilder.HasSequence<int>("gen_destanationseller").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_diraction").StartsAt(100);

            modelBuilder.HasSequence<int>("gen_diractiongrant").StartsAt(208);

            modelBuilder.HasSequence<int>("gen_diractiongroup").StartsAt(6);

            modelBuilder.HasSequence<int>("gen_discard").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_discardgroup").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_docappearance").StartsAt(18);

            modelBuilder.HasSequence<int>("gen_docgroupgrant").StartsAt(843);

            modelBuilder.HasSequence<int>("gen_doclock").StartsAt(7692);

            modelBuilder.HasSequence<int>("gen_docoper").StartsAt(129);

            modelBuilder.HasSequence<int>("gen_docopergrant").StartsAt(857);

            modelBuilder.HasSequence<int>("gen_docrelation").StartsAt(74);

            modelBuilder.HasSequence<int>("gen_docscript").StartsAt(695);

            modelBuilder.HasSequence<int>("gen_docscriptgrant").StartsAt(1018);

            modelBuilder.HasSequence<int>("gen_docscriptgroup").StartsAt(24);

            modelBuilder.HasSequence<int>("gen_docstate").StartsAt(82);

            modelBuilder.HasSequence<int>("gen_docwork").StartsAt(418112);

            modelBuilder.HasSequence<int>("gen_docworkpeople").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_embrasuretype");

            modelBuilder.HasSequence<int>("gen_embrasuretypegroup");

            modelBuilder.HasSequence<int>("gen_equipment");

            modelBuilder.HasSequence<int>("gen_equipmentdoc");

            modelBuilder.HasSequence<int>("gen_equipmentdocfile");

            modelBuilder.HasSequence<int>("gen_equipmentglass");

            modelBuilder.HasSequence<int>("gen_equipmentgroup");

            modelBuilder.HasSequence<int>("gen_equipmentper");

            modelBuilder.HasSequence<int>("gen_equipmentprofile");

            modelBuilder.HasSequence<int>("gen_equipmentprofilein");

            modelBuilder.HasSequence<int>("gen_equipmentprofileout");

            modelBuilder.HasSequence<int>("gen_error").StartsAt(158);

            modelBuilder.HasSequence<int>("gen_errorgroup").StartsAt(15);

            modelBuilder.HasSequence<int>("gen_errortype").StartsAt(6);

            modelBuilder.HasSequence<int>("gen_files").StartsAt(59);

            modelBuilder.HasSequence<int>("gen_finparam").StartsAt(185);

            modelBuilder.HasSequence<int>("gen_finparamcalc").StartsAt(1651462);

            modelBuilder.HasSequence<int>("gen_finparamgroup").StartsAt(11);

            modelBuilder.HasSequence<int>("gen_ganttchart").StartsAt(10);

            modelBuilder.HasSequence<int>("gen_glass").StartsAt(539);

            modelBuilder.HasSequence<int>("gen_glassdetail").StartsAt(1802);

            modelBuilder.HasSequence<int>("gen_glasselement").StartsAt(279);

            modelBuilder.HasSequence<int>("gen_glasselementgroup").StartsAt(10);

            modelBuilder.HasSequence<int>("gen_glassgroup").StartsAt(63);

            modelBuilder.HasSequence<int>("gen_good").StartsAt(24309);

            modelBuilder.HasSequence<int>("gen_goodanalog").StartsAt(1302);

            modelBuilder.HasSequence<int>("gen_goodanalogdetail").StartsAt(1379);

            modelBuilder.HasSequence<int>("gen_goodanaloggroup").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_goodbuffer").StartsAt(327);

            modelBuilder.HasSequence<int>("gen_goodcolorgroupprice").StartsAt(14995);

            modelBuilder.HasSequence<int>("gen_goodcolorparam").StartsAt(94);

            modelBuilder.HasSequence<int>("gen_goodgroup").StartsAt(1846);

            modelBuilder.HasSequence<int>("gen_goodkit");

            modelBuilder.HasSequence<int>("gen_goodkitdetail");

            modelBuilder.HasSequence<int>("gen_goodkitgroup");

            modelBuilder.HasSequence<int>("gen_goodmeasure").StartsAt(4317);

            modelBuilder.HasSequence<int>("gen_goodoptim").StartsAt(30);

            modelBuilder.HasSequence<int>("gen_goodost");

            modelBuilder.HasSequence<int>("gen_goodparam").StartsAt(5946);

            modelBuilder.HasSequence<int>("gen_goodparamname").StartsAt(37);

            modelBuilder.HasSequence<int>("gen_goodprice").StartsAt(3430);

            modelBuilder.HasSequence<int>("gen_goodpricegroup");

            modelBuilder.HasSequence<int>("gen_goodpricehistory").StartsAt(11561);

            modelBuilder.HasSequence<int>("gen_goodservice").StartsAt(12);

            modelBuilder.HasSequence<int>("gen_goodservicegroup").StartsAt(9);

            modelBuilder.HasSequence<int>("gen_goodtype").StartsAt(51);

            modelBuilder.HasSequence<int>("gen_insertion").StartsAt(1220);

            modelBuilder.HasSequence<int>("gen_insertiondetail").StartsAt(4037);

            modelBuilder.HasSequence<int>("gen_insertionparam").StartsAt(1227);

            modelBuilder.HasSequence<int>("gen_insertionparamdetail").StartsAt(9772);

            modelBuilder.HasSequence<int>("gen_installdoc").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_installdocdiraction");

            modelBuilder.HasSequence<int>("gen_installdocdiractionpeople");

            modelBuilder.HasSequence<int>("gen_installdocfile");

            modelBuilder.HasSequence<int>("gen_installdocgoodservice");

            modelBuilder.HasSequence<int>("gen_installdocgroup").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_installdocpos");

            modelBuilder.HasSequence<int>("gen_installdocsign");

            modelBuilder.HasSequence<int>("gen_localizedstring");

            modelBuilder.HasSequence<int>("gen_mailinglist").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_mailinglistondemand");

            modelBuilder.HasSequence<int>("gen_mailinglistsettings").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_mailinglistusers").StartsAt(9);

            modelBuilder.HasSequence<int>("gen_manufactdiraction");

            modelBuilder.HasSequence<int>("gen_manufactdiractionpeople");

            modelBuilder.HasSequence<int>("gen_manufactdoc").StartsAt(227);

            modelBuilder.HasSequence<int>("gen_manufactdoccar");

            modelBuilder.HasSequence<int>("gen_manufactdocgoodin");

            modelBuilder.HasSequence<int>("gen_manufactdocgroup").StartsAt(58);

            modelBuilder.HasSequence<int>("gen_manufactdocnopyramid").StartsAt(25);

            modelBuilder.HasSequence<int>("gen_manufactdocorder").StartsAt(9);

            modelBuilder.HasSequence<int>("gen_manufactdocpos").StartsAt(769);

            modelBuilder.HasSequence<int>("gen_manufactdocpyramid");

            modelBuilder.HasSequence<int>("gen_manufactdocpyramidpos");

            modelBuilder.HasSequence<int>("gen_manufactdocsign").StartsAt(22);

            modelBuilder.HasSequence<int>("gen_markingfilter");

            modelBuilder.HasSequence<int>("gen_markingfilterdetail");

            modelBuilder.HasSequence<int>("gen_measure").StartsAt(34);

            modelBuilder.HasSequence<int>("gen_messages");

            modelBuilder.HasSequence<int>("gen_messagetype").StartsAt(8);

            modelBuilder.HasSequence<int>("gen_model").StartsAt(138964);

            modelBuilder.HasSequence<int>("gen_modelcalc").StartsAt(1091248);

            modelBuilder.HasSequence<int>("gen_modelparam").StartsAt(490);

            modelBuilder.HasSequence<int>("gen_modelparamcalc").StartsAt(1424888);

            modelBuilder.HasSequence<int>("gen_modelparamcondition").StartsAt(2247);

            modelBuilder.HasSequence<int>("gen_modelparamconditiondetail").StartsAt(620);

            modelBuilder.HasSequence<int>("gen_modelparamgroup").StartsAt(32);

            modelBuilder.HasSequence<int>("gen_modelparamvalue").StartsAt(1837);

            modelBuilder.HasSequence<int>("gen_modelpart").StartsAt(39);

            modelBuilder.HasSequence<int>("gen_modelpic").StartsAt(144487);

            modelBuilder.HasSequence<int>("gen_modelscript").StartsAt(78);

            modelBuilder.HasSequence<int>("gen_nopaper");

            modelBuilder.HasSequence<int>("gen_optimdoc").StartsAt(84);

            modelBuilder.HasSequence<int>("gen_optimdocdiraction");

            modelBuilder.HasSequence<int>("gen_optimdocdiractionpeople");

            modelBuilder.HasSequence<int>("gen_optimdocgoodin").StartsAt(1431);

            modelBuilder.HasSequence<int>("gen_optimdocgoodout").StartsAt(575);

            modelBuilder.HasSequence<int>("gen_optimdocgroup").StartsAt(20);

            modelBuilder.HasSequence<int>("gen_optimdocpic").StartsAt(2359);

            modelBuilder.HasSequence<int>("gen_optimdocpos").StartsAt(9050);

            modelBuilder.HasSequence<int>("gen_optimdocsign");

            modelBuilder.HasSequence<int>("gen_orderbudget");

            modelBuilder.HasSequence<int>("gen_orderdiraction").StartsAt(1818);

            modelBuilder.HasSequence<int>("gen_orderdiractionpeople");

            modelBuilder.HasSequence<int>("gen_ordererror").StartsAt(87921);

            modelBuilder.HasSequence<int>("gen_orderevent").StartsAt(338);

            modelBuilder.HasSequence<int>("gen_ordereventgroup").StartsAt(17);

            modelBuilder.HasSequence<int>("gen_orderfile");

            modelBuilder.HasSequence<int>("gen_ordergood");

            modelBuilder.HasSequence<int>("gen_ordergoodservice");

            modelBuilder.HasSequence<int>("gen_orderitem").StartsAt(127244);

            modelBuilder.HasSequence<int>("gen_orderpricechange").StartsAt(3024);

            modelBuilder.HasSequence<int>("gen_orders").StartsAt(1969);

            modelBuilder.HasSequence<int>("gen_ordersetting");

            modelBuilder.HasSequence<int>("gen_ordersgroup").StartsAt(119);

            modelBuilder.HasSequence<int>("gen_ordersign").StartsAt(3161);

            modelBuilder.HasSequence<int>("gen_paymentdoc").StartsAt(90);

            modelBuilder.HasSequence<int>("gen_paymentdocgroup").StartsAt(33);

            modelBuilder.HasSequence<int>("gen_paymentdocsign");

            modelBuilder.HasSequence<int>("gen_paymentgroup").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_people").StartsAt(536);

            modelBuilder.HasSequence<int>("gen_peopledate").StartsAt(92);

            modelBuilder.HasSequence<int>("gen_peopledatetime").StartsAt(168);

            modelBuilder.HasSequence<int>("gen_peoplegroup").StartsAt(209);

            modelBuilder.HasSequence<int>("gen_peoplegrouplist").StartsAt(1011);

            modelBuilder.HasSequence<int>("gen_peopleparam");

            modelBuilder.HasSequence<int>("gen_peopleparamtype").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_peoplepost").StartsAt(41);

            modelBuilder.HasSequence<int>("gen_peoplepostgroup").StartsAt(10);

            modelBuilder.HasSequence<int>("gen_pf_glass").StartsAt(24);

            modelBuilder.HasSequence<int>("gen_pf_glass_ct_source").StartsAt(197);

            modelBuilder.HasSequence<int>("gen_pf_glass_source_ge").StartsAt(34);

            modelBuilder.HasSequence<int>("gen_pf_glass_source_glass").StartsAt(392);

            modelBuilder.HasSequence<int>("gen_pf_ms").StartsAt(17);

            modelBuilder.HasSequence<int>("gen_pf_ms_ct_source").StartsAt(21);

            modelBuilder.HasSequence<int>("gen_pf_ms_mp_filtr").StartsAt(41);

            modelBuilder.HasSequence<int>("gen_pf_ms_mp_set");

            modelBuilder.HasSequence<int>("gen_pf_pt").StartsAt(182);

            modelBuilder.HasSequence<int>("gen_pf_pt_ct_source").StartsAt(3438);

            modelBuilder.HasSequence<int>("gen_pf_pt_mp_filtr");

            modelBuilder.HasSequence<int>("gen_pf_pt_mp_set");

            modelBuilder.HasSequence<int>("gen_pf_stv").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_pf_stv_ct_source").StartsAt(20);

            modelBuilder.HasSequence<int>("gen_pf_stv_mp");

            modelBuilder.HasSequence<int>("gen_picture").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_poll").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_pollanswer").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_pollexecuting");

            modelBuilder.HasSequence<int>("gen_pollexecutingdiraction");

            modelBuilder.HasSequence<int>("gen_pollexecutinggroup").StartsAt(7);

            modelBuilder.HasSequence<int>("gen_pollexecutingitem");

            modelBuilder.HasSequence<int>("gen_pollexecutingitemanswer");

            modelBuilder.HasSequence<int>("gen_pollexecutingsign");

            modelBuilder.HasSequence<int>("gen_pollgroup").StartsAt(208);

            modelBuilder.HasSequence<int>("gen_pollquestion").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_pollrelation").StartsAt(6);

            modelBuilder.HasSequence<int>("gen_power").StartsAt(133);

            modelBuilder.HasSequence<int>("gen_powergrant").StartsAt(77);

            modelBuilder.HasSequence<int>("gen_powerplan").StartsAt(60059);

            modelBuilder.HasSequence<int>("gen_powerrel").StartsAt(70);

            modelBuilder.HasSequence<int>("gen_preference").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_pricechange").StartsAt(46);

            modelBuilder.HasSequence<int>("gen_pricechangegrant").StartsAt(90);

            modelBuilder.HasSequence<int>("gen_pricechangegroup").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_pricelist").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_pricelisterror");

            modelBuilder.HasSequence<int>("gen_pricelistgoodservice");

            modelBuilder.HasSequence<int>("gen_pricelistgroup").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_pricelistitem");

            modelBuilder.HasSequence<int>("gen_pricelistmodel");

            modelBuilder.HasSequence<int>("gen_pricelistpricechange");

            modelBuilder.HasSequence<int>("gen_productiondoc").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_productiondocgroup").StartsAt(7);

            modelBuilder.HasSequence<int>("gen_productiondocpos");

            modelBuilder.HasSequence<int>("gen_productiondocsign");

            modelBuilder.HasSequence<int>("gen_productionsite").StartsAt(6);

            modelBuilder.HasSequence<int>("gen_productiontype").StartsAt(616);

            modelBuilder.HasSequence<int>("gen_productiontypeconstruction").StartsAt(223);

            modelBuilder.HasSequence<int>("gen_productiontypegrant").StartsAt(1336);

            modelBuilder.HasSequence<int>("gen_productiontypegroup").StartsAt(119);

            modelBuilder.HasSequence<int>("gen_productiontypeparam").StartsAt(470);

            modelBuilder.HasSequence<int>("gen_productiontypesetting").StartsAt(133);

            modelBuilder.HasSequence<int>("gen_productiontypesystems").StartsAt(540);

            modelBuilder.HasSequence<int>("gen_productiontypetemplate").StartsAt(387);

            modelBuilder.HasSequence<int>("gen_pyramid").StartsAt(76);

            modelBuilder.HasSequence<int>("gen_pyramidfact");

            modelBuilder.HasSequence<int>("gen_pyramidfactpos");

            modelBuilder.HasSequence<int>("gen_report").StartsAt(432);

            modelBuilder.HasSequence<int>("gen_reportdocoper").StartsAt(7163);

            modelBuilder.HasSequence<int>("gen_reportgroup").StartsAt(42);

            modelBuilder.HasSequence<int>("gen_reportkit").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_reportkitdetail").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_reportsave");

            modelBuilder.HasSequence<int>("gen_reportscript").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_respower").StartsAt(2008);

            modelBuilder.HasSequence<int>("gen_revisiongp").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_revisiongpitem");

            modelBuilder.HasSequence<int>("gen_rotoxflugel");

            modelBuilder.HasSequence<int>("gen_rotoxhouse");

            modelBuilder.HasSequence<int>("gen_route").StartsAt(101);

            modelBuilder.HasSequence<int>("gen_seller").StartsAt(1063);

            modelBuilder.HasSequence<int>("gen_sellerdestanation").StartsAt(4);

            modelBuilder.HasSequence<int>("gen_sellergrant").StartsAt(2915);

            modelBuilder.HasSequence<int>("gen_sellergroup").StartsAt(5);

            modelBuilder.HasSequence<int>("gen_sellerpricechange").StartsAt(5557);

            modelBuilder.HasSequence<int>("gen_servicedepartment").StartsAt(10);

            modelBuilder.HasSequence<int>("gen_servicedepartmentpeople");

            modelBuilder.HasSequence<int>("gen_servicedoc").StartsAt(15);

            modelBuilder.HasSequence<int>("gen_servicedocdiraction").StartsAt(12);

            modelBuilder.HasSequence<int>("gen_servicedocgroup").StartsAt(21);

            modelBuilder.HasSequence<int>("gen_servicedocpos").StartsAt(5);

            modelBuilder.HasSequence<int>("gen_servicedocsign").StartsAt(13);

            modelBuilder.HasSequence<int>("gen_servicereason").StartsAt(28);

            modelBuilder.HasSequence<int>("gen_setting").StartsAt(444);

            modelBuilder.HasSequence<int>("gen_settinggroup").StartsAt(36);

            modelBuilder.HasSequence<int>("gen_shtapikgroup").StartsAt(78);

            modelBuilder.HasSequence<int>("gen_shtapikgroupdetail").StartsAt(535);

            modelBuilder.HasSequence<int>("gen_shtapikgroupparamdetail").StartsAt(1393);

            modelBuilder.HasSequence<int>("gen_shtapikgroupprofile").StartsAt(569);

            modelBuilder.HasSequence<int>("gen_sign").StartsAt(119);

            modelBuilder.HasSequence<int>("gen_signgrant").StartsAt(4121);

            modelBuilder.HasSequence<int>("gen_signgroup").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_signvalue").StartsAt(1199);

            modelBuilder.HasSequence<int>("gen_sizedoc").StartsAt(11);

            modelBuilder.HasSequence<int>("gen_sizedocconstrtype").StartsAt(5);

            modelBuilder.HasSequence<int>("gen_sizedocdiraction").StartsAt(8);

            modelBuilder.HasSequence<int>("gen_sizedocdiractionpeople");

            modelBuilder.HasSequence<int>("gen_sizedocfile");

            modelBuilder.HasSequence<int>("gen_sizedocgroup").StartsAt(3);

            modelBuilder.HasSequence<int>("gen_sizedocsign").StartsAt(10);

            modelBuilder.HasSequence<int>("gen_sourceinfo");

            modelBuilder.HasSequence<int>("gen_sourceinfogroup");

            modelBuilder.HasSequence<int>("gen_storagespace").StartsAt(311);

            modelBuilder.HasSequence<int>("gen_storedepart").StartsAt(146);

            modelBuilder.HasSequence<int>("gen_storedepartdocoper").StartsAt(48);

            modelBuilder.HasSequence<int>("gen_storedepartrel").StartsAt(31);

            modelBuilder.HasSequence<int>("gen_storedoc").StartsAt(281);

            modelBuilder.HasSequence<int>("gen_storedocgroup").StartsAt(30);

            modelBuilder.HasSequence<int>("gen_storedocpos").StartsAt(8592);

            modelBuilder.HasSequence<int>("gen_storedocsign");

            modelBuilder.HasSequence<int>("gen_supplydoc").StartsAt(31);

            modelBuilder.HasSequence<int>("gen_supplydocdiraction");

            modelBuilder.HasSequence<int>("gen_supplydocgoodservice");

            modelBuilder.HasSequence<int>("gen_supplydocgroup").StartsAt(27);

            modelBuilder.HasSequence<int>("gen_supplydocpos").StartsAt(111);

            modelBuilder.HasSequence<int>("gen_supplydocsign");

            modelBuilder.HasSequence<int>("gen_sysconnect");

            modelBuilder.HasSequence<int>("gen_sysinfo");

            modelBuilder.HasSequence<int>("gen_system").StartsAt(82);

            modelBuilder.HasSequence<int>("gen_systemdetail").StartsAt(1307);

            modelBuilder.HasSequence<int>("gen_systemdetailrel");

            modelBuilder.HasSequence<int>("gen_systemdetailrelationship");

            modelBuilder.HasSequence<int>("gen_sysupdate").StartsAt(840);

            modelBuilder.HasSequence<int>("gen_tariff").StartsAt(5);

            modelBuilder.HasSequence<int>("gen_techdoc");

            modelBuilder.HasSequence<int>("gen_techdocdiraction");

            modelBuilder.HasSequence<int>("gen_techdocgroup");

            modelBuilder.HasSequence<int>("gen_techdocpos");

            modelBuilder.HasSequence<int>("gen_techdocsign");

            modelBuilder.HasSequence<int>("gen_template").StartsAt(6);

            modelBuilder.HasSequence<int>("gen_templategroup").StartsAt(2);

            modelBuilder.HasSequence<int>("gen_templateparam");

            modelBuilder.HasSequence<int>("gen_trash");

            modelBuilder.HasSequence<int>("gen_valut").StartsAt(9);

            modelBuilder.HasSequence<int>("gen_valutrate").StartsAt(5);

            modelBuilder.HasSequence<int>("gen_variant").StartsAt(2286);

            modelBuilder.HasSequence<int>("gen_variantdetail").StartsAt(1991);

            modelBuilder.HasSequence<int>("gen_variantparam").StartsAt(3157);

            modelBuilder.HasSequence<int>("gen_variantparamdetail").StartsAt(3146);

            modelBuilder.HasSequence<int>("gen_variantparamtype").StartsAt(160);

            modelBuilder.HasSequence<int>("gen_variantparamtypevalue").StartsAt(151);

            modelBuilder.HasSequence<int>("gen_varianttype").StartsAt(9);

            modelBuilder.HasSequence<int>("gen_vectorpicture").StartsAt(131);

            modelBuilder.HasSequence<int>("gen_vectorpicturedetail");

            modelBuilder.HasSequence<int>("gen_wdlog").StartsAt(70818);

            modelBuilder.HasSequence<int>("gen_work").StartsAt(135);

            modelBuilder.HasSequence<int>("gen_workgroup").StartsAt(41);

            modelBuilder.HasSequence<int>("gen_workoper").StartsAt(510);

            modelBuilder.HasSequence<int>("gen_workpeople");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
