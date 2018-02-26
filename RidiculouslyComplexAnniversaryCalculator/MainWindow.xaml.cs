using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Media;

namespace RidiculouslyComplexAnniversaryCalculator
{
    public partial class MainWindow : Window
    {
        Dictionary<string, DateTime> EmployeeList = new Dictionary<string, DateTime>();
        ImageWindow ABomb;
        Storyboard ABombStory = new Storyboard();
        ColorAnimation ABombAnimation = new ColorAnimation(Colors.Red,new Duration(new TimeSpan(0,0,0,0,500)));

        public MainWindow()
        {
            InitializeComponent();
            var Contents = Properties.Resources.users.Split('\n');
            foreach(string line in Contents)
            {
                var split = line.Split(',');
                EmployeeList.Add(split[0], DateTime.Parse(split[1]));
            }
            foreach(string key in EmployeeList.Keys)
            {
                CBEmployeeList.Items.Add(key);
            }
            CBEmployeeList.SelectedIndex = 0;
            YearComboBox.Items.Add("2017");
            YearComboBox.SelectedIndex = 0;
        }

        private void PlaySound(Stream stream)
        {
            using (SoundPlayer sound = new SoundPlayer(stream))
            {
                sound.Play();
            }
        }
        private async void ABombCloseDelay()
        {
            await Task.Delay(3000);
            ABomb.Close();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            string employee = CBEmployeeList.SelectedItem.ToString().ToLower().Replace("'", "");
            employee = employee.Split(' ')[1] + employee.Split(' ')[0].Substring(0, 1);
            int year = int.Parse(YearComboBox.SelectedItem.ToString());           
            DateTime AnniversaryDate = (EmployeeList[CBEmployeeList.SelectedItem.ToString()]).AddYears(10);
            if(employee == "keenanm")
            {
                Prompt warning = new Prompt($"Employee '{CBEmployeeList.SelectedItem.ToString()}' started as part time. Algorithm required to calculate ten year anniversary must be made twice as overly complicated. Proceed with caution.");
                var result = warning.ShowDialog();
                warning.Close();
                AnniversaryDate = DateTime.Parse("1/1/2018");
                employee = "hr";
            }
            BackdropWindow backdrop = new BackdropWindow(employee);
            var wait = backdrop.ShowDialog();
            lbAnnDate.Content = $"Anniversary: {AnniversaryDate.ToShortDateString()}";
            if ((AnniversaryDate < DateTime.Parse($"1/1/{year + 1}")) &&
                (AnniversaryDate > DateTime.Parse($"12/31/{year - 1}")))
            {
                lbHonor.Content = "Yes";
                PlaySound(Properties.Resources.win);
                lbHonor.Background = Brushes.LightGreen;
            }
            else
            {
                lbHonor.Content = "No";
                Override.IsEnabled = true;
                Override.Focus();
                PlaySound(Properties.Resources.lose);
                lbHonor.Background = Brushes.Red;
            }
        }
        private void Override_Click(object sender, RoutedEventArgs e)
        {
            Warning warning = new Warning("Honoring this employee on an atypical schedule could lead to global thermal nuclear meltdown");
            var result = warning.ShowDialog();
            if (warning.IsYes)
            {
                PlaySound(Properties.Resources.boom);
                ABomb = new ImageWindow("ABombStyle", true, 1000, 1000)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                };
                ABomb.Show();
                ABombCloseDelay();
                lbHonor.Content = "YES";
                ABombAnimation.From = Colors.White;
                ABombAnimation.To = Colors.Red;
                ABombAnimation.RepeatBehavior = RepeatBehavior.Forever;
                ABombAnimation.AutoReverse = true;
                PropertyPath colorTargetPath = new PropertyPath("(Label.Background).(SolidColorBrush.Color)");
                Storyboard.SetTarget(ABombAnimation, lbHonor);
                Storyboard.SetTargetProperty(ABombAnimation, colorTargetPath);
                ABombStory.Children.Add(ABombAnimation);
                ABombStory.Begin();
            }
            warning.Close();
        }
        private void CBEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbStartDate.Content = $"Start Date: {(EmployeeList[CBEmployeeList.SelectedItem.ToString()]).ToShortDateString()}";
            lbAnnDate.Content = "Anniversary:";
            btnCalc.Focus();
            lbHonor.Content = "";
            Override.IsEnabled = false;
            lbHonor.Background = Brushes.White;
            ABombStory.Stop();
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
