using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_0218.DataBindingOneWay
{
    class Employee
    {
        public string Name { get; set; }
        public string Title { get; set; }

        public static Employee GetEmployee()
        {
            var emp = new Employee()
            {
                Name = "Ali Ahmed",
                Title = "Developer"
            };
            return emp;
        }
    }
}
