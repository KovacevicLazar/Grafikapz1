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

namespace PredmetniZadatak1
{
    /// <summary>
    /// Interaction logic for DrawARectangle.xaml
    /// </summary>
    public partial class DrawARectangle : Window
    {
        
        public static List<string> Color;
        private string fillColor;
        private string borderColor;
        private double rectangleHeight;
        private double rectangleWidth;
        private double rectangleBorderThickness;
        private bool draw;

        public DrawARectangle()
        {
            InitializeComponent();
            Color = new List<string>();
            Color.Add("Red");
            Color.Add("Blue");
            Color.Add("Green");
            Color.Add("Yelow");
            Color.Add("Pink");
            Color.Add("Gray");
            Color.Add("Brown");
            Color.Add("White");
            Color.Add("Black");
            FillColor = "";
            BorderColor = "";
            Draw = false;
            FillColorComboBox.ItemsSource = Color;
            BorderColorComboBox.ItemsSource = Color;
        }

        public string FillColor { get => fillColor; set => fillColor = value; }
        public string BorderColor { get => borderColor; set => borderColor = value; }
        public double RectangleHeight { get => rectangleHeight; set => rectangleHeight = value; }
        public double RectangleWidth { get => rectangleWidth; set => rectangleWidth = value; }
        public double RectangleBorderThickness { get => rectangleBorderThickness; set => rectangleBorderThickness = value; }
        public bool Draw { get => draw; set => draw = value; }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Draw = false;
            this.Close();
        }


        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            if(!Double.TryParse(WidthTextBox.Text, out rectangleWidth) || !Double.TryParse(HeightTextBox.Text, out rectangleHeight) || !Double.TryParse(BorderThicknessTextBox.Text, out rectangleBorderThickness) || BorderColorComboBox.SelectedIndex == -1 || FillColorComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Proverite da li su sva polja ispravno popunjena i pokušajte ponovo.");
            }
            else
            {
                Draw = true;
                BorderColor = BorderColorComboBox.SelectedItem.ToString();
                FillColor = FillColorComboBox.SelectedItem.ToString();
                this.Close();
            }
        }

    }
}
