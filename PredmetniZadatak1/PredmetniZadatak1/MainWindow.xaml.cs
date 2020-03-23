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
        public enum Shapes
        {
            Ellipse, Rectangle, Polygon, Image, NoShape
        }

        // Define the current shape used
        private Shapes currShape;

        Point point;
        PointCollection polygonPoints = new PointCollection(); //Points for polygon
        UndoRedo undoRedo = new UndoRedo();
        private List<FrameworkElement> listAllShapes = new List<FrameworkElement>();

        public List<FrameworkElement> ListAllShapes { get => listAllShapes; set => listAllShapes = value; }

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
            polygonPoints = new PointCollection();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = Shapes.Image;
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            undoRedo.Undo(this);
        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            undoRedo.Redo(this);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (PaintCanvas.Children.Count != 0)
            {
                undoRedo.InsertAllShapeforUndoRedo(ListAllShapes);
                ListAllShapes.Clear();
                PaintCanvas.Children.Clear();
            }
            currShape = Shapes.NoShape;
        }
        
        private void PaintCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            point = e.GetPosition(this);
            switch (currShape)
            {
                case Shapes.NoShape:
                    MessageBox.Show("Niste izabrali oblik","Greska");
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
                    // polygonPoints.Clear(); 
                    polygonPoints = new PointCollection(); //mora ovako, jer cemo imati vise poligona
                }
                currShape = Shapes.NoShape;
            }
            else
            {
                Shape clickedShape = e.OriginalSource as Shape;
               
                if (clickedShape != null)
                {
                    
                    ChangeShapeColor changeShapeColor = new ChangeShapeColor();
                    changeShapeColor.BorderThicknessTextBox.Text = clickedShape.StrokeThickness.ToString();
                    changeShapeColor.ShowDialog();
                    if (changeShapeColor.ApplyChange)
                    {
                        // Shape tempShape = clickedShape;
                        clickedShape.Fill = getColor(changeShapeColor.FillColor);
                        clickedShape.Stroke = getColor(changeShapeColor.BorderColor);
                        clickedShape.StrokeThickness = changeShapeColor.ShapeBorderThickness;
                        //PaintCanvas.Children.Remove(clickedShape);
                        // PaintCanvas.Children.Add(tempShape);  
                    }  
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
            ListAllShapes.Add(newEllipse);
            currShape = Shapes.NoShape;

            undoRedo.InsertShapeforUndoRedo(newEllipse);
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
            ListAllShapes.Add(newRectangle);
            currShape = Shapes.NoShape;
           
            undoRedo.InsertShapeforUndoRedo(newRectangle);
        }

        private void DrawPolygon(string fillcolor, string bordercolor, double borderthickness)
        {
            Polygon newPolygon = new Polygon();

            newPolygon.Fill = getColor(fillcolor);
            newPolygon.Stroke = getColor(bordercolor);
            newPolygon.StrokeThickness = borderthickness;
            newPolygon.Points = polygonPoints;

            PaintCanvas.Children.Add(newPolygon);
            ListAllShapes.Add(newPolygon);
            //polygonPoints.Clear();
            polygonPoints = new PointCollection(); //mora ovako, jer cemo imati vise poligona
            currShape = Shapes.NoShape;
           
            undoRedo.InsertShapeforUndoRedo(newPolygon);
        }

        private void DrawImage(double width, double height, string photoFileName)
        {
            BitmapImage theImage = new BitmapImage(new Uri(photoFileName,UriKind.RelativeOrAbsolute));

            ImageBrush myImageBrush = new ImageBrush(theImage);

            Canvas ImageCanvas = new Canvas();
            
            ImageCanvas.SetValue(Canvas.LeftProperty, point.X);
            ImageCanvas.SetValue(Canvas.TopProperty, point.Y - 44);
            ImageCanvas.Width = width;
            ImageCanvas.Height = height;
            ImageCanvas.Background= myImageBrush;
            ImageCanvas.MouseLeftButtonDown += new MouseButtonEventHandler(image_MouseLeftButtonDown);

            
            PaintCanvas.Children.Add(ImageCanvas);
            ListAllShapes.Add(ImageCanvas);
            currShape = Shapes.NoShape;
           
            undoRedo.InsertShapeforUndoRedo(ImageCanvas);
        }

        void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Canvas clickedShape = e.OriginalSource as Canvas;

            if (clickedShape != null)
            {
                double height = clickedShape.Height;
                double width = clickedShape.Width;
                string PhotoFileName;

                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                dlg.DefaultExt = ".jpg";
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

                Nullable<bool> result = dlg.ShowDialog(); //true false null

                if (result == true)
                {
                    PhotoFileName = dlg.FileName;
                    var uri = new Uri(PhotoFileName);
                    BitmapImage theImage = new BitmapImage(new Uri(PhotoFileName, UriKind.RelativeOrAbsolute));
                    ImageBrush myImageBrush = new ImageBrush(theImage);

                    clickedShape.Height = height;
                    clickedShape.Width = width;
                    clickedShape.Background=myImageBrush;
                }
            }
        }

        private SolidColorBrush getColor(string color)
        {
            SolidColorBrush sb = null;

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
