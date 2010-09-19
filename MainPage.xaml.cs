using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml;
using Microsoft.Phone.Controls;
using PivotBrowser.Data;

namespace PivotBrowser
{
    public partial class MainPage : PhoneApplicationPage
    {
        //private int _id = 1;
        private Data.PivotBrowserController pivotBrowserController;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();

                pivotBrowserController = new Data.PivotBrowserController(LayoutRoot.Children.First() as Pivot);
                pivotBrowserController.AddPivotBrowser();
            }
        }

        private void addPivotBrowser(object sender, RoutedEventArgs e)
        {
            pivotBrowserController.AddPivotBrowser();

            if (pivotBrowserController.pivotController.Items.Count > 1)
            {
                delBrowserButton.IsEnabled = true;
            }
        }

        private void delPivotBrowser(object sender, RoutedEventArgs e)
        {
            pivotBrowserController.DelPivotBrowser();

            if(pivotBrowserController.pivotController.Items.Count == 1)
            {
                delBrowserButton.IsEnabled = false;
            }
        }

    }
}