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

        Point point;
        PointCollection polygonPoints = new PointCollection(); //Points for polygon


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
           
            PaintCanvas.Children.Clear();
            
        }
        
        private void PaintCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            point = e.GetPosition(this);
            switch (currShape)
            {
                case Shapes.NoShape:
                    MessageBox.Show("Niste izabrali oblik");
                    break;

                case Shapes.Ellipse:
                    DrawAEllipse drawAEllipse = new DrawAEllipse();
                    drawAEllipse.ShowDialog();
                    if (drawAEllipse.Draw)
                    {
                        DrawEllipse(drawAEllipse.EllipseWidth, drawAEllipse.EllipseHeight, drawAEllipse.FillColor, drawAEllipse.BorderColor, drawAEllipse.EllipseBorderThickness);
                    }
                    break;

                case Shapes.Rectangle:
                    DrawARectangle drawARectangle = new DrawARectangle();
                    drawARectangle.ShowDialog();
                    if (drawARectangle.Draw)
                    {
                        DrawRectangle(drawARectangle.RectangleWidth, drawARectangle.RectangleHeight, drawARectangle.FillColor, drawARectangle.BorderColor, drawARectangle.RectangleBorderThickness);
                    }
                    break;

                case Shapes.Polygon:
                    point.Y = point.Y - 44;
                    polygonPoints.Add(point);
                    break;

                case Shapes.Image:
                    DrawAImage drawAImage = new DrawAImage();
                    drawAImage.ShowDialog();
                    if (drawAImage.Draw)
                    {
                        DrawImage(drawAImage.PhotoWidth, drawAImage.PhotoHeight, drawAImage.PhotoFileName);
                    }
                    break;

                default:
                    return;
            }
        }

        private void PaintCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currShape == Shapes.Polygon)
            {
                DrawAPolygon drawAPolygon = new DrawAPolygon();
                drawAPolygon.ShowDialog();
                if (drawAPolygon.Draw)
                {
                    DrawPolygon(drawAPolygon.FillColor, drawAPolygon.BorderColor, drawAPolygon.PolygonBorderThickness);
                    drawAPolygon.Draw = false;
                }
                else
                {
                    polygonPoints = new PointCollection();
                }
            }
        }

        private void DrawEllipse(double width,double height,string fillcolor,string bordercolor,double borderthickness)
        {
            Ellipse newEllipse = new Ellipse();
          
            newEllipse.SetValue(Canvas.LeftProperty, point.X);
            newEllipse.SetValue(Canvas.TopProperty, point.Y - 44);
            newEllipse.Width = width;
            newEllipse.Height = height;
            newEllipse.Fill = getColor(fillcolor);
            newEllipse.Stroke = getColor(bordercolor);
            newEllipse.StrokeThickness = borderthickness;
           
            PaintCanvas.Children.Add(newEllipse);
        }

        private void DrawRectangle(double width, double height, string fillcolor, string bordercolor, double borderthickness)
        {
            Rectangle newRectangle = new Rectangle();
            
            newRectangle.SetValue(Canvas.LeftProperty, point.X);
            newRectangle.SetValue(Canvas.TopProperty, point.Y - 44);
            newRectangle.Width = width;
            newRectangle.Height = height;
            newRectangle.Fill = getColor(fillcolor);
            newRectangle.Stroke = getColor(bordercolor);
            newRectangle.StrokeThickness = borderthickness;

            PaintCanvas.Children.Add(newRectangle);
        }

        private void DrawPolygon(string fillcolor, string bordercolor, double borderthickness)
        {
            Polygon newPolygon = new Polygon();

            newPolygon.Fill = getColor(fillcolor);
            newPolygon.Stroke = getColor(bordercolor);
            newPolygon.StrokeThickness = borderthickness;
            newPolygon.Points = polygonPoints;

            PaintCanvas.Children.Add(newPolygon);
            polygonPoints = new PointCollection();
        }

        private void DrawImage(double width, double height, string photoFileName)
        {
            BitmapImage theImage = new BitmapImage
                (new Uri(photoFileName, UriKind.Relative));

            ImageBrush myImageBrush = new ImageBrush(theImage);
            
            Canvas newImage = new Canvas();
            newImage.SetValue(Canvas.LeftProperty, point.X);
            newImage.SetValue(Canvas.TopProperty, point.Y - 44);
            newImage.Width = width;
            newImage.Height = height;
            newImage.Background = myImageBrush;

            PaintCanvas.Children.Add(newImage);

        }

        private SolidColorBrush getColor(string color)
        {
            SolidColorBrush sb=null;

            switch(color)
            {
                case "Red":
                    sb = new SolidColorBrush(Colors.Red);
                    break;
                    
                case "Blue":
                    sb = new SolidColorBrush(Colors.Blue);
                    break;

                case "Green":
                    sb = new SolidColorBrush(Colors.Green);
                    break;

                case "Yelow":
                    sb = new SolidColorBrush(Colors.Yellow);
                    break;

                case "Pink":
                    sb = new SolidColorBrush(Colors.Pink);
                    break;

                case "Gray":
                    sb = new SolidColorBrush(Colors.Gray);
                    break;

                case "Brown":
                    sb = new SolidColorBrush(Colors.Brown);
                    break;

                case "White":
                    sb = new SolidColorBrush(Colors.White);
                    break;

                case "Black":
                    sb = new SolidColorBrush(Colors.Black);
                    break;
            }
            return sb;
        }
    }
}
