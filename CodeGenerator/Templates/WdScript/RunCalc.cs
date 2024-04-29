using Atechnology.Components;
using Atechnology.DBConnections2;
using Atechnology.winDraw.Model;
using CalcAlumOperation;
using System;
using System.Data;
using System.Windows.Forms;

namespace Atechnology.ecad.Calc
{
    public class RunCalc
    {
        public void Run(dbconn _db, DataRow dr, Construction model)
        {
            AlumOperationService alumCalc = new AlumOperationService();
            alumCalc.RunCalcOperations(_db, dr, model); 
        }
    }
}
