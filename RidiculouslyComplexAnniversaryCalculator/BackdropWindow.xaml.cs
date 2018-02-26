using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RidiculouslyComplexAnniversaryCalculator
{
    /// <summary>
    /// Interaction logic for StoryCanvas.xaml
    /// </summary>
    public partial class BackdropWindow : Window
    {
        int StoryCounter = 0;
        ImageWindow ImagePopup;
        string Employee;
        string Resource;
        int StagedWidth = 500;
        int StagedHeight = 500;
        int NextWidth;
        bool hr;

        public BackdropWindow(string employee)
        {
            InitializeComponent();
            Employee = employee;
            if(employee == "hr")
            {
                hr = true;
            }
        }

        private void ResetRectangle(int x, int y)
        {
            StoryGrid.Children.Remove(rect);
            rect = new Border
            {
                BorderBrush = Brushes.LightGreen,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 10,
                Width = 10,
                BorderThickness = new Thickness(2)               
            };
            StoryGrid.Children.Add(rect);
            TranslateTransform translate = new TranslateTransform(x, y);
            rect.RenderTransform = translate;
        }
        private void GrowRect(int width, int height)
        {
            DoubleAnimation rectW = new DoubleAnimation(width, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            DoubleAnimation rectH = new DoubleAnimation(height, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            rectH.Completed += MatrixPeek_Completed;
            rect.BeginAnimation(Rectangle.WidthProperty, rectW);
            rect.BeginAnimation(Rectangle.HeightProperty, rectH);
        }
        private void StagePopup(int width, int height,
                                int moveX, int moveY, 
                                string resource, Point topRight, 
                                int offsetX = 0, int offsetY = 0)
        {
            ImagePopup = new ImageWindow(resource, false, StagedWidth, StagedHeight)
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = topRight.X - offsetX,
                Top = topRight.Y + 28 + offsetY
            };
            ImagePopup.Show();
            ResetRectangle(moveX, moveY);
            GrowRect(width, height);
            StagedWidth = width;
            StagedHeight = height;
        }

        private void MatrixPeek_Completed(object sender, EventArgs e)
        {
            StoryCounter++;
            Point topRight = rect.TranslatePoint(new Point(rect.ActualWidth / 2, (0.0 - rect.ActualHeight) / 2), StoryGrid);
            switch (StoryCounter)
            {
                case 1:
                    Resource = hr ? "redtape2" : "math1";
                    StagePopup(500, 500, 250, 100, Resource, topRight);
                    break;
                case 2:
                    ImagePopup.Close();
                    NextWidth = hr ? 700 : 900;
                    StagePopup(NextWidth, 500, -400, 400, "math2", topRight);
                    break;
                case 3:
                    ImagePopup.Close();
                    Resource = hr ? "redtape3" : "aperture";
                    StagePopup(500, 500, 50, 50, Resource, topRight);
                    break;
                case 4:
                    ImagePopup.Close();
                    StagePopup(500, 500, 250, 100, "math2", topRight);
                    break;
                case 5:
                    ImagePopup.Close();
                    NextWidth = hr ? 700 : 900;
                    StagePopup(NextWidth, 500, 0, 0, "math2", topRight);
                    break;
                case 6:
                    ImagePopup.Close();
                    Resource = hr ? "redtape" : "science";
                    StagePopup(600, 900, 0, 0, Resource, topRight, 200);
                    break;
                case 7:
                    ImagePopup.Close();
                    StagePopup(0, 0, 0, 0, Employee, topRight, 150, 400);
                    break;
                case 8:
                    ImagePopup.Close();
                    this.Close();
                    break;
            }            
        }
    }
}
