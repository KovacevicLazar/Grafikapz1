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
    /// Interaction logic for ChangeShapeColor.xaml
    /// </summary>
    /// 
  
    public partial class ChangeShapeColor : Window
    {
        public static List<string> Color;
        private string fillColor;
        private string borderColor;
        private double shapeBorderThickness;
        private bool applyChange;
        public ChangeShapeColor()
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
            FillColorComboBox.ItemsSource = Color;
            BorderColorComboBox.ItemsSource = Color;
        }

        public string FillColor { get => fillColor; set => fillColor = value; }
        public string BorderColor { get => borderColor; set => borderColor = value; }
        public double ShapeBorderThickness { get => shapeBorderThickness; set => shapeBorderThickness = value; }
        public bool ApplyChange { get => applyChange; set => applyChange = value; }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ApplyChange = false;
            this.Close();
        }

        private void ButtonDraw_Click(object sender, RoutedEventArgs e)
        {
            ApplyChange = true;
            BorderColor = BorderColorComboBox.SelectedItem.ToString();
            FillColor = FillColorComboBox.SelectedItem.ToString();
            ShapeBorderThickness = double.Parse(BorderThicknessTextBox.Text);
            this.Close();
        }
    }
}
