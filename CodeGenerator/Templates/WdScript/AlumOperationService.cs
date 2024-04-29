using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using Atechnology.DBConnections2;
using Atechnology.winDraw.Model;
using Atechnology.winDraw;
using Atechnology.Components;
using Atechnology.ecad.Document.DataSets;
using Atechnology.ecad.Document.Classes;
using Atechnology.ecad.Dictionary.Classes;
using Atechnology.ecad.Dictionary.DataSets;
using Atechnology.ecad.Dictionary;
using System.Xml;
using AtLog = Atechnology.Logging.Impl.Log;
using System.Linq;
using Newtonsoft.Json;
using Atechnology.ecad.Calc;
using Atechnology.ecad;
using System.Data.Common;
using Newtonsoft.Json.Linq;

namespace CalcAlumOperation
{
    public class aRegion
    {
        public bool first = false;
        public int idx;
        public int kind; // 0: Заполнение, 1: Створка, 2: Встройка
        public int length;
        public double length_double;
        public int startcoord;
        public int endcoord;
        public double startcoord_double;
        public double endcoord_double;

        public string side;

        public ModelPartClass mpc;
    }

    public class AlumOperationService
    {
        #region Variables

        public Atechnology.DBConnections2.dbconn db;
        OrderClass Order;
        ds_order.orderitemRow drOI;
        string dist = "";
        ds_productiontype.productiontypeRow drPT;
        string sLog = "Скрипт Расчета координат закладных деталей алюминия: ";
        Construction model;
        Construction Model;

        DataTable t_alu_dobor { get; set; }
        DataTable t_alu_dobor_rama;
        DataTable dtInsForCalcOuter;
        DataTable dtshgForCalcOuter;
        DataTable dtMaterial;

        List<Impost> lstConImpDisassembled = new List<Impost>();
        List<Impost> lstConImpAssembled = new List<Impost>();
        List<Glass> lstConRegDisassembled = new List<Glass>();
        List<Glass> lstConRegAssembled = new List<Glass>();
        List<RamaItem> lstConFrameBeemAssembled = new List<RamaItem>();
        List<RamaItem> lstConFrameBeemDisassembled = new List<RamaItem>();
        List<StvorkaItem> lstConStvorkaBeemAssembled = new List<StvorkaItem>();

        public int thickOporPlast = 0;
        #endregion

        public AlumOperationService()
        {


        }

        public string mpcAsXML(ModelPartClass mpc)
        {
            return Storage.Serializer.Serialize(mpc);
        }

        public void RunCalcOperations(dbconn _db, DataRow dr, Construction model)
        {
            db = _db;
            DataSet ds = dr.Table.DataSet;
            Order = dr.Table.DataSet.ExtendedProperties["DocClass"] as OrderClass;
            drOI = (ds_order.orderitemRow)dr;
            //ds_productiontype.productiontypeRow drPT = ProductionTypeClass.GetProductionType(drOI.idproductiontype);
            
            // if( Atechnology.ecad.Settings.idpeople == 168 ) return;
            Model = model;
            string Err = "1";
            try
            {
                
                t_alu_dobor = new DataTable(); t_alu_dobor_rama = new DataTable();
                t_alu_dobor = CalcProcessor.Modules["GetTable"](new object[] { "aludobor" })[0] as DataTable;
                t_alu_dobor_rama = CalcProcessor.Modules["GetTable"](new object[] { "aludobor_rama" })[0] as DataTable;
                dtInsForCalcOuter = CalcProcessor.Modules["GetTable"](new object[] { "insertionForCalcOuter" })[0] as DataTable;
                dtshgForCalcOuter = CalcProcessor.Modules["GetTable"](new object[] { "shtapikGroupForCalcOuter" })[0] as DataTable;

                if (drOI.IsidproductiontypeNull())
                    return;
                //if(model == null) return;
                if(model != null) if(!drOI.IsidpowerNull()) if(drOI.idpower == 52) StartStopExecutionTimeCounter(true, "idorder: " + drOI.idorder + " idorderitem: " + drOI.idorderitem + " idpeople: " + Atechnology.ecad.Settings.idpeople);
                string dtLogs = "start script " + DateTime.Now.ToString("HH:mm:ss:fff");
                ds_order.orderitemRow rootProduction = getRootProduction(drOI);
                Err = "1_01";
                //Для расчета стыка на створку
                if (model != null)
                {
                    CalcProvedalStik(model);
                }

                if (model != null && !string.IsNullOrEmpty(GetErrForRackLen(model)))
                {
                    Order.AddErrorUnical(drOI.idorderitem, "и589", "", GetErrForRackLen(model));
                }

                bool err = false;
                if (model != null && model.ImpostList.Count > 0
                    && model.ProfileSystem.ToLower().Contains("prove"))
                {
                    //MessageBox.Show(model.Name);
                    foreach (Impost i in model.ImpostList)
                    {
                        Err = "pr.1";
                        if (string.IsNullOrEmpty(i.Variants))
                        {
                            err = true;
                            if (err)
                            {
                                Err = "pr.2";
                                Order.AddErrorUnical(drOI.idorderitem, "о002", "", "Не удалось определить соединение импоста " + i.Marking + "!!!");
                                Err = "pr.3";
                            }
                            break;
                        }
                    }
                    
                }


                
                Err = "1_02";
                if (/*Atechnology.ecad.Settings.idpeople == 2214 
					|| Atechnology.ecad.Settings.idpeople == 3410
					|| Atechnology.ecad.Settings.idpeople == 7228
					&&*/ model != null)
                {
                    dtLogs += "\nbefore city_calcKozToImp " + DateTime.Now.ToString("HH:mm:ss:fff");
                    Err = "1_02_001";
                    CITY_CalcKozToImp(model, drOI);
                    dtLogs += "\nafter city_calcKozToImp " + DateTime.Now.ToString("HH:mm:ss:fff");
                    Err = "1_02_002";
                    CalcProvedalUpl20(model, drOI);
                    dtLogs += "\nafter calcProvedalUpl20 " + DateTime.Now.ToString("HH:mm:ss:fff");
                    Err = "1_02_003";
                    CalcXCrossCity(model, drOI, ref Err);
                    dtLogs += "\nafter calcXCrossCity " + DateTime.Now.ToString("HH:mm:ss:fff");
                    Err = "1_02_004";
                    CalcCityAdapter(model, drOI);
                    dtLogs += "\nafter calcCityAdapter " + DateTime.Now.ToString("HH:mm:ss:fff");
                    Err = "1_02_005";
                    CalcCityUpl(model, drOI);
                    dtLogs += "\nafter calcCityUpl " + DateTime.Now.ToString("HH:mm:ss:fff");
                    Err = "1_02_006";
                    CalcTatUpl(model, drOI);
                    CalcTatUpl2(model, drOI);
                    dtLogs += "\nafter calcProvedalUpl20 " + DateTime.Now.ToString("HH:mm:ss:fff");
                    Err = "1_02_007";
                    CalcMP640RaspMaterials(model, drOI);
                    dtLogs += "\nafter calcMP640RaspMat " + DateTime.Now.ToString("HH:mm:ss:fff");
                    Err = "1_02_008";
                    CalcMP640RazdMaterials(model, drOI);
                    dtLogs += "\nafter calcMP640RazdMat " + DateTime.Now.ToString("HH:mm:ss:fff");
                    Err = "1_02_009";
                    if (Atechnology.ecad.Settings.idpeople == 2214
                        || Atechnology.ecad.Settings.idpeople == 3410
                        || Atechnology.ecad.Settings.idpeople == 889)
                    {
                        List<MyOper> lstMO = new List<MyOper>();
                        MyOper mo = new MyOper();
                        mo.Qu = 1;
                        mo.Marking = "123";
                        lstMO.Add(mo);
                        mo.Qu = 2;
                        mo.Marking = "222123";
                        lstMO.Add(mo);

                        Operation oppp = new Operation(lstMO, 9999, "lstMO");
                        Model.Rama[0].OperationList.Add(oppp);
                    }
                    //					CalcTPT72PS_Details(model,drOI);

                    //if(Atechnology.ecad.Settings.idpeople == 1896)
                    AddMaterialFromCustomTableCity(model, drOI);

                    if (Atechnology.ecad.Settings.idpeople == 7228
                        || Atechnology.ecad.Settings.idpeople == 3404)
                    {
                        AddMaterialFromCustomTableSokol(model, drOI);
                    }
                    dtLogs += "\nafter addMatsFromCustomTableCity " + DateTime.Now.ToString("HH:mm:ss:fff");
                }

                //if (inRange(Atechnology.ecad.Settings.idpeople,434, 3302))
                //{
                CheckCastomAlum(model, drOI);
                //}

                if (model != null && (model.ProfileSystem == "Татпроф МП-45"))
                {
                    CalcZaklMP45(model, drOI);
                    CalcAdapterMP45(model, drOI);
                    CalcTorcMP45(model, drOI);
                }

                if (model != null && (model.ProfileSystem == "Татпроф ТПТ-72ПС"))
                {
                    CalcTPT72PS_Details(model, drOI);
                }

                if (model != null && (model.ProfileSystem == "Inicial IF50 R2R" || model.ProfileSystem == "Inicial IF50 RR"))
                {
                    Err = "1_02_01";
                    #region Материалы для выносов
                    int maxThick = model.DefaultFillThikness;
                    int shg = 0;
                    foreach (Glass g in model.GlassList)
                    {
                        Err = "1_02_02";
                        //Предположим, что ShtapicGroup всегда одинаковый
                        if (Atechnology.ecad.Settings.idpeople == 2214)
                        {

                            foreach (GlassItem gi in g)
                            {
                                if (!string.IsNullOrEmpty(gi.ShtapikGroup))
                                {
                                    shg = Convert.ToInt32(gi.ShtapikGroup.Split(';')[0]);
                                }
                            }
                        }
                        if (g.Thickness > maxThick)
                        {
                            maxThick = g.Thickness;
                        }
                    }
                    Err = "1_02_03";
                    string strForSearchIns = maxThick.ToString() + " мм рама";
                    string strForSearchInsImp = maxThick.ToString() + " мм импост";
                    string strForParam = model.GetUserParam("Теплотехническая характеристика").StrValue;
                    double outerLen = 0;
                    int quOuter = 0;
                    string riInsertions = "";
                    foreach (RamaItem ri in model.Rama)
                    {
                        if (ri.Outer1 != 0 || ri.Outer2 != 0)
                        {
                            if (ri.Outer1 != 0)
                            {
                                riInsertions = ri.Insertions.Replace(";", ",").TrimEnd(',');
                                outerLen = ri.Outer1 > 0 ? ri.Outer1 : ri.Outer2;
                                CalcGoodsForOuter((int)outerLen, drOI, strForSearchIns, strForParam, riInsertions);
                            }
                            if (ri.Outer2 != 0)
                            {
                                riInsertions = ri.Insertions.Replace(";", ",").TrimEnd(',');
                                outerLen = ri.Outer1 > 0 ? ri.Outer1 : ri.Outer2;
                                CalcGoodsForOuter((int)outerLen, drOI, strForSearchIns, strForParam, riInsertions);
                            }
                        }

                    }
                    dtLogs += "\nafter CalcGoodsForOuter " + DateTime.Now.ToString("HH:mm:ss:fff");
                    foreach (Impost i in model.ImpostList)
                    {
                        if (i.Outer1 != 0 || i.Outer2 != 0)
                        {
                            if (i.Outer1 != 0)
                            {
                                riInsertions = i.Insertions.Replace(";", ",").TrimEnd(',');
                                outerLen = i.Outer1;
                                //CalcGoodsForOuter((int)outerLen,drOI,strForSearchInsImp,strForParam,riInsertions);
                                if (dist != "")
                                {
                                    drOI.AddModelcalc(dist, 2.0m, (int)outerLen, 0, 0, 0, 0);
                                }
                            }
                            if (i.Outer2 != 0)
                            {
                                riInsertions = i.Insertions.Replace(";", ",").TrimEnd(',');
                                outerLen = i.Outer2;
                                //CalcGoodsForOuter((int)outerLen,drOI,strForSearchInsImp,strForParam,riInsertions);
                                if (dist != "")
                                {
                                    drOI.AddModelcalc(dist, 2.0m, (int)outerLen, 0, 0, 0, 0);
                                }
                            }
                        }
                    }

                    dtLogs += "\nafter add Dist modelcalc on imp " + DateTime.Now.ToString("HH:mm:ss:fff");
                    foreach (RamaItem ri in model.Rama)
                    {
                        if (ri.Outer1 != 0 || ri.Outer2 != 0)
                        {
                            //							riInsertions = ri.Insertions.Replace(";",",").TrimEnd(',');
                            //							outerLen = ri.Outer1 > 0 ? ri.Outer1 : ri.Outer2;
                            //							CalcGoodsForOuter((int)outerLen,drOI,strForSearchIns,strForParam,riInsertions);
                        }
                        else
                        {
                            if (ri.AngNakl == 90 || ri.AngNakl == 270)
                            {
                                riInsertions = ri.Insertions.Replace(";", ",").TrimEnd(',');
                                //Так как у импоста может не быть Outer1 (Outer2), 
                                //из-за того, что задан выступ у горизонтальной балки рамы, 
                                //то будем определять по косвенным признакам
                                foreach (Impost i in model.ImpostList)
                                {
                                    if (i.Outer1 != 0 || i.Outer2 != 0)
                                    {
                                        outerLen = i.Outer1 > 0 ? i.Outer1 : i.Outer2;
                                    }
                                    else if (i.IsRack && (i.AngNakl == 90 || i.AngNakl == 270) && ((i.Outer1 != 0 || i.Outer2 != 0) && ri.LengthInterfaceCalcInt < i.LengthInterfaceCalcInt))
                                    {
                                        if (i.LengthInterfaceCalc > ri.LengthInterfaceCalc)
                                        {
                                            outerLen = i.LengthInterfaceCalc - ri.LengthInterfaceCalc;
                                            if (outerLen > 0)
                                            {
                                                CalcGoodsForOuter((int)outerLen, drOI, strForSearchIns, strForParam, riInsertions);
                                                CalcUplForOuter(model.ProfileSystem, model.DefaultFillThikness, (int)outerLen);
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    dtLogs += "\nafter calcGoodsForOuter2 " + DateTime.Now.ToString("HH:mm:ss:fff");
                    #endregion Материалы для выносов

                    Err = "1_02_03";
                    #region материалы для тяжелых заполнений
                    //DEV-95218
                    if (1 == 1) //Atechnology.ecad.Settings.idpeople == 434 || Atechnology.ecad.Settings.idpeople == 7228)
                    {
                        //Балки рамы
                        Err = "1_02_03_1";
                        foreach (RamaItem ri in model.Rama)
                        {
                            if (ri.Marking.ToLower().Contains("без"))
                                continue;
                            if (!ri.IsRack) //нужны только стойки
                                continue;
                            if (ri.PartTypeList == null)
                                continue;

                            foreach (ModelPartClass mpc in ri.PartTypeList)
                            {
                                if (mpc == null) continue;
                                CalcGoodByBigWeightSP(ri, mpc, ri.Side == ItemSide.Left, false, drOI);
                            }
                        }
                        //Балки имостов
                        Err = "1_02_03_2";
                        if (model.ImpostList != null)
                        {
                            Dictionary<int, MyMPC> dicMpcByXAll = new Dictionary<int, MyMPC>();
                            foreach (Impost im in model.ImpostList.Where(x => x.IsRack && !x.Marking.ToLower().Contains("без")))
                            {
                                Dictionary<int, MyMPC> dicMpcByX = new Dictionary<int, MyMPC>();
                                //if (im.Marking.ToLower().Contains("без"))
                                //continue;
                                //if (!im.IsRack) //нужны только стойки
                                //continue;

                                if (im.PartTypeList != null)
                                {
                                    foreach (ModelPartClass mpc in im.PartTypeList) // заполнения с лева
                                    {
                                        if (mpc == null) continue;
                                        dicMpcByX.Add(mpc.CoordStart, new MyMPC() { LeftSide = false, OneLevel = false, MPC = mpc });
                                    }
                                }

                                if (im.PartTypeList2 != null)
                                {
                                    foreach (ModelPartClass mpc in im.PartTypeList2) // заполнения с право добавляю только те у которых коорднината нижней балки не содержится в справочнике иначе помечаю как соединение в одном уровне с лева и справо
                                    {
                                        if (mpc == null) continue;
                                        MyMPC pos = null;
                                        if (dicMpcByX.TryGetValue(mpc.CoordStart, out pos))
                                        {
                                            //тут нужно брать то заполнение которое больше
                                            Glass gLeft = pos.MPC.Glass;
                                            Glass gRight = mpc.Glass;
                                            if (gLeft == null)
                                            {
                                                if (gRight == null)
                                                    dicMpcByX.Remove(mpc.CoordStart);
                                                else
                                                {
                                                    //прилегает только с право пакет
                                                    dicMpcByX.Remove(mpc.CoordStart);
                                                    dicMpcByX.Add(mpc.CoordStart, new MyMPC() { LeftSide = false, OneLevel = false, MPC = mpc });
                                                }
                                            }
                                            else
                                            {
                                                if (gRight == null)
                                                    // с право пакета нет
                                                    pos.OneLevel = false;
                                                else
                                                {
                                                    //есть и слева и с право пакет
                                                    UserParam upRightGp = gRight.GetUserParam("Вес заполнения");
                                                    UserParam upLeftGp = gLeft.GetUserParam("Вес заполнения");

                                                    if (upRightGp != null && upLeftGp != null && upRightGp.IntValue > upLeftGp.IntValue)
                                                    {
                                                        dicMpcByX.Remove(mpc.CoordStart);
                                                        dicMpcByX.Add(mpc.CoordStart, new MyMPC() { LeftSide = false, OneLevel = true, MPC = mpc });
                                                    }
                                                    else
                                                        pos.OneLevel = true; // пакеты с двух сторон
                                                }

                                            }
                                        }
                                        else
                                            dicMpcByX.Add(mpc.CoordStart, new MyMPC() { LeftSide = false, OneLevel = false, MPC = mpc });

                                    }
                                }

                                foreach (var pos in dicMpcByX)
                                {
                                   CalcGoodByBigWeightSP(im, pos.Value.MPC, pos.Value.LeftSide, pos.Value.OneLevel, drOI);
                                }
                            }
                        }
                        Err = "1_02_03_3";
                        //Повесить ошибки на пакеты:
                        //1) Ошибка! При весе стеклопакета более 135 кг, минимальная толщина заполнения 42 мм
                        //2) Ошибка! Запрещено построение стеклопакета весом более 500 кг
                        if (model.GlassList != null)
                        {
                            foreach (Glass g in model.GlassList)
                            {
                                if (g == null) continue;
                                UserParam up = g.GetUserParam("Вес заполнения");
                                if (up == null)
                                    continue;
                                if (up.IntValue > 500)
                                    Order.AddErrorUnical(drOI.idorderitem, "о1345", g.Part, g.Part + ": весом более 500 кг!");
                                else if (up.IntValue >= 135 && g.Thickness < 42)
                                    Order.AddErrorUnical(drOI.idorderitem, "о1344", g.Part, g.Part + ": толщина заполнения меньше 42 мм при весе более 135 кг!");
                            }
                        }
                        //3)Ошибка! Под стеклопакеты весом более 135 кг использовать минимальный ригель 75 мм 01 02 04-01
                        //4)Ошибка! Под стеклопакеты весом более 200 кг использовать ригели 01 02 06, 01 02 06-01, 01 02 07 или 01 02 08
                        // добавляются в расчете материала выше

                    }
                    #endregion

                    dtLogs += "\nafter calcMat For Heavy insertions " + DateTime.Now.ToString("HH:mm:ss:fff");
                }

                //-- DEV-104084 7889 - проверяем, что вес заполнения в глухой секции не превышает 50 кг 
                if (model != null && inRange(model.ProfileSystem, "Inicial IP45", "Татпроф МП-45"))
                {
                    Err = "1_02_06_CheckFillingWeight";
                    CheckFillingWeight(model, drOI);
                    dtLogs += "\nafter fillingWeight " + DateTime.Now.ToString("HH:mm:ss:fff");
                }


                if (model != null &&
                inRange(model.ProfileSystem, "Inicial IP45", "Inicial IF50 R2R", "Inicial IF50 RR", "Татпроф МП-45", "Татпроф СОКОЛ 40")
                /*&& Atechnology.ecad.Settings.idpeople == 2214*/)
                {
                    Err = "1_02_06";
                    #region Заполняем сбор/разбор
                    DevidedIP45IF50(drOI, model);
                    if (inRange(model.ProfileSystem, "Inicial IP45", "Татпроф МП-45", "Татпроф СОКОЛ 40") && model.ConstructionType.Name == "Перегородка")
                    {
                        Err = "1_02_07";
                        if (model.ProfileSystem == "Inicial IP45") CalcIP45Pritvor(model, drOI);

                        Err = "1_02_08";
                        AddMaterialFromCustomTableIP45(drOI, model);
                        if (inRange(model.ProfileSystem, "Inicial IP45", "Татпроф МП-45", "Татпроф СОКОЛ 40"))//Atechnology.ecad.Settings.idpeople == 2214 || Atechnology.ecad.Settings.idpeople == 1896)
                        {
                            List<Tuple<int, string>> bp = new List<Tuple<int, string>>();

                            #region Получаем разобранные балки
                            if (lstConImpDisassembled.Count > 0)
                            {
                                #region Добавляем импосты в разборе
                                foreach (Balka b in lstConImpDisassembled)
                                {
                                    bp.Add(new Tuple<int, string>(b.ID, b.BalkaType.ToString()));
                                }
                                #endregion Добавляем импосты в разборе
                            }
                            Err = "1_02_09";
                            if (lstConFrameBeemDisassembled.Count > 0)
                            {
                                Err = "1_02_09_01";

                                #region Добавляем рамы в разборе
                                foreach (Balka b in lstConFrameBeemDisassembled)
                                {
                                    if (b != null)
                                        bp.Add(new Tuple<int, string>(b.ID, b.BalkaType.ToString()));
                                }
                                #endregion Добавляем рамы в разборе
                            }
                            Err = "1_02_10";
                            if (lstConRegDisassembled.Count > 0)
                            {
                                bp.Add(new Tuple<int, string>(0, "Shtapik"));
                            }
                            #endregion

                            OrderClass o = Order;
                            Err = "1_02_11";
                            if (!o.ds.ExtendedProperties.Contains("DisDT"))
                            {
                                o.ds.ExtendedProperties.Add("DisDT", bp);
                            }
                            else
                            {
                                o.ds.ExtendedProperties.Remove("DisDT");
                                o.ds.ExtendedProperties.Add("DisDT", bp);
                            }

                            //							if( Atechnology.ecad.Settings.idpeople == 168 ) 
                            //							{
                            //								MessageBox.Show( "A1. " + bp.Count + ", lstConFrameBeemDisassembled.Count=" + lstConFrameBeemDisassembled.Count );
                            //							}
                        }
                    }
                    Err = "1_02_04";
                    if (inRange(model.ProfileSystem, "Inicial IF50 RR", "Inicial IF50 R2R") && model.ConstructionType.Name == "Витраж")
                    {
                        if (true)//Atechnology.ecad.Settings.idpeople == 2214 || Atechnology.ecad.Settings.idpeople == 1896)
                        {
                            List<Tuple<int, string>> bp = new List<Tuple<int, string>>();

                            #region Получаем разобранные балки
                            if (lstConImpDisassembled.Count > 0)
                            {
                                #region Добавляем импосты в разборе
                                foreach (Balka b in lstConImpDisassembled)
                                {
                                    bp.Add(new Tuple<int, string>(b.ID, b.BalkaType.ToString()));
                                }
                                #endregion Добавляем импосты в разборе
                            }

                            if (lstConFrameBeemDisassembled.Count > 0)
                            {
                                #region Добавляем рамы в разборе
                                foreach (Balka b in lstConFrameBeemDisassembled)
                                {
                                    bp.Add(new Tuple<int, string>(b.ID, b.BalkaType.ToString()));
                                }
                                #endregion Добавляем рамы в разборе
                            }

                            if (lstConRegDisassembled.Count > 0)
                            {
                                bp.Add(new Tuple<int, string>(0, "Shtapik"));
                            }
                            #endregion

                            OrderClass o = Order;

                            if (!o.ds.ExtendedProperties.Contains("DisDT"))
                            {
                                o.ds.ExtendedProperties.Add("DisDT", bp);
                            }
                            else
                            {
                                o.ds.ExtendedProperties.Remove("DisDT");
                                o.ds.ExtendedProperties.Add("DisDT", bp);
                            }
                        }
                    }

                    #endregion Заполняем сбор/разбор
                    dtLogs += "\nafter sbor/razbor on Inicial sys " + DateTime.Now.ToString("HH:mm:ss:fff");
                }

                #region Расчет заглушек Татпроф
                if (model != null && (model.ProfileSystem == "Татпроф МП-65" || model.ProfileSystem == "Татпроф МП-45"))
                {
                    CalcZaglMP4565(model, drOI);
                    dtLogs += "\nafter CalcZaglMP4565 " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion Расчет заглушек Татпроф

                if (model != null && model.ProfileSystem == "Сокол МП-640")
                {
                    CalcZaglMp640(model, drOI);
                    dtLogs += "\nafter CalcZaglMp640 " + DateTime.Now.ToString("HH:mm:ss:fff");
                }

                Err = "1_02_04_01";
                #region Расчет декоративной крышки W45.13.04 black системы Tatprof TS 45 NI
                if( !drOI.IsidprofsysNull() && drOI.idprofsys==222 && !drOI.IsidconstructiontypeNull() && drOI.idconstructiontype==2 )
                {
                    /*
                     * if ((ri.AngNakl == 0 || ri.AngNakl == 180)
                        && ri.Side == ItemSide.Bottom && ri.RamaType == RamaType.Rama) // если это нижняя горизонтальная балка
                     */
                    RamaItem ri = model.Rama.Find(x => (x.AngNakl == 0 || x.AngNakl == 180) && x.Side == ItemSide.Bottom && x.RamaType == RamaType.Rama && !x.Marking.ToLower().Contains("без"));
                    if (ri != null)
                    {
                        int cnt_details = 0;
                        if (ri.LengthInterfaceCalcInt <= 400)
                        {
                            cnt_details = 1;
                        }
                        else if(ri.LengthInterfaceCalcInt >= 401 && ri.LengthInterfaceCalcInt <= 900 )
                        {
                            cnt_details = 2;
                        }
                        else if (ri.LengthInterfaceCalcInt >= 901 && ri.LengthInterfaceCalcInt <= 1500)
                        {
                            cnt_details = 3;
                        }
                        else if (ri.LengthInterfaceCalcInt >= 1501 && ri.LengthInterfaceCalcInt <= 2100)
                        {
                            cnt_details = 4;
                        }
                        else if (ri.LengthInterfaceCalcInt >= 2101 && ri.LengthInterfaceCalcInt <= 2700)
                        {
                            cnt_details = 5;
                        }
                        else
                        {
                            cnt_details = 6;
                        }

                        if( cnt_details > 0 )
                        {
                            ds_order.modelcalcRow drMC = drOI.AddModelcalc("W45.13.04 black", cnt_details);

                            drMC.addstr3 = "Н"; drMC.modelpart = "Р-"+(ri.ID+1);
                        }
                    }
                }
                #endregion


                Err = "1_02_05";
                #region Расчет крепежных башмаков и закладных
                if (model != null && (inRange(drOI.idproductiontype, 820, 884, 1644, 1678, 1714)))
                {
                    dtLogs += "\nbefore bashmak and zakl " + DateTime.Now.ToString("HH:mm:ss:fff");
                    string mount_Mode = model.GetUserParam(1247).StrValue; // Наличие крепежных пластин
                    string mount_Mode_IP45 = "";
                    if (model.GetUserParam("Металлические пластины") != null)
                        mount_Mode_IP45 = !model.GetUserParam("Металлические пластины").Visible ? "" : model.GetUserParam("Металлические пластины").StrValue;
                    dtLogs += "\nafter getUserParam " + DateTime.Now.ToString("HH:mm:ss:fff");
                    bool need_Mount = mount_Mode.ToLower() == "да" && inRange(drOI.profsys_name, "Inicial IF50 R2R");
                    bool need_Mount_IP45 = mount_Mode_IP45.ToLower() == "да"
                        //&& drOI.idconstructiontype == 39 
                        && inRange(drOI.profsys_name, "Inicial IP45");
                    dtLogs += "\nbefore RamaItem cycle " + DateTime.Now.ToString("HH:mm:ss:fff");
                    //					MessageBox.Show( "Mounts!" );
                    Err = "2";
                    int mounts_top = 0; int mounts_bottom = 0; int mounts_all = 0;
                    #region Крайние стойки (рама)
                    foreach (RamaItem ri in model.Rama)
                    {
                        if (ri.IsRack)
                        {

                            string sd = "";
                            int mounts_qty = 0;
                            #region Проверяем конец 1
                            if (!ri.BalkaStart.IsRack)
                            {
                                // Считаем 1
                                mounts_qty++;

                                switch (ri.BalkaStart.AngleHorisont)
                                {
                                    case 0:
                                        mounts_top++;
                                        sd = "Top"; break;
                                    case 180:
                                        mounts_bottom++;
                                        sd = "Bottom"; break;
                                    default:
                                        sd = "none"; break;
                                }
                            }
                            #endregion
                            #region Проверяем конец 2
                            if (!ri.BalkaEnd.IsRack)
                            {
                                // Считаем 2
                                mounts_qty++;
                                switch (ri.BalkaEnd.AngleHorisont)
                                {
                                    case 0:
                                        mounts_top++;
                                        sd = "Top"; break;
                                    case 180:
                                        mounts_bottom++;
                                        sd = "Bottom"; break;
                                    default:
                                        sd = "none"; break;
                                }
                            }
                            #endregion
                            Err = "2.1";
                            if (need_Mount)
                                SaveModelCalcForRack_Mounts(drOI, ri, mounts_qty);

                            if (need_Mount_IP45)
                                SaveModelCalcForRack_Mounts_IP45(drOI, ri, mounts_qty);

                            mounts_all += mounts_qty;
                            Err = "2.2";
                        }
                    }
                    dtLogs += "\nend RamaItemCycle " + DateTime.Now.ToString("HH:mm:ss:fff");
                    #endregion
                    Err = "3";

                    #region Средние стойки (импост)
                    foreach (Impost ri in model.ImpostList)
                    {
                        if (ri.IsRack)
                        {
                            int mounts_qty = 0;

                            #region Проверяем конец 1

                            if (!ri.BalkaStart1.IsRack && !ri.BalkaStart2.IsRack && !ri.BalkaStart.IsRack)
                            {
                                // Считаем 1
                                mounts_qty++;
                            }

                            #endregion
                            #region Проверяем конец 2

                            if (!ri.BalkaEnd1.IsRack && !ri.BalkaEnd2.IsRack && !ri.BalkaEnd.IsRack)
                            {
                                // Считаем 2
                                mounts_qty++;
                            }

                            #endregion


                            if (need_Mount)
                                SaveModelCalcForRack_Mounts(drOI, ri, mounts_qty);

                            if (need_Mount_IP45)
                                SaveModelCalcForRack_Mounts_IP45(drOI, ri, mounts_qty);

                            mounts_all += mounts_qty;
                        }
                    }
                    dtLogs += "\nend Impost cycle " + DateTime.Now.ToString("HH:mm:ss:fff");
                    #endregion

                    Err = "4";
                    #region Сохранение 436 финпараметра (количество опорных пластин)

                    if (need_Mount)
                        drOI.AddFinparam(436, mounts_all, mounts_all);

                    #endregion
                }
                #endregion
                dtLogs += "\nend bashmak and zakl " + DateTime.Now.ToString("HH:mm:ss:fff");
                if (!drOI.IsidprofsysNull() && inRange(drOI.idprofsys, 208) && !drOI.IsidconstructiontypeNull() && drOI.idconstructiontype == 38 && model != null)
                {
                    // Сокол МП-640
                    // Адаптеры заполнения
                    #region Рамные стойки
                    foreach (RamaItem ri in model.Rama)
                    {
                        Err = "1_03_01_01";
                        if (ri.IsRack && inRange(ri.Marking, "#МП-64091-02", "#МП-64091", "#МП-64091-01", "#МП-64092-02", "МП-64092-02", "#МП-64092", "МП-64092", "#МП-64020", "МП-64020", "#МП-64020-02", "МП-64020-02", "#МП-64029", "#МП-64021-04"))
                        {
                            List<aRegion> regions = new List<aRegion>();
                            int idx = 0; double delta = 0; int delta_int = 0;

                            foreach (ModelPartClass mpc in ri.PartTypeList)
                            {
                                Err = "1_03_01_01";
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Glass g = mpc.Glass;
                                    bool exInnerGlass = g != null && model.InnerList.Find(x => x.ID == g.ID) != null;
                                    if (g == null || (g != null && !exInnerGlass && !g.Marking.ToLower().Contains("без")))
                                    {
                                        double aFrom = 0; double aTo = 0;
                                        fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta); delta_int = (int)delta;

                                        aRegion r = new aRegion();
                                        r.idx = idx;

                                        r.kind = 0;

                                        r.mpc = mpc;
                                        r.startcoord_double = aFrom; r.startcoord = (int)aFrom; r.endcoord_double = aTo; r.endcoord = (int)aTo;
                                        r.length = delta_int;
                                        r.length_double = delta;
                                        regions.Add(r);
                                        idx++;
                                    }
                                }
                            }

                            int current_kind = 0;
                            int sumlen = 0;
                            if (regions.Count > 0) current_kind = regions[0].kind;
                            foreach (aRegion r in regions)
                            {
                                /*
								if( r.kind == current_kind ) 
								{
									sumlen += r.length;						
								}
								else
								{
									// Сменился тип участка, необходимо сохранить данные и обнулить счетчики
									SaveModelCalcForBalkaPart( drOI, ri, sumlen, current_kind, "ПР" );
									sumlen = r.length; current_kind = r.kind;
								}*/
                                SaveModelCalcForBalkaPart(drOI, ri, r.length, r.kind, "ПР");
                            }
                            /*
							// Если после крайней смены типа есть несохраненный участок с длиной, то сохраняем его
							if( sumlen > 0 )
							{
								SaveModelCalcForBalkaPart( drOI, ri, sumlen, current_kind, "ПР" );
							}
							*/
                        }
                    }
                    dtLogs += "\nend rama stoiki " + DateTime.Now.ToString("HH:mm:ss:fff");
                    #endregion

                    #region Импостные стойки
                    foreach (Impost ri in model.ImpostList)
                    {
                        Err = "1_03_01_01";
                        if (ri.IsRack && inRange(ri.Marking, "#МП-64091-02", "#МП-64091", "#МП-64091-01", "#МП-64092-02", "МП-64092-02", "#МП-64092", "МП-64092", "#МП-64020", "МП-64020", "#МП-64020-02", "МП-64020-02", "#МП-64029", "#МП-64021-04"))
                        {
                            List<aRegion> regions = new List<aRegion>();
                            int idx = 0; double delta = 0; int delta_int = 0;

                            // Слева
                            foreach (ModelPartClass mpc in ri.PartTypeList)
                            {
                                Err = "1_03_01_01";
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Glass g = mpc.Glass;

                                    bool fnd_connect_glass = false;
                                    if (g == null)
                                    {
                                        fnd_connect_glass |= mpc.Balka1 != null && mpc.Balka1.BalkaType == ModelPart.RamaItem && model.GlassList.Any(x => x.Any(y => y.ConnectBalka == mpc.Balka1));
                                        fnd_connect_glass |= mpc.Balka2 != null && mpc.Balka2.BalkaType == ModelPart.RamaItem && model.GlassList.Any(x => x.Any(y => y.ConnectBalka == mpc.Balka2));
                                    }

                                    bool exInnerGlass = g != null && model.InnerList.Find(x => x.ID == g.ID) != null;
                                    if ((g == null && fnd_connect_glass) || (g != null && !exInnerGlass && !g.Marking.ToLower().Contains("без")))
                                    {
                                        double aFrom = 0; double aTo = 0;
                                        fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta); delta_int = (int)delta;

                                        aRegion r = new aRegion();
                                        r.idx = idx;

                                        r.kind = 0;
                                        r.side = "ЛЕВ";
                                        r.mpc = mpc;
                                        r.startcoord_double = aFrom; r.startcoord = (int)aFrom; r.endcoord_double = aTo; r.endcoord = (int)aTo;
                                        r.length = delta_int;
                                        r.length_double = delta;
                                        regions.Add(r);
                                        idx++;
                                    }
                                }
                            }

                            // Справа
                            int idx_mpc = 0;
                            foreach (ModelPartClass mpc in ri.PartTypeList2)
                            {
                                idx_mpc++;
                                Err = "1_03_01_01";
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Glass g = mpc.Glass;

                                    bool fnd_connect_glass = false;
                                    if (g == null)
                                    {
                                        fnd_connect_glass |= mpc.Balka1 != null && mpc.Balka1.BalkaType == ModelPart.RamaItem && model.GlassList.Any(x => x.Any(y => y.ConnectBalka == mpc.Balka1));
                                        fnd_connect_glass |= mpc.Balka2 != null && mpc.Balka2.BalkaType == ModelPart.RamaItem && model.GlassList.Any(x => x.Any(y => y.ConnectBalka == mpc.Balka2));
                                    }

                                    bool exInnerGlass = g != null && model.InnerList.Find(x => x.ID == g.ID) != null;
                                    if ((g == null && fnd_connect_glass) || (g != null && !exInnerGlass && !g.Marking.ToLower().Contains("без")))
                                    {
                                        double aFrom = 0; double aTo = 0;
                                        fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta); delta_int = (int)delta;

                                        aRegion r = new aRegion();
                                        r.idx = idx;

                                        r.kind = 0;
                                        r.side = "ПР";
                                        r.mpc = mpc;
                                        r.startcoord_double = aFrom; r.startcoord = (int)aFrom; r.endcoord_double = aTo; r.endcoord = (int)aTo;
                                        r.length = delta_int;
                                        r.length_double = delta;
                                        regions.Add(r);
                                        idx++;


                                        if (1 == 0 && Atechnology.ecad.Settings.idpeople == 168)
                                        {


                                            fnd_connect_glass |= mpc.Balka1.BalkaType == ModelPart.RamaItem && model.GlassList.Any(x => x.Any(y => y.ConnectBalka == mpc.Balka1));

                                            fnd_connect_glass |= mpc.Balka2.BalkaType == ModelPart.RamaItem && model.GlassList.Any(x => x.Any(y => y.ConnectBalka == mpc.Balka2));

                                            /*
											if( mpc.Balka1.BalkaType == ModelPart.Rama || mpc.Balka1.BalkaType == ModelPart.Rama )
											{											
												foreach( Glass gl in model.GlassList )
												{
													foreach( GlassItem gi in gl )
													{
														fnd_connect_glass |= gi.ConnectBalka == mpc.Balka1;
													}
												}
											}
											if( mpc.Balka2.BalkaType == ModelPart.Rama || mpc.Balka2.BalkaType == ModelPart.Rama )
											{											
												foreach( Glass gl in model.GlassList )
												{
													foreach( GlassItem gi in gl )
													{
														fnd_connect_glass |= gi.ConnectBalka == mpc.Balka2;
													}
												}
											}*/

                                            string debug = "";

                                            debug += "\fnd_connect_glass=" + fnd_connect_glass + ", B1=" + mpc.Balka1.BalkaType.ToString() + ", B2=" + mpc.Balka2.BalkaType.ToString() + "\n";


                                            MessageBox.Show("MPC=GLASS. RIGHT. RI.ID=" + ri.ID + ", isnull_Glass=" + (g == null).ToString() + debug);

                                            // System.IO.File.WriteAllText( "C:\\Temp\\Impost.ID" + ri.ID + " mpc_id" + idx_mpc + ".xml", mpcAsXML( mpc ) );

                                        }

                                    }
                                }
                            }


                            foreach (aRegion r in regions)
                            {
                                SaveModelCalcForBalkaPart(drOI, ri, r.length, r.kind, r.side);
                            }

                        }
                    }
                    dtLogs += "\nend impost stoiki " + DateTime.Now.ToString("HH:mm:ss:fff");
                    #endregion




                    #region Расчет крепежных башмаков и закладных
                    if (model != null) // Витраж MP640
                    {

                        #region Крайние стойки (рама)
                        foreach (RamaItem ri in model.Rama)
                        {
                            if (ri.IsRack)
                            {
                                int mounts_top = 0; int mounts_bottom = 0;
                                #region Проверяем конец 1
                                if (!ri.BalkaStart.IsRack)
                                {
                                    // Считаем 1
                                    switch (ri.BalkaStart.AngleHorisont)
                                    {
                                        case 0: mounts_top++; break;
                                        case 180: mounts_bottom++; break;
                                        default: break;
                                    }
                                }
                                #endregion
                                #region Проверяем конец 2
                                if (!ri.BalkaEnd.IsRack)
                                {
                                    // Считаем 2
                                    switch (ri.BalkaEnd.AngleHorisont)
                                    {
                                        case 0: mounts_top++; break;
                                        case 180: mounts_bottom++; break;
                                        default: break;
                                    }
                                }
                                #endregion
                                SaveModelCalcForRack_Mounts_MP640(drOI, model, ri, mounts_top, mounts_bottom);
                            }
                        }
                        #endregion

                        #region Средние стойки (импост)
                        foreach (Impost ri in model.ImpostList)
                        {
                            if (ri.IsRack)
                            {
                                int mounts_top = 0; int mounts_bottom = 0;

                                #region Проверяем конец 1
                                if (!ri.BalkaStart1.IsRack && !ri.BalkaStart2.IsRack && !ri.BalkaStart.IsRack)
                                {
                                    // Считаем 1
                                    switch (ri.BalkaStart1.AngleHorisont)
                                    {
                                        case 0: mounts_top++; break;
                                        case 180: mounts_bottom++; break;
                                        default: break;
                                    }
                                }
                                #endregion

                                #region Проверяем конец 2
                                if (!ri.BalkaEnd1.IsRack && !ri.BalkaEnd2.IsRack && !ri.BalkaEnd.IsRack)
                                {
                                    // Считаем 2
                                    switch (ri.BalkaEnd1.AngleHorisont)
                                    {
                                        case 0: mounts_top++; break;
                                        case 180: mounts_bottom++; break;
                                        default: break;
                                    }

                                }
                                #endregion
                                SaveModelCalcForRack_Mounts_MP640(drOI, model, ri, mounts_top, mounts_bottom);
                            }
                        }
                        #endregion

                    }
                    #endregion

                    dtLogs += "\nend calc krepezh " + DateTime.Now.ToString("HH:mm:ss:fff");
                }


                if (!drOI.IsidprofsysNull() && inRange(drOI.idprofsys, 122, 160, 188, 222) && !drOI.IsidconstructiontypeNull() && model != null)
                {
                    int cntMP45 = 0;
                    Err = "1_03_+++";
                    #region Опоры заполнения и притвора
                    #region Рамные стойки 19, 21 (##130719, ##130721)
                    foreach (RamaItem ri in model.Rama)
                    {
                        Err = "1_03_01_01";
                        if (inRange(ri.Marking.Replace("#", "")
                            , "130719", "130721", "130711"
                            , "МП-64092", "МП-64092-02", "МП-64081", "МП-64092-02+МП-64080", "МП-64092+МП-64080", "МП-64081+МП-64080",
                            "МП-45.05.02", "МП-45.05.04", "МП-45.05.05", "МП-45.05.06"
                            , "W45.03.03", "W45.05.01", "W45.05.02"))
                        {
                            List<aRegion> regions = new List<aRegion>();

                            int idx = 0; double delta = 0; int delta_int = 0;
                            cntMP45 = 0;
                            foreach (ModelPartClass mpc in ri.PartTypeList)
                            {
                                Err = "1_03_01_01";
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Glass g = mpc.Glass;
                                    if (1 == 1 || g != null)
                                    {
                                        if (Atechnology.ecad.Settings.idpeople == 2214)
                                        {

                                        }
                                        //if(g.Marking == "Без_стекла_и_штапика") continue; Раньше нужно было убирать эту опору для без стекла и штапика 
                                        //теперь надо вернуть 13.03.2020 (DEV-40167)
                                        double aFrom = 0; double aTo = 0;
                                        fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta); delta_int = (int)delta;

                                        aRegion r = new aRegion();
                                        r.idx = idx;

                                        r.kind = 0;

                                        r.mpc = mpc;
                                        r.startcoord_double = aFrom; r.startcoord = (int)aFrom; r.endcoord_double = aTo; r.endcoord = (int)aTo;
                                        r.length = delta_int;
                                        r.length_double = delta;
                                        regions.Add(r);
                                        idx++;

                                    }
                                }
                                if (mpc.ModelPart == ModelPart.Stvorka || mpc.ModelPart == ModelPart.StvorkaItem)
                                {
                                    double aFrom = 0; double aTo = 0;
                                    fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta); delta_int = (int)delta;
                                    aRegion r = new aRegion();
                                    r.idx = idx;
                                    if (inRange(mpc.StvItem.Marking, "130703", "P400/02X", "МП-45.04.01", "W45.02.02")) /* МП-45.04.01 или МП-45.01.03 или МП-45.04.04  */
                                    {
                                        r.kind = 0;
                                    }
                                    else if (inRange(mpc.StvItem.Marking, "МП-45.04.03", "МП-45.04.04"))
                                    {
                                        r.kind = 100;
                                    }
                                    else if (inRange(mpc.StvItem.Marking, "МП-45.02.02", "МП-45.02.03", "D45.02.01", "D45.02.02"))
                                    {
                                        r.kind = 3; // Створки, к которым нужны спец адаптеры
                                    }

                                    else
                                    {
                                        r.kind = 1;
                                    }
                                    r.mpc = mpc;
                                    r.startcoord_double = aFrom; r.startcoord = (int)aFrom; r.endcoord_double = aTo; r.endcoord = (int)aTo;
                                    r.length = delta_int; r.length_double = delta;
                                    regions.Add(r);
                                    idx++;
                                }
                                if (mpc.ModelPart == ModelPart.Rama)
                                {
                                    double aFrom = 0; double aTo = 0;
                                    fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta); delta_int = (int)delta;

                                    aRegion r = new aRegion();
                                    r.idx = idx;
                                    r.kind = 2; // Встройка (рама)
                                    r.mpc = mpc;
                                    r.startcoord_double = aFrom; r.startcoord = (int)aFrom; r.endcoord_double = aTo; r.endcoord = (int)aTo;
                                    r.length = delta_int; r.length_double = delta;
                                    regions.Add(r);
                                    idx++;
                                }
                            }
                            int current_kind = 0;
                            int sumlen = 0;
                            if (regions.Count > 0) current_kind = regions[0].kind;
                            foreach (aRegion r in regions)
                            {
                                if (r.kind == current_kind)
                                {
                                    sumlen += r.length;
                                }
                                else
                                {
                                    // Сменился тип участка, необходимо сохранить данные и обнулить счетчики
                                    SaveModelCalcForBalkaPart(drOI, ri, sumlen, current_kind, "ПР");
                                    sumlen = r.length; current_kind = r.kind;
                                }
                            }
                            // Если после крайней смены типа есть несохраненный участок с длиной, то сохраняем его
                            if (sumlen > 0)
                            {
                                SaveModelCalcForBalkaPart(drOI, ri, sumlen, current_kind, "ПР");
                            }


                            if (ri.Marking == "##130721" && ri.IsRail)
                            {
                                if (model.StvorkaList.Find(y => y.Find(x => x.RamaItem == ri && inRange(x.Marking, "130803", "130804")) != null) != null)
                                {
                                    SaveModelCalcForBalkaPart(drOI, ri, ri.LengthInterfaceCalcInt, 4, "ПР");
                                }
                            }

                        }


                    }
                    #endregion
                    Err = "1_03_I";
                    #region Импостные стойки #130719, #130721

                    foreach (Impost ri in model.ImpostList)
                    {
                        if (inRange(ri.Marking.Replace("#", ""), "130719", "130721", "130711"
                            ,"МП-64092", "МП-64092-02", "МП-64081", "МП-64092-02+МП-64080", "МП-64092+МП-64080", "МП-64081+МП-64080"
                            ,"МП-45.05.02", "МП-45.05.04", "МП-45.05.05", "МП-45.05.06"
                            ,"W45.03.03", "W45.05.01", "W45.05.02"))
                        {
                            //								MessageBox.Show( "Calc imp: " + ri.Marking );
                            List<aRegion> regions = new List<aRegion>();

                            int idx = 0; double delta = 0; int delta_int = 0; bool isFirst = true;
                            bool needBreak = false;
                            foreach (ModelPartClass mpc in ri.PartTypeList)
                            {
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Err = "1_03_1";
                                    Glass g = mpc.Glass;

                                    Err = "1_03_2";
                                    if (1 == 1 || g != null)
                                    {
                                        if (model.InnerList != null && model.InnerList.Count > 0 && Atechnology.ecad.Settings.idpeople == 22214)
                                        {
                                            if (mpc.Glass != null)
                                            {
                                                if (model.InnerList.Any(x => x.ID == mpc.Glass.ID))
                                                {
                                                    needBreak = true;
                                                    continue;
                                                }
                                            }
                                        }
                                        //if(g.Marking == "Без_стекла_и_штапика") continue;Раньше нужно было убирать эту опору для без стекла и штапика 
                                        //теперь надо вернуть 13.03.2020 (DEV-40167)
                                        Err = "1_03_3";
                                        Err = "1_03_4";
                                        double aFrom = 0; double aTo = 0;
                                        Err = "1_03_5";
                                        fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta);
                                        Err = "1_03_6";
                                        delta_int = (int)delta;
                                        Err = "1_03_7";
                                        aRegion r = new aRegion();
                                        r.first = isFirst;
                                        Err = "1_03_8";
                                        r.idx = idx;
                                        Err = "1_03_9";
                                        if (needBreak)
                                        {
                                            r.kind = 5;
                                        }
                                        else
                                        {
                                            r.kind = 0;
                                        }
                                        Err = "1_03_10";
                                        r.mpc = mpc;
                                        r.side = "ЛЕВ";
                                        r.startcoord_double = aFrom;
                                        r.startcoord = (int)aFrom;
                                        Err = "1_03_11";
                                        r.endcoord_double = aTo;
                                        r.endcoord = (int)aTo;
                                        Err = "1_03_12";
                                        r.length = delta_int; r.length_double = delta;
                                        regions.Add(r);
                                        Err = "1_03_13";
                                        idx++;
                                        Err = "1_03_14";
                                    }
                                }
                                if (mpc.ModelPart == null) continue;
                                if (mpc.ModelPart == ModelPart.Stvorka || mpc.ModelPart == ModelPart.StvorkaItem)
                                {
                                    Err = "1_03_5_0";
                                    double aFrom = 0; double aTo = 0;
                                    fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta);
                                    delta_int = (int)delta;

                                    aRegion r = new aRegion();
                                    r.first = isFirst;
                                    r.idx = idx;
                                    if (inRange(mpc.StvItem.Marking, "130703", "P400/02X", "МП-45.04.01", "W45.02.02"))
                                    {
                                        r.kind = 0;
                                    }
                                    else if (inRange(mpc.StvItem.Marking, "МП-45.04.03", "МП-45.04.04"))
                                    {
                                        r.kind = 100;
                                    }
                                    else if (inRange(mpc.StvItem.Marking, "МП-45.02.02", "МП-45.02.03", "D45.02.01", "D45.02.02"))
                                    {
                                        r.kind = 3; // Створки, к которым нужны спец адаптеры
                                    }
                                    //									else if( ri.Marking == "#130721" && ri.IsRail && inRange( mpc.StvItem.Marking, "130803", "130804" ) )
                                    //									{
                                    //										r.kind = 4;
                                    //									}
                                    else
                                    {
                                        r.kind = 1;
                                    }
                                    r.mpc = mpc; r.side = "ЛЕВ";

                                    r.startcoord_double = aFrom;
                                    r.startcoord = (int)aFrom;
                                    r.endcoord_double = aTo;
                                    r.endcoord = (int)aTo;
                                    r.length = delta_int;
                                    r.length_double = delta;

                                    regions.Add(r);
                                    idx++;
                                }
                                if (mpc.ModelPart == ModelPart.Rama)
                                {
                                    double aFrom = 0; double aTo = 0;
                                    Err = "1_03_5";
                                    fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta);
                                    Err = "1_03_6";
                                    delta_int = (int)delta;
                                    Err = "1_03_7";
                                    aRegion r = new aRegion();
                                    r.first = isFirst;
                                    Err = "1_03_8";
                                    r.idx = idx;
                                    Err = "1_03_9";
                                    r.kind = 2;
                                    Err = "1_03_10";
                                    r.mpc = mpc;
                                    r.side = "ЛЕВ";
                                    r.startcoord_double = aFrom;
                                    r.startcoord = (int)aFrom;
                                    Err = "1_03_11";
                                    r.endcoord_double = aTo;
                                    r.endcoord = (int)aTo;
                                    Err = "1_03_12";
                                    r.length = delta_int; r.length_double = delta;
                                    regions.Add(r);
                                    Err = "1_03_13";
                                    idx++;
                                    Err = "1_03_14";
                                }

                                isFirst = false;
                            }
                            isFirst = true;
                            foreach (ModelPartClass mpc in ri.PartTypeList2)
                            {
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Glass g = mpc.Glass;

                                    if (1 == 1 || g != null)
                                    {
                                        if (model.InnerList != null && model.InnerList.Count > 0 && Atechnology.ecad.Settings.idpeople == 22214)
                                        {
                                            if (mpc.Glass != null)
                                            {
                                                if (model.InnerList.Any(x => x.ID == mpc.Glass.ID))
                                                {
                                                    needBreak = true;
                                                    continue;
                                                }
                                            }
                                        }
                                        //if(g.Marking == "Без_стекла_и_штапика") continue;Раньше нужно было убирать эту опору для без стекла и штапика 
                                        //теперь надо вернуть 13.03.2020 (DEV-40167)
                                        double aFrom = 0; double aTo = 0;
                                        fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta);
                                        delta_int = (int)delta;

                                        aRegion r = new aRegion();
                                        r.first = isFirst;
                                        r.idx = idx;
                                        if (needBreak)
                                        {
                                            r.kind = 5;
                                        }
                                        else
                                        {

                                            r.kind = 0;

                                        }
                                        r.mpc = mpc; r.side = "ПР";
                                        r.startcoord_double = aFrom; r.startcoord = (int)aFrom; r.endcoord_double = aTo; r.endcoord = (int)aTo;
                                        r.length = delta_int; r.length_double = delta;
                                        regions.Add(r);
                                        idx++;

                                    }
                                }
                                Err = "1_03_5_" + ri.Marking;
                                if (mpc.ModelPart == null) continue;
                                if (mpc.ModelPart == ModelPart.Stvorka || mpc.ModelPart == ModelPart.StvorkaItem)
                                {
                                    Err = "1_03_5_1" + ri.Marking;
                                    double aFrom = 0; double aTo = 0;
                                    fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta);
                                    delta_int = (int)delta;

                                    Err = "1_03_5_2" + ri.Marking;
                                    aRegion r = new aRegion();
                                    r.first = isFirst;
                                    r.idx = idx;
                                    if (mpc.StvItem == null)
                                        continue;
                                    else
                                    {
                                        if (inRange(mpc.StvItem.Marking, "130703", "P400/02X", "МП-45.04.01", "W45.02.02"))
                                        {
                                            r.kind = 0;
                                        }
                                        else if (inRange(mpc.StvItem.Marking, "МП-45.04.03", "МП-45.04.04"))
                                        {
                                            r.kind = 100;
                                        }
                                        else if (inRange(mpc.StvItem.Marking, "МП-45.02.02", "МП-45.02.03", "D45.02.01", "D45.02.02"))
                                        {
                                            r.kind = 3; // Створки, к которым нужны спец адаптеры
                                        }
                                        //										else if( ri.Marking == "#130721" && ri.IsRail && inRange( mpc.StvItem.Marking, "130803", "130804" ) )
                                        //										{
                                        //											r.kind = 4;
                                        //										}
                                        else
                                        {
                                            r.kind = 1;
                                        }
                                    }
                                    r.mpc = mpc;

                                    r.side = "ПР";
                                    Err = "1_03_5_3" + ri.Marking;
                                    r.startcoord_double = aFrom;
                                    r.startcoord = (int)aFrom;
                                    r.endcoord_double = aTo;
                                    r.endcoord = (int)aTo;
                                    r.length = delta_int;
                                    r.length_double = delta;

                                    regions.Add(r);
                                    idx++;
                                    Err = "1_03_5_4" + ri.Marking;
                                }
                                if (mpc.ModelPart == ModelPart.Rama)
                                {
                                    double aFrom = 0; double aTo = 0;
                                    Err = "1_03_5";
                                    fillModelPartClass_FromTo2(drOI, ri, mpc, ref aFrom, ref aTo, ref delta);
                                    Err = "1_03_6";
                                    delta_int = (int)delta;
                                    Err = "1_03_7";
                                    aRegion r = new aRegion();
                                    r.first = isFirst;
                                    Err = "1_03_8";
                                    r.idx = idx;
                                    Err = "1_03_9";
                                    r.kind = 2;
                                    Err = "1_03_10";
                                    r.mpc = mpc;
                                    r.side = "ПР";
                                    r.startcoord_double = aFrom;
                                    r.startcoord = (int)aFrom;
                                    Err = "1_03_11";
                                    r.endcoord_double = aTo;
                                    r.endcoord = (int)aTo;
                                    Err = "1_03_12";
                                    r.length = delta_int; r.length_double = delta;
                                    regions.Add(r);
                                    Err = "1_03_13";
                                    idx++;
                                    Err = "1_03_14";
                                }

                                isFirst = false;
                            }
                            Err = "1_03_6_" + ri.Marking;
                            int current_kind = 0;
                            int sumlen = 0; string cur_side = ""; bool curFirst = false;
                            if (regions.Count > 0) { current_kind = regions[0].kind; cur_side = regions[0].side; curFirst = regions[0].first; }
                            foreach (aRegion r in regions)
                            {
                                if (r.kind == current_kind && r.side == cur_side)
                                {
                                    sumlen += r.length;
                                }
                                else
                                {
                                    // if( current_kind == 0 && curFirst && ri.Outer1 > 0 ) sumlen += ri.Outer1; // Для импостов и заполнений в случае выноса с "начала" балки, добавляем его к длине
                                    // Сменился тип участка, необходимо сохранить данные и обнулить счетчики
                                    SaveModelCalcForBalkaPart(drOI, ri, sumlen, current_kind, cur_side);
                                    sumlen = r.length; current_kind = r.kind; cur_side = r.side; curFirst = r.first;
                                }
                            }
                            // Если после крайней смены типа есть несохраненный участок с длиной, то сохраняем его
                            if (sumlen > 0)
                            {
                                // if( current_kind == 0 && ri.Outer2 > 0 ) sumlen += ri.Outer2; // Для импостов и заполнений в случае выноса с "конца" балки, добавляем его к длине
                                SaveModelCalcForBalkaPart(drOI, ri, sumlen, current_kind, cur_side);
                            }

                            //							if( ri.Marking == "#130721" && ri.IsRail )
                            //							{
                            //								if( model.StvorkaList.Find( y=>y.Find( x=>x.Impost == ri && inRange( x.Marking, "130803", "130804" ) ) != null ) != null )
                            //								{
                            //									SaveModelCalcForBalkaPart( drOI, ri, ri.LengthInterfaceCalcInt, 4, "И" );
                            //								}
                            //							}
                        }


                    }

                    #endregion
                    #endregion
                    dtLogs += "\nend opori and pritvora " + DateTime.Now.ToString("HH:mm:ss:fff");
                    #region Татпроф МП-45
                    if (drOI.idprofsys == 188 && drOI.idconstructiontype == 39)
                    {
                        // Крайние ригеля надо проверить на коннект с рядомстоящей створкой и посчитать туда огрызки адаптеров
                        foreach (RamaItem ri in model.Rama)
                        {
                            if (!inRange(ri.Marking, "МП-45.05.02", "#МП-45.05.02")
                                || !ri.IsRack || ri.StvorkaItemList.Count == 0
                                || ri.StvorkaItemList.Find(x => inRange(x.Marking, "МП-45.02.02", "МП-45.02.03")) == null) continue; // Работаем только со стойками, к которым есть примыкание створок
                            RamaItem ri_start = (RamaItem)(ri.BalkaStart);
                            RamaItem ri_end = (RamaItem)(ri.BalkaEnd);

                            // Проверяем балку начала на коннект с общей створкой двери
                            if (ri_start != null && inRange(ri_start.Marking, "#МП-45.01.03", "#МП-45.01.04") && !ri_start.Marking.ToLower().Contains("без") && ri_start.StvorkaItemList.Count > 0 && ri_start.StvorkaItemList.Find(x => inRange(x.Marking, "МП-45.02.02", "МП-45.02.03")) != null)
                            {
                                bool connectOK = false;
                                foreach (StvorkaItem si in ri.StvorkaItemList)
                                {
                                    Stvorka s = si.Stvorka;
                                    foreach (StvorkaItem si2 in ri_start.StvorkaItemList)
                                    {
                                        connectOK = si2.Stvorka == s;
                                        if (connectOK) break;
                                    }
                                    if (connectOK) break;
                                }

                                // рама- арт. #МП-45.01.03 - считать длину адаптера равную размеру С профиля - это 36 мм
                                // рама -арт. #МП-45.01.04 -считать длину адаптера равную размеру С профиля - это 52 мм
                                if (connectOK)
                                {
                                    //SaveModelCalcForBalkaPart( drOI, ri, (int)ri_start.C, 0, "ПР.Р" );	
                                }
                            }

                            // Проверяем балку начала на коннект с общей створкой двери
                            if (ri_end != null && inRange(ri_end.Marking, "#МП-45.01.03", "#МП-45.01.04") && !ri_end.Marking.ToLower().Contains("без") && ri_end.StvorkaItemList.Count > 0 && ri_end.StvorkaItemList.Find(x => inRange(x.Marking, "МП-45.02.02", "МП-45.02.03")) != null)
                            {
                                bool connectOK = false;
                                foreach (StvorkaItem si in ri.StvorkaItemList)
                                {
                                    Stvorka s = si.Stvorka;
                                    foreach (StvorkaItem si2 in ri_end.StvorkaItemList)
                                    {
                                        connectOK = si2.Stvorka == s;
                                        if (connectOK) break;
                                    }
                                    if (connectOK) break;
                                }

                                // рама- арт. #МП-45.01.03 - считать длину адаптера равную размеру С профиля - это 36 мм
                                // рама -арт. #МП-45.01.04 -считать длину адаптера равную размеру С профиля - это 52 мм
                                if (connectOK)
                                {
                                    //SaveModelCalcForBalkaPart( drOI, ri, (int)ri_end.C, 0, "ПР.Р" );	
                                }
                            }
                        }

                        foreach (Impost ri in model.ImpostList)
                        {
                            if (!inRange(ri.Marking, "МП-45.05.02", "#МП-45.05.02") || !ri.IsRack || ri.StvorkaItemList.Count == 0 || ri.StvorkaItemList.Find(x => inRange(x.Marking, "МП-45.02.02", "МП-45.02.03")) == null) continue; // Работаем только со стойками, к которым есть примыкание створок

                            List<RamaItem> ri_left = new List<RamaItem>();
                            ri_left.Add((RamaItem)(ri.BalkaStart1));
                            ri_left.Add((RamaItem)(ri.BalkaEnd1));
                            ri_left.Add((RamaItem)(ri.BalkaStart2));
                            ri_left.Add((RamaItem)(ri.BalkaEnd2));

                            foreach (RamaItem ri0 in ri_left)
                            {

                                // Проверяем балку начала на коннект с общей створкой двери
                                if (ri0 != null && inRange(ri0.Marking, "#МП-45.01.03", "#МП-45.01.04") && ri0.StvorkaItemList.Find(x => inRange(x.Marking, "МП-45.02.02", "МП-45.02.03")) != null)
                                {
                                    bool connectOK = false;
                                    foreach (StvorkaItem si in ri.StvorkaItemList)
                                    {
                                        Stvorka s = si.Stvorka;
                                        foreach (StvorkaItem si2 in ri0.StvorkaItemList)
                                        {
                                            connectOK = si2.Stvorka == s;
                                            if (connectOK) break;
                                        }
                                        if (connectOK) break;
                                    }
                                    if (connectOK)
                                    {
                                        //SaveModelCalcForBalkaPart( drOI, ri, (int)ri0.C, 0, "И" );	
                                    }
                                }
                            }
                        }
                    }
                    #endregion Татпроф МП-45

                    dtLogs += "\nend tatprof mp45" + DateTime.Now.ToString("HH:mm:ss:fff");
                }

                #region Inicial City Pro
                if (drOI.idproductiontype == 1416) // Изделие из профиля Inicial City Pro
                {
                    Err = "1_04";
                    #region Расчет вентрешеток IP45
                    foreach (Glass g in model.GlassList)
                    {
                        if (g.Marking == "Вентрешетка IP45")
                        {
                            // MessageBox.Show( "A1" );
                            int width = g.Width;
                            int height = g.Height;

                            string part = g.Part;

                            // MessageBox.Show( "Part=" + part );

                            int idcolor1 = 0; if (!drOI.IsidcoloroutNull()) idcolor1 = drOI.idcolorout;
                            int idcolor2 = 0; if (!drOI.IsidcolorinNull()) idcolor2 = drOI.idcolorin;

                            ds_order.modelcalcRow r = null;
                            // 1. Расчет рамки - верх/низ
                            r = drOI.AddModelcalc("13 07 44", 1);
                            r.thick = width; r.ang1 = 45; r.ang2 = 45; r.addstr3 = "В"; r.modelpart = part;
                            if (idcolor1 != 0) r.idcolor1 = idcolor1;
                            if (idcolor2 != 0) r.idcolor2 = idcolor2;
                            // 1. Расчет рамки - верх/низ
                            r = drOI.AddModelcalc("13 07 44", 1);
                            r.thick = width; r.ang1 = 45; r.ang2 = 45; r.addstr3 = "Н"; r.modelpart = part;
                            if (idcolor1 != 0) r.idcolor1 = idcolor1;
                            if (idcolor2 != 0) r.idcolor2 = idcolor2;

                            // 2. Расчет рамки - лево/право
                            r = drOI.AddModelcalc("13 07 44", 1);
                            r.thick = height; r.ang1 = 45; r.ang2 = 45; r.addstr3 = "Л"; r.modelpart = part;
                            if (idcolor1 != 0) r.idcolor1 = idcolor1;
                            if (idcolor2 != 0) r.idcolor2 = idcolor2;
                            r = drOI.AddModelcalc("13 07 44", 1);
                            r.thick = height; r.ang1 = 45; r.ang2 = 45; r.addstr3 = "П"; r.modelpart = part;
                            if (idcolor1 != 0) r.idcolor1 = idcolor1;
                            if (idcolor2 != 0) r.idcolor2 = idcolor2;

                            // 3. Расчет ламелей
                            int work_w = width - 43;
                            int work_h = height - 43;
                            int qu = (int)Math.Round(((decimal)work_h) / 25M, MidpointRounding.AwayFromZero);

                            r = drOI.AddModelcalc("13 07 45", qu);
                            r.thick = work_w; r.ang1 = 90; r.ang2 = 90; r.modelpart = part;
                            if (idcolor1 != 0) r.idcolor1 = idcolor1;
                            if (idcolor2 != 0) r.idcolor2 = idcolor2;

                            r = drOI.AddModelcalc("РС 10-02", 4); // Уголок 
                            r.thick = 21; // Длина 21мм r.modelpart = part;
                            if (Atechnology.ecad.Settings.idpeople == 172)
                            {
                                MessageBox.Show("Саморезы!");
                            }
                            r = drOI.AddModelcalc("4,2х13 DIN 7981", qu * 2); // Саморезы по числу ламелей x2
                            r.modelpart = part;
                            r = drOI.AddModelcalc("99 02 18", 8); // Саморезы 8 шт на уголки
                            r.modelpart = part;

                        }
                    }
                    #endregion
                    dtLogs += "\nend ventr IP45 " + DateTime.Now.ToString("HH:mm:ss:fff");
                    #region Расчет операций для City Pro

                    #region Расчет фрезеровок fr
                    #region Для Крайних ригелей (Рамных)
                    foreach (RamaItem i in model.Rama)
                    {
                        if (!i.IsRail) continue;
                        string artLeftBalka = "";
                        string artRightBalka = "";
                        string pLeft = ""; string pRight = "";
                        switch ((int)i.AngNakl)
                        {
                            case 000: // Верхняя
                                artLeftBalka = i.BalkaEnd.Marking; pLeft = (i.BalkaEnd.ID + 1).ToString();
                                artRightBalka = i.BalkaStart.Marking; pRight = (i.BalkaStart.ID + 1).ToString();
                                break;
                            case 180: // Нижняя
                                artLeftBalka = i.BalkaStart.Marking; pLeft = (i.BalkaStart.ID + 1).ToString();
                                artRightBalka = i.BalkaEnd.Marking; pRight = (i.BalkaEnd.ID + 1).ToString();
                                break;
                            default: // ХЗ что это
                                artLeftBalka = i.BalkaStart.Marking; pLeft = (i.BalkaStart.ID + 1).ToString();
                                artRightBalka = i.BalkaEnd.Marking; pRight = (i.BalkaEnd.ID + 1).ToString();
                                break;

                        }
                        CITY_AddFrezToBalka(drOI, i, artLeftBalka, artRightBalka, i.Tag4);
                    }
                    #endregion

                    #region Для средних ригелей (Импостных)
                    foreach (Impost i in model.ImpostList)
                    {
                        if (!i.IsRail) continue;

                        string artLeftBalka = "";
                        string artRightBalka = "";
                        string pLeft = ""; string pRight = "";
                        switch ((int)i.AngNakl)
                        {
                            case 000: // Верхняя
                                artLeftBalka = i.BalkaStart.Marking; pLeft = (i.BalkaStart.ID + 1).ToString();
                                artRightBalka = i.BalkaEnd.Marking; pRight = (i.BalkaEnd.ID + 1).ToString();
                                break;
                            case 180: // Нижняя
                                artLeftBalka = i.BalkaStart.Marking; pLeft = (i.BalkaStart.ID + 1).ToString();
                                artRightBalka = i.BalkaEnd.Marking; pRight = (i.BalkaEnd.ID + 1).ToString();
                                break;
                            default: // ХЗ что это
                                artLeftBalka = i.BalkaStart.Marking; pLeft = (i.BalkaStart.ID + 1).ToString();
                                artRightBalka = i.BalkaEnd.Marking; pRight = (i.BalkaEnd.ID + 1).ToString();
                                break;

                        }

                        CITY_AddFrezToBalka(drOI, i, artLeftBalka, artRightBalka, i.Tag4);
                    }
                    #endregion
                    #endregion

                    #region Расчет закладных ML/MR zl/zr

                    string op_zakl_left = "ML";//"zl";
                    string op_zakl_right = "MR";//"zr";
                    string op_dop_zakl_left = "zl_smesh";
                    string op_dop_zakl_right = "zr_smesh";

                    Err = "23_" + drOI.name;

                    // Количество стоек
                    int quStoek = 0;
                    // Количество ригелей
                    int quRigel = 0;

                    decimal oiSquare = 0;

                    oiSquare = drOI.width * drOI.height / 1000000;
                    Err = "23_1";
                    //Балки рамы
                    foreach (RamaItem ri in model.Rama)
                    {
                        bool inverse = ri.AngleHorisont == 270;
                        double sign = 1;
                        if (inverse) sign = -1;

                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        else
                        {
                            if ((ri.AngNakl == 90) || (ri.AngNakl == 270))
                            {
                                quStoek++;
                            }
                            else
                            {
                                quRigel++;
                            }

                            #region Добавление операций на балку рамы, по координатам прилегающих импостов, а также на края, там ведь тоже закладные
                            int impCnt = 0;
                            foreach (double i_ in ri.ImpostPositionListDoubleInterface)
                            {
                                double i = Math.Round(i_, 3);
                                if (ri.Side == ItemSide.Right)
                                    i -= 6;
                                else if (ri.Side == ItemSide.Left)
                                    i += 6;
                                if (i < 0 || i > ri.Lenght || ri.ImpostList.Count == 0) continue;
                                Impost imp = (Impost)ri.ImpostList[impCnt];
                                if (imp != null && !imp.Marking.ToLower().Contains("без"))
                                {
                                    Operation op = new Operation(op_zakl_right, (double)i, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    ri.OperationList.Add(op);
                                }

                                #region Добавление операций закладных со сдвигом на балку рамы								
                                if (imp != null && inRange(imp.Marking, "17 06 03", "17 06 04", "17 06 05", "#17 06 03", "#17 06 04", "#17 06 05"))
                                {
                                    double pos = i;
                                    int koef = ri.AngleHorisont == 90
                                        ? 1
                                        : -1;

                                    string innerModelPosition = imp.GetUserParam(2276).StrValue;
                                    if (innerModelPosition == "Снизу")
                                    {
                                        pos += koef * 11.4;
                                    }
                                    else if (innerModelPosition == "Сверху")
                                    {
                                        pos -= koef * 11.4;
                                    }

                                    Operation op = new Operation(op_dop_zakl_right, pos, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)pos, (double)pos);
                                    ri.OperationList.Add(op);
                                }
                                #endregion

                                impCnt++;
                            }

                            if (ri.IsRack)
                            {
                                int railCnt = 0;
                                foreach (double i_ in ri.RailPositionListDoubleInterface)
                                {
                                    double i = Math.Round(i_, 3);
                                    if (i < 0 || i > ri.Lenght) continue;

                                    Balka b = (Balka)ri.RailList[railCnt];

                                    if (b != null && b.Side == ItemSide.Bottom) { i += sign * b.A / 2; } else { i -= sign * b.A / 2; }

                                    if (b != null && !b.Marking.ToLower().Contains("без"))
                                    {
                                        Operation op = new Operation(op_zakl_right + "", (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        ri.OperationList.Add(op);
                                    }
                                    railCnt++;
                                }
                            }

                            #endregion


                        }
                    }
                    Err = "23_01";
                    foreach (Impost ri in model.ImpostList)
                    {
                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        else
                        {
                            if ((ri.AngNakl == 90) || (ri.AngNakl == 270))
                            {
                                quStoek++;
                            }
                            else
                            {
                                quRigel++;
                            }

                            #region Добавление операций по установке закладных на балки импостов (средних ригелей и стоек), по координатам прилегающих балок, а также на краях (длинные соединения)
                            int impCnt = 0;
                            foreach (double i_ in ri.ImpostPositionListDoubleInterface)
                            {
                                double i = Math.Round(i_, 3) + 6;
                                if (i < 0 || i > ri.Lenght || ri.ImpostList.Count == 0) continue;
                                Impost imp = (Impost)ri.ImpostList[impCnt];
                                if (imp != null && !imp.Marking.ToLower().Contains("без") && ri.AngNakl != imp.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                {
                                    Operation op = new Operation(op_zakl_left, (double)i, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    ri.OperationList.Add(op);
                                }

                                #region Добавление операций закладных со сдвигом на балку импоста								
                                if (imp != null && inRange(imp.Marking, "17 06 03", "17 06 04", "17 06 05", "#17 06 03", "#17 06 04", "#17 06 05"))
                                {
                                    double pos = i;

                                    string innerModelPosition = imp.GetUserParam(2276).StrValue;
                                    if (innerModelPosition == "Снизу")
                                    {
                                        pos += 11.4;
                                    }
                                    else if (innerModelPosition == "Сверху")
                                    {
                                        pos -= 11.4;
                                    }

                                    Operation op = new Operation(op_dop_zakl_left, pos, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)pos, (double)pos);
                                    ri.OperationList.Add(op);

                                }
                                #endregion

                                impCnt++;
                            }
                            if (ri.IsRack)
                            {

                                int railCnt = 0;
                                foreach (double i_ in ri.RailPositionListDoubleInterface)
                                {
                                    double i = Math.Round(i_, 3);
                                    if (i < 0 || i > ri.Lenght || ri.RailsList.Count == 0) continue;

                                    Balka b = (Balka)ri.RailsList[railCnt];
                                    if (b != null && b.Side == ItemSide.Bottom) { i += b.A / 2; } else { i -= b.A / 2; }

                                    if (b != null && !b.Marking.ToLower().Contains("без") && ri.AngNakl != b.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                    {
                                        Operation op = new Operation(op_zakl_left, (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        ri.OperationList.Add(op);
                                    }
                                    railCnt++;
                                }
                            }

                            impCnt = 0;
                            foreach (double i_ in ri.ImpostPositionListDouble2Interface)
                            {
                                double i = Math.Round(i_, 3) + 6;
                                if (i < 0 || i > ri.Lenght) continue;

                                Impost imp = (Impost)ri.ImpostList2[impCnt];
                                if (imp != null && !imp.Marking.ToLower().Contains("без") && ri.AngNakl != imp.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                {
                                    Operation op = new Operation(op_zakl_right, (double)i, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    ri.OperationList.Add(op);
                                }

                                #region Добавление операций закладных со сдвигом на балку импоста								
                                if (imp != null && inRange(imp.Marking, "17 06 03", "17 06 04", "17 06 05", "#17 06 03", "#17 06 04", "#17 06 05"))
                                {
                                    double pos = i;

                                    string innerModelPosition = imp.GetUserParam(2276).StrValue;
                                    if (innerModelPosition == "Снизу")
                                    {
                                        pos += 11.4;
                                    }
                                    else if (innerModelPosition == "Сверху")
                                    {
                                        pos -= 11.4;
                                    }

                                    Operation op = new Operation(op_dop_zakl_right, pos, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)pos, (double)pos);
                                    ri.OperationList.Add(op);

                                }
                                #endregion

                                impCnt++;
                            }
                            if (ri.IsRack)
                            {

                                int railCnt = 0;
                                foreach (double i_ in ri.RailPositionListDouble2Interface)
                                {
                                    double i = Math.Round(i_, 3);
                                    if (i < 0 || i > ri.Lenght || ri.RailsList2.Count == 0) continue;
                                    Balka b = (Balka)ri.RailsList2[railCnt];
                                    if (b != null && b.Side == ItemSide.Bottom) { i += b.A / 2; } else { i -= b.A / 2; }
                                    //									MessageBox.Show( "B_ANGLE=" + b.AngNakl.ToString() + ", I_ANGLE=" + ri.AngNakl.ToString() );

                                    if (b != null && !b.Marking.ToLower().Contains("без") && ri.AngNakl != b.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                    {
                                        Operation op = new Operation(op_zakl_right, (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        ri.OperationList.Add(op);
                                    }
                                    railCnt++;
                                }
                            }
                            #endregion
                        }
                    }

                    #endregion

                    #region DL/DR
                    //отключил по задаче DEV-84896
                    if (1 == 0 && model != null && !drOI.IsidprofsysNull() && inRange(drOI.idprofsys, 144))
                    {
                        string[] prof = { "17 09 02", "17 06 01", "17 09 01", "17 08 01" };

                        foreach (RamaItem ri in model.Rama)
                        {
                            if (ri.Marking.ToLower().Contains("без"))
                                continue;

                            if (
                                (ri.AngNakl == 0 || ri.AngNakl == 180)
                                && ri.Side == ItemSide.Bottom
                                && ri.RamaType == RamaType.Rama
                                //&& Array.IndexOf(prof,ri.Marking.Replace("#","")) >= 0 
                                )
                            {
                                ri.OperationList.Add(new Operation("DL", 200, "DL_start"));
                                ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 200, "DL_end"));
                            }
                        }

                        foreach (Stvorka s in model.StvorkaList)
                        {
                            foreach (StvorkaItem si in s)
                            {
                                if (si.Marking.ToLower().Contains("без"))
                                    continue;

                                if (
                                    (si.AngNakl == 0 || si.AngNakl == 180)
                                    && si.Side == ItemSide.Bottom
                                    //&& Array.IndexOf(prof,si.Marking.Replace("#","")) >= 0 
                                    )
                                {
                                    si.OperationList.Add(new Operation("DL", 200, "DL_start"));
                                    si.OperationList.Add(new Operation("DL", si.LengthInterfaceCalc - 200, "DL_end"));
                                }
                            }
                        }

                        foreach (Impost ri in model.ImpostList)
                        {
                            if (ri.Marking.ToLower().Contains("без"))
                                continue;

                            if (
                                (ri.AngNakl == 0 || ri.AngNakl == 180)
                                //&&	Array.IndexOf(prof,ri.Marking.Replace("#","")) >= 0 
                                )
                            {
                                ri.OperationList.Add(new Operation("DL", 200, "DL_start"));
                                ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 200, "DL_end"));
                            }

                        }
                    }
                    #endregion

                    #endregion Расчет операций для City Pro
                    dtLogs += "\nend ops for city pro " + DateTime.Now.ToString("HH:mm:ss:fff");
                    #region Расчет крепежных башмаков и закладных
                    if (model != null && (drOI.idproductiontype == 1416) && !drOI.IsidconstructiontypeNull() && inRange(drOI.idconstructiontype, 38, 13)) // Витраж City
                    {

                        #region Крайние стойки (рама)
                        foreach (RamaItem ri in model.Rama)
                        {
                            if (ri.IsRack)
                            {
                                int mounts_top = 0; int mounts_bottom = 0;
                                #region Проверяем конец 1
                                if (!ri.BalkaStart.IsRack && ri.Connect1 != SoedType.Korotkoe)
                                {
                                    // Считаем 1
                                    switch (ri.BalkaStart.AngleHorisont)
                                    {
                                        case 0: mounts_top++; break;
                                        case 180: mounts_bottom++; break;
                                        default: break;
                                    }
                                }
                                #endregion
                                #region Проверяем конец 2
                                if (!ri.BalkaEnd.IsRack && ri.Connect2 != SoedType.Korotkoe)
                                {
                                    // Считаем 2
                                    switch (ri.BalkaEnd.AngleHorisont)
                                    {
                                        case 0: mounts_top++; break;
                                        case 180: mounts_bottom++; break;
                                        default: break;
                                    }
                                }
                                #endregion
                                SaveModelCalcForRack_Mounts_City(drOI, model, ri, mounts_top, mounts_bottom);
                            }
                        }
                        #endregion

                        #region Средние стойки (импост)
                        foreach (Impost ri in model.ImpostList)
                        {
                            /*
							if( ri.IsRack )
							{
								int mounts_top = 0; int mounts_bottom = 0;								
								#region Проверяем конец 1
								if( !ri.BalkaStart1.IsRack && !ri.BalkaStart2.IsRack && !ri.BalkaStart.IsRack )
								{
									// Считаем 1
									switch( ri.BalkaStart.AngleHorisont )
									{
										case 0: mounts_top ++; break;
										case 180: mounts_bottom ++; break;
										default: break;
									}
								}
								#endregion
								#region Проверяем конец 2
								if( !ri.BalkaEnd1.IsRack && !ri.BalkaEnd2.IsRack && !ri.BalkaEnd.IsRack )
								{
									// Считаем 2
									switch( ri.BalkaEnd.AngleHorisont )
									{
										case 0: mounts_top ++; break;
										case 180: mounts_bottom ++; break;
										default: break;
									}

								}
								#endregion
								SaveModelCalcForRack_Mounts_City( drOI, model, ri, mounts_top, mounts_bottom );
							}
							*/
                            if (ri.IsRack)
                            {
                                int mounts_top = 0; int mounts_bottom = 0;

                                #region Проверяем конец 1
                                if (!ri.BalkaStart1.IsRack && !ri.BalkaStart2.IsRack && !ri.BalkaStart.IsRack && ri.Connect1 != SoedType.Korotkoe)
                                {
                                    // Считаем 1
                                    switch (ri.BalkaStart1.AngleHorisont)
                                    {
                                        case 0: mounts_top++; break;
                                        case 180: mounts_bottom++; break;
                                        default: break;
                                    }
                                }
                                #endregion

                                #region Проверяем конец 2
                                if (!ri.BalkaEnd1.IsRack && !ri.BalkaEnd2.IsRack && !ri.BalkaEnd.IsRack && ri.Connect2 != SoedType.Korotkoe)
                                {
                                    // Считаем 2
                                    switch (ri.BalkaEnd1.AngleHorisont)
                                    {
                                        case 0: mounts_top++; break;
                                        case 180: mounts_bottom++; break;
                                        default: break;
                                    }

                                }
                                #endregion
                                SaveModelCalcForRack_Mounts_City(drOI, model, ri, mounts_top, mounts_bottom);
                            }
                        }
                        #endregion

                    }
                    #endregion
                    dtLogs += "\nend bashmak and zakl " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion Inicial City Pro

                Err = "8";

                #region Работы + Закладные + Операции IF50 RR, R2R, Татпроф МП-40
                if ((inRange(drOI.idproductiontype, 820, 1644, 1678, 1714, 2074)
                    && inRange(drOI.profsys_name, "Inicial IF50 RR", "Inicial IF50 R2R", "Татпроф МП-40", "Татпроф TFS50 Стойка-стойка встык", "Татпроф TFS50 Стойка-ригель внахлёст"))) // Расчет работ по алюминию IF50RR				
                {
                    dtLogs += "\nstart works+zakl+ops IF50 RR, R2R, Татпроф МП-40 " + DateTime.Now.ToString("HH:mm:ss:fff");
                    #region Маркеры координат закладных, заполнений, доборных элементов с каждой из сторон

                    string op_zakl_left = "Z";
                    string op_zakl_right = "Z";
                    string op_zap_right = "zap_right";
                    string op_zap_left = "zap_left";
                    string op_dop_right = "dop_right";
                    string op_dop_left = "dop_left";
                    string suff_zakl_N = "N";
                    string suff_zakl_V = "V";
                    string op_zakl_cnter_left = "ZN";
                    string op_zakl_cnter_right = "ZV";

                    //MessageBox.Show( "CALC IF50 OPERS" );

                    #endregion

                    #region Артикул крепежа ПП отсечки
                    string pp_mount_marking = "Пластина 38х80х2";
                    #endregion
                    /*
					#region Отладка групп заполнений
					foreach( Glass g in model.GlassList )
					{
						if( !inRange( g.Part, "Г-5", "Г-10", "Г-15" ) )
						{
							continue;
						}
						MessageBox.Show( g.ModelPart.ToString() + "-" + g.Part.ToString() );
						
						
						foreach( GlassItem gi in g )
						{
							MessageBox.Show( gi.AngNakl.ToString() );
						}
					}
					#endregion
								*/
                    string[] racks_if50r2r = {
                        "010101","010110",
                        "010301","010302","010303","010304","010305","010306",
                        "011302","011303","011304"
                        };
                    string[] rails_if50r2r = {
                        "010202","010203","010203-01","010204","010205","010205-01","010206","010206-01","010207","010208"
                        };
                    string[] racks_if50rr = {
                        "010203-01","010203","010204","010205","010205-01","010206","010206-01","010207","010208"
                        };
                    string[] rails_if50rr = {
                        "010202","010203","010203-01","010204","010205","010205-01","010206","010206-01","010207","010208"
                        };
                    string[] rails_MP40 = {
                        "МП-4001_ригель","МП-4002_ригель","МП-4003_ригель",
                        "МП-4004_ригель","МП-4005_ригель","МП-4006_ригель",
                        "МП-4007_ригель","МП-4008_ригель","МП-4009_ригель"
                        };
                    string[] racks_tfs50 = {
                        "F50.01.01","F50.01.02",
                        "F50.01.03","F50.01.04","F50.01.05","F50.01.06","F50.01.07","F50.01.08",
                        "F50.01.09","F50.01.10","F50.01.11","F50.01.12","F50.01.13","F50.01.14","F50.01.15","F50.01.16","F50.01.17","F50.01.18","F50.01.19","F50.01.20","F50.01.21","F50.01.22"
                        };
                    string[] rails_tfs50 = {
                        "F50.01.01","F50.01.02",
                        "F50.01.03","F50.01.04","F50.01.05","F50.01.06","F50.01.07","F50.01.08",
                        "F50.01.09","F50.01.10","F50.01.11","F50.01.12","F50.01.13","F50.01.14","F50.01.15","F50.01.16","F50.01.17","F50.01.18","F50.01.19","F50.01.20","F50.01.21","F50.01.22",
                        "F50.02.01","F50.02.02",
                        "F50.02.03","F50.02.04","F50.02.05","F50.02.06","F50.02.07","F50.02.08",
                        "F50.02.09","F50.02.10","F50.02.11","F50.02.12"
                        };
                    string[] rails_tfs50r = {
                        "F50.02.01","F50.02.02",
                        "F50.02.03","F50.02.04","F50.02.05","F50.02.06","F50.02.07","F50.02.08",
                        "F50.02.09","F50.02.10","F50.02.11","F50.02.12"
                        };

                    Err = "21";
                    #region Работы + Закладные + Операции 
                    // Количество стоек
                    int quStoek = 0;
                    // Количество ригелей
                    int quRigel = 0;

                    decimal oiSquare = 0;

                    oiSquare = drOI.width * drOI.height / 1000000;
                    dtLogs += "\nstart ramaItemCycle " + DateTime.Now.ToString("HH:mm:ss:fff");
                    //Балки рамы
                    foreach (RamaItem ri in model.Rama)
                    {
                        bool inverse = ri.AngleHorisont == 270;
                        double sign = 1;
                        if (inverse) sign = -1;

                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        else
                        {
                            if ((ri.AngNakl == 90) || (ri.AngNakl == 270))
                            {
                                quStoek++;
                            }
                            else
                            {
                                quRigel++;
                            }

                            #region Добавление операций на балку рамы, по координатам прилегающих импостов, а также на края, там ведь тоже закладные
                            int impCnt = 0;
                            foreach (double i_ in ri.ImpostPositionListDoubleInterface)
                            {
                                double i = Math.Round(i_, 3);
                                if (i < 0 || i > ri.Lenght || ri.ImpostList.Count == 0) continue;
                                Impost imp = (Impost)ri.ImpostList[impCnt];
                                if (imp != null && !imp.Marking.ToLower().Contains("без"))
                                {
                                    Operation op;

                                    //									if(Atechnology.ecad.Settings.people_admin)
                                    //									{
                                    op = new Operation(op_zakl_right + imp.G + suff_zakl_V, (double)i, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    //									}
                                    //									else
                                    //									{
                                    //										op = new Operation( op_zakl_right,(double)i,imp.Tag4 + " [" + imp.Marking.Replace("#","") + "]",(double)i,(double)i);
                                    //									}

                                    //Operation op = new Operation( op_zakl_right,(double)i,imp.Tag4 + " [" + imp.Marking.Replace("#","") + "]",(double)i,(double)i);
                                    ri.OperationList.Add(op);

                                    //									MessageBox.Show( "ADDING: " + op_zakl_right );
                                }
                                impCnt++;
                            }
                            dtLogs += "\nend ImpostPositionListDoubleInterface " + DateTime.Now.ToString("HH:mm:ss:fff");
                            if (ri.IsRack)
                            {
                                int railCnt = 0;
                                foreach (double i_ in ri.RailPositionListDoubleInterface)
                                {
                                    double i = Math.Round(i_, 3);
                                    if (i < 0 || i > ri.Lenght || ri.RailList.Count == 0) continue;

                                    Balka b = (Balka)ri.RailList[railCnt];

                                    if (b != null && b.Side == ItemSide.Bottom) { i += sign * b.A / 2; } else { i -= sign * b.A / 2; }

                                    if (b != null && !b.Marking.ToLower().Contains("без"))
                                    {
                                        Operation op;
                                        //										if(Atechnology.ecad.Settings.people_admin)
                                        //										{
                                        op = new Operation(op_zakl_right + b.G + suff_zakl_V, (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        //										}
                                        //										else
                                        //										{
                                        //											op = new Operation( op_zakl_right + "",(double)i,b.Tag4 + " [" + b.Marking.Replace("#","") + "]",(double)i,(double)i);
                                        //										}
                                        ri.OperationList.Add(op);

                                        if (ri.Side == ItemSide.Left)
                                        {
                                            op = new Operation(op_zakl_cnter_left, (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                            ri.OperationList.Add(op);
                                        }
                                        if (ri.Side == ItemSide.Right)
                                        {
                                            op = new Operation(op_zakl_cnter_right, (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                            ri.OperationList.Add(op);
                                        }

                                    }
                                    railCnt++;
                                }
                                dtLogs += "\nend RailPositionListDoubleInterface " + DateTime.Now.ToString("HH:mm:ss:fff");
                            }
                            if (ri.IsRack
                                &&
                                ri.LengthInterfaceCalc > 60
                                &&
                                (
                                Array.IndexOf(racks_if50r2r, ri.Marking.Replace("#", "")) >= 0
                                ||
                                Array.IndexOf(racks_if50rr, ri.Marking.Replace("#", "")) >= 0
                                ||
                                Array.IndexOf(racks_tfs50, ri.Marking.Replace("#", "")) >= 0
                                )
                                )
                            {
                                // Крайние дырки для крепления опорных башмаков или продолжения следующей стойки
                                // SSA	15 мм от края стойки (от обоих)
                                // SSB	30 мм от края стойки (от обоих)
                                if (ri.Connect1 == SoedType.Dlinnoe)
                                {
                                    ri.OperationList.Add(new Operation("SSA", 15, "SSA_begin"));
                                    ri.OperationList.Add(new Operation("SSB", 30, "SSB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Dlinnoe)
                                {
                                    ri.OperationList.Add(new Operation("SSA", ri.LengthInterfaceCalc - 15, "SSA_end"));
                                    ri.OperationList.Add(new Operation("SSB", ri.LengthInterfaceCalc - 30, "SSB_end"));
                                }
                            }
                            else if (ri.IsRail
                                &&
                                drOI.idprofsys == 128
                                &&
                                ri.LengthInterfaceCalc > 66
                                &&
                                Array.IndexOf(rails_if50r2r, ri.Marking.Replace("#", "")) >= 0
                                )
                            {
                                //								SRA1	9 мм от края балки (от обоих)
                                //								SRB1	9 мм от края балки (от обоих)
                                //								SRA2	33 мм от края балки (от обоих)
                                //								SRB2	33 мм от края балки (от обоих)

                                //								FRL	0 мм от края балки (от обоих)
                                //								FRR	0 мм от края балки (от обоих)

                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", 9, "SRA_begin"));
                                    ri.OperationList.Add(new Operation("SRB", 9, "SRB_begin"));
                                    ri.OperationList.Add(new Operation("SRA", 33, "SRA_begin"));
                                    ri.OperationList.Add(new Operation("SRB", 33, "SRB_begin"));

                                    //ri.OperationList.Add(new Operation("FRL", 0, "FRL_begin"))

                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", ri.LengthInterfaceCalc - 9, "SRA_end"));
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 9, "SRB_end"));
                                    ri.OperationList.Add(new Operation("SRA", ri.LengthInterfaceCalc - 33, "SRA_end"));
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 33, "SRB_end"));

                                    //ri.OperationList.Add(new Operation("FRR", ri.LengthInterfaceCalc, "FRR_end"));
                                }
                            }
                            else if (ri.IsRail
                                &&
                                drOI.idprofsys == 120
                                &&
                                ri.LengthInterfaceCalc > 36
                                &&
                                Array.IndexOf(rails_if50rr, ri.Marking.Replace("#", "")) >= 0
                                )
                            {
                                //								SRA3	18 мм от края балки (от обоих)
                                //								SRB3	18 мм от края балки (от обоих)
                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", 18, "SRA_begin"));
                                    ri.OperationList.Add(new Operation("SRB", 18, "SRB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", ri.LengthInterfaceCalc - 18, "SRA_end"));
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 18, "SRB_end"));
                                }
                            }

                            else if (ri.IsRail
                                &&
                                drOI.idprofsys == 157
                                &&
                                ri.LengthInterfaceCalc > 36
                                &&
                                Array.IndexOf(rails_MP40, ri.Marking.Replace("#", "")) >= 0)
                            {
                                if (ri.Connect1 == SoedType.Dlinnoe)
                                {
                                    ri.OperationList.Add(new Operation("SSA", 30, "SSA_begin"));
                                    ri.OperationList.Add(new Operation("SSB", 30, "SSB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Dlinnoe)
                                {
                                    ri.OperationList.Add(new Operation("SSA", ri.LengthInterfaceCalc - 30, "SSA_end"));
                                    ri.OperationList.Add(new Operation("SSB", ri.LengthInterfaceCalc - 30, "SSB_end"));
                                }
                            }
                            else if (ri.IsRail
                                 &&
                                 (drOI.idprofsys == 212 || drOI.idprofsys == 214)
                                 &&
                                 ri.LengthInterfaceCalc > 36
                                 &&
                                 Array.IndexOf(rails_tfs50, ri.Marking.Replace("#", "")) >= 0
                                 )
                            {
                                //								SRA3	18 мм от края балки (от обоих)
                                //								SRB3	18 мм от края балки (от обоих) 
                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRB", 28.8, "SRB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 28.8, "SRB_end"));
                                }
                            }
                            else if (ri.IsRail
                                &&
                                (drOI.idprofsys == 212 || drOI.idprofsys == 214)
                                &&
                                ri.LengthInterfaceCalc > 36
                                &&
                                Array.IndexOf(rails_tfs50r, ri.Marking.Replace("#", "")) >= 0
                                )
                            {
                                //								SRA3	18 мм от края балки (от обоих)
                                //								SRB3	18 мм от края балки (от обоих) rails_tfs50r
                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRB", 43.8, "SRB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 43.8, "SRB_end"));
                                }
                            }
                            dtLogs += "\nend addOpsOn isRack " + DateTime.Now.ToString("HH:mm:ss:fff");


                            #endregion

                            #region Добавление операций по списку прилегающих заполнений
                            foreach (ModelPartClass mpc in ri.PartTypeList)
                            {
                                #region для прилегающих заполнений
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Glass g = mpc.Glass;

                                    //									if( ri.ID==7 )
                                    //									{
                                    //										MessageBox.Show( g.Marking + ", thick=" + g.Thickness.ToString() + ", ramalen=" + ri.Lenght.ToString() + ", glasspart=" + g.Part + ". c_start=" + mpc.FillStart.ToString() );
                                    //									}
                                    string shtg = mpc.ShtapicGroup;
                                    if (g != null)
                                    {
                                        double aFrom = 0; double aTo = 0;
                                        fillModelPartClass_FromTo(ri, mpc, ref aFrom, ref aTo);
                                        //string side = getSideRussian( ri );
                                        Operation op = new Operation(op_zap_right, ri.ID, g.Part + " [" + g.Marking + "] ", aFrom, aTo);
                                        op.X1_Double = aFrom;
                                        op.X2_Double = aTo;
                                        ri.OperationList.Add(op);

                                        #region Расчет крепежей ПП отсечки
                                        UserParam up = g.GetUserParam("Противопожарная отсечка");
                                        if (up != null && up.StrValue == "Да")
                                        {
                                            // https://servicedesk.it-swarm.pro/browse/DEV-12198
                                            // программа должна автоматически рассчитать металлические пластины 80*38*2 оцинкованные  с шагом 250 мм с округлением в большую сторону и прибавлением еще 1 штуки
                                            int quPPmount = roundToMax(Math.Abs(aFrom - aTo) / 250) + 1;
                                            ds_order.modelcalcRow rr = drOI.AddModelcalc(pp_mount_marking, quPPmount);
                                            rr.modelpart = ri.Tag4 + " [" + ri.Marking.Replace("#", "") + "]";
                                        }
                                        #endregion


                                        #region Добавление операций по материалам, устанавливаемым на сторону балки согласно группы заполнения, если таковая есть
                                        if (shtg != "")
                                        {
                                            string[] a = shtg.Split(';');
                                            if (a.Length > 0)
                                            {
                                                // Берем первую группу заполнений из списка
                                                int idShtapicGroup = Useful.GetInt32(a[0], 0);

                                                decimal zap_Depth = 0;

                                                string[] markings = { }; decimal[] delta = { }; decimal[] coeff = { };
                                                //												if(Atechnology.ecad.Settings.idpeople == 434  )
                                                //												{
                                                //													MessageBox.Show("  idShtapicGroup=" + idShtapicGroup
                                                //														+ " g.Thickness= " + g.Thickness  + " ri.Marking= " + ri.Marking + " ri.Lenght= " + ri.Lenght.ToString() + " ri.BalkaType=" + ri.BalkaType + " ri.Side=" + ri.Side);
                                                //												}

                                                if (getShtapicGroupDetail2(idShtapicGroup, g.Thickness, ri.Marking, ref markings, ref delta, ref coeff, ref zap_Depth))
                                                {
                                                    dtLogs += "\nafter getShtapicGroupDetail2 " + DateTime.Now.ToString("HH:mm:ss:fff");

                                                    int i = 0;
                                                    decimal d = delta[i];
                                                    decimal k = coeff[i];
                                                    foreach (string mark in markings)
                                                    {
                                                        //	MessageBox.Show( "ПР: Mark=" + mark + ", r_mark=" + ri.Marking + ", ri_len=" + ri.LengthInterfaceCalcInt +"\n\n ID" + ri.ID + " " + ri.Tag + " " + ri.Tag2 + " " + ri.Tag3 + " " + ri.Tag4 + " ");
                                                        op = new Operation(op_dop_right, ri.ID, mark + " [" + g.Part + "] ", aFrom, aTo);
                                                        //MessageBox.Show( "aFrom=" + aFrom.ToString() + ", aTo=" + aTo.ToString() + ", mark=" + mark + ", delta=" + d.ToString() + ", k=" + k.ToString() );
                                                        op.X = Useful.GetInt32((double)k * (aTo - aFrom + (double)d), 0);
                                                        op.X1_Double = aFrom - (double)d / 2;
                                                        op.X2_Double = aTo + (double)d / 2;
                                                        ri.OperationList.Add(op);
                                                        i++;
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                #endregion для прилегающих заполнений														
                            }
                            dtLogs += "\nend glass cycle " + DateTime.Now.ToString("HH:mm:ss:fff");

                            #endregion

                            #region Добавление операции по доборным профилям (компенсаторам) с внешней стороны рамы (в проем), сторона = ЛЕВАЯ
                            //							MessageBox.Show( ri.Insertions );
                            string[] insertionlist = ri.Insertions.Split(';');
                            foreach (string insertionid in insertionlist)
                            {
                                int idinsertion = Useful.GetInt32(insertionid, 0);
                                if (idinsertion != 0)
                                {
                                    string[] markings = { }; decimal[] delta = { }; decimal[] coeff = { };
                                    if (getInsertionDetail(idinsertion, ref markings, ref delta, ref coeff))
                                    {
                                        int i = 0;
                                        decimal d = delta[i];
                                        decimal k = coeff[i];
                                        foreach (string mark in markings)
                                        {
                                            Operation op = new Operation(op_dop_left, ri.ID, mark, 0, ri.Lenght);
                                            op.X = Useful.GetInt32((double)k * (ri.Lenght + (double)d), 0);
                                            op.X1_Double = 0;
                                            op.X2_Double = ri.Lenght;
                                            ri.OperationList.Add(op);
                                            i++;
                                        }
                                    }
                                }
                            }
                            dtLogs += "\nend add ops po dobor on RamAitem " + DateTime.Now.ToString("HH:mm:ss:fff");
                            #endregion
                        }

                    }
                    dtLogs += "\nend RamaItem cycle+StartImpostCycle " + DateTime.Now.ToString("HH:mm:ss:fff");
                    //Балки имостов
                    foreach (Impost ri in model.ImpostList)
                    {
                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        else
                        {
                            if ((ri.AngNakl == 90) || (ri.AngNakl == 270))
                            {
                                quStoek++;
                            }
                            else
                            {
                                quRigel++;
                            }

                            #region Добавление операций по установке закладных на балки импостов (средних ригелей и стоек), по координатам прилегающих балок, а также на краях (длинные соединения)
                            int impCnt = 0;
                            foreach (double i_ in ri.ImpostPositionListDoubleInterface)
                            {
                                double i = Math.Round(i_, 3);
                                if (i < 0 || i > ri.Lenght || ri.ImpostList.Count == 0) continue;

                                Impost imp = (Impost)ri.ImpostList[impCnt];
                                if (imp != null && !imp.Marking.ToLower().Contains("без") && ri.AngNakl != imp.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                {
                                    Operation op;
                                    //op = new Operation(op_zakl_right + imp.G + suff_zakl_V, (double)i, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    //ri.OperationList.Add(op);

                                    op = new Operation(op_zakl_cnter_right, (double)i, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    ri.OperationList.Add(op);
                                }
                                impCnt++;
                            }
                            if (ri.IsRack)
                            {

                                int railCnt = 0;
                                foreach (double i_ in ri.RailPositionListDoubleInterface)
                                {
                                    double i = Math.Round(i_, 3);
                                    if (i < 0 || i > ri.Lenght || ri.RailsList.Count == 0) continue;

                                    Balka b = (Balka)ri.RailsList[railCnt];
                                    if (b != null && b.Side == ItemSide.Bottom) { i += b.A / 2; } else { i -= b.A / 2; }

                                    if (b != null && !b.Marking.ToLower().Contains("без") && ri.AngNakl != b.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                    {
                                        //MessageBox.Show( "RailNo: " + railCnt.ToString() + ", OPER=" + op_zakl_left + ", i=" + i.ToString() + ", Info=" + getBalkaIndex(b) + " [" + b.Marking.Replace("#","") + "]" );
                                        Operation op;
                                        //op = new Operation(op_zakl_right + b.G + suff_zakl_V, (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        //ri.OperationList.Add(op);

                                        op = new Operation(op_zakl_cnter_right, (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        ri.OperationList.Add(op);
                                    }
                                    railCnt++;
                                }
                            }


                            impCnt = 0;
                            foreach (double i_ in ri.ImpostPositionListDouble2Interface)
                            {
                                double i = Math.Round(i_, 3);
                                if (i < 0 || i > ri.Lenght) continue;

                                Impost imp = (Impost)ri.ImpostList2[impCnt];
                                if (imp != null && !imp.Marking.ToLower().Contains("без") && ri.AngNakl != imp.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                {
                                    Operation op;
                                    //op = new Operation(op_zakl_left + imp.G + suff_zakl_N, (double)i, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    //ri.OperationList.Add(op);

                                    op = new Operation(op_zakl_cnter_left, (double)i, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    ri.OperationList.Add(op);
                                }
                                impCnt++;
                            }
                            if (ri.IsRack)
                            {

                                int railCnt = 0;
                                foreach (double i_ in ri.RailPositionListDouble2Interface)
                                {
                                    double i = Math.Round(i_, 3);
                                    if (i < 0 || i > ri.Lenght || ri.RailsList2.Count == 0) continue;
                                    Balka b = (Balka)ri.RailsList2[railCnt];
                                    if (b != null && b.Side == ItemSide.Bottom) { i += b.A / 2; } else { i -= b.A / 2; }
                                    if (b != null && !b.Marking.ToLower().Contains("без") && ri.AngNakl != b.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                    {
                                        Operation op;
                                        //op = new Operation(op_zakl_left + b.G + suff_zakl_N, (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        //ri.OperationList.Add(op);
                                        op = new Operation(op_zakl_cnter_left, (double)i, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        ri.OperationList.Add(op);
                                    }
                                    railCnt++;
                                }
                            }

                            #endregion
                            
                            #region Инициализация массива координат прилегающих заполнений для поиска пересечений диапазонов при расчете монтажных ПП отсечек
                            bool[] balka_zap = new bool[ri.LengthInterfaceCalcInt + 1];
                            #endregion
                            dtLogs += "\nstart impost glass cycle left " + DateTime.Now.ToString("HH:mm:ss:fff");
                            #region Добавление операций по списку прилегающих заполнений. Слева
                            // Слева
                            foreach (ModelPartClass mpc in ri.PartTypeList)
                            {
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Glass g = mpc.Glass;

                                    if (g != null)
                                    {
                                        double aFrom = 0; double aTo = 0;
                                        fillModelPartClass_FromTo(ri, mpc, ref aFrom, ref aTo);
                                        Operation op = new Operation(op_zap_left, ri.ID, g.Part + " [" + g.Marking + "]", aFrom, aTo);
                                        op.X1_Double = aFrom;
                                        op.X2_Double = aTo;
                                        ri.OperationList.Add(op);

                                        #region Расчет крепежей ПП отсечки
                                        UserParam up = g.GetUserParam("Противопожарная отсечка");
                                        if (up != null && up.StrValue == "Да")
                                        {
                                            fillArrayFromTo(ref balka_zap, (int)aFrom, (int)aTo, true);
                                            dtLogs += "\nafter fill array from to " + DateTime.Now.ToString("HH:mm:ss:fff");
                                        }
                                        #endregion

                                        #region Добавление операций по материалам, устанавливаемым на сторону балки согласно группы заполнения, если таковая есть
                                        if (mpc.ShtapicGroup != "")
                                        {
                                            string[] a = mpc.ShtapicGroup.Split(';');
                                            if (a.Length > 0)
                                            {
                                                // Берем первую группу заполнений из списка
                                                int idShtapicGroup = Useful.GetInt32(a[0], 0);

                                                decimal zap_Depth = 0;

                                                string[] markings = { }; decimal[] delta = { }; decimal[] coeff = { };
                                                if (getShtapicGroupDetail2(idShtapicGroup, g.Thickness, ri.Marking, ref markings, ref delta, ref coeff, ref zap_Depth))
                                                {
                                                    int i = 0;
                                                    decimal d = delta[i];
                                                    decimal k = coeff[i];
                                                    foreach (string mark in markings)
                                                    {
                                                        op = new Operation(op_dop_left, ri.ID, mark + " [" + g.Part + "] ", aFrom, aTo);
                                                        //MessageBox.Show( "aFrom=" + aFrom.ToString() + ", aTo=" + aTo.ToString() + ", mark=" + mark + ", delta=" + d.ToString() + ", k=" + k.ToString() );
                                                        op.X = Useful.GetInt32((double)k * (aTo - aFrom + (double)d), 0);
                                                        op.X1_Double = aFrom - (double)d / 2;
                                                        op.X2_Double = aTo + (double)d / 2;
                                                        ri.OperationList.Add(op);
                                                        i++;
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    dtLogs += "\nend impostCyle iteration " + DateTime.Now.ToString("HH:mm:ss:fff");
                                }
                            }
                            #endregion
                            dtLogs += "\nstart impost cycle right " + DateTime.Now.ToString("HH:mm:ss:fff");
                            #region Добавление операций по списку прилегающих заполнений. Справа
                            // Справа
                            foreach (ModelPartClass mpc in ri.PartTypeList2)
                            {
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Glass g = mpc.Glass;
                                    if (g != null)
                                    {
                                        double aFrom = 0; double aTo = 0;
                                        fillModelPartClass_FromTo(ri, mpc, ref aFrom, ref aTo);
                                        Operation op = new Operation(op_zap_right, ri.ID, g.Part + " [" + g.Marking + "]", aFrom, aTo);
                                        op.X1_Double = aFrom;
                                        op.X2_Double = aTo;
                                        ri.OperationList.Add(op);

                                        #region Расчет крепежей ПП отсечки
                                        UserParam up = g.GetUserParam("Противопожарная отсечка");
                                        if (up != null && up.StrValue == "Да")
                                        {
                                            fillArrayFromTo(ref balka_zap, (int)aFrom, (int)aTo, true);
                                        }
                                        #endregion

                                        #region Добавление операций по материалам, устанавливаемым на сторону балки согласно группы заполнения, если таковая есть
                                        if (mpc.ShtapicGroup != "")
                                        {
                                            string[] a = mpc.ShtapicGroup.Split(';');
                                            if (a.Length > 0)
                                            {
                                                // Берем первую группу заполнений из списка
                                                int idShtapicGroup = Useful.GetInt32(a[0], 0);

                                                decimal zap_Depth = 0;

                                                string[] markings = { }; decimal[] delta = { }; decimal[] coeff = { };
                                                if (getShtapicGroupDetail2(idShtapicGroup, g.Thickness, ri.Marking, ref markings, ref delta, ref coeff, ref zap_Depth))
                                                {
                                                    int i = 0;
                                                    decimal d = delta[i];
                                                    decimal k = coeff[i];
                                                    foreach (string mark in markings)
                                                    {
                                                        op = new Operation(op_dop_right, ri.ID, mark + " [" + g.Part + "] ", aFrom, aTo);
                                                        op.X = Useful.GetInt32((double)k * (aTo - aFrom + (double)d), 0);
                                                        op.X1_Double = aFrom - (double)d / 2;
                                                        op.X2_Double = aTo + (double)d / 2;
                                                        ri.OperationList.Add(op);
                                                        i++;
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                            dtLogs += "\nend impost cycle right " + DateTime.Now.ToString("HH:mm:ss:fff");
                            #region SRA/SRB 
                            if (ri.IsRack
                                &&
                                ri.LengthInterfaceCalc > 60
                                &&
                                (
                                Array.IndexOf(racks_if50r2r, ri.Marking.Replace("#", "")) >= 0
                                ||
                                Array.IndexOf(racks_if50rr, ri.Marking.Replace("#", "")) >= 0
                                 ||
                                Array.IndexOf(racks_tfs50, ri.Marking.Replace("#", "")) >= 0
                                )
                                )
                            {//FDD
                             // Крайние дырки для крепления опорных башмаков или продолжения следующей стойки
                             // SSA	15 мм от края стойки (от обоих)
                             // SSB	30 мм от края стойки (от обоих)
                                if (ri.Connect1 == SoedType.Dlinnoe)
                                {
                                    ri.OperationList.Add(new Operation("SSA", 15, "SSA_begin"));
                                    ri.OperationList.Add(new Operation("SSB", 30, "SSB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Dlinnoe)
                                {
                                    ri.OperationList.Add(new Operation("SSA", ri.LengthInterfaceCalc - 15, "SSA_end"));
                                    ri.OperationList.Add(new Operation("SSB", ri.LengthInterfaceCalc - 30, "SSB_end"));
                                }
                            }
                            else if (ri.IsRail
                                &&
                                drOI.idprofsys == 128
                                &&
                                ri.LengthInterfaceCalc > 66
                                &&
                                Array.IndexOf(rails_if50r2r, ri.Marking.Replace("#", "")) >= 0
                                )
                            {
                                //								SRA1	9 мм от края балки (от обоих)
                                //								SRB1	9 мм от края балки (от обоих)
                                //								SRA2	33 мм от края балки (от обоих)
                                //								SRB2	33 мм от края балки (от обоих)

                                //								FRL	0 мм от края балки (от обоих)
                                //								FRR	0 мм от края балки (от обоих)

                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", 9, "SRA_begin"));
                                    ri.OperationList.Add(new Operation("SRB", 9, "SRB_begin"));
                                    ri.OperationList.Add(new Operation("SRA", 33, "SRA_begin"));
                                    ri.OperationList.Add(new Operation("SRB", 33, "SRB_begin"));

                                    //ri.OperationList.Add(new Operation("FRR", 0, "FRR_begin"));
                                    //ri.OperationList.Add(new Operation("FRL", 0, "FRL_begin"));

                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", ri.LengthInterfaceCalc - 9, "SRA_end"));
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 9, "SRB_end"));
                                    ri.OperationList.Add(new Operation("SRA", ri.LengthInterfaceCalc - 33, "SRA_end"));
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 33, "SRB_end"));

                                    //ri.OperationList.Add(new Operation("FRR", ri.LengthInterfaceCalc, "FRR_end"));
                                    //ri.OperationList.Add(new Operation("FRL", ri.LengthInterfaceCalc, "FRL_end"));
                                }
                            }
                            else if (ri.IsRail
                                &&
                                drOI.idprofsys == 120
                                &&
                                ri.LengthInterfaceCalc > 36
                                &&
                                Array.IndexOf(rails_if50rr, ri.Marking.Replace("#", "")) >= 0
                                )
                            {
                                //								SRA3	18 мм от края балки (от обоих)
                                //								SRB3	18 мм от края балки (от обоих)
                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", 18, "SRA_begin"));
                                    ri.OperationList.Add(new Operation("SRB", 18, "SRB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", ri.LengthInterfaceCalc - 18, "SRA_end"));
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 18, "SRB_end"));
                                }
                            }
                            else if (ri.IsRail
                                &&
                                drOI.idprofsys == 157
                                &&
                                ri.LengthInterfaceCalc > 36
                                &&
                                Array.IndexOf(rails_MP40, ri.Marking.Replace("#", "")) >= 0
                                )
                            {
                                //if( Atechnology.ecad.Settings.idpeople == 434 ) MessageBox.Show("Ригель + " +ri.Marking + " ri.ID=" + ri.ID + " SRA" + " ri.Connect1=" + ri.Connect1 + " ri.Connect2=" + ri.Connect2); 
                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", 30, "SRA_begin"));
                                    ri.OperationList.Add(new Operation("SRB", 30, "SRB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRA", ri.LengthInterfaceCalc - 30, "SRA_end"));
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 30, "SRB_end"));
                                }
                            }
                            else if (ri.IsRail
                                &&
                                (drOI.idprofsys == 212 || drOI.idprofsys == 214)
                                &&
                                ri.LengthInterfaceCalc > 36
                                &&
                                Array.IndexOf(rails_tfs50r, ri.Marking.Replace("#", "")) >= 0
                                )
                            {
                                //								SRA3	18 мм от края балки (от обоих)
                                //								SRB3	18 мм от края балки (от обоих) rails_tfs50r
                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRB", 43.8, "SRB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 43.8, "SRB_end"));
                                }
                            }
                            else if (ri.IsRail
                                &&
                                (drOI.idprofsys == 212 || drOI.idprofsys == 214)
                                &&
                                ri.LengthInterfaceCalc > 36
                                &&
                                Array.IndexOf(rails_tfs50, ri.Marking.Replace("#", "")) >= 0
                                )
                            {
                                //								SRA3	18 мм от края балки (от обоих)
                                //								SRB3	18 мм от края балки (от обоих) rails_tfs50r
                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRB", 43.8, "SRB_begin"));
                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    ri.OperationList.Add(new Operation("SRB", ri.LengthInterfaceCalc - 43.8, "SRB_end"));
                                }
                            }
                            #endregion SRA/SRB
                            dtLogs += "\nend SBA/SRB " + DateTime.Now.ToString("HH:mm:ss:fff");
                            if (1 == 1 /* || Atechnology.ecad.Settings.idpeople == 168 */ )
                            {
                                Err = "22.00. LiCalc=" + ri.LengthInterfaceCalcInt + ". BZ_LEN=" + balka_zap.Length;
                                #region Обработка массива прилегающих ПП отсечек слева + справа
                                int idx_begin = -1; int idx_end = -1;
                                for (int i = 0; i < ri.LengthInterfaceCalcInt; i++)
                                {
                                    if (balka_zap[i]) // Если тут есть ПП отсечка
                                    {
                                        if (idx_begin == -1)
                                        {
                                            idx_begin = i; // Диапазон только начался, установим индекс стартовой координаты
                                        }
                                        else
                                        {
                                            idx_end = i; // Диапазон ранее начат, значит сдвигаем конец
                                        }
                                    }
                                    else // На данной координате нет ПП отсечки
                                    {
                                        if (idx_begin == -1)
                                        {
                                        }
                                        else
                                        {
                                            // Диапазон закончился, надо сохранить данные

                                            int quPPmount = roundToMax(((double)idx_end - (double)idx_begin) / 250) + 1;

                                            if (quPPmount > 0)
                                            {
                                                ds_order.modelcalcRow rr = drOI.AddModelcalc(pp_mount_marking, quPPmount);
                                                rr.modelpart = ri.Tag4 + " [" + ri.Marking.Replace("#", "") + "]";
                                            }

                                            idx_begin = -1; idx_end = -1; // Обнуляем начало и конец
                                        }
                                    }
                                }
                                if (idx_begin != -1)
                                {
                                    idx_end = ri.LengthInterfaceCalcInt;
                                    int quPPmount = roundToMax(((double)idx_end - (double)idx_begin) / 250) + 1;

                                    if (quPPmount > 0)
                                    {
                                        ds_order.modelcalcRow rr = drOI.AddModelcalc(pp_mount_marking, quPPmount);
                                        rr.modelpart = ri.Tag4 + " [" + ri.Marking.Replace("#", "") + "]";
                                    }
                                }
                                #endregion
                            }
                        }
                        dtLogs += "\nend  impost big cycle " + DateTime.Now.ToString("HH:mm:ss:fff");
                    }
                    #endregion Работы Inicial IF50RR
                    dtLogs += "\nend   works+zakl+ops IF50 RR, R2R, Татпроф МП-40  " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion

                Err = "23.01.0";
                #region Работы + Закладные IP45 + Опоры заполнения и опоры притвора
                if (!drOI.IsidprofsysNull() && drOI.idprofsys == 122 && model != null) // Расчет работ по алюминию IP45				
                {
                    #region Тест сохранения координат закладных с каждой из сторон

                    string op_zakl_left = "zl";
                    string op_zakl_right = "zr";

                    #endregion
                    Err = "23";
                    #region Работы Inicial IP45
                    //Кол-во балок
                    int quBeem = 0;
                    //Кол-во закладных
                    int quZakl = 0;
                    //Упл. в раму
                    int quUplRam = 0;
                    //Упл. в створку
                    int quUplStv = 0;
                    //Фрезеровка под ручку
                    int quHandle = 0;
                    //Проверка фальцлюфта
                    int quFalz = 0;
                    //установка фурнитуры
                    int quFurn = 0;
                    //резка штапика
                    int quShtap = 0;
                    //установка заполнений
                    int quZap = 0;
                    //провис створки
                    int quProvis = 0;
                    // quUplRam++;
                    //Балки рамы
                    foreach (RamaItem ri in model.Rama)
                    {

                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        else
                        {
                            quBeem++;

                            #region Добавление операций на балку рамы, по координатам прилегающих импостов, а также на края, там ведь тоже закладные
                            int impCnt = 0;
                            foreach (double i_ in ri.ImpostPositionListDoubleInterface)
                            {
                                double i = Math.Round(i_, 3);

                                Impost imp = (Impost)ri.ImpostList[impCnt];
                                if (imp != null && !imp.Marking.ToLower().Contains("без"))
                                {
                                    Operation op = new Operation(op_zakl_right, (double)i, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    ri.OperationList.Add(op);
                                }
                                impCnt++;
                            }
                            //MessageBox.Show( ri.Variants );
                            Balka bs = ri.BalkaStart;
                            Balka be = ri.BalkaEnd;

                            if (bs != null && !bs.Marking.ToLower().Contains("без") && ri.Connect1 == SoedType.Dlinnoe)
                            {
                                Operation op = new Operation(op_zakl_right, 0, bs.Tag4 + " [" + bs.Marking.Replace("#", "") + "]", 0, 0);
                                ri.OperationList.Add(op);
                            }

                            if (be != null && !be.Marking.ToLower().Contains("без") && ri.Connect2 == SoedType.Dlinnoe)
                            {
                                Operation op = new Operation(op_zakl_right, ri.LengthDouble, be.Tag4 + " [" + be.Marking.Replace("#", "") + "]", ri.LengthDouble, ri.LengthDouble);
                                ri.OperationList.Add(op);
                            }
                            #endregion

                        }
                    }

                    foreach (RamaItem ri in model.Rama)
                    {

                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        if (ri.RamaType == RamaType.Porog)
                        {
                            quZakl = 2;
                            break;
                        }
                        else
                        {
                            quZakl = 4;
                        }
                    }

                    foreach (Stvorka s in model.StvorkaList)
                    {
                        quUplStv++; // Уплотнитель на створку 1шт = притворный
                        quFalz++;
                        quFurn++;
                        quProvis++;
                        quUplRam++; // На каждую створку на раме 1шт уплотнитель = притворный
                        if (s.HandlePosition > 0 && s.Shtulp == null)
                        {
                            quHandle++;
                        }
                        //Балки створки
                        foreach (StvorkaItem si in s)
                        {
                            if (si.Marking.ToLower().Contains("без"))
                                continue;
                            quBeem++;
                            quZakl++;
                        }
                    }

                    foreach (Impost i in model.ImpostList)
                    {
                        //Балки импоста
                        if (i.Marking.ToLower().Contains("без") || i.ImpostType == ImpostType.Shtulp)
                            continue;
                        quBeem++;
                        quZakl += 2;

                        Impost ri = i;

                        #region Добавление операций по установке закладных на балки импостов (средних ригелей и стоек), по координатам прилегающих балок, а также на краях (длинные соединения)
                        int impCnt = 0;
                        foreach (double i0_ in ri.ImpostPositionListDoubleInterface)
                        {
                            double i0 = Math.Round(i0_, 3);

                            Impost imp = (Impost)ri.ImpostList[impCnt];
                            if (imp != null && !imp.Marking.ToLower().Contains("без"))
                            {
                                //Operation op = new Operation(op_zakl_left, (double)i0, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i0, (double)i0);
                                //ri.OperationList.Add(op);
                            }
                            impCnt++;
                        }

                        if (ri.BalkaStart1 != null && !ri.BalkaStart1.Marking.ToLower().Contains("без") && ri.Connect1 == SoedType.Dlinnoe)
                        {
                            //Operation op = new Operation(op_zakl_left, 0, ri.BalkaStart1.Tag4 + " [" + ri.BalkaStart1.Marking.Replace("#", "") + "]", 0, 0);
                            //ri.OperationList.Add(op);
                        }

                        if (ri.BalkaEnd1 != null && !ri.BalkaEnd1.Marking.ToLower().Contains("без") && ri.Connect2 == SoedType.Dlinnoe)
                        {
                            //Operation op = new Operation(op_zakl_left, ri.LengthDouble, ri.BalkaEnd1.Tag4 + " [" + ri.BalkaEnd1.Marking.Replace("#", "") + "]", ri.LengthDouble, ri.LengthDouble);
                            //ri.OperationList.Add(op);
                        }

                        impCnt = 0;
                        foreach (double i0_ in ri.ImpostPositionListDouble2Interface)
                        {
                            double i0 = Math.Round(i0_, 3);

                            Impost imp = (Impost)ri.ImpostList2[impCnt];
                            if (imp != null && !imp.Marking.ToLower().Contains("без"))
                            {
                                //Operation op = new Operation(op_zakl_right, (double)i0, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i0, (double)i0);
                                //ri.OperationList.Add(op);
                            }
                            impCnt++;
                        }

                        if (ri.BalkaStart2 != null && !ri.BalkaStart2.Marking.ToLower().Contains("без") && ri.Connect1 == SoedType.Dlinnoe)
                        {
                            //Operation op = new Operation(op_zakl_right, 0, ri.BalkaStart2.Tag4 + " [" + ri.BalkaStart2.Marking.Replace("#", "") + "]", 0, 0);
                            //ri.OperationList.Add(op);
                        }

                        if (ri.BalkaEnd2 != null && !ri.BalkaEnd2.Marking.ToLower().Contains("без") && ri.Connect2 == SoedType.Dlinnoe)
                        {
                            //Operation op = new Operation(op_zakl_right, ri.LengthDouble, ri.BalkaEnd2.Tag4 + " [" + ri.BalkaEnd2.Marking.Replace("#", "") + "]", ri.LengthDouble, ri.LengthDouble);
                            //ri.OperationList.Add(op);
                        }
                        #endregion

                    }

                    foreach (Glass g in model.GlassList)
                    {
                        if (g.Marking.ToLower().Contains("без_стекла_и_штапика")) continue;
                        if (!g.Marking.ToLower().Contains("без"))
                        {
                            quZap++;
                        }
                        foreach (GlassItem gi in g)
                        {
                            quShtap++;
                        }

                        if (g.ModelPart == ModelPart.Rama)
                        {
                            quUplRam += 2;
                        }
                        else if (g.ModelPart == ModelPart.Stvorka)
                        {
                            quUplStv += 2; // В СТВОРКАХ УПЛОТНЕНИЯ НЕ ВХОДЯТ В РАБОТЫ..  (с) Бубнов. Вроде снова входят. 19.12.2017
                        }
                    }
                    #endregion
                    dtLogs += "\nend   calc works IP45  " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion

                #region Расчет координат операций IW70
                if (model != null /* && inRange( Atechnology.ecad.Settings.idpeople, 168, 2206 ) */ && !drOI.IsidprofsysNull() && inRange(drOI.idprofsys, 156))
                {
                    dtLogs += "\nstart calc cooed ops IW70 " + DateTime.Now.ToString("HH:mm:ss:fff");
                    string[] doorStvorka = { "031008", "031009", "032008", "032009" };
                    string[] doorRama = { "031010", "031011", "032010", "032011", "032002", "031001", "032002", "032001", "031002" };

                    string[] windowStvorka = { "030748", "030848" };
                    string[] windowRama = { "030803", "030801", "030836", "030812", "030733", "030712", "030703", "030701" };

                    string[] impostsAll = { "030719", "030819", "030722", "030732", "030832", "030822", "030823", "031003", "032003", "030723" };
                    string[] imposts90 = { "030703", "030803" };

                    foreach (RamaItem ri in model.Rama)
                    {
                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        else if (
                            (ri.AngNakl == 0 || ri.AngNakl == 180)
                            && ri.Side == ItemSide.Bottom && ri.RamaType == RamaType.Rama
                            ) // если это нижняя горизонтальная балка
                        {
                            if (Array.IndexOf(doorRama, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                            {
                                //								DL	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 
                                //								DO	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 

                                ri.OperationList.Add(new Operation("DL", 100, "DL_start"));
                                ri.OperationList.Add(new Operation("DO", 100, "DO_start"));
                                ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 100, "DL_end"));
                                ri.OperationList.Add(new Operation("DO", ri.LengthInterfaceCalc - 100, "DO_end"));
                            }
                            else if (Array.IndexOf(windowRama, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                            {
                                //								DL	центр дренажного отверстия	Для горигонтальных балок(только нижние), 100 мм от края створки 
                                //								DO	центр дренажного отверстия	Для горигонтальных балок створок(только нижние), 200 мм от края створки 

                                ri.OperationList.Add(new Operation("DL", 100, "DL_start"));
                                ri.OperationList.Add(new Operation("DO", 200, "DO_start"));
                                ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 100, "DL_end"));
                                ri.OperationList.Add(new Operation("DO", ri.LengthInterfaceCalc - 200, "DO_end"));
                            }
                        }
                    }
                    dtLogs += "\nend RamaItam cycle IW70 " + DateTime.Now.ToString("HH:mm:ss:fff");
                    foreach (Stvorka s in model.StvorkaList)
                    {
                        foreach (StvorkaItem ri in s)
                        {
                            if (ri.Marking.ToLower().Contains("без"))
                            {
                                continue;
                            }
                            else if (
                                (ri.AngNakl == 0 || ri.AngNakl == 180)
                                && ri.Side == ItemSide.Bottom
                                ) // если это нижняя горизонтальная балка
                            {
                                if (Array.IndexOf(doorStvorka, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                                {
                                    //								DL	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 
                                    //								DO	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 

                                    ri.OperationList.Add(new Operation("DL", 200, "DL_start"));
                                    ri.OperationList.Add(new Operation("DO", 200, "DO_start"));
                                    ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 200, "DL_end"));
                                    ri.OperationList.Add(new Operation("DO", ri.LengthInterfaceCalc - 200, "DO_end"));
                                }
                                else if (Array.IndexOf(windowStvorka, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                                {
                                    //								DL	центр дренажного отверстия	Для горигонтальных балок(только нижние), 200 мм от края створки 
                                    //								DO	центр дренажного отверстия	Для горигонтальных балок створок(только нижние), 200 мм от края створки 

                                    ri.OperationList.Add(new Operation("DL", 200, "DL_start"));
                                    ri.OperationList.Add(new Operation("DO", 200, "DO_start"));
                                    ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 200, "DL_end"));
                                    ri.OperationList.Add(new Operation("DO", ri.LengthInterfaceCalc - 200, "DO_end"));
                                }
                            }
                        }
                    }
                    dtLogs += "\nend StvorkaList cycle IW70 " + DateTime.Now.ToString("HH:mm:ss:fff");
                    foreach (Impost ri in model.ImpostList)
                    {
                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        else
                        {
                            if (
                                Array.IndexOf(impostsAll, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0
                                ||
                                (
                                Array.IndexOf(imposts90, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0 && ri.Ang1 == 90 && ri.Ang2 == 90
                                )
                                )
                            {
                                //								FIL	0 мм от края балки (от обоих)	всегда (для артикулов 03 07 03 и 03 07 08 только при соединении 90 градусов)
                                //								FIR	0 мм от края балки (от обоих)	всегда (для артикулов 03 07 03 и 03 07 08 только при соединении 90 градусов)
                                //								SIA	25,5 мм от края балки (от обоих)	всегда (для артикулов 03 07 03 и 03 07 08 только при соединении 90 градусов)
                                //								SIB	57,5 мм от края балки (от обоих)	всегда (для артикулов 03 07 03 и 03 07 08 только при соединении 90 градусов)
                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    if (model.ProfileSystem == "Inicial IP45" && ri.Marking.Contains("130802"))
                                    {
                                        //ri.OperationList.Add(new Operation("FIL", 0, "FIL_start"));
                                        ri.OperationList.Add(new Operation("SIA", 25.5, "SIA_start"));
                                        //ri.OperationList.Add(new Operation("SIB", 32.5, "SIB_start"));
                                    }
                                    else
                                    {
                                        ri.OperationList.Add(new Operation("SIA", 25.5, "SIA_start"));
                                        //ri.OperationList.Add(new Operation("SIB", 32.5, "SIB_start"));
                                    }
                                    ri.OperationList.Add(new Operation("SIB", 32.5, "SIB_start"));
                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    if (model.ProfileSystem == "Inicial IP45" && ri.Marking.Contains("130802"))
                                    {
                                        //ri.OperationList.Add(new Operation("FIR", ri.LengthInterfaceCalc, "FIR_end"));
                                        ri.OperationList.Add(new Operation("SIA", ri.LengthInterfaceCalc - 25.5, "SIA_end"));
                                    }
                                    else
                                    {
                                        ri.OperationList.Add(new Operation("SIA", ri.LengthInterfaceCalc - 25.5, "SIA_end"));
                                    }
                                    ri.OperationList.Add(new Operation("SIB", ri.LengthInterfaceCalc - 32.5, "SIB_end"));
                                }

                                if (ri.AngNakl == 0 || ri.AngNakl == 180)
                                {
                                    //									DL	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 
                                    //									DO	центр дренажного отверстия	Для горигонтальных балок (только нижние),  100 мм от края створки 

                                    ri.OperationList.Add(new Operation("DL", 100, "DL_start"));
                                    ri.OperationList.Add(new Operation("DO", 100, "DO_start"));
                                    ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 100, "DL_end"));
                                    ri.OperationList.Add(new Operation("DO", ri.LengthInterfaceCalc - 100, "DO_end"));
                                }
                            }
                        }
                    }
                    dtLogs += "\nend ImpostList cycle IW70 " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion

                #region Расчет координат опираций МП45,TS45 OPL/OPR
                if (model != null && !drOI.IsidprofsysNull() && inRange(drOI.idprofsys, 188, 222))
                {
                    dtLogs += "\nstart calc coord ops MP45,TS45 OPL/OPR " + DateTime.Now.ToString("HH:mm:ss:fff");
                    int pos = 0;
                    List<string> porogMarkings = new List<string>() { "МП-45.06.02", "D45.05.02" };
                    foreach (RamaItem ri in model.Rama)
                    {
                        #region OPL/R				
                        Err = "OperIP45_1.3";
                        if (ri.Side == ItemSide.Left && ri.BalkaEnd != null && porogMarkings.Contains(ri.BalkaEnd.Marking)) 
                        {
                            //левая балка рамы
                            pos = ri.Lenght - 7 - ri.Outer1;
                            ri.OperationList.Add(new Operation("OPL", pos, "OPL", pos, pos));
                        }
                        if (ri.Side == ItemSide.Right && ri.BalkaStart != null && porogMarkings.Contains(ri.BalkaStart.Marking))
                        {
                            pos = 7 + ri.Outer2;
                            if (inRange(ri.Marking,"МП-45.02.01","D45.01.01")) // дверная рама то на ней всегда "OPL"
                                ri.OperationList.Add(new Operation("OPL", pos, "OPL", pos, pos));
                            else
                                ri.OperationList.Add(new Operation("OPR", pos, "OPR", pos, pos));
                        }

                        #endregion OPL/R
                    }
                    dtLogs += "\nend RamaItem cycle MP45,TS45 OPL/OPR " + DateTime.Now.ToString("HH:mm:ss:fff");
                    foreach (Impost im in model.ImpostList)
                    {
                        if (im.BalkaStart1 != null && porogMarkings.Contains(im.BalkaStart1.Marking.Replace("#", "")))
                        {
                            pos = 7 + im.Outer1;
                            im.OperationList.Add(new Operation("OPL", pos, "OPL", pos, pos));
                        }
                        if (im.BalkaStart2 != null && porogMarkings.Contains(im.BalkaStart2.Marking.Replace("#", "")))
                        {
                            pos = 7 + im.Outer1;
                            im.OperationList.Add(new Operation("OPR", pos, "OPR", pos, pos));
                        }
                    }
                    dtLogs += "\nend ImpostList cycle MP45,TS45 OPL/OPR " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion Расчет координат опираций МП 45 OPL/OPR

                #region Расчет координат операций Татпроф МП-72 OPL/OPR
                if (model != null && !drOI.IsidprofsysNull() && inRange(drOI.idprofsys, 198, 199))
                {
                    
                    int pos = 0;
                    foreach (RamaItem ri in model.Rama)
                    {
                        #region OPL/R				
                        Err = "OperIP45_1.3";
                        if (ri.Side == ItemSide.Left && ri.BalkaEnd != null && inRange(ri.BalkaEnd.Marking, "МП-72.06.03", "МП-72.06.03 ТЕРМО"))
                        {
                            //левая балка рамы
                            pos = ri.Lenght - 10 - ri.Outer1;
                            ri.OperationList.Add(new Operation("OPL", pos, "OPL", pos, pos));
                        }
                        if (ri.Side == ItemSide.Right && ri.BalkaStart != null && inRange(ri.BalkaStart.Marking, "МП-72.06.03", "МП-72.06.03 ТЕРМО"))
                        {
                            pos = 10 + ri.Outer2;
                            if (inRange(ri.Marking, "МП-72.09.01", "МП-72.09.01 ТЕРМО", "МП-72.09.02", "МП-72.09.02 ТЕРМО", "МП-72.09.03", "МП-72.09.03 ТЕРМО", "МП-72.09.04", "МП-72.09.04 ТЕРМО")) // дверная рама то на ней всегда "OPL"
                                ri.OperationList.Add(new Operation("OPL", pos, "OPL", pos, pos));
                            else
                                ri.OperationList.Add(new Operation("OPR", pos, "OPR", pos, pos));
                        }

                        #endregion OPL/R
                    }
                    foreach (Impost im in model.ImpostList)
                    {
                        if (im.BalkaStart1 != null && (im.BalkaStart1.Marking.Replace("#", "") == "МП-72.06.03" || im.BalkaStart1.Marking.Replace("#", "") == "МП-72.06.03 ТЕРМО"))
                        {
                            pos = 10 + im.Outer1;
                            im.OperationList.Add(new Operation("OPL", pos, "OPL", pos, pos));
                        }
                        if (im.BalkaStart2 != null && (im.BalkaStart2.Marking.Replace("#", "") == "МП-72.06.03" || im.BalkaStart2.Marking.Replace("#", "") == "МП-72.06.03 ТЕРМО"))
                        {
                            pos = 10 + im.Outer1;
                            im.OperationList.Add(new Operation("OPR", pos, "OPR", pos, pos));
                        }
                    }
                    dtLogs += "\nend calc  МП-72 OPL/OPR " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion Расчет координат операций Татпроф МП-72 OPL/OPR

                #region Расчет координат операций IP45
                if (model != null
                    //&& inRange( Atechnology.ecad.Settings.idpeople, 2214 )  
                    && !drOI.IsidprofsysNull() && inRange(drOI.idprofsys, 122))
                {
                    string[] doorStvorka = { "130803", "130804" };
                    string[] doorRama = { "130802" };

                    string[] windowStvorka = { "" };
                    string[] windowRama = { "130708", "130702" };

                    string[] impostsAll = { "130707", "130704", "130711", "130712", "130721", "030704", };
                    string[] imposts90 = { "130708", "130702" };

                    string[] prof4Porof = { "130708", "130711", "130721", "130719", "130802" };

                    int impCnt = 0;

                    string op_zakl_right = "M";
                    string op_zakl_left = "M";
                    string suff_zakl_V = "";
                    //					try
                    //					{
                    Err = "OperIP45_1";
                    foreach (RamaItem ri in model.Rama)
                    {

                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        bool inverse = ri.AngleHorisont == 270;
                        double sign = 1;
                        if (inverse) sign = -1;

                        #region ML/MR для рам
                        if (ri.IsRack)
                        {
                            if (!ri.Marking.ToLower().Contains("130802"))
                            {
                                int railCnt = 0;
                                foreach (double i_ in ri.RailPositionListDoubleInterface)
                                {
                                    double i = Math.Round(i_, 3);
                                    if (i < 0 || i > ri.Lenght) continue;

                                    Balka b = (Balka)ri.RailList[railCnt];

                                    if (b != null && b.Side == ItemSide.Bottom) { i += sign * b.A / 2; } else { i -= sign * b.A / 2; }

                                    if (b != null && !b.Marking.ToLower().Contains("без"))
                                    {
                                        Operation op;
                                        op = new Operation(op_zakl_right + "R" + suff_zakl_V, (double)i + b.G, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        ri.OperationList.Add(op);
                                    }
                                    railCnt++;
                                }
                            }
                        }
                        #endregion ML/MR для рам

                        #region DL 

                        if (1 == 0  // отключил по DEV-93588
                            && (ri.AngNakl == 0 || ri.AngNakl == 180)
                            && ri.Side == ItemSide.Bottom && ri.RamaType == RamaType.Rama
                            ) // если это нижняя горизонтальная балка
                        {

                            if (Array.IndexOf(doorRama, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                            {
                                Err = "OperIP45_1.1";
                                //								DL	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 
                                //								DO	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 

                                ri.OperationList.Add(new Operation("DL", 120, "DL_start"));
                                //ri.OperationList.Add( new Operation( "DO",120,"DO_start") );
                                ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 120, "DL_end"));
                                //ri.OperationList.Add( new Operation( "DO",ri.LengthInterfaceCalc-120,"DO_end") );
                            }
                            else if (Array.IndexOf(windowRama, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                            {
                                if (ri.Marking == "130708" || ri.Marking == "130702")
                                {
                                    continue;
                                }

                                Err = "OperIP45_1.2";
                                //								DL	центр дренажного отверстия	Для горигонтальных балок(только нижние), 100 мм от края створки 
                                //								DO	центр дренажного отверстия	Для горигонтальных балок створок(только нижние), 200 мм от края створки 

                                ri.OperationList.Add(new Operation("DL", 120, "DL_start"));
                                //ri.OperationList.Add( new Operation( "DO",120,"DO_start") );
                                ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 120, "DL_end"));
                                //ri.OperationList.Add( new Operation( "DO",ri.LengthInterfaceCalc-120,"DO_end") );
                            }
                        }
                        #endregion DL 

                        #region OPL/R
                        if (Array.IndexOf(prof4Porof, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                        {
                            Err = "OperIP45_1.3";
                            int pos = 0;
                            if (ri.Side == ItemSide.Left && ri.BalkaEnd != null && ri.BalkaEnd.Marking == "130401")
                            {
                                pos = ri.Lenght - 7 - ri.Outer1;
                                ri.OperationList.Add(new Operation("OPL", pos, "OPL", pos, pos));
                            }
                            if (ri.Side == ItemSide.Right && ri.BalkaStart != null && ri.BalkaStart.Marking == "130401")
                            {
                                pos = 7 + ri.Outer2;
                                ri.OperationList.Add(new Operation("OPR", pos, "OPR", pos, pos));
                            }
                        }
                        #endregion OPL/R

                        if (ri.AngleHorisont == 90 || ri.AngleHorisont == 270)
                        {
                            Err = "OperIP45_1.4";
                            if (ri.Side == ItemSide.Left)
                            {
                                suff_zakl_V = "L";
                            }
                            else
                            {
                                suff_zakl_V = "R";
                            }
                            Err = "OperIP45_1.5";
                            impCnt = 0;
                            foreach (double i_ in ri.ImpostPositionListDoubleInterface)
                            {
                                double i = Math.Round(i_, 3);
                                if (i < 0 || i > ri.Lenght || ri.ImpostList.Count == 0) continue;
                                Impost imp = (Impost)ri.ImpostList[impCnt];
                                if (imp != null && !imp.Marking.ToLower().Contains("без"))
                                {
                                    Err = "OperIP45_1.6";
                                    Operation op;
                                    op = new Operation(op_zakl_right + suff_zakl_V, (double)i + imp.G, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                    ri.OperationList.Add(op);
                                }
                                impCnt++;
                            }
                        }
                    }

                    Err = "OperIP45_2";
                    #region DL на створках
                    if (1 == 0) // отключил по DEV-93588
                    {
                        foreach (Stvorka s in model.StvorkaList)
                        {
                            foreach (StvorkaItem ri in s)
                            {
                                if (ri.Marking.ToLower().Contains("без"))
                                {
                                    continue;
                                }
                                else if (
                                    (ri.AngNakl == 0 || ri.AngNakl == 180)
                                    && ri.Side == ItemSide.Bottom
                                    ) // если это нижняя горизонтальная балка
                                {
                                    if (Array.IndexOf(doorStvorka, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                                    {
                                        //DL	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 
                                        //DO	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 

                                        ri.OperationList.Add(new Operation("DL", 120, "DL_start"));
                                        //ri.OperationList.Add( new Operation( "DO",120,"DO_start") );
                                        ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 120, "DL_end"));
                                        //ri.OperationList.Add( new Operation( "DO",ri.LengthInterfaceCalc-120,"DO_end") );
                                    }
                                    else if (Array.IndexOf(windowStvorka, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                                    {
                                        //								DL	центр дренажного отверстия	Для горигонтальных балок(только нижние), 200 мм от края створки 
                                        //								DO	центр дренажного отверстия	Для горигонтальных балок створок(только нижние), 200 мм от края створки 

                                        ri.OperationList.Add(new Operation("DL", 120, "DL_start"));
                                        //ri.OperationList.Add( new Operation( "DO",120,"DO_start") );
                                        ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 120, "DL_end"));
                                        //ri.OperationList.Add( new Operation( "DO",ri.LengthInterfaceCalc-120,"DO_end") );
                                    }
                                }
                            }
                        }
                    }
                    #endregion DL на створках

                    Err = "OperIP45_3";
                    foreach (Impost ri in model.ImpostList)
                    {
                        if (ri.Marking.ToLower().Contains("без"))
                        {
                            continue;
                        }
                        else
                        {
                            if (Array.IndexOf(prof4Porof, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0)
                            {
                                int pos = 0;
                                if (ri.BalkaStart1 != null && ri.BalkaStart1.Marking == "130401")
                                {
                                    pos = 7 + ri.Outer1;
                                    ri.OperationList.Add(new Operation("OPL", pos, "OPL", pos, pos));
                                }
                                if (ri.BalkaStart2 != null && ri.BalkaStart2.Marking == "130401")
                                {
                                    pos = 7 + ri.Outer1;
                                    ri.OperationList.Add(new Operation("OPR", pos, "OPR", pos, pos));
                                }
                            }

                            if (
                                Array.IndexOf(impostsAll, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0
                                ||
                                (
                                Array.IndexOf(imposts90, ri.Marking.Replace("#", "").Replace(" ", "")) >= 0 && ri.Ang1 == 90 && ri.Ang2 == 90
                                )
                                )
                            {

                                Err = "OperIP45_3.1";
                                #region ML/MR для импостов

                                if (ri.IsRack)
                                {

                                    int railCnt = 0;
                                    foreach (double i_ in ri.RailPositionListDoubleInterface)
                                    {
                                        suff_zakl_V = "L";
                                        double i = Math.Round(i_, 3);
                                        if (i < 0 || i > ri.Lenght || ri.RailsList.Count == 0) continue;

                                        Balka b = (Balka)ri.RailsList[railCnt];
                                        if (b != null && b.Side == ItemSide.Bottom) { i += b.A / 2; } else { i -= b.A / 2; }

                                        if (b != null && !b.Marking.ToLower().Contains("без") && ri.AngNakl != b.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                        {
                                            //MessageBox.Show( "RailNo: " + railCnt.ToString() + ", OPER=" + op_zakl_left + ", i=" + i.ToString() + ", Info=" + getBalkaIndex(b) + " [" + b.Marking.Replace("#","") + "]" );
                                            Operation op;
                                            op = new Operation(op_zakl_left + suff_zakl_V, (double)i + b.G, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                            ri.OperationList.Add(op);
                                        }
                                        railCnt++;
                                    }
                                }

                                if (ri.IsRack)
                                {

                                    int railCnt = 0;
                                    foreach (double i_ in ri.RailPositionListDouble2Interface)
                                    {
                                        suff_zakl_V = "R";
                                        double i = Math.Round(i_, 3);
                                        if (i < 0 || i > ri.Lenght || ri.RailsList2.Count == 0) continue;

                                        Balka b = (Balka)ri.RailsList2[railCnt];
                                        if (b != null && b.Side == ItemSide.Bottom) { i += b.A / 2; } else { i -= b.A / 2; }

                                        if (b != null && !b.Marking.ToLower().Contains("без") && ri.AngNakl != b.AngNakl) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
                                        {
                                            //MessageBox.Show( "RailNo: " + railCnt.ToString() + ", OPER=" + op_zakl_left + ", i=" + i.ToString() + ", Info=" + getBalkaIndex(b) + " [" + b.Marking.Replace("#","") + "]" );
                                            Operation op;
                                            op = new Operation(op_zakl_left + suff_zakl_V, (double)i + b.G, b.Tag4 + " [" + b.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                            ri.OperationList.Add(op);
                                        }
                                        railCnt++;
                                    }
                                }


                                impCnt = 0;
                                foreach (double i_ in ri.ImpostPositionListDoubleInterface)
                                {
                                    Err = "OperIP45_3.1.1";
                                    suff_zakl_V = "L";
                                    double i = Math.Round(i_, 3);
                                    if (i < 0 || i > ri.Lenght || ri.ImpostList.Count == 0) continue;
                                    Impost imp = (Impost)ri.ImpostList[impCnt];
                                    if (imp != null && !imp.Marking.ToLower().Contains("без"))
                                    {
                                        Operation op;
                                        op = new Operation(op_zakl_right + suff_zakl_V, (double)i + imp.G, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        ri.OperationList.Add(op);
                                    }
                                    impCnt++;
                                }
                                impCnt = 0;
                                foreach (double i_ in ri.ImpostPositionListDouble2Interface)
                                {
                                    //	MessageBox.Show("impCnt: " + impCnt+1 + "\r\n" + ri.ImpostPositionListDouble2Interface.Count + "\r\n" + ri.Marking);
                                    Err = "OperIP45_3.1.2_impCnt: " + impCnt + "ri.ImpostList: " + ri.ImpostList.Count;
                                    suff_zakl_V = "R";
                                    double i = Math.Round(i_, 3);
                                    if (i < 0 || i > ri.Lenght) continue;
                                    Impost imp = (Impost)ri.ImpostList2[impCnt];
                                    if (imp != null && !imp.Marking.ToLower().Contains("без"))
                                    {
                                        Operation op;
                                        op = new Operation(op_zakl_right + suff_zakl_V, (double)i + imp.G, imp.Tag4 + " [" + imp.Marking.Replace("#", "") + "]", (double)i, (double)i);
                                        ri.OperationList.Add(op);
                                    }
                                    impCnt++;
                                }

                                #endregion ML/MR для импостов

                                Err = "OperIP45_3.2";
                                //FIL	0 мм от края балки (от обоих)	всегда (для артикулов 03 07 03 и 03 07 08 только при соединении 90 градусов)
                                //FIR	0 мм от края балки (от обоих)	всегда (для артикулов 03 07 03 и 03 07 08 только при соединении 90 градусов)
                                //SIA	25,5 мм от края балки (от обоих)	всегда (для артикулов 03 07 03 и 03 07 08 только при соединении 90 градусов)
                                //SIB	57,5 мм от края балки (от обоих)	всегда (для артикулов 03 07 03 и 03 07 08 только при соединении 90 градусов)
                                if (ri.Connect1 == SoedType.Korotkoe)
                                {
                                    if (model.ProfileSystem == "Inicial IP45" && ri.Marking.Contains("130802"))
                                    {
                                        ri.OperationList.Add(new Operation("SIA", 42.5, "SIA_start"));
                                        //	ri.OperationList.Add( new Operation( "SIB",41.7,"SIB_start") );
                                    }
                                    else
                                    {
                                        ri.OperationList.Add(new Operation("SIA", 42.5, "SIA_start"));
                                    }
                                }
                                if (ri.Connect2 == SoedType.Korotkoe)
                                {
                                    if (model.ProfileSystem == "Inicial IP45" && ri.Marking.Contains("130802"))
                                    {
                                        ri.OperationList.Add(new Operation("SIA", ri.LengthInterfaceCalc - 42.5, "SIA_end"));
                                    }
                                    else
                                    {
                                        ri.OperationList.Add(new Operation("SIA", ri.LengthInterfaceCalc - 42.5, "SIA_end"));
                                    }
                                    //	ri.OperationList.Add( new Operation( "SIB",ri.LengthInterfaceCalc-41.7,"SIB_end") );
                                }

                                if (ri.AngNakl == 0 || ri.AngNakl == 180)
                                {
                                    //DL	центр дренажного отверстия	Для горигонтальных балок (только нижние), 100 мм от края створки 
                                    //DO	центр дренажного отверстия	Для горигонтальных балок (только нижние),  100 мм от края створки 

                                    //ri.OperationList.Add(new Operation("DL", 120, "DL_start"));
                                    //ri.OperationList.Add( new Operation( "DO",120,"DO_start") );
                                    //ri.OperationList.Add(new Operation("DL", ri.LengthInterfaceCalc - 120, "DL_end"));
                                    //ri.OperationList.Add( new Operation( "DO",ri.LengthInterfaceCalc-120,"DO_end") );
                                }
                            }
                        }
                    }
                    //					}
                    //					catch(Exception ex)
                    //					{
                    //						MessageBox.Show("Ошибка расчета координат для IP45!Err: " + Err + "\r\nMessage: " + ex.Message,"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //					}
                    dtLogs += "\nend calc  coord ops IP45 " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion Расчет координат IP45

                #region Дренажные заглушки
                // https://servicedesk.it-swarm.pro/browse/DEV-86714
                if (model != null && drOI != null && !drOI.IsidprofsysNull() && inRange(drOI.idprofsys, 198, 199, 217, 218, 219) && !drOI.IsidconstructiontypeNull() && inRange(drOI.idconstructiontype, 2, 38))
                {
                    //					условия расчета:
                    //
                    //					Системы:
                    //						-Татпроф МП-72
                    //						-Татпроф МП-72 ТЕРМО
                    //                      -Татпроф TS-65
                    //                      -Татпроф TS-72
                    //                      -Татпроф TS-72 HI
                    //
                    //					типы конструкций:
                    //						-Окно
                    //						-Витраж
                    //
                    //						Балки
                    //						-Для горизонтальных импостов
                    //						-Для нижних горизонтальных рам
                    //
                    //						Логика расчета: 2 шт всегда+ 1 шт. на каждые 500 мм при длине балки более 1000 мм

                    int quZagl = 0;
                    foreach (RamaItem ri in model.Rama)
                    {
                        if ((ri.AngNakl == 0 || ri.AngNakl == 180) && (ri.Radius1 == 0)
                            && ri.Side == ItemSide.Bottom && ri.RamaType == RamaType.Rama) // если это нижняя горизонтальная балка
                        {
                            quZagl += 2;
                            if (ri.LengthInterfaceCalcInt > 1000)
                            {
                                quZagl += roundToMax((double)(ri.LengthInterfaceCalcInt - 1000) / 500);
                            }
                        }
                    }
                    foreach (Impost ri in model.ImpostList)
                    {
                        if ((ri.AngNakl == 0 || ri.AngNakl == 180) && (ri.Radius1 == 0)
                            && ri.ImpostType == ImpostType.Impost) // если это горизонтальный импост
                        {
                            quZagl += 2;
                            if (ri.LengthInterfaceCalcInt > 1000)
                            {
                                quZagl += roundToMax((double)(ri.LengthInterfaceCalcInt - 1000) / 500);
                            }
                        }
                    }

                    if (quZagl > 0)
                    {
                        string marking = "";

                        if (inRange(drOI.idprofsys, 217, 218, 219))
                        {
                            marking = "W45.13.04 black";
                        }
                        else
                        {
                            marking = "МПУ-016 black";
                            if (model.ColorOut.Contains("RAL 9003") || model.ColorOut.Contains("RAL 9016"))
                            {
                                marking = "МПУ-016 white";
                            }
                        }
                        drOI.AddModelcalc(marking, quZagl);
                    }
                    dtLogs += "\nend calc DRENAZh " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion

                #region Операция подпила FL/FR
                if (model != null && drOI != null && !drOI.IsidprofsysNull() && inRange(drOI.idprofsys, 113, 122, 156, 186, 188, 222) && !drOI.IsidconstructiontypeNull() && inRange(drOI.idconstructiontype, 5, 6, 35, 36))
                {
                    //					условия расчета:
                    //
                    //					Системы:
                    //						-Inicial IW63 - 113
                    //						-Inicial IP45 - 122 
                    //                      -Inicial IW70 - 156
                    //                      -Татпроф МП-65 - 186
                    //                      -Татпроф МП-45 - 188
                    //					типы конструкций:
                    //						-Дверь входная открывание во внутрь(6)/ Дверь входная открывание наружу(7)
                    //
                    //						Балки
                    //						-Для пассивных створок 
                    //			то на штульповой створке: на Z- образной с 2х сторон,
                    //			на верхней и нижней балке створки с одной(та что примыкает к Z профилю) 
                    //          причем если углы под 45
                    if (model.StvorkaList.Count == 2) //двупольная дверь
                    {
                        foreach (Stvorka stv in model.StvorkaList)
                        {
                            //Штульповая створка 
                            if (stv.ShtulpExist == ShtulpExist.Exist)
                            {
                                foreach (StvorkaItem si in stv)
                                {
                                    if (si.Side == ItemSide.Bottom || si.Side == ItemSide.Top) // для нижней и верхней балке только на тот угол который прилегает к балке ручки
                                    {
                                        if (si.BalkaStart.IsHandle && si.BalkaStart.Ang2 == 45 && si.Ang1 == 45)
                                            si.OperationList.Add(new Operation("FL", 20, "FL"));
                                        if (si.BalkaEnd.IsHandle && si.BalkaEnd.Ang1 == 45 && si.Ang2 == 45)
                                            si.OperationList.Add(new Operation("FR", 20, "FR"));

                                    }
                                    else if (si.IsHandle)
                                    {
                                        if (si.Ang1 == 45)
                                            si.OperationList.Add(new Operation("FL", 20, "FL"));
                                        if (si.Ang2 == 45)
                                            si.OperationList.Add(new Operation("FR", 20, "FR"));
                                    }

                                }
                            }
                        }
                    }

                }
                #endregion

                #region Расчет 8KT/30 DEV-100434 
                Err = "calc_8KT/30";
                if (model != null
                    && inRange(model.ProfileSystem, "Provedal C640, P400", "Provedal P400", "Inicial City Pro", "Сиал КП 40", "Татпроф СОКОЛ 40", "Сокол МП-640")
                    /*&& inRange(Atechnology.ecad.Settings.idpeople, 7889, 3404)*/)
                {
                    if (Model.ConstructionType.ID == 13)
                    {
                        bool razdtype = true;
                        foreach (Stvorka s in model.StvorkaList)
                        {
                            if (s.otkrivanieType != OtkrivanieType.Razd)
                            {
                                razdtype = false;
                                break;
                            }
                        }

                        if (razdtype)
                        {
                            if (Model.StvorkaList.Count == 2)
                            {
                                drOI.AddModelcalc("8KT/30", 1);
                            }
                            else if (Model.StvorkaList.Count >= 3 && Model.StvorkaList.Count <= 5)
                            {
                                drOI.AddModelcalc("8KT/30", 2);
                            }
                        }
                    }
                    dtLogs += "\nend calc  8KT/30 " + DateTime.Now.ToString("HH:mm:ss:fff");
                }
                #endregion

                StartStopExecutionTimeCounter(false, "idorder: " + drOI.idorder + " idorderitem: " + drOI.idorderitem );
                dtLogs += "\nEND SCRYPT " + DateTime.Now.ToString("HH:mm:ss:fff");
                SetAdditionalLogs("idorder: " + drOI.idorder + " idorderitem: "  + drOI.idorderitem + " idpeople: " + Atechnology.ecad.Settings.idpeople + "  " + dtLogs);
            }
            catch (Exception e)
            {
                if (Atechnology.ecad.Settings.idpeople == 803)
                    MessageBox.Show(e.Message + "\n\n" + e.StackTrace);
                Order.AddErrorUnical(drOI.idorderitem, "о002", "", "Ошибка скрипта Расчета координат закладных алюминий:\r\nErr: " + Err + "\r\n" + e.Message + "\r\n" + e.TargetSite.ToString() + " \r\n" + e.StackTrace + "\r\nТочка:" + Err);
            }
            //			if (AtLog.Enabled) {
            //				AtLog.LogInstance.DebugFormat("Конец скрипта расчета");
            //			}
        }

        public void fillModelPartClass_FromTo(Balka b, ModelPartClass mpc, ref double aFrom, ref double aTo)
        {
            if (mpc == null) return;

            switch ((int)b.AngNakl)
            {
                case 000: // Верхняя
                    aFrom = mpc.FillEnd; aTo = mpc.FillStart;
                    break;
                case 180: // Нижняя
                    aFrom = mpc.FillStart; aTo = mpc.FillEnd;
                    break;
                case 090: // Левая
                    aFrom = mpc.FillStart; aTo = mpc.FillEnd;
                    break;
                case 270: // Правая
                    aFrom = mpc.FillStart; aTo = mpc.FillEnd;
                    break;
                default: // ХЗ что это
                    break;

            }
            if (aFrom > aTo) { double t = aFrom; aFrom = aTo; aTo = t; } // Переворот
            aFrom = Math.Round(aFrom, 1); aTo = Math.Round(aTo, 1);
        }

        public void fillModelPartClass_FromTo2(ds_order.orderitemRow drOI, Balka b, ModelPartClass mpc, ref double aFrom, ref double aTo, ref double len)
        {
            if (mpc == null) return;

            switch ((int)b.AngNakl)
            {
                case 000: // Верхняя
                    aFrom = mpc.CoordFinish; aTo = mpc.CoordStart;
                    break;
                case 180: // Нижняя
                    aFrom = mpc.CoordStart; aTo = mpc.CoordFinish;
                    break;
                case 090: // Левая
                    aFrom = mpc.CoordStart; aTo = mpc.CoordFinish;
                    break;
                case 270: // Правая
                    aFrom = mpc.CoordStart; aTo = mpc.CoordFinish;
                    break;
                default: // ХЗ что это
                    break;

            }


            //			if( Atechnology.ecad.Settings.idpeople == 2214 )
            //			{
            //				MessageBox.Show( "Balka1.Тип=["+mpc.Balka1.BalkaType+"]: " + mpc.Balka1.Marking + ", Balka2.Тип=["+mpc.Balka2.BalkaType+"]:" + mpc.Balka2.Marking );
            //			}

            bool isMPC_Door_Stvorka = mpc != null && mpc.StvItem != null && inRange(mpc.StvItem.Marking, "МП-45.02.02", "МП-45.02.03");
            bool isMPC_Window_Stvorka = mpc != null && mpc.StvItem != null && inRange(mpc.StvItem.Marking, "МП-45.04.01", "МП-45.04.03", "МП-45.04.04");

            double delta = 0;

            if (mpc.Balka1 != null && mpc.Balka1.BalkaType == ModelPart.Impost)
            {
                switch (mpc.Balka1.Marking)
                {
                    //					case "#130719":
                    //					case "#130721":
                    //						delta += 22.5;
                    //						break;
                    case "##130803":
                    case "##130804":
                        delta += 40;
                        break;
                    case "##МП-45.01.03":
                        if (isMPC_Door_Stvorka)
                        {
                            delta -= 18;
                        }
                        break;
                    case "##МП-45.01.04":
                        if (isMPC_Door_Stvorka)
                        {
                            delta -= 26;
                        }
                        break;
                }
            }
            if (mpc.Balka2 != null && mpc.Balka2.BalkaType == ModelPart.Impost)
            {
                switch (mpc.Balka2.Marking)
                {
                    //					case "#130719":
                    //					case "#130721":
                    //						delta += 22.5;
                    //						break;
                    case "##130803":
                    case "##130804":
                        delta += 40;
                        break;
                    case "##МП-45.01.03":
                        if (isMPC_Door_Stvorka)
                        {
                            delta -= 18;
                        }
                        break;
                    case "##МП-45.01.04":
                        if (isMPC_Door_Stvorka)
                        {
                            delta -= 26;
                        }
                        break;
                }
            }


            if (!inRange(drOI.idprofsys, 208) && inRange(b.Marking,
                "МП-64092", "#МП-64092", "МП-64092-02",
                "#МП-64092-02", "МП-64081", "#МП-64081",
                "МП-64092-02+МП-64080", "#МП-64092-02+МП-64080", "МП-64092+МП-64080",
                "#МП-64092+МП-64080", "МП-64081+МП-64080", "#МП-64081+МП-64080"))
            {
                if (mpc.Balka1 != null && mpc.Balka1.BalkaType == ModelPart.Impost)
                {
                    switch (mpc.Balka1.Marking)
                    {
                        case "##МП-64025-01":
                        case "#МП-64025-01":
                        case "##МП-64025":
                        case "#МП-64025":
                            delta += mpc.Balka1.A;
                            break;
                    }
                }
                if (mpc.Balka2 != null && mpc.Balka2.BalkaType == ModelPart.Impost)
                {
                    switch (mpc.Balka2.Marking)
                    {
                        case "##МП-64025-01":
                        case "#МП-64025-01":
                        case "##МП-64025":
                        case "#МП-64025":
                            delta += mpc.Balka2.A;
                            break;
                    }
                }
            }

            if (inRange(drOI.idprofsys, 208) && inRange(b.Marking, "#МП-64091-02", "#МП-64091", "#МП-64091-01", "#МП-64092-02", "МП-64092-02", "#МП-64092", "МП-64092", "#МП-64020", "МП-64020", "#МП-64020-02", "МП-64020-02", "#МП-64029", "#МП-64021-04"))
            {
                /*
				if( mpc.Balka1 != null ) delta += mpc.Balka1.A;
				if( mpc.Balka2 != null ) delta += mpc.Balka2.A;
				*/
                if (mpc.Glass != null)
                {
                    Balka b001 = (Balka)(mpc.Glass.Find(x => x.AngNakl == 0).ConnectBalka);
                    Balka b002 = (Balka)(mpc.Glass.Find(x => x.AngNakl == 180).ConnectBalka);

                    if (b001 != null) delta += b001.A;
                    if (b002 != null) delta += b002.A;

                }
                else
                {
                    delta += mpc.Balka1 != null ? mpc.Balka1.A : 0;
                    delta += mpc.Balka2 != null ? mpc.Balka2.A : 0;
                }
            }

            if (aFrom > aTo)
            {
                double t = aFrom;
                aFrom = aTo;
                aTo = t;
            }
            // Переворот
            aFrom = Math.Round(aFrom, 1);
            aTo = Math.Round(aTo, 1);

            double x_len = Math.Abs(mpc.x2 - mpc.x1);
            double y_len = Math.Abs(mpc.y2 - mpc.y1);


            len = Math.Round(Math.Sqrt(x_len * x_len + y_len * y_len) - delta);


            //			if( Atechnology.ecad.Settings.idpeople == 168 )
            //			{
            //				MessageBox.Show( "RISING=" + b.Rising + ", ADDE=" + b.AddEnd );
            //			}

            if (Atechnology.ecad.Settings.idpeople == 2214)
            {
                if (Model.ProfileSystem == "Inicial IP45"
                    && Model.ImpostList.Count == 0
                    && Model.StvorkaList.Count == 0)
                {
                    if (len < mpc.CoordFinish)
                    {
                        len = (double)mpc.CoordFinish;
                    }
                }
            }

            if ((mpc.ModelPart == ModelPart.Stvorka || mpc.ModelPart == ModelPart.StvorkaItem) && mpc.StvItem != null && inRange(mpc.StvItem.Marking, "МП-45.02.02", "МП-45.02.03"))
            {
                delta = 0;
                if (mpc.Balka1 != null && mpc.Balka1.BalkaType != ModelPart.Porog && !inRange(mpc.Balka1.Marking, "МП-45.06.01", "Порог врезной 12 мм", "Без порога 8мм"))
                {
                    delta += 6.5;
                }
                else if (mpc.Balka2 != null && (mpc.Balka1.BalkaType == ModelPart.Porog || inRange(mpc.Balka1.Marking, "МП-45.06.01", "Порог врезной 12 мм", "Без порога 8мм")))
                {
                    delta += 8;
                }
                if (mpc.Balka2 != null && mpc.Balka2.BalkaType != ModelPart.Porog && !inRange(mpc.Balka2.Marking, "МП-45.06.01", "Порог врезной 12 мм", "Без порога 8мм"))
                {
                    delta += 6.5;
                }
                else if (mpc.Balka2 != null && (mpc.Balka2.BalkaType == ModelPart.Porog || inRange(mpc.Balka2.Marking, "МП-45.06.01", "Порог врезной 12 мм", "Без порога 8мм")))
                {
                    delta += 8;
                }

                len = mpc.StvItem.Stvorka.Height + delta;

                //				if( Atechnology.ecad.Settings.idpeople == 168 ) MessageBox.Show( "LEN=" + len + ", StvHeight=" +  mpc.StvItem.Stvorka.Height + ", delta=" + delta + ", mpc.B2.marking=" + mpc.Balka2.Marking + ", mpc.B1.marking=" + mpc.Balka1.Marking );
            }


            if (inRange(b.Marking.Replace("#", ""), "МП-45.05.02", "МП-45.05.04", "МП-45.05.05") && mpc.StvItem != null && inRange(mpc.StvItem.Marking, "МП-45.04.03"))
            {
                switch (b.Marking.Replace("#", ""))
                {
                    case "МП-45.05.02":
                        delta = -12;
                        break;
                    case "МП-45.05.04":
                    case "МП-45.05.05":
                    case "МП-45.05.06":
                        delta = -56;
                        break;
                }
                len = mpc.StvItem.Stvorka.Height + delta;
            }

            if (drOI.idprofsys == 222)
            {
                if (mpc.Glass != null)
                {
                    Balka b001 = (Balka)(mpc.Glass.Find(x => x.AngNakl == 0).ConnectBalka);
                    Balka b002 = (Balka)(mpc.Glass.Find(x => x.AngNakl == 180).ConnectBalka);
                    if (b002 != null && b002 is Impost)
                    {
                        Impost i1 = (Impost)b002;

                        foreach (ModelPartClass mpc1 in i1.PartTypeList)
                        {
                            if (mpc1.ModelPart == ModelPart.Stvorka)
                            {
                                if (mpc1.StvItem.Marking == "D45.02.01" || mpc1.StvItem.Marking == "D45.02.02")
                                {
                                    len = len - 44;
                                }
                            }
                        }

                        foreach (ModelPartClass mpc1 in i1.PartTypeList2)
                        {
                            if (mpc1.ModelPart == ModelPart.Stvorka)
                            {
                                if (mpc1.StvItem.Marking == "D45.02.01" || mpc1.StvItem.Marking == "D45.02.02")
                                {
                                    len = len - 44;
                                }
                            }
                        }
                    }
                }
            }

        }


        public void SaveModelCalcForBalkaPart(ds_order.orderitemRow drOI, Balka b, int len, int kind, string side)
        {
            ds_order.modelcalcRow mc = null;
            int count_samorez = (len / 250) + 1;
            string balkapart = "";
            switch (b.BalkaType)
            {
                case ModelPart.RamaItem:
                    balkapart = "Р-" + (b.ID + 1).ToString();
                    break;
                case ModelPart.Impost:
                    balkapart = "И-" + (b.ID + 1).ToString();
                    break;
            }
            if (inRange(b.Marking, "##130719", "##130721", "#130719", "#130721", "#130711", "##130711"))
            {
                //				MessageBox.Show( "kind=" + kind );
                switch (kind)
                {
                    case 0:
                        mc = drOI.AddModelcalc("13 01 01", 1, len, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        break;
                    case 1:
                        /*if(Atechnology.ecad.Settings.idpeople == 2214)
						{
							// 13 04 02
							mc = drOI.AddModelcalc( "13 04 02", 1, len, 90, 90, 0, 0 ); 
							mc.addstr = "Additional_2214";
							mc.idcolor1 = drOI.idcolorout;
							mc.modelpart = balkapart;
							mc.addstr3 = side;
							mc = drOI.AddModelcalc( "99 02 10", count_samorez ); 
							mc.modelpart = balkapart;
							mc.addstr3 = side;
						}*/

                        break;
                    case 4:
                        mc = drOI.AddModelcalc("13 04 02", 1, b.LengthInterfaceCalcInt + 4, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;

                        count_samorez = (len / 300) + 1;
                        mc = drOI.AddModelcalc("3.9x16", count_samorez);
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        mc.addstr = "59"; // ! Алюминька. Рама+Створка
                        break;
                }
            }
            if (!inRange(drOI.idprofsys, 208) && inRange(b.Marking, "МП-64092", "#МП-64092", "МП-64092-02", "#МП-64092-02", "МП-64081", "#МП-64081"))
            {
                switch (kind)
                {
                    case 0:
                        mc = drOI.AddModelcalc("МП-64061", 1, len, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;

                        count_samorez = (len / 300) + 1;
                        mc = drOI.AddModelcalc("3.9x16", count_samorez);
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        mc.addstr = "59";
                        break;
                    case 1:
                        break;
                }
            }
            if (inRange(drOI.idprofsys, 208) && inRange(b.Marking, "#МП-64091-02", "#МП-64091", "#МП-64091-01", "#МП-64092-02", "МП-64092-02", "#МП-64092", "МП-64092", "#МП-64020", "МП-64020", "#МП-64020-02", "МП-64020-02", "#МП-64029", "#МП-64021-04"))
            {
                switch (kind)
                {
                    case 0:
                        mc = drOI.AddModelcalc("МП-64061", 1, len, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;

                        count_samorez = (len / 300) + 1;
                        mc = drOI.AddModelcalc("4,2х13 DIN 7982", count_samorez);
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        mc.addstr = "59";
                        break;
                    case 1:
                        break;
                }
            }

            if (inRange(b.Marking, "МП-64092-02+МП-64080",
                "#МП-64092-02+МП-64080",
                "МП-64092+МП-64080",
                "#МП-64092+МП-64080",
                "МП-64081+МП-64080",
                "#МП-64081+МП-64080"))
            {
                switch (kind)
                {
                    case 0:
                        mc = drOI.AddModelcalc("МП-64080", 1, len, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;

                        count_samorez = (len / 300) + 1;
                        mc = drOI.AddModelcalc("3.9x16", count_samorez);
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        mc.addstr = "59";
                        break;
                    case 1:
                        break;
                }
            }

            if (inRange(b.Marking.Replace("#", ""), "МП-45.05.02"))
            {
                if (kind >= 1000)
                {
                    mc = drOI.AddModelcalc("МП-45.07.14", 1, len, 90, 90, 0, 0);
                    mc.addstr = "Additional";
                    mc.idcolor1 = drOI.idcolorout;
                    mc.idcolor2 = drOI.idcolorin;
                    mc.modelpart = balkapart;
                    mc.addstr3 = side;

                    count_samorez = (len / 300) + 1;
                    mc = drOI.AddModelcalc("3.9x25", count_samorez);
                    mc.modelpart = balkapart;
                    mc.addstr3 = side;
                    mc.addstr = "59"; // ! Алюминька. Рама+Створка
                }
                switch (kind)
                {
                    case 0:
                        /*	mc = drOI.AddModelcalc( "МП-45.07.14", 1, len, 90, 90, 0, 0 ); 
							mc.addstr = "Additional";
							mc.idcolor1 = drOI.idcolorout;
							mc.idcolor2 = drOI.idcolorin;
							mc.modelpart = balkapart;
							mc.addstr3 = side;

							count_samorez = ( len / 300 ) + 1;
							mc = drOI.AddModelcalc( "3.9x25", count_samorez ); 
							mc.modelpart = balkapart;
							mc.addstr3 = side;
							mc.addstr = "59";*/ // ! Алюминька. Рама+Створка
                        break;
                    case 1:
                        break;
                    case 3:
                        mc = drOI.AddModelcalc("МП-45.07.13", 1, len + 4, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.idcolor2 = drOI.idcolorin;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;

                        count_samorez = (len / 300) + 1;
                        mc = drOI.AddModelcalc("3.9x25", count_samorez);
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        mc.addstr = "59"; // ! Алюминька. Рама+Створка
                        break;
                }
            }

            if (inRange(b.Marking.Replace("#", ""), "МП-45.05.04", "МП-45.05.05", "МП-45.05.06"))
            {

                switch (kind)
                {
                    case 100:
                        mc = drOI.AddModelcalc("МП-45.07.15", 1, len, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.idcolor2 = drOI.idcolorout;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;

                        count_samorez = (len / 300) + 1;
                        mc = drOI.AddModelcalc("3.9x16", count_samorez);
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        mc.addstr = "59"; // ! Алюминька. Рама+Створка
                        break;
                    case 1:
                        break;
                    case 3:
                        mc = drOI.AddModelcalc("МП-45.07.13", 1, len + 4, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.idcolor2 = drOI.idcolorin;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;

                        count_samorez = (len / 300) + 1;
                        mc = drOI.AddModelcalc("3.9x25", count_samorez);
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        mc.addstr = "59"; // ! Алюминька. Рама+Створка
                        break;
                }
            }

            if (inRange(b.Marking.Replace("#", ""), "W45.03.03", "W45.05.01", "W45.05.02") && b.IsRack)
            {
                //				MessageBox.Show( "kind=" + kind );
                switch (kind)
                {
                    case 0:
                        mc = drOI.AddModelcalc("W45.06.03", 1, len, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;

                        count_samorez = (len / 300) + 1;
                        mc = drOI.AddModelcalc("4,2х19 DIN7982", count_samorez);
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        mc.addstr = "59"; // ! Алюминька. Рама+Створка
                        break;
                    case 1:
                        break;
                    case 3:
                        mc = drOI.AddModelcalc("D45.06.10", 1, len - 24, 90, 90, 0, 0);
                        mc.addstr = "Additional";
                        mc.idcolor1 = drOI.idcolorout;
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;

                        count_samorez = (len / 300) + 1;
                        mc = drOI.AddModelcalc("4,2х19 DIN7982", count_samorez);
                        mc.modelpart = balkapart;
                        mc.addstr3 = side;
                        mc.addstr = "59"; // ! Алюминька. Рама+Створка
                        break;
                }
            }

        }

        public void SaveModelCalcForRack_Mounts(ds_order.orderitemRow drOI, Balka b, int qty)
        {
            if (qty <= 0 || b == null || drOI == null || b.Marking == "Без рамы" || b.Marking.ToLower().Contains("фиктивн")) return;

            ds_order.modelcalcRow m0 = null;
            ds_order.modelcalcRow m1 = null;
            ds_order.modelcalcRow m2 = null;
            string Err = "";

            try
            {
                switch (b.Marking)
                {
                    case "010301":
                    case "#010301":
                        Err = "1";
                        m0 = drOI.AddModelcalc("01 07 01_200мм", qty);
                        m1 = drOI.AddModelcalc("99 01 19", qty * 4);
                        m2 = drOI.AddModelcalc("01 80 01", qty);
                        break;
                    case "010302":
                    case "011302":
                    case "#010302":
                    case "#011302":
                        m0 = drOI.AddModelcalc("01 07 02", qty, 150, 90, 90, 0, 0);
                        m1 = drOI.AddModelcalc("99 01 19", qty * 4);
                        m2 = drOI.AddModelcalc("01 80 02", qty);
                        Err = "2";
                        break;
                    case "010303":
                    case "011303":
                    case "#010303":
                    case "#011303":
                        m0 = drOI.AddModelcalc("01 07 03", qty, 150, 90, 90, 0, 0);
                        m1 = drOI.AddModelcalc("99 01 19", qty * 4);
                        m2 = drOI.AddModelcalc("01 80 03", qty);
                        Err = "3";
                        break;
                    case "010304":
                    //case "011304":
                    case "#010304":
                        // case "#011304":
                        m0 = drOI.AddModelcalc("01 07 04", qty, 150, 90, 90, 0, 0);
                        m1 = drOI.AddModelcalc("99 01 19", qty * 4);
                        m2 = drOI.AddModelcalc("01 80 04", qty);
                        Err = "4";
                        break;
                    case "010305":
                    case "#010305":
                        m0 = drOI.AddModelcalc("01 07 05", qty, 150, 90, 90, 0, 0);
                        m1 = drOI.AddModelcalc("99 01 19", qty * 4);
                        m2 = drOI.AddModelcalc("01 80 05", qty);
                        Err = "5";
                        break;
                    case "010306":
                    case "#010306":
                        m0 = drOI.AddModelcalc("01 07 06", qty, 150, 90, 90, 0, 0);
                        m1 = drOI.AddModelcalc("99 01 19", qty * 4);
                        m2 = drOI.AddModelcalc("01 80 06", qty);
                        Err = "6";
                        break;
                    case "010101":
                    case "#010101":
                        m0 = drOI.AddModelcalc("01 08 03", qty, 65, 90, 90, 0, 0);
                        m1 = drOI.AddModelcalc("99 02 10", qty * 4);
                        m1.addstr = "115";
                        m2 = drOI.AddModelcalc("99 02 10", qty);
                        m2.addstr = "115";
                        Err = "6";
                        break;
                }

                if (Atechnology.ecad.Settings.idpeople == 803)
                {
                    if (m0 == null || m1 == null || m2 == null || getSideRussian(b) == null)
                    {
                        MessageBox.Show("b.Marking - " + b.Marking + "\n"
                            + "b.ID- " + b.ID + "\n"
                            + "m0 " + (m0 == null).ToString() + "\n"
                            + "m1 " + (m1 == null).ToString() + "\n"
                            + "m2 " + (m2 == null).ToString() + "\n"
                            + "getSideRussian( b ) " + (getSideRussian(b) == null).ToString() + "\n");
                    }
                }
                Err = "7";

                if (m0 == null || m1 == null || m2 == null)
                {
                    if (!inRange(b.Marking, "011304", "#011304", "010110", "#010110", "010111", "#010111")) Order.AddErrorUnical(drOI.idorderitem, "о002", "", "Ошибка скрипта Расчета координат закладных алюминий:\r\nДля артикула " + b.Marking + " не удалось рассчитать операции закладных!!!");
                }

                if (m0 != null)
                {
                    m0.addstr = "Additional";
                    m0.modelpart = "Ст-" + (b.ID + 1);
                    m0.addstr2 = b.Marking;
                    m0.addstr3 = getSideRussian(b);
                }
                if (m1 != null)
                {
                    m1.modelpart = m0.modelpart;
                    m1.addstr2 = b.Marking;
                    m1.addstr3 = m0.addstr3;
                }
                if (m2 != null)
                {
                    m2.modelpart = m0.modelpart;
                    m2.addstr2 = b.Marking;
                    m2.addstr3 = m0.addstr3;
                }
                Err = "8";
                // m1.addstr = "78";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка метода SaveModelCalcForRack_Mounts \r\nErr: " + Err + "\r\nMessage: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveModelCalcForRack_Mounts_IP45(ds_order.orderitemRow drOI, Balka b, int qty, int qtyTop = 0, int qtyBottom = 0)
        {
            if (qty <= 0 || b == null || drOI == null || b.Marking == "Без рамы"
                || b.Connect1 != SoedType.Dlinnoe
                || b.Connect2 != SoedType.Dlinnoe) return;

            ds_order.modelcalcRow m0 = null;
            ds_order.modelcalcRow m1 = null;
            ds_order.modelcalcRow m2 = null;
            ds_order.modelcalcRow m3 = null;
            string Err = "";

            Err = "SMC_FRM: 001";
            try
            {
                switch (b.Marking.Replace("#", ""))
                {
                    case "130721":
                    case "130719":
                    case "130707":
                    case "130708":
                        Err = "1";
                        m0 = drOI.AddModelcalc("13 03 10", qty, 150, 90, 90, 0, 0);
                        m0.addstr = "Additional";
                        m0.modelpart = "Ст-" + (b.ID + 1);
                        m0.addstr2 = b.Marking;
                        m0.addstr3 = getSideRussian(b);// + side;

                        m1 = drOI.AddModelcalc("13 80 02", qty);
                        m1.modelpart = m0.modelpart;
                        m1.addstr2 = b.Marking;
                        m1.addstr3 = m0.addstr3;

                        m2 = drOI.AddModelcalc("99 01 35", qty * 4);
                        m2.modelpart = m0.modelpart;
                        m2.addstr2 = b.Marking;
                        m2.addstr3 = m0.addstr3;

                        if (CheckAssembled(b))
                        {
                            //m2.addstr = "";
                        }
                        else
                        {
                            m2.addstr = "115";
                        }


                        m3 = drOI.AddModelcalc("99 02 10", qty * 2);
                        m3.addstr = "115";
                        m3.modelpart = m0.modelpart;
                        m3.addstr2 = b.Marking;
                        m3.addstr3 = m0.addstr3;

                        break;

                    case "130711":
                    case "130712":
                        Err = "2";
                        m0 = drOI.AddModelcalc("13 03 03", qty, 150, 90, 90, 0, 0);
                        m0.addstr = "Additional";
                        m0.modelpart = "Ст-" + (b.ID + 1);
                        m0.addstr2 = b.Marking;
                        m0.addstr3 = getSideRussian(b);// + side;

                        m1 = drOI.AddModelcalc("13 80 01", qty);
                        m1.modelpart = m0.modelpart;
                        m1.addstr2 = b.Marking;
                        m1.addstr3 = m0.addstr3;

                        m2 = drOI.AddModelcalc("99 01 35", qty * 4);
                        m2.modelpart = m0.modelpart;
                        m2.addstr2 = b.Marking;
                        m2.addstr3 = m0.addstr3;
                        if (CheckAssembled(b))
                        {
                            //m2.addstr = "";
                        }
                        else
                        {
                            m2.addstr = "115";
                        }

                        m3 = drOI.AddModelcalc("99 02 10", qty * 2);
                        m3.addstr = "115";
                        m3.modelpart = m0.modelpart;
                        m3.addstr2 = b.Marking;
                        m3.addstr3 = m0.addstr3;

                        Err = "5";
                        break;
                }
                Err = "7";

                if (m0 == null || m1 == null || m2 == null || m3 == null)
                {
                    MessageBox.Show("Ошибка скрипта Расчета закладных алюминий: \r\nДля артикула " + b.Marking);
                    //Order.AddErrorUnical(drOI.idorderitem, "о002", "", "Ошибка скрипта Расчета координат закладных алюминий:\r\nДля артикула " + b.Marking + " не удалось рассчитать операции закладных!!!");
                }

                Err = "8";
                // m1.addstr = "78";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка метода SaveModelCalcForRack_Mounts_IP45 \r\nErr: " + Err + "\r\nMessage: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region Mounts City
        public void SaveModelCalcForRack_Mounts_City(ds_order.orderitemRow drOI, Construction model, Balka b, int qtyTop, int qtyBottom)
        {
            if ((qtyTop <= 0 && qtyBottom <= 0) || b == null || drOI == null) return;

            // ПП "Толщина опорной пластины"
            if (model.GetUserParam(3235).StrValue == "2 мм")
                thickOporPlast = 2;
            else if (model.GetUserParam(3235).StrValue == "3 мм")
                thickOporPlast = 3;

            /*
			if( !inRange( Atechnology.ecad.Settings.idpeople, 168, 7228 ) )
			{
				string mountTypeTop = ""; if( model.GetUserParam(31) != null && model.GetUserParam(31).Visible ) mountTypeTop = model.GetUserParam(31).StrValue;
				string mountTypeBottom = ""; if( model.GetUserParam(111) != null && model.GetUserParam(111).Visible ) mountTypeBottom = model.GetUserParam(111).StrValue;
				
				if( qtyTop > 0 ) AddRackRailElementCity( drOI, b, qtyTop, "ВЕРХ", mountTypeTop );
				if( qtyBottom > 0 ) AddRackRailElementCity( drOI, b, qtyBottom, "НИЗ", mountTypeBottom );
			}
			else
			{	*/
            string mountTypeTop = ""; if (model.GetUserParam(4) != null && model.GetUserParam(4).Visible) mountTypeTop = model.GetUserParam(4).StrValue;
            string mountTypeBottom = ""; if (model.GetUserParam(4) != null && model.GetUserParam(4).Visible) mountTypeBottom = model.GetUserParam(4).StrValue;

            if (mountTypeTop == "Навесной" && model.GetUserParam(31) != null && model.GetUserParam(31).Visible)
            {
                mountTypeTop = model.GetUserParam(31).StrValue;
            }

            if (mountTypeBottom == "Навесной" && model.GetUserParam(111) != null && model.GetUserParam(111).Visible)
            {
                mountTypeBottom = model.GetUserParam(111).StrValue;
            }

            if (qtyTop > 0) AddRackRailMountCity(drOI, b, qtyTop, "ВЕРХ", mountTypeTop);
            if (qtyBottom > 0) AddRackRailMountCity(drOI, b, qtyBottom, "НИЗ", mountTypeBottom);

            //			}

            // if( Atechnology.ecad.Settings.idpeople == 168 ) MessageBox.Show( (int)( b.ID + 1 )+ " [marking=" + b.Marking + ", thick="+b.Lenght+"]: " + b.BalkaType.ToString()+ ":: MT: qtyT=" + qtyTop + " [" + mountTypeTop + "], qtyB=" + qtyBottom + " ["+mountTypeBottom+"]" );
        }
        public void AddRackRailElementCity(ds_order.orderitemRow drOI, Balka b, int qty, string side, string mountType)
        {
            // НЕ ИСПОЛЬЗУЕТСЯ
            ds_order.modelcalcRow m0 = null;

            string bmarking = b.Marking.Replace("#", "");
            //			MessageBox.Show( "JJ. " +mountType  );
            switch (bmarking)
            {
                case "17 07 22":
                case "17 07 23":
                case "17 07 24":
                case "17 07 25":
                case "17 07 26":
                case "17 07 27":
                    switch (mountType)
                    {
                        case "Навесной":
                            m0 = drOI.AddModelcalc("99 12 01", qty * 2); m0.addstr = "Additional"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 14 01", qty * 2); m0.addstr = "Additional"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 14 02", qty * 2); m0.addstr = "Additional"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 13 01", qty * 2); m0.addstr = "Additional"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("17 81 01", qty); m0.addstr = "Additional"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            break;
                        case "В проем":
                            m0 = drOI.AddModelcalc("04 06 03_150мм", qty, 150, 90, 90, 0, 0); m0.addstr = "115"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("17 80 02", qty); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 01 35", qty * 4);
                            m0.modelpart = "Ст-" + (b.ID + 1);
                            m0.addstr2 = b.Marking;
                            m0.addstr3 = getSideRussian(b) + ". " + side;
                            if (CheckAssembled(b))
                            {
                                //m0.addstr = "";
                            }
                            else
                            {
                                m0.addstr = "115";
                            }
                            break;
                    }
                    break;


                case "17 07 05":
                    switch (mountType)
                    {
                        case "Навесной":
                            m0 = drOI.AddModelcalc("04 03 10", qty, 150, 90, 90, 0, 0); m0.addstr = "Additional"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("4.8x25 7981", qty * 3); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            break;
                        case "В проем":
                            m0 = drOI.AddModelcalc("04 06 03_150мм", qty, 150, 90, 90, 0, 0); m0.addstr = "115"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("17 80 02", qty); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 01 35", qty * 4);
                            m0.modelpart = "Ст-" + (b.ID + 1);
                            m0.addstr2 = b.Marking;
                            m0.addstr3 = getSideRussian(b) + ". " + side;
                            if (CheckAssembled(b))
                            {
                                //m0.addstr = "";
                            }
                            else
                            {
                                m0.addstr = "115";
                            }
                            break;
                    }
                    break;
                default:
                    switch (mountType)
                    {
                        case "Навесной":
                            m0 = drOI.AddModelcalc("17 04 01", qty, 300, 90, 90, 0, 0); m0.addstr = "Additional"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("13 03 11", qty, 300, 90, 90, 0, 0); m0.addstr = "Additional"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 01 01", qty * 2); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 17 05", qty * 2); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 13 04", qty * 2); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 12 06", qty * 2); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 14 01", qty * 2); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 03 07", qty); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 14 02", qty * 2); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 13 01", qty * 2); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            break;
                        case "В проем":
                            m0 = drOI.AddModelcalc("17 04 03_150мм", qty); m0.addstr = "115"; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("17 80 01", qty); m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
                            m0 = drOI.AddModelcalc("99 01 35", qty * 3);
                            m0.modelpart = "Ст-" + (b.ID + 1);
                            m0.addstr2 = b.Marking;
                            m0.addstr3 = getSideRussian(b) + ". " + side;
                            if (CheckAssembled(b))
                            {
                                //m0.addstr = "";
                            }
                            else
                            {
                                m0.addstr = "115";
                            }
                            break;
                    }
                    break;
            }

        }

        public void AddRackRailMountCity(ds_order.orderitemRow drOI, Balka b, int qty, string side, string mountType)
        {
            //			MessageBox.Show( "AddRackRailMountCity: " + side + ", ID=" + b.ID + ", mountType=" + mountType );
            ds_order.modelcalcRow m0 = null;
            string bmarking = b.Marking.Replace("#", "");

            if (mountType == "От плиты до плиты перекрытия" || mountType == "В проем")
            {
                switch (bmarking)
                {
                    case "17 06 01": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 09 02": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 06": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 01": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 02": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 03": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 08": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 04": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 09": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 11": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 05": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Наружу"); break;

                    case "17 07 22": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Внутрь"); break;
                    case "17 07 23": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Внутрь"); break;
                    case "17 07 24": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "3", "Внутрь"); break;
                    case "17 07 25": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "4", "Внутрь"); break;
                    case "17 07 26": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "5", "Внутрь"); break;
                    case "17 07 27": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "6", "Внутрь"); break;
                    case "17 07 28": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "7", "Внутрь"); break;
                    case "17 07 40": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "8", "Внутрь"); break;
                    case "17 07 41": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "8", "Внутрь"); break;
                    case "17 07 42": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "8", "Внутрь"); break;
                }
            }
            if (mountType == "Навесной")
            {
                switch (bmarking)
                {
                    case "17 06 01": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 09 02": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Наружу"); break;
                    case "17 07 06": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Наружу"); break;
                    case "17 07 01": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Наружу"); break;
                    case "17 07 02": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Наружу"); break;
                    case "17 07 03": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Наружу"); break;
                    case "17 07 08": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Наружу"); break;
                    case "17 07 04": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Наружу"); break;
                    case "17 07 09": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Наружу"); break;
                    case "17 07 11": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Наружу"); break;
                    case "17 07 05": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "3", "Наружу"); break;

                    case "17 07 22": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Внутрь"); break;
                    case "17 07 23": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Внутрь"); break;
                    case "17 07 24": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Внутрь"); break;
                    case "17 07 25": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Внутрь"); break;
                    case "17 07 26": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Внутрь"); break;
                    case "17 07 27": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Внутрь"); break;
                    case "17 07 28": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "1", "Внутрь"); break;
                    case "17 07 40": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Внутрь"); break;
                    case "17 07 41": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Внутрь"); break;
                    case "17 07 42": AddRackRailMountComplectCity(drOI, b, qty, side, mountType, "2", "Внутрь"); break;
                }
            }

        }

        public void AddRackRailMountComplectCity(ds_order.orderitemRow drOI, Balka b, int qty, string side, string mountType, string complectNo, string insideoutside)
        {
            //			MessageBox.Show( "SaveModelCalcForRack_Mounts_City. balkaType=" + b.BalkaType + ",ID=" + b.ID + ", qty=" + qty + ", side=" + side + ", mountType=" + mountType + ", complectNo=" + complectNo );

            ds_order.modelcalcRow m = null;
            string bmarking = b.Marking.Replace("#", "");

            #region Наружу - Перекрытие / Проем
            if (insideoutside == "Наружу" && (mountType == "От плиты до плиты перекрытия" || mountType == "В проем"))
            {
                switch (complectNo)
                {
                    case "1":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("17 04 03_150мм", qty * 1); SetCommonMountComplectData(m, b, side, "115");
                            m = drOI.AddModelcalc("99 01 35", qty * 3); SetCommonMountComplectData(m, b, side, "5");

                            if (thickOporPlast == 2)
                                m = drOI.AddModelcalc("Takt 17 80 01", qty * 1);
                            else if (thickOporPlast == 3)
                                m = drOI.AddModelcalc("17 80 01", qty * 1);
                            SetCommonMountComplectData(m, b, side, "5");
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("17 04 03_150мм", qty * 1); SetCommonMountComplectData(m, b, side, "115");
                            m = drOI.AddModelcalc("99 01 35", qty * 3); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 17 05", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 13 04", qty * 2); SetCommonMountComplectData(m, b, side, "5");

                            if (thickOporPlast == 2)
                                m = drOI.AddModelcalc("Takt 17 80 01", qty * 1);
                            else if (thickOporPlast == 3)
                                m = drOI.AddModelcalc("17 80 01", qty * 1);
                            SetCommonMountComplectData(m, b, side, "5");
                        }
                        if (Atechnology.ecad.Settings.idpeople == 168)
                        {
                            MessageBox.Show("Side=" + side + " Complect No1: " + (b.ID + 1).ToString() + ", b.Len=" + b.Lenght + ", Mark=" + b.Marking);
                        }

                        break;
                    case "2":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("04 06 03_150мм", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side, "115");
                            m = drOI.AddModelcalc("99 01 35", qty * 4); SetCommonMountComplectData(m, b, side, "5");

                            if (thickOporPlast == 2)
                                m = drOI.AddModelcalc("Takt 17 80 02", qty * 1);
                            else if (thickOporPlast == 3)
                                m = drOI.AddModelcalc("17 80 02", qty * 1);
                            SetCommonMountComplectData(m, b, side, "5");
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("04 06 03_150мм", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side, "115");
                            m = drOI.AddModelcalc("99 01 35", qty * 4); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 02 18", qty * 3); SetCommonMountComplectData(m, b, side, "5");

                            if (thickOporPlast == 2)
                                m = drOI.AddModelcalc("Takt 17 80 02", qty * 1);
                            else if (thickOporPlast == 3)
                                m = drOI.AddModelcalc("17 80 02", qty * 1);
                            SetCommonMountComplectData(m, b, side, "5");
                        }
                        break;
                }
            }
            #endregion
            #region Внутр - Перекрытие / Проем
            if (insideoutside == "Внутрь" && (mountType == "От плиты до плиты перекрытия" || mountType == "В проем"))
            {
                switch (complectNo)
                {
                    case "1":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 49 мм", qty * 1); SetCommonMountComplectData(m, b, side);
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 49 мм", qty * 1); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("99 12 06", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        }
                        break;
                    case "2":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 64 мм", qty * 1); SetCommonMountComplectData(m, b, side);
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 64 мм", qty * 1); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("99 12 06", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        }
                        break;
                    case "3":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 78 мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 78 мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("99 12 06", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        }
                        break;
                    case "4":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 88 мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 88 мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("99 12 06", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        }
                        break;
                    case "5":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 104 мм", qty * 1); SetCommonMountComplectData(m, b, side);
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 104 мм", qty * 1); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("99 12 06", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        }
                        break;
                    case "6":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 113 мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("17 04 05_ 113 мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("99 12 06", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        }
                        break;
                    case "7":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("17 04 05_133мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("17 04 05_133мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("99 12 06", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        }
                        break;
                    case "8":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("17 04 12_150мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("13 80 02", qty * 1); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 01 35", qty * 4); SetCommonMountComplectData(m, b, side, "5");
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("17 04 12_150мм", qty * 1); m.smbase4 = 0.5M; SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("13 80 02", qty * 1); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 01 35", qty * 4); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 12 14", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 01", qty * 4); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                            m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        }
                        break;
                }
            }
            #endregion
            #region Наружу - Навесной
            if (insideoutside == "Наружу" && mountType == "Навесной")
            {
                switch (complectNo)
                {
                    case "1":
                        m = drOI.AddModelcalc("17 04 01", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("99 17 05", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 13 04", qty * 2); SetCommonMountComplectData(m, b, side, "5");

                        m = drOI.AddModelcalc("99 03 07", qty * 1); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("13 03 11", qty * 1, 80, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("99 01 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 12 06", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");

                        break;
                    case "2":
                        m = drOI.AddModelcalc("17 04 01", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("13 03 11", qty * 1, 80, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side, "58");
                        m = drOI.AddModelcalc("99 01 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 17 05", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 13 04", qty * 2); SetCommonMountComplectData(m, b, side, "5");

                        m = drOI.AddModelcalc("99 03 07", qty * 1); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 12 06", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        break;
                    case "3":
                        m = drOI.AddModelcalc("04 03 10", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("4.8x25 7981", qty * 3); SetCommonMountComplectData(m, b, side, "5");

                        m = drOI.AddModelcalc("04 06 03_150мм", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side, "115");
                        m = drOI.AddModelcalc("99 12 08", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("01 09 17", qty * 2, 28, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);

                        break;
                }
            }
            #endregion
            #region Внутрь - Навесной
            if (insideoutside == "Внутрь" && mountType == "Навесной")
            {
                switch (complectNo)
                {
                    case "1":
                        m = drOI.AddModelcalc("99 12 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("01 09 17", qty * 2, 11, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        break;
                    case "2":
                        m = drOI.AddModelcalc("17 04 12_150мм", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 12 08", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 14 02", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        m = drOI.AddModelcalc("99 13 01", qty * 2); SetCommonMountComplectData(m, b, side, "5");
                        break;
                }
            }
            #endregion
        }
        #endregion

        #region Mounts_MP640
        public void SaveModelCalcForRack_Mounts_MP640(ds_order.orderitemRow drOI, Construction model, Balka b, int qtyTop, int qtyBottom)
        {
            //			MessageBox.Show( "SaveModelCalcForRack_Mounts_MP640. " + b.ID + ", qtyTop=" + qtyTop + ", qtyBottom=" + qtyBottom );
            if ((qtyTop <= 0 && qtyBottom <= 0) || b == null || drOI == null) return;
            string mountTypeTop = ""; if (model.GetUserParam(4) != null && model.GetUserParam(4).Visible) mountTypeTop = model.GetUserParam(4).StrValue;
            string mountTypeBottom = ""; if (model.GetUserParam(4) != null && model.GetUserParam(4).Visible) mountTypeBottom = model.GetUserParam(4).StrValue;
            if (mountTypeTop == "Навесной" && model.GetUserParam(31) != null && model.GetUserParam(31).Visible)
            {
                mountTypeTop = model.GetUserParam(31).StrValue;
            }

            if (mountTypeBottom == "Навесной" && model.GetUserParam(111) != null && model.GetUserParam(111).Visible)
            {
                mountTypeBottom = model.GetUserParam(111).StrValue;
            }

            // MessageBox.Show( "SaveModelCalcForRack_Mounts_MP640. " + b.ID + ", qtyTop=" + qtyTop + ", qtyBottom=" + qtyBottom + ", mountType=" + mountType );
            if (qtyTop > 0) AddRackRailMountMP640(drOI, b, qtyTop, "ВЕРХ", mountTypeTop);
            if (qtyBottom > 0) AddRackRailMountMP640(drOI, b, qtyBottom, "НИЗ", mountTypeBottom);
        }
        public void AddRackRailMountMP640(ds_order.orderitemRow drOI, Balka b, int qty, string side, string mountType)
        {
            ds_order.modelcalcRow m = null;
            string bmarking = b.Marking.Replace("#", "");

            if (mountType == "От плиты до плиты перекрытия" || mountType == "В проем")
            {
                switch (bmarking)
                {
                    case "МП-64087": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "5"); break;
                    case "МП-64023-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "4"); break;
                    case "МП-64090-04": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "3"); break;
                    case "МП-64090-02":
                    case "МП-64090":
                    case "МП-64090-01":
                    case "МП-64091-02":
                    case "МП-64091":
                    case "МП-64091-01":
                    case "МП-64092-02":
                    case "МП-64092":
                    case "МП-64020":
                    case "МП-64020-02":
                    case "МП-64029":
                    case "МП-64021-04":
                    case "МП-64024-01":
                    case "МП-64024":
                    case "МП-64025":
                    case "МП-64027":
                    case "МП-64024-03": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "1"); break;
                    case "МП-64024-04": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "1"); break;
                    case "МП-64024-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "1"); break;
                    case "МП-64024-05": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "2"); break;
                    case "МП-64022-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "1"); break;
                    case "МП-64022-01": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "4"); break;
                }
            }
            if (mountType == "Навесной")
            {
                switch (bmarking)
                {
                    case "МП-64023-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "4"); break;
                    case "МП-64090-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "5"); break;
                    case "МП-64090": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "5"); break;
                    case "МП-64090-01": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "5"); break;
                    case "МП-64091-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "5"); break;
                    case "МП-64091": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "5"); break;
                    case "МП-64091-01": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "5"); break;
                    case "МП-64092-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "5"); break;
                    case "МП-64092": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "5"); break;
                    case "МП-64020": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "1"); break;
                    case "МП-64020-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "1"); break;
                    case "МП-64029": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "3"); break;
                    case "МП-64021-04": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "1"); break;
                    case "МП-64024-01": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "2"); break;
                    case "МП-64024": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "2"); break;
                    case "МП-64024-03": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "2"); break;
                    case "МП-64024-04": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "2"); break;
                    case "МП-64024-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "2"); break;
                    case "МП-64024-05": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "6"); break;
                    case "МП-64022-02": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "1"); break;
                    case "МП-64022-01": AddRackRailMountComplectMP640(drOI, b, qty, side, mountType, "1"); break;
                }
            }
        }
        public void SetCommonMountComplectData(ds_order.modelcalcRow m0, Balka b, string side, string addstr = "")
        {
            m0.addstr = addstr == "" ? "Additional" : addstr; m0.modelpart = "Ст-" + (b.ID + 1); m0.addstr2 = b.Marking; m0.addstr3 = getSideRussian(b) + ". " + side;
        }
        public void AddRackRailMountComplectMP640(ds_order.orderitemRow drOI, Balka b, int qty, string side, string mountType, string complectNo)
        {
            //MessageBox.Show( "SaveModelCalcForRack_Mounts_MP640. balkaType=" + b.BalkaType + ",ID=" + b.ID + ", qty=" + qty + ", side=" + side + ", mountType=" + mountType + ", complectNo=" + complectNo );

            ds_order.modelcalcRow m = null;
            string bmarking = b.Marking.Replace("#", "");

            if (mountType == "От плиты до плиты перекрытия" || mountType == "В проем")
            {
                switch (complectNo)
                {
                    case "1":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("МП-64071", qty * 1, 80, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("УМП-177", qty * 1); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("4,2х32 DIN 7982", qty * 4); SetCommonMountComplectData(m, b, side);
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("МП-64071", qty * 1, 80, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("МПУ-69101", qty * 1); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("УМП-177", qty * 1); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("4,2х32 DIN 7982", qty * 4); SetCommonMountComplectData(m, b, side);
                        }
                        break;
                    case "2":
                        if (side == "ВЕРХ")
                        {
                            m = drOI.AddModelcalc("МП-64071-01", qty * 1, 80, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("УМП-177", qty * 1); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("4,2х32 DIN 7982", qty * 4); SetCommonMountComplectData(m, b, side);
                        }
                        if (side == "НИЗ")
                        {
                            m = drOI.AddModelcalc("МП-64071-01", qty * 1, 80, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("МПУ-69101", qty * 1); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("УМП-177", qty * 1); SetCommonMountComplectData(m, b, side);
                            m = drOI.AddModelcalc("4,2х32 DIN 7982", qty * 4); SetCommonMountComplectData(m, b, side);
                        }
                        break;
                    case "3":
                        m = drOI.AddModelcalc("МП-64059", qty * 1, 80, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("УМП-177", qty * 1); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("4,2х32 DIN 7982", qty * 2); SetCommonMountComplectData(m, b, side);
                        break;
                    case "4":
                        // m = drOI.AddModelcalc("МП-64060", qty * 1, 80, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МП-64060_80мм", qty * 1); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("УМП-177", qty * 1); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("4,2х32 DIN 7982", qty * 2); SetCommonMountComplectData(m, b, side);
                        break;
                    case "5":
                        m = drOI.AddModelcalc("МП-64078", qty * 1, 80, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("УМП-177", qty * 1); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("4,2х32 DIN 7982", qty * 2); SetCommonMountComplectData(m, b, side);
                        break;

                }
            }
            if (mountType == "Навесной")
            {
                switch (complectNo)
                {
                    case "1":
                        m = drOI.AddModelcalc("МП-64060", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МП-5051", qty * 2, 17, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side); m.smbase4 = 0.5M;
                        m = drOI.AddModelcalc("Шина 100х5 DIN", qty * 1, 119, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х25 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х40 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN9021 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN125 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 65Г DIN127 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Гайка М8 DIN934 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МПУ-020", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("УМП-048", qty * 1); SetCommonMountComplectData(m, b, side);
                        break;
                    case "2":
                        m = drOI.AddModelcalc("УМП-013", qty * 1); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МП-5051", qty * 2, 8, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шина 100х5 DIN", qty * 1, 119, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х25 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х40 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN9021 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN125 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 65Г DIN127 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Гайка М8 DIN934 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МПУ-020", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("УМП-048", qty * 1); SetCommonMountComplectData(m, b, side);
                        break;
                    case "3":
                        m = drOI.AddModelcalc("МП-64059", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МП-5051", qty * 2, 16, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side); m.smbase4 = 0.5M;
                        m = drOI.AddModelcalc("Шина 100х5 DIN", qty * 1, 119, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х25 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х40 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN9021 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN125 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 65Г DIN127 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Гайка М8 DIN934 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МПУ-020", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("УМП-048", qty * 1); SetCommonMountComplectData(m, b, side);
                        break;
                    case "4":
                        m = drOI.AddModelcalc("МП-64060", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МП-5051", qty * 2, 17, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side); m.smbase4 = 0.5M;
                        m = drOI.AddModelcalc("Шина 100х5 DIN", qty * 1, 119, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х25 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х40 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN9021 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN125 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 65Г DIN127 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Гайка М8 DIN934 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МПУ-020", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("УМП-048", qty * 1); SetCommonMountComplectData(m, b, side);
                        break;
                    case "5":
                        m = drOI.AddModelcalc("МП-64056", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шина 100х5 DIN", qty * 1, 119, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х30 DIN965 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х19 DIN9316 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х25 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN125 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 65Г DIN127 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Гайка М8 DIN934 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("УМП-048", qty * 1); SetCommonMountComplectData(m, b, side);
                        break;
                    case "6":
                        m = drOI.AddModelcalc("УМП-013", qty * 1); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МП-64071-01", qty * 1, 150, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("4,2х32 DIN 7982", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МП-5051", qty * 2, 8, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шина 100х5 DIN", qty * 1, 119, 0, 0, 0, 0); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х25 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("М8х40 DIN933 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN9021 A2", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 DIN125 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Шайба 8 65Г DIN127 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("Гайка М8 DIN934 A2", qty * 4); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("МПУ-020", qty * 2); SetCommonMountComplectData(m, b, side);
                        m = drOI.AddModelcalc("УМП-048", qty * 1); SetCommonMountComplectData(m, b, side);
                        break;
                }
            }
        }
        #endregion

        ds_order.orderitemRow getRootProduction(ds_order.orderitemRow drOI_cur)
        {
            ds_order.orderitemRow drParent_OI = null;
            if (drOI_cur == null) return null;
            if (!drOI_cur.IsparentidNull())
            {
                foreach (ds_order.orderitemRow drOI_1 in Order.ds.orderitem.Select("idorderitem=" + drOI_cur.parentid.ToString()))
                {
                    drParent_OI = drOI_1;
                }
            }
            if (drParent_OI == null)
            {
                return drOI_cur;
            }
            else
            {
                if (drParent_OI.idproductiontype != 107) // Если не конструкция, иду вверх
                {
                    return getRootProduction(drParent_OI);
                }
                else
                {
                    return drOI_cur;
                }
            }
        }


        #region Вспомогательные методы

        // Процедура получения перечня элементов указанной группы заполнения с поправками и коэффициентами, а также глубины вхождения заполнения в профиль
        public bool getShtapicGroupDetail(int idShtapicGroup, int thick, string profileMark, ref string[] markingList, ref decimal[] deltaSum, ref decimal[] coeffList, ref decimal zap_depth)
        {
            bool res = false;
            string sql = @"
				declare @thick_zap int = " + thick.ToString() + ";" + @"
				declare @idshtapicgroup int = " + idShtapicGroup.ToString() + ";" + @"
				declare @profilename varchar(255) = '" + profileMark + "';" + @"
				
				select g.marking, 
				( select sum( sgpd.numvalue ) from shtapikgroupparamdetail sgpd where sgpd.idshtapikgroupdetail=sgd.idshtapikgroupdetail and sgpd.deleted is null and sgpd.idvariantparamtype=39 ) delta_sum,
				( select EXP(SUM(LOG( sgpd2.numvalue ))) from shtapikgroupparamdetail sgpd2 where sgpd2.idshtapikgroupdetail=sgd.idshtapikgroupdetail and sgpd2.deleted is null and sgpd2.idvariantparamtype=48 ) coeff,
				( select top 1 sgp.size from shtapikgroupprofile sgp 
				join systemdetail sd on sd.idsystemdetail=sgp.idsystemdetail and sd.deleted is null 
				where sgp.idshtapikgroup=sgd.idshtapikgroup and sgp.deleted is null and sd.name=@profilename ) depth
				from shtapikgroupdetail sgd 
				join good g on g.idgood=sgd.idgood and g.deleted is null
				left join goodparam gp on gp.idgood=g.idgood and gp.idgoodparamname=84 and gp.deleted is null
				where sgd.idshtapikgroup=@idshtapicgroup and sgd.deleted is null
				and ( gp.intvalue=107 or g.idgoodtype=11 )
				and ( 
				( sgd.thick <= @thick_zap and @thick_zap <= sgd.thick2 ) OR
				( @thick_zap = sgd.thick and sgd.thick2 is null )
				)
				";
            DataTable tableTemp = new DataTable();
            dbconn _db = new dbconn();
            _db.command.CommandText = sql;
            _db.OpenDB();
            _db.adapter.Fill(tableTemp);
            _db.CloseDB();

            if (tableTemp.Select().Length > 0)
            {
                res = true;
                foreach (DataRow drVal in tableTemp.Select())
                {
                    string mark = Useful.GetString(drVal["marking"], "");
                    decimal delta = Useful.GetDecimal(drVal["delta_sum"], 0);
                    decimal coeff = Useful.GetDecimal(drVal["coeff"], 1);
                    if (mark != "")
                    {
                        Array.Resize(ref markingList, markingList.Length + 1); markingList[markingList.Length - 1] = mark;
                        Array.Resize(ref deltaSum, deltaSum.Length + 1); deltaSum[deltaSum.Length - 1] = delta;
                        Array.Resize(ref coeffList, coeffList.Length + 1); coeffList[coeffList.Length - 1] = coeff;
                    }
                    zap_depth = Useful.GetDecimal(drVal["depth"], 0);
                }
            }

            return res;
        }
        public bool getShtapicGroupDetail2(int idShtapicGroup, int thick, string profileMark, ref string[] markingList, ref decimal[] deltaSum, ref decimal[] coeffList, ref decimal zap_depth)
        {
            bool res = false;
            DataTable tableTemp = new DataTable();
            string dtLogs = DateTime.Now.ToString("HH:mm:ss.fff");
           
           /* string select_filter1 = "[idshtapikgroup]='" + idShtapicGroup.ToString() + "' AND [profilename]='" + profileMark + "'" +
                " AND ( " +
                "( [thick]<=" + thick.ToString() + " AND [thick2]>=" + thick.ToString() + " )" +
                " OR " +
                "( [thick]=" + thick.ToString() + " AND [thick2] is null ) " +
                ")";
            DataRow[] ddd1 = t_alu_dobor.Select(select_filter1);
            dtLogs += "\n" + DateTime.Now.ToString("HH:mm:ss.fff");*/

            string select_filter = "[idshtapikgroup]='" + idShtapicGroup.ToString() + "' AND [profilename]='" + profileMark + "'";
            //Разделил фильтр на 2 части, тк так гораздо быстрее выполняется
            string thickness_filer =   "( " +
                "( [thick]<=" + thick.ToString() + " AND [thick2]>=" + thick.ToString() + " )" +
                " OR " +
                "( [thick]=" + thick.ToString() + " AND [thick2] is null ) " +
                ")";
            DataRow[] ddd = t_alu_dobor.Select(select_filter);
           
            if (ddd.Length > 0)
            {
                DataRow[] filteredArr = ddd.CopyToDataTable().Select(thickness_filer);
                if (filteredArr.Length > 0)
                {
                    res = true;
                    foreach (DataRow drVal in filteredArr)
                    {
                        //					if( idShtapicGroup == 41 && profileMark == "010205" )
                        //					{
                        //						MessageBox.Show( Useful.GetString( drVal["marking"], "" ) +", thick=" + thick.ToString() );
                        //					}
                        string mark = Useful.GetString(drVal["marking"], "");
                        decimal delta = Useful.GetDecimal(drVal["delta_sum"], 0);
                        decimal coeff = Useful.GetDecimal(drVal["coeff"], 1);
                        if (mark != "")
                        {
                            Array.Resize(ref markingList, markingList.Length + 1); markingList[markingList.Length - 1] = mark;
                            Array.Resize(ref deltaSum, deltaSum.Length + 1); deltaSum[deltaSum.Length - 1] = delta;
                            Array.Resize(ref coeffList, coeffList.Length + 1); coeffList[coeffList.Length - 1] = coeff;
                        }
                        zap_depth = Useful.GetDecimal(drVal["size"], 0);
                    }
                }
            }


            return res;
        }

        // Процедура определения доборных элементов с поправками и коэффициентами
        public bool getInsertionDetail_OLD(int idInsertion, ref string[] markingList, ref decimal[] deltaSum, ref decimal[] coeffList)
        {
            bool res = false;
            string sql = @"
				declare @idinsertion int = " + idInsertion.ToString() + ";" + @"
				
				select  
				g.marking, 
				( select sum( ipd.numvalue ) from insertionparamdetail ipd where ipd.idinsertiondetail=id.idinsertiondetail and ipd.deleted is null and ipd.idvariantparamtype=39 ) delta_sum,
				( select EXP(SUM(LOG(ipd2.numvalue))) from insertionparamdetail ipd2 where ipd2.idinsertiondetail=id.idinsertiondetail and ipd2.deleted is null and ipd2.idvariantparamtype=48 ) coeff
				from insertion i
				join insertiondetail id on id.idinsertion=i.idinsertion and id.deleted is null
				join good g on g.idgood=id.idgood and g.deleted is null
				left join goodparam gp on gp.idgood=g.idgood and gp.deleted is null and gp.idgoodparamname=84
				where 
				i.deleted is null and i.idinsertion=@idinsertion
				and ( gp.intvalue=107 or g.idgoodtype=11 ) and i.name not like '%Держатель%'
				";
            // and ( gp.intvalue=107 or g.idgoodtype=11 )
            DataTable tableTemp = new DataTable();
            dbconn _db = new dbconn();
            _db.command.CommandText = sql;
            _db.OpenDB();
            _db.adapter.Fill(tableTemp);
            _db.CloseDB();

            if (tableTemp.Select().Length > 0)
            {
                /*
				if( tableTemp.Select().Length > 2 )
				{
//					MessageBox.Show( "I=" + idInsertion.ToString() + ", CNT=" + tableTemp.Select().Length.ToString() );
				}
*/
                res = true;
                foreach (DataRow drVal in tableTemp.Select())
                {
                    string mark = Useful.GetString(drVal["marking"], "");
                    decimal delta = Useful.GetDecimal(drVal["delta_sum"], 0);
                    decimal coeff = Useful.GetDecimal(drVal["coeff"], 1);
                    if (mark != "")
                    {
                        Array.Resize(ref markingList, markingList.Length + 1); markingList[markingList.Length - 1] = mark;
                        Array.Resize(ref deltaSum, deltaSum.Length + 1); deltaSum[deltaSum.Length - 1] = delta;
                        Array.Resize(ref coeffList, coeffList.Length + 1); coeffList[coeffList.Length - 1] = coeff;
                    }
                }
            }

            return res;
        }
        public bool getInsertionDetail(int idInsertion, ref string[] markingList, ref decimal[] deltaSum, ref decimal[] coeffList)
        {
            bool res = false;
            string sql = @"
				declare @idinsertion int = " + idInsertion.ToString() + ";" + @"
				
				select  
				g.marking, 
				( select sum( ipd.numvalue ) from insertionparamdetail ipd where ipd.idinsertiondetail=id.idinsertiondetail and ipd.deleted is null and ipd.idvariantparamtype=39 ) delta_sum,
				( select EXP(SUM(LOG(ipd2.numvalue))) from insertionparamdetail ipd2 where ipd2.idinsertiondetail=id.idinsertiondetail and ipd2.deleted is null and ipd2.idvariantparamtype=48 ) coeff
				from insertion i
				join insertiondetail id on id.idinsertion=i.idinsertion and id.deleted is null
				join good g on g.idgood=id.idgood and g.deleted is null
				left join goodparam gp on gp.idgood=g.idgood and gp.deleted is null and gp.idgoodparamname=84
				where 
				i.deleted is null and i.idinsertion=@idinsertion
				and ( gp.intvalue=107 or g.idgoodtype=11 ) and i.name not like '%Держатель%'
				";

            DataRow[] ddd = t_alu_dobor_rama.Select("[idinsertion]='" + idInsertion.ToString() + "'");
            if (ddd.Length > 0)
            {
                res = true;
                foreach (DataRow drVal in ddd)
                {
                    string mark = Useful.GetString(drVal["marking"], "");
                    decimal delta = Useful.GetDecimal(drVal["delta_sum"], 0);
                    decimal coeff = Useful.GetDecimal(drVal["coeff"], 1);
                    if (mark != "")
                    {
                        Array.Resize(ref markingList, markingList.Length + 1); markingList[markingList.Length - 1] = mark;
                        Array.Resize(ref deltaSum, deltaSum.Length + 1); deltaSum[deltaSum.Length - 1] = delta;
                        Array.Resize(ref coeffList, coeffList.Length + 1); coeffList[coeffList.Length - 1] = coeff;
                    }
                }
            }

            return res;
        }

        private bool inRange(string str, params string[] args)
        {
            foreach (var item in args)
            {
                if (str == item)
                {
                    return true;
                }
            }
            return false;
        }
        private bool inRange(int str, params int[] args)
        {
            foreach (var item in args)
            {
                if (str == item)
                {
                    return true;
                }
            }
            return false;
        }
        private bool inRange(decimal str, params decimal[] args)
        {
            foreach (var item in args)
            {
                if (str == item)
                {
                    return true;
                }
            }
            return false;
        }

        // Определение русской подписи стороны балки
        string getSideRussian(Balka bi)
        {
            switch (bi.Side.ToString().ToLower())
            {
                case "bottom": return "Низ"; break;
                case "top": return "Верх"; break;
                case "left": return "Лево"; break;
                case "right": return "Право"; break;
            }
            return "";
        }

        /*
		public void LoadALUDobor()
		{
			t_alu_Dobor=new DataTable();
			dbconn._db.command.CommandText=
				@"select g.marking, sgd.thick, sgd.thick2, sgd.idshtapikgroup, sgp.size, sd.name profilename, 
				( select sum( sgpd.numvalue ) from shtapikgroupparamdetail sgpd where sgpd.idshtapikgroupdetail=sgd.idshtapikgroupdetail and sgpd.deleted is null and sgpd.idvariantparamtype=39 ) delta_sum,
				( select EXP(SUM(LOG( sgpd2.numvalue ))) from shtapikgroupparamdetail sgpd2 where sgpd2.idshtapikgroupdetail=sgd.idshtapikgroupdetail and sgpd2.deleted is null and sgpd2.idvariantparamtype=48 ) coeff
				from shtapikgroupdetail sgd 
				join good g on g.idgood=sgd.idgood and g.deleted is null
				left join goodparam gp on gp.idgood=g.idgood and gp.idgoodparamname=84 and gp.deleted is null
				join shtapikgroupprofile sgp on sgp.idshtapikgroup=sgd.idshtapikgroup and sgp.deleted is null
				join systemdetail sd on sd.idsystemdetail=sgp.idsystemdetail and sd.deleted is null 
				where sgd.deleted is null
				and ( gp.intvalue=107 or g.idgoodtype=11 )
				";
			dbconn._db.adapter.Fill(t_alu_Dobor);
		}
*/

        #endregion

        public void fillArrayFromTo(ref bool[] arr, int start, int stop, bool val)
        {
            int b = start; int e = stop;
            if (b < 0) b = 0;
            if (e > arr.Length - 1) e = arr.Length - 1;
            if (b > e) { int tmp = b; b = e; e = tmp; }
            for (int i = b; i < e; i++) arr[i] = val;
        }

        string getBalkaIndex(Balka b, Dictionary<string, string> beamMarkingDic)
        {
            string res = "";
            string IDs = Useful.GetString(b.ID + 1, "");
            switch (b.BalkaType)
            {
                case ModelPart.Impost: res = "И-" + IDs; break;
                case ModelPart.RamaItem: res = "Р-" + IDs; break;
                default: res = b.BalkaType.ToString() + "-" + IDs; break;
            }


            if (Atechnology.ecad.Settings.idpeople == 803)
            {
                string result = "";
                if (beamMarkingDic.TryGetValue(b.Guid, out result))
                {
                    res = result;
                }
            }

            return res;
        }

        public int roundToMax(double x)
        {
            if (x > Convert.ToDouble(Math.Truncate(x))) { return Convert.ToInt32(Math.Truncate(x) + 1); } else { return Convert.ToInt32(Math.Truncate(x)); }
        }

        void CITY_AddFrezToBalka(ds_order.orderitemRow drOI, Balka i, string artLeftBalka, string artRightBalka, string balkaIndex)
        {
            bool left_frez11 =
                (
                (
                inRange(i.Marking, "17 06 05", "#17 06 05") && inRange(artLeftBalka, "17 07 01", "#17 07 01", "17 07 02", "#17 07 02", "17 07 06", "#17 07 06")
                )
                ||
                (
                inRange(i.Marking, "17 06 04", "#17 06 04") && inRange(artLeftBalka, "17 07 06", "#17 07 06")
                )
                );
            bool right_frez11 =
                (
                (
                inRange(i.Marking, "17 06 05", "#17 06 05") && inRange(artRightBalka, "17 07 01", "#17 07 01", "17 07 02", "#17 07 02", "17 07 06", "#17 07 06")
                )
                ||
                (
                inRange(i.Marking, "17 06 04", "#17 06 04") && inRange(artRightBalka, "17 07 06", "#17 07 06")
                )
                );

            int frez_left = 10; int frez_right = 10;
            if (left_frez11) frez_left = 11;
            if (right_frez11) frez_right = 11;

            double l = i.LengthInterfaceCalc;
            Operation op;
            op = new Operation("fr_left", frez_left, balkaIndex + ": " + i.Marking.Replace("#", "") + " [соединение с " + artLeftBalka.Replace("#", "") + "]", (double)l, (double)l); i.OperationList.Add(op);
            op = new Operation("fr_right", frez_right, balkaIndex + ": " + i.Marking.Replace("#", "") + " [соединение с " + artRightBalka.Replace("#", "") + "]", (double)l, (double)l); i.OperationList.Add(op);

        }

        void CalcGoodsForOuter(int outerLen, ds_order.orderitemRow drOI, string strForSearchIns, string strForParam, string riInsertions)
        {
            //			if(Atechnology.ecad.Settings.idpeople == 2214)
            //			{
            //				MessageBox.Show("outerLen = " + outerLen + "\r\n" + riInsertions + "\r\nstrForSearchIns: " + strForSearchIns + "\r\nstrForParam: " + strForParam);
            //			}
            //Сначала собираем для тех материалов, которые не зависят от польз. параметров
            DataRow[] drs = dtInsForCalcOuter.Select("idinsertion in (" + riInsertions + ") and name = '" + strForSearchIns + "'" + " and strvalue is null");
            foreach (DataRow drG in drs)
            {
                drOI.AddModelcalc(drG["marking"].ToString(), 1.0m, (int)outerLen, 0, 0, 0, 0);
                dist = drG["marking"].ToString();
            }
            #region Для материалов у которых есть параметры 
            //			drs = dtInsForCalcOuter.Select("idinsertion in (" + riInsertions + ") and name = '" + strForSearchIns + "'" +
            //				" and strvalue = '" + strForParam + "'");
            //												
            //			foreach(DataRow drG in drs)
            //			{
            //				drOI.AddModelcalc(drG["marking"].ToString(),1.0m,(int)outerLen,0,0,0,0);
            //			}
            #endregion Для материалов у которых есть параметры 
        }

        void CalcUplForOuter(string proSys, int thickness, int outerLen)
        {
            //определяем название группы заполнения для поиска Inicial IF50 R2R 40 стойка
            string SHG = "";
            if (proSys == "Inicial IF50 RR")
                SHG = "name = '" + proSys + " " + thickness + "" + "' and thick = " + thickness;
            else
                SHG = "name = '" + proSys + " " + thickness + " стойка" + "' and thick = " + thickness;

            //MessageBox.Show(SHG);
            DataRow[] drs = dtshgForCalcOuter.Select(SHG);
            if (drs.Length > 0)
            {
                foreach (DataRow drG in drs)
                {
                    drOI.AddModelcalc(drG["marking"].ToString(), 1.0m, (int)outerLen, 0, 0, 0, 0);
                }
            }

        }

        public void InitBeamMarkingDict(Construction model, Dictionary<string, string> beamMarkingDict)
        {
            try
            {
                int cntRack = 0;
                int cntRail = 0;
                string modelPart = string.Empty;

                if (model != null)
                {
                    foreach (Impost imp in model.ImpostList)
                    {
                        modelPart = "";
                        if (imp.IsRack)
                        {
                            modelPart = "Ст-" + (++cntRack);
                        }
                        else if (imp.IsRail)
                        {
                            modelPart = "Ри-" + (++cntRail);
                        }

                        beamMarkingDict.Add(imp.Guid, modelPart);
                    }

                    foreach (RamaItem ri in model.Rama)
                    {
                        modelPart = "";
                        if (ri.IsRack)
                        {
                            modelPart = "Ст-" + (++cntRack);
                        }
                        else if (ri.IsRail)
                        {
                            modelPart = "Ри-" + (++cntRail);
                        }
                        beamMarkingDict.Add(ri.Guid, modelPart);
                    }
                }
            }
            catch (Exception e)
            {
                if (Atechnology.ecad.Settings.idpeople == 803)
                {
                    MessageBox.Show(e.Message + "\n\n" + e.StackTrace);
                }
            }
        }

        string GetErrForRackLen(Construction model)
        {
            string Err = "";
            string errImpLen = "";
            try
            {
                if (model.ProfileSystem == "Inicial IF50 RR" || model.ProfileSystem == "Inicial IF50 R2R")
                {
                    foreach (Impost i in model.ImpostList)
                    {
                        if (i.IsRack && i.BalkaEnd1Type == ModelPart.Impost)
                        {
                            Err = "1";
                            if ((i.Lenght + i.BalkaEnd1.Lenght) > model.Height)
                            {
                                errImpLen = "ВНИМАНИЕ!!!Высота стойки СТ-" + (i.ID + 1) + " и СТ-" + (i.BalkaEnd.ID + 1) + " превышает высоту конструкции!!!";
                                return errImpLen;
                            }
                        }
                        if (i.IsRack && i.BalkaEnd != null && i.BalkaEnd.IsRack && i.BalkaEndType == ModelPart.Impost)
                        {
                            Err = "2";
                            if ((i.Lenght + i.BalkaEnd.Lenght) > model.Height)
                            {
                                errImpLen = "ВНИМАНИЕ!!!Высота стойки СТ-" + (i.ID + 1) + " и СТ-" + (i.BalkaEnd.ID + 1) + " превышает высоту конструкции!!!";
                                return errImpLen;
                            }
                        }
                        if (i.IsRack && i.BalkaStart1Type == ModelPart.Impost && i.BalkaStart.IsRack)
                        {
                            Err = "3";
                            if ((i.Lenght + i.BalkaStart1.Lenght) > model.Height)
                            {
                                errImpLen = "ВНИМАНИЕ!!!Высота стойки СТ-" + (i.ID + 1) + " и СТ-" + (i.BalkaStart.ID + 1) + " превышает высоту конструкции!!!";
                                return errImpLen;
                            }
                        }
                        if (i.IsRack && i.BalkaStart != null && i.BalkaStart.IsRack && i.BalkaStartType == ModelPart.Impost)
                        {
                            Err = "4";
                            if ((i.Lenght + i.BalkaStart.Lenght) > model.Height)
                            {
                                errImpLen = "Высота стойки СТ-" + (i.ID + 1) + " и СТ-" + (i.BalkaStart.ID + 1) + " превышает высоту конструкции!!!";
                                return errImpLen;
                            }
                        }
                    }

                    foreach (RamaItem ri in model.Rama)
                    {
                        if (ri.IsRack && ri.BalkaEnd != null && ri.BalkaEnd.IsRack && ri.BalkaEnd.BalkaType == ModelPart.RamaItem)
                        {
                            Err = "5";
                            if (ri.Lenght + ri.BalkaEnd.Lenght > model.Height)
                            {
                                errImpLen = "ВНИМАНИЕ!!!Суммарная высота стойки СТ-" + (ri.ID + 1) + " и СТ-" + (ri.BalkaEnd.ID + 1) + " = " + (ri.Lenght + ri.BalkaEnd.Lenght) + " превышает высоту конструкции!!!";
                                return errImpLen;
                            }
                        }
                        if (ri.IsRack && ri.BalkaStart != null && ri.BalkaStart.IsRack && ri.BalkaStart.BalkaType == ModelPart.RamaItem)
                        {
                            Err = "6";
                            if (ri.Lenght + ri.BalkaStart.Lenght > model.Height)
                            {
                                errImpLen = "ВНИМАНИЕ!!!Суммарная высота стойки СТ-" + (ri.ID + 1) + " и СТ-" + (ri.BalkaStart.ID + 1) + " = " + (ri.Lenght + ri.BalkaStart.Lenght) + " превышает высоту конструкции!!!";
                                return errImpLen;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Order.AddErrorUnical(drOI.idorderitem, "о002", "", "Ошибка скрипта Расчета координат закладных алюминий:\r\nМетод GetErrForRackLen \r\n"
                    + ex.Message + "\r\n" + ex.TargetSite.ToString() + " \r\n" + ex.StackTrace + "\r\nТочка:" + Err);
            }
            return errImpLen;
        }

        #region Дренажи
        public int SaveDrenag(Construction model)
        {
            int count = 0;
            int count2 = 0;
            // string vodootvod=model.GetUserParam("Дренаж").StrValue;
            string vodootvod = "Снаружи";
            if (vodootvod == "Снаружи" || vodootvod == "Изнутри")
            {
                string dren_sliv = "";
                //Расчет дренажных крышек для нижней рамы
                foreach (RamaItem ri in model.Rama)
                {
                    if ((ri.AngNakl == 0 || ri.AngNakl == 180)
                        && ri.Side == ItemSide.Bottom && ri.RamaType == RamaType.Rama) // если это нижняя горизонтальная балка
                    {

                        if (ri.LenghtC < 355 && ri.ImpostPositionList.Count == 0)
                        {
                            //Слив
                            AddOperation(ri, ri.Lenght / 2, dren_sliv);
                            count++;
                        }
                        else if (ri.LenghtC < 480 && ri.ImpostPositionList.Count == 0)
                        {
                            //Слив
                            AddOperation(ri, ri.Lenght / 2, dren_sliv);
                            count++;
                        }
                        else if (ri.LenghtC >= 480 && ri.ImpostPositionList.Count == 0)
                        {
                            //Слив
                            AddOperation(ri, (int)ri.C + 185, dren_sliv);
                            count++;
                            AddOperation(ri, ri.Lenght - (int)ri.C - 185, dren_sliv);
                            count++;
                            if (ri.LenghtC > 1800)
                            {
                                AddOperation(ri, ri.Lenght / 2, dren_sliv);
                                count++;
                            }
                        }
                        else
                        {
                            //Слив
                            AddOperation(ri, (int)ri.C + 185, dren_sliv);
                            count++;
                            AddOperation(ri, ri.Lenght - (int)ri.C - 185, dren_sliv);
                            count++;

                            if (ri.LenghtC > 1800)
                            {
                                bool DrenagAdded = false;
                                if (ri.ImpostPositionList.Count > 0)
                                {
                                    foreach (int ImpostPos in ri.ImpostPositionList)
                                    {
                                        if (ImpostPos > ri.Lenght / 2 - 100 && ImpostPos < ri.Lenght / 2 + 100)
                                        {
                                            //MessageBox.Show("ri.Lenght="+ri.Lenght+" ImpostPos="+ImpostPos);
                                            AddOperation(ri, ImpostPos, dren_sliv);
                                            count++;
                                            DrenagAdded = true;
                                            break;
                                        }
                                    }
                                }
                                if (!DrenagAdded)
                                {
                                    AddOperation(ri, ri.Lenght / 2, dren_sliv);
                                    count++;
                                }
                            }
                        }
                    }
                }


                //Расчет дренажных крышек для горизонтальных импостов WHS, WHS 72 и Сателс
                foreach (Impost im in model.ImpostList)
                {
                    if (im.Hide == true || (im.Marking != "102013" && im.Marking != "102309" && im.Marking != "102309900001" && im.Marking != "102309WHS"))
                        continue;

                    if ((im.AngNakl == 0 || im.AngNakl == 180)) // если это горизонтальная балка
                    {

                        if (im.LenghtC < 355 && im.ImpostPositionList.Count == 0)
                        {
                            AddOperation(im, im.Lenght / 2, dren_sliv);
                            count2++;
                        }
                        else if (im.LenghtC < 480 && im.ImpostPositionList.Count == 0)
                        {
                            AddOperation(im, im.Lenght / 2, dren_sliv);
                            count2++;
                        }
                        else if (im.LenghtC >= 480 && im.ImpostPositionList.Count == 0)
                        {
                            AddOperation(im, (int)im.C + 185, dren_sliv);
                            count2++;
                            AddOperation(im, im.Lenght - (int)im.C - 185, dren_sliv);
                            count2++;
                            if (im.LenghtC > 1800)
                            {
                                AddOperation(im, im.Lenght / 2, dren_sliv);
                                count2++;
                            }
                        }
                        else
                        {
                            AddOperation(im, 185, dren_sliv);
                            count2++;
                            AddOperation(im, im.Lenght - 185, dren_sliv);
                            count2++;

                            if (im.LenghtC > 1800)
                            {
                                bool DrenagAdded = false;
                                if (im.ImpostPositionList.Count > 0)
                                {
                                    foreach (int ImpostPos in im.ImpostPositionList)
                                    {
                                        if (ImpostPos > im.Lenght / 2 - 100 && ImpostPos < im.Lenght / 2 + 100)
                                        {
                                            AddOperation(im, ImpostPos, dren_sliv);
                                            count2++;
                                            DrenagAdded = true;
                                            break;
                                        }
                                    }
                                }
                                if (!DrenagAdded)
                                {
                                    AddOperation(im, im.Lenght / 2, dren_sliv);
                                    count2++;
                                }
                            }
                        }
                    }
                }
                // если заглушки есть, то списываем работы
                count = count + count2;
            }
            return count;
        }

        #region Из скрипта ширмера


        void AddOperation(Balka Balka, int StartImp, string pName)
        {
        }

        #endregion

        #endregion

        void DevidedIP45IF50(ds_order.orderitemRow dr_oi, Construction Model)
        {
            string Err = "";
            lstConImpDisassembled.Clear();
            lstConImpAssembled.Clear();
            lstConRegDisassembled.Clear();
            lstConRegAssembled.Clear();
            lstConFrameBeemAssembled.Clear();
            lstConFrameBeemDisassembled.Clear();



            if (Model == null)
            {
                Model = new Construction();
                Model.Load(Atechnology.Components.ZipArchiver.UnZip2(dr_oi.modelRow._class));
            }
            try
            {
                int idorder = dr_oi.idorder;
                int idorderitem = dr_oi.idorderitem;
                if (Model.StvorkaList.Count == 0)
                {
                    //Если нет створок в конструкции... Все в разбор
                    foreach (RamaItem ri in Model.Rama)
                    {
                        if (!lstConFrameBeemDisassembled.Contains(ri))
                        {
                            lstConFrameBeemDisassembled.Add(ri);
                        }
                    }
                    foreach (Impost i in Model.ImpostList)
                    {
                        if (!lstConImpDisassembled.Contains(i))
                        {
                            lstConImpDisassembled.Add(i);
                        }
                    }
                    foreach (Glass g in Model.GlassList)
                    {
                        if (!lstConRegDisassembled.Contains(g))
                        {
                            lstConRegDisassembled.Add(g);
                        }
                    }
                }
                else
                {
                    foreach (Impost i in Model.ImpostList)
                    {
                        Err = "00.1";
                        if (i.AngNakl == 0 || i.AngNakl == 180)
                        {
                            Err = "00.2";
                            bool isStv = false;
                            bool isGL = false;
                            double stvH = 0;
                            double glH = 0;
                            double op = 0;
                            foreach (ModelPartClass mpc in i.PartTypeList)
                            {
                                
                                if (Model.ProfileSystem.Contains("IF50")) continue;
                                if (mpc.ModelPart == ModelPart.Glass)
                                {
                                    Glass g = mpc.Glass;
                                    if (g != null)
                                    {
                                        if (mpc.y1Fill + mpc.Glass.Height > 2700)
                                        {
                                            Err = "00.23";
                                            if (!lstConRegDisassembled.Contains(g))
                                            {
                                                lstConRegDisassembled.Add(g);
                                            }
                                        }
                                    }

                                }
                                Err = "00.3";
                                if (mpc.ModelPart == ModelPart.Stvorka)
                                {
                                    if (Model.ProfileSystem.Contains("IF50")) continue;
                                    foreach (ModelPartClass mpc2 in i.PartTypeList2)
                                    {
                                        if (mpc2.ModelPart == ModelPart.Glass)
                                        {
                                            Glass g = mpc2.Glass;
                                            if (g != null)
                                            {
                                                if (mpc.StvItem.BalkaStart.LengthInterfaceCalcInt + g.Height > 2700)
                                                {
                                                    if (!lstConRegAssembled.Contains(g))
                                                    {
                                                        if (!lstConRegDisassembled.Contains(g))
                                                        {
                                                            lstConRegDisassembled.Add(g);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            Err = "00.4";
                            foreach (ModelPartClass mpc2 in i.PartTypeList2)
                            {
                                    if (mpc2.Glass == null) continue;
                                    if (Model.ProfileSystem.Contains("IF50")) continue;
                                if (mpc2.ModelPart == ModelPart.Stvorka)
                                {
                                    foreach (ModelPartClass mpc in i.PartTypeList)
                                    {
                                        if (mpc.ModelPart == ModelPart.Glass)
                                        {
                                            Err = "00.5";
                                            Glass g = mpc.Glass;
                                            if (g != null)
                                            {
                                                Err = "00.6.6";
                                                if (mpc2.StvItem != null && mpc2.StvItem.BalkaStart.LengthInterfaceCalcInt + g.Height > 2700)
                                                {
                                                    Err = "00.7";
                                                    if (!lstConRegAssembled.Contains(g))
                                                    {
                                                        Err = "00.8";
                                                        if (!lstConRegDisassembled.Contains(g))
                                                        {
                                                            Err = "00.9";
                                                            lstConRegDisassembled.Add(g);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Err = "00.10";
                                                    if (!lstConRegAssembled.Contains(g))
                                                    {
                                                        Err = "00.11";
                                                        lstConRegAssembled.Add(g);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Err = "01";
                        if ((i.AngNakl == 90 || i.AngNakl == 270)
                            && i.ImpostType == ImpostType.Impost
                            && (i.Connect1 == SoedType.Dlinnoe && i.Connect2 == SoedType.Dlinnoe))
                        {
                            bool isAssembled = false;
                            string stvSide = string.Empty;
                            #region Определяем сторону примиыкания створки к импосту вертикальному
                            foreach (ModelPartClass mpc in i.PartTypeList)
                            {
                                if (mpc.ModelPart == ModelPart.Stvorka)
                                {
                                    isAssembled = true;
                                    if (!string.IsNullOrEmpty(stvSide))
                                    {
                                        stvSide = "BOTH";
                                    }
                                    else
                                    {
                                        stvSide = "L";
                                    }
                                }
                            }
                            foreach (ModelPartClass mpc in i.PartTypeList2)
                            {
                                if (mpc.ModelPart == ModelPart.Stvorka)
                                {
                                    isAssembled = true;
                                    if (!string.IsNullOrEmpty(stvSide))
                                    {
                                        stvSide = "BOTH";
                                    }
                                    else
                                    {
                                        stvSide = "R";
                                    }
                                }
                            }
                            #endregion Определяем сторону примиыкания створки к импосту вертикальному

                            //Если примыкает створка, то импост в сборе
                            if (isAssembled)
                            {
                                if (!lstConImpAssembled.Contains(i))
                                {
                                    lstConImpAssembled.Add(i);
                                }
                            }
                            else
                            {
                                if (!lstConImpDisassembled.Contains(i))
                                {
                                    lstConImpDisassembled.Add(i);
                                }
                            }
                            if (stvSide == "L")
                            {
                                #region Если створка примыкает слева то все левые импоста в сборе
                                if (!lstConFrameBeemAssembled.Contains(i.BalkaEnd1))
                                {
                                    lstConFrameBeemAssembled.Add(i.BalkaEnd1 as RamaItem);
                                }
                                if (!lstConFrameBeemDisassembled.Contains(i.BalkaEnd2))
                                {
                                    lstConFrameBeemDisassembled.Add(i.BalkaEnd2 as RamaItem);
                                }

                                if (!lstConFrameBeemAssembled.Contains(i.BalkaStart2))
                                {
                                    lstConFrameBeemAssembled.Add(i.BalkaStart2 as RamaItem);
                                }
                                if (!lstConFrameBeemDisassembled.Contains(i.BalkaStart1))
                                {
                                    lstConFrameBeemDisassembled.Add(i.BalkaStart1 as RamaItem);
                                }

                                //Если створка примыкает слева то все левые импоста в сборе
                                foreach (Impost imLst in i.ImpostList)
                                {
                                    if (!lstConImpAssembled.Contains(imLst))
                                    {
                                        lstConImpAssembled.Add(imLst);
                                    }
                                }
                                //Все правые импоста в разборе
                                foreach (Impost imLst in i.ImpostList2)
                                {
                                    if (!lstConImpDisassembled.Contains(imLst))
                                    {
                                        lstConImpDisassembled.Add(imLst);
                                    }
                                }
                                #endregion Если створка примыкает слева то все левые импоста в сборе

                                foreach (ModelPartClass mpc in i.PartTypeList)
                                {
                                    if (mpc == null) continue;
                                    if (mpc.ModelPart == ModelPart.Glass)
                                    {
                                        Glass g = mpc.Glass;
                                        if (g != null)
                                        {
                                            if (!lstConRegAssembled.Contains(g))
                                            {
                                                if (!lstConRegDisassembled.Contains(g))
                                                {
                                                    lstConRegAssembled.Add(g);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (stvSide == "R")
                            {
                                #region Если створка примыкает справа то все правые импоста в сборе
                                if (!lstConFrameBeemAssembled.Contains(i.BalkaEnd2))
                                {
                                    lstConFrameBeemAssembled.Add(i.BalkaEnd2 as RamaItem);
                                }
                                if (!lstConFrameBeemDisassembled.Contains(i.BalkaEnd1))
                                {
                                    lstConFrameBeemDisassembled.Add(i.BalkaEnd1 as RamaItem);
                                }

                                if (!lstConFrameBeemAssembled.Contains(i.BalkaStart1))
                                {
                                    lstConFrameBeemAssembled.Add(i.BalkaStart1 as RamaItem);
                                }
                                if (!lstConFrameBeemDisassembled.Contains(i.BalkaStart2))
                                {
                                    lstConFrameBeemDisassembled.Add(i.BalkaStart2 as RamaItem);
                                }
                                //Если створка примыкает справа то все правые импоста в сборе
                                foreach (Impost imLst in i.ImpostList2)
                                {
                                    if (!lstConImpAssembled.Contains(imLst))
                                    {
                                        lstConImpAssembled.Add(imLst);
                                    }
                                }
                                //Все левые импоста вразбор
                                foreach (Impost imLst in i.ImpostList)
                                {
                                    if (!lstConImpDisassembled.Contains(imLst))
                                    {
                                        lstConImpDisassembled.Add(imLst);
                                    }
                                }
                                #endregion Если створка примыкает справа то все правые импоста в сборе
                                foreach (ModelPartClass mpc in i.PartTypeList2)
                                {
                                    if (mpc == null) continue;
                                    if (mpc.ModelPart == ModelPart.Glass)
                                    {
                                        Glass g = mpc.Glass;
                                        if (g != null)
                                        {
                                            if (!lstConRegAssembled.Contains(g))
                                            {
                                                if (!lstConRegDisassembled.Contains(g))
                                                {
                                                    lstConRegAssembled.Add(g);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (stvSide == "BOTH")
                            {

                            }
                            if (stvSide == "")
                            {
                                if (!lstConFrameBeemDisassembled.Contains(i.BalkaEnd1))
                                {
                                    lstConFrameBeemDisassembled.Add(i.BalkaEnd1 as RamaItem);
                                }
                                if (!lstConFrameBeemDisassembled.Contains(i.BalkaEnd2))
                                {
                                    lstConFrameBeemDisassembled.Add(i.BalkaEnd2 as RamaItem);
                                }

                                if (!lstConFrameBeemDisassembled.Contains(i.BalkaStart2))
                                {
                                    lstConFrameBeemDisassembled.Add(i.BalkaStart2 as RamaItem);
                                }
                                if (!lstConFrameBeemDisassembled.Contains(i.BalkaStart1))
                                {
                                    lstConFrameBeemDisassembled.Add(i.BalkaStart1 as RamaItem);
                                }

                                //Если створка примыкает справа то все правые импоста в сборе
                                foreach (Impost imLst in i.ImpostList2)
                                {
                                    if (!lstConImpDisassembled.Contains(imLst))
                                    {
                                        lstConImpDisassembled.Add(imLst);
                                    }
                                }
                                //Все левые импоста вразбор
                                foreach (Impost imLst in i.ImpostList)
                                {
                                    if (!lstConImpDisassembled.Contains(imLst))
                                    {
                                        lstConImpDisassembled.Add(imLst);
                                    }
                                }
                            }
                        }
                        Err = "03";
                        if (Model.ProfileSystem.Contains("Inicial IF50"))
                        {
                            foreach (Impost imLst in Model.ImpostList)
                            {
                                if (!lstConImpDisassembled.Contains(imLst))
                                {
                                    lstConImpDisassembled.Add(imLst);
                                }
                            }
                        }
                    }
                    Err = "04";
                    foreach (Impost i in Model.ImpostList)
                    {
                        if ((i.AngNakl == 90 || i.AngNakl == 270)
                            && i.ImpostType == ImpostType.Impost
                            && i.Connect1 == SoedType.Korotkoe
                            && i.Connect2 == SoedType.Korotkoe
                            )
                        {
                            Balka start = i.BalkaStart;
                            Balka end = i.BalkaStart;
                            if (lstConFrameBeemDisassembled.Contains(start) || lstConFrameBeemDisassembled.Contains(end))
                            {
                                if (!lstConImpDisassembled.Contains(i))
                                    lstConImpDisassembled.Add(i);
                            }
                            if (lstConImpDisassembled.Contains(start) || lstConImpDisassembled.Contains(end))
                            {
                                if (!lstConImpDisassembled.Contains(i))
                                    lstConImpDisassembled.Add(i);
                            }
                            if (lstConFrameBeemAssembled.Contains(start) || lstConFrameBeemAssembled.Contains(end))
                            {
                                if (!lstConImpAssembled.Contains(i))
                                    lstConImpAssembled.Add(i);
                            }
                            if (lstConImpAssembled.Contains(start) || lstConImpAssembled.Contains(end))
                            {
                                if (!lstConImpAssembled.Contains(i))
                                    lstConImpAssembled.Add(i);
                            }
                        }
                    }
                    Err = "05";
                    #region Балки рамы
                    foreach (RamaItem ri in Model.Rama)
                    {
                        Err = "RI_1";
                        //Вертикальные рамы
                        if (ri.AngNakl == 90 || ri.AngNakl == 270)
                        {
                            bool isAssembled = false;
                            foreach (ModelPartClass mpc in ri.PartTypeList)
                            {
                                if (mpc.ModelPart == ModelPart.Stvorka)
                                {
                                    if (!lstConFrameBeemAssembled.Contains(ri))
                                    {
                                        lstConFrameBeemAssembled.Add(ri);
                                        isAssembled = true;
                                        break;
                                    }
                                }
                            }
                            if (!isAssembled)
                            {
                                if (!lstConFrameBeemDisassembled.Contains(ri))
                                {
                                    lstConFrameBeemDisassembled.Add(ri);
                                }
                            }
                        }
                    }
                    foreach (RamaItem ri in Model.Rama)
                    {

                        if (Model.ProfileSystem.Contains("IF50"))
                        {
                            if (!lstConFrameBeemDisassembled.Contains(ri))
                            {
                                lstConFrameBeemDisassembled.Add(ri);
                            }
                        }
                        else
                        {
                            Err = "RI_2";
                            //Передлано по инцеденту https://servicedesk.it-swarm.pro/browse/DEV-43495
                            //Горизонтальные 
                            if (ri.AngNakl == 0 || ri.AngNakl == 180)
                            {
                                if (ri.RamaType != RamaType.Porog)
                                {
                                    Err = "RI_2";
                                    //Если БалкаСтарт и БалкаЕнд в разборе, то и балка между ними в разборе
                                    if (lstConFrameBeemDisassembled.Contains(ri.BalkaStart)
                                        && lstConFrameBeemDisassembled.Contains(ri.BalkaEnd))
                                    {
                                        if (!lstConFrameBeemDisassembled.Contains(ri))
                                        {
                                            lstConFrameBeemDisassembled.Add(ri);
                                        }
                                    }
                                    //Если БалкаСтарт и БалкаЕнд в сборе, то и балка между ними в сборе
                                    else if (lstConFrameBeemAssembled.Contains(ri.BalkaStart)
                                        && lstConFrameBeemAssembled.Contains(ri.BalkaEnd))
                                    {
                                        if (!lstConFrameBeemAssembled.Contains(ri))
                                        {
                                            lstConFrameBeemAssembled.Add(ri);
                                        }
                                    }
                                    //Во всех остальных случаях, как раньше с разборе
                                    else
                                    {
                                        if (!lstConFrameBeemAssembled.Contains(ri))
                                        {
                                            if (!lstConFrameBeemDisassembled.Contains(ri))
                                            {
                                                lstConFrameBeemDisassembled.Add(ri);
                                            }
                                        }
                                    }
                                }
                                //Порог всегда будет всборе
                                if (ri.RamaType == RamaType.Porog)
                                {
                                    if (!lstConFrameBeemAssembled.Contains(ri))
                                    {
                                        lstConFrameBeemAssembled.Add(ri);
                                    }
                                }
                            }
                        }
                    }
                    #endregion Балки рамы


                    Err = "05_Fills";
                    #region Заполнения
                    int cntImp = 0;
                    foreach (Glass g in Model.GlassList)
                    {

                        foreach (Impost i in Model.ImpostList)
                        {
                            if (i.AngNakl == 90 || i.AngNakl == 270)
                            {
                                cntImp++;
                            }
                        }

                        if (cntImp > 0)
                        {
                            if (g.ModelPart != ModelPart.Stvorka)
                            {
                                if (!lstConRegAssembled.Contains(g))
                                {
                                    if (!lstConRegDisassembled.Contains(g))
                                    {
                                        lstConRegDisassembled.Add(g);
                                    }
                                }
                                if (lstConRegAssembled.Contains(g) && lstConRegDisassembled.Contains(g))
                                {
                                    lstConRegAssembled.Remove(g);
                                }
                            }
                            else
                            {
                                if (!lstConRegAssembled.Contains(g))
                                {
                                    if (!lstConRegDisassembled.Contains(g))
                                    {
                                        lstConRegAssembled.Add(g);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (g.ModelPart != ModelPart.Stvorka)
                            {
                                bool isAssembled = false;
                                foreach (RamaItem rama in lstConFrameBeemAssembled)
                                {
                                    if (isAssembled) break;
                                    foreach (ModelPartClass mpc in rama.PartTypeList)
                                    {
                                        if (mpc.Glass == g && !isAssembled)
                                        {
                                            if (!lstConRegDisassembled.Contains(g))
                                            {
                                                lstConRegAssembled.Add(g);
                                                isAssembled = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (!lstConRegAssembled.Contains(g))
                                {
                                    if (!lstConRegDisassembled.Contains(g))
                                    {
                                        lstConRegAssembled.Add(g);
                                    }
                                }
                            }
                        }
                    }
                    #endregion Заполнения
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("!Ошибка скрипта расчета[Расчет координат операций для алюминия] в методе DevidedIP45!\r\nТочка: " + Err + "\r\nMessage: " + ex.Message);
            }
        }

        DataTable FillDisassembledDataTable(ds_order.orderitemRow drOI, OrderClass Order)
        {
            DataTable dtAlumparts = new DataTable();

            #region Добавляем столбцы в таблицу
            DataColumn idorder = new DataColumn();
            DataColumn idorderitem = new DataColumn();
            DataColumn guid = new DataColumn();
            DataColumn disassembled = new DataColumn();
            DataColumn idregion = new DataColumn();
            DataColumn idbeam = new DataColumn();
            DataColumn balkatype = new DataColumn();
            DataColumn regionpart = new DataColumn();

            idorder.ColumnName = "idorder";
            idorder.DataType = typeof(int);

            idorderitem.ColumnName = "idorderitem";
            idorderitem.DataType = typeof(int);

            guid.ColumnName = "guid";
            guid.DataType = typeof(string);

            disassembled.ColumnName = "disassembled";
            disassembled.DataType = typeof(int);

            idregion.ColumnName = "idregion";
            idregion.DataType = typeof(int);

            idbeam.ColumnName = "idbeam";
            idbeam.DataType = typeof(int);

            balkatype.ColumnName = "balkatype";
            balkatype.DataType = typeof(string);

            regionpart.ColumnName = "regionpart";
            regionpart.DataType = typeof(string);

            dtAlumparts.Columns.Add(idorder);
            dtAlumparts.Columns.Add(idorderitem);
            dtAlumparts.Columns.Add(guid);
            dtAlumparts.Columns.Add(disassembled);
            dtAlumparts.Columns.Add(idregion);
            dtAlumparts.Columns.Add(idbeam);
            dtAlumparts.Columns.Add(balkatype);
            dtAlumparts.Columns.Add(regionpart);


            #endregion Добавляем столбцы в таблицу

            if (lstConImpDisassembled.Count > 0)
            {
                #region Добавляем импосты в разборе
                foreach (Balka b in lstConImpDisassembled)
                {
                    DataRow drn = dtAlumparts.NewRow();
                    drn[0] = drOI.idorder;
                    drn[1] = drOI.idorderitem;
                    drn[2] = b.Guid;
                    drn[3] = 1;
                    drn[4] = null;
                    drn[5] = b.ID;
                    drn[6] = b.BalkaType;
                    drn[7] = null;

                    dtAlumparts.Rows.Add(drn);
                }
                #endregion Добавляем импосты в разборе
            }

            if (lstConRegDisassembled.Count > 0)
            {
                #region Добавляем заполнения в разборе
                foreach (Glass g in lstConRegDisassembled)
                {
                    DataRow drn = dtAlumparts.NewRow();
                    drn[0] = drOI.idorder;
                    drn[1] = drOI.idorderitem;
                    drn[2] = null;
                    drn[3] = 1;
                    drn[4] = g.ID;
                    drn[5] = null;
                    drn[6] = null;
                    drn[7] = g.Part;

                    dtAlumparts.Rows.Add(drn);
                }
                #endregion Добавляем заполнения в разборе
            }

            if (lstConFrameBeemDisassembled.Count > 0)
            {
                #region Добавляем рамы в разборе
                foreach (Balka b in lstConFrameBeemDisassembled)
                {
                    DataRow drn = dtAlumparts.NewRow();
                    drn[0] = drOI.idorder;
                    drn[1] = drOI.idorderitem;
                    drn[2] = b.Guid;
                    drn[3] = 1;
                    drn[4] = null;
                    drn[5] = b.ID;
                    drn[6] = b.BalkaType;
                    drn[7] = null;

                    dtAlumparts.Rows.Add(drn);
                }
                #endregion Добавляем рамы в разборе
            }

            return dtAlumparts;

        }

        bool CheckAssembled(Balka b)
        {
            bool isAssembled = false;
            if (b is Impost)
            {
                foreach (Impost i in lstConImpAssembled)
                {
                    if (b == i)
                    {
                        isAssembled = true;
                    }
                }
            }
            if (b is RamaItem)
            {
                foreach (RamaItem ri in lstConFrameBeemAssembled)
                {
                    if (b == ri)
                    {
                        isAssembled = true;
                    }
                }
            }
            return isAssembled;
        }

        #region AddMaterialFromCustomTableIP45
        void AddMaterialFromCustomTableIP45(ds_order.orderitemRow drOI, Construction Model)
        {
            string Err = "";
            try
            {

                Err = "1_BeforeFilldtMaterial";
                dtMaterial = Atechnology.ecad.Settings.GetSetVar(1697).TableCustomValue;
                Err = "1_AfterFilldtMaterial";

                if (dtMaterial.Rows.Count == 0)
                {
                    return;
                }

                //Цикл по горизонтальным импостам 
                foreach (Impost i in Model.ImpostList)
                {
                    if (i.AngNakl == 0 || i.AngNakl == 180)
                    {
                        //Если импост в створке пропускаем его
                        if (i.BalkaEndType == ModelPart.StvorkaItem || i.BalkaStartType == ModelPart.StvorkaItem)
                        {
                            continue;
                        }
                        AddMaterialForBalka(i, dtMaterial, drOI);
                    }
                }

                //Цикл по горизонтальным балкам створки 
                foreach (RamaItem ri in Model.Rama)
                {
                    if (ri.AngNakl == 0 || ri.AngNakl == 180)
                    {
                        AddMaterialForBalka(ri, dtMaterial, drOI);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка скрипта Расчет материалов двойного назначения\r\nErr: " + Err + "\r\nMessage: " + ex.Message);
            }
        }

        void AddMaterialForBalka(Balka b, DataTable dt, ds_order.orderitemRow drOI)
        {
            try
            {
                DataRow drMC = null;
                DataRow[] drs = dt.Select("MarkInSys = '" + b.Marking + "'");
                if (drs.Length == 0)
                    return;
                if (b is Impost)
                {
                    if (b.Connect1.ToString() == drs[0]["Connect1"].ToString() && b.Connect2.ToString() == drs[0]["Connect2"].ToString())
                    {
                        AddMaterial(b, drOI, drs);
                    }
                }
                if (b is RamaItem)
                {
                    if (b.Connect1.ToString() == drs[0]["Connect1"].ToString() && b.Connect2.ToString() == drs[0]["Connect2"].ToString())
                    {
                        AddMaterial(b, drOI, drs);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка метода AddMaterialForBalka\r\nMessage: " + ex.Message);
            }
        }

        void AddMaterial(Balka b, ds_order.orderitemRow drOI, DataRow[] drs)
        {
            try
            {
                string addstr = CheckAssembled(b) ? "59" : "115";
                ds_order.modelcalcRow drMC = null;
                drMC = drOI.AddModelcalc(drs[0]["goodMarking"].ToString(), Useful.GetDecimal(drs[0]["qu"]));

                drMC.addint = b.ID;
                drMC.addstr = addstr;
                drMC.addstr2 = b.BalkaType.ToString();
                if (Atechnology.ecad.Settings.idpeople == 2214 || Atechnology.ecad.Settings.idpeople == 4)
                {
                    drMC.modelpart = b.Guid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка метода AddMaterial\r\nMessage: " + ex.Message);
            }
        }

        #endregion AddMaterialFromCustomTableIP45


        /// <summary>
        /// Расчет стыка C640_30X в полуфабрикате створки 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void CalcProvedalStik(Construction model)
        {
            if (model.ConstructionType.Name == "Створка" && inRange(model.ProfileSystem, "Provedal C640, P400", "Татпроф СОКОЛ 40"))
            {
                foreach (Stvorka s in model.StvorkaList)
                {
                    if (s.GetUserParam("StPRV").StrValue == "1")
                    {
                        DataRow drMC = drOI.AddModelcalc("C640_30X",
                            (model.ColorOut),
                            (model.ColorIn),
                            null, null, 1, (int)s.Height, 90, 90, 0, 0, "С-" + (s.ID + 1));
                        if (drMC != null)
                        {
                            drMC["idcolor1"] = drOI.idcolorout;
                            drMC["idcolor2"] = drOI.idcolorin;
                            drMC["addstr"] = "Impost";
                            drMC["addstr2"] = "C640_30X";
                            drMC["addstr3"] = "В";
                            drMC["addint"] = s.ID + 1;
                        }
                    }
                    if (s.GetUserParam("StPRV").StrValue == "2")
                    {
                        DataRow drMC = drOI.AddModelcalc("C640_30X",
                            (model.ColorOut),
                            (model.ColorIn),
                            null, null, 1, (int)s.Height, 90, 90, 0, 0, "С-" + (s.ID + 1));
                        if (drMC != null)
                        {
                            drMC["idcolor1"] = drOI.idcolorout;
                            drMC["idcolor2"] = drOI.idcolorin;
                            drMC["addstr"] = "Impost";
                            drMC["addstr2"] = "C640_30X";
                            drMC["addstr3"] = "В";
                            drMC["addint"] = s.ID + 1;
                        }
                        //Если это 5-ти створчатый проведал ставим еще один стык
                        drMC = drOI.AddModelcalc("C640_30X",
                            (model.ColorOut),
                            (model.ColorIn),
                            null, null, 1, (int)s.Height, 90, 90, 0, 0, "С-" + (s.ID + 1));
                        if (drMC != null)
                        {
                            drMC["idcolor1"] = drOI.idcolorout;
                            drMC["idcolor2"] = drOI.idcolorin;
                            drMC["addstr"] = "Impost";
                            drMC["addstr2"] = "C640_30X";
                            drMC["addstr3"] = "В";
                            drMC["addint"] = s.ID + 1;
                        }
                    }
                }
            }
        }

        void CalcIP45Pritvor(Construction model, ds_order.orderitemRow drOI)
        {
            bool isCokol = false;
            int addForCokol = 0;
            //так сказала Сайдакова
            double len = 0;
            foreach (Stvorka s in model.StvorkaList)
            {
                if (s.FirstOrDefault(x => x.Marking == "130805") != null)
                {
                    addForCokol = 20;
                }

                if (s.FirstOrDefault(x => x.Marking == "130703") != null) continue;

                //if(s[0].Marking != "130804" && s[0].Marking != "130803") continue;
                if (s.ShtulpExist == ShtulpExist.Exist) continue;
                len = s.Height;
                foreach (StvorkaItem si in s)
                {
                    if (si.Side == ItemSide.Top)
                    {
                        if (si.RamaItem != null && si.RamaItem.Marking == "#130802")
                        {
                            foreach (StvorkaItem sii in s)
                            {
                                if (sii.Side == ItemSide.Bottom)
                                {
                                    if (sii.RamaItem != null)
                                    {
                                        if (sii.RamaItem.Marking == "130401")
                                        {
                                            len = s.Height + 17 + addForCokol;
                                        }
                                        if (sii.RamaItem.Marking == "Без_рамы_IP45")
                                        {
                                            len = s.Height + 9;
                                        }
                                        if (sii.RamaItem.Marking == "#130802")
                                        {
                                            len = s.Height + 22;
                                        }
                                    }
                                }
                            }
                        }
                        if (si.Impost != null && (si.Impost.Marking == "##130803" || si.Impost.Marking == "##130804"))
                        {
                            foreach (StvorkaItem sii in s)
                            {
                                if (sii.Side == ItemSide.Bottom)
                                {
                                    if (sii.RamaItem != null)
                                    {
                                        if (sii.RamaItem.Marking == "#130802")
                                        {
                                            len = s.Height + 22;
                                        }
                                        if (sii.RamaItem.Marking == "130401")
                                        {
                                            len = s.Height + 17 + addForCokol;
                                        }
                                        if (sii.RamaItem.Marking == "Без_рамы_IP45")
                                        {
                                            len = s.Height + 9;
                                        }
                                    }
                                    if (sii.Impost != null && (sii.Impost.Marking == "##130803" || sii.Impost.Marking == "##130804"))
                                    {
                                        len = s.Height + 22;
                                    }
                                }
                            }
                        }
                    }
                }
                if (len > 0)
                {
                    // 13 04 02
                    ds_order.modelcalcRow mc = null;
                    int count_samorez = ((int)len / 250) + 1;
                    mc = drOI.AddModelcalc("13 04 02", 1, Convert.ToInt32(len) + 4, 90, 90, 0, 0);
                    mc.addstr = "Additional";
                    mc.idcolor1 = drOI.idcolorout;
                    mc = drOI.AddModelcalc("3.9x16", count_samorez);
                    mc.addstr = "59";


                    count_samorez = ((int)len / 250) + 1;
                    mc = drOI.AddModelcalc("13 04 02", 1, Convert.ToInt32(len) + 4, 90, 90, 0, 0);
                    mc.addstr = "Additional";
                    mc.idcolor1 = drOI.idcolorout;
                    mc = drOI.AddModelcalc("3.9x16", count_samorez);
                    mc.addstr = "59";
                }
            }
        }

        void CalcZaglMP4565(Construction model, ds_order.orderitemRow drOI)
        {
            if (model.ConstructionType.ID == 2)
            {
                foreach (RamaItem ri in model.Rama)
                {
                    AddZagl(drOI, ri, model.ColorOut, model.ProfileSystem);
                }
                foreach (Impost i in model.ImpostList)
                {
                    AddZagl(drOI, i, model.ColorOut, model.ProfileSystem);
                }
            }
        }

        void CalcZaglMp640(Construction model, ds_order.orderitemRow drOI)
        {
            string marking = "МПУ-016 black";
            if (model.ColorOut.Contains("RAL 9003") || model.ColorOut.Contains("RAL 9016"))
            {
                marking = "МПУ-016 white";
            }

            foreach (RamaItem ri in model.Rama)
            {
                if (ri.Side == ItemSide.Bottom && inRange(ri.Marking, "#МП-64027","#МП-64042","#МП-64048","#МП-64086","#МП-64084-01","МП-64025","МП-64041"))
                {
                    int qu = 0;
                    if (ri.LengthInterfaceCalcInt <= 399)
                    {
                        qu = 1;
                    }
                    if (ri.LengthInterfaceCalcInt > 399)
                    {
                        qu = 2;
                    }
                    if (ri.LengthInterfaceCalcInt > 900)
                    {
                        qu += 1;
                    }
                    drOI.AddModelcalc(marking, qu);
                }
            }
            foreach (Impost ri in model.ImpostList)
            {
                if ((ri.AngNakl == 0 || ri.AngNakl == 180) && inRange(ri.Marking, "#МП-64027", "#МП-64042", "#МП-64048", "#МП-64086", "#МП-64084-01", "#МП-64025", "#МП-64041"))
                {
                    int qu = 0;
                    if (ri.LengthInterfaceCalcInt <= 399)
                    {
                        qu = 1;
                    }
                    if (ri.LengthInterfaceCalcInt > 399)
                    {
                        qu = 2;
                    }
                    if (ri.LengthInterfaceCalcInt > 900)
                    {
                        qu += 1;
                    }
                    drOI.AddModelcalc(marking, qu);
                }
            }
        }

        void AddZagl(ds_order.orderitemRow drOI, Balka b, string color, string profileSystem)
        {
            int qu = 0;
            if (b.AngNakl == 0)
            {
                if (b.LengthInterfaceCalcInt <= 400)
                {
                    qu = 1;
                }
                if (b.LengthInterfaceCalcInt > 400)
                {
                    qu = 2;
                }
                if (b.LengthInterfaceCalcInt > 1300)
                {
                    qu += (int)((b.LengthInterfaceCalcInt) / 1000);
                }
            }
            if (qu > 0)
            {
                string marking = "";
                marking = "МПУ-016 black";
                if (color.Contains("RAL 9003") || color.Contains("RAL 9016"))
                {
                    marking = "МПУ-016 white";
                }

                drOI.AddModelcalc(marking, qu);
            }
        }

        void CalcZaklMP45(Construction model, ds_order.orderitemRow drOI)
        {
            double len = 0;
            //Узел 1) L(22,5) = 22,5 / sin ? + 39,5 / tg ?
            //Узел 2) L(38,5) = 38,5 / sin ? + 39,5 / tg ?
            foreach (Impost imp in model.ImpostList)
            {
                if (imp.IsRail && imp.AngNakl != 0 && imp.AngNakl != 180)
                {
                    if (inRange(imp.Marking, "#МП-45.01.04", "##МП-45.01.04", "#МП-45.03.04"))
                    {
                        //len = CalcLen(22.5, imp.AngNakl);
                    }
                    else if (inRange(imp.Marking, "#МП-45.01.03", "##МП-45.01.03", "#МП-45.03.03"))
                    {
                        //len = CalcLen(38.5, imp.AngNakl);
                    }
                }
            }

            foreach (RamaItem ri in model.Rama)
            {
                if (ri.IsRail && ri.AngNakl != 0 && ri.AngNakl != 180)
                {
                    if (inRange(ri.Marking, "#МП-45.01.04", "##МП-45.01.04", "#МП-45.03.04"))
                    {
                        AddZkl(38.5, ri.Ang1, ri.Ang2, drOI);
                        AddZkl(38.5, ri.Ang2, ri.Ang1, drOI);
                    }
                    else if (inRange(ri.Marking, "#МП-45.01.03", "##МП-45.01.03", "#МП-45.03.03"))
                    {
                        AddZkl(22.5, ri.Ang1, ri.Ang2, drOI);
                        AddZkl(22.5, ri.Ang2, ri.Ang1, drOI);
                    }
                }
            }
        }
        /// <summary>
        /// Расчет фиктивных операций торцовки на ригеля МП45 для дальнейшего вывода инф. на этикетку
        /// </summary>
        /// <param name="model"></param>
        /// <param name="drOI"></param>
        void CalcTorcMP45(Construction model, ds_order.orderitemRow drOI)
        {
            //это должно работать только для Перегородок
            if (model == null || drOI.IsidconstructiontypeNull() || drOI.idconstructiontype != 39)
                return;

            string torcOper = "TR";

            
            foreach (Impost imp in model.ImpostList)
            {
                if (imp.IsRail)
                {
                    if (imp.BalkaStart != null && inRange(imp.BalkaStart.Marking, "#МП-45.01.04", "##МП-45.01.04", "#МП-45.03.04"))
                    {
                        imp.OperationList.Add(new Operation(torcOper, 0, torcOper, 0, 0));
                    }
                    if (imp.BalkaEnd != null && inRange(imp.BalkaEnd.Marking, "#МП-45.01.04", "##МП-45.01.04", "#МП-45.03.04"))
                    {
                        imp.OperationList.Add(new Operation(torcOper,  imp.Lenght, torcOper, imp.Lenght, imp.Lenght));
                    }
                }
            }

            foreach (RamaItem ri in model.Rama)
            {
                if (ri.IsRail)
                {
                    if (ri.BalkaStart != null && inRange(ri.BalkaStart.Marking, "#МП-45.01.04", "##МП-45.01.04", "#МП-45.03.04"))
                    {
                        ri.OperationList.Add(new Operation(torcOper, 0, torcOper, 0, 0));
                    }
                    if (ri.BalkaEnd != null && inRange(ri.BalkaEnd.Marking, "#МП-45.01.04", "##МП-45.01.04", "#МП-45.03.04"))
                    {
                        ri.OperationList.Add(new Operation(torcOper, ri.Lenght, torcOper, ri.Lenght, ri.Lenght));
                    }
                }
            }
        }

        void AddZkl(double d, decimal ang1, decimal ang2, ds_order.orderitemRow drOI)
        {
            //MessageBox.Show("d = " + d + "_ang1 = " + ang1 + "_ang2 = " + ang2);
            decimal ang = ang1;
            DataRow drMC = null;
            if (ang1 > 90)
            {
                ang = 180 - ang1;
            }
            else
            {
                ang = ang1;
            }
            double rad = (double)ang * Math.PI / 180;

            double len = d / Math.Sin(rad) + 39.5 / Math.Tan(rad);

            drMC = drOI.AddModelcalc("МП-45.08.06", 1, (int)len, ang1, ang2, 0, 0, "");
            if (drMC != null)
            {
                drMC["addstr"] = "Additional";
            }
        }

        void CalcAdapterMP45(Construction model, ds_order.orderitemRow drOI)
        {
            string markingAdapter = "";
            int len = 0;
            ds_order.modelcalcRow mc = null;
            string balkapart = "";
            int count_samorez = (len / 250) + 1;

            foreach (Glass g in model.GlassList)
            {
                if (g.ModelPart == ModelPart.Rama)
                {
                    foreach (GlassItem gi in g)
                    {
                        if (gi.AngNakl == 90 || gi.AngNakl == 270)
                        {
                            string side = gi.AngNakl == 90 ? "Л" : "П";
                            len = gi.Lenght + 18;

                            Balka b = null;

                            if (gi.ConnectImpost != null)
                            {
                                b = gi.ConnectImpost;
                            }
                            if (gi.ConnectRama != null)
                            {
                                b = gi.ConnectRama;
                            }
                            if (b != null)
                            {
                                switch (b.BalkaType)
                                {
                                    case ModelPart.RamaItem:
                                        balkapart = "Р-" + (b.ID + 1).ToString();
                                        break;
                                    case ModelPart.Impost:
                                        balkapart = "И-" + (b.ID + 1).ToString();
                                        break;
                                }
                                if (inRange(b.Marking.Replace("#", ""), "МП-45.05.04", "МП-45.05.05", "МП-45.05.06"))
                                {
                                    mc = drOI.AddModelcalc("МП-45.07.15", 1, len - 18 - 26, 90, 90, 0, 0);
                                    mc.addstr = "Additional";
                                    mc.idcolor1 = drOI.idcolorout;
                                    mc.idcolor2 = drOI.idcolorout;
                                    mc.modelpart = balkapart;
                                    mc.addstr3 = side;

                                    count_samorez = (len / 300) + 1;
                                    mc = drOI.AddModelcalc("3.9x16", count_samorez);
                                    mc.modelpart = balkapart;
                                    mc.addstr3 = side;
                                    mc.addstr = "59"; // ! Алюминька. Рама+Створка
                                }
                                if (inRange(b.Marking.Replace("#", ""), "МП-45.05.02", "МП-45.05.02"))
                                {
                                    mc = drOI.AddModelcalc("МП-45.07.14", 1, len, 90, 90, 0, 0);
                                    mc.addstr = "Additional";
                                    mc.idcolor1 = drOI.idcolorout;
                                    mc.idcolor2 = drOI.idcolorin;
                                    mc.modelpart = balkapart;
                                    mc.addstr3 = side;

                                    count_samorez = (len / 300) + 1;
                                    mc = drOI.AddModelcalc("3.9x25", count_samorez);
                                    mc.modelpart = balkapart;
                                    mc.addstr3 = side;
                                    mc.addstr = "59"; // ! Алюминька. Рама+Створка
                                }
                            }
                        }
                    }
                }
            }

            foreach (Impost i in model.ImpostList)
            {
                foreach (ModelPartClass mpc in i.PartTypeList)
                {
                    if (mpc.ModelPart == ModelPart.StvorkaItem || mpc.ModelPart == ModelPart.Stvorka)
                    {
                        if (inRange(i.Marking.Replace("#", ""), "МП-45.05.02"))
                        {
                            if (!inRange(mpc.StvItem.Marking, "МП - 45.02.02", "МП - 45.02.02"))
                            {
                                len = mpc.StvItem.LenghtB - 12;
                                mc = drOI.AddModelcalc("МП-45.07.14", 1, len, 90, 90, 0, 0);
                                mc.addstr = "Additional";
                                mc.idcolor1 = drOI.idcolorout;
                                mc.idcolor2 = drOI.idcolorin;
                                mc.modelpart = "И-" + (i.ID + 1);
                                mc.addstr3 = "Л";

                                count_samorez = (len / 300) + 1;
                                mc = drOI.AddModelcalc("3.9x25", count_samorez);
                                mc.modelpart = "И-" + (i.ID + 1);
                                mc.addstr3 = "Л";
                                mc.addstr = "59"; // ! Алюминька. Рама+Створка
                            }
                        }
                    }
                }
                foreach (ModelPartClass mpc in i.PartTypeList2)
                {
                    if (mpc.ModelPart == ModelPart.StvorkaItem || mpc.ModelPart == ModelPart.Stvorka)
                    {
                        if (inRange(i.Marking.Replace("#", ""), "МП-45.05.02"))
                        {
                            if (!inRange(mpc.StvItem.Marking, "МП - 45.02.02", "МП - 45.02.02"))
                            {
                                len = mpc.StvItem.LenghtB - 12;
                                mc = drOI.AddModelcalc("МП-45.07.14", 1, len, 90, 90, 0, 0);
                                mc.addstr = "Additional";
                                mc.idcolor1 = drOI.idcolorout;
                                mc.idcolor2 = drOI.idcolorin;
                                mc.modelpart = "И-" + (i.ID + 1);
                                mc.addstr3 = "П";

                                count_samorez = (len / 300) + 1;
                                mc = drOI.AddModelcalc("3.9x25", count_samorez);
                                mc.modelpart = "И-" + (i.ID + 1);
                                mc.addstr3 = "П";
                                mc.addstr = "59"; // ! Алюминька. Рама+Створка
                            }
                        }
                    }
                }
            }
        }

        void CITY_CalcKozToImp(Construction model, ds_order.orderitemRow drOI)
        {
            DataRow drMC = null;
            if (model.ProfileSystem == "Inicial City Pro")
            {
                foreach (Impost imp in model.ImpostList)
                {
                    if (inRange(imp.Marking, "#17 06 08 + 17 05 14", "#17 06 08 + 17 05 16", "#17 06 08 + 17 05 18", "#17 06 08"))
                    {
                        if (imp.GetUserParam("Положение встроенной конструкции") != null
                            && imp.GetUserParam("Положение встроенной конструкции").StrValue == "Снизу")
                        {
                            drMC = drOI.AddModelcalc("17 05 21", 1, imp.LengthInterfaceCalcInt, 90, 90, 0, 0, "И-" + (imp.ID + 1).ToString());
                            if (drMC != null)
                            {
                                drMC["idcolor1"] = drOI.idcolorout;
                                drMC["idcolor2"] = drOI.idcolorin;
                                drMC["addstr"] = "Additional";
                            }
                            //4,2х13 DIN 7981
                            drMC = drOI.AddModelcalc("4,2х13 DIN 7981", (int)Math.Round(imp.LengthInterfaceCalcInt / 300.0));
                            if (drMC != null)
                            {
                                drMC["modelpart"] = "И-" + (imp.ID + 1).ToString();
                            }
                        }
                    }
                }
            }
        }

        void CalcProvedalUpl20(Construction model, ds_order.orderitemRow drOI)
        {
            //if(!inRange(Atechnology.ecad.Settings.idpeople, 2214, 3410)) return;
            if (model.ProfileSystem == "Provedal C640, P400")
            {
                bool inPovStv = false;
                foreach (Glass g in model.GlassList)
                {
                    //					foreach( Stvorka s in model.StvorkaList )
                    //					{
                    //						if(g.ModelPart == ModelPart.Stvorka 
                    //							&& g.ModelItem == s 
                    //							&& s.otkrivanieType == OtkrivanieType.Pov)
                    //						{
                    //							inPovStv = true;
                    //							break;
                    //						}
                    //					}

                    if (g.ModelPart == ModelPart.Rama)
                    {
                        foreach (GlassItem gi in g)
                        {
                            string side = "";
                            switch (gi.SideExtended)
                            {
                                case ItemSide.Bottom:
                                    side = "Н";
                                    break;
                                case ItemSide.Left:
                                    side = "Л";
                                    break;
                                case ItemSide.Top:
                                    side = "В";
                                    break;
                                case ItemSide.Right:
                                    side = "П";
                                    break;
                            }

                            DataRow drMC = null;
                            if (gi.Lenght - 24 <= 500)
                            {
                                drMC = drOI.AddModelcalc("W45.10.03", 2, 20, 0, 0, 0, 0, "З-" + (g.ID + 1));
                                drMC["addstr3"] = side;
                            }
                            if (gi.Lenght - 24 > 500 && gi.Lenght - 24 <= 1000)
                            {
                                drMC = drOI.AddModelcalc("W45.10.03", 3, 20, 0, 0, 0, 0, "З-" + (g.ID + 1));
                                drMC["addstr3"] = side;
                            }
                            if (gi.Lenght - 24 > 1000 && gi.Lenght - 24 <= 2000)
                            {
                                drMC = drOI.AddModelcalc("W45.10.03", 4, 20, 0, 0, 0, 0, "З-" + (g.ID + 1));
                                drMC["addstr3"] = side;
                            }
                        }
                    }

                }
            }
        }

        void CalcXCrossCity(Construction model, ds_order.orderitemRow drOI, ref string Err)
        {
            if (model.ProfileSystem != "Inicial City Pro") return;
            List<double> lstCrossPos = new List<double>();
            double pos1 = 0;
            double pos2 = 0;
            #region Х соединения
            foreach (Impost i in model.ImpostList)
            {
                if (i.AngleHorisont == 90 || i.AngleHorisont == 270)
                {
                    Err = "XCC: 001";
                    for (int im = 0; im < i.ImpostList.Count; im++)
                    {
                        if (i.ImpostList[im].Marking == "#17 06 08 + 17 05 16"
                            || i.ImpostList[im].Marking == "#17 06 08 + 17 05 18")
                        {
                            pos1 = i.ImpostPositionList[im];
                        }
                        if (pos1 > 0)
                        {
                            for (int im2 = 0; im2 < i.ImpostList2.Count; im2++)
                            {
                                if (i.ImpostList2[im2].Marking == "#17 06 08 + 17 05 16"
                                    || i.ImpostList2[im2].Marking == "#17 06 08 + 17 05 18")
                                {
                                    pos2 = i.ImpostPositionList2[im2];
                                    if (pos1 == pos2)
                                    {
                                        /*99 14 01 - 2 шт
										01 09 17 - 70 мм, 1 шт
										4,2х13 DIN 7981 - 2 шт*/
                                        //DoCalcMat
                                        lstCrossPos.Add(pos1);
                                        DataRow drMC = null;
                                        drMC = drOI.AddModelcalc("99 14 01", 2);
                                        drMC = drOI.AddModelcalc("01 09 17", 1, 70, 0, 0, 0, 0);
                                        drMC["addstr"] = "Additional";
                                        drMC = drOI.AddModelcalc("4,2х13 DIN 7981", 2);
                                        pos1 = 0;
                                        pos2 = 0;

                                        break;
                                    }

                                }
                            }
                        }
                    }
                    Err = "XCC: 002";
                    for (int im = 0; im < i.ImpostList.Count; im++)
                    {
                        if (i.ImpostList[im].Marking == "#17 06 08 + 17 05 16" || i.ImpostList[im].Marking == "#17 06 08 + 17 05 18")
                        {
                            if (!lstCrossPos.Any(x => x == i.ImpostPositionList[im]))
                            {
                                /*1) При соединении 1 ригеля к стойке: (T соед)
									01 09 17 - 40 мм, 1 шт
									99 12 08 -1 шт
									99 13 01 -1 шт*/
                                //DoCalcMat
                                DataRow drMC = null;
                                drMC = drOI.AddModelcalc("99 12 08", 1);
                                drMC = drOI.AddModelcalc("01 09 17", 1, 40, 0, 0, 0, 0);
                                drMC["addstr"] = "Additional";
                                drMC = drOI.AddModelcalc("99 13 01", 1);
                            }
                        }
                    }

                    Err = "XCC: 003";

                    // 27.05.2022
                    // Инцидент: https://servicedesk.it-swarm.pro/browse/DEV-83345
                    // БЫЛО: ImpostList, ImpostPositionList
                    // ИСПРАВИЛ на ImpostList2, ImpostPositionList2. Похоже обход импоста должен быть с другой стороны
                    for (int im = 0; im < i.ImpostList2.Count; im++)
                    {
                        if (i.ImpostList2[im].Marking == "#17 06 08 + 17 05 16" || i.ImpostList2[im].Marking == "#17 06 08 + 17 05 18")
                        {
                            if (!lstCrossPos.Any(x => x == i.ImpostPositionList2[im]))
                            {
                                /*1) При соединении 1 ригеля к стойке: (T соед)
									01 09 17 - 40 мм, 1 шт
									99 12 08 -1 шт
									99 13 01 -1 шт*/
                                //DoCalcMat
                                DataRow drMC = null;
                                drMC = drOI.AddModelcalc("99 12 08", 1);
                                drMC = drOI.AddModelcalc("01 09 17", 1, 40, 0, 0, 0, 0);
                                drMC["addstr"] = "Additional";
                                drMC = drOI.AddModelcalc("99 13 01", 1);
                            }
                        }
                    }
                    lstCrossPos.Clear();
                    Err = "XCC: 004";
                }
            }
            #endregion Х соединения

            foreach (RamaItem i in model.Rama)
            {
                if (i.AngleHorisont == 90 || i.AngleHorisont == 270)
                {

                    // Средние ригели (импосты)
                    for (int im = 0; im < i.ImpostList.Count; im++)
                    {
                        if (inRange(i.ImpostList[im].Marking.Replace("#", ""), "17 06 08 + 17 05 16", "17 06 08 + 17 05 18"))
                        {
                            DataRow drMC = null;
                            drMC = drOI.AddModelcalc("99 12 08", 1);
                            drMC = drOI.AddModelcalc("01 09 17", 1, 40, 0, 0, 0, 0);
                            drMC["addstr"] = "Additional";
                            drMC = drOI.AddModelcalc("99 13 01", 1);
                        }
                    }
                    /*
					if( i.BalkaStart != null && inRange( i.BalkaStart.Marking.Replace("#",""), "17 06 08 + 17 05 16", "17 06 08 + 17 05 18" ) )
					{
						DataRow drMC = null;
						drMC = drOI.AddModelcalc("99 12 08", 1);
						drMC = drOI.AddModelcalc("01 09 17", 1, 40, 0, 0, 0, 0);
						drMC["addstr"] = "Additional";
						drMC = drOI.AddModelcalc("99 13 01", 1);
					}
					if( i.BalkaEnd != null && inRange( i.BalkaEnd.Marking.Replace("#",""), "17 06 08 + 17 05 16", "17 06 08 + 17 05 18" ) )
					{
						DataRow drMC = null;
						drMC = drOI.AddModelcalc("99 12 08", 1);
						drMC = drOI.AddModelcalc("01 09 17", 1, 40, 0, 0, 0, 0);
						drMC["addstr"] = "Additional";
						drMC = drOI.AddModelcalc("99 13 01", 1);
					}
*/
                }
            }
        }

        void CalcCityAdapter(Construction model, ds_order.orderitemRow drOI)
        {
            if (model.ProfileSystem != "Inicial City Pro") return;
            //Унес расчет адаптеров из пересчета стоимости
            //https://servicedesk.it-swarm.pro/browse/DEV-83047
            if (model == null) return;
            string err = "1";
            try
            {
                #region Расчет адаптеров на витраж для встройки
                if (drOI != null
                    && !drOI.IsidpowerNull()
                    && drOI.idpower == 52
                    && !drOI.IsparentidNull()
                    && model.ConstructionType != null
                    && inRange(model.ConstructionType.ID, 13)
                    && !drOI.IsidprofsysNull()
                    && drOI.idprofsys == 144
                    && model.StvorkaList.Count > 0
                    && model.StvorkaList.Any(x => x.otkrivanieType == OtkrivanieType.Razd))
                {
                    err = "2";
                    // Ищем родителя 107 у данного алюминиевого изделия
                    ds_order.orderitemRow drParent = null;
                    foreach (ds_order.orderitemRow dr0 in Order.ds.orderitem.Select("idorderitem=" + drOI.parentid))
                    {
                        err = "2.1";
                        if (!dr0.IsidproductiontypeNull() && dr0.idproductiontype == 107)
                        {
                            err = "2.2";
                            drParent = dr0;
                            break;
                        }
                    }

                    // Есть родитель 107 и рядом имеется витраж, значит данная конструкция = встройка
                    if (drParent != null && Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38").Length > 0)
                    {
                        err = "3";
                        ds_order.orderitemRow drOIVitr = (ds_order.orderitemRow)Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38")[0];
                        DataRow drMC = drOIVitr.AddModelcalc("17 05 04", drOI.colorout_name, drOI.colorin_name, 1, drOI.height - 20 + 3, 90, 90, 0, 0, "");
                        drMC["idcolor1"] = drOIVitr.idcolorout;
                        drMC["addstr"] = "Additional";
                        drMC = drOIVitr.AddModelcalc("17 05 04", drOI.colorout_name, drOI.colorin_name, 1, drOI.height - 20 + 3, 90, 90, 0, 0, "");
                        drMC["idcolor1"] = drOIVitr.idcolorout;
                        drMC["addstr"] = "Additional";

                        //3.9x19
                        int cnt_samorez = ((int)Math.Round(((drOI.height - 20) / 300.0m), 0)) + 1;
                        drMC = drOIVitr.AddModelcalc("3.9x19", cnt_samorez * 2);

                        if (model.Rama.Any(x => x.Marking == "Без рамы в/н" && x.Side == ItemSide.Bottom))
                        {
                            drMC = drOIVitr.AddModelcalc("17 05 05", drOI.colorout_name, drOI.colorin_name, 1, drOI.width - 21, 90, 90, 0, 0, "");
                            drMC["idcolor1"] = drOIVitr.idcolorout;
                            drMC["addstr"] = "Additional";

                            //3.9x16
                            cnt_samorez = ((int)Math.Round(((drOI.width - 26) / 300.0m), 0)) + 1;
                            drMC = drOIVitr.AddModelcalc("3.9x16", cnt_samorez);
                            drMC["addstr"] = "59";
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка скрипта [Пересчет стоимости материалов] в методе CalcCityAdapter_" + drOI.numpos + "\r\n err=" + err + "\r\n" + ex.Message + "\r\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CalcCityUpl(Construction model, ds_order.orderitemRow drOI)
        {
            if (model.ProfileSystem != "Inicial City Pro") return;
            //Унес расчет адаптеров из пересчета стоимости
            //https://servicedesk.it-swarm.pro/browse/DEV-83047
            if (model == null) return;
            string err = "1";
            try
            {
                #region Расчет адаптеров на витраж для встройки
                if (drOI != null
                    && !drOI.IsidpowerNull()
                    && drOI.idpower == 52
                    && !drOI.IsparentidNull()
                    && model.ConstructionType != null
                    && inRange(model.ConstructionType.ID, 13)
                    && !drOI.IsidprofsysNull()
                    && drOI.idprofsys == 144
                    && model.StvorkaList.Count > 0)
                {
                    err = "2";
                    // Ищем родителя 107 у данного алюминиевого изделия
                    ds_order.orderitemRow drParent = null;
                    foreach (ds_order.orderitemRow dr0 in Order.ds.orderitem.Select("idorderitem=" + drOI.parentid))
                    {
                        err = "2.1";
                        if (!dr0.IsidproductiontypeNull() && dr0.idproductiontype == 107)
                        {
                            err = "2.2";
                            drParent = dr0;
                            break;
                        }
                    }

                    // Есть родитель 107 и рядом имеется витраж, значит данная конструкция = встройка
                    if (drParent != null && Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38").Length > 0)
                    {
                        if (model.StvorkaList.Any(x => x.otkrivanieType != OtkrivanieType.Razd))
                        {
                            err = "3";
                            ds_order.orderitemRow drOIVitr = (ds_order.orderitemRow)Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38")[0];
                            DataRow drMC = drOIVitr.AddModelcalc("17 30 02", 1, drOI.width * 2 + drOI.height * 2, 90, 90, 0, 0, "");
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка скрипта [Пересчет стоимости материалов] в методе CalcCityUpl_" + drOI.numpos + "\r\n err=" + err + "\r\n" + ex.Message + "\r\n" + ex.StackTrace
                    , "Ошибка"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        void CalcTatUpl(Construction model, ds_order.orderitemRow drOI)
        {
            if (!inRange(model.ProfileSystem, "Татпроф МП-40", "Татпроф МП-50", "Татпроф МП-50300", "Татпроф МП-45", "Татпроф МП-65", "Татпроф TFS50 Стойка-стойка встык", "Татпроф TFS50 Стойка-ригель внахлёст", "Татпроф МП-72 ТЕРМО", "Татпроф МП-72", "Татпроф TS-65", "Татпроф TS-72", "Татпроф TS-72 HI", "Inicial IW70D", "Inicial IW70D HI", "Inicial IW62D", "Татпроф TWS50")) return;
            //Унес расчет адаптеров из пересчета стоимости
            //https://servicedesk.it-swarm.pro/browse/DEV-83047
            if (model == null) return;
            string err = "1";
            try
            {
                //MessageBox.Show("" + drOI.idpower + "_" + model.ConstructionType.ID);
                #region Расчет адаптеров на витраж для встройки
                if (drOI != null
                    && !drOI.IsidpowerNull()
                    && drOI.idpower == 52
                    && !drOI.IsparentidNull()
                    && model.ConstructionType != null
                    && inRange(model.ConstructionType.ID, 13, 2, 7, 6, 35, 36))
                {
                    err = "2";
                    // Ищем родителя 107 у данного алюминиевого изделия
                    ds_order.orderitemRow drParent = null;

                    foreach (ds_order.orderitemRow dr0 in Order.ds.orderitem.Select("idorderitem=" + drOI.parentid))
                    {
                        err = "2.1";
                        if (!dr0.IsidproductiontypeNull() && dr0.idproductiontype == 107)
                        {
                            err = "2.2";
                            drParent = dr0;
                            break;
                        }
                    }

                    // Есть родитель 107 и рядом имеется витраж, значит данная конструкция = встройка
                    if (drParent != null && Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38").Length > 0)
                    {
                        double len = drOI.width * 2 + drOI.height * 2;
                        len += len * 0.05;
                        err = "3";
                        ds_order.orderitemRow drOIVitr = (ds_order.orderitemRow)Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38")[0];
                        DataRow drMC = null;
                        //MessageBox.Show("model.Rama[0].Marking"+  model.Rama[0].Marking);
                        foreach (RamaItem ri in model.Rama)
                        {
                            if (ri.Marking == "МП-45.01.06")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                                //break;
                            }
                            if (ri.Marking == "МП-45.02.07")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                                //break;
                            }
                            if (ri.Marking == "МП-45.02.08")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                                //break;
                            }
                            if (ri.Marking == "МП-65.01.02")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                            }
                            if (ri.Marking == "МП-65.02.04")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                            }
                            if (ri.Marking == "МП-65.02.02")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                            }
                            // 7910
                            if (ri.Marking == "МП-72.01.02 ТЕРМО")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                            }
                            if (ri.Marking == "МП-72.09.02 ТЕРМО")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                            }
                            if (ri.Marking == "МП-72.09.04 ТЕРМО")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                            }
                            if (ri.Marking == "МП-72.01.02")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                            }
                            if (ri.Marking == "МП-72.09.02")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                            }
                            if (ri.Marking == "МП-72.09.04")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                            }
                            //DEV-110334
                            if (ri.RamaType == RamaType.Porog) continue; //Если порог, то пропуск.
                            switch (ri.Marking)
                            {
                                //https://servicedesk.it-swarm.pro/browse/DEV-104649
                                case "W50.01.03":
                                case "W50.01.04":
                                case "W50.01.05":
                                case "W50.01.06":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                //TS 65
                                case "W65.01.02":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                case "D65.01.02":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                case "D65.01.04":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                //TS 72
                                case "W72.01.02":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                case "D72.01.02":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                case "D72.01.04":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                //TS 72 HI
                                case "W72.01.02 HI":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                case "D72.01.02 HI":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                case "D72.01.04 HI":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("W45.10.08", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                                case "03 11 04":
                                case "03 11 05":
                                case "03 11 06":
                                case "03 11 07":
                                case "03 18 04":
                                case "03 18 05":
                                case "03 18 06":
                                case "03 18 07":
                                case "03 19 04":
                                case "03 19 05":
                                case "03 19 06":
                                case "03 19 07":
                                    len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                    drMC = drOIVitr.AddModelcalc("03 30 35", 1, (int)len, 90, 90, 0, 0, "");
                                    break;
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка скрипта [Пересчет стоимости материалов] в методе CalcTatUpl_" + drOI.numpos + "\r\n err=" + err + "\r\n" + ex.Message + "\r\n" + ex.StackTrace
                    , "Ошибка"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        void CalcTatUpl2(Construction model, ds_order.orderitemRow drOI)
        {
            if (!inRange(model.ProfileSystem, "Татпроф МП-65")) return;
            //Унес расчет адаптеров из пересчета стоимости
            //https://servicedesk.it-swarm.pro/projects/DEV/queues/issue/DEV-105702
            if (model == null) return;
            string err = "1";
            try
            {
                //MessageBox.Show("" + drOI.idpower + "_" + model.ConstructionType.ID);
                #region Расчет адаптеров на витраж для встройки
                if (drOI != null
                    && !drOI.IsidpowerNull()
                    && drOI.idpower == 52
                    && !drOI.IsparentidNull()
                    && model.ConstructionType != null
                    && inRange(model.ConstructionType.ID, 2, 7, 6))
                {
                    err = "2";
                    // Ищем родителя 107 у данного алюминиевого изделия
                    ds_order.orderitemRow drParent = null;

                    foreach (ds_order.orderitemRow dr0 in Order.ds.orderitem.Select("idorderitem=" + drOI.parentid))
                    {
                        err = "2.1";
                        if (!dr0.IsidproductiontypeNull() && dr0.idproductiontype == 107)
                        {
                            err = "2.2";
                            drParent = dr0;
                            break;
                        }
                    }

                    // Есть родитель 107 и рядом имеется витраж, значит данная конструкция = встройка
                    if (drParent != null && Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38").Length > 0)
                    {
                        double len = drOI.width * 2 + drOI.height * 2;
                        len += len * 0.05;
                        err = "3";
                        ds_order.orderitemRow drOIVitr = (ds_order.orderitemRow)Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38")[0];
                        DataRow drMC = null;

                        if (drOIVitr == null || !inRange(drOIVitr.idprofsys, 120, 128, 193, 195, 157, 212, 214)) return;

                        //MessageBox.Show("model.Rama[0].Marking"+  model.Rama[0].Marking);
                        foreach (RamaItem ri in model.Rama)
                        {
                            if (ri.Marking == "W65.01.02")
                            {
                                len = ri.LengthInterfaceCalc + ri.LengthInterfaceCalc * 0.05;
                                drMC = drOIVitr.AddModelcalc("W45.10.03", 1, (int)len, 90, 90, 0, 0, "");
                                //break;

                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка скрипта [Пересчет стоимости материалов] в методе CalcTatUpl2_" + drOI.numpos + "\r\n err=" + err + "\r\n" + ex.Message + "\r\n" + ex.StackTrace
                    , "Ошибка"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        void AddMaterialFromCustomTableCity(Construction model, ds_order.orderitemRow drOI)
        {
            if (model.ProfileSystem != "Inicial City Pro") return;

            lstConImpDisassembled.Clear();
            lstConRegDisassembled.Clear();
            lstConRegAssembled.Clear();
            lstConFrameBeemDisassembled.Clear();
            lstConStvorkaBeemAssembled.Clear();

            string err = "1";
            try
            {
                #region CityPro 
                foreach (RamaItem ri in model.Rama)
                {
                    if (ri.Marking.ToLower().Contains("без")) continue;

                    if (!lstConFrameBeemDisassembled.Contains(ri))
                    {
                        lstConFrameBeemDisassembled.Add(ri);
                    }
                }
                foreach (Stvorka s in model.StvorkaList)
                {
                    foreach (StvorkaItem si in s)
                    {
                        if (!lstConStvorkaBeemAssembled.Contains(si))
                        {
                            lstConStvorkaBeemAssembled.Add(si);
                        }
                    }
                }
                foreach (Impost i in model.ImpostList)
                {
                    if (i.Marking.ToLower().Contains("без")) continue;
                    if (!lstConImpDisassembled.Contains(i))
                    {
                        lstConImpDisassembled.Add(i);
                    }
                }
                foreach (Glass g in model.GlassList)
                {
                    if (g.Part.Contains("C"))
                    {
                        lstConRegAssembled.Add(g);
                    }
                    else
                    {
                        lstConRegDisassembled.Add(g);
                    }
                }
                #endregion CityPro

                AddMaterialFromCustomTableIP45(drOI, model);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка скрипта [Пересчет стоимости материалов] в методе AddMaterialFromCustomTableCity" + drOI.numpos + "\r\n err=" + err + "\r\n" + ex.Message + "\r\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AddMaterialFromCustomTableSokol(Construction model, ds_order.orderitemRow drOI)
        {
            if (model.ProfileSystem != "Сокол МП-640") return;

            lstConImpDisassembled.Clear();
            lstConRegDisassembled.Clear();
            lstConRegAssembled.Clear();
            lstConFrameBeemDisassembled.Clear();
            lstConStvorkaBeemAssembled.Clear();

            string err = "1";
            try
            {
                #region Сокол МП-640 
                foreach (RamaItem ri in model.Rama)
                {
                    if (ri.Marking.ToLower().Contains("без")) continue;

                    if (!lstConFrameBeemDisassembled.Contains(ri))
                    {
                        lstConFrameBeemDisassembled.Add(ri);
                    }
                }
                foreach (Stvorka s in model.StvorkaList)
                {
                    foreach (StvorkaItem si in s)
                    {
                        if (!lstConStvorkaBeemAssembled.Contains(si))
                        {
                            lstConStvorkaBeemAssembled.Add(si);
                        }
                    }
                }
                foreach (Impost i in model.ImpostList)
                {
                    if (i.Marking.ToLower().Contains("без")) continue;
                    if (!lstConImpDisassembled.Contains(i))
                    {
                        lstConImpDisassembled.Add(i);
                    }
                }
                foreach (Glass g in model.GlassList)
                {
                    if (g.Part.Contains("C"))
                    {
                        lstConRegAssembled.Add(g);
                    }
                    else
                    {
                        lstConRegDisassembled.Add(g);
                    }
                }
                #endregion Сокол МП-640

                AddMaterialFromCustomTableIP45(drOI, model);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка скрипта [Пересчет стоимости материалов] в методе AddMaterialFromCustomTableCity" + drOI.numpos + "\r\n err=" + err + "\r\n" + ex.Message + "\r\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CalcTPT72PS_Details(Construction model, ds_order.orderitemRow drOI)
        {
            if (drOI == null || drOI.IsidprofsysNull() || drOI.idprofsys != 192 || drOI.IsidconstructiontypeNull() || drOI.idconstructiontype != 2 || model == null || model.StvorkaList.Count == 0) return;

            foreach (Stvorka s in model.StvorkaList)
            {
                if (s.otkrivanieType != OtkrivanieType.PodiyomnoSdvijnaya) continue;

                if (s.ShtulpExist == ShtulpExist.NoShtulp)
                {
                    // Одиночная створка
                    foreach (StvorkaItem si in s)
                    {
                        switch ((int)si.AngNakl)
                        {
                            case 0: // Низ
                                if (si.RamaItem != null && s.otkrivanieSide == OtkrivanieSide.Right)
                                {
                                    // Снизу рама и открывание вправо (глухарь справа)

                                    // Балка створки, у которой рядом импост
                                    StvorkaItem si2 = s.Find(x => (x.AngNakl == 90 || x.AngNakl == 270) && x.Impost != null);

                                    if (si2 != null)
                                    {
                                        int idx_impost = si.RamaItem.ImpostList.IndexOf(si2.Impost);
                                        if (idx_impost >= 0)
                                        {
                                            //double w_detail = si.RamaItem.LengthInterfaceCalc - si.RamaItem.ImpostPositionListDoubleInterface[idx_impost];
                                            double w_detail = si.RamaItem.ImpostPositionListDoubleInterface[idx_impost];
                                            AddTPT72PS_Detail(si.RamaItem, drOI, (int)(w_detail - 126), "Н_ЛевоОП");
                                        }
                                    }
                                }
                                else if (si.RamaItem != null && s.otkrivanieSide == OtkrivanieSide.Left)
                                {
                                    // Снизу рама и открывание влево (глухарь слева)

                                    // Балка створки, у которой рядом импост
                                    StvorkaItem si2 = s.Find(x => (x.AngNakl == 90 || x.AngNakl == 270) && x.Impost != null);

                                    if (si2 != null)
                                    {
                                        int idx_impost = si.RamaItem.ImpostList.IndexOf(si2.Impost);
                                        if (idx_impost >= 0)
                                        {
                                            double w_detail = si.RamaItem.LengthInterfaceCalc - si.RamaItem.ImpostPositionListDoubleInterface[idx_impost];
                                            //	double w_detail = si.RamaItem.ImpostPositionListDoubleInterface[idx_impost];
                                            AddTPT72PS_Detail(si.RamaItem, drOI, (int)(w_detail - 126), "Н_ПравоОЛ");
                                        }
                                    }
                                }
                                break;
                            case 180:
                                if (si.RamaItem != null && s.otkrivanieSide == OtkrivanieSide.Right)
                                {
                                    // Снизу рама и открывание вправо (глухарь справа)

                                    // Балка створки, у которой рядом импост
                                    StvorkaItem si2 = s.Find(x => (x.AngNakl == 90 || x.AngNakl == 270) && x.Impost != null);

                                    if (si2 != null)
                                    {
                                        int idx_impost = si.RamaItem.ImpostList.IndexOf(si2.Impost);
                                        if (idx_impost >= 0)
                                        {
                                            // double w_detail = si.RamaItem.ImpostPositionListDoubleInterface[idx_impost];
                                            double w_detail = si.RamaItem.LengthInterfaceCalc - si.RamaItem.ImpostPositionListDoubleInterface[idx_impost];
                                            AddTPT72PS_Detail(si.RamaItem, drOI, (int)(w_detail - 100), "В_ЛевоОП");
                                        }
                                    }
                                }
                                else if (si.RamaItem != null && s.otkrivanieSide == OtkrivanieSide.Left)
                                {
                                    // Снизу рама и открывание влево (глухарь слева)

                                    // Балка створки, у которой рядом импост
                                    StvorkaItem si2 = s.Find(x => (x.AngNakl == 90 || x.AngNakl == 270) && x.Impost != null);

                                    if (si2 != null)
                                    {
                                        int idx_impost = si.RamaItem.ImpostList.IndexOf(si2.Impost);
                                        if (idx_impost >= 0)
                                        {
                                            double w_detail = si.RamaItem.ImpostPositionListDoubleInterface[idx_impost];
                                            // double w_detail = si.RamaItem.LengthInterfaceCalc - si.RamaItem.ImpostPositionListDoubleInterface[idx_impost];
                                            AddTPT72PS_Detail(si.RamaItem, drOI, (int)(w_detail - 100), "В_ПравоОЛ");
                                        }
                                    }
                                }
                                break;
                            case 90:
                            case 270:
                                if (si.RamaItem != null) AddTPT72PS_Detail(si.RamaItem, drOI, model.Rama.Height - 86, s.otkrivanieSide == OtkrivanieSide.Right ? "Л" : "П");
                                break;
                        }

                    }
                }
                else if (s.ShtulpExist == ShtulpExist.NonExist)
                {
                    Stvorka s2 = s.ShtulpStvorka;

                    // S=Штульповая створка (акт)
                    // S2=Штульповая створка (пасс)

                    // Находим импост со стороны активной створки					
                    StvorkaItem s_si1 = s.Find(x => (x.AngNakl == 90 || x.AngNakl == 270) && x.Impost != null && x.Impost.ImpostType != ImpostType.Shtulp);

                    // Находим импост со стороны пассивной створки
                    StvorkaItem s2_si1 = s2.Find(x => (x.AngNakl == 90 || x.AngNakl == 270) && x.Impost != null && x.Impost.ImpostType != ImpostType.Shtulp);

                    if (s_si1 != null && s2_si1 != null)
                    {
                        foreach (RamaItem ri in model.Rama)
                        {
                            if ((ri.AngNakl == 0 || ri.AngNakl == 180) && ri.StvorkaList.IndexOf(s) >= 0 && ri.StvorkaList.IndexOf(s2) >= 0)
                            {
                                // Нижняя балка рамы соприкасается с активной и пассивной створками
                                int idx_impost1 = ri.ImpostList.IndexOf(s_si1.Impost);
                                int idx_impost2 = ri.ImpostList.IndexOf(s2_si1.Impost);

                                double coord_imp1 = ri.ImpostPositionListDoubleInterface[idx_impost1];
                                double coord_imp2 = ri.ImpostPositionListDoubleInterface[idx_impost2];

                                double w_detail = Math.Abs(coord_imp1 - coord_imp2) - 140;
                                AddTPT72PS_Detail(ri, drOI, (int)w_detail, ri.AngNakl == 0 ? "Н" : "Л");

                            }
                        }
                    }
                }

            }
        }

        void AddTPT72PS_Detail(RamaItem ri, ds_order.orderitemRow drOI, int detaillen, string side_comment)
        {
            string tt_char = drOI.GetModelParamList()["Теплотехническая характеристика"].StrValue;

            ds_order.modelcalcRow mc = drOI.AddModelcalc("ТПТ-72.02.13", 1);
            mc.addstr = "Additional";
            mc.thick = detaillen;
            mc.addstr3 = side_comment;
            mc.addint = ri.ID;
            mc.modelpart = "Р-" + ((int)ri.ID + 1);
            mc.idcolor1 = drOI.idcolorin;
            mc.idcolor2 = drOI.idcolorout;
            mc.ang1 = 90;
            mc.ang2 = 90;

            mc = drOI.AddModelcalc("РВ 048.0750-FP", 1);
            mc.thick = detaillen;
            mc.addstr3 = side_comment;
            mc.addint = ri.ID;
            mc.modelpart = "Р-" + ((int)ri.ID + 1);

            if (tt_char == "I3")
            {
                mc = drOI.AddModelcalc("ТПУ-358", 1);
                mc.thick = detaillen;
                mc.addstr3 = side_comment;
                mc.addint = ri.ID;
                mc.modelpart = "Р-" + ((int)ri.ID + 1);
            }

        }

        void CalcMP640RaspMaterials(Construction model, ds_order.orderitemRow drOI)
        {

            if (model.ProfileSystem != "Сокол МП-640") return;
            //Унес расчет адаптеров из пересчета стоимости
            //https://servicedesk.it-swarm.pro/browse/DEV-83047
            if (model == null) return;
            string err = "1";
            try
            {
                #region Расчет адаптеров на витраж для встройки
                if (drOI != null
                    && !drOI.IsidpowerNull()
                    && drOI.idpower == 52
                    && !drOI.IsparentidNull()
                    && model.ConstructionType != null
                    && inRange(model.ConstructionType.ID, 13)
                    && !drOI.IsidprofsysNull()
                    && drOI.idprofsys == 208)
                {
                    err = "2";
                    // Ищем родителя 107 у данного алюминиевого изделия
                    ds_order.orderitemRow drParent = null;
                    foreach (ds_order.orderitemRow dr0 in Order.ds.orderitem.Select("idorderitem=" + drOI.parentid))
                    {
                        err = "2.1";
                        if (!dr0.IsidproductiontypeNull() && dr0.idproductiontype == 107)
                        {
                            err = "2.2";
                            drParent = dr0;
                            break;
                        }
                    }

                    // Есть родитель 107 и рядом имеется витраж, значит данная конструкция = встройка
                    if (drParent != null && Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38").Length > 0)
                    {
                        err = "3";
                        ds_order.orderitemRow drOIVitr = (ds_order.orderitemRow)Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38")[0];
                        DataRow drMC = null;
                        foreach (RamaItem ri in model.Rama)
                        {
                            if (ri.Marking == "Без ригеля_угловая стойка")
                            {
                                drMC = drOIVitr.AddModelcalc("МП-64076", drOI.colorout_name, drOI.colorin_name, 1, ri.LengthInterfaceCalcInt, 90, 90, 0, 0, "");
                                drMC["idcolor1"] = drOIVitr.idcolorout;
                                drMC["idcolor2"] = drOIVitr.idcolorin;
                                drMC["addstr"] = "Additional";

                                drMC = drOIVitr.AddModelcalc("МП-64076", drOI.colorout_name, drOI.colorin_name, 1, ri.LengthInterfaceCalcInt, 90, 90, 0, 0, "");
                                drMC["idcolor1"] = drOIVitr.idcolorout;
                                drMC["idcolor2"] = drOIVitr.idcolorin;
                                drMC["addstr"] = "Additional";

                                //4,2x32 DIN 7981
                                int cnt_samorez = ((int)Math.Round((decimal)ri.LengthInterfaceCalc / 150.0m, 0)) + 1;
                                drMC = drOIVitr.AddModelcalc("4,2x32 DIN 7981", cnt_samorez);

                                //МПУ-021
                                cnt_samorez = ((int)Math.Round(((decimal)ri.LengthInterfaceCalc / 300.0m), 0)) + 1;
                                drMC = drOIVitr.AddModelcalc("МПУ-021", cnt_samorez);
                                drMC["addstr"] = "59";
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка скрипта расчета в методе CalcMP640RaspMaterials_" + drOI.numpos + "\r\n err=" + err + "\r\n" + ex.Message + "\r\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CalcMP640RazdMaterials(Construction model, ds_order.orderitemRow drOI)
        {

            if (model.ProfileSystem != "Сокол МП-640") return;
            //Унес расчет адаптеров из пересчета стоимости
            //https://servicedesk.it-swarm.pro/browse/DEV-83047
            if (model == null) return;
            string err = "1";
            try
            {
                #region Расчет адаптеров на витраж для встройки
                if (drOI != null
                    && !drOI.IsidpowerNull()
                    && drOI.idpower == 52
                    && !drOI.IsparentidNull()
                    && model.ConstructionType != null
                    && inRange(model.ConstructionType.ID, 13)
                    && !drOI.IsidprofsysNull()
                    && drOI.idprofsys == 208
                    && model.StvorkaList.Count > 0
                    && model.StvorkaList.Any(x => x.otkrivanieType == OtkrivanieType.Razd))
                {
                    bool isGluh = model.GlassList.Any(x => x.ModelPart != ModelPart.Stvorka);

                    err = "2";
                    // Ищем родителя 107 у данного алюминиевого изделия
                    ds_order.orderitemRow drParent = null;
                    foreach (ds_order.orderitemRow dr0 in Order.ds.orderitem.Select("idorderitem=" + drOI.parentid))
                    {
                        err = "2.1";
                        if (!dr0.IsidproductiontypeNull() && dr0.idproductiontype == 107)
                        {
                            err = "2.2";
                            drParent = dr0;
                            break;
                        }
                    }

                    // Есть родитель 107 и рядом имеется витраж, значит данная конструкция = встройка
                    if (drParent != null && Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38").Length > 0)
                    {
                        DataRow drMC = null;
                        err = "3";
                        ds_order.orderitemRow drOIVitr = (ds_order.orderitemRow)Order.ds.orderitem.Select("parentid=" + drParent.idorderitem + " and idconstructiontype=38")[0];

                        if (Model.StvorkaList.Count > 1)
                        {
                            foreach (RamaItem ri in Model.Rama)
                            {

                                if (ri.Marking == "Без рамы в/н Сдвижные створки")
                                {
                                    //МП-64051
                                    drMC = drOIVitr.AddModelcalc("МП-64051", 1, drOI.width, 90, 90, 0, 0, "");
                                    drMC["idcolor1"] = drOIVitr.idcolorout;
                                    drMC["idcolor2"] = drOIVitr.idcolorout;

                                    //4,2х13 DIN 7982
                                    int cnt_samorez = ((int)Math.Round(drOI.width / 300.0m, 0)) + 1;
                                    drMC = drOIVitr.AddModelcalc("4,2х13 DIN 7982", cnt_samorez);
                                }
                                if (ri.Marking == "Без рамы л/п Сдвижные створки")
                                {

                                    //МП-64066
                                    drMC = drOIVitr.AddModelcalc("МП-64066", 1, drOI.height, 90, 90, 0, 0, "");
                                    drMC["idcolor1"] = drOIVitr.idcolorout;
                                    drMC["idcolor2"] = drOIVitr.idcolorout;
                                    drMC["addstr"] = "Additional";


                                    //3.9x25
                                    drMC = drOIVitr.AddModelcalc("3.9x25", 2);
                                }
                            }
                        }
                        if (Model.StvorkaList.Count == 1)
                        {
                            //МП-64066
                            drMC = drOIVitr.AddModelcalc("МП-64066", 1, drOI.height, 90, 90, 0, 0, "");
                            drMC["idcolor1"] = drOIVitr.idcolorout;
                            drMC["idcolor2"] = drOIVitr.idcolorout;
                            drMC["addstr"] = "Additional";

                            drMC = drOIVitr.AddModelcalc("3.9x25", 2);

                            drMC = drOIVitr.AddModelcalc("МП-64063", drOI.colorout_name, "", 1, drOI.height, 90, 90, 0, 0, "");
                            drMC["idcolor1"] = drOIVitr.idcolorout;
                            drMC["addstr"] = "Additional";

                            //9FE/04
                            drMC = drOIVitr.AddModelcalc("9FE/04", "", "", 1, drOI.height, 90, 90, 0, 0, "");

                            drMC = drOIVitr.AddModelcalc("МП-64063", drOI.colorout_name, "", 1, drOI.width, 90, 90, 0, 0, "");
                            drMC["idcolor1"] = drOIVitr.idcolorout;
                            drMC["addstr"] = "Additional";

                            //9FE/04
                            drMC = drOIVitr.AddModelcalc("9FE/04", "", "", 1, drOI.width, 90, 90, 0, 0, "");

                            drMC = drOIVitr.AddModelcalc("МП-64063", drOI.colorout_name, "", 1, drOI.width, 90, 90, 0, 0, "");
                            drMC["idcolor1"] = drOIVitr.idcolorout;
                            drMC["addstr"] = "Additional";

                            //9FE/04
                            drMC = drOIVitr.AddModelcalc("9FE/04", "", "", 1, drOI.width, 90, 90, 0, 0, "");

                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка скрипта расчета в методе CalcMP640RazdMaterials_" + drOI.numpos + "\r\n err=" + err + "\r\n" + ex.Message + "\r\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-- DEV-104084 7889
        void CheckFillingWeight(Construction model, ds_order.orderitemRow drOI)
        {
            List<string> mes_errors = new List<string>();
            double ves = 0;
            foreach (Glass g in model.GlassList)
            {
                ves = g.GetUserParam("Вес заполнения").IntValue;
                if (ves <= 50) continue;

                //-- смотрим, что заполнение находится именно в глухой секции, т.е. отсутствуют рамы створки
                int cRama = 0; int cImp = 0; int cStv = 0;
                foreach (GlassItem gitem in g)
                {
                    if (gitem.ConnectRama != null)
                    {
                        cRama += 1;
                    }
                    if (gitem.ConnectImpost != null)
                    {
                        cImp += 1;
                    }
                    if (gitem.ConnectStvorka != null)
                    {
                        cStv += 1;
                    }
                }
                if (cStv > 0) continue; //-- заполнение створки не  интересует

                if (cRama == 0 && cImp == 0) continue; //-- типа заполнение само по себе

                mes_errors.Add("№" + (g.ID + 1).ToString() + "-" + ves.ToString() + " кг");
            }

            if (mes_errors.Count > 0)
            {
                Order.AddErrorUnical(drOI.idorderitem, "о1418", "", "Заполнения: " + String.Join(", ", mes_errors));
            }
            return;
        }

        void CalcGoodByBigWeightSP(Balka b, ModelPartClass mpc, bool mpcLeft, bool oneLevel, ds_order.orderitemRow drOI)
        {
            string Err = "CalcGoodByBigWeightSP 1";
            //try
            //{
            Err = "CalcGoodByBigWeightSP 1.1";
            string riPart = "";
            Balka riNiz = mpcLeft ? mpc.Balka2 : mpc.Balka1;
            Err = "CalcGoodByBigWeightSP 1.2";
            if (riNiz == null) return;
            Err = "CalcGoodByBigWeightSP 1.3";
            if (riNiz.IsRail)
                riPart = "Ри-" + (riNiz.ID + 1).ToString();
            else if (mpc.Balka2 != null && mpc.Balka2.IsRack)
            {
                riPart = "Ст-" + (riNiz.ID + 1).ToString();
            }
            Err = "CalcGoodByBigWeightSP 1.4";
            Glass g = mpc.Glass;
            if (g == null || g.Part == null)
                return;
            riPart += " под [" + g.Part + "]";

            Err = "CalcGoodByBigWeightSP 2";
            if (mpc.ModelPart != ModelPart.Glass)
                return;

            Err = "CalcGoodByBigWeightSP 3";
            UserParam up = g.GetUserParam("Вес заполнения");
            double GPweight = 0;
            if (up == null)
                return;
            GPweight = up.IntValue;
            Err = "CalcGoodByBigWeightSP 4";

            //-- определяем ригель под заполнением DEV-103012 7889
            string downRmarking = ""; //-- артикул нижнего ригеля
            foreach (GlassItem gitem in g)
            {
                if (gitem.SideExtended == ItemSide.Bottom)
                {
                    if (gitem.ConnectRama != null)
                    {
                        downRmarking = gitem.ConnectRama.Marking;
                    }
                    else if (gitem.ConnectImpost != null)
                    {
                        downRmarking = gitem.ConnectImpost.Marking;
                    }
                    else if (gitem.ConnectStvorka != null)
                    {
                        downRmarking = gitem.ConnectStvorka.Marking;
                    }
                }
            }


            string part = b.Tag4 + " [" + g.Part + "]" + (oneLevel ? "+" : "");
            if (GPweight >= 135)
            {
                Order.AddErrorUnical(drOI.idorderitem, "и1582", "Информация! Под стеклопакетом весом от 135 кг артикул ригеля должен совпадать с артикулом соседних ригелей слева/справа");
            }
            bool isRight = riNiz.BalkaStart.BalkaType == ModelPart.RamaItem || (b.BalkaType == ModelPart.Impost && riNiz.BalkaEnd.BalkaType == ModelPart.RamaItem);

            if (GPweight >= 135 && GPweight <= 200)
            {
                //добавить на эту стойку материалы из узла 1 
                Err = "CalcGoodByBigWeightSP 5";
                var mc = drOI.AddModelcalc("99 12 13", 2, 0, part);
                mc.addstr = "59";
                mc = drOI.AddModelcalc("99 14 03", 2, 0, part);
                mc.addstr = "59";
                drOI.AddModelcalc("01 71 21", 2, 0, part);
                mc = drOI.AddModelcalc("99 14 01", 2, 0, part);
                mc.addstr = "59";
                mc = drOI.AddModelcalc("99 13 01", 2, 0, part);
                mc.addstr = "59";
                if (g.Thickness <= 48)
                {
                    //добавить на заполнение материалы из узла 3
                    drOI.AddModelcalc("01 75 01", oneLevel ? 2 : 1, 0, part);
                    drOI.AddModelcalc("99 01 24", oneLevel ? 4 : 2, 0, part);
                }
                else if (g.Thickness > 48 && g.Thickness <= 54)
                {
                    //добавить на заполнение материалы из узла 4
                    drOI.AddModelcalc("01 75 02", oneLevel ? 2 : 1, 0, part);
                    drOI.AddModelcalc("99 01 24", oneLevel ? 4 : 2, 0, part);
                }
                Err = "CalcGoodByBigWeightSP 6";
                //3)Ошибка! Под стеклопакеты весом более 135 кг использовать минимальный ригель 75 мм 01 02 04-01
                if (inRange(downRmarking.Replace("#", ""), "010202", "010203-01", "010203", "010204-01", "010204"))
                    Order.AddErrorUnical(drOI.idorderitem, "о1346", riPart, riPart + " :слабый ригель!");
            }
            else if (GPweight > 200 && GPweight <= 350)
            {
                Err = "CalcGoodByBigWeightSP 7";
                //добавить на эту стойку материалы из узла 2
                drOI.AddModelcalc("01 71 21", 3, 0, part);
                var mc = drOI.AddModelcalc("99 17 04", 3, 0, part);
                mc.addstr = "59";
                mc = drOI.AddModelcalc("99 14 04", 3, 0, part);
                mc.addstr = "59";
                mc = drOI.AddModelcalc("99 13 01", 3, 0, part);
                mc.addstr = "59";
                //закладные на каждое соединение ригель-стойка
                if (inRange(riNiz.Marking.Replace("#", ""), "010206-01", "010206"))
                {
                    if (oneLevel)
                    {
                        drOI.AddModelcalc("01 75 25", 1, 0, part);
                        drOI.AddModelcalc("01 75 25-01", 1, 0, part);
                    }
                    else if (!isRight)
                    {
                        drOI.AddModelcalc("01 75 25", 1, 0, part);
                    }
                    else
                    {
                        drOI.AddModelcalc("01 75 25-01", 1, 0, part);
                    }


                }
                else if (riNiz.Marking.Replace("#", "") == "010207")
                {
                    if (oneLevel)
                    {
                        drOI.AddModelcalc("01 75 26", 1, 0, part);
                        drOI.AddModelcalc("01 75 26-01", 1, 0, part);
                    }
                    else
                        if (!isRight)
                    {
                        drOI.AddModelcalc("01 75 26", 1, 0, part);
                    }
                    else
                    {
                        drOI.AddModelcalc("01 75 26-01", 1, 0, part);
                    }

                }
                else if (riNiz.Marking.Replace("#", "") == "010208")
                {
                    if (oneLevel)
                    {
                        drOI.AddModelcalc("01 75 27", 1, 0, part);
                        drOI.AddModelcalc("01 75 27-01", 1, 0, part);
                    }
                    else
                        if (!isRight)
                    {
                        drOI.AddModelcalc("01 75 27", 1, 0, part);
                    }
                    else
                    {
                        drOI.AddModelcalc("01 75 27-01", 1, 0, part);
                    }


                }
                if (g.Thickness <= 48)
                {
                    //добавить на заполнение материалы из узла 5
                    drOI.AddModelcalc("01 75 05", oneLevel ? 2 : 1, 0, part);
                    drOI.AddModelcalc("99 01 24", oneLevel ? 4 : 2, 0, part);
                }
                else
                    if (g.Thickness >= 50 && g.Thickness <= 54)
                {
                    //добавить на заполнение материалы из узла 6
                    drOI.AddModelcalc("01 75 06", oneLevel ? 2 : 1, 0, part);
                    drOI.AddModelcalc("99 01 24", oneLevel ? 4 : 2, 0, part);
                }
                else if (g.Thickness >= 56)
                {
                    //добавить на заполнение материалы из узла 7
                    drOI.AddModelcalc("01 75 07", oneLevel ? 2 : 1, 0, part);
                    drOI.AddModelcalc("99 01 24", oneLevel ? 4 : 2, 0, part);
                }
                Err = "CalcGoodByBigWeightSP 8";
                //4)Ошибка! Под стеклопакеты весом более 200 кг использовать ригели 01 02 06, 01 02 06-01, 01 02 07 или 01 02 08
                if (!inRange(downRmarking.Replace("#", ""), "010206", "010206-01", "010207", "010208"))
                    Order.AddErrorUnical(drOI.idorderitem, "о1347", riPart, riPart + " :слабый ригель!");
            }
            else if (GPweight > 350 && GPweight <= 500)
            {
                Err = "CalcGoodByBigWeightSP 9";
                //добавить на эту стойку материалы из узла 2
                drOI.AddModelcalc("01 71 21", 3, 0, part);
                var mc = drOI.AddModelcalc("99 17 04", 3, 0, part);
                mc.addstr = "59";
                drOI.AddModelcalc("99 14 04", 3, 0, part);
                mc = drOI.AddModelcalc("99 13 01", 3, 0, part);
                mc.addstr = "59";
                //закладные на каждое соединение ригель-стойка
                //закладные на каждое соединение ригель-стойка
                if (inRange(riNiz.Marking.Replace("#", ""), "010206-01", "010206"))
                {
                    if (oneLevel)
                    {
                        drOI.AddModelcalc("01 75 25", 1, 0, part);
                        drOI.AddModelcalc("01 75 25-01", 1, 0, part);
                    }
                    else
                        if (!isRight)
                    {
                        drOI.AddModelcalc("01 75 25", 1, 0, part);
                    }
                    else
                    {

                        drOI.AddModelcalc("01 75 25-01", 1, 0, part);
                    }

                }
                else if (riNiz.Marking.Replace("#", "") == "010207")
                {
                    if (oneLevel)
                    {
                        drOI.AddModelcalc("01 75 26", 1, 0, part);
                        drOI.AddModelcalc("01 75 26-01", 1, 0, part);
                    }
                    else
                        if (!isRight)
                    {
                        drOI.AddModelcalc("01 75 26", 1, 0, part);
                    }
                    else
                    {
                        drOI.AddModelcalc("01 75 26-01", 1, 0, part);
                    }

                }
                else if (riNiz.Marking.Replace("#", "") == "010208")
                {
                    if (oneLevel)
                    {
                        drOI.AddModelcalc("01 75 27", 1, 0, part);
                        drOI.AddModelcalc("01 75 27-01", 1, 0, part);
                    }
                    else
                        if (!isRight)
                    {
                        drOI.AddModelcalc("01 75 27", 1, 0, part);
                    }
                    else
                    {
                        drOI.AddModelcalc("01 75 27-01", 1, 0, part);
                    }

                }
                Err = "CalcGoodByBigWeightSP 10";
                if (!oneLevel) //если ригель примыкает с одной стороны
                {
                    if (g.Thickness <= 48)
                    {
                        //добавить на заполнение материалы из узла 8
                        drOI.AddModelcalc("01 75 09", 1, 0, part);
                        drOI.AddModelcalc("01 75 13", 1, 0, part);
                        drOI.AddModelcalc("99 15 02", 2, 0, part);
                        drOI.AddModelcalc("99 18 02", 6, 0, part);
                    }
                    else if (g.Thickness >= 50 && g.Thickness <= 54)
                    {
                        //добавить на заполнение материалы из узла 9
                        drOI.AddModelcalc("01 75 10", 1, 0, part);
                        drOI.AddModelcalc("01 75 14", 1, 0, part);
                        drOI.AddModelcalc("99 15 02", 2, 0, part);
                        drOI.AddModelcalc("99 18 02", 6, 0, part);
                    }
                    else
                    {
                        //добавить на заполнение материалы из узла 10
                        drOI.AddModelcalc("01 75 11", 1, 0, part);
                        drOI.AddModelcalc("01 75 15", 1, 0, part);
                        drOI.AddModelcalc("99 15 02", 2, 0, part);
                        drOI.AddModelcalc("99 18 02", 6, 0, part);
                    }
                }
                else //oneLevel - ригель примыкает с двух сторон в одинаковой координате
                {
                    if (g.Thickness <= 48)
                    {
                        //добавить на заполнение материалы из узла 11
                        drOI.AddModelcalc("01 75 17", 1, 0, part);
                        drOI.AddModelcalc("01 75 13", 1, 0, part);
                        drOI.AddModelcalc("99 15 02", 2, 0, part);
                        drOI.AddModelcalc("99 18 02", 9, 0, part);
                    }
                    else if (g.Thickness >= 50 && g.Thickness <= 54)
                    {
                        //добавить на заполнение материалы из узла 12
                        drOI.AddModelcalc("01 75 18", 1, 0, part);
                        drOI.AddModelcalc("01 75 14", 1, 0, part);
                        drOI.AddModelcalc("99 15 02", 2, 0, part);
                        drOI.AddModelcalc("99 18 02", 9, 0, part);
                    }
                    else
                    {
                        //добавить на заполнение материалы из узла 13
                        drOI.AddModelcalc("01 75 19", 1, 0, part);
                        drOI.AddModelcalc("01 75 15", 1, 0, part);
                        drOI.AddModelcalc("99 15 02", 2, 0, part);
                        drOI.AddModelcalc("99 18 02", 9, 0, part);
                    }
                }
                Err = "CalcGoodByBigWeightSP 11";
                //4)Ошибка! Под стеклопакеты весом более 200 кг использовать ригели 01 02 06, 01 02 06-01, 01 02 07 или 01 02 08
                if (!inRange(downRmarking.Replace("#", ""), "010206", "010206-01", "010207", "010208"))
                    Order.AddErrorUnical(drOI.idorderitem, "о1347", riPart, riPart + " :слабый ригель!");
            }
        }

        void CheckCastomAlum(Construction model, ds_order.orderitemRow drOI)
        {
            List<string> BadRack = new List<string>();
            #region стыкованные стойки с выносами запрещены: DEV-107260
            if (model != null && !drOI.IsidconstructiontypeNull() && inRange(drOI.idconstructiontype, 38, 13)) //Алюминиевая конструкция, Витраж
            {

                #region Крайние стойки (рама)
                /*
				foreach (RamaItem ri in model.Rama)
				{
					//пока отключил - импостов достаточно
					if (1== 0 && ri.IsRack)
					{
						#region Проверяем конец 1
						if (ri.BalkaStart != null && ri.BalkaStart.IsRack && inRange(ri.BalkaStart.AngleHorisont, 90) && ri.BalkaEnd.IsRail)
						{
							//проверяем конец что он без выносов
							//берем соседнюю стойку
							//ri.BalkaEnd - это ригель по соседству с которым проверяем выносы у стойки
							Balka b = ri.BalkaEnd.BalkaStart.Guid != ri.Guid ? ri.BalkaEnd.BalkaStart : ri.BalkaEnd.BalkaEnd;
							if (b is null || !(b is Impost))
								continue;
							Impost rail = (Impost)b;

							if (rail.RailsList[0].Guid == ri.BalkaEnd.Guid && rail.RailPositionListDoubleInterface[0] > 0.05)
							{
								BadRack.Add(ri.Tag3);
								continue;
							}
							else if (rail.RailsList[rail.RailsList.Count() - 1].Guid == ri.BalkaEnd.Guid && rail.Lenght - rail.RailPositionListDoubleInterface[rail.RailsList.Count() - 1] > 0.05)
                            {
								BadRack.Add(ri.Tag3);
								continue;
							}
						}
						#endregion
						#region Проверяем конец 2
						if (ri.BalkaEnd  != null && ri.BalkaEnd.IsRack && inRange(ri.BalkaEnd.AngleHorisont, 90))
						{
							// проверяем начало что оно без выноса
							//берем соседнюю стойку
							//ri.BalkaEnd - это ригель по соседству с которым проверяем выносы у стойки
							Balka b = ri.BalkaStart.BalkaStart.Guid != ri.Guid ? ri.BalkaStart.BalkaStart : ri.BalkaStart.BalkaEnd;
							if (b is null || !(b is Impost))
								continue;
							Impost rail = (Impost)b;

							if (rail.RailsList.Count > 0 && rail.RailsList[0].Guid == ri.BalkaEnd.Guid && rail.RailPositionListDoubleInterface[0] > 0.05)
							{
								BadRack.Add(ri.Tag3);
								continue;
							}
							else if (rail.RailsList.Count > 0  && rail.RailsList[rail.RailsList.Count() - 1].Guid == ri.BalkaEnd.Guid && rail.Lenght - rail.RailPositionListDoubleInterface[rail.RailsList.Count() - 1] > 0.05)
							{
								BadRack.Add(ri.Tag3);
								continue;
							}
						}
						#endregion
					}
				}
				*/
                #endregion

                #region Средние стойки (импост)
                foreach (Impost im in model.ImpostList)
                {

                    if (im.IsRack)
                    {
                        #region Проверяем конец 1
                        if (im.BalkaStart != null && im.BalkaStart.IsRack && inRange(im.BalkaStart.AngleHorisont, 90))
                        {
                            //проверяем конец что он без выносов
                            //im.BalkaEnd1 и im.BalkaEnd2 должны быть в RailList скраю
                            if ((im.RailsList.Count > 0 && im.RailsList[im.RailsList.Count() - 1].Guid == im.BalkaEnd2.Guid && im.LengthInterfaceCalc - im.RailPositionListDoubleInterface[im.RailsList.Count() - 1] > 1)
                                ||
                                (im.RailsList2.Count > 0 && im.RailsList2[im.RailsList.Count() - 1].Guid == im.BalkaEnd1.Guid && im.LengthInterfaceCalc - im.RailPositionListDouble2Interface[im.RailsList.Count() - 1] > 1))
                            {
                                BadRack.Add(im.Tag3 + " id=" + im.ID);
                            }

                        }
                        #endregion

                        #region Проверяем конец 2
                        if (im.BalkaEnd != null && im.BalkaEnd.IsRack && inRange(im.BalkaEnd.AngleHorisont, 90))
                        {
                            // проверяем начало что оно без выноса
                            //im.BalkaStart1 и im.BalkaStart2 должны быть в RailList скраю
                            if ((im.RailsList.Count > 0 && im.RailsList[0].Guid == im.BalkaStart2.Guid && im.RailPositionListDoubleInterface[0] > 1.0)
                                ||
                                (im.RailsList2.Count > 0 && im.RailsList2[0].Guid == im.BalkaStart1.Guid && im.RailPositionListDouble2Interface[0] > 1.0))
                            {
                                BadRack.Add(im.Tag3 + " id=" + im.ID);
                            }
                        }
                        #endregion
                    }
                }
                #endregion

            }
            if (BadRack.Count > 0)
            {
                string rails = string.Join(",", BadRack.Distinct().ToArray());
                Order.AddErrorUnical(drOI.idorderitem, "o1444", "", "Стыкованные стойки: " + rails + " не должны быть с выносом (сбоку от начала и конца стоек должны быть ригель) !");
            }
            #endregion
        }

        #region DEV-116839. Подсчет времени выполнения скрипта
        int idPerfomanceLog = 0;
        private void StartStopExecutionTimeCounter(bool isStart, string param)
        {
            try
            {
                if (isStart)
                {
                    DataTable tbl = new DataTable();
                    string sql = @"DECLARE @id int
					EXEC dbo.Start_my_perfomancelog2 70, '" + param + @"', @id OUT
					SELECT @id as id";

                    Atechnology.DBConnections2.dbconn _db = new Atechnology.DBConnections2.dbconn();
                    _db.command.CommandText = sql;
                    _db.OpenDB();
                    _db.adapter.Fill(tbl);
                    _db.CloseDB();

                    DataRow[] dr = tbl.Select();

                    foreach (DataRow d in dr)
                    {
                        idPerfomanceLog = Useful.GetInt32(d["id"], 0);
                    }
                }
                else
                {
                    if (idPerfomanceLog == 0) return;
                    //if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show("Старт");

                    //	if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show("Перед вставкой");
                    string sql = @"EXEC dbo.End_my_perfomancelog " + idPerfomanceLog.ToString();

                    Atechnology.DBConnections2.dbconn _db = new Atechnology.DBConnections2.dbconn();
                    _db.command.CommandText = sql;
                    _db.OpenDB();
                    _db.command.ExecuteNonQuery();
                    _db.CloseDB();
                    //if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show("после вставки");
                }

            }
            catch (Exception e) { if (Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(e.ToString()); }
        }
        private void SetAdditionalLogs(string param)
        {
            try
            {
                if (idPerfomanceLog == 0) return;
                if (Atechnology.ecad.Settings.idpeople != 8234) return;
                string sql = @"if(exists(select top 1 1  FROM my_perfomancelog mp where mp.idPerfomancelog = " + idPerfomanceLog + @"))
                            BEGIN
                                UPDATE my_perfomancelog set param = '" + param + @"' where idPerfomancelog = " + idPerfomanceLog + @"
                            END";
                Atechnology.DBConnections2.dbconn _db = new Atechnology.DBConnections2.dbconn();
                _db.command.CommandText = sql;
                _db.OpenDB();
                _db.command.ExecuteNonQuery();
                _db.CloseDB();
            }
            catch (Exception e)
            {
                if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(e.ToString());
            }
        }
        #endregion
    }

    public class Dis
    {
        public int id;
        public string idd;
    }
    public class MyMPC
    {
        public bool LeftSide { get; set; }
        public bool OneLevel { get; set; }
        public ModelPartClass MPC { get; set; }
    }


    public class MyOper
    {
        public int Qu { get; set; }

        public string Marking { get; set; }

    }
}