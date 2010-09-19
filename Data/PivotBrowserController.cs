using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PivotBrowser.Data
{
    public class PivotBrowserController
    {
        public Pivot pivotController { get; set; }
        private Dictionary<int, PivotBrowser> browserList;
        private int id = 0;

        public PivotBrowserController(Pivot pivotController)
        {
            this.pivotController = pivotController;
            browserList = new Dictionary<int, PivotBrowser>();
        }

        public void AddPivotBrowser()
        {
            id++;
            var browser = new Data.PivotBrowser(id);
            pivotController.Items.Add(browser.PItem);
            browserList.Add(id, browser);
            pivotController.SelectedItem = browser.PItem;
        }

        public void DelPivotBrowser()
        {
            pivotController.Items.RemoveAt(pivotController.SelectedIndex);
            browserList.Remove(pivotController.SelectedIndex);
            // TODO: Select last used tab?
        }

        private PivotBrowser getSelectedBrowser()
        {
            PivotBrowser browser;
            int id = Int32.Parse((pivotController.SelectedItem as PivotItem).Name);
            browserList.TryGetValue(id, out browser);
            return browser;
        }

    }
}
