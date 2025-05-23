using Atechnology.Components;
using Atechnology.DBConnections2;
using Atechnology.winDraw.Model;
using NameSpaceDefault;
using System;
using System.Data;
using System.Windows.Forms;

namespace Atechnology.ecad.Calc
{
    public class RunCalc
    {
        public void Run(dbconn _db, DataRow dr, Construction model)
        {
            DefaultWinDrawService service = new DefaultWinDrawService();
			service.RunService(_db, dr, model); 
        }
    }
}
