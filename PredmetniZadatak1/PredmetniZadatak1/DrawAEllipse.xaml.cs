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
    /// Interaction logic for DrawAEllipse.xaml
    /// </summary>
    public partial class DrawAEllipse : Window
    {
        public static List<string> Color;
        private string fillColor;
        private string borderColor;
        private double height;
        private double width;
        private double borderThickness;
        private bool draw;
        public DrawAEllipse()
        {
            InitializeComponent();
            Color = new List<string>();
            Color.Add("Red");
            Color.Add("Blue");
            Color.Add("Green");
            FillColor = "";
            BorderColor = "";
            FillColorComboBox.ItemsSource = Color;
            BorderColorComboBox.ItemsSource = Color;
        }

        public string FillColor { get => fillColor; set => fillColor = value; }
        public string BorderColor { get => borderColor; set => borderColor = value; }
        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }
        public double BorderThickness { get => borderThickness; set => borderThickness = value; }
        public bool Draw { get => draw; set => draw = value; }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Draw = false;
            this.Close();
        }

        private void ButtonDraw_Click(object sender, RoutedEventArgs e)
        {
            Draw = true;
            BorderColor = BorderColorComboBox.SelectedItem.ToString();
            FillColor = FillColorComboBox.SelectedItem.ToString();
            Width = double.Parse(WidthTextBox.Text);
            Height = double.Parse(HightTextBox.Text);
            BorderThickness = double.Parse(BorderThicknessTextBox.Text);
            this.Close();
        }
    }
}
