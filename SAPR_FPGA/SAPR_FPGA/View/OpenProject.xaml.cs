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
    /// 
    public delegate void SelectProject(int index); // делегат для события выбора проекта
    public partial class OpenProject : Window
    {
        public OpenProject()
        {
            InitializeComponent();
        }
        
        private int _indexProject = 0;
        private SelectProject _projectSelected; // экземпляр делегата
        public OpenProject(List<ProjectExploler> exprojects)
        {
            InitializeComponent();
            DG_projects.AutoGenerateColumns = true;
            DG_projects.ItemsSource = exprojects;
            DG_projects.RowBackground = Brushes.White;
            DG_projects.ColumnWidth = DataGridLength.Auto;
            DG_projects.RowHeaderWidth = 30;
            DG_projects.FontSize = 14;
            DG_projects.FontFamily = FontFamily;
            

        }

        public int IndexProject
        {
            get { return _indexProject; }
        }

        public SelectProject ProjectSelected
        {
            get { return _projectSelected; }
            set { _projectSelected = value; }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DG_projects.SelectedIndex >=0)
                {
                    _projectSelected(DG_projects.SelectedIndex + 1); // событие выбора проекта
                    this.Close();
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
