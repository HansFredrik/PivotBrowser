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
        public Pivot PivotController { get; set; }
        private readonly Dictionary<int, PivotBrowser> _browserList;
        private int _id = 0;

        public PivotBrowserController(Pivot pivotController)
        {
            this.PivotController = pivotController;
            _browserList = new Dictionary<int, PivotBrowser>();
        }

        public void AddPivotBrowser()
        {
            _id++;
            var browser = new Data.PivotBrowser(_id);
            PivotController.Items.Add(browser.PivotItem);
            _browserList.Add(_id, browser);
            PivotController.SelectedItem = browser.PivotItem;
        }

        public void DelPivotBrowser()
        {
            PivotController.Items.RemoveAt(PivotController.SelectedIndex);
            _browserList.Remove(PivotController.SelectedIndex);
            // TODO: Select last used tab?
        }

        private PivotBrowser getSelectedBrowser()
        {
            PivotBrowser browser;
            int selectedId = Int32.Parse((PivotController.SelectedItem as PivotItem).Name);
            _browserList.TryGetValue(selectedId, out browser);
            return browser;
        }

    }
}
