using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.Model.DAO
{
    public class BaseDAO
    {
        protected Model.EF.QuanLySachEntities db_;

        public BaseDAO()
        {
            db_ = new EF.QuanLySachEntities();
        }
    }
}
