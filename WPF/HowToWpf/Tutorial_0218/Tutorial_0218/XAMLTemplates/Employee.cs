using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_0218.XAMLTemplates
{
    class Employee : INotifyPropertyChanged
    {
       
        private string name; public string Name
        {
            get { return name; }
            set { name = value; RaiseProperChanged(); }
        }

        private string title; public string Title
        {
            get { return title; }
            set { title = value; RaiseProperChanged(); }
        }

        public static Employee GetEmployee()
        {
            var emp = new Employee()
            {
                Name = "Waqas",
                Title = "Software Engineer"
            };
            return emp;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseProperChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public static ObservableCollection<Employee> GetEmployees()
        {
            var employees = new ObservableCollection<Employee>();
            employees.Add(new Employee() { Name = "Ali", Title = "Developer" });
            employees.Add(new Employee() { Name = "Ahmed", Title = "Programmer" });
            employees.Add(new Employee() { Name = "Amjad", Title = "Desiner" });
            employees.Add(new Employee() { Name = "Waqas", Title = "Programmer" });
            employees.Add(new Employee() { Name = "Bilal", Title = "Engineer" });
            employees.Add(new Employee() { Name = "Waqar", Title = "Manager" });
            return employees;
        }
    }
}
