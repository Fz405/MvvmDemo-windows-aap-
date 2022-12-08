using MVVMdemo.ViewModels;
using System.Windows;
namespace MVVMdemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel= new EmployeeViewModel();
            this.DataContext= ViewModel;
        }
    }
}
