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
using System.Windows.Shapes;

namespace SAPR_FPGA.View
{
    /// <summary>
    /// Логика взаимодействия для OpenProject.xaml
    /// </summary>
    public partial class OpenProject : Window
    {
        public OpenProject()
        {
            InitializeComponent();
        }

        public OpenProject(List<ProjectExploler> exprojects)
        {
            InitializeComponent();
           DG_projects.AutoGenerateColumns = true;
            DG_projects.ItemsSource = exprojects;
          
        }
    }
}
