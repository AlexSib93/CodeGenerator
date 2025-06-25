internal class WdScripts
{
	public static string ModelSerialize = @"using System;
using System.Xml;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Atechnology.DBConnections2;
using Atechnology.winDraw.Model;
using Atechnology.winDraw;
using Atechnology.Components;
using Atechnology.ecad.Document.DataSets;
using Atechnology.ecad.Document.Classes;
using Atechnology.ecad.Dictionary;
using Atechnology.ecad.Dictionary.Classes;
using Atechnology.ecad.Dictionary.DataSets;

namespace Atechnology.ecad.Calc
{

	public class RunCalc
	{
		public DBConnections2.dbconn db;
		bool bIsT=false;
		OrderClass Order = null;
		int idorderitem;
		ds_order.orderitemRow drOI;
		DataTable glass_table;

		public RunCalc(){}
  
		//Стартовый метод
		public void Run(DBConnections2.dbconn _db,DataRow dr, Construction model){
			string Err=""1"";
			try
			{
				if(model==null)
					return;
			
				db = _db;
				DataSet ds = dr.Table.DataSet;				
				idorderitem=Convert.ToInt32(dr[""idorderitem""]);
				drOI=(ds_order.orderitemRow)dr;
				Err=""2"";
				bIsT=(bool)CalcProcessor.Modules[""GetT""](new object[]{model})[0];
				int LastIdApdexLog1 = (int)CalcProcessor.Modules[""StartApdexLog""](new object[] { 129, Atechnology.ecad.Settings.People.idpeople, ""idorder = "" + drOI.idorder.ToString(), Useful.GetInt32(drOI.idorder, 0) })[0];
				int idPerfomanceLog = 0;
				StartStopExecutionTimeCounter(true, ref idPerfomanceLog, ""idorder: "" + drOI.idorder +"" idorderitem: "" + drOI.idorderitem + "" idpeople: "" + Atechnology.ecad.Settings.idpeople);
				// Отрисовка изделия в построителе (со стороны улицы)
				bool isOutsideDrawing = false;
				
				if(inRange(drOI.idconstructiontype,2,3,6,7,21,35,36))
				{
					foreach(Glass gl in model.GlassList)
					{
						if(gl.ModelPart != null && gl.ModelPart == ModelPart.Stvorka)
						{
							Stvorka s = gl.ModelItem as Stvorka;
							
							if((s.Width == gl.Width || s.Height == gl.Height)/*&& !drOI.IsidproductiontypeNull()&& !inRange(drOI.idproductiontype, 106, 108, 113, 114, 1453, 1477, 1479, 1480, 1481, 1482, 2029,2269)*/)
							{

								Order.AddErrorUnical(drOI.idorderitem, ""o377"", """", drOI.idorderitem.ToString() + ""___Ошибка, размер заполнения совпадает с размером родительской конструкции."");
							}
						}
					}
				}
				
				
				
				
				
				ErrStvorkaSize(drOI,model);
				
				// Отрисовка со стороны улицы у Витражей, у Дверь входная открывание наружу, у Створки Т.
				isOutsideDrawing = !drOI.IsidconstructiontypeNull() && (drOI.idconstructiontype == 7 || drOI.idconstructiontype == 38|| drOI.idconstructiontype == 36)
					|| bIsT;
							
				glass_table=CalcProcessor.Modules[""GetTable""](new object[]{""glass""})[0] as DataTable;
				bool isShortConnect = false;
				bool isPorog = false;
				
				if( 1==0 && inRange( Atechnology.ecad.Settings.idpeople, 2214, 168, 889, 3404, 6970, 3410 ) )
				{
					AddFinParam576(drOI, model);
				}
				
				if(true)
				{
					AddFinParam637(drOI, model);
				}
				
				foreach(RamaItem ri in model.Rama)
				{
					if(ri.RamaType == RamaType.Porog)
						isPorog = true;
				}
				
				if(!isPorog)
				{
					foreach(RamaItem ri in model.Rama)
					{
						if(ri.Connect1 == SoedType.Korotkoe || ri.Connect2 == SoedType.Korotkoe )
						{
							isShortConnect = true;
							break;
						}
					}
				}
				if(isShortConnect)
				{
					//MessageBox.Show(""Короткое соединение"");
					drOI.AddFinparam(461,1,1);
				}
				
				string stvHandlePos = """";
				
				
				if(inRange(drOI.idproductiontype, 903,1850,1852,1470,1900))
				{
					if(model.GetUserParam(""Ширина наличника, мм"").StrValue.ToLower().Contains(""нестанд""))
					{
						drOI.AddFinparam(534,1,1);
					}
				}
				

				if(!drOI.IsidconstructiontypeNull() 
					&& model.ConstructionType.Name != ""Створка"" 
					&& !model.ConstructionType.Name.Contains(""Москитная сетка"") 
					&& model.StvorkaList.Count > 0
					&& !model.FurnitureSystem.ToLower().Contains(""без""))
				{
					string stv_Handle_Name = """";
					
					foreach(Stvorka s in model.StvorkaList)
					{
						if(model.ProfileSystem.ToLower().Contains(""inici"") || model.ProfileSystem.ToLower().Contains(""татп""))
						{
							stvHandlePos += ""С-"" + (s.ID+1) + "":"" + (s.HandlePosition).ToString() + "";"";
						}
						else
						{
							stvHandlePos += ""С-"" + (s.ID+1) + "":"" + s.HandlePosition + "";"";
						}
						
						if( inRange( drOI.idconstructiontype, 2, 3 ) ) stv_Handle_Name = s.GetUserParam( 424 ).StrValue; // Ручка оконная
					}
					if(stvHandlePos != """")
					{
						drOI.AddFinparam(109,1,1).strvalue = stvHandlePos;						
					}
					if( stv_Handle_Name != """" )
					{
						drOI.AddFinparam(685,1,1).strvalue = stv_Handle_Name;
					}
				}
				
				
				bool isStvErrConn = false;
				foreach(Stvorka s in model.StvorkaList)
				{
					foreach(StvorkaItem si in s)
					{
						if(string.IsNullOrEmpty(si.VariantsPrim))
						{
							Order.AddError(drOI.idorderitem,""о501"","""");
							isStvErrConn = true;
							break;
						}
					}
					if(isStvErrConn) break;
				}
				
				string finparamStrValue = isOutsideDrawing ? ""outside"" : ""inside"";
				
				drOI.AddFinparam(412).strvalue = finparamStrValue;
				
				Err=""3"";
				string strColorRamaOut=bIsT?model.ColorIn:model.ColorOut;
				string strColorRamaIn=bIsT?model.ColorOut:model.ColorIn;
				Err=""4"";
				
				ds_order.finparamcalcRow fpr = drOI.AddFinparam( 65,(decimal)model.Rama.WidthDouble,(decimal)model.Width);
				fpr.smbase4=model.Width;
				
				ds_order.finparamcalcRow fpr66 = (model.SoedinitelList.Count > 0)
					? drOI.AddFinparam(66,(decimal)model.Rama.Height,(decimal)model.Rama.Height)
					: drOI.AddFinparam(66,(decimal)model.Rama.Height,(decimal)model.Height);
				
				if(model != null &&  !drOI.IsidconstructiontypeNull() &&  inRange(drOI.idconstructiontype,2,3,6,7,21,35,36,42,13,38,39)) 
				{
					fpr.strvalue = getSoedThick(model);	
					fpr66.strvalue = model.GetUserParam(""Толщина армирования"").StrValue;
					drOI.AddFinparam(477, getThickStvWithRama(model), getThickStvWithRama(model));
					
					fpr66.smbase4=(decimal)model.Height;
				}	

				Err=""5. drOI.name="" + drOI.name + "", drOI.idoi="" + drOI.idorderitem;
				
				//if(Atechnology.ecad.Settings.idpeople == 1896)
				//{
				if(drOI.GetFinparam(433) != null){
					string ss = model.GetUserParam(""Цвет москитной сетки"").StrValue + "","" + model.GetUserParam(""Тип москитной сетки"").StrValue;
					drOI.AddFinparam(433).strvalue = ss;					
				}
				//}
				
				if(model.ConstructionType.Name==""Створка"")
				{
					var profSys = new string[] { ""Inicial IP45"", ""Татпроф СОКОЛ 40"", ""Inicial IW63"", ""Inicial IW70"" };
					foreach(Stvorka s in model.StvorkaList)
					{
						s.ID=Useful.GetInt32((dr[""winue3""]));//Useful.GetInt32(model.CalcVariables[""Id""]);
						if(s.HandlePosition>0 && s.ShtulpExist != ShtulpExist.Exist)
						{
							
							
							if((model.ProfileSystem == ""Inicial IW63"" || model.ProfileSystem == ""Inicial IW70"")
								&& s.GetUserParam(""Замок"").Visible && s.GetUserParam(""Замок"").StrValue == ""Многозапорный"")
							{
								drOI.AddFinparam(109,s.HandlePosition,s.HandlePosition - 20).strvalue = s.HandlePositionType.ToString();
							}
							else
							{
								drOI.AddFinparam(109,s.HandlePosition,s.HandlePosition - 20);
							}
							//Так сказал Паньков
							if(profSys.Contains(model.ProfileSystem) && model.FurnitureSystem == ""Фурнитура дверная"")
							{
								//drOI.AddFinparam(109,1005,s.HandlePosition - 20);
							}
							try
							{
								if (drOI.GetFinparam(109) != null
									&& profSys.Contains(model.ProfileSystem)
									&& s.GetUserParam(""Второй замок"").StrValue != ""Без замка"")
									drOI.GetFinparam(109).smbase2 = s.HandlePosition - 300;
							}
							finally { }
							//drOI.AddFinparam(109,s.HandlePosition,(decimal)(s.HandlePosition - s.StvorkaHandle.E));
						}
						drOI.AddFinparam(141,1,1).strvalue=bIsT.ToString();
					}
					drOI.weight = getOIWeight( model );
				}
				Err=""5.0.1"";
				//Сохраняем толщину стеклопакета
				if(model.ConstructionType.Name==""Стеклопакет""
					||model.ConstructionType.Name==""Стекло""
					||model.ConstructionType.Name==""Сэндвич""
					)
				{
					foreach(Glass g in model.GlassList){
						dr[""winue3""]=g.Thickness;
						break;
					}
				}
				Err=""5.0.2"";

				//Сохраняем камерность стеклопакета
				if(model.ConstructionType.Name==""Стеклопакет""||model.ConstructionType.Name==""Стекло"")
				{
					foreach(Glass g in model.GlassList)
					{
						if( g.Camernost > 0 )
						{
//							if(Atechnology.ecad.Settings.idpeople == 1863)
//							{
//								MessageBox.Show(""g.Camernost = "" + g.Camernost + "" marking = "" + g.Marking);
//							}
							drOI.AddFinparam(61,g.Camernost,g.Camernost);
							if(Atechnology.ecad.Settings.idpeople == 2214)
							{
								drOI.AddFinparam(61).smbase2 = (decimal)get_Heatresistance(g, glass_table);
							}
							break;
						}
					}
				}
				
				
				Err=""5.1"";
				//ИД балок створки
				//MessageBox.Show(""model.CalcVariables=""+model.CalcVariables.Count,model.ConstructionType.Name);
				if(model.CalcVariables.ContainsKey(""IdLeafBeems""))
				{
					//Ключи балок
					//MessageBox.Show(""=""+model.CalcVariables[""IdLeafBeems""]);
					string[] Ids=model.CalcVariables[""IdLeafBeems""].Split(',');
					int i=0;
					foreach(Stvorka stv in model.StvorkaList){
						foreach(StvorkaItem si in stv){
							si.ID=Convert.ToInt32(Ids[i++]);
						}
					}
				}
				Err=""5.2."";
				//Заполнение
				if(model!= null && model.ConstructionType != null && drOI!= null && 
					( model.ConstructionType.Name==""Стеклопакет""
					||model.ConstructionType.Name==""Сэндвич""
					||model.ConstructionType.Name==""Стекло""
					)
					)
				{
					Err=""5.2.A"";
					if(drOI.part==""Конструкции"")
					{
						drOI.part=""Г-1"";
					}
					Err=""5.2.B"";
					foreach(Glass g in model.GlassList)
					{
						g.Part=drOI.part;
					}
				}
				Err=""5.2.1"";
				//Ошибки построителя!!!
				if(drOI.IshideNull()||drOI.hide==false)
				{
					foreach(string ErrCode in model.CalcVariables.Keys){
						if(ErrCode.Contains(""о"")||ErrCode.Contains(""и"")){
							if (Order == null)
								Order = (OrderClass)dr.Table.DataSet.ExtendedProperties[""DocClass""];
							Order.AddErrorUnical(idorderitem,ErrCode,"""",model.CalcVariables[ErrCode]);
						}
					}
				}
			
				Err=""5.2.2"";

				#region Расчет вкючения в пирамидный план для продукций
				if(model.ProfileSystem==""Provedal C640"")
				{
					if(model.ConstructionType.Name==""Створка"")
					{
						drOI[""addnum1""]=1;
					}
					else
					{
						drOI[""addnum1""]=0;
					}
				}
				#endregion
				

				Err=""5.2.3"";

				#region Родительская конструкция для створки
				if(model != null && drOI != null && model.ConstructionType.Name==""Створка""
					&&(drOI.idproductiontype==112 )
					)
				{
					Err=""5.2.3.1"";
					//Принадлежность пакета изделию СТ или НСТ
					if(drOI.IsparentidNull()){
						Err=""5.2.3.1.0"";

						drOI[""addstr""]=DBNull.Value;
					}
					else{
						if (Order == null)
							Order = (OrderClass)dr.Table.DataSet.ExtendedProperties[""DocClass""];
						Err=""5.2.3.2. Order="" + Order.DocRow.name;
						ds_order.orderitemRow drOIParent=Order.ds.orderitem.FindByidorderitem(drOI.parentid);
						Err=""5.2.3.2.1Ф"";
						if(drOIParent != null && !drOIParent.IsidpowerNull())
						{
							Err=""5.2.3.3"";			
							
							drOI[""addstr""]=drOIParent.idpower;
						}
					}
				}
				#endregion
				Err=""5.2.4"";
			
				#region Добавление фин. параметра створки в ствроке
				foreach(Stvorka s in model.StvorkaList)
				{
					if(s.ParentStvorka != null)
					{
						foreach (ds_order.orderitemRow drOIS in Order.ds.orderitem.Select(""idorder = "" + Order.DocRow.idorder 
							+ "" and part = 'С-"" + (s.ID + 1) + ""'""))
						{
							drOIS.AddFinparam(490,1,1);
						}
					}
				}
				#endregion Добавление фин. параметра створки в ствроке
				Err=""5.2.5"";
				bool needParam = false;
				if(/*( model.ProfileSystem == ""Rehau Blitz"" 
					|| model.ProfileSystem == ""Rehau Delight""
					|| model.ProfileSystem == ""Rehau Grazio""
					|| model.ProfileSystem == ""Exprof Profecta 70mm""
					|| model.ProfileSystem == ""KBE Эксперт 70""
					|| model.ProfileSystem == ""KBE 76"") */
					inRange( model.ProfileSystem, ""KBE 76"", ""KBE Эксперт 70"",  ""Rehau Grazio"" /*, ""Exprof Profecta 70mm"", ""KBE Эксперт 70"", ""KBE 76""*/ )					
					&& inRange(model.FurnitureSystem, ""Фурнитура Roto NT"",""Фурнитура Maco MM""))
				{
					DataTable dtGlassGroup = CalcProcessor.Modules[""GetTable""](new object[]{""glass_group""})[0] as DataTable;
					foreach(Glass g in model.GlassList)
					{
						DataRow [] drs = dtGlassGroup.Select(""idglass = "" + g.IDGlass);
						if(drs.Length > 0)
						{
							if(drs[0][""name""].ToString().ToLower().Contains(""control""))
							{
								needParam = true;
								break;
							}
						}
					}
				}
				if(needParam)
				{
					drOI.AddFinparam(492,1,1);
				}
				Err=""5.2.6"";
				if(model.ConstructionType.ID == 39 && model.ProfileSystem == ""Inicial IP45"")
				{
					Err=""5.2.6.1"";
					
					if(model.StvorkaList.Count > 0 && model.StvorkaList.Any(x=>x.FurnitureSystem == ""Фурнитура СТН для алюминиевых окон""))
					{
						
						if (Order == null)
						{
							Order = (OrderClass)dr.Table.DataSet.ExtendedProperties[""DocClass""];
						}
						Err=""5.2.6.2 = "" + drOI.idorderitem + "" "" + drOI.numpos;
						Order.AddErrorUnical(drOI.idorderitem, ""и1020"", """", ""Внимание! Необходимо проверить сбор/разбор конструкции!"");
						Err=""5.2.6.3 = "" + drOI.idorderitem + "" "" + drOI.numpos;
						
					}
				}
				Err = ""5.2.7"";
				if(model.ProfileSystem == ""Provedal C640, P400"" && model.ConstructionType.ID != 12)
				{
					DataRow []drOrdErr = ds.Tables[""ordererror""].Select(""error_code = 'о1021'"");
					if(drOrdErr.Length == 0)
					{
						foreach(Glass g in model.GlassList)
						{
							if(g.Thickness == 24)
							{
								if(!inRange(g.Marking, ""Вентрешетка/Ламели 13 07 45"", ""Вентрешетка/Ламели 15 02 10"", ""Вентрешетка_МП_3013""))
								{
									if (Order == null)
									{
										Order = (OrderClass)dr.Table.DataSet.ExtendedProperties[""DocClass""];
									}
									Order.AddError(drOI.idorderitem, ""о1021"", """", ""Ошибка! В систему Provedal С640, Р400 нельзя строить[""+g.Marking+""] СП 24 мм!!"");
									break;
								}
							}
						}
					}
				}
				
				//if(Atechnology.ecad.Settings.idpeople == 1896)
					ArmImpostSide(drOI, model);
			CalcProcessor.Modules[""EndApdexLog""](new object[] { LastIdApdexLog1 });		
			StartStopExecutionTimeCounter(false, ref idPerfomanceLog, ""idorder: "" + drOI.idorder +"" idorderitem: "" + drOI.idorderitem + "" idpeople: "" + Atechnology.ecad.Settings.idpeople);
			}
			catch(Exception e)
			{
				if (Order == null)
					Order = (OrderClass)dr.Table.DataSet.ExtendedProperties[""DocClass""];
				Order.AddErrorUnical(idorderitem,""о002"","""",""Ошибка скрипта .. Сериализация модели:\r\n""+e.Message+""\r\n""+e.TargetSite.ToString()+"" \r\n""+e.StackTrace+""\r\nТочка:""+Err);
			}
		}
		
		public string getSoedThick(Construction model) //Формирует строку с количеством саморезов, в зависимости от толщины расширителя
		{
			string str = """";
			
			decimal len30_45 = 0;
			decimal len60_90 = 0;
			decimal len90 = 0;
			decimal len4 = 0;
								
								
			foreach( Soedinitel soed in model.SoedinitelList )
			{
				if(soed.ConnSoedinitel == null)
				{
					if(soed.A >= 30 && soed.A <= 45)
					{
						len30_45 += soed.Lenght;	
					}
					else if(soed.A >= 60 && soed.A < 90)
					{
						len60_90 +=soed.Lenght;	
					}
					else if(soed.A >= 90)
					{
						len90 += soed.Lenght;	
					}
				}
			}
		
			len4 = (model.LenghtFrame -(len30_45 + len60_90 + len90))/1000;//Периметр консрукции - длина расширителей
			len30_45 = len30_45 / 1000;
			len60_90 = len60_90 / 1000;
			len90 = len90 / 1000;

			str =  len30_45 + "":"" + len60_90 + "":"" + len90 + "":"" + len4;

			return str;
		}
		
		public decimal getThickStvWithRama(Construction model) //вычисляет суммарную длину примыкания створок с рамой (импосты не считаем, створку в створке не считаем)
		{
			decimal LenStv = 0;
			
			foreach (Stvorka stv in model.StvorkaList)
			{
				foreach(StvorkaItem si in stv)
				{					
					if(si.RamaItem == null || si.Marking==(""Без створки""))
						continue;
					LenStv +=  si.LenghtC;
				}
			}
			

			return LenStv/1000;
		}
		
		public int roundToMax(decimal x)
		{
			if( x > Convert.ToDecimal(Math.Truncate(x) ) ) { return Convert.ToInt32(Math.Truncate(x) + 1); } else { return Convert.ToInt32(Math.Truncate(x)); }
		}
		public bool inRange( int val, params int[] compare )
		{
			bool res = false;
			foreach( int a in compare )
			{
				res = a == val;
				if( res ) break;
			}
			return res;
		}
		public bool inRange( string val, params string[] compare )
		{
			bool res = false;
			foreach( string a in compare )
			{
				res = a == val;
				if( res ) break;
			}
			return res;
		}
		public decimal getOIWeight( Construction Model )
		{
			decimal res = 0;
			
			if( Model == null || Model.StvorkaList.Count == 0 || Model.ConstructionType.ID != 12 ) return res; // Это створка ? Нет модели или створок или это ПФ = 0 - выход
			
			foreach( Stvorka l in Model.StvorkaList )
			{
				UserParam up = null;
				foreach( UserParam up_ in l.UserParamList )
				{
					if( up_.Name==""Вес створки"" )
					{
						up = up_; break;
					}
				}
				
				res = (decimal) up.IntValue;
				//MessageBox.Show( drOI.name + "", "" + drOI.weight.ToString() );
				/*
					try
					{
						decimal S_weightmm = 2.5M; // Вес 1мм стекла размером 1х1м
						decimal SEND_weightmm = 0.1625M; // Вес 1мм сэндвича размером 1х1м
						decimal sumleafweight = 0;
					
						// Взвешиваем заполнения
						foreach( Glass r in Model.GlassList )
						{
						r.GetElementList(
							if( r.ModelPart == ModelPart.Stvorka )
							{
								if( r.FillType == Atechnology.winDraw.Model.FillType.GlassPack )
								{
									foreach( clsFillElement e in r.FillElements )
									{
										if( e.ElementType == FillElementType.Glass )
										{
											sumleafweight += S_weightmm * (decimal)e.Thickness * (decimal)r.Width(4) * (decimal)r.Height(4) / 1000000M;
										}
									}
								}
								if( r.Fill.FillType == Atechnology.winDraw.Model.FillType.Sandwich )
								{
									sumleafweight += SEND_weightmm * (decimal)r.Fill.Thikness * (decimal)r.Width(4) * (decimal)r.Height(4) / 1000000M;
								}
							}
						}
						// Взвешиваем балки створки
						foreach( clsLeafBeem lb in l )
						{
							sumleafweight += (decimal)lb.Lenght * ( (decimal)lb.Profile.profile.Width / 1000M ) / 1000M;
						}
						// Взвешиваем импосты
						foreach( clsImpost i in l.Imposts )
						{
							sumleafweight += (decimal)i.Lenght * ( (decimal)i.Profile.profile.Width / 1000M ) / 1000M;
						}
						// Взвешиваем импосты через рефлексию
						try
						{

							clsImpost shtulp = l.GetType().GetField(""ShtulpBinding"", BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance).GetValue(l) as clsImpost;
							if( shtulp != null ) 
							{
								//MessageBox.Show( shtulp.Lenght.ToString() );
								sumleafweight += (decimal)shtulp.Lenght * ( (decimal)shtulp.Profile.profile.Width / 1000M ) / 1000M;
							}
						}
						catch( Exception E )
						{
						}
						// Присваиваем вес пользовательскому параметру ""Вес створки""
						//					MessageBox.Show( sumleafweight.ToString() );
						clp.NumericValue = (double)sumleafweight;
						clp.StringValue = String.Format(""{0:####.#}"",sumleafweight).PadLeft(6,'0');
						//clp.StringValue = sumleafweight.ToString();
					}
					catch( Exception E )
					{
					
					}*/
			}
			return res;
		}
		
		double get_Heatresistance(Glass gl, DataTable glass_table)
		{
			double heatresistance = 0;
			string elem = """";
			string el = """";
			foreach(var e in gl.Marking.Split('-'))
			{
				if (e.IndexOf('[')!=-1)
					el=e.Substring(0,e.IndexOf('['));
				else el = e;
				elem += elem !="""" ? ""-"" + el : el;
			}
			
			if(glass_table.Select(""marking = '"" + elem +""' AND deleted IS NULL"").Length > 0)
				heatresistance = Useful.GetDouble(glass_table.Select(""marking = '"" + elem +""' AND deleted IS NULL"")[0][""heatresistance""]);
			
			return heatresistance;
		}
		
		void AddFinParam576(ds_order.orderitemRow drOI, Construction model)
		{
			if( drOI != null && !drOI.IsidpowerNull() && inRange( drOI.idpower, 3,4,5,66 ) && model.ColorIn != ""Белый"" || model.ColorOut != ""Белый"")
			{
				drOI.AddFinparam(576, 1, 1).strvalue = model.GetUserParam(""Ламинация"").StrValue;
			}
		}
		
		void AddFinParam637(ds_order.orderitemRow drOI, Construction model)
		{
			if(model.ProfileSystem == ""Татпроф МП-45"" || model.ProfileSystem == ""Татпроф СОКОЛ 40"" || model.ProfileSystem == ""Inicial IP45"")
			{
				if(model.ImpostList.Any(imp => imp.IsRack && imp.StvorkaList.Count >= 2))
				{
					drOI.AddFinparam(637,1,1);
				}
				if(model.ImpostList.Any(imp => imp.IsRack && imp.StvorkaList.Count >= 1 && (imp.Connect1 == SoedType.Korotkoe || imp.Connect2 == SoedType.Korotkoe)))
				{
					drOI.AddFinparam(637,1,1);
				}
			}
			if(model.ProfileSystem == ""Inicial City Pro"" || model.ProfileSystem == ""Сокол МП-640"")
			{
				drOI.AddFinparam(637,1,1);
			}
		}
		
		void ArmImpostSide(ds_order.orderitemRow drOI, Construction model)
		{
			string Ret = """";
			string Err = ""1"";
			try
			{
				Err = ""1"";
				int imp = 0;
				Atechnology.ecad.Document.DataSets.ds_order.finparamcalcRow row = null;
				foreach (var im in model.ImpostList)
				{
					bool ArmLeft = false;
					bool ArmRight = false;
					Err = ""2"";

					// Слева
					foreach (ModelPartClass mpc in im.PartTypeList)
					{
						if (mpc.ModelPart == ModelPart.Stvorka)
						{
							ArmLeft = true;
							break;
						}
					}

					// Слева
					foreach (ModelPartClass mpc in im.PartTypeList2)
					{
						if (mpc.ModelPart == ModelPart.Stvorka)
						{
							ArmRight = true;
							break;
						}
					}

					if (ArmLeft && !ArmRight)
					{
						Ret = ""НИЗ_АРМ"";//	НИЗ_АРМ			
					}
					if (!ArmLeft && ArmRight)
					{
						Ret = ""ВЕРХ_АРМ"";//		ВЕРХ_АРМ			
					}
					if ((!ArmLeft && !ArmRight))
					{
						Ret = ""НИЗ_АРМ!"";//	НИЗ_АРМ!			
					}
					if ((ArmLeft && ArmRight))
					{
						Ret = ""АРМ"";
					}
					Ret+= GetImpostConnectionBeam(im);
					
					if (row == null)
						row = drOI.AddFinparam(651, im.ID, im.ID);

					if (imp == im.ID)
					{
						row.sm = im.ID;
						row.strvalue = Ret;
					}
					else
					{
						row = row.DoublicateRow();
						row.sm = im.ID;
						row.strvalue = Ret;
					}
				}
			}
			catch (Exception e)
			{
				if(Atechnology.ecad.Settings.idpeople==8818)
				{
					MessageBox.Show(e.Message);
				}
			}
		}
		
		string GetImpostConnectionBeam(Impost imp)
		{
			var start = imp.BalkaStartType;
			var end = imp.BalkaEndType;
			var letterData = """";
			if (start == ModelPart.RamaItem || end == ModelPart.RamaItem || start == ModelPart.Impost || end == ModelPart.Impost)
			{
				letterData = "" Р"";
			}
			else if (start == ModelPart.Stvorka || end == ModelPart.StvorkaItem || end == ModelPart.Stvorka || end == ModelPart.StvorkaItem)
			{
				letterData = "" С"";
			}
			return letterData;
		}
		
		void ErrStvorkaSize(ds_order.orderitemRow drOI, Construction model)
		{
			if(drOI.idconstructiontype == 12)
			{
				if(drOI.width != model.Width || drOI.height != model.Height)
				{
					Order.AddError(drOI.idorderitem, ""о002"", """", ""Ошибка размер створки не совпадает с размером полуфабриката!"");
				}
			}
		}
	
		#region DEV-116839. Подсчет времени выполнения скрипта
		private void StartStopExecutionTimeCounter(bool isStart,ref int idPerfomanceLog, string param)
		{
			try
			{
				if(isStart)
				{
					DataTable tbl = new DataTable();
					string sql = @""DECLARE @id int
						EXEC dbo.Start_my_perfomancelog2 4, '""+param+@""', @id OUT
						SELECT @id as id"";
					
					DBConnections2.dbconn _db = new DBConnections2.dbconn(); 
					_db.command.CommandText = sql;
					_db.OpenDB();
					_db.adapter.Fill(tbl);
					_db.CloseDB();
					
					DataRow[] dr = tbl.Select();			
			      
					foreach (DataRow d in dr)
					{
						idPerfomanceLog = Useful.GetInt32(d[""id""], 0);
					}
				}
				else
				{
					if(idPerfomanceLog == 0) return; 
					//if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(""Старт"");
				
					//	if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(""Перед вставкой"");
					string sql = @""EXEC dbo.End_my_perfomancelog "" + idPerfomanceLog.ToString();
					
					DBConnections2.dbconn _db = new DBConnections2.dbconn(); 
					_db.command.CommandText = sql;
					_db.OpenDB();
					_db.command.ExecuteNonQuery();
					_db.CloseDB();
					//if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(""после вставки"");
				}
				
			}
			catch (Exception e){if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(e.ToString());}
		}
		#endregion
	} 
}
";

    public static string CalcConstructionsWorks = @"using System;
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
using AtLog=Atechnology.Logging.Impl.Log;
using System.Linq;

namespace Atechnology.ecad.Calc
{
	public class FalshData
	{
		public string glasses;
		public string marking;
		public string sides;
		public string colorout;
		public string colorin;
		
		public string GetString()
		{
			return ""Фальш: "" + marking + "", Стороны: "" + sides + "", Заполнения: "" + glasses + (colorout!=""""?("", Цвет внеш: "" + colorout):"""") + (colorin!=""""?("", Цвет внутр: "" + colorin):"""");
		}
		
		public string GetColorOut()
		{
			return glasses + "", "" + (colorout!=""""?(colorout):"""");
		}
		
		public string GetColorIn()
		{
			return glasses + "", "" + (colorin!=""""?(colorin):"""");
		}		
		
		public bool exOutColor()
		{
			return colorout != """";
		}
		public bool exInColor()
		{
			return colorin != """";
		}
	}
	public class RunCalc
	{
		#region Variables
		
		public DBConnections2.dbconn db;
		OrderClass Order;
		ds_order.orderitemRow drOI;
		ds_productiontype.productiontypeRow drPT;
		string sLog = ""Скрипт Расчета работ и операций: "";
		Construction model;
		
		DataTable t_alu_dobor;
		DataTable t_alu_dobor_rama;
		DataTable table_workoper;
		
		#endregion
		
		public void AddOrUpdateFalsh( string glass, string marking, string sides, string colorout, string colorin, List<FalshData> fd )
		{
			FalshData f = fd.Find( x=>x.marking==marking && x.sides == sides && x.colorout == colorout && x.colorin == colorin );
			if( f != null )
			{
				f.glasses += "", "" + glass;
			}
			else
			{
				f = new FalshData();
				f.glasses = glass;
				f.marking = marking;
				f.sides = sides;
				f.colorout = colorout;
				f.colorin = colorin;
				fd.Add( f );	
			}
		}

		public RunCalc(){}
		
		public void Run(DBConnections2.dbconn _db,DataRow dr, Construction model)
		{
			//			MessageBox.Show( ""OK"" );
			db = _db;
			DataSet ds = dr.Table.DataSet;
			Order=dr.Table.DataSet.ExtendedProperties[""DocClass""] as OrderClass;
			drOI=(ds_order.orderitemRow)dr;
			ds_productiontype.productiontypeRow drPT = ProductionTypeClass.GetProductionType(drOI.idproductiontype);
			string dtLogs = ""\n start script "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
			string Err=""1"";
			try
			{
				drOI.AddFinparam(69).sm=0;
				if(drOI.IsidproductiontypeNull())
					return;
				if(drOI.idproductiontype == 2172) return;
				int LastIdApdexLog1 = (int)CalcProcessor.Modules[""StartApdexLog""](new object[] { 136, Atechnology.ecad.Settings.People.idpeople, ""idorder = "" + drOI.idorder.ToString(), Useful.GetInt32(drOI.idorder, 0) })[0];

				int idPerfomanceLog = 0;
				if(!drOI.IsidprofsysNull() && !drOI.IsidpowerNull() && !drOI.IsidproductiontypeNull() && !drOI.IsidconstructiontypeNull() && !drOI.Isprofsys_nameNull())
					if(inRange(drOI.idproductiontype, 105, 1191, 1551, 1891, 820, 1644, 1678, 1960, 2074, 247, 1594, 1416, 1694, 1714, 1932, 1976, 2088, 2096, 2101, 2148, 112, 1860, 535, 111, 42, 1720)
						|| inRange( drOI.idpower, 52, 66, 4,5,6, 12,90,125,139 )
						|| inRange( drOI.idprofsys, 144, 129, 113, 156, 186, 122, 160, 188, 139, 215, 208, 222, 244 )
						|| inRange(drOI.idconstructiontype, 38, 13, 39, 107, 6, 7, 35, 36,  55   )
						|| inRange( drOI.profsys_name, ""Inicial IF50 RR"", ""Inicial IF50 R2R"", ""Татпроф МП-50"", ""Татпроф МП-50300"", ""Татпроф TFS50 Стойка-стойка встык"", ""Татпроф TFS50 Стойка-ригель внахлёст"", ""Inicial IW63"", ""Inicial IF50 SSG"", ""Inicial IW70"", ""Татпроф МП-65"", ""Татпроф МП-72"", ""Татпроф МП-72 ТЕРМО"", 
						""Татпроф TWS50"" , ""Татпроф TS-65"", ""Татпроф TS-72"", ""Татпроф TS-72 HI"", ""Inicial IW70D"", ""Inicial IW70D HI"", ""Inicial IW62D"", ""KBE Эксперт 70"", ""Exprof Practica 58mm"", ""Exprof Prowin""  ) )
						StartStopExecutionTimeCounter(true, ref idPerfomanceLog, ""idorder: "" + drOI.idorder + "" idorderitem: "" + drOI.idorderitem + "" idpeople: "" + Atechnology.ecad.Settings.idpeople);
				
				ds_order.orderitemRow rootProduction = getRootProduction( drOI );
                 
				t_alu_dobor = new DataTable(); t_alu_dobor_rama = new DataTable();
				t_alu_dobor = CalcProcessor.Modules[""GetTable""](new object[]{""aludobor""})[0] as DataTable;
				t_alu_dobor_rama = CalcProcessor.Modules[""GetTable""](new object[]{""aludobor_rama""})[0] as DataTable;
				table_workoper = CalcProcessor.Modules[""GetTable""](new object[]{""view_workoper""})[0] as DataTable;
				
				Err=""7"";
				
				if(model!=null && !inRange(drOI.idconstructiontype,6,7))
				{
					UserParam us = model.GetUserParam(""Дренаж"");
					if( us != null )
					{
						if(us.StrValue == ""Дренаж с узкой стороны профиля"")
						{

								Order.AddErrorUnical(drOI.idorderitem,""о1985"");
						}
					}
				}
				
				#region параметр Алюминиевая конструкция отгружается в разборе
				if( ( model != null ) && (inRange(drOI.idconstructiontype,38) || inRange(drOI.idconstructiontype, 13)&& !drOI.IsidprofsysNull() && !inRange(drOI.idprofsys,8)))
				{
					ds_order.finparamcalcRow fpr = drOI.AddFinparam(279);		
				}
				if(model!=null && inRange(drOI.idconstructiontype,38) && inRange(drOI.idprofsys,157, 120, 128, 212, 214))
				{
					UserParam us = model.GetUserParam(""Разбить изделие"");
					if( us != null )
					{
						int count = 0;
						if(us.StrValue == ""Да"")
						{
							count++;
							if(count >0)
							{
								Order.AddErrorUnical(drOI.idorderitem,""и1892"");
							}
						}
					}
				}
				
				// Reshetnikov 20200127 поменял условие
				//if( ( model != null ) && (drOI.idconstructiontype == 39) && (drOI.height > 2500) && (drOI.width > 2500))
				if( ( model != null ) && (drOI.idconstructiontype == 39) &&( (drOI.height > 2500) || (drOI.width > 2500)))					
				{
					ds_order.finparamcalcRow fpr = drOI.AddFinparam(279);		
				}
				
				#endregion параметр Алюминиевая конструкция отгружается в разборе
				
				Err=""8"";
				#region работы фальши
				int quSide = 1;
				if( ( model != null ) && ( drOI.idproductiontype!=107))
				{
					List<FalshData> fff = new List<FalshData>();
					foreach (Glass g in model.GlassList)
					{					
						if(g.Falsh != null)
						{			
							if( g.Falsh.Marking.ToLower().Contains(""фальш"") )
							{
								Order.AddErrorUnical(drOI.idorderitem,""п002"");
							}
							if( g.Falsh.Marking.ToLower().Contains(""g278"" ) && g.Thickness!=40 && !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 96 ) ) // Exprof profecta, 40mm
							{
								Order.AddErrorUnical(drOI.idorderitem,""п003"");
							}
							
							if( g.Falsh != null )
							{
								ds_order.finparamcalcRow f;
						
								f= drOI.AddFinparam( 362, 1, 1 );
								f.strvalue = g.Falsh.Marking;
						
								string sideF = """"; string colorOut = """"; string colorIn = """";
								switch( g.Falsh.Side )
								{
									case FalshSide.DoubleSide: sideF = ""С двух сторон""; colorOut = g.Falsh.ColorOut; colorIn = g.Falsh.ColorIn; break;
									case FalshSide.InSide: sideF = ""С внутренней стороны""; colorIn = g.Falsh.ColorIn; break;
									case FalshSide.OutSide: sideF = ""С внешней стороны""; colorOut = g.Falsh.ColorOut; break;
								}
								f = drOI.AddFinparam( 363, 1, 1 );
								f.strvalue = sideF;
						
								/*
								if( colorOut != """" )
								{
									f = drOI.AddFinparam( 364, 1, 1 );
									f.strvalue = colorOut;
								}
								if( colorIn != """" )
								{
									f = drOI.AddFinparam( 365, 1, 1 );
									f.strvalue = colorIn;
								}
								*/
						
								AddOrUpdateFalsh( g.Part, g.Falsh.Marking, sideF, colorOut, colorIn, fff );
							}

							
							if(g.Falsh.Side == FalshSide.DoubleSide)
							{
								quSide = 2;
							}
							Err=""8.1"";
							foreach(FalshItem fi in g.Falsh)
							{
								
								Err=""8.2"";
								if(fi.AngNakl == 90 || fi.AngNakl == 45|| fi.AngNakl == 0)
								{
									Err=""8.3"";
									//MessageBox.Show(""1"");
									Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
									Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление и установка фальш-переплета"");
									Order.DocWork.AddWorkOperForItem(""Фальш со стандартными углами"",quSide);
								}
								else
								{
									Err=""8.4"";
									//MessageBox.Show(""2"");
									Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
									Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление и установка фальш-переплета"");
									Order.DocWork.AddWorkOperForItem(""Фальш с нестандартными углами"",quSide);
								}
							}
						}
					}
					
					if( /*Atechnology.ecad.Settings.idpeople == 168 && */ fff.Count > 0 )
					{
						string fdata = """"; string coutdata = """"; string cindata = """";
						foreach( FalshData fd in fff )
						{
							
							// MessageBox.Show( fd.GetString() ); 
							fdata += ""\n"" + fd.GetString();
							if( fd.exOutColor() ) coutdata += ( coutdata==""""?"""":""\n"" ) + fd.GetColorOut();
							if( fd.exInColor() ) cindata += ( cindata==""""?"""":""\n"" ) + fd.GetColorIn();
						}
						
						if( coutdata != """" )
						{
							ds_order.finparamcalcRow f = drOI.AddFinparam( 364, 1, 1 );
							f.strvalue = coutdata;
						}
						
						if( cindata != """" )
						{
							ds_order.finparamcalcRow f = drOI.AddFinparam( 365, 1, 1 );
							f.strvalue = cindata;
						}
						
					}
				}
				#endregion работы фальши
				#region Работы ПМС
				if( inRange( drOI.idproductiontype, 105, 1191, 1551, 1891, 2186 ) ) //Москитная сетка
				{
					Err=""19"";
					#region Москитки
					ds_order.finparamcalcRow f; 
					
					bool antiCat = false; bool innerMS = false; bool isAntiDust = false;
					bool isAntiMosh = false; bool isAntiPil = false;
					
					string strMS = """";
					if( model != null )
					{
						UserParam u = model.GetUserParam(""Тип полотна МС"");
						if( u != null )
						{
							antiCat = u.StrValue == ""Полотно Антикошка"" && u.Visible;
							
							isAntiDust = 
								( u.StrValue == ""Полотно Антипыльца"" && u.Visible ) 
								|| 
								( u.StrValue == ""Полотно Антимошка"" && u.Visible );
							isAntiMosh = u.StrValue == ""Полотно Антимошка"" && u.Visible;
							isAntiPil = u.StrValue == ""Полотно Антипыльца"" && u.Visible;
						}
						
						UserParam u2 = model.GetUserParam(""Тип москитной сетки"");
						innerMS = u2 != null && u2.StrValue == ""Вставная в ПВХ"" && u2.Visible; 
					}
				
					/*Расчет в финпараметр 287 в smbase2 типов полотна ПМС */
					int isVidPolotna = 1;
					if(isAntiMosh)
					{
						isVidPolotna = 2;
					}
					if(isAntiPil)
					{
						isVidPolotna = 3;
					}
					if(antiCat)
					{
						isVidPolotna = 4;
					}
					
					#region Расчет работ за каждый импост в МС
					int quMSimp = 0;
					foreach( Impost i in model.ImpostList )
					{
						if( i != null && !i.Marking.ToLower().Contains( ""без"" ) )
						{
							quMSimp ++;
						}
					}

					if( quMSimp > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МС"");
						Order.DocWork.AddWorkOperForItem(""Установка импоста МС"",quMSimp);
					}
					#endregion
					
					Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
					Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МС"");
					
					
					string typeMS_Main = model.GetUserParam(""Тип москитной сетки"").StrValue;
					if( isAntiDust && inRange( typeMS_Main, ""Оконная"", ""Дверная"", ""Оконная усиленная"", ""Дверная усиленная"", ""Оконная Стандарт"", ""Усиленная Стандарт"", ""Дверная Стандарт"" ) )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МС"");
						Order.DocWork.AddWorkOperForItem(""Установка полотна пыль+мошка, шт."",1);
					}
					
					switch(drOI.idconstructiontype)
					{
						case 8:
							if( !antiCat )
							{
								f = drOI.AddFinparam( 287, 1, 1 ); // Вид москитной сетки
								f.strvalue = ""Оконная"";
								f.smbase2 = isVidPolotna;
								if(model.GetUserParam(""Тип москитной сетки"").StrValue == ""Оконная усиленная"")
								{
									f.sm = 10;
									f.smbase = 10;
									f.strvalue = ""Оконная усиленная"";
								}
								
								if( !isAntiDust ) Order.DocWork.AddWorkOperForItem(""Оконная, шт."",1);
								
							}
							else
							{
								f = drOI.AddFinparam( 287, 4, 4 ); // Вид москитной сетки
								f.strvalue = ""Антикошка"";
								f.smbase2 = isVidPolotna;
								
								if( !isAntiDust ) Order.DocWork.AddWorkOperForItem(""Антикошка, шт."",1);
								
								drOI.AddFinparam( 530, 1, 1 );
								drOI.AddFinparam( 734, 1, 1 );
							}
							
							break;
						
						case 100:
							if( !antiCat && !innerMS )
							{
								f = drOI.AddFinparam( 287, 5, 5 ); // Вид москитной сетки
								f.strvalue = ""Оконная"";
								f.smbase2 = isVidPolotna;
								
								if(model.GetUserParam(""Тип москитной сетки"").StrValue == ""Оконная усиленная"")
								{
									f.sm = 10;
									f.smbase = 10;
									f.strvalue = ""Оконная усиленная"";
								}
								
								if( !isAntiDust ) Order.DocWork.AddWorkOperForItem(""Оконная, шт."",1);
								
							}
							else if( innerMS )
							{
								f = drOI.AddFinparam( 287, 6, 6 ); // Вид москитной сетки
								f.strvalue = ""Вставная"";
								f.smbase2 = isVidPolotna;
								
								Order.DocWork.AddWorkOperForItem(""Вставная, шт."",1);
							}
							else
							{
								f = drOI.AddFinparam( 287, 4, 4 ); // Вид москитной сетки
								f.strvalue = ""Антикошка"";
								f.smbase2 = isVidPolotna;
								
								if( !isAntiDust ) Order.DocWork.AddWorkOperForItem(""Антикошка, шт."",1);
								
								drOI.AddFinparam( 530, 1, 1 );
								drOI.AddFinparam( 734, 1, 1 );
							}
							drOI.AddFinparam( 703, 1, 1 ); // Москитные сетки Вставные (Для ограничения)
							drOI.AddFinparam( 734, 1, 1 );
							break;
						
						case 10:
							if( !antiCat )
							{
								f = drOI.AddFinparam( 287, 2, 2 ); // Вид москитной сетки
								f.strvalue = ""Дверная"";
								f.smbase2 = isVidPolotna;
								if(model.GetUserParam(""Тип москитной сетки"").StrValue == ""Дверная усиленная"")
								{
									f.sm = 20;
									f.smbase = 20;
									f.strvalue = ""Дверная усиленная"";
								}
								
								if( !isAntiDust ) Order.DocWork.AddWorkOperForItem(""Дверная, шт."",1);
							}
							else
							{
								f = drOI.AddFinparam( 287, 4, 4 ); // Вид москитной сетки
								f.strvalue = ""Антикошка"";
								f.smbase2 = isVidPolotna;
								
								if( !isAntiDust ) Order.DocWork.AddWorkOperForItem(""Антикошка, шт."",1);
								
								drOI.AddFinparam( 530, 1, 1 );
								drOI.AddFinparam( 734, 1, 1 );
							}
							break;
						case 17:
							Order.DocWork.AddWorkOperForItem(""Алюминий, шт."",1);
							
							f = drOI.AddFinparam( 287, 3, 3 ); // Вид москитной сетки
							f.strvalue = ""Алюминий"";
							f.smbase2 = isVidPolotna;
							
							break;
						
						case 101:
							Order.DocWork.AddWorkOperForItem(""Вставная, шт."",1);
							
							f = drOI.AddFinparam( 287, 7, 7 ); // Вид москитной сетки
							f.strvalue = ""AlumSN"";
							f.smbase2 = isVidPolotna;
							
							if(Settings.idpeople == 1863)
							{
								drOI.AddFinparam( 710, 1, 1 ); // Москитная сетка для AL окон (Для ограничения)
							}
							break;
					}
					#endregion
					
					

						#region Ошибки на МС
					if( model.MoskitList.Count > 0 )
					{
						UserParam u4 = model.GetUserParam(""Тип москитной сетки"");
						string typeMS2 = u4.StrValue.Trim();
					
						if( inRange( typeMS2, ""Вставная в ПВХ"" ) )
						{
							UserParam u3 = model.GetUserParam(""Тип полотна МС"");
							string typeMS = u3.StrValue.Trim();
							// Сетка Pet Screen
							if( typeMS == ""Полотно Антикошка"" && ( model.Height > 2389 || model.Width > 1381 ) )
							{
								// Ошибка! Недопустимые габариты противомоскитной сетки (максимальная высота 2400 мм или максимальная ширина 1400 мм) 
								Order.AddErrorUnical(drOI.idorderitem,""о1925"","""",""Недопустимые габариты противомоскитной сетки: максимальная высота 2400 мм или максимальная 1400 мм. При этом максимальные размеры светового проёма: высота 2389 мм, ширина 1381 мм."");
							}
							else if( typeMS != ""Полотно Антикошка"" &&( model.Height > 2389 || model.Width > 1581 )  )
							{
								// Ошибка! Недопустимые габариты противомоскитной сетки (максимальная высота 2400 мм или максимальная ширина 1600 мм)
								Order.AddErrorUnical(drOI.idorderitem,""о1926"","""",""Недопустимые габариты противомоскитной сетки: максимальная высота 2400 мм или максимальная 1600 мм. При этом максимальные размеры светового проёма: высота 2389 мм, ширина 1581 мм"");
							}

							if( ( drOI.IsispfNull() || !drOI.ispf ) &&  model.Height > 1389 && !model.ImpostList.Any( x=>( x.AngNakl == 0 || x.AngNakl == 180 ) ) )
							{
								// Ошибка! При указанной высоте сетки необходимо установить импост!
								Order.AddErrorUnical(drOI.idorderitem,""о1927"","""",""При данной высоте сетки (1400 мм) необходимо установить импост! При этом высота светового проёма - 1389 мм"");
							}
						}
						if( inRange( typeMS2, ""Сетка на AL окно"" ) )
						{
							UserParam u3 = model.GetUserParam(""Тип полотна МС"");
							string typeMS = u3.StrValue.Trim();
							// Сетка Pet Screen
							if( typeMS == ""Полотно Антикошка"" && ( model.Height > 2360 || model.Width > 1384 ) )
							{
								// Ошибка! Недопустимые габариты противомоскитной сетки (максимальная высота 2400 мм или максимальная ширина 1400 мм) 
								Order.AddErrorUnical(drOI.idorderitem,""о1925"", """", ""Недопустимые габариты противомоскитной сетки: максимальная высота 2400 мм или максимальная 1400 мм. При этом максимальные размеры светового проёма: высота 2360 мм, ширина 1384 мм."");
							}
							else if( typeMS != ""Полотно Антикошка"" &&( model.Height > 2360 || model.Width > 1584 )  )
							{
								// Ошибка! Недопустимые габариты противомоскитной сетки (максимальная высота 2400 мм или максимальная ширина 1600 мм)
								Order.AddErrorUnical(drOI.idorderitem,""о1926"", """", ""Недопустимые габариты противомоскитной сетки: максимальная высота 2400 мм или максимальная 1600 мм. При этом максимальные размеры светового проёма: высота 2360 мм, ширина 1584 мм."");
							}

							if( ( drOI.IsispfNull() || !drOI.ispf ) &&  model.Height > 1360 && !model.ImpostList.Any( x=>( x.AngNakl == 0 || x.AngNakl == 180 ) ) )
							{
								// Ошибка! При указанной высоте сетки необходимо установить импост!
								Order.AddErrorUnical(drOI.idorderitem,""о1927"","""",""При данной высоте сетки (1400 мм) необходимо установить импост! При этом высота светового проёма - 1360 мм."");
							}
						}
						if( inRange( typeMS2, ""Оконная"", ""Оконная Стандарт"", ""Оконная усиленная"", ""Усиленная Стандарт"", ""Раздвижная"", ""Раздвижная на ISL"" ) && model.Height >= 1430 && !model.ImpostList.Any( x=>( x.AngNakl == 0 || x.AngNakl == 180 ) ) )
						{
							// и287
							Order.AddErrorUnical(drOI.idorderitem,""о1981"", """", ""В оконную сетку высотой более 1430 мм необходимо установить поперечину"");
							
						}
						if( isAntiDust && model.Height > 1000 && !model.ImpostList.Any( x=>( x.AngNakl == 0 || x.AngNakl == 180 ) ) )
						{
							// о1997
							Order.AddErrorUnical(drOI.idorderitem,""о1997"", """", ""При выбранной высоте сетки нужен поперечный импост!"");
						}
						
						int cntHorImp = model.ImpostList.FindAll( x=>( x.AngNakl == 0 || x.AngNakl == 180 ) ).Count ;
						if( inRange( typeMS2, ""Дверная"", ""Дверная Стандарт"" ) && cntHorImp < 2 )
						{
							// о1980
							Order.AddErrorUnical(drOI.idorderitem,""о1980"", """", ""В дверную сетку необходимо установить 2 поперечины"");
						}
					}
					
					#endregion
				}
				#endregion
				dtLogs += ""\n end moskitki "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
				#region Работы + Закладные IF50 RR, R2R
				if( ( inRange( drOI.idproductiontype, 820, 1644, 1678, 1960, 2074 ) 
					&& inRange( drOI.profsys_name, ""Inicial IF50 RR"", ""Inicial IF50 R2R"", ""Татпроф МП-50"", ""Татпроф МП-50300"", ""Татпроф TFS50 Стойка-стойка встык"", ""Татпроф TFS50 Стойка-ригель внахлёст"" ) ) ) // Расчет работ по алюминию IF50RR				
				{
					#region Маркеры координат закладных, заполнений, доборных элементов с каждой из сторон
					
					string op_zakl_left = ""zl"";
					string op_zakl_right = ""zr"";
					string op_zap_right = ""zap_right"";
					string op_zap_left = ""zap_left"";
					string op_dop_right = ""dop_right"";
					string op_dop_left = ""dop_left"";
					
					#endregion
					
					/*
					#region Отладка групп заполнений
					foreach( Glass g in model.GlassList )
					{
						if( !inRange( g.Part, ""Г-5"", ""Г-10"", ""Г-15"" ) )
						{
							continue;
						}
						MessageBox.Show( g.ModelPart.ToString() + ""-"" + g.Part.ToString() );
						
						
						foreach( GlassItem gi in g )
						{
							MessageBox.Show( gi.AngNakl.ToString() );
						}
					}
					#endregion
								*/
					
					Err=""21"";
					#region Работы Inicial IF50RR
					// Количество стоек
					int quStoek = 0;
					// Количество ригелей
					int quRigel = 0;
					
					int quRigelZakl = 0;
					
					decimal oiSquare = 0;
					
					oiSquare = drOI.width * drOI.height / 1000000;
					
					
					
					
					//Балки рамы
					foreach(RamaItem ri in model.Rama)
					{
						bool inverse = ri.AngleHorisont == 270;
						double sign = 1;
						if( inverse ) sign = -1;

						if(ri.Marking.ToLower().Contains(""без""))
						{
							continue;
						}
						else
						{
							if( ( ri.AngNakl == 90 ) || ( ri.AngNakl == 270 ) ) 
							{
								quStoek++;
							}
							else
							{
								quRigel++;
								
								quRigelZakl+=2;
							}

							#region Добавление операций на балку рамы, по координатам прилегающих импостов, а также на края, там ведь тоже закладные
							int impCnt = 0;
							foreach( double i_ in ri.ImpostPositionListDoubleInterface )
							{
								double i = Math.Round( i_, 3 );
								if( i < 0 || i > ri.Lenght ) continue;
								Impost imp = (Impost)ri.ImpostList[ impCnt ];
								impCnt++;
							}

							
							if( ri.IsRack )
							{
								int railCnt = 0;
								foreach( double i_ in ri.RailPositionListDoubleInterface )
								{
									double i = Math.Round( i_, 3 );
									if( i < 0 || i > ri.Lenght ) continue;

									Balka b = (Balka)ri.RailList[ railCnt ];

									if( b != null && b.Side == ItemSide.Bottom ) { i += sign * b.A / 2; } else { i -= sign * b.A / 2; }
									railCnt++;
								}
							}
							
							#endregion
							#region Добавление операций по списку прилегающих заполнений
							foreach( ModelPartClass mpc in ri.PartTypeList )
							{
								if( mpc.ModelPart == ModelPart.Glass )
								{
									Glass g = mpc.Glass;
									
									//									if( ri.ID==7 )
									//									{
									//										MessageBox.Show( g.Marking + "", thick="" + g.Thickness.ToString() + "", ramalen="" + ri.Lenght.ToString() + "", glasspart="" + g.Part + "". c_start="" + mpc.FillStart.ToString() );
									//									}
									
									if( g != null )
									{
										double aFrom = 0; double aTo = 0;
										fillModelPartClass_FromTo( ri, mpc, ref aFrom, ref aTo );
										//string side = getSideRussian( ri );
										Operation op = new Operation( op_zap_right,ri.ID,g.Part + "" [""+g.Marking+""] "",aFrom, aTo);
										op.X1_Double = aFrom;
										op.X2_Double = aTo;
										ri.OperationList.Add( op );
										
										#region Добавление операций по материалам, устанавливаемым на сторону балки согласно группы заполнения, если таковая есть
										if( mpc.ShtapicGroup != """" )
										{
											string[] a = mpc.ShtapicGroup.Split(';');
											if( a.Length > 0 )
											{
												// Берем первую группу заполнений из списка
												int idShtapicGroup = Useful.GetInt32( a[0], 0 );
											
												decimal zap_Depth = 0;
												
												string[] markings={}; decimal[] delta={}; decimal[] coeff={};
												if( getShtapicGroupDetail2( idShtapicGroup, g.Thickness, ri.Marking, ref markings, ref delta, ref coeff, ref zap_Depth ) )
												{
													int i = 0; 
													decimal d = delta[i];
													decimal k = coeff[i];
													foreach( string mark in markings )
													{
														op = new Operation( op_dop_right,ri.ID,mark + "" ["" + g.Part + ""] "",aFrom, aTo);
														//MessageBox.Show( ""aFrom="" + aFrom.ToString() + "", aTo="" + aTo.ToString() + "", mark="" + mark + "", delta="" + d.ToString() + "", k="" + k.ToString() );
														op.X = Useful.GetInt32( (double)k * ( aTo - aFrom + (double)d ), 0 );
														op.X1_Double = aFrom - (double)d/2;
														op.X2_Double = aTo + (double)d/2;
														ri.OperationList.Add( op );
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
							dtLogs += ""\n end huge cycle "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
							#region Добавление операции по доборным профилям (компенсаторам) с внешней стороны рамы (в проем), сторона = ЛЕВАЯ
							//							MessageBox.Show( ri.Insertions );
							string[] insertionlist = ri.Insertions.Split(';');
							foreach( string insertionid in insertionlist )
							{
								int idinsertion = Useful.GetInt32( insertionid, 0 );
								if( idinsertion != 0 )
								{
									string[] markings={}; decimal[] delta={}; decimal[] coeff={};
									if( getInsertionDetail( idinsertion, ref markings, ref delta, ref coeff ) )
									{
										int i = 0; 
										decimal d = delta[i];
										decimal k = coeff[i];
										foreach( string mark in markings )
										{
											Operation op = new Operation( op_dop_left,ri.ID,mark,0,ri.Lenght);
											op.X = Useful.GetInt32( (double)k * ( ri.Lenght + (double)d ), 0 );
											op.X1_Double = 0;
											op.X2_Double = ri.Lenght;
											ri.OperationList.Add( op );
											i++;
										}
									}
								}
							}
							#endregion
						}
					}
					dtLogs += ""\n end add opps dobor "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
					//Балки имостов
					foreach(Impost ri in model.ImpostList )
					{
						if(ri.Marking.ToLower().Contains(""без""))
						{
							continue;
						}
						else
						{
							if( ( ri.AngNakl == 90 ) || ( ri.AngNakl == 270 ) ) 
							{
								quStoek++;
							}
							else
							{
								quRigel++;
								quRigelZakl += 2;
							}
						
							#region Добавление операций по установке закладных на балки импостов (средних ригелей и стоек), по координатам прилегающих балок, а также на краях (длинные соединения)
							int impCnt = 0;
							foreach( double i_ in ri.ImpostPositionListDoubleInterface )
							{
								double i = Math.Round( i_, 3 );
								if( i < 0 || i > ri.Lenght ) continue;
								
								Impost imp = (Impost)ri.ImpostList[ impCnt ];
								//								if( imp != null && !imp.Marking.ToLower().Contains(""без"") && ri.AngNakl != imp.AngNakl ) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
								//								{
								//									Operation op = new Operation( op_zakl_left,(double)i,getBalkaIndex(imp) + "" ["" + imp.Marking.Replace(""#"","""") + ""]"",(double)i,(double)i);
								//									ri.OperationList.Add( op );
								//								}
								impCnt++;
							}
							if( ri.IsRack )
							{

								int railCnt = 0;
								foreach( double i_ in ri.RailPositionListDoubleInterface )
								{
									double i = Math.Round( i_, 3 );
									if( i < 0 || i > ri.Lenght ) continue;
									
									Balka b = (Balka)ri.RailsList[ railCnt ];
									if( b != null && b.Side == ItemSide.Bottom ) { i += b.A / 2; } else { i -= b.A / 2; }

									//									if( b != null && !b.Marking.ToLower().Contains(""без"") && ri.AngNakl != b.AngNakl ) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
									//									{
									//										//MessageBox.Show( ""RailNo: "" + railCnt.ToString() + "", OPER="" + op_zakl_left + "", i="" + i.ToString() + "", Info="" + getBalkaIndex(b) + "" ["" + b.Marking.Replace(""#"","""") + ""]"" );
									//										Operation op = new Operation( op_zakl_left,(double)i,getBalkaIndex(b) + "" ["" + b.Marking.Replace(""#"","""") + ""]"",(double)i,(double)i);
									//										ri.OperationList.Add( op );
									//									}
									railCnt++;
								}
							}
							
							/*
							if( ri.BalkaStart1 != null && !ri.BalkaStart1.Marking.ToLower().Contains(""без"") && ri.Connect1 == SoedType.Dlinnoe )
							{
								Operation op = new Operation( op_zakl_left,0,getBalkaIndex(ri.BalkaStart1) + "" ["" + ri.BalkaStart1.Marking.Replace(""#"","""") + ""]"",0,0);
								ri.OperationList.Add( op );
							}

							if( ri.BalkaEnd1 != null && !ri.BalkaEnd1.Marking.ToLower().Contains(""без"") &&  ri.Connect2 == SoedType.Dlinnoe )
							{
								Operation op = new Operation( op_zakl_left,ri.LengthDouble,getBalkaIndex(ri.BalkaEnd1) + "" ["" + ri.BalkaEnd1.Marking.Replace(""#"","""") + ""]"",ri.LengthDouble,ri.LengthDouble);
								ri.OperationList.Add( op );
							}
							*/
							
							
							impCnt = 0;
							foreach( double i_ in ri.ImpostPositionListDouble2Interface )
							{
								double i = Math.Round( i_, 3 );
								if( i < 0 || i > ri.Lenght ) continue;
								
								Impost imp = (Impost)ri.ImpostList2[ impCnt ];
								//								if( imp != null && !imp.Marking.ToLower().Contains(""без"") && ri.AngNakl != imp.AngNakl ) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
								//								{
								//									Operation op = new Operation( op_zakl_right,(double)i,getBalkaIndex(imp) + "" ["" + imp.Marking.Replace(""#"","""") + ""]"",(double)i,(double)i);
								//									ri.OperationList.Add( op );
								//								}
								impCnt++;
							}
							if( ri.IsRack )
							{

								int railCnt = 0;
								foreach( double i_ in ri.RailPositionListDouble2Interface )
								{
									double i = Math.Round( i_, 3 );
									if( i < 0 || i > ri.Lenght ) continue;
									Balka b = (Balka)ri.RailsList2[ railCnt ];
									if( b != null && b.Side == ItemSide.Bottom ) { i += b.A / 2; } else { i -= b.A / 2; }
									//									MessageBox.Show( ""B_ANGLE="" + b.AngNakl.ToString() + "", I_ANGLE="" + ri.AngNakl.ToString() );

									//									if( b != null && !b.Marking.ToLower().Contains(""без"") && ri.AngNakl != b.AngNakl ) // Закладные разрезных стоек (балки в одном направлении) нам не интересны
									//									{
									//										Operation op = new Operation( op_zakl_right,(double)i,getBalkaIndex(b) + "" ["" + b.Marking.Replace(""#"","""") + ""]"",(double)i,(double)i);
									//										ri.OperationList.Add( op );
									//									}
									railCnt++;
								}
							}
							/*
							if( ri.BalkaStart2 != null && !ri.BalkaStart2.Marking.ToLower().Contains(""без"") && ri.Connect1 == SoedType.Dlinnoe )
							{
								Operation op = new Operation( op_zakl_right,0,getBalkaIndex(ri.BalkaStart2)  + "" ["" + ri.BalkaStart2.Marking.Replace(""#"","""") + ""]"",0,0);
								ri.OperationList.Add( op );
							}

							if( ri.BalkaEnd2 != null && !ri.BalkaEnd2.Marking.ToLower().Contains(""без"") && ri.Connect2 == SoedType.Dlinnoe )
							{
								Operation op = new Operation( op_zakl_right,ri.LengthDouble,getBalkaIndex(ri.BalkaEnd2) + "" ["" + ri.BalkaEnd2.Marking.Replace(""#"","""") + ""]"",ri.LengthDouble,ri.LengthDouble);
								ri.OperationList.Add( op );
							}
							*/
							#endregion
							 
							#region Добавление операций по списку прилегающих заполнений. Слева
							// Слева
							foreach( ModelPartClass mpc in ri.PartTypeList )
							{
								if( mpc.ModelPart == ModelPart.Glass )
								{
									Glass g = mpc.Glass;
									if( g != null )
									{
										double aFrom = 0; double aTo = 0;
										fillModelPartClass_FromTo( ri, mpc, ref aFrom, ref aTo );
										Operation op = new Operation( op_zap_left,ri.ID,g.Part + "" [""+g.Marking+""]"",aFrom, aTo);
										op.X1_Double = aFrom;
										op.X2_Double = aTo;
										ri.OperationList.Add( op );
										
										#region Добавление операций по материалам, устанавливаемым на сторону балки согласно группы заполнения, если таковая есть
										if( mpc.ShtapicGroup != """" )
										{
											string[] a = mpc.ShtapicGroup.Split(';');
											if( a.Length > 0 )
											{
												// Берем первую группу заполнений из списка
												int idShtapicGroup = Useful.GetInt32( a[0], 0 );
											
												decimal zap_Depth = 0;
												
												string[] markings={}; decimal[] delta={}; decimal[] coeff={};
												if( getShtapicGroupDetail2( idShtapicGroup, g.Thickness, ri.Marking, ref markings, ref delta, ref coeff, ref zap_Depth ) )
												{
													int i = 0; 
													decimal d = delta[i];
													decimal k = coeff[i];
													foreach( string mark in markings )
													{
														op = new Operation( op_dop_left,ri.ID,mark + "" ["" + g.Part + ""] "",aFrom, aTo);
														//MessageBox.Show( ""aFrom="" + aFrom.ToString() + "", aTo="" + aTo.ToString() + "", mark="" + mark + "", delta="" + d.ToString() + "", k="" + k.ToString() );
														op.X = Useful.GetInt32( (double)k * ( aTo - aFrom + (double)d ), 0 );
														op.X1_Double = aFrom - (double)d/2;
														op.X2_Double = aTo + (double)d/2;
														ri.OperationList.Add( op );
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
						
							#region Добавление операций по списку прилегающих заполнений. Справа
							// Справа
							foreach( ModelPartClass mpc in ri.PartTypeList2 )
							{
								if( mpc.ModelPart == ModelPart.Glass )
								{
									Glass g = mpc.Glass;
									if( g != null )
									{
										double aFrom = 0; double aTo = 0;
										fillModelPartClass_FromTo( ri, mpc, ref aFrom, ref aTo );
										Operation op = new Operation( op_zap_right,ri.ID,g.Part + "" [""+g.Marking+""]"",aFrom, aTo);
										op.X1_Double = aFrom;
										op.X2_Double = aTo;
										ri.OperationList.Add( op );
										
										#region Добавление операций по материалам, устанавливаемым на сторону балки согласно группы заполнения, если таковая есть
										if( mpc.ShtapicGroup != """" )
										{
											string[] a = mpc.ShtapicGroup.Split(';');
											if( a.Length > 0 )
											{
												// Берем первую группу заполнений из списка
												int idShtapicGroup = Useful.GetInt32( a[0], 0 );
											
												decimal zap_Depth = 0;
												
												string[] markings={}; decimal[] delta={}; decimal[] coeff={};
												if( getShtapicGroupDetail2( idShtapicGroup, g.Thickness, ri.Marking, ref markings, ref delta, ref coeff, ref zap_Depth ) )
												{
													int i = 0; 
													decimal d = delta[i];
													decimal k = coeff[i];
													foreach( string mark in markings )
													{
														op = new Operation( op_dop_right,ri.ID,mark + "" ["" + g.Part + ""] "",aFrom, aTo);
														op.X = Useful.GetInt32( (double)k * ( aTo - aFrom + (double)d ), 0 );
														op.X1_Double = aFrom - (double)d/2;
														op.X2_Double = aTo + (double)d/2;
														ri.OperationList.Add( op );
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
					
						}
					}
					dtLogs += ""\n end huge impost "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff"");
					#region Добавление работ
					
					if(quStoek > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IF50"");
						Order.DocWork.AddWorkOperForItem(""Заготовка стойки"",quStoek);
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IF50"");
						Order.DocWork.AddWorkOperForItem(""Установка уплотнителя в стойку"",quStoek);
					}
					if(quRigel > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IF50"");
						Order.DocWork.AddWorkOperForItem(""Заготовка ригеля"",quRigel);
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IF50"");
						Order.DocWork.AddWorkOperForItem(""Торцовка ригеля"",quRigel);
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IF50"");
						Order.DocWork.AddWorkOperForItem(""Установка уплотнителя в ригель"",quRigel);						
					}
					
					if( oiSquare > 0 ) 
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IF50"");
						Order.DocWork.AddWorkOperForItem(""Комплектование заказа, м2"",oiSquare);						
					}
					
					if( quRigelZakl > 0 && inRange( drOI.idprofsys, 120, 128, 212, 214 ) )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IF50"");
						Order.DocWork.AddWorkOperForItem(""Установка закладной"",quRigelZakl);		
					}
					if( quStoek + quRigel > 0 && inRange( drOI.idprofsys, 212, 214 ) )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IF50"");
						Order.DocWork.AddWorkOperForItem(""Заготовка термомоста"",quStoek + quRigel);
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IF50"");
						Order.DocWork.AddWorkOperForItem(""Установка термомоста"",quStoek + quRigel);
					}
					
					#endregion Добавление работ
					#endregion Работы Inicial IF50RR
					dtLogs += ""\n end inicial if50rr "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff"");
				}
				#endregion
				dtLogs += ""\n end jobs IF50 RR "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
				#region Работы + Закладные IP45
				if( !drOI.IsidpowerNull() && inRange( drOI.idpower, 52 ) && !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 122, 160, 188, 222 ) ) // Расчет работ по алюминию IP45	, Сокол МП40, МП-45			
				{
					#region Тест сохранения координат закладных с каждой из сторон
					
					string op_zakl_left = ""zl"";
					string op_zakl_right = ""zr"";
					
					#endregion
					Err=""23"";
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
					int quSecondZamok = 0;
					
					int zamokBezop = 0;
					
					int quHandleWithHoles = 0;
					
					// int quZakl = 0;
					
					//Балки рамы
					foreach(RamaItem ri in model.Rama)
					{
						
						if(ri.Marking.ToLower().Contains(""без""))
						{
							// if( quZakl > 0 ) quZakl -= 1; // если  безрама, то на одну закладную меньше

							continue;
						}
						else
						{
							quBeem++;
							
							
							// quZakl += 1; // по одной закладной на соединиение рамы с соседом
							
							#region Добавление операций на балку рамы, по координатам прилегающих импостов, а также на края, там ведь тоже закладные
							int impCnt = 0;
							foreach( double i_ in ri.ImpostPositionListDoubleInterface )
							{
								double i = Math.Round( i_, 3 );

								Impost imp = (Impost)ri.ImpostList[ impCnt ];
								//								if( imp != null && !imp.Marking.ToLower().Contains(""без"") )
								//								{
								//									Operation op = new Operation( op_zakl_right,(double)i,getBalkaIndex(imp) + "" ["" + imp.Marking.Replace(""#"","""") + ""]"",(double)i,(double)i);
								//									ri.OperationList.Add( op );
								//									
								//									// quZakl += 1; // по одной закладной на стык рамы и импоста справа
								//
								//								}
								impCnt++;
							}
							//MessageBox.Show( ri.Variants );
							//							Balka bs = ri.BalkaStart;
							//							Balka be = ri.BalkaEnd;
							//							
							//							if( bs != null && !bs.Marking.ToLower().Contains(""без"") && ri.Connect1 == SoedType.Dlinnoe )
							//							{
							//								Operation op = new Operation( op_zakl_right,0,getBalkaIndex(bs) + "" ["" + bs.Marking.Replace(""#"","""") + ""]"",0,0);
							//								ri.OperationList.Add( op );
							//							}
							//
							//							if( be != null && !be.Marking.ToLower().Contains(""без"") && ri.Connect2 == SoedType.Dlinnoe )
							//							{
							//								Operation op = new Operation( op_zakl_right,ri.LengthDouble,getBalkaIndex(be) + "" ["" + be.Marking.Replace(""#"","""") + ""]"",ri.LengthDouble,ri.LengthDouble);
							//								ri.OperationList.Add( op );
							//							}
							#endregion

						}
					}
					
					int quRamaZakl = 0;

					List<string> connectionKeys = new List<string>();
					
					foreach(RamaItem ri in model.Rama)
					{
						
						if(ri.Marking.ToLower().Contains(""без"") || ri.RamaType == RamaType.Porog )
						{
							continue;
						}
						else
						{
							bool bs_via_porog = ( ri.BalkaStart is RamaItem && ((RamaItem)ri.BalkaStart).RamaType == RamaType.Porog );
							if( !ri.BalkaStart.Marking.ToLower().Contains(""без"") && !bs_via_porog )
							{
								Balka b1 = ri;
								Balka b2 = ri.BalkaStart;
								string bs_marking = b1.BalkaType + ""-"" + b1.ID + "":"" + b2.BalkaType + ""-"" + b2.ID;
								string bs_marking_reverse = b2.BalkaType + ""-"" + b2.ID + "":"" + b1.BalkaType + ""-"" + b1.ID;
								
								if( !connectionKeys.Contains( bs_marking ) && !connectionKeys.Contains( bs_marking_reverse ) )
								{
									connectionKeys.Add( bs_marking );
								}
							}
							bool be_via_porog = ( ri.BalkaEnd is RamaItem && ((RamaItem)ri.BalkaEnd).RamaType == RamaType.Porog );
							if( !ri.BalkaEnd.Marking.ToLower().Contains(""без"") && !be_via_porog )
							{
								Balka b1 = ri;
								Balka b2 = ri.BalkaEnd;
								string bs_marking = b1.BalkaType + ""-"" + b1.ID + "":"" + b2.BalkaType + ""-"" + b2.ID;
								string bs_marking_reverse = b2.BalkaType + ""-"" + b2.ID + "":"" + b1.BalkaType + ""-"" + b1.ID;
								
								if( !connectionKeys.Contains( bs_marking ) && !connectionKeys.Contains( bs_marking_reverse ) )
								{
									connectionKeys.Add( bs_marking );
								}
							}
							
						}
					}
					

					quRamaZakl = connectionKeys.Count;
					
					/*
					foreach(RamaItem ri in model.Rama)
					{
						
						if(ri.Marking.ToLower().Contains(""без""))
						{
							continue;
						}
						if(ri.RamaType == RamaType.Porog)
						{
							quZakl = 2;
							break;
						}
						else
						{
							quZakl = 4;
						}
					}
					*/
					quZakl += quRamaZakl;

					foreach (Stvorka s in model.StvorkaList)
					{
						quUplStv++; // Уплотнитель на створку 1шт = притворный
						quFalz++;
						quFurn++;
						quProvis++;
						quUplRam++; // На каждую створку на раме 1шт уплотнитель = притворный
						if(s.HandlePosition > 0 && s.Shtulp==null )
						{
							quHandle++;
						}
						//Балки створки
						foreach(StvorkaItem si in s)
						{
							if(si.Marking.ToLower().Contains(""без""))
								continue;
							quBeem++;
							quZakl++;
						}
						
						if( s.HandlePosition > 0 && s.Shtulp==null && inRange( s.GetUserParam(""Второй замок"").StrValue, ""Ригель-защелка"", ""Ригель-ролик"" ) )
						{
							quSecondZamok ++;
						}
						
						if( s.HandlePosition > 0 && s.ShtulpExist != ShtulpExist.Exist && inRange( s.GetUserParam(""Детский замок"").StrValue, ""Замок с тросом для раздвижных створок"", ""Замок с ключом для распашных створок"" ) )
						{
							zamokBezop ++;
						}
						
						try
						{
							UserParam u2 = s.GetUserParam(""Сверлить отверстия под ручку"");
							if( u2 != null )
							{
								if( u2.StrValue.ToLower() == ""да"" && u2.Visible ) quHandleWithHoles ++;
							}
						}
						catch( Exception E )
						{
								
						}
					}
					
					
					foreach (Impost i in model.ImpostList)
					{
						//Балки импоста
						if(i.Marking.ToLower().Contains(""без"") || i.ImpostType == ImpostType.Shtulp)
							continue;
						quBeem++;
						if( i.Connect1 == Atechnology.winDraw.Model.SoedType.Korotkoe ) quZakl+=1;
						if( i.Connect2 == Atechnology.winDraw.Model.SoedType.Korotkoe ) quZakl+=1;
						
						Impost ri = i;
						
						#region Добавление операций по установке закладных на балки импостов (средних ригелей и стоек), по координатам прилегающих балок, а также на краях (длинные соединения)
						int impCnt = 0;
						foreach( double i0_ in ri.ImpostPositionListDoubleInterface )
						{
							double i0 = Math.Round( i0_, 3 );
							//
							//							Impost imp = (Impost)ri.ImpostList[ impCnt ];
							//							if( imp != null && !imp.Marking.ToLower().Contains(""без"") )
							//							{
							//								Operation op = new Operation( op_zakl_left,(double)i0,getBalkaIndex(imp) + "" ["" + imp.Marking.Replace(""#"","""") + ""]"",(double)i0,(double)i0);
							//								ri.OperationList.Add( op );
							//							}
							impCnt++;
						}
							
						//						if( ri.BalkaStart1 != null && !ri.BalkaStart1.Marking.ToLower().Contains(""без"") && ri.Connect1 == SoedType.Dlinnoe )
						//						{
						//							Operation op = new Operation( op_zakl_left,0,getBalkaIndex(ri.BalkaStart1) + "" ["" + ri.BalkaStart1.Marking.Replace(""#"","""") + ""]"",0,0);
						//							ri.OperationList.Add( op );
						//						}
						//
						//						if( ri.BalkaEnd1 != null && !ri.BalkaEnd1.Marking.ToLower().Contains(""без"") &&  ri.Connect2 == SoedType.Dlinnoe )
						//						{
						//							Operation op = new Operation( op_zakl_left,ri.LengthDouble,getBalkaIndex(ri.BalkaEnd1) + "" ["" + ri.BalkaEnd1.Marking.Replace(""#"","""") + ""]"",ri.LengthDouble,ri.LengthDouble);
						//							ri.OperationList.Add( op );
						//						}
							
						impCnt = 0;
						foreach( double i0_ in ri.ImpostPositionListDouble2Interface )
						{
							double i0 = Math.Round( i0_, 3 );
							
							Impost imp = (Impost)ri.ImpostList2[ impCnt ];
							//							if( imp != null && !imp.Marking.ToLower().Contains(""без"") )
							//							{
							//								Operation op = new Operation( op_zakl_right,(double)i0,getBalkaIndex(imp) + "" ["" + imp.Marking.Replace(""#"","""") + ""]"",(double)i0,(double)i0);
							//								ri.OperationList.Add( op );
							//							}
							impCnt++;
						}
						//
						//						if( ri.BalkaStart2 != null && !ri.BalkaStart2.Marking.ToLower().Contains(""без"") && ri.Connect1 == SoedType.Dlinnoe )
						//						{
						//							Operation op = new Operation( op_zakl_right,0,getBalkaIndex(ri.BalkaStart2)  + "" ["" + ri.BalkaStart2.Marking.Replace(""#"","""") + ""]"",0,0);
						//							ri.OperationList.Add( op );
						//						}
						//
						//						if( ri.BalkaEnd2 != null && !ri.BalkaEnd2.Marking.ToLower().Contains(""без"") && ri.Connect2 == SoedType.Dlinnoe )
						//						{
						//							Operation op = new Operation( op_zakl_right,ri.LengthDouble,getBalkaIndex(ri.BalkaEnd2) + "" ["" + ri.BalkaEnd2.Marking.Replace(""#"","""") + ""]"",ri.LengthDouble,ri.LengthDouble);
						//							ri.OperationList.Add( op );
						//						}
						#endregion

					}

					foreach(Glass g in model.GlassList)
					{

						if( g.Marking.ToLower().Contains(""без_стекла_и_штапика"") ) continue;

						/*
						foreach( GlassItem gi in g )
						{
							if( gi.Lenght < 50 )
							{
								Order.AddErrorUnical(drOI.idorderitem,""о098"");
								break;
							}
						}
				*/

						if(!g.Marking.ToLower().Contains(""без""))
						{
							quZap++;
						}
						foreach(GlassItem gi in g)
						{
							quShtap++;
						}
						
						if( g.ModelPart == ModelPart.Rama )
						{
							quUplRam+=2;
						}
						else if( g.ModelPart == ModelPart.Stvorka )
						{
							quUplStv+=2; // В СТВОРКАХ УПЛОТНЕНИЯ НЕ ВХОДЯТ В РАБОТЫ..  (с) Бубнов. Вроде снова входят. 19.12.2017
						}
					}

					//					MessageBox.Show( quBeem.ToString() );
					#region Добавление работ
					
					if(quBeem > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Резка профиля"",quBeem);
					}
					/*ВЕРНУЛ ОБРАТНО, 23.07.2019!!!! РЕЗКУ ЗАКЛАДНЫХ ПЕРЕВЕСИЛ НА ОБЩИЙ РАСЧЕТ ПО КОЛИЧЕСТВУ ДЕТАЛЕЙ. Расчет работ по группам оптимизирования. таблица = 180
					*/
					if(quZakl > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Резка закладных"",quZakl);
					}
					
					if(quUplRam >0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Уплотнение в раму"",quUplRam);
					}
					if(quUplStv > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Уплотнение в створку"",quUplStv);
					}
					if(quHandle > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка под ручку"",quHandle);
					}
					if(quFalz > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Проверка фальц люфта"",quFalz);
					}
					if(quFurn > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Установка фурнитуры"",quFurn);
					}
					if(quShtap > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Резка штапика"",quShtap);
					}
					if(quZap > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Установка заполнений"",quZap);
					}
					if(quProvis > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Провис створки"",quProvis);
					}
					if( quSecondZamok > 0 ) // Установка фурнитуры дверь
					{
						ds_docwork.docworkRow drw = AddWorkByName( Order, drOI, ""Изготовление IP45"", ""Установка фурнитуры"", quSecondZamok );
					}
					
					if(zamokBezop>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Установка замка безопасности"",zamokBezop);
					}
					
					if(quHandleWithHoles>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IP45"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка под ручку-скобу"",quHandleWithHoles);
					}
					

					
					#endregion Добавление работ
					
					#endregion
					
					#region Доп. Работы Сокол 40
					if( !drOI.IsidpowerNull() && inRange( drOI.idpower, 52 ) && !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 160 ) && !drOI.IsidconstructiontypeNull() && inRange( drOI.idconstructiontype, 39 ) )
					{
						ModelParamClass up = drOI.GetModelParamList()[""Дренаж Алюминий""];
						
						if( up != null && up.StrValue == ""Да"" )
						{
							int quDrenazh = 0; int quDrenazhP400 = 0;
							foreach( RamaItem ri in model.Rama )
							{
								if( !ri.Marking.ToLower().Contains(""без"") && ri.AngleHorisont == 180 )
								{
													/*
													(длинна балки минус 300мм) / 600 = х
									полученное значение х округляем в большую сторону и +1,
									но минимум 2 отверстия.
													*/
									quDrenazh += Math.Max( roundToMax( ( ri.LengthInterfaceCalc - 300 ) / 600 ) + 1, 2 );
								}
							}
							foreach( Impost ri in model.ImpostList )
							{
								if( !ri.Marking.ToLower().Contains(""без"") && inRange( ri.AngleHorisont, 0, 180 ) )
								{
									quDrenazh += Math.Max( roundToMax( ( ri.LengthInterfaceCalc - 300 ) / 600 ) + 1, 2 );
								}
							}
							foreach( Stvorka s in model.StvorkaList )
							{
								foreach( StvorkaItem ri in s )
								{
									if( !ri.Marking.ToLower().Contains(""без"") && inRange( ri.AngleHorisont, 180 ) )
									{
										switch( ri.Marking )
										{
											case ""P400/02X"":
												quDrenazhP400 += Math.Max( roundToMax( ( ri.LengthInterfaceCalc - 300 ) / 600 ) + 1, 2 );
												break;
										}
									}
								}
							}
							
							if( quDrenazh > 0 )
							{
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
								Order.DocWork.SetCalcParam(drOI.idorderitem,""Дренаж"");
								Order.DocWork.AddWorkOperForItem(""Фрезеровка дренажных отверстий"",quDrenazh);
							}
							if( quDrenazhP400 > 0 )
							{
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
								Order.DocWork.SetCalcParam(drOI.idorderitem,""Дренаж"");
								Order.DocWork.AddWorkOperForItem(""Фрезеровка дренажных отверстий P400/02X"",quDrenazhP400);
							}
						}
					}
					#endregion
				}
				#endregion
				dtLogs += ""\n end zaklad IP45 "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
				#region Работы Provedal
				if( 
					(
					inRange( 
					drOI.idproductiontype, 247, 1594, 2261 ) // ) || ( drOI.idproductiontype == 248 ) 
					|| 
					( inRange( drOI.idproductiontype, 112 ) && ( drOI.IsispfNull() || !drOI.ispf ) )
					) && !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 8, 249 ) 
					) // Расчет работ по алюминию Provedal C640, P400				
				{
					Err=""23"";
					#region Работы Provedal
					//Кол-во балок
					int quRama = 0;
					int quBalkaRama = 0;
					int quRazdvStvorka = 0;
					int quPovStvorka = 0;
					int quBalkaRazdvStvorka = 0;
					int quBalkaPovStvorka = 0;
					int quBalkaImpost = 0;
					int quGluhRama = 0;
					int quPlastik = 0;
					int quSoed = 0;
					int quZapaketka = 0;
					int quZapaketkaGluharPov = 0;
					int quSmallBalka = 0;
					
					
					quRama = 1; // Рама всегда одна
					
					// Количество глухих рам
					if( model.StvorkaList.Count == 0 ) 
					{
						quGluhRama = 1;
					}
					else
					{
						quGluhRama = 0;
					}
					
					//Балки рамы
					foreach(RamaItem ri in model.Rama)
					{
						
						if(ri.Marking.ToLower().Contains(""без""))
						{
							continue;
						}
						else
						{
							quBalkaRama++;
						}
					}

					// Соединители
					foreach (Soedinitel  soe in model.SoedinitelList)
					{
						if(!soe.Marking.ToLower().Contains(""без""))
						{
							quSoed++;
						}
					}
					
					// Запакетки
					foreach(Glass g in model.GlassList)
					{
						if(!g.Marking.ToLower().Contains(""без""))
						{
							if(g.ModelPart==ModelPart.Stvorka) // Створка
							{
								Stvorka s=(Stvorka)g.ModelItem;
								if(s.otkrivanieType==OtkrivanieType.Pov) // Но только поворотная
								{
									quZapaketka++;
								}
							}
							else // Глухарь 
							{
								quZapaketka++;
							}
						}
					}
					
					// Количество створок по видам, а также их балки
					foreach (Stvorka s in model.StvorkaList)
					{
						if( s.otkrivanieType == OtkrivanieType.Razd )
						{
							quRazdvStvorka++;
							//Балки створки
							foreach(StvorkaItem si in s)
							{
								if(si.Marking.ToLower().Contains(""без""))
									continue;
								quBalkaRazdvStvorka++;
								
								if(model.Height < 605)
								{
									if(si.Marking == ""C640/10"" || si.Marking==""04 01 04"" )
									{
										quSmallBalka++;
									}
								}
							}
						}
						else if( s.otkrivanieType == OtkrivanieType.Pov )
						{
							quPovStvorka++;
							//Балки створки
							foreach(StvorkaItem si in s)
							{
								if(si.Marking.ToLower().Contains(""без""))
									continue;
								quBalkaPovStvorka++;
							}
						}
					}
					
					foreach (Impost i in model.ImpostList)
					{
						//Балки импоста
						if(i.Marking.ToLower().Contains(""без"") && i.ImpostType != ImpostType.Shtulp)
							continue;
						if( ( i.Marking == ""Сцепка"" ) || ( i.Marking == ""Стык"" ) || (i.Marking == ""C640/30 Стык"" ) || (i.Marking == ""04 01 07"" ) )
							continue; // Стык и сцепка это не импост
						quBalkaImpost++;
					}
					

					#region Добавление работ
					
					if(quBalkaRama > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Резка рамы"",quBalkaRama);
					}

					if(quRazdvStvorka > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Резка раздвижной створки"",quRazdvStvorka);
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Заготовка раздвижной створки"",quRazdvStvorka);						

						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Сборка раздвижной створки"",quRazdvStvorka);
					}
					if(quSmallBalka > 0)
					{
						/* Тут добавляем дополнительную работу для малых (<605) мм балок рамы проведал??? Нужна новая работа или подойдет старая*/
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Резка раздвижной створки"",quSmallBalka);
					}
					if(quPovStvorka >0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Резка поворотной створки"",quPovStvorka);

						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Сборка поворотной створки"",quPovStvorka);
					}
					if(quBalkaImpost > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Резка импоста"",quBalkaImpost);
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Сборка импоста"",quBalkaImpost);						
					}
					if(quBalkaRama > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Сборка рамы"",quBalkaRama);
					}
					if(quGluhRama > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Сборка глухой рамы"",quGluhRama);
					}
					if(quZapaketka > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Запакетка"",quZapaketka);
					}
					if(quSoed > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление Provedal"");
						Order.DocWork.AddWorkOperForItem(""Резка соединителей"",quSoed);
					}
					#endregion Добавление работ
					
					#endregion
					#region Определение принадлежности модели к C640/P400 и т.п.
					int idFinParam = 215; // 215й финпараметр = система Provedal
					bool P400 = false;
					bool C640_razdv = false;
					bool C640_gluhar = false;
					
					foreach( RamaItem ri in model.Rama )
					{
						if( ri.Marking.ToLower().Contains(""p400/01"") || ri.Marking.ToLower().Contains(""04 02 01"") || ri.Marking.ToLower().Contains(""04 02 02"") )
						{
							P400 = true;
							C640_razdv = false;
							C640_gluhar = false;
							break;
						}
						if( ri.Marking.ToLower().Contains(""c640/01"" ) || ri.Marking.ToLower().Contains(""c640/02"" ) || ri.Marking.ToLower().Contains(""c640/03"" ) )
						{
							P400 = false;
							C640_razdv = true;
							C640_gluhar = false;
							break;
						}
						if( ri.Marking.ToLower().Contains(""04 01 01"" ) || ri.Marking.ToLower().Contains(""04 01 02"" ) || ri.Marking.ToLower().Contains(""04 01 03"" ) || ri.Marking.ToLower().Contains(""04 01 14"" ) || ri.Marking.ToLower().Contains(""04 01 15"" )  )
						{
							P400 = false;
							C640_razdv = true;
							C640_gluhar = false;
							break;
						}
						if( ri.Marking.ToLower().Contains(""c640/35"" ) || ri.Marking.ToLower().Contains(""04 02 03"" ) )
						{
							P400 = false;
							C640_razdv = false;
							C640_gluhar = true;
							break;
						}
					}
					ds_order.finparamcalcRow fpr = drOI.AddFinparam(idFinParam);
					if( P400 ) 
					{
						fpr.strvalue = ""P400"";
						fpr.sm = 1; fpr.smbase = 1;
					}
					if( C640_razdv ) 
					{
						fpr.strvalue = ""C640_razdv"";
						fpr.sm = 2; fpr.smbase = 2;
					}			
					if( C640_gluhar )
					{
						fpr.strvalue = ""C640_gluhar"";
						fpr.sm = 3; fpr.smbase = 3;
					}
					
					#endregion
				}
				#endregion	
				
				#region Работы City PRO
				if( drOI.idproductiontype == 1416 ) // Расчет работ по алюминию Inicial City Pro
				{
					#region Работы City
					int quRail = 0; // Количество ригелей
					int quRailWidthDrenaz = 0;
					int quRack = 0; // Количество стоек
					int quRailRack90 = 0; // количество ригелей/стоек, у которых угол запила стойки ригеля оба 90, в том числе импосты в створках
					int quRailRack45 = 0; // количество ригелей/стоек, у которых любой из углов 45
					int quBalkaHoles = 0; // Обработка пробивным : для стойки при условии навесного монтажа 1 операция на балку, для любого ригеля 1 операция
					int quGlass = 0; // Количество заполнений
					int quGlassShtapic = 0; // Количество штапиков
					int quStvorkaTurn = 0; // Количество поворотных створок
					int quStvorkaSlide = 0; // Количество раздвижных створок
					int quStvorkaTurnBalka = 0; // Количество балок поворотных створок
					int quStvorkaSlideBalka = 0; // Количество балок раздвижных створок
					int quStvorkaSlideHandle = 0; // Количество ручек раздвижных створок (по алгоритму проведал)										
					int quBottomOtliv = 0;
					
					bool frezRack = false;
					if(model.GetUserParam(2848) != null && inRange(model.GetUserParam(2848).StrValue, ""Верх"", ""Низ""))
					{
						frezRack = true;
					}
					
					string montazhType = """";
					if( model.GetUserParam(4) != null )
					{
						montazhType = model.GetUserParam(4).StrValue;
					}
					
					
					
					#region Рамные стойки/ригеля
					foreach( RamaItem ri in model.Rama )
					{
						//						if( Atechnology.ecad.Settings.idpeople == 168 )
						//						{
						//							MessageBox.Show( ""Balka. ID="" + ri.ID + "", AngNakl="" + ri.AngNakl + "", Marking="" + ri.Marking + "", Side="" + ri.Side);
						//						}
						if( model.ConstructionType.ID == 38 && ri.AngNakl == 180 && !ri.Marking.ToLower().Contains(""без"") )
						{
							quRailWidthDrenaz++;
						}
						
						if(ri.Marking.ToLower().Contains(""без"") )
						{
							continue;
						}
						else
						{
							if( ri.IsRack )
							{
								quRack++; // Количество стоек ++
								//								MessageBox.Show( drOI.name + "", "" + ri.Ang1.ToString() );
								if( inRange( ri.Ang1, 0, 90 ) && inRange( ri.Ang2, 0, 90 ) )
								{
									quRailRack90++; // ++Количество стоек/ригелей с углами 90 градусов (оба)
									//									if( drOI.idconstructiontype == 13 ) MessageBox.Show( ""E"" );
								}
								else
								{
									quRailRack45++; // ++Количество стоек/ригелей с любым из углов 45 градусов
								}
								
								switch( montazhType )
								{
									case ""От плиты до плиты перекрытия"": 
										break;
									case ""Навесной"":
										quBalkaHoles++; // Обработка пробивным : для стойки при условии навесного монтажа 1 операция на балку, 
										break;
								}
								
							}
							else if( ri.IsRail )
							{
								//								MessageBox.Show( drOI.name + "", "" + ri.Ang1.ToString() );
								quRail++; // Количество ригелей ++
								if( inRange( ri.Ang1, 0, 90 ) && inRange( ri.Ang2, 0, 90 ) )
								{
									quRailRack90++; // ++Количество стоек/ригелей с углами 90 градусов (оба)
									//									if( drOI.idconstructiontype == 13 ) MessageBox.Show( ""F"" );
								}
								else
								{
									quRailRack45++; // ++Количество стоек/ригелей с любым из углов 45 градусов
								}
								quBalkaHoles++; // Обработка пробивным : для любого ригеля 1 операция
								
								if( ri.AngNakl == 180 &&  inRange( ri.Marking, ""17 09 02"" ) )
								{
									if( ""17 07 01, 17 07 02, 17 07 03, 17 07 04, 17 07 06"".Contains( ri.BalkaStart.Marking.Replace(""#"","""") )
										|| ""17 07 01, 17 07 02, 17 07 03, 17 07 04, 17 07 06"".Contains( ri.BalkaEnd.Marking.Replace(""#"","""") ) ) 
									
									{
										quBottomOtliv += 1;
									}
								}
							}
							
						}						
					}
					#endregion
					//					if( Atechnology.ecad.Settings.idpeople == 168 )
					//					{
					//						MessageBox.Show( ""2 A="" + quRailWidthDrenaz );
					//					}
					#region Средние (импостные) стойки/ригеля
					foreach( Impost ri in model.ImpostList )
					{
						if(ri.Marking.ToLower().Contains(""без"") || inRange( ri.Marking, ""Сцепка"" ) )
						{
							continue;
						}
						else if( ri.Stvorka == null && !inRange( ri.Marking, ""Сцепка"", ""04 01 07"" ) ) // Импосты не в створках (ригеля/стойки)
						{
							if( ri.IsRack )
							{
								quRack++; // Количество стоек ++
								if( inRange( ri.Ang1, 0, 90 ) && inRange( ri.Ang2, 0, 90 ) )
								{
									quRailRack90++; // ++Количество стоек/ригелей с углами 90 градусов (оба)
									//									if( drOI.idconstructiontype == 13 ) MessageBox.Show( ""D"" );
								}
								else
								{
									quRailRack45++; // ++Количество стоек/ригелей с любым из углов 45 градусов
								}
								
								switch( montazhType )
								{
									case ""От плиты до плиты перекрытия"": 
										break;
									case ""Навесной"":
										quBalkaHoles++; // Обработка пробивным : для стойки при условии навесного монтажа 1 операция на балку, 
										break;
								}
								
								// Проверяю также если эта стойка упирается в ригель через ""Т"" соединение, то считаю ее ""Ригелем"", т.к. там есть такая же фрезеровка и закладные
								
								if( ri.Connect1 == SoedType.Korotkoe || ri.Connect2 == SoedType.Korotkoe )
								{
									quRail++;
								}
								
							}
							else if( ri.IsRail )
							{
								quRail++; // Количество ригелей ++
								if( inRange( ri.Ang1, 0, 90 ) && inRange( ri.Ang2, 0, 90 ) )
								{
									quRailRack90++; // ++Количество стоек/ригелей с углами 90 градусов (оба)
									//									if( drOI.idconstructiontype == 13 ) MessageBox.Show( ""C"" );
								}
								else
								{
									quRailRack45++; // ++Количество стоек/ригелей с любым из углов 45 градусов
								}
								quBalkaHoles++; // Обработка пробивным : для любого ригеля 1 операция
								
								if( model.ConstructionType.ID == 38 && ( ri.AngNakl == 180 || ri.AngNakl == 0 ) && !ri.Marking.ToLower().Contains(""без"") )
								{
									quRailWidthDrenaz++;
								}
							}
							
						}
						else if( ri.Stvorka != null )
						{
							//							MessageBox.Show( ""A"" );
							quRailRack90++;  // количество импостов в створках
						}
						else if( inRange( ri.Marking, ""04 01 07"" ) )
						{
							//MessageBox.Show( ""B"" );
							quRailRack90++;  // стык
						}
					}
					#endregion
					
					
					//					if( Atechnology.ecad.Settings.idpeople == 168 )
					//					{
					//						MessageBox.Show( ""2 A="" + quRailWidthDrenaz );
					//					}
					//						
					
					#region Подсчет заполнений
					foreach( Glass g in model.GlassList )
					{
						if(g.Marking.ToLower().Contains(""без_стекла_и_штапика"") || g.FillType == FillType.NotFill )
						{
							continue;
						}
						if(g.ModelPart==ModelPart.Stvorka) // Створка
						{
							quGlassShtapic++;
						}
						else // Глухарь 
						{
							quGlass++;
							quGlassShtapic++;
						}
						//						if( Atechnology.ecad.Settings.idpeople == 168 )
						//						{
						//							MessageBox.Show( ""drOI="" + drOI.name + "", quGlass="" + quGlass + "", "" + g.FillType );
						//						}
					}
					#endregion
					
					//					if( Atechnology.ecad.Settings.idpeople == 168 )
					//					{
					//						MessageBox.Show( ""drOI="" + drOI.name + "", quGlass="" + quGlass );
					//					}
					
					#region Подсчет створок ( поворотные / раздвижные )
					foreach( Stvorka s in model.StvorkaList )
					{
						if( s.otkrivanieType == OtkrivanieType.Razd )
						{
							quStvorkaSlide++;
							//Балки створки
							foreach(StvorkaItem si in s)
							{
								if(si.Marking.ToLower().Contains(""без""))
									continue;
								quStvorkaSlideBalka++;
							}
						}
						else if( s.otkrivanieType == OtkrivanieType.Pov ||  s.otkrivanieType == OtkrivanieType.PovOtk )
						{
							quStvorkaTurn++;
							//Балки створки
							foreach(StvorkaItem si in s)
							{
								if(si.Marking.ToLower().Contains(""без""))
									continue;
								quStvorkaTurnBalka++;
							}
						}
					}
					
					// Алгоритм ручек Provedal
					if( quStvorkaSlide > 0 )
					{
						if( quStvorkaSlide > 3 )
						{
							quStvorkaSlideHandle = quStvorkaSlide - 1;
						}
						else
						{
							quStvorkaSlideHandle = quStvorkaSlide;
						}
					}
					#endregion
					
					#region Добавление работ

					if(quRailRack90>0)
					{
						//						MessageBox.Show( ""QRR90="" + quRailRack90 );
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Резка стоек и ригелей под 90 градусов"",quRailRack90);
					}
					if(quRailRack45>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Резка стоек и ригелей под 45 градусов"",quRailRack45);
					}
					if(quBalkaHoles>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Обработка пробивным стойки ригеля"",quBalkaHoles);
					}
					if(quRail>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка"",quRail);

						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Установка закладных"",quRail*2);
						
						/*
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Установка закладных ригельных"",quRail);
					*/
					}
					
					if( quBottomOtliv > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка"",quBottomOtliv+1);
					}
					if(quRack>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Сборка рамы /обжим"",quRack);
						
						if(frezRack)
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
							Order.DocWork.AddWorkOperForItem(""Фрезировка стойки"",quRack);
						}
					}
					if(quGlass>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Запакетка+обрезинка перегородки"",quGlass);
					}
					
					if(quGlassShtapic>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Распил штапика рама + створка"",quGlassShtapic*4);
					}
					if(quStvorkaTurn>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Установка фурнитуры"",quStvorkaTurn);

						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Навешивание на раму"",quStvorkaTurn);

						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Запакетка+обрезинка поворотной створки"",quStvorkaTurn);

						if(quStvorkaTurnBalka>0)
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
							Order.DocWork.AddWorkOperForItem(""Резка створки"",quStvorkaTurnBalka);

							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
							Order.DocWork.AddWorkOperForItem(""Обработка пробивным поворотной створки"",quStvorkaTurnBalka);

							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
							Order.DocWork.AddWorkOperForItem(""Обжим створки /сборка на закладные"",quStvorkaTurnBalka);
						}
					}
					if(quStvorkaSlide>0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Установка фетра с640/10.11"",quStvorkaSlide*3);
	
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Установка роликов"",quStvorkaSlide*1);

						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Сборка раздвижной створки"",quStvorkaSlide*1);

						if(quStvorkaSlideBalka>0)
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
							Order.DocWork.AddWorkOperForItem(""Распил створки с640/10.11.12"",quStvorkaSlideBalka);

							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
							Order.DocWork.AddWorkOperForItem(""Обработка пробивным раздвижной створки"",(int)(quStvorkaSlideBalka/2));
						}
						
						if(quStvorkaSlideHandle>0)
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
							Order.DocWork.AddWorkOperForItem(""Фрезеровка раздвижной створки под ручку"",quStvorkaSlideHandle*1);

							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
							Order.DocWork.AddWorkOperForItem(""Установка ручек"",quStvorkaSlideHandle*1);
						}
					}
					
					if( quRailWidthDrenaz>0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление City"");
						Order.DocWork.AddWorkOperForItem(""Дренаж"",quRailWidthDrenaz);
					}
					
					#endregion Добавление работ
					
					#endregion
	
				}
				#endregion
				dtLogs += ""\n end jobs city pro "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
				#region Работы Inicial IF50 SSG
				if( inRange( drOI.idproductiontype, 820, 1644, 1678, 2074, 2088 ) && !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 139, 215 ) ) // Расчет работ по алюминию IF50 SSG				
				{
					#region Счетчики
					int quRamaBalka = 0;
					int quStvorkaBalka = 0;
					int quShtapik = 0;
					int quFurn = 0;
					
					foreach( RamaItem ri in model.Rama )
					{
						if( ri.Marking.ToLower().Contains(""без"") ) continue;
						quRamaBalka++;
					}
					
					foreach( Stvorka s in model.StvorkaList )
					{
						if( !s.FurnitureSystem.ToLower().Contains(""без"") ) quFurn++;
						foreach( StvorkaItem si in s )
						{
							if( si.Marking.ToLower().Contains(""без"") ) continue;
							quStvorkaBalka++;
						}
					}
					
					foreach( Glass g in model.GlassList )
					{
						if(g.Marking.ToLower().Contains(""без_стекла_и_штапика""))
						{
							continue;
						}
						quShtapik += g.Count;
					}
					#endregion
					
					#region Добавление работ
					if( quRamaBalka + quStvorkaBalka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление SSG"");
						Order.DocWork.AddWorkOperForItem(""Распил профиля"",quRamaBalka + quStvorkaBalka);
					}
					if( quShtapik > 0 ) 
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление SSG"");
						Order.DocWork.AddWorkOperForItem(""Распил штапика"",quShtapik);
					}
					if( quFurn > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление SSG"");
						Order.DocWork.AddWorkOperForItem(""Установка фурнитуры"",quFurn);
					}
					#endregion
					
					
				}
				#endregion
				
				#region Работы IW63, IF50 SSG
				if( 
					( 
					( inRange( drOI.idproductiontype, 820, 1644, 1678, 1694, 1714, 1932, 1976, 2074, 2088, 2096, 2101, 2148,2166, 2140, 2211 ) ) && 
					( inRange( drOI.profsys_name, ""Inicial IW63"", ""Inicial IF50 SSG"", ""Inicial IW70"", ""Татпроф МП-65"", ""Татпроф МП-72"", ""Татпроф МП-72 ТЕРМО"", 
					""Татпроф TWS50"" , ""Татпроф TS-65"", ""Татпроф TS-72"", ""Татпроф TS-72 HI"", ""Inicial IW70D"", ""Inicial IW70D HI"", ""Inicial IW62D"", ""Inicial IW62"" ) ) 
					) || 
					( 
					( drOI.idproductiontype == 112 ) && 
					( inRange( drOI.profsys_name, ""Inicial IW63"", ""Inicial IF50 SSG"", ""Inicial IW70"", ""Татпроф МП-65"", ""Татпроф МП-72"", ""Татпроф МП-72 ТЕРМО"",
					""Татпроф TWS50"", ""Татпроф TS-65"", ""Татпроф TS-72"", ""Татпроф TS-72 HI"", ""Inicial IW70D"", ""Inicial IW70D HI"", ""Inicial IW62D"", ""Inicial IW62"" ) ) && 
					( drOI.IsparentidNull()  ) 
					)  
					) // Расчет работ по алюминию IW63
				{									
					Err=""24"";
					#region Работы Inicial IW63
					//Кол-во балок
					int quBeem = 0;
					int quRama = 0;
					int quStvorka = 0;
					int quStvorkaAct = 0;
					int quGlassShtapic = 0;
					
					int quStvorkaActDoor = 0;
					int quGlassGluhar2 = 0;
					int quGlassStvorka2 = 0;
					int quGlassStvorka = 0;
					int quGlassGluhar = 0;
					int quSecondZamok = 0;
					int quHandleWithHoles = 0;
					int quFurnAxorAluHide = 0;
					int quFurnAxorAluHideP = 0;
					int quFurnAxorAluHidePO = 0;
					int quFurnAxorAluHideO = 0;
					
					int quBalkaRama = 0;
					int quBalkaStvorka = 0;
					int quBalkaPorog = 0;
					int quBalkaImpost = 0;
					
					int quManualDist = 0;
					
					// bool d = Atechnology.ecad.Settings.idpeople == 168 || Atechnology.ecad.Settings.idpeople == 7228;
					
					int quStublinaPodves = 0;
					
					#region Расчет работ для Inicial IW70D, Inicial IW62D
					if( inRange( drOI.idprofsys, 113, 156, 217, 218, 219, 220, 221, 223, 244 ) )
					{
						foreach( RamaItem ri in model.Rama )
						{
							if( ri.Marking.ToLower().Contains(""без"") ) continue;
						
							//
							if( ri.RamaType == RamaType.Rama)
							{
								quBalkaRama++;
							} 
							else if( ri.RamaType == RamaType.Porog )
							{
								quBalkaPorog++;
							}
						}
					
						foreach( Impost i in model.ImpostList )
						{
							if( i.Marking.ToLower().Contains(""без"") || i.Marking.ToLower().Contains(""штульп"") ) continue;
							quBalkaImpost++;
						}
					
						foreach( Stvorka s in model.StvorkaList )
						{
							foreach( StvorkaItem si in s )
							{
								if( si.Marking.ToLower().Contains(""без"") ) continue;
							
								quBalkaStvorka++;
							}
							
							if( s.otkrivanieType == OtkrivanieType.Podves && !drOI.IsidfurnsysNull() && inRange( drOI.idfurnsys, 242, 200 ) )
							{
								quStublinaPodves ++;
							}
						}
						
						//						MessageBox.Show( ""quBalkaRama="" + quBalkaRama + "", quBalkaPorog="" + quBalkaPorog + "", quBalkaImpost="" + quBalkaImpost + "", quBalkaStvorka="" + quBalkaStvorka );
					}
					#endregion

					#region Дистанционка ручная
					if ( drOI.GetFinparam(623) != null )
					{
						quManualDist = (int)(drOI.GetFinparam(623).sm);
					}
					#endregion
					
					foreach (Glass g in model.GlassList)
					{
						//MessageBox.Show(g.Marking);
						
						if( !( g.Marking.ToLower().Contains(""без"") ) ) 
						{ 
							
						
							foreach( GlassItem gi in g )
							{
								quGlassShtapic++;
								//MessageBox.Show(gi.Lenght.ToString());
								
								if( gi.Lenght < 50 )
								{
									Order.AddErrorUnical(drOI.idorderitem,""о098"");
									break;
								}
							}

							if( g.ModelPart==ModelPart.Stvorka )
							{
								quGlassStvorka++; // Количество запакеток створок
							}
							else
							{
								quGlassGluhar++; // Количество запакеток глухарей
							}
						}
						
						
						if (g.ModelPart==ModelPart.Stvorka)
						{
							quGlassStvorka2++; //Створка
						}
						else
						{
							quGlassGluhar2++; //Глухарь 
						}							
					}
					
					
					// Количество рам в одной модели всегда = 1
					quRama = 1;
					// Количество створок
					foreach( Stvorka s in model.StvorkaList )
					{
						quStvorka++;
						
						if( s.ShtulpExist == ShtulpExist.NonExist || s.ShtulpExist == ShtulpExist.NoShtulp )
						{
							quStvorkaAct++;
							if( inRange( model.ConstructionType.ID, 6, 7, 35, 36 ) ||  inRange(drOI.idproductiontype, 2166)) quStvorkaActDoor++; 
						}
						
						if( s.HandlePosition > 0 && s.Shtulp==null && inRange( s.GetUserParam(""Второй замок"").StrValue, ""Ригель-защелка"", ""Ригель-ролик"" ) )
						{
							quSecondZamok ++;
						}
						
						try
						{
							UserParam u2 = s.GetUserParam(""Сверлить отверстия под ручку"");
							if( u2 != null )
							{
								if( u2.StrValue.ToLower() == ""да"" && u2.Visible ) quHandleWithHoles ++;
							}
						}
						catch( Exception E )
						{
								
						}
						
						if( !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 156 ) && !drOI.IsidfurnsysNull() && inRange( drOI.idfurnsys, 174 ) )
						{
							quFurnAxorAluHide++;
							
							switch( s.otkrivanieType )
							{
								case OtkrivanieType.Pov:
									quFurnAxorAluHideP++;
									break;
								case OtkrivanieType.PovOtk:
									quFurnAxorAluHidePO++;
									break;
								case OtkrivanieType.Otk:
									quFurnAxorAluHideO++;
									break;
							}
						}
					}
					
					
					//					//Кол-во закладных
					//					int quZakl = 0;

					//Балки рамы
					foreach(RamaItem ri in model.Rama)
					{
						
						if(ri.Marking.ToLower().Contains(""без""))
						{
							continue;
						}
						else
						{
							//	quBeem++;
						}
					}
				
					#region Добавление работ IW63
					if( ( quRama + quStvorka ) > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IW63"");
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
						Order.DocWork.AddWorkOperForItem(""Клипсование контура"",quRama + quStvorka);
					}
					if( quGlassGluhar2 + quGlassStvorka2 > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IW63"");
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
						// 						Order.DocWork.AddWorkOperForItem(""Установка уплотнителя"",quRama + quStvorka);
						Order.DocWork.AddWorkOperForItem(""Установка уплотнителя"",(  quGlassGluhar2 * 1 + quGlassStvorka2 * 1 ) * 2 ); // У каждого пакета по 2 уплотнителя
					}
					if( ( quStvorka ) > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IW63"");
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
						if( quStvorkaActDoor > 0 ) // дверь наружу, дверь внутрь
						{
							Order.DocWork.AddWorkOperForItem(""Фрезеровка отверстий под дверную фурнитуру"",quStvorkaActDoor*3);
						}
						else // окна
						{
							Order.DocWork.AddWorkOperForItem(""Фрезеровка отверстий под оконную фурнитуру"",quStvorka);
						}
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IW63"");
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
						// 						Order.DocWork.AddWorkOperForItem(""Установка уплотнителя"",quRama + quStvorka);
						Order.DocWork.AddWorkOperForItem(""Установка уплотнителя"", quStvorka + quStvorkaAct ); // У каждой створки 1 уплотнителя притвора на самой створке + количество контуров (рам) по количеству активных створок

						// Фурнитура
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IW63"");
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
						if( inRange( drOI.idconstructiontype, 6, 7 ) && quStvorka - quFurnAxorAluHide > 0) // дверь наружу, дверь внутрь
						{
							Order.DocWork.AddWorkOperForItem(""Установка дверной фурнитуры"",quStvorka - quFurnAxorAluHide);
						}
						else // окна
						{
							Order.DocWork.AddWorkOperForItem(""Установка оконной фурнитуры"",quStvorka - quFurnAxorAluHide);
						}
						
						if( quStublinaPodves > 0 )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
							Order.DocWork.AddWorkOperForItem(""Фрезеровка отверстий под оконную фурнитуру Stublina"",quStublinaPodves);
						}
						
						if( quFurnAxorAluHide > 0 )
						{
							if( quFurnAxorAluHideP > 0 )
							{
								// Фурнитура Axor скрытая
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
								Order.DocWork.AddWorkOperForItem(""Монтаж фурнитуры поворотной скрытой"",quFurnAxorAluHideP);
							}
							if( quFurnAxorAluHideO > 0 )
							{
								// Фурнитура Axor скрытая
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
								Order.DocWork.AddWorkOperForItem(""Монтаж фурнитуры откидной скрытой"",quFurnAxorAluHideO);
							}
							if( quFurnAxorAluHidePO > 0 )
							{
								// Фурнитура Axor скрытая
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
								Order.DocWork.AddWorkOperForItem(""Монтаж фурнитуры поворотно-откидной скрытой"",quFurnAxorAluHidePO);
							}
						}							
					}
					#region Запакетка IW63
					if( quGlassStvorka + quGlassGluhar > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление IW63"");
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
						Order.DocWork.AddWorkOperForItem(""Установка заполнений"", quGlassStvorka + quGlassGluhar );
					}
					#endregion
					#region Второй замок
					if( quSecondZamok > 0 ) // Установка фурнитуры дверь
					{
						ds_docwork.docworkRow drw = AddWorkByName( Order, drOI, ""Изготовление IW63"", ""Установка дверной фурнитуры"", quSecondZamok );
					}
					
					#endregion

					if( quHandleWithHoles > 0 )
					{
						ds_docwork.docworkRow drw = AddWorkByName( Order, drOI, ""Изготовление IW63"", ""Фрезеровка под ручку-скобу"", quHandleWithHoles );
					}
							
					#endregion
					
					if( quManualDist > 0 )
					{
						// Установка ручного привода дистанционного открывания
						ds_docwork.docworkRow drw = AddWorkByName( Order, drOI, ""Изготовление IW63"", ""Установка ручного привода дистанционного открывания"", quManualDist );
					}
					
					#region Добавление работ Inicial IW70D, Inicial IW62D
					if( inRange( rootProduction.idprofsys, 113, 156, 217, 218, 219, 220, 221, 223, 244 ) )
					{
						if( quBalkaRama + quBalkaStvorka + quBalkaImpost + quBalkaPorog > 0 )
						{
							decimal qu = quBalkaRama + quBalkaStvorka + quBalkaImpost + quBalkaPorog;
							
							if( inRange( drOI.idconstructiontype, 6, 7 ) )
							{
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
								Order.DocWork.AddWorkOperForItem(""Распил дверного профиля"",qu);
							}
							else
							{
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
								Order.DocWork.AddWorkOperForItem(""Распил оконного профиля"",qu);
							}
						}
						
						if( quBalkaImpost + quBalkaPorog > 0 )
						{
							decimal qu = quBalkaImpost + quBalkaPorog;
							
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
							Order.DocWork.AddWorkOperForItem(""Торцовка ригеля, импоста, порога"",qu);
							
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
							Order.DocWork.AddWorkOperForItem(""Установка импоста, порога"",qu);
						}
					}
					
					
					#endregion
					
					#endregion
					
					#region Заготовка штапика IW63
					if( !rootProduction.IsidprofsysNull() && inRange( rootProduction.idprofsys, 113, 156, 217, 218, 219, 220, 221, 223, 244 ) )
					{
						if( quGlassShtapic > 0 )
						{
							decimal qu = quGlassShtapic;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление IW63"");
							Order.DocWork.AddWorkOperForItem(""Заготовка штапика"",qu);
						}
					}
					#endregion
				}
				#endregion
				
				#region Работы МП-58
				if( inRange( Atechnology.ecad.Settings.idpeople, 168, 2206 ) &&
					( 
					( inRange( drOI.idproductiontype, 1860 ) ) && 
					( inRange( drOI.profsys_name, ""Татпроф МП-58"" ) ) 
					) || 
					( 
					( drOI.idproductiontype == 112 ) && 
					( inRange( drOI.profsys_name, ""Татпроф МП-58"" ) ) && 
					( drOI.IsparentidNull()  ) 
					)  
					) // Расчет работ по алюминию Татпроф МП-58
				{									
					Err=""24"";
					#region Работы Татпроф МП-58
					int quRama = 0;
					int quStvorka = 0;
					int quStvorkaAct = 0;
					int quGlassGluhar2 = 0;
					int quGlassStvorka2 = 0;
					int quGlassStvorka = 0;
					int quGlassGluhar = 0;
					int quFurnP = 0;
					int quFurnO = 0;
					int quFurnPO = 0;
					int quFurnAxorAluHideP = 0;
					int quFurnAxorAluHidePO = 0;
					int quFurnAxorAluHideO = 0;

					foreach (Glass g in model.GlassList)
					{
						if( !( g.Marking.ToLower().Contains(""без"") ) ) 
						{ 
							foreach( GlassItem gi in g )
							{
								if( gi.Lenght < 50 )
								{
									Order.AddErrorUnical(drOI.idorderitem,""о098"");
									break;
								}
							}

							if( g.ModelPart==ModelPart.Stvorka )
							{
								quGlassStvorka++; // Количество запакеток створок
							}
							else
							{
								quGlassGluhar++; // Количество запакеток глухарей
							}
						}
						
						
						if (g.ModelPart==ModelPart.Stvorka)
						{
							quGlassStvorka2++; //Створка
						}
						else
						{
							quGlassGluhar2++; //Глухарь 
						}							
					}
					
					
					// Количество рам в одной модели всегда = 1
					quRama = 1;
					// Количество створок
					foreach( Stvorka s in model.StvorkaList )
					{
						quStvorka++;
						
						if( s.ShtulpExist == ShtulpExist.NonExist || s.ShtulpExist == ShtulpExist.NoShtulp )
						{
							quStvorkaAct++;
						}						
						if( !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 172 ) && !drOI.IsidfurnsysNull() && inRange( drOI.idfurnsys, 174 ) )
						{
							// quFurnAxorAluHide++;
							
							switch( s.otkrivanieType )
							{
								case OtkrivanieType.Pov:
									quFurnAxorAluHideP++;
									break;
								case OtkrivanieType.PovOtk:
									quFurnAxorAluHidePO++;
									break;
								case OtkrivanieType.Otk:
									quFurnAxorAluHideO++;
									break;
							}
						}
						else
						{
							switch( s.otkrivanieType )
							{
								case OtkrivanieType.Pov:
									quFurnP++;
									break;
								case OtkrivanieType.PovOtk:
									quFurnPO++;
									break;
								case OtkrivanieType.Otk:
									quFurnO++;
									break;
							}
						}
					}
					
				
					#region Добавление работ Татпроф МП-58
					if( ( quRama + quStvorka ) > 0)
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
						Order.DocWork.AddWorkOperForItem(""Клипсование контура"",quRama + quStvorka);
					}
					
					if( quGlassGluhar2 > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
						Order.DocWork.AddWorkOperForItem(""Установка уплотнителя (рама)"",quGlassGluhar2 ); // У каждого пакета по 2 уплотнителя
					}

					if( quGlassStvorka2 > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
						Order.DocWork.AddWorkOperForItem(""Установка уплотнителя (створка)"",quGlassStvorka2 ); // У каждого пакета по 2 уплотнителя
					}
					
					if( ( quStvorka ) > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка отверстий под фурнитуру"",quStvorkaAct);
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
						Order.DocWork.AddWorkOperForItem(""Установка уплотнителя (створка)"", 3 * ( quStvorka ) ); // У каждой створки 1 уплотнителя притвора на самой створке + количество контуров (рам) по количеству активных створок

						if( quFurnAxorAluHideP > 0 )
						{
							// Фурнитура Axor скрытая
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
							Order.DocWork.AddWorkOperForItem(""Монтаж фурнитуры поворотной скрытой"",quFurnAxorAluHideP);
						}
						if( quFurnAxorAluHideO > 0 )
						{
							// Фурнитура Axor скрытая
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
							Order.DocWork.AddWorkOperForItem(""Монтаж фурнитуры откидной скрытой"",quFurnAxorAluHideO);
						}
						if( quFurnAxorAluHidePO > 0 )
						{
							// Фурнитура Axor скрытая
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
							Order.DocWork.AddWorkOperForItem(""Монтаж фурнитуры поворотно-откидной скрытой"",quFurnAxorAluHidePO);
						}
						if( quFurnP > 0 )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
							Order.DocWork.AddWorkOperForItem(""Монтаж фурнитуры поворотной"",quFurnP);
						}
						if( quFurnO > 0 )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
							Order.DocWork.AddWorkOperForItem(""Монтаж фурнитуры откидной"",quFurnO);
						}
						if( quFurnPO > 0 )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
							Order.DocWork.AddWorkOperForItem(""Монтаж фурнитуры поворотно-откидной"",quFurnPO);
						}
					}
					#region Запакетка Татпроф МП-58
					if( quGlassStvorka + quGlassGluhar > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление МП-58"");
						Order.DocWork.AddWorkOperForItem(""Установка заполнения"", quGlassStvorka + quGlassGluhar );
					}
					#endregion
		
					#endregion
					
					#endregion
				}
				#endregion
				dtLogs += ""\n end mp 45 jobs "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
				#region Работы МП-640
				if( /* inRange( Atechnology.ecad.Settings.idpeople, 168 ) && */ !drOI.IsidprofsysNull() && drOI.idprofsys == 208 && !drOI.IsidconstructiontypeNull() && inRange( drOI.idconstructiontype, 38, 13 ) )
				{
					ds_docwork.docworkRow drw = null;
					if( drOI.idconstructiontype==38 )
					{
						bool d1 = Atechnology.ecad.Settings.idpeople == 168;
						
						bool mur = Atechnology.ecad.Settings.idpeople == 7889;
						if (mur)
						{
							//							decimal _wide = 0;
							//							string sql = @""select distinct secnum, secwidth from alumparts where idorderitem=""+drOI.idorderitem.ToString()+"" and secnum>0"";
							//							DataTable tableTemp = new DataTable();
							//							//DBConnections2.dbconn _db1 = new DBConnections2.dbconn(); 
							//							_db.command.CommandText = sql;
							//							_db.OpenDB();
							//							_db.adapter.Fill(tableTemp);
							//							_db.CloseDB();
							//							if (tableTemp.Select().Length>0)
							//							{
							//								foreach( DataRow drVal in tableTemp.Select() )
							//								{
							//									_wide += Useful.GetDecimal( drVal[""secwidth""], 0 );
							//								}
							//							}
							//decimal _H = drOI.height;
							//drw = AddWorkByID( Order, drOI, 1883, _H/1000);
						}
						
						// Витраж (каркас)
						decimal quBalkaKarkas = 0; 
						decimal quBalkaKarkas90 = 0; 
						decimal quShtapikKarkas = 0;
						decimal quGlassGluhar = 0;
						decimal quGlassStvorka = 0;
						decimal quRacks = 0;
						decimal quRails = 0;
						decimal quDrenaz = 0;
						decimal quSections = drOI.sqr;
						
						decimal q = 1;
						
						foreach( RamaItem ri in model.Rama )
						{
							if( !ri.Marking.ToLower().Contains(""без"") && ri.LengthInterfaceCalcInt > 10 ) 
							{
								quBalkaKarkas++;
								
								quBalkaKarkas90 += ( inRange( ri.Ang1, 0, 90 ) && inRange( ri.Ang2, 0, 90 ) ) ?1:0;
								
								
								//								if( d1 ) MessageBox.Show( ""00. ID="" + ri.ID + "", ri.AngleHorisont="" + ri.AngleHorisont + "", ri.Len="" + ri.LengthInterfaceCalcInt + "", ri.Marking="" + ri.Marking + "", quBalkaKarkas90="" + quBalkaKarkas90 + "", quBalkaKarkas="" + quBalkaKarkas );
								
								if( ri.IsRack )
								{
									quRacks++;
								}
								else if( ri.IsRail )
								{
									quRails++;
									
									if( ri.AngleHorisont == 180 ) 
									{
										// https://servicedesk.it-swarm.pro/browse/DEV-120140
										// CountDrenazh( ri, ref quDrenaz );
										quDrenaz++;
									}
								}
							}
						}
						//						if( d1 ) MessageBox.Show( ""1. quBalkaKarkas90="" + quBalkaKarkas90 + "", quBalkaKarkas="" + quBalkaKarkas );
						
						foreach( Impost ri in model.ImpostList )
						{
							if( !ri.Marking.ToLower().Contains(""без"") && ri.LengthInterfaceCalcInt > 10 ) 
							{
								quBalkaKarkas++;
								quBalkaKarkas90 += ( inRange( ri.Ang1, 0, 90 ) && inRange( ri.Ang2, 0, 90 ) ) ?1:0;
								if( ri.IsRack )
								{
									quRacks++;
								}
								else if( ri.IsRail )
								{
									quRails++;
									
									if( inRange( ri.AngleHorisont, 0, 180 ) ) 
									{
										// https://servicedesk.it-swarm.pro/browse/DEV-120140
										// CountDrenazh( ri, ref quDrenaz );
										quDrenaz++;
									}
								}
							}
						}
						//						if( d1 ) MessageBox.Show( ""2. quBalkaKarkas90="" + quBalkaKarkas90 + "", quBalkaKarkas="" + quBalkaKarkas );
						foreach( Glass g in model.GlassList )
						{
							if( !g.Marking.ToLower().Contains(""без_стекла_и_штапика"") )
							{
								if( g.ModelPart==ModelPart.Stvorka )
								{
									quGlassStvorka++;
								}
								else
								{
									quGlassGluhar++;
								}
							}
						}
						
						
						// Изготовление МП-640						
						if( quBalkaKarkas90 > 0 )
						{
							q = quBalkaKarkas90 /* *2 */;
							
							drw = AddWorkByID( Order, drOI, 1873, q ); // Изготовление МП-640/ Распил профиля 90 градусов (каркас)
							
							//							if( d1 ) MessageBox.Show( ""quBalkaKarkas90="" + quBalkaKarkas90 + "", quBalkaKarkas="" + quBalkaKarkas );
							
							/*
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МП-640"");
							drw = Order.DocWork.AddWorkOperForItem(""Распил профиля 90 градусов (каркас)"",q);
							*/
						}
						if( quBalkaKarkas - quBalkaKarkas90 > 0 )
						{
							q = (quBalkaKarkas - quBalkaKarkas90) /* *2 */;
							
							drw = AddWorkByID( Order, drOI, 2065, q ); // Изготовление МП-640/ Распил стоек + ригеля не 90 градусов
						}
						
						if( quGlassGluhar + quGlassStvorka > 0 )
						{
							q = ( quGlassGluhar + quGlassStvorka )*4;
							drw = AddWorkByID( Order, drOI, 1874, q ); // Изготовление МП-640/ Распил штапика (каркас)
							/*
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МП-640"");
							drw = Order.DocWork.AddWorkOperForItem(""Распил штапика (каркас)"",q);
							*/
							
						}
						if( quRails > 0 )
						{
							q = quRails*2;
							drw = AddWorkByID( Order, drOI, 1876, quRails ); // Изготовление МП-640/ Торцевание
							//							drw = AddWorkByID( Order, drOI, 1877, q ); // Изготовление МП-640/ Пробитие отверстий под крепление (горизонтальная балка)
							drw = AddWorkByID( Order, drOI, 1879, q ); // Изготовление МП-640/ Установка закладных ригельных
							
							/*
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МП-640"");
							drw = Order.DocWork.AddWorkOperForItem(""Торцевание"",q);	
							drw = Order.DocWork.AddWorkOperForItem(""Пробитие отверстий под крепление (горизонтальная балка)"",q);
							drw = Order.DocWork.AddWorkOperForItem(""Установка закладных ригельных"",q);
							*/
						}
						if( quDrenaz > 0 )
						{
							q = quDrenaz;
							
							drw = AddWorkByID( Order, drOI, 1878, q ); // Изготовление МП-640/ Дренаж
							/*
							
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МП-640"");
							drw = Order.DocWork.AddWorkOperForItem(""Дренаж"",q);
							*/
						}
						if( quSections > 0 )
						{
							// Сборка сегмента каркаса
							q = quSections;
							
							drw = AddWorkByID( Order, drOI, 1883, q ); // Изготовление МП-640/ Сборка сегмента каркаса
							drw = AddWorkByID( Order, drOI, 1905, q ); // Изготовление МП-640/ Наклейка логистических этикеток на секции
							
							/*
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МП-640"");
							drw = Order.DocWork.AddWorkOperForItem(""Сборка сегмента каркаса"",q);
							drw = Order.DocWork.AddWorkOperForItem(""Наклейка логистических этикеток на секции"",q);
							*/
						}
						if( quGlassGluhar > 0 )
						{
							q = quGlassGluhar;
							
							//							drw = AddWorkByID( Order, drOI, 1884, q ); // Изготовление МП-640/ Установка заполнения
							/*
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МП-640"");
							drw = Order.DocWork.AddWorkOperForItem(""Установка заполнения"",q);
							*/
						}
						
						
					}
					else if( drOI.idconstructiontype==13 )
					{
						ds_order.orderitemRow drOIVitrazh = null;
						
						if( !drOI.IsparentidNull() )
						{
							foreach( ds_order.orderitemRow drVitr in Order.ds.orderitem.Select(""deleted is null and parentid="" + drOI.parentid + "" and idconstructiontype=38"" ) )
							{
								drOIVitrazh = drVitr;
								break;
							}
						}
						
						decimal quGlassStvorka = 0;
						decimal quGlassGluhar = 0;
						
						foreach( Glass g in model.GlassList )
						{
							if( !g.Marking.ToLower().Contains(""без_стекла_и_штапика"") )
							{
								if( g.ModelPart==ModelPart.Stvorka )
								{
									quGlassStvorka++;
								}
								else
								{
									quGlassGluhar++;
								}
							}
						}
						
						if( quGlassGluhar + quGlassStvorka > 0 )
						{
							decimal qq = ( quGlassGluhar + quGlassStvorka )*4;
							drw = AddWorkByID( Order, drOI, 1874, qq ); // Изготовление МП-640/ Распил штапика (каркас)
							/*
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МП-640"");
							drw = Order.DocWork.AddWorkOperForItem(""Распил штапика (каркас)"",q);
							*/
							
						}
						
						// Изготовление МП-640
						decimal q = 0;
						
						decimal quStvorkaPov = 0;
						decimal quStvorkaTypePov = 0;
						decimal quStvorkaTypePovOtk = 0;
						decimal quStvorkaPovDrenazh = 0;
						decimal quStvorkaRaz = 0;
						foreach( Stvorka s in model.StvorkaList ) 
						{
							if( s.otkrivanieType == OtkrivanieType.Pov || s.otkrivanieType == OtkrivanieType.PovOtk )
							{
								quStvorkaPov++;
								/*
								if( s.Width <= 700 )
								{
									quStvorkaPovDrenazh += 2;
								}
								else
								{
									quStvorkaPovDrenazh += 3;
								}
				*/
								quStvorkaPovDrenazh++;
								
								if( s.otkrivanieType == OtkrivanieType.Pov ) quStvorkaTypePov++;
								if( s.otkrivanieType == OtkrivanieType.PovOtk ) quStvorkaTypePovOtk++;
								
							}
							else
							{
								quStvorkaRaz++;
							}
								
						}
						
						if( quStvorkaPov > 0 )
						{
							q = quStvorkaPov;
							
							drw = AddWorkByID( Order, drOI, 1886, q*4 ); // Изготовление МП-640/ Распил профиля 45 градусов(створка)
							drw = AddWorkByID( Order, drOI, 1887, q*4 ); // Изготовление МП-640/ Распил закладных (створка)
							drw = AddWorkByID( Order, drOI, 1888, q ); // Изготовление МП-640/ Фрезерование отверстия под ручку
							drw = AddWorkByID( Order, drOI, 1889, quStvorkaPovDrenazh ); // Изготовление МП-640/ Дренаж (створка)
							drw = AddWorkByID( Order, drOI, 1890, q*4 ); // Изготовление МП-640/ Обжим угла створки
							//							drw = AddWorkByID( Order, drOI, 1891, q ); // Изготовление МП-640/ Установка мостов/подкладок
							drw = AddWorkByID( Order, drOI, 1892, q ); // Изготовление МП-640/ Установка заполнения (створка)
							drw = AddWorkByID( Order, drOI, 1893, q*4 ); // Изготовление МП-640/ Установка штапика (створка)
							
							/*
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МП-640"");
							drw = Order.DocWork.AddWorkOperForItem(""Распил профиля 45 градусов(створка)"",q*4);
							drw = Order.DocWork.AddWorkOperForItem(""Распил закладных (створка)"",q);
							drw = Order.DocWork.AddWorkOperForItem(""Фрезерование отверстия под ручку"",q);
							drw = Order.DocWork.AddWorkOperForItem(""Дренаж (створка)"",quStvorkaPovDrenazh);
							drw = Order.DocWork.AddWorkOperForItem(""Обжим угла створки"",4);
							drw = Order.DocWork.AddWorkOperForItem(""Установка мостов/подкладок"",q);
							drw = Order.DocWork.AddWorkOperForItem(""Установка заполнения (створка)"",q);
							drw = Order.DocWork.AddWorkOperForItem(""Установка штапика (створка)"",q*4);
							*/
							
							if( quStvorkaTypePov > 0 )
							{
								drw = AddWorkByID( Order, drOI, 1894, quStvorkaTypePov ); // Изготовление МП-640/ Сборка поворотной фурнитуры
								/*
								drw = Order.DocWork.AddWorkOperForItem(""Сборка поворотной фурнитуры"",quStvorkaTypePov);	
								*/
							}
							if( quStvorkaTypePovOtk > 0 )
							{
								
								drw = AddWorkByID( Order, drOI, 1895, quStvorkaTypePovOtk ); // Изготовление МП-640/ Сборка поротно-откидной фурнитуры
								/*
								drw = Order.DocWork.AddWorkOperForItem(""Сборка поротно-откидной фурнитуры"",quStvorkaTypePovOtk);
								*/
							}
							
							drw = AddWorkByID( Order, drOI, 1896, q ); // Изготовление МП-640/ Установка створки в каркас
							/*
							drw = Order.DocWork.AddWorkOperForItem(""Установка створки в каркас"",q);
							*/
						}
						if( quStvorkaRaz > 0 )
						{
							q = quStvorkaRaz;
							
							drw = AddWorkByID( Order, drOI, 1897, q*4 ); // Изготовление МП-640/ Распил профиля 90 градусов (створка)
							drw = AddWorkByID( Order, drOI, 1899, q ); // Изготовление МП-640/ Обработка на пресс-матрице
							drw = AddWorkByID( Order, drOI, 1900, q*2 ); // Изготовление МП-640/ Установка роликов
							drw = AddWorkByID( Order, drOI, 1901, q ); // Изготовление МП-640/ Фрезеровка отверстия под замок-защелку
							drw = AddWorkByID( Order, drOI, 1902, q ); // Изготовление МП-640/ Сборка раздвижной створки
							drw = AddWorkByID( Order, drOI, 1903, q ); // Изготовление МП-640/ Упаковка раздвижной створки
							
							/*
							drw = Order.DocWork.AddWorkOperForItem(""Распил профиля 90 градусов (створка)"",q*4);
							drw = Order.DocWork.AddWorkOperForItem(""Обработка на пресс-матрице"",q);
							drw = Order.DocWork.AddWorkOperForItem(""Установка роликов"",q*2);
							drw = Order.DocWork.AddWorkOperForItem(""Фрезеровка отверстия под замок-защелку"",q);
							drw = Order.DocWork.AddWorkOperForItem(""Сборка раздвижной створки"",q);
							drw = Order.DocWork.AddWorkOperForItem(""Упаковка раздвижной створки"",q);
							*/
							
							if( drOIVitrazh != null )
							{
								drw = AddWorkByID( Order, drOIVitrazh, 1882, quStvorkaRaz>1?2:1 ); // Изготовление МП-640/ установка ответок для ручки-защелки
								/*
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(drOIVitrazh.idorderitem,""Изготовление МП-640"");
								drw = Order.DocWork.AddWorkOperForItem(""установка ответок для ручки-защелки"",quStvorkaRaz>1?2:1);	
								*/
							}
							else
							{
								drw = AddWorkByID( Order, drOI, 1882, quStvorkaRaz>1?2:1 ); // Изготовление МП-640/ установка ответок для ручки-защелки
								/*
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление МП-640"");
								drw = Order.DocWork.AddWorkOperForItem(""установка ответок для ручки-защелки"",quStvorkaRaz>1?2:1);
								*/
							}
						}
					}
				}
				#endregion
				
				#region Работы Татпроф ТПТ-72ПС
				if( // inRange( Atechnology.ecad.Settings.idpeople, 168, 7228 ) &&
					( 
					( inRange( drOI.idproductiontype, 1958, 2174, 2193 ) ) && 
					( inRange( drOI.profsys_name, ""Татпроф ТПТ-72ПС"", ""Alutech SL160"", ""Alutech SL130"" ) ) 
					) || 
					( 
					( drOI.idproductiontype == 112 ) && 
					( inRange( drOI.profsys_name, ""Татпроф ТПТ-72ПС"", ""Alutech SL160"", ""Alutech SL130"" ) ) && 
					( drOI.IsparentidNull()  ) 
					)  
					) // Расчет работ по алюминию Татпроф ТПТ-72ПС
				{	
					decimal sqr_work = (decimal)(model.Width * model.Height) / 1000000;
					
					if( sqr_work > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление Татпроф ТПТ-72ПС"");
						Order.DocWork.AddWorkOperForItem(""Сборка ТПТ-72ПС"",sqr_work );
					}
					
					rootProduction.AddFinparam(682,1,1); // Порталы 
				}
				#endregion
				
				#region Работы Rehau Intelio Slide
				if( 
					( 
					( inRange( drOI.idproductiontype, 2194 ) ) && // Слайд
					( inRange( drOI.profsys_name, ""Rehau Intelio Slide"" ) ) 
					) || 
					( 
					( drOI.idproductiontype == 112 ) && 
					( inRange( drOI.profsys_name, ""Rehau Intelio Slide"" ) ) && 
					( drOI.IsparentidNull()  ) 
					)  
					) // Расчет работ по Rehau Intelio Slide
				{	
					Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					Order.DocWork.SetCalcParam(rootProduction.idorderitem,""Изготовление Rehau Intelio Slide"");
					Order.DocWork.AddWorkOperForItem(""Сборка Rehau Intelio Slide"",1 ); 
				}
				#endregion
				
				#region Маркеры негабаритов
				bool isNegabaritPVH = inRange( drOI.idpower, 3,4,5,66 ) && !drOI.IswidthNull() && drOI.width > 2500 && drOI.width <= 3500 && !drOI.IsheightNull() && drOI.height > 2500 && drOI.height <= 3500;
				
				// Если одна из сторон Пвх конструкции превышает 3100мм а вторая сторона в диапазоне 3000-3800мм и мощность НЕСТАНДАРТ, 
				// то выводить предупреждение и815 «Одна из сторон конструкции превышает 3100 мм. Согласование с производством НЕ требуется!» и автоматически должна добавляться сумма за сложность работ 500 руб. на конструкцию
				bool isNegabaritPVH2 = inRange( drOI.idpower, 4,5 ) && !drOI.IswidthNull() && !drOI.IsheightNull() &&
					(
					/*
						(
						drOI.width > 3100 && 
						drOI.height >= 3000 && drOI.height <= 3800
						)
						||
						(
						drOI.height > 3100 && 
						drOI.width >= 3000 && drOI.width <= 3800
						)*/
					drOI.width > 3100 || drOI.height > 3100
					);
				
				// Если одна из сторон Пвх конструкции превышает 3500мм а вторая сторона в диапазоне 3000-3800мм и мощность ПОЛУНЕСТАНДАРТ и СТАНДАРТ, 
				// то выводить предупреждение и816 «Одна из сторон конструкции превышает 3500 мм. Согласование с производством НЕ требуется!» и автоматически должна добавляться сумма за сложность работ 500 руб. на конструкцию
				bool isNegabaritPVH3 = inRange( drOI.idpower, 3,66) && !drOI.IswidthNull() && !drOI.IsheightNull() &&
					(
					/*
					(
					drOI.width > 3500 && 
					drOI.height >= 3000 && drOI.height <= 3800
					)
					||
					(
					drOI.height > 3500 && 
					drOI.width >= 3000 && drOI.width <= 3800
					)*/
					drOI.width > 3500 || drOI.height > 3500
					);
				#endregion 
				
				#region ПВХ
				dtLogs += ""\n start PVH "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
				bool isPlaswinLam = false; bool isBlackShagrenLam = false; 
				
				bool isGroupALam = false;
				
				if( inRange( drOI.idpower, 3, 4, 5, 66 ) )
				{
					try
					{
						ds_order.finparamcalcRow r = drOI.GetFinparam( 533 ); // Ламинация Plaswin
						
						isPlaswinLam = r != null;
						
						isBlackShagrenLam = ( !drOI.IsidcoloroutNull() && inRange( drOI.idcolorout, 2520, 2522, 2603, 348, 373, 2347, 2360 ) ) || ( !drOI.IsidcolorinNull() && inRange( drOI.idcolorin, 2520, 2522, 2603, 348, 373, 2347, 2360 ) );
						
						ds_order.finparamcalcRow f576 = drOI.GetFinparam(576); // Группа Ламинации
						isGroupALam = f576 != null && f576.strvalue == ""Группа А"";
						
						isPlaswinLam |= isGroupALam;
						
					}
					catch( Exception E )
					{
					}
					//DEV-119638
					if (drOI.idpower == 5 ||
						drOI.idpower == 4)//ПВХ НСТ
					{
						int count = 0;
						foreach (Stvorka s in model.StvorkaList)
						{
							UserParam u = s.GetUserParam(""Петли оконные"");
								
							if( u != null )
							{
								if (u.StrValue == ""Скрытые"")
								{
									Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
									Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
									Order.DocWork.AddWorkOperForItem(""Скрытые петли НСТ"", 2);
									count++;
								}
							}
						}
						if (count > 0)
							drOI.AddFinparam(688, count, count);
					}
					
					//DEV-121313
					if (drOI.idpower == 3 ||
						drOI.idpower == 66)//ПВХ СТ белый и ПВХ ПН
					{
						int count = 0;
						foreach (Stvorka s in model.StvorkaList)
						{
							UserParam u = s.GetUserParam(""Петли оконные"");
								
							if( u != null )
							{
								if (u.StrValue == ""Скрытые"")
								{
									count++;
								}
							}
						}
						if (count > 0)
							drOI.AddFinparam(687, count, count);
					}
					
					//DEV-122870
					if (//Atechnology.ecad.Settings.idpeople == 8648 &&
						drOI.GetFinparam(417) != null)
					{
						decimal colorCoeff = 1.3M;
						var drw = AddWorkByName(Order, drOI, ""Сборка ПВХ окно Нестандарт"", ""Установка привода дистанционного открывания"", 1);
						drw.price *= colorCoeff; drw.sm *= colorCoeff;
					}
				}
				
				if( drOI.idproductiontype == 111 || drOI.idproductiontype == 535 )
				{
					decimal q = 1;
					bool isColorPVH = drOI.idproductiontype == 111;
					decimal colorCoeff = 1; if( isColorPVH ) colorCoeff = 1.3M;
						
					Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					Order.DocWork.SetCalcParam(drOI.idorderitem,""Работы по аркам"");
					ds_docwork.docworkRow drw = Order.DocWork.AddWorkOperForItem(""Заготовка арки"",q);
					if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

					Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					Order.DocWork.SetCalcParam(drOI.idorderitem,""Работы по аркам"");
					drw = Order.DocWork.AddWorkOperForItem(""Загиб арки"",q);
					if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }	
					
					if( 1==1 )
					{
						string[] itr_works = {""ЗП бригадира"",""ЗП начальника участка"",""ЗП передельщика""};
						string[] itr_work_groups = {""Работы по аркам""};						
						#region Работы для ИТР
						foreach( string g in itr_work_groups ) { foreach( string s in itr_works ) { AddWorkByName( Order, drOI, g, s, 1 ); } }
						#endregion
					}
				}
				
				
				if( drOI.idpower == 3 && !isPlaswinLam ) // ПВХ Стандарт Белый
				{
					Err=""25"";
					#region Работы ПВХ Стандарт
					//Кол-во рам
					int quRama = 0;
					int quStvorka = 0;
					int quBalkaRama = 0;
					int quBalkaStvorka = 0;
					int quBalkaImpost = 0;
					int quBalkaImpostStvorka = 0;
					int quHandle = 0;
					int quHandleDrill = 0;
					int quGluhar = 0;
					int quGlassStvorka = 0;
					int quGlassGluhar = 0;
					int quShtapik = 0;
					int quBalkaArmirovka = 0;
					int quBalkaArmirovkaProkat = 0;
					int quGlassStvorkaRezin = 0;
					int quGlassVkleyka = 0;
					int quImpostVImpost = 0;
					int quAdditionalSredPrizim = 0;

					int quAereco = 0;
					int quVentHoles = 0;
					
					bool isColorPVH = 
						( !drOI.IsidcolorinNull() && !inRange( drOI.idcolorin, 2 ) ) ||
						( !drOI.IsidcoloroutNull() && !inRange( drOI.idcolorout, 2 ) );
					bool exOutColor = !inRange( drOI.idcolorout, 0, 2 );
					bool exInColor = !inRange( drOI.idcolorin, 0, 2 );
					
					quRama = 1;
					
					bool complectCorp = false;
					try
					{
						UserParam u = model.GetUserParam(""Армирование РБН"");
						if( u != null )
						{
							complectCorp = u.StrValue == ""Комплектация Корп"" && u.Visible;
						}
					}
					catch( Exception E )
					{
						
					}
					
					bool noWorkRezin = false;
					try
					{
						UserParam u = model.GetUserParam(""Профиль с протянутой резиной"");
						if( u != null )
						{
							noWorkRezin = u.StrValue == ""Да"" && u.Visible;
						}
					}
					catch( Exception E )
					{
					}
					
					bool exVentHoles = false;
					try
					{
						UserParam u = model.GetUserParam(""Вентиляционные отверстия"");
						if( u != null )
						{
							exVentHoles = u.StrValue == ""Да"" && u.Visible;
							
							if( exVentHoles ) { quVentHoles += 2; }
						}
					}
					catch( Exception E )
					{
					}

					foreach (Glass g in model.GlassList)
					{
						if( g.ModelPart==ModelPart.Stvorka )
						{
							quGlassStvorkaRezin++; // Количество контуров уплотнения в створку (ставится в т.ч. когда нет заполнения)
						}
						if( !( g.Marking.ToLower().Contains(""без"") ) && ( g.Marking.ToLower() != ""без_стекла_и_штапика"" ) ) 
						{ 
							if( g.ModelPart==ModelPart.Stvorka )
							{
								quGlassStvorka++; // Количество запакеток створок
							}
							else
							{
								quGlassGluhar++; // Количество запакеток глухарей
							}
							
							UserParam u2 = g.GetUserParam(""Вклейка стеклопакета"");
							if( u2 != null && u2.StrValue.ToLower() == ""да"" )
							{
								quGlassVkleyka++;
							}			
						} 
						
						if( g.Marking.ToLower() != ""без_стекла_и_штапика"" )
						{
							foreach(GlassItem gi in g)
							{
								quShtapik++; // Количество штапиков
							}
						}
						
						if (g.ModelPart==ModelPart.Stvorka)
						{
							//Створка
						}
						else
						{
							quGluhar++;
							//Глухарь
						}						
					}
					
					//Балки рамы
					foreach(RamaItem ri in model.Rama)
					{
						
						if(ri.Marking.ToLower().Contains(""без""))
						{
							continue;
						}
						else
						{
							// if( inRange( model.ConstructionType.ID, 42 )
							if( ri.MarkingSteel == """" ) ri.MarkingSteel = ""207 (1,2)""; // По-умолчанию 207я
							quBalkaRama++;
							if( ri.MarkingSteel.ToString() != """" )
							{
								if( inRange( ri.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
								quBalkaArmirovka++;
							}
						}
					}
					
					foreach (Stvorka s in model.StvorkaList)
					{
						quStvorka++;
						//Балки створки
						foreach(StvorkaItem si in s)
						{
							if(si.Marking.ToLower().Contains(""без""))
								continue;
							quBalkaStvorka++;
							if( !inRange( model.ConstructionType.ID, 42 ) )  // Проверка на ХХ
							{ 
								if( si.MarkingSteel == """" ) si.MarkingSteel = ""207 (1,2)""; 
							} else 
							{ 
								si.MarkingSteel=""""; // В ХХ Армировка в створку не нужна
							} 
							
							if( si.MarkingSteel.ToString() != """" )
							{
								quBalkaArmirovka++;
								if( inRange( si.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
							}
							
						}
						if(s.HandlePosition > 0 && s.Shtulp==null )
						{
							quHandle++;
							
							UserParam up3 = s.GetUserParam(""Ручка оконная"");
							if( !s.FurnitureSystem.ToLower().Contains(""фурнитура без"") && up3 != null && up3.StrValue!=""Без ручки, Без фурнитуры, Только петли"" )
							{
								quHandleDrill++;
							}
						}
						
						try
						{
							UserParam u = s.GetUserParam(""Клапан АЭРЭКО"");
							if( u != null )
							{
								if( u.StrValue.ToLower() == ""да"" && u.Visible ) quAereco ++;
							}
						}
						catch( Exception E )
						{
								
						}
						//DEV-119638

						UserParam u2 = s.GetUserParam(""Петли оконные"");
						if( u2 != null )
						{
							if (u2.StrValue == ""Скрытые"")
							{
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
								Order.DocWork.AddWorkOperForItem(""Скрытые петли СТ"", 2);
							}
						}
						
						if( s.otkrivanieType == OtkrivanieType.Pov )
							try
							{
								UserParam u = s.GetUserParam(""Дополнительный средний прижим"");
								if( u != null )
								{
									if( u.StrValue.ToLower() != ""0"" && u.Visible ) quAdditionalSredPrizim += Useful.GetInt32(u.StrValue, 0);
								}
							}
							catch( Exception E )
							{
								
							}
						// quAdditionalSredPrizim
					}					
					
					foreach (Impost i in model.ImpostList)
					{
						//Балки импоста
						if(i.Marking.ToLower().Contains(""без"") && i.ImpostType != ImpostType.Shtulp)
							continue;
						quBalkaImpost++;
						
						if(i.Stvorka != null ) quBalkaImpostStvorka++;
						
						if(i.ImpostType==ImpostType.Impost) 
						{ 
							if( i.MarkingSteel == """" ) i.MarkingSteel = ""203 (1,2)""; 
						} else 
						{ 
							i.MarkingSteel = """"; // В штульп армировку не ставим
						} // По-умолчанию 203м

						if( i.MarkingSteel.ToString() != """" )
						{
							quBalkaArmirovka++;
							if( inRange( i.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
						}
						if( i.BalkaStart != null && i.BalkaStart.BalkaType == ModelPart.Impost ) quImpostVImpost ++;
						if( i.BalkaEnd != null && i.BalkaEnd.BalkaType == ModelPart.Impost ) quImpostVImpost ++;
						
						if( exVentHoles && inRange( (int)(i.AngNakl), 90, 270 ) && i.Lenght <= 1600 ) 
						{
							quVentHoles += 1;
						}
						else if( exVentHoles && inRange( (int)(i.AngNakl), 90, 270 ) && i.Lenght > 1600 )
						{
							quVentHoles += 2;
						}
					}
					#endregion
					
					#region Добавление работ
					decimal sc223_summa = 0;
					decimal colorCoeff = 1;

					#region Заготовка стандарт -- Резка ПВХ окно Murat
					// Балки рамы + Балки створки
					if( quBalkaRama + quBalkaStvorka > 0 ) 
					{
						decimal q = quBalkaRama + quBalkaStvorka;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat"");
						Order.DocWork.AddWorkOperForItem(""Резка пластика"",q);
						
						DataRow p = GetWorkOper( 1205 ); // Резка пластика SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
					}
					// Балка импоста
					if( quBalkaImpost > 0 ) 
					{
						decimal q = quBalkaImpost;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Импост Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Резка импоста окно Стандарт"",q);
						
						DataRow p = GetWorkOper( 1206 ); // Резка импоста SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Импост Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка импоста окно Стандарт"",q);
						
						p = GetWorkOper( 1569 ); // Фрезеровка импоста SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Импост Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Сборка импоста окно Стандарт"",q);
						
						p = GetWorkOper( 1570 ); // Сборка импоста SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
					}
                    
					if( 1==0 && !inRange( Atechnology.ecad.Settings.idpeople, 168, 200 ) )
					{
						// Резка стали
						if( quBalkaArmirovka - quBalkaArmirovkaProkat > 0 ) 
						{
							decimal q = quBalkaArmirovka - quBalkaArmirovkaProkat;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat"");
							Order.DocWork.AddWorkOperForItem(""Резка стали"",q);
						
							DataRow p = GetWorkOper( 1207 ); // Резка стали SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}
						if( quBalkaArmirovkaProkat > 0)
						{
							decimal q = quBalkaArmirovkaProkat;
							// Резка проката
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat"");
							Order.DocWork.AddWorkOperForItem(""Резка проката"",q);
						
							DataRow p = GetWorkOper( 1224 ); // Резка проката SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}
					}
					
					// Армирование
					if( 1==0 && quBalkaArmirovka > 0 ) 
					{
						decimal q = quBalkaArmirovka;
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat"");
						Order.DocWork.AddWorkOperForItem(""Армирование"",q);
						
						DataRow p = GetWorkOper( 1208 ); // Армирование SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
					}
					#endregion
					
					#region Сварка и зачистка стандарт окно Murat
					//					if( quBalkaRama + quBalkaStvorka > 0 )
					//					{
					//						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно"");
					//						Order.DocWork.AddWorkOperForItem(""Сварка"", ( quBalkaRama + quBalkaStvorka ) );
					//						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно"");
					//						Order.DocWork.AddWorkOperForItem(""Зачистка"", ( quBalkaRama + quBalkaStvorka ) );
					//					}
					
					if( quBalkaRama > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Сварка рамы стандарт"", quBalkaRama );
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Зачистка рамы стандарт"", quBalkaRama );
					}					
					if( quBalkaStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Сварка створки стандарт"", quBalkaStvorka );
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Зачистка створки стандарт"", quBalkaStvorka );
					}
					#endregion
					dtLogs += ""\n end Murat  "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
					#region Сборка ПВХ окно
					if( quBalkaRama + quBalkaStvorka > 0 && isColorPVH )
					{
						int quSides = ( exOutColor ? 1:0 ) + ( exInColor ? 1:0 ) ;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Закраска швов"", ( quBalkaRama + quBalkaStvorka ) * quSides );
					}
					
					if( quStvorka > 0 )
					{
						//						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						//						Order.DocWork.AddWorkOperForItem(""Фальцлюфт"", ( quStvorka ) );
						
						if( !noWorkRezin )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
							if( 
								( drOI.profsys_name == ""KBE Эксперт 70"" ) || 
								( drOI.profsys_name == ""Exprof Practica 58mm"" ) || 
								( drOI.profsys_name == ""Exprof Prowin"" )
								)
							{
								Order.DocWork.AddWorkOperForItem(""Уплотнение в створку"", ( quStvorka * 2 ) + quGlassStvorkaRezin );						
							} 
							else
							{
								Order.DocWork.AddWorkOperForItem(""Уплотнение в створку"", ( quStvorka ) + quGlassStvorkaRezin );						
							}
						}
						else if( noWorkRezin && drOI.profsys_name == ""Plaswin"" )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
							Order.DocWork.AddWorkOperForItem(""Уплотнение в створку"", quStvorka );						
						}
					}
					
					if( model.FurnitureSystem != ""Фурнитура БЕЗ"" && quStvorka > 0 && model.ConstructionType.ID == 3 )
					{
						// Установка фурнитуры в БД
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Установка фурнитуры в БД"", quStvorka );
					}
					if( quBalkaImpost > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Установка импоста, сверление отверстий под петли"", ( quBalkaImpost ) );
					}
					
					if( quBalkaImpostStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно""); // Сборка ПВХ окно
						Order.DocWork.AddWorkOperForItem(""Установка импоста в створку"", quBalkaImpostStvorka );
					}
					
					/*
					// ФУРНИТУРА для стандарта зависит от МГГ материала (по основному запору) 
					if( model.FurnitureSystem != ""Фурнитура БЕЗ"" && quStvorka > 0 )
					{
						if( model.FurnitureSystem == ""Фурнитура СТН"" )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
							Order.DocWork.AddWorkOperForItem(""Установка СТН"", quStvorka );
						}
						else
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
							Order.DocWork.AddWorkOperForItem(""Установка не СТН"", quStvorka );						
						}
					}
					*/
					
					if( model.FurnitureSystem != ""Фурнитура БЕЗ"" && quStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Установка фурнитуры в раму"", quStvorka );	
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Установка петель на раму"", quStvorka );	
					}
					
					
					if( !noWorkRezin && ( quStvorka + quGluhar > 0 ) )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Уплотнение в раму"", quStvorka + quGluhar );						
					}
					
					
					if( quBalkaImpost > 0 && !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 145 ) && complectCorp )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Установка заглушки импоста"", quBalkaImpost * 2 );
					}
					
					if( isNegabaritPVH )
					{
						// Доплата за сложность (негабарит) 1350
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность (негабарит)"", 1 );
					}
					if( isNegabaritPVH3 )
					{
						// Доплата за сложность (негабарит) 1350
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность (негабарит)"", 1 );
						
						Order.AddErrorUnical(drOI.idorderitem,""и816"","""",""Одна из сторон конструкции превышает 3500 мм. Согласование с производством НЕ требуется!"");
					}
					if( isBlackShagrenLam )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Доплата за сложность"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность ламинации (черная шагрень)"", 1 );
					}
					
					if( quHandleDrill > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Сверление отверстий под ручку СТ"", quHandleDrill );	
					}
					
					if( quImpostVImpost > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Установка соедининения импост/импост"", quImpostVImpost );	
					}
					if( quVentHoles > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Сверление компенсационного отверстия СТ"", quVentHoles );	
					}
					#endregion
					
					#region Запакетка ПВХ
					if( quGlassStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Запакетка ПВХ"");
						Order.DocWork.AddWorkOperForItem(""Запакетка створки Стандарт"", quGlassStvorka );
					}
					if( quGlassGluhar > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Запакетка ПВХ"");
						Order.DocWork.AddWorkOperForItem(""Запакетка глухаря Стандарт"", quGlassGluhar );
					}
					if( quShtapik > 0 ) 
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Распил штапика"");
						Order.DocWork.AddWorkOperForItem(""Резка штапика Стандарт"", quShtapik );
					}
					if( quGlassVkleyka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Вклейка стеклопакета"");
						Order.DocWork.AddWorkOperForItem(""Вклейка стеклопакета"", quGlassVkleyka );
					}
					
					#endregion
					
					#region Клапан Аэреко
					if( quAereco > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Фрезеровка под клапан АЭРЭКО"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка под клапан АЭРЭКО"", quAereco );
					}
					#endregion
					
					#region quAdditionalSredPrizim
					if( quAdditionalSredPrizim > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
						Order.DocWork.AddWorkOperForItem(""Установка дополнительных прижимов"", quAdditionalSredPrizim );
					}
					#endregion
					
					#region Шаттл
					
					Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					Order.DocWork.SetCalcParam(drOI.idorderitem,""Формирование шаттла"");
					Order.DocWork.AddWorkOperForItem(""Формирование шаттла"", 1 );
					
					#endregion
					dtLogs += ""\n end shattle "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
					if( 1==1 )
					{
						string[] itr_works = {""ЗП бригадира"",""ЗП начальника участка"",""ЗП передельщика""};
						string[] itr_work_groups = {""Резка ПВХ окно Murat"",""Резка ПВХ окно Импост Стандарт"",""Сварка ПВХ окно"",""Сборка ПВХ окно"",""Запакетка ПВХ""};
						
						if( model.FurnitureSystem != ""Фурнитура БЕЗ"" && quStvorka > 0 )
						{
							Array.Resize(ref itr_work_groups, itr_work_groups.Length + 1); itr_work_groups[itr_work_groups.Length - 1] = ""Сборка ПВХ окно Kaban Стандарт"";
						}
						
						#region Работы для ИТР
						foreach( string g in itr_work_groups ) { foreach( string s in itr_works ) { AddWorkByName( Order, drOI, g, s, 1 ); } }
						#endregion
					}
					#endregion
				} // idpower=3 Чистый ПВХ Белый СТД
				else if( drOI.idpower == 66 && !isPlaswinLam ) // ПВХ Полунестандарт Белый
				{
					Err=""25"";
					#region Работы ПВХ Полунестандарт
					//Кол-во рам
					int quRama = 0;
					int quStvorka = 0;
					int quBalkaRama = 0;
					int quBalkaStvorka = 0;
					int quBalkaImpost = 0;
					int quBalkaImpostStvorka = 0;
					int quHandle = 0;
					int quHandleDrill = 0;
					int quGluhar = 0;
					int quGlassStvorka = 0;
					int quGlassGluhar = 0;
					int quShtapik = 0;
					int quBalkaArmirovka = 0;
					int quBalkaArmirovkaProkat = 0;
					int quDrenazh = SaveDrenag( model );
					int quAdditionalSredPrizim = 0;

					int quGlassStvorkaRezin = 0;
					int quAereco = 0;
					int quGlassVkleyka = 0;
					int quImpostVImpost = 0;
					int quVentHoles = 0;
					
					bool isColorPVH = 
						( !drOI.IsidcolorinNull() && !inRange( drOI.idcolorin, 2 ) ) ||
						( !drOI.IsidcoloroutNull() && !inRange( drOI.idcolorout, 2 ) );
					bool exOutColor = !inRange( drOI.idcolorout, 0, 2 );
					bool exInColor = !inRange( drOI.idcolorin, 0, 2 );
					
					bool complectCorp = false;
					try
					{
						UserParam u = model.GetUserParam(""Армирование РБН"");
						if( u != null )
						{
							complectCorp = u.StrValue == ""Комплектация Корп"" && u.Visible;
						}
					}
					catch( Exception E )
					{
						
					}
					
					bool noWorkRezin = false;
					try
					{
						UserParam u = model.GetUserParam(""Профиль с протянутой резиной"");
						if( u != null )
						{
							noWorkRezin = u.StrValue == ""Да"" && u.Visible;
						}
					}
					catch( Exception E )
					{
					}

					bool exVentHoles = false;
					try
					{
						UserParam u = model.GetUserParam(""Вентиляционные отверстия"");
						if( u != null )
						{
							exVentHoles = u.StrValue == ""Да"" && u.Visible;
							
							if( exVentHoles ) { quVentHoles += 2; }
						}
					}
					catch( Exception E )
					{
					}
					
					quRama = 1;
					
					foreach (Glass g in model.GlassList)
					{
						if( g.ModelPart==ModelPart.Stvorka )
						{
							quGlassStvorkaRezin++; // Количество контуров уплотнения в створку (ставится в т.ч. когда нет заполнения)
						}

						if( !( g.Marking.ToLower().Contains(""без"") ) && ( g.Marking.ToLower() != ""без_стекла_и_штапика"" ) ) 
						{ 
							if( g.ModelPart==ModelPart.Stvorka )
							{
								quGlassStvorka++; // Количество запакеток створок
							}
							else
							{
								quGlassGluhar++; // Количество запакеток глухарей
							}
							
							UserParam u2 = g.GetUserParam(""Вклейка стеклопакета"");
							if( u2 != null && u2.StrValue.ToLower() == ""да"" )
							{
								quGlassVkleyka++;
							}
							
							//							foreach(GlassItem gi in g)
							//							{
							//								quShtapik++; // Количество штапиков
							//							}
						} 
						
						if( g.Marking.ToLower() != ""без_стекла_и_штапика"" )
						{
							foreach(GlassItem gi in g)
							{
								quShtapik++; // Количество штапиков
							}
						}
						
						if (g.ModelPart==ModelPart.Stvorka)
						{
							//Створка
						}
						else
						{
							quGluhar++;
							//Глухарь
						}						
					}
					
					//Балки рамы
					foreach(RamaItem ri in model.Rama)
					{
						
						if(ri.Marking.ToLower().Contains(""без""))
						{
							continue;
						}
						else
						{
							quBalkaRama++;
							// ri.MarkingSteel = ""207 (1,2)""; // По-умолчанию 207я
							if( ri.MarkingSteel.ToString() != """" )
							{
								quBalkaArmirovka++;
								if( inRange( ri.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
							}
						}
					}
					
					foreach (Stvorka s in model.StvorkaList)
					{
						quStvorka++;
						//Балки створки
						foreach(StvorkaItem si in s)
						{
							if(si.Marking.ToLower().Contains(""без""))
								continue;
							quBalkaStvorka++;
							// if( !inRange( model.ConstructionType.ID, 42 ) ) { si.MarkingSteel = ""207 (1,2)""; } else { si.MarkingSteel=""""; } // По-умолчанию 207я
							if( inRange( model.ConstructionType.ID, 42 ) ) { si.MarkingSteel=""""; } // В ХХ створках нет армирования
							if( si.MarkingSteel.ToString() != """" )
							{
								quBalkaArmirovka++;
								if( inRange( si.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
							}
							
						}
						if(s.HandlePosition > 0 && s.Shtulp==null )
						{
							quHandle++;
							UserParam up3 = s.GetUserParam(""Ручка оконная"");
							if( !s.FurnitureSystem.ToLower().Contains(""фурнитура без"") && up3 != null && up3.StrValue!=""Без ручки, Без фурнитуры, Только петли"" )
							{
								quHandleDrill++;
							}
						}
						
						try
						{
							UserParam u = s.GetUserParam(""Клапан АЭРЭКО"");
							if( u != null )
							{
								if( u.StrValue.ToLower() == ""да"" && u.Visible ) quAereco ++;
							}
						}
						catch( Exception E )
						{
								
						}
						
						if( s.otkrivanieType == OtkrivanieType.Pov )
							try
							{
								UserParam u = s.GetUserParam(""Дополнительный средний прижим"");
								if( u != null )
								{
									if( u.StrValue.ToLower() != ""0"" && u.Visible ) quAdditionalSredPrizim += Useful.GetInt32(u.StrValue, 0);
								}
							}
							catch( Exception E )
							{
								
							}
						// quAdditionalSredPrizim
						
						//DEV-119638
						UserParam u2 = s.GetUserParam(""Петли оконные"");
						if( u2 != null )
						{
							if (u2.StrValue == ""Скрытые"")
							{
								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
								Order.DocWork.AddWorkOperForItem(""Скрытые петли ПНСТ"", 2);
							}
						}
					}

					
					foreach (Impost i in model.ImpostList)
					{
						//Балки импоста
						if(i.Marking.ToLower().Contains(""без"") && i.ImpostType != ImpostType.Shtulp)
							continue;
						quBalkaImpost++;
						if(i.Stvorka != null ) quBalkaImpostStvorka++;
						//if(i.ImpostType==ImpostType.Impost) { i.MarkingSteel = ""203м""; } else { i.MarkingSteel = """"; } // По-умолчанию 203м
						if( i.MarkingSteel.ToString() != """" )
						{
							quBalkaArmirovka++;
							if( inRange( i.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
						}
						
						if( i.BalkaStart != null && i.BalkaStart.BalkaType == ModelPart.Impost ) quImpostVImpost ++;
						if( i.BalkaEnd != null && i.BalkaEnd.BalkaType == ModelPart.Impost ) quImpostVImpost ++;
						
						if( exVentHoles && inRange( (int)(i.AngNakl), 90, 270 ) && i.Lenght <= 1600 ) 
						{
							quVentHoles += 1;
						}
						else if( exVentHoles && inRange( (int)(i.AngNakl), 90, 270 ) && i.Lenght > 1600 )
						{
							quVentHoles += 2;
						}
						
					}
					#endregion
					
					#region Добавление работ
					decimal sc223_summa = 0;
					decimal colorCoeff = 1;

					#region Заготовка стандарт -- Резка ПВХ окно Murat
					// Балки рамы + Балки створки
					if( quBalkaRama + quBalkaStvorka > 0 ) 
					{
						decimal q = quBalkaRama + quBalkaStvorka;

						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Резка пластика Kaban Стандарт"",q);
						
						DataRow p = GetWorkOper( 1205 ); // Резка пластика SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;

					}
					// Балка импоста
					if( quBalkaImpost > 0 ) 
					{
						decimal q = quBalkaImpost;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Резка импоста Kaban Стандарт"",q);
						
						DataRow p = GetWorkOper( 1206 ); // Резка импоста SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка импоста Kaban Стандарт"",q);
						
						p = GetWorkOper( 1569 ); // Фрезеровка импоста SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Сборка импоста Kaban Стандарт"",q);
						
						p = GetWorkOper( 1570 ); // Сборка импоста SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
					}

					if( 1==0 && !inRange( Atechnology.ecad.Settings.idpeople, 168, 200 ) )
					{

						// Резка стали
						if( quBalkaArmirovka - quBalkaArmirovkaProkat > 0 ) 
						{
							decimal q = quBalkaArmirovka - quBalkaArmirovkaProkat;

							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Стандарт"");
							Order.DocWork.AddWorkOperForItem(""Резка стали Kaban Стандарт"",q);

							DataRow p = GetWorkOper( 1207 ); // Резка стали SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}
						if( quBalkaArmirovkaProkat > 0 )
						{
							decimal q = quBalkaArmirovkaProkat;
							// Резка проката
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Стандарт"");
							Order.DocWork.AddWorkOperForItem(""Резка проката Kaban Стандарт"",q);
						
							DataRow p = GetWorkOper( 1224 ); // Резка проката SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}
					}

					// Армирование
					if( 1==0 && quBalkaArmirovka > 0 ) 
					{
						decimal q = quBalkaArmirovka;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Армирование Kaban Стандарт"",q);
						
						DataRow p = GetWorkOper( 1208 ); // Армирование SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
					}
					
					// Дренажи Kaban Нестандарт
					
					if( quDrenazh > 0 ) 
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Дренажи Kaban Стандарт"",quDrenazh);
					}
					
					// Фрезеровка ручки Kaban Нестандарт
					if( quHandle > 0 ) 
					{
						decimal q = quHandle;

						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка ручки Kaban Стандарт"",q);
						
						DataRow p = GetWorkOper( 1226 ); // Фрезеровка ручки SC-223
						if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
					}					
					drOI.AddFinparam( 410, sc223_summa, sc223_summa ); // Заготовка нестандарта на SC-223

					#endregion
					
					#region Сварка и зачистка стандарт окно Murat
					//					if( quBalkaRama + quBalkaStvorka > 0 )
					//					{
					//						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
					//						Order.DocWork.AddWorkOperForItem(""Сварка Kaban"", ( quBalkaRama + quBalkaStvorka ) );
					//						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
					//						Order.DocWork.AddWorkOperForItem(""Зачистка Kaban"", ( quBalkaRama + quBalkaStvorka ) );
					//					}
					if( quBalkaRama > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						Order.DocWork.AddWorkOperForItem(""Сварка рамы НСТ"", quBalkaRama );
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						Order.DocWork.AddWorkOperForItem(""Зачистка рамы НСТ"", quBalkaRama );
					}					
					if( quBalkaStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						Order.DocWork.AddWorkOperForItem(""Сварка створки НСТ"", quBalkaStvorka );
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						Order.DocWork.AddWorkOperForItem(""Зачистка створки НСТ"", quBalkaStvorka );
					}
					
					#endregion
					dtLogs += ""\n before PVH window "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
					#region Сборка ПВХ окно
					
					if( quBalkaRama + quBalkaStvorka > 0 && isColorPVH )
					{
						int quSides = ( exOutColor ? 1:0 ) + ( exInColor ? 1:0 ) ;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Закраска швов"", ( quBalkaRama + quBalkaStvorka ) * quSides );
					}
					
					if( quStvorka > 0 )
					{
						//						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт""); // Сборка ПВХ окно Kaban Стандарт
						//						Order.DocWork.AddWorkOperForItem(""Фальцлюфт"", ( quStvorka ) );
						if( !noWorkRezin )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт""); // Сборка ПВХ окно Kaban Стандарт
							if( 
								( drOI.profsys_name == ""KBE Эксперт 70"" ) || 
								( drOI.profsys_name == ""Exprof Practica 58mm"" ) || 
								( drOI.profsys_name == ""Exprof Prowin"" )
								)
							{
								Order.DocWork.AddWorkOperForItem(""Уплотнение в створку"", ( quStvorka * 2 ) + quGlassStvorkaRezin );						
							}
							else
							{
								Order.DocWork.AddWorkOperForItem(""Уплотнение в створку"", ( quStvorka ) + quGlassStvorkaRezin );						
							}
						}
						else if( noWorkRezin && drOI.profsys_name == ""Plaswin"" )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
							Order.DocWork.AddWorkOperForItem(""Уплотнение в створку"", quStvorka );						
						}
						
					}
					if( quBalkaImpost > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт""); // Сборка ПВХ окно Kaban Стандарт
						Order.DocWork.AddWorkOperForItem(""Установка импоста, сверление отверстий под петли"", ( quBalkaImpost ) );
					}
					
					if( quBalkaImpostStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт""); // Сборка ПВХ окно Kaban Стандарт
						Order.DocWork.AddWorkOperForItem(""Установка импоста в створку"", quBalkaImpostStvorka );
					}
					
					if( quBalkaImpost > 0 && !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 145 ) && complectCorp )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт""); // Сборка ПВХ окно Kaban Стандарт
						Order.DocWork.AddWorkOperForItem(""Установка заглушки импоста"", quBalkaImpost * 2 );
					}
					
					if( model.FurnitureSystem != ""Фурнитура БЕЗ"" && quStvorka > 0 && model.ConstructionType.ID == 3 )
					{
						// Установка фурнитуры в БД
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Установка фурнитуры в БД"", quStvorka );
					}
					
					

					/*
					// ФУРНИТУРА для стандарта зависит от МГГ материала (по основному запору)
					if( model.FurnitureSystem != ""Фурнитура БЕЗ"" && quStvorka > 0 )
					{
						if( model.FurnitureSystem == ""Фурнитура СТН"" )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
							Order.DocWork.AddWorkOperForItem(""Установка СТН"", quStvorka );
						}
						else
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно"");
							Order.DocWork.AddWorkOperForItem(""Установка не СТН"", quStvorka );						
						}
					}
					*/
					
					if( model.FurnitureSystem != ""Фурнитура БЕЗ"" && quStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Установка фурнитуры в раму"", quStvorka );		
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Установка петель на раму"", quStvorka );
					}
					
					if( !noWorkRezin && ( quStvorka + quGluhar > 0 ) )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт""); // Сборка ПВХ окно Kaban Стандарт
						Order.DocWork.AddWorkOperForItem(""Уплотнение в раму"", quStvorka + quGluhar );						
					}
							
					if( isNegabaritPVH )
					{
						// Доплата за сложность (негабарит) 1352
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность (негабарит)"", 1 );
					}
					if( isNegabaritPVH3 )
					{
						// Доплата за сложность (негабарит) 1350
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность (негабарит)"", 1 );
						
						Order.AddErrorUnical(drOI.idorderitem,""и816"","""",""Одна из сторон конструкции превышает 3500 мм. Согласование с производством НЕ требуется!"");
					}
					if( isBlackShagrenLam )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Доплата за сложность"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность ламинации (черная шагрень)"", 1 );
					}
					
					if( quHandleDrill > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Сверление отверстий под ручку ПНСТ"", quHandleDrill );	
					}
					
					if( quImpostVImpost > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Установка соедининения импост/импост нестандарт ПНСТ"", quImpostVImpost );	
					}
					
					if( quVentHoles > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Сверление компенсационного отверстия ПНСТ"", quVentHoles );	
					}
					
					#region quAdditionalSredPrizim
					if( quAdditionalSredPrizim > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Kaban Стандарт"");
						Order.DocWork.AddWorkOperForItem(""Установка дополнительных прижимов"", quAdditionalSredPrizim );
					}
					#endregion
					
					#endregion
					
					#region Запакетка ПВХ
					if( quGlassStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Запакетка ПВХ"");
						Order.DocWork.AddWorkOperForItem(""Запакетка створки Стандарт"", quGlassStvorka );
					}
					if( quGlassGluhar > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Запакетка ПВХ"");
						Order.DocWork.AddWorkOperForItem(""Запакетка глухаря Стандарт"", quGlassGluhar );
					}
					if( quShtapik > 0 ) 
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Распил штапика"");
						Order.DocWork.AddWorkOperForItem(""Резка штапика Стандарт"", quShtapik );
					}
					if( quGlassVkleyka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Вклейка стеклопакета"");
						Order.DocWork.AddWorkOperForItem(""Вклейка стеклопакета"", quGlassVkleyka );
					}
					#endregion
					
					#region Клапан Аэреко
					if( quAereco > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Фрезеровка под клапан АЭРЭКО"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка под клапан АЭРЭКО"", quAereco );
					}
					#endregion

					#region Шаттл
					
					Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					Order.DocWork.SetCalcParam(drOI.idorderitem,""Формирование шаттла"");
					Order.DocWork.AddWorkOperForItem(""Формирование шаттла"", 1 );
					
					#endregion
					
					if( 1==1 )
					{
						string[] itr_works = {""ЗП бригадира"",""ЗП начальника участка"",""ЗП передельщика""};
						string[] itr_work_groups = {""Резка ПВХ окно Kaban Стандарт"",""Сварка ПВХ окно Kaban"",""Сборка ПВХ окно Kaban Стандарт"",""Запакетка ПВХ""};						
						#region Работы для ИТР
						foreach( string g in itr_work_groups ) { foreach( string s in itr_works ) { AddWorkByName( Order, drOI, g, s, 1 ); } }
						#endregion
					}
					#endregion
					dtLogs += ""\n end standrt PVH "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
				}					
				else if( 
					( 
					inRange( drOI.idpower, 4, 5 ) || ( inRange( drOI.idpower, 3, 66 ) && isPlaswinLam ) 
					) && 
					!drOI.IsidconstructiontypeNull() && !inRange( drOI.idconstructiontype, 6, 7, 35, 36, 55  ) ) // ПВХ Нестандарт + Ламинация КРОМЕ ДВЕРЕЙ
				{
					Err=""26"";
					#region Работы ПВХ Нестандарт
					//Кол-во рам
					int quRama = 0;
					int quStvorka = 0;
					int quBalkaRama = 0;
					int quBalkaStvorka = 0;
					int quBalkaStvorka318 = 0;
					int quBalkaImpost = 0;
					int quBalkaImpostNestAngle = 0;
					int quBalkaImpost318 = 0;
					int quBalkaImpostStvorka = 0;
					int quHandle = 0;
					int quHandleDrill = 0;
					int quFurnOrdinary = 0;
					int quFurn318 = 0;
					int quGluhar = 0;
					int quGlassStvorka = 0;
					int quGlassGluhar = 0;
					int quShtapik = 0;
					int quBalkaArmirovka = 0;
					int quBalkaArmirovkaProkat = 0;
					int quArka = 0;
					int quTrap = 0;
					int quTrap35 = 0;
					int quTrapRamaStvorka = 0;
					int quDrenazh = SaveDrenag( model );
					int quGlassStvorkaNest = 0;
					int quGlassGluharNest = 0;
					int quShtapikRama = 0;
					int quShtapikRamaNest = 0;
					int quShtapikStvorka = 0;
					int quShtapikStvorkaNest = 0;

					int quGlassStvorkaRezin = 0;
					int quNozhnicAdditional = 0;

					int quAereco = 0;
					int quPortals = 0;
					int quFramugas = 0;	
					int quGlassVkleyka = 0;
					int quDrenazhImpost = 0;
					
					int quBalkaNest = 0;
					int quImpostVImpost = 0;
					int quVentHoles = 0;
					
					
					List<string> connectionKeys9090 = new List<string>();
					int quRamaRama90 = 0; // Количество операций соединения рамы с рамой под углом 90 градусов (запил 90град). Кроме соединения рама-порог
					dtLogs += ""\n start nest pvh "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
					bool complectCorp = false;
					try
					{
						UserParam u = model.GetUserParam(""Армирование РБН"");
						if( u != null )
						{
							complectCorp = u.StrValue == ""Комплектация Корп"" && u.Visible;
						}
					}
					catch( Exception E ){}
					
					bool noWorkRezin = false;
					try
					{
						UserParam u = model.GetUserParam(""Профиль с протянутой резиной"");
						if( u != null )
						{
							noWorkRezin = u.StrValue == ""Да"" && u.Visible;
						}
					}
					catch( Exception E )
					{
					}
					
					
					bool exVentHoles = false;
					try
					{
						UserParam u = model.GetUserParam(""Вентиляционные отверстия"");
						if( u != null )
						{
							exVentHoles = u.StrValue == ""Да"" && u.Visible;
							if( exVentHoles ) { quVentHoles += 2; }
						}
					}
					catch( Exception E )
					{
					}
					
					Err=""26.002"";
					#region Операция за дистанционное управление фрамугой 1227 ""Установка привода дистанционного открывания""/работа 68 ""Сборка ПВХ окно Нестандарт""  группа Нестандарт
					int quRemoteControl = 0;
					// if( drOI.GetFinparam(417) != null ) quRemoteControl = 1;
					#endregion
				
					bool isColorPVH = 
						( !drOI.IsidcolorinNull() && !inRange( drOI.idcolorin, 2 ) ) ||
						( !drOI.IsidcoloroutNull() && !inRange( drOI.idcolorout, 2 ) );
					bool exOutColor = !inRange( drOI.idcolorout, 0, 2 );
					bool exInColor = !inRange( drOI.idcolorin, 0, 2 );
					
					decimal colorCoeff = 1.3M;
					if( !isColorPVH ) colorCoeff = 1;
					int lamlen = 0;
					
					int lamlencoeff = 1;
					if( exOutColor && exInColor ) lamlencoeff = 2;
					
					quRama = 1;
					Err=""26.003"";
					foreach (Glass g in model.GlassList)
					{
						if( g.ModelPart==ModelPart.Stvorka )
						{
							quGlassStvorkaRezin++; // Количество контуров уплотнения в створку (ставится в т.ч. когда нет заполнения)
						}
						if( /* !( g.Marking.ToLower().Contains(""без"") ) && */ ( g.Marking.ToLower() != ""без_стекла_и_штапика"" ) ) 
						{ 
							if( !( g.Marking.ToLower().Contains(""без"") ) && ( g.Marking.ToLower() != ""без_стекла_и_штапика"" ) )
							{
								UserParam u2 = g.GetUserParam(""Вклейка стеклопакета"");
								if( u2 != null && u2.StrValue.ToLower() == ""да"" )
								{
									quGlassVkleyka++;
								}
							}
							bool isNest = false;
							foreach(GlassItem gi in g)
							{
								// quShtapik++; // Количество штапиков
								if( g.ModelPart == ModelPart.Stvorka )
								{
									if( 
										( !inRange( gi.Ang1, 0, 90, 45, 180 ) ) 
										|| 
										( !inRange( gi.Ang2, 0, 90, 45, 180 ) )
										|| gi.Radius1 != 0 || gi.Radius2 != 0
										)
									{
										quShtapikStvorkaNest++;
										isNest = true;
									}
									else
									{
										quShtapikStvorka++;
									}
								}
								else
								{
									if( 
										( !inRange( gi.Ang1, 0, 90, 45, 180 ) ) 
										|| 
										( !inRange( gi.Ang2, 0, 90, 45, 180 ) )
										|| gi.Radius1 != 0 || gi.Radius2 != 0
										)
									{
										// MessageBox.Show( ""1="" + gi.Ang1.ToString() + "", 2="" + gi.Ang2.ToString() );
										isNest = true;
										quShtapikRamaNest++;
									}
									else
									{
										quShtapikRama++;
									}
									
								}
								// Длина лам. штапика
								if( exInColor && gi.Radius1 == 0 && gi.Radius2 == 0 ) lamlen += gi.LenghtShtapik;
							}
							
							// Длины лам. фальшей
							if( g.Falsh != null )
							{
								if( exOutColor && ( g.Falsh.Side == FalshSide.DoubleSide || g.Falsh.Side == FalshSide.OutSide ) ) lamlen += g.Falsh.Perimetr;
								if( exInColor && ( g.Falsh.Side == FalshSide.DoubleSide || g.Falsh.Side == FalshSide.InSide ) ) lamlen += g.Falsh.Perimetr;
							}
							
							/*
							if( g.ModelPart==ModelPart.Stvorka )
							{
								quGlassStvorka++; // Количество запакеток створок
							}
							else
							{
								quGlassGluhar++; // Количество запакеток глухарей
							}
							foreach(GlassItem gi in g)
							{
								quShtapik++; // Количество штапиков
							}
							*/
							
							if( g.ModelPart==ModelPart.Stvorka )
							{
								if( !isNest )
								{
									quGlassStvorka++; // Количество запакеток створок
								}
								else
								{
									quGlassStvorkaNest++;
								}
							}
							else
							{
								if( !isNest )
								{
									quGlassGluhar++; // Количество запакеток глухарей
								}
								else
								{
									quGlassGluharNest++; // Количество запакеток глухарей
								}
							}
							
							
						} 
						if (g.ModelPart==ModelPart.Stvorka)
						{
							//Створка
						}
						else
						{
							quGluhar++;
							//Глухарь
						}						
					}
					/*
					if( 1==0 && Atechnology.ecad.Settings.idpeople == 168 )
					{
						MessageBox.Show( ""A="" + lamlen );
					}
					*/
					
					Err=""26.004"";
					//Балки рамы
					foreach(RamaItem ri in model.Rama)
					{
						if( ri.HeightArc != 0 ) 
						{
							quArka++;
						}
						if( ( ri.Ang1 != 45 ) || ( ri.Ang2 != 45 ) ) 
						{
							quTrap++;
							quTrapRamaStvorka++;
							if( ri.Ang1 < 35 ) quTrap35 ++;
							if( ri.Ang2 < 35 ) quTrap35 ++;
							
							
							if(ri.Marking.ToLower().Contains(""без"") || ri.RamaType == RamaType.Porog )
							{
								
							}
							else if( ri.Ang1 == 90 || ri.Ang2 == 90 )
							{
								bool bs_via_porog = ( ri.BalkaStart is RamaItem && ((RamaItem)ri.BalkaStart).RamaType == RamaType.Porog );
								if( ri.Ang1 == 90 && !ri.BalkaStart.Marking.ToLower().Contains(""без"") && !bs_via_porog )
								{
									Balka b1 = ri;
									Balka b2 = ri.BalkaStart;
									string bs_marking = b1.BalkaType + ""-"" + b1.ID + "":"" + b2.BalkaType + ""-"" + b2.ID;
									string bs_marking_reverse = b2.BalkaType + ""-"" + b2.ID + "":"" + b1.BalkaType + ""-"" + b1.ID;
								
									if( !connectionKeys9090.Contains( bs_marking ) && !connectionKeys9090.Contains( bs_marking_reverse ) )
									{
										connectionKeys9090.Add( bs_marking );
									}
								}
								bool be_via_porog = ( ri.BalkaEnd is RamaItem && ((RamaItem)ri.BalkaEnd).RamaType == RamaType.Porog );
								if( ri.Ang2 == 90 && !ri.BalkaEnd.Marking.ToLower().Contains(""без"") && !be_via_porog )
								{
									Balka b1 = ri;
									Balka b2 = ri.BalkaEnd;
									string bs_marking = b1.BalkaType + ""-"" + b1.ID + "":"" + b2.BalkaType + ""-"" + b2.ID;
									string bs_marking_reverse = b2.BalkaType + ""-"" + b2.ID + "":"" + b1.BalkaType + ""-"" + b1.ID;
								
									if( !connectionKeys9090.Contains( bs_marking ) && !connectionKeys9090.Contains( bs_marking_reverse ) )
									{
										connectionKeys9090.Add( bs_marking );
									}
								}
							}
						}
						if(ri.Marking.ToLower().Contains(""без""))
						{
							continue;
						}
						else
						{
							quBalkaRama++;
							if( ri.MarkingSteel.ToString() != """" )
							{
								quBalkaArmirovka++;
								if( inRange( ri.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
							}
							
							// Длина ламиниарованных рам
							if( isColorPVH && ri.Radius1 == 0 && ri.Radius2 == 0 ) lamlen += lamlencoeff * ri.LengthInterfaceCalcInt; 
						}
					}
					
					quRamaRama90 = connectionKeys9090.Count;
					Err=""26.005"";
					foreach (Stvorka s in model.StvorkaList)
					{
						quStvorka++;
						//Балки створки
						bool is318 = false;
						foreach(StvorkaItem si in s)
						{
							if(si.Marking.ToLower().Contains(""без""))
								continue;
							quBalkaStvorka++;
							
							// Длина ламинированных створок
							if( isColorPVH && si.Radius1 == 0 && si.Radius2 == 0 ) lamlen += lamlencoeff * si.LengthInterfaceCalcInt;
							
							if( ( is318 == false) && ( si.Marking.ToLower().Contains(""318"") ) && ( drOI.profsys_name == ""KBE Эталон 58"" ) )
							{
								is318 = true;
							}
							if( si.MarkingSteel.ToString() != """" )
							{
								quBalkaArmirovka++;
								if( inRange( si.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
							}
							
							if( si.HeightArc != 0 ) 
							{
								quArka++;
							}
							if( ( si.Ang1 != 45 ) || ( si.Ang2 != 45 ) ) 
							{
								quTrap++;
								quTrapRamaStvorka++;
								if( si.Ang1 < 35 ) quTrap35 ++;
								if( si.Ang2 < 35 ) quTrap35 ++;
							}
							if( is318 ) 
							{
								quBalkaStvorka318++;
							}

						}
						//если фурнитура не Фурнитура без и створка 318
						if(!s.FurnitureSystem.Contains(""без"") && is318)
						{
							quFurn318++;
						}
						else if( ( !s.FurnitureSystem.Contains(""без"") ) && ( !is318 ) )
						{
							quFurnOrdinary++;
						}
						if( s.HandlePosition > 0 && s.Shtulp==null )
						{
							quHandle++;
							UserParam up3 = s.GetUserParam(""Ручка оконная"");
							if( !s.FurnitureSystem.ToLower().Contains(""фурнитура без"") && up3 != null && up3.StrValue!=""Без ручки, Без фурнитуры, Только петли"" )
							{
								quHandleDrill++;
							}
							
							if( s.GetUserParam(""Дополнительные ножницы"").StrValue.ToLower() == ""да"" )
							{
								quNozhnicAdditional ++;
							}
							
							if( s.GetUserParam(""Дистанционное управление"").StrValue.ToLower() == ""да"" )
							{
								quRemoteControl ++;
							}
						}
						
						try
						{
							UserParam u = s.GetUserParam(""Клапан АЭРЭКО"");
							if( u != null )
							{
								if( u.StrValue.ToLower() == ""да"" && u.Visible ) quAereco ++;
							}
						}
						catch( Exception E )
						{
								
						}
												
						if( s.otkrivanieType == OtkrivanieType.Podves )
						{
							quFramugas++;
							/*
							if (Atechnology.ecad.Settings.People.idpeople == 8500 ||
							Atechnology.ecad.Settings.People.idpeople == 3404){
								
								var petli = s.GetUserParam(""Петли оконные"");
								
								if (petli == null)
								{
									continue;
								}
								
								if (petli.StrValue !=  ""Фрикционные"")
								{
									continue;
								}
								
								foreach(StvorkaItem si in s)
								{
									if (si.MarkingSteel == ""207"")
									{
										Order.AddErrorUnical(drOI.idorderitem,""о1630"");
									}
								}
							}
						*/
						}
						else if( s.otkrivanieType == OtkrivanieType.PodiyomnoSdvijnaya )
						{
							quPortals += 1;
							//							if( s.ShtulpExist != ShtulpExist.NonExist )
							//							{
							//								quPortals += 1;
							//								
							//								MessageBox.Show( ""se="" + s.ShtulpExist + "", q="" + quPortals );
							//							}
						}
					}			
					
					bool exDrenazhImpost = inRange( model.GetUserParam(""Дренаж"").StrValue.ToLower(), ""авто"", ""снизу"" );
					
					Err=""26.006"";
					foreach (Impost i in model.ImpostList)
					{
						//Балки импоста
						if(i.Marking.ToLower().Contains(""без"") && i.ImpostType != ImpostType.Shtulp)
							continue;
						
						// Длина ламинированных импостов
						if( isColorPVH && i.Radius1 == 0 && i.Radius2 == 0 ) lamlen += lamlencoeff * i.LengthInterfaceCalcInt;
						
						if( !inRange( i.Ang1, 0, 45, 90 ) || !inRange( i.Ang2, 0, 45, 90 ) ) 
						{
							quBalkaImpostNestAngle++;
						}
						else if( ( i.BalkaEnd.Marking.Contains(""318"") ) || ( i.BalkaStart.Marking.Contains(""318"") ) )
						{
							quBalkaImpost318++;
						}
						else
						{
							quBalkaImpost++;
						}
						
						if(i.Stvorka != null ) quBalkaImpostStvorka++;
						
						if( i.MarkingSteel.ToString() != """" )
						{
							quBalkaArmirovka++;
							if( inRange( i.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
						}
						if( i.HeightArc != 0 ) 
						{
							quArka++;
						}
						if( !inRange( i.Ang1, 0, 45, 90 ) || !inRange( i.Ang2, 0, 45, 90 ) ) 
						{
							quTrap++;
						}
						
						if( exDrenazhImpost && !i.Marking.ToLower().Contains(""без"") && inRange( i.AngleHorisont, 0, 180 ) )
						{
							quDrenazhImpost += 1;
						}
						
						if( i.BalkaStart != null && i.BalkaStart.BalkaType == ModelPart.Impost ) quImpostVImpost ++;
						if( i.BalkaEnd != null && i.BalkaEnd.BalkaType == ModelPart.Impost ) quImpostVImpost ++;
						
						
						if( exVentHoles && inRange( (int)(i.AngNakl), 90, 270 ) && i.Lenght <= 1600 ) 
						{
							quVentHoles += 1;
						}
						else if( exVentHoles && inRange( (int)(i.AngNakl), 90, 270 ) && i.Lenght > 1600 )
						{
							quVentHoles += 2;
						}
						
					}
					#endregion
					Err=""26.007"";
					dtLogs += ""\n end pvh nest "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
					bool exNestAngle = quBalkaImpostNestAngle > 0 || quTrapRamaStvorka > 0;
					
					bool canUse223 = !exNestAngle && !drOI.IsidconstructiontypeNull() && inRange( drOI.idconstructiontype, 2,3,12) && ( !inRange( drOI.idcolorout,0,2,234 ) || !inRange( drOI.idcolorin, 0, 2, 234 ) );
					
					#region Добавление работ
					
					decimal sc223_summa = 0;
					
					ds_docwork.docworkRow drw = null; 
					ds_docwork.docworkRow drw_sc = null; 
						
					Err=""26.007.005"";
					if( canUse223 )
					{
						#region Заготовка нестандарт -- 223
						// Балки рамы + Балки створки
						if( quBalkaRama + quBalkaStvorka > 0 ) 
						{
							decimal q = quBalkaRama + quBalkaStvorka;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка пластика SC-223"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
							DataRow p = GetWorkOper( 1205 ); // Резка пластика SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						}
						// Балка импоста
						if( quBalkaImpost /* + quBalkaImpost318 */ > 0 ) 
						{
							decimal q = quBalkaImpost /* + quBalkaImpost318 */;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка импоста SC-223"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1206 ); // Резка импоста SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							Order.DocWork.AddWorkOperForItem(""Фрезеровка импоста SC-223"",q);
						
							p = GetWorkOper( 1569 ); // Фрезеровка импоста SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							Order.DocWork.AddWorkOperForItem(""Сборка импоста SC-223"",q);
						
							p = GetWorkOper( 1570 ); // Сборка импоста SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						}
						// Резка импоста Kaban Нестандарт 318
						if( quBalkaImpost318 > 0 ) 
						{
							decimal q = quBalkaImpost318;
						
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка импоста 318"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1291 ); // Резка импоста 318
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}

						Err=""26.007.005.01"";
						
						// Резка импоста непрямой угол
						if( quBalkaImpostNestAngle > 0 ) 
						{
							decimal q = quBalkaImpostNestAngle;

							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка и фрезеровка импоста не под прямым углом"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1290 ); // Резка и фрезеровка импоста не под прямым углом
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}

						// Резка рамы/створки не под прямым углом менее 35 градусов
						if( quTrap35 > 0 ) 
						{
							decimal q = quTrap35;

							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка пластика под углом менее 35 град."",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1288 ); // Резка пластика под углом менее 35 град.
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}

					
						if( 1==0 && !inRange( Atechnology.ecad.Settings.idpeople, 168, 200 ) )
						{
							// Резка стали
							if( quBalkaArmirovka - quBalkaArmirovkaProkat > 0 ) 
							{
								decimal q = quBalkaArmirovka - quBalkaArmirovkaProkat;

								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
								drw = Order.DocWork.AddWorkOperForItem(""Резка стали SC-223"",q);
								if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
								DataRow p = GetWorkOper( 1207 ); // Резка стали SC-223
								if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
							}
					
							if( quBalkaArmirovkaProkat > 0 )
							{
								decimal q = quBalkaArmirovkaProkat;

								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
								drw = Order.DocWork.AddWorkOperForItem(""Резка проката SC-223"",quBalkaArmirovkaProkat);
								if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
								DataRow p = GetWorkOper( 1224 ); // Резка проката SC-223
								if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
							}
						}
						Err=""26.007.005.02"";
						// Армирование
						if( 1==0 && quBalkaArmirovka > 0 ) 
						{
							decimal q = quBalkaArmirovka;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							drw = Order.DocWork.AddWorkOperForItem(""Армирование SC-223"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1208 ); // Армирование SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}

						// Дренажи Kaban Нестандарт
					
						/* ВРЕМЕННО ОТКЛЮЧИЛ пока не добавили работу в справочник
						if( quDrenazh > 0 ) 
						{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
						drw = Order.DocWork.AddWorkOperForItem(""Дренажи Kaban Нестандарт"",quDrenazh);
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						}
						*/
						
						if( quDrenazhImpost > 0 )
						{
							decimal q = quDrenazhImpost;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							drw = Order.DocWork.AddWorkOperForItem(""Дренаж на импосте"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1928 ); // Дренаж на импосте SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}
						Err=""26.007.005.03"";
						// Фрезеровка ручки Kaban Нестандарт
						if( quHandle > 0 ) 
						{
							decimal q = quHandle;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							drw = Order.DocWork.AddWorkOperForItem(""Фрезеровка ручки SC-223"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
							DataRow p = GetWorkOper( 1226 ); // Фрезеровка ручки SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}		
					
					
						if( quRamaRama90 > 0 )
						{
							decimal q = quRamaRama90;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Murat SC-223"");
							drw = Order.DocWork.AddWorkOperForItem(""Торцовка рамы и соединение рама-рама через импостной соединитель для трапеций"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1316 ); // Торцовка рамы и соединение рама-рама через импостной соединитель для трапеций SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}
						#endregion	
						dtLogs += ""\n end canuse233 "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
					}
					else
					{
					
						#region Заготовка нестандарт -- Резка ПВХ окно Kaban Нестандарт
						// Балки рамы + Балки створки
						if( quBalkaRama + quBalkaStvorka > 0 ) 
						{
							decimal q = quBalkaRama + quBalkaStvorka;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка пластика Kaban Нестандарт"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
							DataRow p = GetWorkOper( 1205 ); // Резка пластика SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						}
						// Балка импоста
						if( quBalkaImpost /* + quBalkaImpost318 */ > 0 ) 
						{
							decimal q = quBalkaImpost /* + quBalkaImpost318 */;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка импоста Kaban Нестандарт"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1206 ); // Резка импоста SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							Order.DocWork.AddWorkOperForItem(""Фрезеровка импоста Kaban Нестандарт"",q);
						
							p = GetWorkOper( 1569 ); // Фрезеровка импоста SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							Order.DocWork.AddWorkOperForItem(""Сборка импоста Kaban Нестандарт"",q);
						
							p = GetWorkOper( 1570 ); // Сборка импоста SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						
						}
						// Резка импоста Kaban Нестандарт 318
						if( quBalkaImpost318 > 0 ) 
						{
							decimal q = quBalkaImpost318;
						
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка импоста Kaban Нестандарт 318"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1291 ); // Резка импоста 318
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}

						// Резка импоста непрямой угол
						if( quBalkaImpostNestAngle > 0 ) 
						{
							decimal q = quBalkaImpostNestAngle;

							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка и фрезеровка импоста не под прямым углом"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1290 ); // Резка и фрезеровка импоста не под прямым углом
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}

						// Резка рамы/створки не под прямым углом менее 35 градусов
						if( quTrap35 > 0 ) 
						{
							decimal q = quTrap35;

							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Резка пластика под углом менее 35 град. "",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1288 ); // Резка пластика под углом менее 35 град.
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}

					
						if( 1==0 && !inRange( Atechnology.ecad.Settings.idpeople, 168, 200 ) )
						{
							// Резка стали
							if( quBalkaArmirovka - quBalkaArmirovkaProkat > 0 ) 
							{
								decimal q = quBalkaArmirovka - quBalkaArmirovkaProkat;

								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
								drw = Order.DocWork.AddWorkOperForItem(""Резка стали Kaban Нестандарт"",q);
								if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
								DataRow p = GetWorkOper( 1207 ); // Резка стали SC-223
								if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
							}
					
							if( quBalkaArmirovkaProkat > 0 )
							{
								decimal q = quBalkaArmirovkaProkat;

								Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
								Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
								drw = Order.DocWork.AddWorkOperForItem(""Резка проката Kaban Нестандарт"",quBalkaArmirovkaProkat);
								if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
								DataRow p = GetWorkOper( 1224 ); // Резка проката SC-223
								if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
							}
						}

						// Армирование
						if( 1==0 && quBalkaArmirovka > 0 ) 
						{
							decimal q = quBalkaArmirovka;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Армирование Kaban Нестандарт"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1208 ); // Армирование SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}

						// Дренажи Kaban Нестандарт
					
						if( quDrenazh > 0 ) 
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Дренажи Kaban Нестандарт"",quDrenazh);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						}
						if( quDrenazhImpost > 0 )
						{
							decimal q = quDrenazhImpost;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Дренаж на импосте"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1928 ); // Дренаж на импосте SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}
					
						// Фрезеровка ручки Kaban Нестандарт
						if( quHandle > 0 ) 
						{
							decimal q = quHandle;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Фрезеровка ручки Kaban Нестандарт"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
							DataRow p = GetWorkOper( 1226 ); // Фрезеровка ручки SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}		
					
					
						if( quRamaRama90 > 0 )
						{
							decimal q = quRamaRama90;
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Торцовка рамы и соединение рама-рама через импостной соединитель для трапеций"",q);
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }

							DataRow p = GetWorkOper( 1316 ); // Торцовка рамы и соединение рама-рама через импостной соединитель для трапеций SC-223
							if( p != null ) sc223_summa += q * Useful.GetDecimal( p[""price1""], 0 ) * colorCoeff;
						}
						#endregion
					
						dtLogs += ""\n end kaban nest "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
					}
					#region Заготовка для Арок = Загиб арок
					if( quArka > 0 && 1==0 ) 
					{
						decimal q = quArka;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Работы по аркам"");
						drw = Order.DocWork.AddWorkOperForItem(""Заготовка арки"",q);
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
						DataRow p1 = GetWorkOper( 1453 ); // Заготовка арок SC-223
						if( p1 != null ) sc223_summa += q * Useful.GetDecimal( p1[""price1""], 0 ) * colorCoeff;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Работы по аркам"");
						drw = Order.DocWork.AddWorkOperForItem(""Загиб арки"",q);
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
						DataRow p2 = GetWorkOper( 1289 ); // Загиб арок SC-223
						if( p2 != null ) sc223_summa += q * Useful.GetDecimal( p2[""price1""], 0 ) * colorCoeff;

						
					}	
					#endregion
					
					
					
					
					drOI.AddFinparam( 410, sc223_summa, sc223_summa ); // Заготовка нестандарта на SC-223
					
					#region Сварка ПВХ окно Kaban
					//					if( quTrapRamaStvorka == 0 && ( quBalkaRama + quBalkaStvorka - quBalkaStvorka318 > 0 ) )
					//					{
					//						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
					//						drw = Order.DocWork.AddWorkOperForItem(""Сварка Kaban"", ( quBalkaRama + quBalkaStvorka - quBalkaStvorka318 ) );
					//						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					//						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
					//						drw = Order.DocWork.AddWorkOperForItem(""Зачистка Kaban"", ( quBalkaRama + quBalkaStvorka - quBalkaStvorka318 ) );
					//						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					//					}
					//					
					if( quTrapRamaStvorka == 0 && quBalkaRama > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						drw = Order.DocWork.AddWorkOperForItem(""Сварка рамы НСТ"", quBalkaRama );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						drw = Order.DocWork.AddWorkOperForItem(""Зачистка рамы НСТ"", quBalkaRama );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					if( quTrapRamaStvorka == 0 && ( quBalkaStvorka - quBalkaStvorka318 > 0 ) )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						drw = Order.DocWork.AddWorkOperForItem(""Сварка створки НСТ"", quBalkaStvorka - quBalkaStvorka318 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						drw = Order.DocWork.AddWorkOperForItem(""Зачистка створки НСТ"", quBalkaStvorka - quBalkaStvorka318 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					if( quTrapRamaStvorka > 0 )
					{
						decimal q = 1;
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						drw = Order.DocWork.AddWorkOperForItem(""Сварка Kaban трапеция"", q );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					if( quBalkaStvorka318 > 0 )
					{
						decimal q = quBalkaStvorka318;
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						drw = Order.DocWork.AddWorkOperForItem(""Сварка Kaban 318"", q );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сварка ПВХ окно Kaban"");
						drw = Order.DocWork.AddWorkOperForItem(""Зачистка Kaban 318"", q );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					#endregion
					Err=""26.011"";
					#region Сборка ПВХ окно Нестандарт
					if( quBalkaRama + quBalkaStvorka > 0 && isColorPVH )
					{
						int quSides = ( exOutColor ? 1:0 ) + ( exInColor ? 1:0 ) ;
						
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						drw = Order.DocWork.AddWorkOperForItem(""Закраска швов"", ( quBalkaRama + quBalkaStvorka ) * quSides );
					}
					
					if( quStvorka > 0 )
					{
						//						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						//						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						//						drw = Order.DocWork.AddWorkOperForItem(""Фальцлюфт Нестандарт"", ( quStvorka ) );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						if( !noWorkRezin )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Уплотнение в створку Нестандарт"", ( quStvorka ) + quGlassStvorkaRezin );						
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						}
						else if( noWorkRezin && drOI.profsys_name == ""Plaswin"" )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Уплотнение в створку Нестандарт"", quStvorka );	
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						}
					}
					Err=""26.011.02"";
					if( quBalkaImpost > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						drw = Order.DocWork.AddWorkOperForItem(""Установка импоста, сверление отверстий под петли Нестандарт"", ( quBalkaImpost ) );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					if( quBalkaImpostStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт""); // Сборка ПВХ окно Нестандарт
						Order.DocWork.AddWorkOperForItem(""Установка импоста в створку"", quBalkaImpostStvorka );
					}
					
					Err=""26.011.03"";
					if( quBalkaImpost318 > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						drw = Order.DocWork.AddWorkOperForItem(""Установка импоста Нестандарт 318"", ( quBalkaImpost318 ) );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					Err=""26.012"";
					if( quFurn318 + quFurnOrdinary > 0 )
					{
						if( quFurn318 > 0 )
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Установка фурнитуры Нестандарт 318"", quFurn318 );
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						}
							
						if( quFurnOrdinary > 0 ) 
						{
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Установка фурнитуры Нестандарт"", quFurnOrdinary );						
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
							
							Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
							drw = Order.DocWork.AddWorkOperForItem(""Установка фурнитуры в раму"", quFurnOrdinary );						
							if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						}
					}
					
					
					if( model.FurnitureSystem != ""Фурнитура БЕЗ"" && quFurn318 + quFurnOrdinary > 0 && model.ConstructionType.ID == 3 )
					{
						// Установка фурнитуры в БД
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						drw = Order.DocWork.AddWorkOperForItem(""Установка фурнитуры в БД"", quFurn318 + quFurnOrdinary );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					
					if( !noWorkRezin && ( quStvorka + quGluhar > 0 ) )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						drw = Order.DocWork.AddWorkOperForItem(""Уплотнение в раму Нестандарт"", quStvorka + quGluhar );						
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					Err=""26.013"";
					if( quBalkaImpost > 0 && !drOI.IsidprofsysNull() && inRange( drOI.idprofsys, 145 ) && complectCorp )
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ окно Нестандарт"", ""Установка заглушки импоста"", quBalkaImpost * 2 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quRemoteControl > 0 )
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ окно Нестандарт"", ""Установка привода дистанционного открывания"", quRemoteControl );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					if( quNozhnicAdditional > 0 )
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ окно Нестандарт"", ""Установка привода дистанционного открывания (установка ножниц)"", quNozhnicAdditional );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					
					if( isNegabaritPVH )
					{
						// Доплата за сложность (негабарит) 1352
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность (негабарит)"", 1 );
					}
					
					if( isNegabaritPVH2 )
					{
						// Доплата за сложность (негабарит) 1352
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность (негабарит)"", 1 );
						
						//Order.AddErrorUnical(drOI.idorderitem,""и815"","""",""Одна из сторон конструкции превышает 3100 мм. Согласование с производством НЕ требуется!"");
					}
					if( isBlackShagrenLam )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Доплата за сложность"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность ламинации (черная шагрень)"", 1 );
					}
					
					if( quFramugas > 0 )
					{
						// Доплата за сложность (негабарит) 1352
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						Order.DocWork.AddWorkOperForItem(""Установка фрикционной петли"", quFramugas );
					}
					
					if( quPortals > 0 )
					{
						// Доплата за сложность (негабарит) 1352
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						Order.DocWork.AddWorkOperForItem(""Установка портала"", quPortals );
					}
					
					if( quHandleDrill > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						Order.DocWork.AddWorkOperForItem(""Сверление отверстий под ручку НСТ"", quHandleDrill );	
					}
					
					
					if( quImpostVImpost > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						Order.DocWork.AddWorkOperForItem(""Установка соедининения импост/импост нестандарт"", quImpostVImpost );	
					}
					
					if( quVentHoles > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						Order.DocWork.AddWorkOperForItem(""Сверление компенсационного отверстия НСТ"", quVentHoles );	
					}
					
					#endregion
					
					#region Запакетка ПВХ (для нестандарта)
					/*
					if( quGlassStvorka > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Запакетка ПВХ"");
						drw = Order.DocWork.AddWorkOperForItem(""Запакетка створки Нестандарт"", quGlassStvorka );
					}
					if( quGlassGluhar > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Запакетка ПВХ"");
						drw = Order.DocWork.AddWorkOperForItem(""Запакетка глухаря Нестандарт"", quGlassGluhar );
					}
					if( quShtapik > 0 ) 
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Запакетка ПВХ"");
						drw = Order.DocWork.AddWorkOperForItem(""Резка штапика Нестандарт"", quShtapik );
					}*/
					
					if( quShtapikRama + quShtapikStvorka > 0 ) // Резка штапика Стандарт
					{
						drw = AddWorkByName( Order, drOI, ""Распил штапика"", ""Резка штапика Стандарт"", quShtapikRama + quShtapikStvorka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quShtapikRamaNest + quShtapikStvorkaNest > 0 ) // Резка штапика Нестандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ"", ""Резка штапика Нестандарт"", quShtapikRamaNest + quShtapikStvorkaNest );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quGlassStvorka > 0 ) // Запакетка створки Стандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ"", ""Запакетка створки Стандарт"", quGlassStvorka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quGlassStvorkaNest > 0 ) // Запакетка створки Нестандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ"", ""Запакетка створки Нестандарт"", quGlassStvorkaNest );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quGlassGluhar > 0 ) // Запакетка глухаря Стандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ"", ""Запакетка глухаря Стандарт"", quGlassGluhar );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quGlassGluharNest > 0 ) // Запакетка глухаря Нестандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ"", ""Запакетка глухаря Нестандарт"", quGlassGluharNest );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quGlassVkleyka > 0 ) // Вклейка
					{
						drw = AddWorkByName( Order, drOI, ""Вклейка стеклопакета"", ""Вклейка стеклопакета"", quGlassVkleyka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					#endregion
					dtLogs += ""\n end zapaketka nets pvh "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
					#region Картон
					if((drOI.idcolorin != 2 || drOI.idcolorout != 2))
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Упаковка из картона"");
						Order.DocWork.AddWorkOperForItem(""Упаковка из картона"", quRama );
					}
					
					#endregion Картон

					#region Клапан Аэреко
					if( quAereco > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Фрезеровка под клапан АЭРЭКО"");
						Order.DocWork.AddWorkOperForItem(""Фрезеровка под клапан АЭРЭКО"", quAereco );
					}
					#endregion
					
					#region Шаттл
					bool isK4Lam = false;
					try
					{
						ds_order.finparamcalcRow f = drOI.GetFinparam( 474 );
						isK4Lam = f != null && f.sm == 1;
					}
					catch( Exception E )
					{
					}
					if( isK4Lam )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Формирование шаттла"");
						Order.DocWork.AddWorkOperForItem(""Формирование шаттла"", 1 );
					}
					#endregion
					
					#endregion
					
					if( 1==1 )
					{
						string[] itr_works = {""ЗП бригадира"",""ЗП начальника участка"",""ЗП передельщика""};
						string[] itr_work_groups = {""Резка ПВХ окно Murat SC-223"",""Резка ПВХ окно Kaban Нестандарт"",""Сварка ПВХ окно Kaban"",""Сборка ПВХ окно Нестандарт"",""Запакетка ПВХ""};						
						#region Работы для ИТР
						foreach( string g in itr_work_groups ) { foreach( string s in itr_works ) { AddWorkByName( Order, drOI, g, s, 1 ); } }
						#endregion
					}
					
					#region Добавление финпараметра Длина Ламинации для ограничения сроков бронирования
					if( lamlen > 0 && Atechnology.ecad.Settings.idpeople != 168 )
					{
						// drOI.AddFinparam( 449, ((decimal)lamlen)/1000, ((decimal)lamlen)/1000 );
					}
					#endregion
				}
				else if( 
					( 
					inRange( drOI.idpower, 4, 5 ) || ( inRange( drOI.idpower, 3, 66 ) && isPlaswinLam ) 
					) && !drOI.IsidconstructiontypeNull() && inRange( drOI.idconstructiontype, 6, 7, 35, 36, 55  ) ) // ПВХ Нестандарт + Ламинация ДВЕРЕЙ
				{
					#region Расчет показателей
					int quRama = 0;
					int quStvorka = 0;
					int quStvorkaWindow = 0;
					int quBalkaRama = 0;
					int quBalkaRamaPorog = 0;
					int quBalkaStvorka = 0;
					int quBalkaStvorkaWindow = 0;
					int quBalkaStvorka318 = 0;
					int quBalkaImpost = 0;
					int quBalkaImpostNestAngle = 0;
					//					int quBalkaImpost318 = 0;
					int quHandle = 0;
					int quHandleDrill = 0;
					int quHandleWindow = 0;
					int quFurnOrdinary = 0;
					int quFurnWindow = 0;
					int quFurn318 = 0;
					int quGluhar = 0;
					int quGlassStvorka = 0;
					int quGlassStvorkaWindow = 0;
					int quGlassGluhar = 0;
					int quGlassStvorkaNest = 0;
					int quGlassStvorkaNestWindow = 0;
					int quGlassGluharNest = 0;
					int quShtapikRama = 0;
					int quShtapikRamaNest = 0;
					int quShtapikStvorka = 0;
					int quShtapikStvorkaNest = 0;
					int quShtapikStvorkaWindow = 0;
					int quShtapikStvorkaNestWindow = 0;
					
					int quBalkaArmirovka = 0;
					int quBalkaArmirovkaProkat = 0;
					int quArka = 0;
					int quTrap = 0;
					//					int quArkaStvorka = 0;
					//					int quTrapStvorka = 0;
					int quDrenazh = SaveDrenag( model );
					
					int quSecondZamok = 0;
					
					int quGlassStvorkaRezin = 0;
					
					int quHandleWithHoles = 0;
					int quGlassVkleyka = 0;
					int quDrenazhImpost = 0;
					int quImpostVImpost = 0;
					
					
					
					bool isColorPVH = 
						( !drOI.IsidcolorinNull() && !inRange( drOI.idcolorin, 2 ) ) ||
						( !drOI.IsidcoloroutNull() && !inRange( drOI.idcolorout, 2 ) );
					decimal colorCoeff = 1.3M;
					//					decimal colorCoeff = 1; ЗАМЕНИЛ 04.06.2018.  Согласовано: Гаряев

					bool exOutColor = !inRange( drOI.idcolorout, 0, 2 );
					bool exInColor = !inRange( drOI.idcolorin, 0, 2 );

					int lamlen = 0;
					
					int lamlencoeff = 1;
					if( exOutColor && exInColor ) lamlencoeff = 2;
					
					quRama = 1;
					
					foreach (Glass g in model.GlassList)
					{
						if( g.ModelPart==ModelPart.Stvorka )
						{
							quGlassStvorkaRezin++; // Количество контуров уплотнения в створку (ставится в т.ч. когда нет заполнения)
						}
						if( /*!( g.Marking.ToLower().Contains(""без"") ) &&*/ ( g.Marking.ToLower() != ""без_стекла_и_штапика"" ) ) 
						{ 
							if( !( g.Marking.ToLower().Contains(""без"") ) && ( g.Marking.ToLower() != ""без_стекла_и_штапика"" ) )
							{
								UserParam u2 = g.GetUserParam(""Вклейка стеклопакета"");
								if( u2 != null && u2.StrValue.ToLower() == ""да"" )
								{
									quGlassVkleyka++;
								}
							}
							
							bool isStvorkaInStvorka = false;
							foreach( Stvorka s in model.StvorkaList )
							{
								if( g.ModelItem == s )
								{
									if( s.ParentStvorka != null ) { isStvorkaInStvorka = true; break; }
								}
							}
							
							bool isNest = false;
							foreach(GlassItem gi in g)
							{
								// quShtapik++; // Количество штапиков
								if( g.ModelPart == ModelPart.Stvorka )
								{
									if( 
										( !inRange( gi.Ang1, 0, 90, 45, 180 ) ) 
										|| 
										( !inRange( gi.Ang2, 0, 90, 45, 180 ) )
										|| gi.Radius1 != 0 || gi.Radius2 != 0
										)
									{
										if( isStvorkaInStvorka )
										{
											quShtapikStvorkaNestWindow++;
										}
										else
										{
											quShtapikStvorkaNest++;
										}
										isNest = true;
									}
									else
									{
										if( isStvorkaInStvorka )
										{
											quShtapikStvorkaWindow++;
										}
										else
										{
											quShtapikStvorka++;
										}
									}
								}
								else
								{
									if( 
										( !inRange( gi.Ang1, 0, 90, 45, 180 ) ) 
										|| 
										( !inRange( gi.Ang2, 0, 90, 45, 180 ) )
										|| gi.Radius1 != 0 || gi.Radius2 != 0
										)
									{
										isNest = true;
										quShtapikRamaNest++;
									}
									else
									{
										quShtapikRama++;
									}
									
								}
								// Длина лам. штапика
								if( exInColor && gi.Radius1 == 0 && gi.Radius2 == 0 ) lamlen += gi.LenghtShtapik;
							}

							// Длины лам. фальшей
							if( g.Falsh != null )
							{
								if( exOutColor && ( g.Falsh.Side == FalshSide.DoubleSide || g.Falsh.Side == FalshSide.OutSide ) ) lamlen += g.Falsh.Perimetr;
								if( exInColor && ( g.Falsh.Side == FalshSide.DoubleSide || g.Falsh.Side == FalshSide.InSide ) ) lamlen += g.Falsh.Perimetr;
							}
							
							if( g.ModelPart==ModelPart.Stvorka )
							{
								if( !isNest )
								{
									if( isStvorkaInStvorka )
									{
										quGlassStvorkaWindow++;
									}
									else
									{
										quGlassStvorka++; // Количество запакеток створок
									}
								}
								else
								{
									if( isStvorkaInStvorka )
									{
										quGlassStvorkaNestWindow++;
									}
									else
									{
										quGlassStvorkaNest++;
									}
								}
							}
							else
							{
								if( !isNest )
								{
									quGlassGluhar++; // Количество запакеток глухарей
								}
								else
								{
									quGlassGluharNest++; // Количество запакеток глухарей
								}
							}
						} 
						if (g.ModelPart==ModelPart.Stvorka)
						{
							//Створка
						}
						else
						{
							quGluhar++;
							//Глухарь
						}						
					}

					
					//Балки рамы
					foreach(RamaItem ri in model.Rama)
					{
						if( ri.HeightArc != 0 ) 
						{
							quArka++;
						}
						if( ( ri.Ang1 != 45 ) || ( ri.Ang2 != 45 ) ) 
						{
							quTrap++;
						}
							
						if(ri.Marking.ToLower().Contains(""без""))
						{
							continue;
						}
						else
						{
							quBalkaRama++;
							
							// Длина ламиниарованных рам
							if( isColorPVH && ri.Radius1 == 0 && ri.Radius2 == 0 ) lamlen += lamlencoeff * ri.LengthInterfaceCalcInt; 
							
							if( ri.MarkingSteel.ToString() != """" )
							{
								quBalkaArmirovka++;
								if( inRange( ri.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
							}
							if( ri.BalkaType == ModelPart.Porog )
							{
								quBalkaRamaPorog++;
							}
						}
					}
					
					foreach (Stvorka s in model.StvorkaList)
					{
						bool isStvorkaInStvorka = s.ParentStvorka != null;

						if( isStvorkaInStvorka )
						{
							quStvorkaWindow++;
						}
						else
						{
							quStvorka++;
						}
						//Балки створки
						bool is318 = false;
						foreach(StvorkaItem si in s)
						{
							if(si.Marking.ToLower().Contains(""без""))
								continue;
							
							// Длина ламинированных створок
							if( isColorPVH && si.Radius1 == 0 && si.Radius2 == 0 ) lamlen += lamlencoeff * si.LengthInterfaceCalcInt;
							
							if( isStvorkaInStvorka )
							{
								quBalkaStvorkaWindow++;
							}
							else
							{
								quBalkaStvorka++;
							}
							if( ( is318 == false) && ( si.Marking.ToLower().Contains(""318"") ) && ( drOI.profsys_name == ""KBE Эталон 58"" ) )
							{
								is318 = true;
							}
							if( si.MarkingSteel.ToString() != """" )
							{
								quBalkaArmirovka++;
								if( inRange( si.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
							}
							
							if( si.HeightArc != 0 ) 
							{
								quArka++;
							}
							if( ( si.Ang1 != 45 ) || ( si.Ang2 != 45 ) ) 
							{
								quTrap++;
							}
							if( is318 ) 
							{
								quBalkaStvorka318++;
							}

						}
						//если фурнитура не Фурнитура без и створка 318
						if(!s.FurnitureSystem.Contains(""без"") && is318)
						{
							quFurn318++;
						}
						else if( ( !s.FurnitureSystem.Contains(""без"") ) && ( !is318 ) )
						{
							if( isStvorkaInStvorka )
							{
								quFurnWindow++;
							}
							else
							{
								quFurnOrdinary++;
								if( s.HandlePosition > 0 && s.Shtulp==null && inRange( s.GetUserParam(""Второй замок"").StrValue, ""Ригель-защелка"", ""Ригель-ролик"" ) )
								{
									quSecondZamok ++;
								}
							}
						}
						
						try
						{
							UserParam u2 = s.GetUserParam(""Сверлить отверстия под ручку"");
							if( u2 != null )
							{
								if( u2.StrValue.ToLower() == ""да"" && u2.Visible ) quHandleWithHoles ++;
							}
						}
						catch( Exception E )
						{
								
						}
						
						if(s.HandlePosition > 0 && s.Shtulp==null )
						{							
							if( isStvorkaInStvorka )
							{
								quHandleWindow++;
								UserParam up3 = s.GetUserParam(""Ручка оконная"");
								if( !s.FurnitureSystem.ToLower().Contains(""фурнитура без"") && up3 != null && up3.StrValue!=""Без ручки, Без фурнитуры, Только петли"" )
								{
									quHandleDrill++;
								}
							}
							else
							{
								quHandle++;
							}
						}
					}				
					
					bool exDrenazhImpost = inRange( model.GetUserParam(""Дренаж"").StrValue.ToLower(), ""авто"", ""снизу"" );
					foreach (Impost i in model.ImpostList)
					{
						//Балки импоста
						if(i.Marking.ToLower().Contains(""без"") && i.ImpostType != ImpostType.Shtulp)
							continue;

						// Длина ламинированных импостов
						if( isColorPVH && i.Radius1 == 0 && i.Radius2 == 0 ) lamlen += lamlencoeff * i.LengthInterfaceCalcInt;
						
						if( !inRange( i.Ang1, 0, 45, 90 ) || !inRange( i.Ang2, 0, 45, 90 ) ) 
						{
							quBalkaImpostNestAngle++;
						}
						else
						{
							quBalkaImpost++;
						}

						if( i.MarkingSteel.ToString() != """" )
						{
							quBalkaArmirovka++;
							if( inRange( i.MarkingSteel, ""207 (1,2)"", ""203 (1,2)"", ""L-образная импост"", ""L-образная в створку и раму"" ) ) quBalkaArmirovkaProkat ++;
						}
						if( i.HeightArc != 0 ) 
						{
							quArka++;
						}
						if( !inRange( i.Ang1, 0, 45, 90 ) || !inRange( i.Ang1, 0, 45, 90 ) ) 
						{
							quTrap++;
						}
						
						if( exDrenazhImpost && !i.Marking.ToLower().Contains(""без"") && inRange( i.AngleHorisont, 0, 180 ) )
						{
							quDrenazhImpost += 1;
						}
						if( i.BalkaStart != null && i.BalkaStart.BalkaType == ModelPart.Impost ) quImpostVImpost ++;
						if( i.BalkaEnd != null && i.BalkaEnd.BalkaType == ModelPart.Impost ) quImpostVImpost ++;
						
					}
					#endregion
					
					#region Добавление работ
					ds_docwork.docworkRow drw = null;

					#region Резка ПВХ дверь 
					if( quBalkaRama + quBalkaStvorka > 0 ) // Резка пластика дверь
					{
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ дверь"", ""Резка пластика дверь"", quBalkaRama + quBalkaStvorka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					if( quBalkaStvorkaWindow > 0 )
					{
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ окно Kaban Нестандарт"", ""Резка пластика Kaban Нестандарт"", quBalkaStvorkaWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					if( quBalkaArmirovka > 0 ) // Резка стали дверь, Армировка дверь
					{
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ дверь"", ""Резка стали дверь"", quBalkaArmirovka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ дверь"", ""Армировка дверь"", quBalkaArmirovka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quDrenazh > 0 ) // Дренажи дверь
					{
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ дверь"", ""Дренажи дверь"", quDrenazh );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quBalkaImpost > 0 ) // Резка импоста дверь
					{
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ дверь"", ""Резка импоста дверь"", quBalkaImpost );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quBalkaImpostNestAngle > 0 ) // Резка импоста с нестандартными углами дверь
					{
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ дверь"", ""Резка и фрезеровка импоста не под прямым углом дверь"", quBalkaImpostNestAngle );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quHandle > 0 ) // Фрезеровка ручки дверь
					{
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ дверь"", ""Фрезеровка ручки дверь"", quHandle );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quHandleWindow > 0 ) // Фрезеровка ручки окно
					{
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ окно Kaban Нестандарт"", ""Фрезеровка ручки Kaban Нестандарт"", quHandleWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					if( quHandleWithHoles > 0 ) 
					{
						drw = AddWorkByName( Order, drOI, ""Резка ПВХ дверь"", ""Фрезеровка армирования под ручку-скобу"", quHandleWithHoles );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					/*
					if( quDrenazhImpost > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка ПВХ окно Kaban Нестандарт"");
						drw = Order.DocWork.AddWorkOperForItem(""Дренаж на импосте"",quDrenazhImpost);
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					*/
					
					#endregion
					#region Сварка ПВХ дверь
					if( quBalkaRama - quBalkaRamaPorog*2 > 0 ) // Сварка рам дверь, Зачистка рам дверь
					{
						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ дверь"", ""Сварка рам дверь"", quBalkaRama - quBalkaRamaPorog*2 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ дверь"", ""Зачистка рам дверь"", quBalkaRama - quBalkaRamaPorog*2 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quBalkaStvorka - quBalkaStvorka318 > 0 ) // Сварка створок дверь, Зачистка створок дверь (НЕ 318я створка)
					{
						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ дверь"", ""Сварка створок дверь"", quBalkaStvorka - quBalkaStvorka318 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ дверь"", ""Зачистка створок дверь"", quBalkaStvorka - quBalkaStvorka318 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quBalkaStvorka318 > 0 ) // Сварка створок дверь, Зачистка створок дверь (318я стврка)
					{
						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ дверь"", ""Сварка 318-ой створки"", quBalkaStvorka318 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ дверь"", ""Зачистка 318-ой створки"", quBalkaStvorka318 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					//					if( quBalkaStvorkaWindow > 0 ) // Сварка створок ОКНО
					//					{
					//						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ окно Kaban"", ""Сварка Kaban"", quBalkaStvorkaWindow );
					//						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					//						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ окно Kaban"", ""Зачистка Kaban"", quBalkaStvorkaWindow );
					//						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					//					}
					
					if( quBalkaStvorkaWindow > 0 ) // Сварка створок ОКНО
					{
						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ окно Kaban"", ""Сварка створки НСТ"", quBalkaStvorkaWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						drw = AddWorkByName( Order, drOI, ""Сварка ПВХ окно Kaban"", ""Зачистка створки НСТ"", quBalkaStvorkaWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}


					#endregion
					#region Сборка ПВХ дверь
					if( quBalkaImpost > 0 ) // Установка импоста дверь
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ дверь"", ""Установка импоста дверь"", quBalkaImpost );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quStvorka > 0 ) // Проверка фальцлюфта дверь, Уплотнение в створку дверь
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ дверь"", ""Проверка фальцлюфта дверь"", quStvorka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ дверь"", ""Уплотнение в створку дверь"", quStvorka + quGlassStvorka + quGlassStvorkaNest );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quStvorkaWindow > 0 ) // Проверка фальцлюфта ОКНО, Уплотнение в створку ОКНО
					{
						//drw = AddWorkByName( Order, drOI, ""Сборка ПВХ окно Нестандарт"", ""Фальцлюфт Нестандарт"", quStvorkaWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ окно Нестандарт"", ""Уплотнение в створку Нестандарт"", quStvorkaWindow + quGlassStvorkaWindow + quGlassStvorkaNestWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quStvorka + quGluhar > 0 ) // Уплотнение в раму дверь
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ дверь"", ""Уплотнение в раму дверь"", quStvorka + quGluhar );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quStvorkaWindow > 0 ) // Уплотнение в раму ОКНО
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ окно Нестандарт"", ""Уплотнение в раму Нестандарт"", quStvorkaWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quFurnOrdinary + quSecondZamok > 0 ) // Установка фурнитуры дверь
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ дверь"", ""Установка фурнитуры дверь"", quFurnOrdinary + quSecondZamok );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quFurnWindow > 0 ) // Установка фурнитуры ОКНО
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ окно Нестандарт"", ""Установка фурнитуры Нестандарт"", quFurnWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quHandleDrill > 0 )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Сборка ПВХ окно Нестандарт"");
						Order.DocWork.AddWorkOperForItem(""Сверление отверстий под ручку НСТ"", quHandleDrill );	
					}

					if( quFurn318 > 0 ) // Установка фурнитуры 318-ая створка
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ дверь"", ""Установка фурнитуры 318-ая створка"", quFurn318 );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quHandleWithHoles > 0 ) 
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ дверь"", ""Фрезеровка пластика под ручку-скобу"", quHandleWithHoles );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					if( quImpostVImpost > 0 ) 
					{
						drw = AddWorkByName( Order, drOI, ""Сборка ПВХ дверь"", ""Установка соединения импост/импост Дверь"", quImpostVImpost );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					#endregion
					#region Запакетка ПВХ дверь
					if( quShtapikRama + quShtapikStvorka > 0 ) // Резка штапика Стандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ дверь"", ""Резка штапика Стандарт дверь"", quShtapikRama + quShtapikStvorka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quShtapikStvorkaWindow > 0 ) // Резка штапика Стандарт ОКНО
					{
						drw = AddWorkByName( Order, drOI, ""Распил штапика"", ""Резка штапика Стандарт"", quShtapikStvorkaWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quShtapikRamaNest + quShtapikStvorkaNest > 0 ) // Резка штапика Нестандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ дверь"", ""Резка штапика Нестандарт дверь"", quShtapikRamaNest + quShtapikStvorkaNest );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quShtapikStvorkaNestWindow > 0 ) // Резка штапика Нестандарт ОКНО
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ"", ""Резка штапика Нестандарт"", quShtapikStvorkaNestWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quGlassStvorka > 0 ) // Запакетка створки Стандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ дверь"", ""Запакетка створки Стандарт дверь"", quGlassStvorka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quGlassStvorkaWindow > 0 ) // Запакетка створки Стандарт ОКНО
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ"", ""Запакетка створки Стандарт"", quGlassStvorkaWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					
					if( quGlassStvorkaNest > 0 ) // Запакетка створки Нестандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ дверь"", ""Запакетка створки Нестандарт дверь"", quGlassStvorkaNest );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}

					if( quGlassStvorkaNestWindow > 0 ) // Запакетка створки Нестандарт ОКНО
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ"", ""Запакетка створки Нестандарт"", quGlassStvorkaNestWindow );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					
					
					
					if( quGlassGluhar > 0 ) // Запакетка глухаря Стандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ дверь"", ""Запакетка глухаря Стандарт дверь"", quGlassGluhar );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quGlassGluharNest > 0 ) // Запакетка глухаря Нестандарт дверь
					{
						drw = AddWorkByName( Order, drOI, ""Запакетка ПВХ дверь"", ""Запакетка глухаря Нестандарт дверь"", quGlassGluharNest );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					if( quGlassVkleyka > 0 ) // Вклейка
					{
						drw = AddWorkByName( Order, drOI, ""Вклейка стеклопакета"", ""Вклейка стеклопакета"", quGlassVkleyka );
						if( isColorPVH ) { drw.price *= colorCoeff; drw.sm *= colorCoeff; }
					}
					#endregion
					
					#region Картон

					if((drOI.idcolorin != 2 || drOI.idcolorout != 2))
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Упаковка из картона"");
						Order.DocWork.AddWorkOperForItem(""Упаковка из картона"", quRama );
					}

					#endregion Картон
					
					if( isBlackShagrenLam )
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Доплата за сложность"");
						Order.DocWork.AddWorkOperForItem(""Доплата за сложность ламинации (черная шагрень)"", 1 );
					}
					
					#endregion
					
					string[] itr_works = {""ЗП бригадира"",""ЗП начальника участка"",""ЗП передельщика""};
					string[] itr_work_groups = {""Резка ПВХ дверь"",""Резка ПВХ окно Kaban Нестандарт"",""Сварка ПВХ дверь"",""Сварка ПВХ окно Kaban"",""Сборка ПВХ дверь"",""Сборка ПВХ окно Нестандарт"",""Запакетка ПВХ"",""Запакетка ПВХ дверь""};						
					#region Работы для ИТР
					foreach( string g in itr_work_groups ) { foreach( string s in itr_works ) { AddWorkByName( Order, drOI, g, s, 1 ); } }
					#endregion
					
					#region Добавление финпараметра Длина Ламинации для ограничения сроков бронирования
					if( lamlen > 0 && Atechnology.ecad.Settings.idpeople != 168 )
					{
						// drOI.AddFinparam( 449, ((decimal)lamlen)/1000, ((decimal)lamlen)/1000 );
					}
					#endregion
				}
				#endregion
				dtLogs += ""\n before SP "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
				#region СП
				if(drOI.idproductiontype==114) //Стекло
				{
					Err=""26"";
					#region Стекла
					//AtLog.LogInstance.DebugFormat(""HI"");
					if(!drOI.IssqrNull())
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
					
				
						if (!drOI.IsisstandartNull()&&!drOI.isstandart) {
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление стекла"");
							Order.DocWork.AddWorkOperForItem(""Площадь кв.м. за нестандарт"",drOI.sqr);
						} 
						else {
							Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление стекла"");
							Order.DocWork.AddWorkOperForItem(""Площадь кв.м."",drOI.sqr);
						}	
						
					}
					#endregion
				}
				else if(drOI.idproductiontype==108)//Тонировка пленкой стекло
				{
					Err=""27"";
					#region Тонировка стекла
					//AtLog.LogInstance.DebugFormat(""HI"");
					if(!drOI.IssqrNull())
					{
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
				
						
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Тонировка пленкой"");
						Order.DocWork.AddWorkOperForItem(""Площадь кв.м."",drOI.sqr);
						
						
					}
					#endregion
				}
				#endregion

				#region Сэндвич в составе конструкции
				if(drOI.idproductiontype==113 && !drOI.IsispfNull() && drOI.ispf && !drOI.IsparentidNull() ) //Сэндвич
				{
					Err=""26"";
					#region Сэндвич

					string[] itr_works = {""ЗП бригадира"",""ЗП начальника участка"",""ЗП передельщика""};
					
					ds_order.orderitemRow drParent = getRootProduction( drOI );
					
					if( drParent != null )
					{
						int idworkoper = 0;
						
						string[] itr_work_groups = {""""};
						
						switch( drParent.idpower )
						{
							case 3:
								idworkoper = 1185;
								itr_work_groups[0] = ""Резка сэндвича ПВХ Стандарт"";
								break;
							case 4:
								idworkoper = 1186;
								itr_work_groups[0] = ""Резка сэндвича ПВХ Нестандарт"";
								break;
							case 5:
								idworkoper = 1186;
								itr_work_groups[0] = ""Резка сэндвича ПВХ Нестандарт"";
								break;
							case 66:
								idworkoper = 1188;
								itr_work_groups[0] = ""Резка сэндвича ПВХ Полунестандарт"";
								break;
							case 52:
								idworkoper = 1187;
								//								itr_work_groups[0] = ""Резка сэндвича Алюминий"";
								break;
						}
						

						
						if( idworkoper != 0 )
						{
							AddWorkByID( Order, drOI, idworkoper, 1 );
							
							if( itr_work_groups[0] != """" )
							{
								foreach( string g in itr_work_groups ) { foreach( string s in itr_works ) { AddWorkByName( Order, drOI, g, s, 1 ); } }
							}
						}
						
					}
					
					//	Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);

					/*
					if (!drOI.IsisstandartNull()&&!drOI.isstandart) {
					Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление стекла"");
					Order.DocWork.AddWorkOperForItem(""Площадь кв.м. за нестандарт"",drOI.sqr);
					} 
					else {
					Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление стекла"");
					Order.DocWork.AddWorkOperForItem(""Площадь кв.м."",drOI.sqr);
					}	
					*/	
					#endregion
				}
				#endregion

				
				#region Соединители и расширители
	
				if( inRange(drOI.idpower, 12,90,125,139) && !drOI.IsispfNull() && drOI.ispf == true ) // Ноапиловка соединителей, расширителей в составе изделий
				{
					Err=""28"";
					// Добавление работ напиловка соединителей, расширителей
					Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
					Order.DocWork.SetCalcParam(drOI.idorderitem,""Резка соединителей, расширителей в составе конструкции"");
					Order.DocWork.AddWorkOperForItem(""Резка соединителей, расширителей в составе конструкции"",1);
					
					if( 1==1 )
					{
						string[] itr_works = {""ЗП бригадира"",""ЗП начальника участка"",""ЗП передельщика""};
						string[] itr_work_groups = {""Резка соединителей, расширителей в составе конструкции""};
						#region Работы для ИТР
						foreach( string g in itr_work_groups ) { foreach( string s in itr_works ) { AddWorkByName( Order, drOI, g, s, 1 ); } }
						#endregion
					}
				
				}
				#endregion
				
				#region Работы для перильных ограждений
				if(1==1)
				{
					if(drOI.idproductiontype == 1720)
					{
						Err = ""DW_Ogr_1.1"";
						Order.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
						Order.DocWork.SetCalcParam(drOI.idorderitem,""Изготовление перильных ограждений"");
						decimal len = drOI.GetModelParamList()[""Ширина""].IntValue2;
						if(len <= 1000)
						{
							Order.DocWork.AddWorkOperForItem(""Упаковка ограждения до 1000 мм"", 1);
						}
						else if(len > 1000 && len <= 1500)
						{
							Order.DocWork.AddWorkOperForItem(""Упаковка ограждения от 1000 до 1500 мм"", 1);
						}
						else if(len > 1500 && len <= 2000)
						{
							Order.DocWork.AddWorkOperForItem(""Упаковка ограждения от 1500 до 2000 мм"", 1);
						}
						else if(len > 2000 && len <= 2500)
						{
							Order.DocWork.AddWorkOperForItem(""Упаковка ограждения от 2000 до 2500 мм"", 1);
						}
						else if(len > 2500 && len <= 3000)
						{
							Order.DocWork.AddWorkOperForItem(""Упаковка ограждения от 2500 до 3000 мм"", 1);
						}
						
						decimal quVert = 0;
						
						if(drOI.GetModelParamList()[""Шаг вертикального элемента""].StrValue == ""Авто"")
						{
							quVert = (int)(len / 100)-1;
							Order.DocWork.AddWorkOperForItem(""Установка вертикальной трубы"", quVert);
						}
						if(drOI.GetModelParamList()[""Шаг вертикального элемента""].StrValue == ""Ручной ввод"")
						{
							decimal step = drOI.GetModelParamList()[""Шаг""].IntValue2;
							quVert = (int)(len / step) - 1;
							Order.DocWork.AddWorkOperForItem(""Установка вертикальной трубы"", quVert);
						}
						
						if( quVert > 0 )
						{
							drOI.AddFinparam( 681, quVert, quVert );
							
							drOI.AddFinparam( 736, quVert, quVert );
						}
					}
				}
				#endregion Работы для перильных ограждений
				dtLogs += ""\n end all "" + DateTime.Now.ToString(""yyyy.MM.dd HH:mm:ss.fff""); 
				CalcProcessor.Modules[""EndApdexLog""](new object[] { LastIdApdexLog1 });
				StartStopExecutionTimeCounter(false, ref idPerfomanceLog, ""idorder: "" + drOI.idorder + "" idorderitem: "" + drOI.idorderitem);
				//if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(dtLogs);
			}
			catch(Exception e)
			{
				Order.AddErrorUnical(drOI.idorderitem,""о002"","""",""Ошибка скрипта Расчета работ и операций:\r\n""+e.Message+""\r\n""+e.TargetSite.ToString()+"" \r\n""+e.StackTrace+""\r\nТочка:""+Err);
			}
			//			if (AtLog.Enabled) {
			//				AtLog.LogInstance.DebugFormat(""Конец скрипта расчета"");
			//			}
		}
		
		public void fillModelPartClass_FromTo( Balka b, ModelPartClass mpc, ref double aFrom, ref double aTo )
		{
			if( mpc == null ) return;
			
			switch( (int)b.AngNakl )
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
			if( aFrom > aTo ) {	double t = aFrom; aFrom = aTo; aTo = t; } // Переворот
			aFrom = Math.Round( aFrom,1 ); aTo = Math.Round( aTo,1 );
		}
		
		void CountDrenazh( Balka ri, ref decimal quDrenaz )
		{
			if( ri.LengthInterfaceCalc <= 700 )
			{
				quDrenaz += 2;
			}
			else if( ri.LengthInterfaceCalc > 700 && ri.LengthInterfaceCalc <= 1200 )
			{
				quDrenaz += 3;
			}
			else if( ri.LengthInterfaceCalc > 1200 )
			{
				quDrenaz += 4;
			}
		}
		
		ds_order.orderitemRow getRootProduction( ds_order.orderitemRow drOI_cur )
		{
			ds_order.orderitemRow drParent_OI = null;
			if( drOI_cur == null ) return null;
			if( !drOI_cur.IsparentidNull() )
			{
				foreach(ds_order.orderitemRow drOI_1 in Order.ds.orderitem.Select(""idorderitem=""+drOI_cur.parentid.ToString()))
				{
					drParent_OI = drOI_1;
				}
			}
			if( drParent_OI == null ) 
			{
				return drOI_cur;
			}
			else
			{
				if( drParent_OI.idproductiontype != 107 ) // Если не конструкция, иду вверх
				{
					return getRootProduction( drParent_OI );
				}
				else
				{
					return drOI_cur;
				}
			}
		}

		#region Вспомогательные методы
		
		// Процедура получения перечня элементов указанной группы заполнения с поправками и коэффициентами, а также глубины вхождения заполнения в профиль
		public bool getShtapicGroupDetail( int idShtapicGroup, int thick, string profileMark, ref string[] markingList, ref decimal[] deltaSum, ref decimal[] coeffList, ref decimal zap_depth )
		{
			bool res = false;
			string sql = @""
				declare @thick_zap int = ""+ thick.ToString() +"";"" + @""
				declare @idshtapicgroup int = ""+ idShtapicGroup.ToString() +"";"" + @""
				declare @profilename varchar(255) = '""+ profileMark +""';"" + @""
				
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
				"";
			DataTable tableTemp = new DataTable();
			DBConnections2.dbconn _db = new DBConnections2.dbconn(); 
			_db.command.CommandText = sql;
			_db.OpenDB();
			_db.adapter.Fill(tableTemp);
			_db.CloseDB();

			if (tableTemp.Select().Length>0)
			{
				res = true;
				foreach( DataRow drVal in tableTemp.Select() )
				{
					string mark = Useful.GetString( drVal[""marking""], """" );
					decimal delta = Useful.GetDecimal( drVal[""delta_sum""], 0 );
					decimal coeff = Useful.GetDecimal( drVal[""coeff""], 1 );
					if( mark != """" )
					{
						Array.Resize(ref markingList, markingList.Length + 1); markingList[markingList.Length - 1] = mark;
						Array.Resize(ref deltaSum, deltaSum.Length + 1); deltaSum[deltaSum.Length - 1] = delta;
						Array.Resize(ref coeffList, coeffList.Length + 1); coeffList[coeffList.Length - 1] = coeff;
					}
					zap_depth = Useful.GetDecimal( drVal[""depth""], 0 );
				}
			}
			
			return res;
		}
		public bool getShtapicGroupDetail2( int idShtapicGroup, int thick, string profileMark, ref string[] markingList, ref decimal[] deltaSum, ref decimal[] coeffList, ref decimal zap_depth )
		{
			bool res = false;
			string sql = @""
				declare @thick_zap int = ""+ thick.ToString() +"";"" + @""
				declare @idshtapicgroup int = ""+ idShtapicGroup.ToString() +"";"" + @""
				declare @profilename varchar(255) = '""+ profileMark +""';"" + @""
				
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
				"";
			DataTable tableTemp = new DataTable();
			/*
			DBConnections2.dbconn _db = new DBConnections2.dbconn(); 
			_db.command.CommandText = sql;
			_db.OpenDB();
			_db.adapter.Fill(tableTemp);
			_db.CloseDB();
*/
			
			string select_filter = ""[idshtapikgroup]='""+idShtapicGroup.ToString()+""' AND [profilename]='""+profileMark+""'"" + 
				"" AND ( "" + 
				""( [thick]<=""+thick.ToString()+"" AND [thick2]>=""+thick.ToString()+"" )"" + 
				"" OR "" +
				""( [thick]=""+thick.ToString()+"" AND [thick2] is null ) "" + 
				"")"";
			DataRow[] ddd = t_alu_dobor.Select(select_filter);
			if (ddd.Length>0)
			{
				res = true;
				foreach( DataRow drVal in ddd )
				{
					//					if( idShtapicGroup == 41 && profileMark == ""010205"" )
					//					{
					//						MessageBox.Show( Useful.GetString( drVal[""marking""], """" ) +"", thick="" + thick.ToString() );
					//					}
					string mark = Useful.GetString( drVal[""marking""], """" );
					decimal delta = Useful.GetDecimal( drVal[""delta_sum""], 0 );
					decimal coeff = Useful.GetDecimal( drVal[""coeff""], 1 );
					if( mark != """" )
					{
						Array.Resize(ref markingList, markingList.Length + 1); markingList[markingList.Length - 1] = mark;
						Array.Resize(ref deltaSum, deltaSum.Length + 1); deltaSum[deltaSum.Length - 1] = delta;
						Array.Resize(ref coeffList, coeffList.Length + 1); coeffList[coeffList.Length - 1] = coeff;
					}
					zap_depth = Useful.GetDecimal( drVal[""size""], 0 );
				}
			}
			
			return res;
		}
		
		// Процедура определения доборных элементов с поправками и коэффициентами
		public bool getInsertionDetail_OLD( int idInsertion, ref string[] markingList, ref decimal[] deltaSum, ref decimal[] coeffList )
		{
			bool res = false;
			string sql = @""
				declare @idinsertion int = ""+ idInsertion.ToString() +"";"" + @""
				
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
				"";
			// and ( gp.intvalue=107 or g.idgoodtype=11 )
			DataTable tableTemp = new DataTable();
			DBConnections2.dbconn _db = new DBConnections2.dbconn(); 
			_db.command.CommandText = sql;
			_db.OpenDB();
			_db.adapter.Fill(tableTemp);
			_db.CloseDB();

			if (tableTemp.Select().Length>0)
			{
				/*
				if( tableTemp.Select().Length > 2 )
				{
//					MessageBox.Show( ""I="" + idInsertion.ToString() + "", CNT="" + tableTemp.Select().Length.ToString() );
				}
*/
				res = true;
				foreach( DataRow drVal in tableTemp.Select() )
				{
					string mark = Useful.GetString( drVal[""marking""], """" );
					decimal delta = Useful.GetDecimal( drVal[""delta_sum""], 0 );
					decimal coeff = Useful.GetDecimal( drVal[""coeff""], 1 );
					if( mark != """" )
					{
						Array.Resize(ref markingList, markingList.Length + 1); markingList[markingList.Length - 1] = mark;
						Array.Resize(ref deltaSum, deltaSum.Length + 1); deltaSum[deltaSum.Length - 1] = delta;
						Array.Resize(ref coeffList, coeffList.Length + 1); coeffList[coeffList.Length - 1] = coeff;
					}
				}
			}
			
			return res;
		}
		public bool getInsertionDetail( int idInsertion, ref string[] markingList, ref decimal[] deltaSum, ref decimal[] coeffList )
		{
			bool res = false;
			string sql = @""
				declare @idinsertion int = ""+ idInsertion.ToString() +"";"" + @""
				
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
				"";
			// and ( gp.intvalue=107 or g.idgoodtype=11 )
			/*
			DataTable tableTemp = new DataTable();
			DBConnections2.dbconn _db = new DBConnections2.dbconn(); 
			_db.command.CommandText = sql;
			_db.OpenDB();
			_db.adapter.Fill(tableTemp);
			_db.CloseDB();
			*/
			DataRow[] ddd = t_alu_dobor_rama.Select(""[idinsertion]='""+idInsertion.ToString()+""'"");
			if (ddd.Length>0)
			{
				/*
				if( tableTemp.Select().Length > 2 )
				{
//					MessageBox.Show( ""I="" + idInsertion.ToString() + "", CNT="" + tableTemp.Select().Length.ToString() );
				}
*/
				res = true;
				foreach( DataRow drVal in ddd )
				{
					string mark = Useful.GetString( drVal[""marking""], """" );
					decimal delta = Useful.GetDecimal( drVal[""delta_sum""], 0 );
					decimal coeff = Useful.GetDecimal( drVal[""coeff""], 1 );
					if( mark != """" )
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
		string getSideRussian( Balka bi )
		{
			switch( bi.Side.ToString().ToLower() )
			{
				case ""bottom"": return ""Низ""; break;
				case ""top"": return ""Верх""; break;
				case ""left"": return ""Лево""; break;
				case ""right"": return ""Право""; break;
			}
			return """";
		}
		
		public ds_docwork.docworkRow AddWorkByName( OrderClass ord, ds_order.orderitemRow dr_oi, string workname, string workopername, decimal qu )
		{
			ord.DocWork.SetCalcParam (wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time); 
			ord.DocWork.SetCalcParam(dr_oi.idorderitem,workname);
			return ord.DocWork.AddWorkOperForItem(workopername,qu);
		}
		public ds_docwork.docworkRow AddWorkByID( OrderClass ord, ds_order.orderitemRow dr_oi, int idworkoper, decimal qu )
		{
			//			MessageBox.Show( ""Adding work oper. id="" + idworkoper + "", qu="" + qu );
			return AddWork(ord,dr_oi, idworkoper,(double)qu);
		}
		
		private ds_docwork.docworkRow AddWork( OrderClass ooo, ds_order.orderitemRow drOI_, int idWorkOper, double count, string comment = """")
		{	
			var workName = table_workoper.AsEnumerable().
				Where(row => row[""idworkoper""].ToString() == idWorkOper.ToString()).
				Select(row => row[""work_name""].ToString()).ToList<string>();
			
			var workOperName = table_workoper.AsEnumerable().
				Where(row => row[""idworkoper""].ToString() == idWorkOper.ToString()).
				Select(row => row[""name""].ToString()).ToList<string>();
			
			if (workName != null && workName.Count > 0)
			{
				ooo.DocWork.SetCalcParam(wCalcPrice.Price1, wCalcType.Qu, wCalcType.SetValue, wCalcType.Time);
				ooo.DocWork.SetCalcParam(drOI_.idorderitem, workName[0]);
				ds_docwork.docworkRow docworkRow = ooo.DocWork.AddWorkOperForItem(workOperName[0], (decimal)count);
				if (comment != """")
					docworkRow.comment = comment;
				return docworkRow;
			}
			return null;
		}

		private DataRow GetWorkOper( int idworkoper )
		{	
			DataRow[] r = table_workoper.Select(""idworkoper="" + idworkoper );
			if( r.Length > 0 ) return r[0];
			return null;
		}

		
		/*
		public void LoadALUDobor()
		{
			t_alu_Dobor=new DataTable();
			dbconn._db.command.CommandText=
				@""select g.marking, sgd.thick, sgd.thick2, sgd.idshtapikgroup, sgp.size, sd.name profilename, 
				( select sum( sgpd.numvalue ) from shtapikgroupparamdetail sgpd where sgpd.idshtapikgroupdetail=sgd.idshtapikgroupdetail and sgpd.deleted is null and sgpd.idvariantparamtype=39 ) delta_sum,
				( select EXP(SUM(LOG( sgpd2.numvalue ))) from shtapikgroupparamdetail sgpd2 where sgpd2.idshtapikgroupdetail=sgd.idshtapikgroupdetail and sgpd2.deleted is null and sgpd2.idvariantparamtype=48 ) coeff
				from shtapikgroupdetail sgd 
				join good g on g.idgood=sgd.idgood and g.deleted is null
				left join goodparam gp on gp.idgood=g.idgood and gp.idgoodparamname=84 and gp.deleted is null
				join shtapikgroupprofile sgp on sgp.idshtapikgroup=sgd.idshtapikgroup and sgp.deleted is null
				join systemdetail sd on sd.idsystemdetail=sgp.idsystemdetail and sd.deleted is null 
				where sgd.deleted is null
				and ( gp.intvalue=107 or g.idgoodtype=11 )
				"";
			dbconn._db.adapter.Fill(t_alu_Dobor);
		}
*/
		
		#endregion
		
	
		string getBalkaIndex( Balka b )
		{
			string res="""";
			string IDs = Useful.GetString( b.ID + 1, """" );
			switch( b.BalkaType )
			{
				case ModelPart.Impost: res= ""И-"" + IDs; break;
				case ModelPart.RamaItem: res= ""Р-"" + IDs; break;
				default: res = b.BalkaType.ToString() + ""-"" + IDs; break;
			}
			return res;
		}
		
		#region Дренажи
		public int SaveDrenag( Construction model )
		{
			int count = 0;
			int count2 = 0;
			// string vodootvod=model.GetUserParam(""Дренаж"").StrValue;
			string vodootvod=""Снаружи"";
			if(vodootvod==""Снаружи""||vodootvod==""Изнутри"")
			{
				string dren_sliv="""";
				//Расчет дренажных крышек для нижней рамы
				foreach (RamaItem ri in model.Rama)
				{
					if ((ri.AngNakl == 0 || ri.AngNakl == 180) 
						&& ri.Side == ItemSide.Bottom && ri.RamaType==RamaType.Rama) // если это нижняя горизонтальная балка
					{
						
						if(ri.LenghtC<355&&ri.ImpostPositionList.Count==0)
						{
							//Слив
							AddOperation(ri,ri.Lenght/2,dren_sliv);
							count++;
						}
						else if(ri.LenghtC<480&&ri.ImpostPositionList.Count==0)
						{
							//Слив
							AddOperation(ri,ri.Lenght/2,dren_sliv);
							count++;
						}
						else if(ri.LenghtC>=480&&ri.ImpostPositionList.Count==0)
						{
							//Слив
							AddOperation(ri,(int)ri.C+185,dren_sliv);
							count++;
							AddOperation(ri,ri.Lenght-(int)ri.C-185,dren_sliv);
							count++;
							if(ri.LenghtC>1800)
							{
								AddOperation(ri,ri.Lenght/2,dren_sliv);
								count++;
							}
						}
						else
						{
							//Слив
							AddOperation(ri,(int)ri.C+185,dren_sliv);
							count++;
							AddOperation(ri,ri.Lenght-(int)ri.C-185,dren_sliv);
							count++;
								
							if(ri.LenghtC>1800)
							{
								bool DrenagAdded=false;
								if(ri.ImpostPositionList.Count>0)
								{
									foreach(int ImpostPos in ri.ImpostPositionList)
									{
										if(ImpostPos>ri.Lenght/2-100&&ImpostPos<ri.Lenght/2+100)
										{
											//MessageBox.Show(""ri.Lenght=""+ri.Lenght+"" ImpostPos=""+ImpostPos);
											AddOperation(ri,ImpostPos,dren_sliv);
											count++;
											DrenagAdded=true;
											break;
										}
									}
								}
								if(!DrenagAdded)
								{
									AddOperation(ri,ri.Lenght/2,dren_sliv);
									count++;
								}
							}
						}
					}
				}
				
					
				//Расчет дренажных крышек для горизонтальных импостов WHS, WHS 72 и Сателс
				foreach(Impost im in model.ImpostList)
				{
					if(im.Hide==true||(im.Marking!=""102013""&&im.Marking!=""102309""&&im.Marking!=""102309900001""&&im.Marking!=""102309WHS""))
						continue;
					
					if ((im.AngNakl == 0 || im.AngNakl == 180)) // если это горизонтальная балка
					{
						
						if(im.LenghtC<355&&im.ImpostPositionList.Count==0)
						{
							AddOperation(im,im.Lenght/2,dren_sliv);
							count2++;
						}
						else if(im.LenghtC<480&&im.ImpostPositionList.Count==0)
						{
							AddOperation(im,im.Lenght/2,dren_sliv);
							count2++;
						}
						else if(im.LenghtC>=480&&im.ImpostPositionList.Count==0)
						{
							AddOperation(im,(int)im.C+185,dren_sliv);
							count2++;
							AddOperation(im,im.Lenght-(int)im.C-185,dren_sliv);
							count2++;
							if(im.LenghtC>1800)
							{
								AddOperation(im,im.Lenght/2,dren_sliv);
								count2++;
							}
						}
						else
						{
							AddOperation(im,185,dren_sliv);
							count2++;
							AddOperation(im,im.Lenght-185,dren_sliv);
							count2++;

							if(im.LenghtC>1800)
							{
								bool DrenagAdded=false;
								if(im.ImpostPositionList.Count>0)
								{
									foreach(int ImpostPos in im.ImpostPositionList)
									{
										if(ImpostPos>im.Lenght/2-100&&ImpostPos<im.Lenght/2+100)
										{
											AddOperation(im,ImpostPos,dren_sliv);
											count2++;
											DrenagAdded=true;
											break;
										}
									}
								}
								if(!DrenagAdded)
								{
									AddOperation(im,im.Lenght/2,dren_sliv);
									count2++;
								}
							}
						}
					}
				}
				// если заглушки есть, то списываем работы
				count = count + count2 ;
			}
			return count;
		}
		public int roundToMax(double x)
		{
			if( x > Convert.ToDouble(Math.Truncate(x) ) ) { return Convert.ToInt32(Math.Truncate(x) + 1); } else { return Convert.ToInt32(Math.Truncate(x)); }
		}
  
		#region Из скрипта ширмера


		void AddOperation(Balka Balka,int StartImp,string pName)
		{
		}

		#endregion 
  
		#endregion 
		
		#region DEV-116839. Подсчет времени выполнения скрипта
		private void StartStopExecutionTimeCounter(bool isStart, ref int idPerfomanceLog, string param)
		{
			try
			{
				if (isStart)
				{
					DataTable tbl = new DataTable();
					string sql = @""DECLARE @id int
						EXEC dbo.Start_my_perfomancelog2 63, '"" + param + @""', @id OUT
						SELECT @id as id"";

					Atechnology.DBConnections2.dbconn _db = new Atechnology.DBConnections2.dbconn();
					_db.command.CommandText = sql;
					_db.OpenDB();
					_db.adapter.Fill(tbl);
					_db.CloseDB();

					DataRow[] dr = tbl.Select();

					foreach (DataRow d in dr)
					{
						idPerfomanceLog = Useful.GetInt32(d[""id""], 0);
					}
				}
				else
				{
					if (idPerfomanceLog == 0) return;
					//if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(""Старт"");

					//	if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(""Перед вставкой"");
					string sql = @""EXEC dbo.End_my_perfomancelog "" + idPerfomanceLog.ToString();

					Atechnology.DBConnections2.dbconn _db = new Atechnology.DBConnections2.dbconn();
					_db.command.CommandText = sql;
					_db.OpenDB();
					_db.command.ExecuteNonQuery();
					_db.CloseDB();
					//if(Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(""после вставки"");
				}

			}
			catch (Exception e) { if (Atechnology.ecad.Settings.idpeople == 8234) MessageBox.Show(e.ToString()); }
		}
		#endregion
	}	
	
}";
}