using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BEL
{
    public class Department_BEL
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Employee_BEL> employee { get; set; }
    }
}
