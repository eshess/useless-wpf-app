using System.Windows;
using System.Windows.Media;

namespace RidiculouslyComplexAnniversaryCalculator
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow(string image, bool animated, int width, int height)
        {
            InitializeComponent();
            this.Height = height;
            this.Width = width;           
            if(animated)
            {
                ImageToDisplay.Style = (Style)FindResource(image);
            }else
            {
                ImageSource ToDisplay = null;
                try
                {
                    ToDisplay = (ImageSource)FindResource(image);
                }
                catch { }
                if (ToDisplay == null)
                {
                    ToDisplay = (ImageSource)FindResource("math1");
                }
                ImageToDisplay.Style = (Style)FindResource("MasterImage");
                ImageToDisplay.Source = ToDisplay;
            }          
        }
    }
}
