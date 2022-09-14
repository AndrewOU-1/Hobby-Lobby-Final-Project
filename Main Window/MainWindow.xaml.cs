using Main_Window;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Main_Screen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            cboView.Items.Add("Store View");
            cboView.Items.Add("Transportation View");

        }

        private void cboView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = cboView.SelectedItem.ToString();

            if (selected == "Store View")
            {
                StoreViewWindow wnd = new StoreViewWindow();

                wnd.ShowDialog();
            }
            if (selected == "Transportation View")
            {
                TransportViewWindow wnd = new TransportViewWindow();

                wnd.ShowDialog();
            }

        }
    }
}