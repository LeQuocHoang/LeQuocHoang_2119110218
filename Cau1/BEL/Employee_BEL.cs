using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BEL
{
    public class Employee_BEL
    {
        public string IdEmployee { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public bool Gender { get; set; }
        public string PlaceBirth { get; set; }
        public Department_BEL Departments { get; set; }
        public string DepartName { get { return Departments.Name; } }

    }
}
