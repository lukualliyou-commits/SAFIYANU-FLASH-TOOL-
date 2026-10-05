using System;
using System.Windows;
using System.IO.Ports;
using System.Management;
using System.Diagnostics;

namespace SafiyanuFlashTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckDriverBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
                foreach (ManagementObject obj in searcher.Get())
                {
                    string name = obj["Name"]?.ToString() ?? "";
                    if (name.Contains("Mediatek") || name.Contains("USB"))
                    {
                        MessageBox.Show("Driver found: " + name);
                        return;
                    }
                }
                MessageBox.Show("MTK Driver not found - Please install driver");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FlashBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SAFIYANU FLASH TOOL - Ready!");
        }
    }
}
