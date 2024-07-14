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
using System.IO;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for CVWindow.xaml
    /// </summary>
    public partial class CVWindow : Window
    {
        public CVWindow()
        {
            InitializeComponent();
        }


        public async void LoadPdf(string filePath)
        {
            string pdfViewerUrl = $"file:///{filePath}";
            await pdfView.EnsureCoreWebView2Async(null);
            pdfView.CoreWebView2.Navigate(pdfViewerUrl);

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
