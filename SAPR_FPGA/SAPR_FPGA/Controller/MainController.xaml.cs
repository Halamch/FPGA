using System;
using System.Collections.Generic;
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
using SAPR_FPGA.View;
namespace SAPR_FPGA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        View.View View = new View.View(); // объект представления
        Model_ Model = new Model_(); // объект модели
        OpenProject openproject; // окно открытия проекта
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MenuItem_Click_0(object sender, RoutedEventArgs e) // Команда открыть проект
        {
            string answer = "";
            Model.ShowProjects(ref answer);
            openproject = new OpenProject(Model.Exprojects);
            openproject.Show();
            
            //MessageBox.Show(answer);
        }

     
    }
}
