using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;

namespace BAL
{
    public class BALClass
    {
        DALClass dalObj = new DALClass();

        public void InsertStudent(string name, string email, decimal fees, int cId)
        {
            dalObj.insertDetail(name, email, fees, cId);
        }

        public DataTable SelectStudent()
        {
            return (DataTable)dalObj.getDetail();
        }

        public void UpdateStudent(int sid, string name, string email, decimal fees, int cId)
        {
            dalObj.EditDetail(sid, name, email, fees, cId);
        }

        public void RemoveStudent(int sid)
        {
            dalObj.DeleteDetail(sid);
        }
    }
}

