using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace PivotBrowser.Data
{
    public class PivotBrowser
    {
        public PivotItem PivotItem { get; set; }
        private readonly URLBox _urlBox;
        private readonly TextBox _textBox;
        private readonly WebBrowser _browser;
        private readonly ProgressBar _progressBar;

        private bool _textBoxInFocus = false;

        public PivotBrowser(int id)
        {
            this.PivotItem = new PivotItem();
            this.PivotItem.Header = "blank";
            this.PivotItem.Name = id.ToString();

            Canvas canvas = new Canvas();
            canvas.Height = 650;
            canvas.Width = 460;
            canvas.Margin = new Thickness(0,-10,0,0);
            canvas.Name = "canvas" + id.ToString();
            canvas.VerticalAlignment = VerticalAlignment.Top;
            canvas.HorizontalAlignment = HorizontalAlignment.Left;

            _textBox = new TextBox();
            _textBox.Height = 72;
            _textBox.Width = 400;
            _textBox.Margin = new Thickness(0,0,0,0);
            _textBox.Name = "textBox" + id.ToString();
            _textBox.Text = "URL";
            _textBox.HorizontalAlignment = HorizontalAlignment.Left;
            _textBox.VerticalAlignment = VerticalAlignment.Top;
            _textBox.GotFocus += new RoutedEventHandler(_textBox_GotFocus);
            _textBox.KeyDown += new KeyEventHandler(_textBox_KeyDown);
            _textBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(_textBox_TextChanged);
            _textBox.LostFocus += new RoutedEventHandler(_textBox_LostFocus);

            Button button = new Button();
            button.Content = "Go";
            button.Height = 72;
            button.Width = 80;
            button.Margin = new Thickness(386,0,0,0);
            button.Click += new RoutedEventHandler(NavigateBrowser);

            _browser = new WebBrowser();
            _browser.HorizontalAlignment = HorizontalAlignment.Left;
            _browser.VerticalAlignment = VerticalAlignment.Top;
            _browser.Margin = new Thickness(0,72,0,0);
            _browser.Name = "browser" + id.ToString();
            _browser.Height = 578;
            _browser.Width = 460;
            _browser.Navigated += new EventHandler<System.Windows.Navigation.NavigationEventArgs>(browser_Navigated);

            _urlBox = new URLBox();
            _urlBox.Hide();

            _progressBar = new ProgressBar();
            _progressBar.Margin = new Thickness(0,0,0,0);
            _progressBar.Height = 10;
            _progressBar.Width = 370;
            _progressBar.IsIndeterminate = true;
            _progressBar.Visibility = Visibility.Collapsed;

            canvas.Children.Add(_textBox);
            canvas.Children.Add(button);
            canvas.Children.Add(_browser);
            canvas.Children.Add(_urlBox.Rectangle);
            canvas.Children.Add(_urlBox.ListBox);
            canvas.Children.Add(_progressBar);

            this.PivotItem.Content = canvas;
        }

        void _textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _textBox.SelectAll();
            _textBoxInFocus = true;
        }
        void _textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _urlBox.Hide();
            _textBoxInFocus = false;
        }

        void _textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (_textBoxInFocus)
            {
                _urlBox.Show();
            }
        }

        void browser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            _textBox.Text = e.Uri.ToString();
            _progressBar.Visibility = Visibility.Collapsed;
            try
            {
                PivotItem.Header = e.Uri.Host.ToString().Substring(0, 8);
            }
            catch (Exception)
            {
                PivotItem.Header = e.Uri.ToString();
            }
        }

        void _textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NavigateBrowser(null, null);
            }
        }

        private void NavigateBrowser(object sender, RoutedEventArgs e)
        {
            _urlBox.Hide();
            _browser.Focus();
            _progressBar.Visibility = Visibility.Visible;

            string site = _textBox.Text;
            if (!site.StartsWith("http://"))
            {
                site = "http://" + site;
            }
            _browser.Navigate(new Uri(site, UriKind.Absolute));   
        }
        
    }
}
