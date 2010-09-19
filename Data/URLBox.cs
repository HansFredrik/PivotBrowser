using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PivotBrowser.Data
{
    public class URLBox
    {
        public Rectangle Rectangle { get; set; }
        public ListBox ListBox { get; set; }

        public URLBox()
        {
            Rectangle = new Rectangle();
            Rectangle.Margin = new Thickness(15,60,0,0);
            Rectangle.Height = 150;
            Rectangle.Width = 370;
            Brush brush = new SolidColorBrush(new Color{ A = 170, B = 170, G = 170, R = 170 });
            Rectangle.Fill = brush;

            ListBox = new ListBox();
            ListBox.Margin = new Thickness(25,70,0,0);
            ListBox.Height = 140;
            ListBox.Width = 425;
            ListBox.FontSize = 25;

            ListBox.Items.Add(new ListBoxItem { Content = "URL1" });
            ListBox.Items.Add(new ListBoxItem { Content = "URL2" });
            ListBox.Items.Add(new ListBoxItem { Content = "URL3" });

            Rectangle.Visibility = Visibility.Collapsed;
            ListBox.Visibility = Visibility.Collapsed;
        }

        public void Show()
        {
            Rectangle.Visibility = Visibility.Visible;
            ListBox.Visibility = Visibility.Visible;
        }
        public void Hide()
        {
            Rectangle.Visibility = Visibility.Collapsed;
            ListBox.Visibility = Visibility.Collapsed;
        }
    }
}
