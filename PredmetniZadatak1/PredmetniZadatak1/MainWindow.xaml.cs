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

namespace PredmetniZadatak1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Define enum for all shapes
        private enum Shapes
        {
            Ellipse, Rectangle, Polygon, Image, NoShape
        }

        // Define the current shape used
        private Shapes currShape;


        public MainWindow()
        {
            InitializeComponent();
            currShape = Shapes.NoShape;
        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = Shapes.Ellipse;
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = Shapes.Rectangle;
        }

        private void PolygonButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = Shapes.Polygon;
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = Shapes.Image;
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }

        Point start;
        private void PaintCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(this);
            switch (currShape)
            {
                case Shapes.NoShape:
                    MessageBox.Show("Niste izabrali oblik");
                    break;

                case Shapes.Ellipse:
                    DrawAEllipse drawAEllipse = new DrawAEllipse();
                    drawAEllipse.ShowDialog();
                    DrawEllipse(drawAEllipse.Width,drawAEllipse.Height,drawAEllipse.FillColor,drawAEllipse.BorderColor,drawAEllipse.BorderThickness);
                    break;

                case Shapes.Rectangle:
                    DrawARectangle drawARectangle = new DrawARectangle();
                    drawARectangle.ShowDialog();
                    break;

                case Shapes.Polygon:
                    DrawAPolygon drawAPolygon = new DrawAPolygon();
                    drawAPolygon.ShowDialog();
                    break;

                case Shapes.Image:
                    DrawAImage drawAImage = new DrawAImage();
                    drawAImage.ShowDialog();
                    break;

                default:
                    return;
            }
        }

        private void DrawEllipse(double width,double height,string fillcolor,string bordercolor,double borderthickness)
        {
            Ellipse newEllipse = new Ellipse()
            {
                Stroke = Brushes.Green,
                Fill = Brushes.Red,
                StrokeThickness = 4,
                Height = 10,
                Width = 10
            };

            
            newEllipse.SetValue(Canvas.LeftProperty, start.X);
            newEllipse.SetValue(Canvas.TopProperty, start.Y - 50);
            newEllipse.Width = width;
            newEllipse.Height = height;
            newEllipse.Fill = new SolidColorBrush(Colors.Red);
            newEllipse.Stroke = new SolidColorBrush(Colors.Blue);
            newEllipse.StrokeThickness = borderthickness;
           
            PaintCanvas.Children.Add(newEllipse);
        }


    }
}
