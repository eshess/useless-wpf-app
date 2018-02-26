using System.Windows;

namespace RidiculouslyComplexAnniversaryCalculator
{
    /// <summary>
    /// Interaction logic for Prompt.xaml
    /// </summary>
    public partial class Prompt : Window
    {
        public Prompt(string promptMessage)
        {
            InitializeComponent();
            PromptMessage.Text = promptMessage;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
