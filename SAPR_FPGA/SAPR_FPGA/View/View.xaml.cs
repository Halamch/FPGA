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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAPR_FPGA.View
{
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : UserControl
    {
        private double distance = 10000;
        private double x = 0;
        double y = 0;
        private double zdirection = 10000;
        private int masSizeX = 100, masSizeY = 100;
        private MeshGeometry3D mesh;
        public View()
        {
            InitializeComponent();
            Perspective.LookDirection = new Vector3D(0, 0, zdirection);
            Perspective.Position = new Point3D(0, 0, -zdirection);
        }


        double Clamp(double val, double min, double max)
        {
            if (val < min)
                val = min;
            if (val > max)
                val = max;
            return val;
        }

        private void WorkGrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //Grid workgrid = (Grid)sender;
            //Point location = e.GetPosition(workgrid);
            //Perspective.FieldOfView -= (e.Delta / 120);
            // 1.5
            double zoom = Clamp(e.Delta, -120, 120) / 120;

            if (zoom > 0)
                distance *= (1.95 - zoom);
            else
                distance *= (0.05 - zoom);
            distance = Clamp(distance, 2, zdirection);
            Perspective.Position = new Point3D(x, y, -distance);


        }

        private void WorkGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Perspective.LookDirection = new Vector3D(0, 0, zdirection);
            Perspective.Position = new Point3D(0, 0, -zdirection);
            //distance = zdirection;
            //x = 0;
            //y = 0;

        }


        private void port3d_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Viewport3D viewport = (Viewport3D)sender;
            Point location = e.GetPosition(viewport);

            HitTestResult hitResult = VisualTreeHelper.HitTest(viewport, location);
            RayMeshGeometry3DHitTestResult meshHitResult = hitResult as RayMeshGeometry3DHitTestResult;
            if (meshHitResult != null)
            {
                Perspective.LookDirection = new Vector3D(meshHitResult.PointHit.X, meshHitResult.PointHit.Y, zdirection);
                x = meshHitResult.PointHit.X;
                y = meshHitResult.PointHit.Y;
                Perspective.Position = new Point3D(x, y, -distance);
            }



        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Point3D[, ,] points = new Point3D[masSizeX, masSizeY, 3];
            double x = 990;
            double y = 990;
            double z = 0;
            for (int j = 0; j < masSizeY; j++)
            {
                for (int i = 0; i < masSizeX; i++)
                {
                    points[i, j, 0] = new Point3D(x, y, z);
                    points[i, j, 1] = new Point3D(x + 10, y + 10, z);
                    points[i, j, 2] = new Point3D(x, y + 10, z);
                    drawTriangle(points[i, j, 0], points[i, j, 1], points[i, j, 2], Colors.Blue, port3d, true);
                    drawTriangle(points[i, j, 0], points[i, j, 1], new Point3D(points[i, j, 1].X, points[i, j, 0].Y, z), Colors.Brown, port3d, false);
                    // drawLine();
                    x -= 20;
                }
                y -= 20;
                x = 990;
            }


            //port3d.Children.Add();
        }

        public static void drawTriangle(Point3D p0, Point3D p1, Point3D p2, Color color, Viewport3D viewport, bool firstpiece)
        {

            MeshGeometry3D mesh = new MeshGeometry3D();
            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.TriangleIndices.Add(0);
            if (firstpiece)
            {
                mesh.TriangleIndices.Add(1);
                mesh.TriangleIndices.Add(2);
            }
            else
            {
                mesh.TriangleIndices.Add(1);
                mesh.TriangleIndices.Add(2);
            }


            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = color;
            Material material = new DiffuseMaterial(brush);

            GeometryModel3D geometry = new GeometryModel3D(mesh, material);
            ModelUIElement3D model = new ModelUIElement3D();
            model.Model = geometry;

            viewport.Children.Add(model);
            // MessageBox.Show(viewport.Children[viewport.Children.Count - 1].ToString());
        }

        public void GetGeometricParams(int[] calculateGeometricParameters, Viewport3D port3)
        {
            // Positions="-1000,-1000,1 1000,1000,1 1000,-1000,1"
            //mesh = new MeshGeometry3D();
            //double MicroSize = Convert.ToDouble(calculateGeometricParameters[5]);
            //mesh.Positions.Clear();
            //mesh.Positions.Add(new Point3D(-MicroSize, -MicroSize, 1));
            //mesh.Positions.Add(new Point3D(MicroSize, MicroSize, 1));
            //mesh.Positions.Add(new Point3D(MicroSize, -MicroSize, 1));
            drawTriangle(new Point3D(-99, -99, 1), new Point3D(99, 99, 1), new Point3D(99, -99, 1), Colors.Blue, port3, true);
        }



        

           //GeometricParameters[0] = fpga.CountCLB;
           //     GeometricParameters[1] = fpga.ChannelWidth;
           //     GeometricParameters[2] = Row * 2 + 1; // размерность матрицы КЛБ (квадратная)
           //     GeometricParameters[3] = fpga.ChannelWidth + 1; // размер стороны КЛБ
           //     GeometricParameters[4] = L;// длина канала
           //     GeometricParameters[5] = (2 * L + GeometricParameters[3]) * (Row * 2 + 1); // размер микросхемы (квадратная)
    }
}
