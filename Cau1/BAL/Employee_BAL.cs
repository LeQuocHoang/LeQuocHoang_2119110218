using Cau1.BEL;
using Cau1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class Employee_BAL
    {
        Employee_DAL dal = new Employee_DAL();
        public List<Employee_BEL> ReadEmployee()
        {
            List<Employee_BEL> ltsEmp = dal.ReadEmployee();
            return ltsEmp;
        }
        public void NewEmployee(Employee_BEL emp)
        {
            dal.NewEmployee(emp);
        }

        public void EditEmployee(Employee_BEL emp)
        {
            dal.EditEmployee(emp);
        }

        public void DeleteEmployee(Employee_BEL emp)
        {
            dal.DeleteEmployee(emp);
        }
    }
}
