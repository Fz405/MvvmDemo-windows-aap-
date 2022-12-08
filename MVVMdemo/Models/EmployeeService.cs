//https://www.c-sharpcorner.com/UploadFile/raj1979/simple-mvvm-pattern-in-wpf/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMdemo.Models
{
     public class EmployeeService
    {
        private static List<Employee> _EmployeeList;
        public EmployeeService() {
            _EmployeeList = new List<Employee>
            {
                new Employee{Id=1, UserName="Faiza", Age=60}
            };
            }
        public List<Employee> Index()
        {
            return _EmployeeList;
        }
        public bool AddEmployee(Employee employee)
        {   if (employee.Age < 21 || employee.Age > 58)
                throw new ArgumentException("Invalid Argument Exception");
            _EmployeeList.Add(employee);
            return true;
        }
        public bool Update(Employee employee) {
            bool _isUpdated = false;
            for(int i=0; i< _EmployeeList.Count; i++)
            {
                if (_EmployeeList[i].Id == employee.Id) {
                    _EmployeeList[i].UserName = employee.UserName;
                    _EmployeeList[i].Age = employee.Age;
                    _isUpdated= true;
                    break;
                }
            }
            return _isUpdated;

        }
        public bool Delete(int id)
        {
            bool _isDeleted = false;
            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                if (_EmployeeList[i].Id == id)
                {
                    _EmployeeList.RemoveAt(i);
                    _isDeleted = true;
                    break;
                }
            }
            return _isDeleted;
        }
        public  Employee Search(int id)
        { //return _EmployeeList.FirstOrDefault(e => e.Id == id);
         return   _EmployeeList.FirstOrDefault(i => i.Id == id);


        }
    }
}
