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

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow()
        {
            InitializeComponent();
        }

        public void SetImageSource(string imagePath)
        {
            DisplayedImage.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
