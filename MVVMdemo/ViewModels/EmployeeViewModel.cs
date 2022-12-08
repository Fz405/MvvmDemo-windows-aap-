using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMdemo.Models;
using MVVMdemo.Commands;
using System.Windows;

namespace MVVMdemo.ViewModels

{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        EmployeeService ObjEmployeeService;
        private ObservableCollection<Employee> employeeList;
        public EmployeeViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand= new RelayCommand(Save);
            searchCommand= new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }
        #region DisplayEmployees
        public ObservableCollection<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value;
                OnPropertyChanged("EmployeeList"); }
        }

        private void LoadData()
        {
            EmployeeList = new ObservableCollection<Employee>(ObjEmployeeService.Index());
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertName));
            }
        }
        #endregion

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set
            {
                currentEmployee = value;
                OnPropertyChanged("CurrentEmployee");
            }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value;
                OnPropertyChanged("Message");
            }
        }

        #region AddEmployee
        private RelayCommand saveCommand;  // like button click

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }
    public void Save()
        {
            try
            {
                var _isSaved= ObjEmployeeService.AddEmployee(CurrentEmployee);  
                LoadData();
                if(_isSaved)
                {
                    Message = "Employee added sucessfully";
                }
                else
                {
                    Message = "Employee unable to add";
                }

            }
            catch (Exception ex) 
            {
                Message= ex.Message;
            }
        }
        #endregion

        #region SearchEmployee
        private RelayCommand searchCommand;  // like button click

        public RelayCommand SearchCommand
        {
            get { return searchCommand; 
            }
        }
        public void Search()
        {
            try
            {
                var ObjEmployee = ObjEmployeeService.Search(CurrentEmployee.Id);
                if (ObjEmployee!=null)
                {
                    CurrentEmployee.UserName= ObjEmployee.UserName;
                    CurrentEmployee.Age = ObjEmployee.Age;

                }
                else
                {
                    Message = "Employee not found";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region UpdateCommand
        private RelayCommand updateCommand;  // like button click

        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        public void Update()
        {
            try
            {
                var _isUpdated = ObjEmployeeService.Update(CurrentEmployee);
                if (_isUpdated)
                {
                    Message = "Updated sucessfully";
                    LoadData();

                }
                else
                {
                    Message = "Employee not updated";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region DeleteEmployee
        private RelayCommand deleteCommand;  // like button click

        public RelayCommand DeleteEmployee
        {
            get
            {
                return deleteCommand;
            }
        }
        public void Delete()
        {
            try
            {
                var _isDeleted = ObjEmployeeService.Delete(CurrentEmployee.Id);
                if (_isDeleted)
                {
                    Message = "Deleted sucessfully";
                    LoadData();

                }
                else
                {
                    Message = "Employee not deleted";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion





    }
}
