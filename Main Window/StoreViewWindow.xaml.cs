using Main_Window;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Main_Screen
{
    /// <summary>
    /// Interaction logic for StoreViewWindow.xaml
    /// </summary>
    public partial class StoreViewWindow : Window
    {
        RootClass Stores;
        public StoreViewWindow()
        {
            //  serialize json
            string json = File.ReadAllText("HL_Stores.json");
            Stores = JsonConvert.DeserializeObject<RootClass>(json);


            InitializeComponent();
            cboDepth.Items.Add("5'");
            cboDepth.Items.Add("10'");
            cboDepth.Items.Add("15'");
            cboDepth.Items.Add("20'");
            cboDepth.Items.Add("25'");
            cboDepth.Items.Add("30'");
            cboDepth.Items.Add("35'");
            cboDepth.Items.Add("40'");
            cboDepth.Items.Add("45'");

            foreach (HL_Stores store in Stores.Stores)
            {
                if (cboStoreSelect.Items.Contains(store.Location) == false)
                {
                    cboStoreSelect.Items.Add(store.Location);
                }

                //lstOwners.Items.Add(owner);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isDataValid = true;
            double number;


            if (double.TryParse(txtTotes.Text, out number) == false)
            {
                MessageBox.Show("You need to enter valid data for the number of totes.\n");
                isDataValid = false;
            }

            if (double.TryParse(txtCartons.Text, out number) == false)
            {
                MessageBox.Show("You need to enter valid data for the number of cartons.\n");
                isDataValid = false;
            }

            if (double.TryParse(txtLoadlocks.Text, out number) == false)
            {
                MessageBox.Show("You need to enter valid data for the number of loadlocks.\n");
                isDataValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtTime.Text))
            {
                MessageBox.Show("You need to enter valid data for the time.\n");
                isDataValid = false;
            }

            //  formatting date becuase date included time too
            string date = dpDate.SelectedDate.Value.ToString("dd MM yyyy");

            //  creating new entry record based off data entered from user
            //  record will go to this destination: GroupProject\Main Window\bin\Debug\ --->  netcoreapp3.1  <--- 
            string[] lines =
            {
            $"\t\t\tEntry Record", $"\nStore Location: {cboStoreSelect.SelectedItem}", 
            $"\nTotal feet of trailer: {cboDepth.SelectedItem}", $"\nTotes: {txtTotes.Text}", 
            $"\nCartons: {txtCartons.Text}", $"\nLoad Locks: {txtLoadlocks.Text}", 
            $"\nDate: {date}", $"\nTime: {txtTime.Text}", 
            $"\nAdditional Comments: {txtComment.Text}"
            };

            File.WriteAllLinesAsync("EntryRecord.txt", lines);

            if (isDataValid)
            {
                MessageBox.Show("Entry has successfully been created.");
            }

        }
    }
}
