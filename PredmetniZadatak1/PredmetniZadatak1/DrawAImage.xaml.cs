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
    /// Interaction logic for DrawAImage.xaml
    /// </summary>
    public partial class DrawAImage : Window
    {
        private string photoFileName;
        private double photoHeight;
        private double photoWidth;
        private bool draw;

        public DrawAImage()
        {
            InitializeComponent();
        }

        public string PhotoFileName { get => photoFileName; set => photoFileName = value; }
        public double PhotoHeight { get => photoHeight; set => photoHeight = value; }
        public double PhotoWidth { get => photoWidth; set => photoWidth = value; }
        public bool Draw { get => draw; set => draw = value; }

        private void ButtonAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog(); //true false null...moze i tip bool? 

            if (result == true)
            {
                PhotoFileName = dlg.FileName;
                var uri = new Uri(PhotoFileName);
                Photo.Source = new BitmapImage(uri);
            }

        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Draw = false;
            this.Close();
        }

        private void ButtonDraw_Click(object sender, RoutedEventArgs e)
        {
            Draw = true;
            PhotoWidth = double.Parse(WidthTextBox.Text);
            PhotoHeight = double.Parse(HeightTextBox.Text);
            this.Close();
        }

    }
}
