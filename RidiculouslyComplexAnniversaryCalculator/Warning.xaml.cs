using System.Windows;

namespace RidiculouslyComplexAnniversaryCalculator
{
    /// <summary>
    /// Interaction logic for Warning.xaml
    /// </summary>
    public partial class Warning : Window
    {
        public bool IsYes { get; set; }

        public Warning(string warningMessage)
        {
            InitializeComponent();
            WarningMessage.Text = warningMessage.ToUpper();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            IsYes = true;
            this.Close();
        }
        private void No_Click(object sender, RoutedEventArgs e)
        {
            IsYes = false;
            this.Close();
        }
    }
}
