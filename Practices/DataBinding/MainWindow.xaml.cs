using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> students = new List<Student>
        {
            new Student(){Name = "张无忌",Age = 18},
            new Student(){Name = "张三丰",Age = 98},
            new Student(){Name = "灭绝师太",Age = 48},
            new Student(){Name = "周芷若",Age = 18},
            new Student(){Name = "白眉鹰王",Age = 68},
        };

        private Student studentInXaml = null;

        public MainWindow()
        {
            InitializeComponent();
            studentInXaml = (this.FindResource("student") as Student);
        }

        private void btnAlterDataSource_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private int _age;
        public string Name
        {
            get { return _name;}
            set
            {
                if (_name == value) return;
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (_age == value) return;
                _age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
            }
        }
    }
}
