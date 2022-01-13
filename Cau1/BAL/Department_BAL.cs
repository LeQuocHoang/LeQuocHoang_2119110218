using Cau1.BEL;
using Cau1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class Department_BAL
    {
        Department_DAL dal = new Department_DAL();
        public List<Department_BEL> ReadDepartmentList()
        {
            List<Department_BEL> lstDepartment = dal.ReadDepartmentList();
            return lstDepartment;
        }
    }
}
