using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace MVVMdemo.Models
{
    public class Employee : INotifyPropertyChanged   // Eventhandler need to be invoked upon property change
    {
            private int id;
            private int age;
            public string userName;
        public int Id
            {
            get { return id; } 
            set { id = value; OnPropertyChanged("Id"); }
            } 
             public int Age 
            {  get{ return age; }
              set { age = value; OnPropertyChanged("Age"); }
            }
                        
            public string UserName {
            get { return userName; } 
            set { userName = value; OnPropertyChanged("UserName"); } 
        }

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

    }



}
