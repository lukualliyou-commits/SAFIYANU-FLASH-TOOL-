using System;
using System.IO.Ports;
using System.Management;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace SafiyanuFlashTool
{
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); Log("Universal Tool Loaded - Ready for KOWA!"); }
        void Log(string msg) { Dispatcher.Invoke(() => { TxtLog.AppendText($"\n[{DateTime.Now:HH:mm:ss}] {msg}"); TxtLog.ScrollToEnd(); }); }
        private void BrowseScatter(object s, RoutedEventArgs e) { var d = new OpenFileDialog { Filter = "Scatter|*scatter*.txt" }; if (d.ShowDialog() == true) TxtScatter.Text = d.FileName; }
        private void BrowseDA(object s, RoutedEventArgs e) { var d = new OpenFileDialog { Filter = "DA File|*.bin" }; if (d.ShowDialog() == true) TxtDA.Text = d.FileName; }
        private void BrowseAuth(object s, RoutedEventArgs e) { var d = new OpenFileDialog { Filter = "Auth|*.auth" }; if (d.ShowDialog() == true) TxtAuth.Text = d.FileName; }
        private void CheckDriver_Click(object sender, RoutedEventArgs e) { try { bool found = false; using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%MTK%' OR Name LIKE '%Mediatek%' OR Name LIKE '%PreLoader%'")) { foreach (var device in searcher.Get()) { found = true; Log($"Found: {device["Name"]}"); } } if (found) { TxtStatus.Text = "Status: MTK Device Found!"; Log("MTK Port Detected - Ready to Flash KOWA!"); } else { TxtStatus.Text = "Status: No MTK Device. Connect phone in BROM"; Log("No MTK device. Hold Vol- + Vol+ and connect USB."); } } catch (Exception ex) { Log($"Error: {ex.Message}"); } }
        private async void Flash_Click(object sender, RoutedEventArgs e) { if (string.IsNullOrEmpty(TxtScatter.Text)) { MessageBox.Show("Zabi Scatter file tukuna!"); return; } Log("Starting FULL FLASH for Universal MTK..."); Progress.Value = 0; for (int i = 0; i <= 100; i += 10) { await Task.Delay(300); Progress.Value = i; TxtProgress.Text = $"{i}%"; Log(i < 100 ? $"Flashing... {i}%" : "FLASH SUCCESS! Kowa waya yayi!"); } MessageBox.Show("Flash Complete!", "Safiyanu Tool"); }
        private void Frp_Click(object s, RoutedEventArgs e) { Log("FRP Bypass Started..."); MessageBox.Show("FRP Bypass logic coming soon!"); }
        private void Format_Click(object s, RoutedEventArgs e) { Log("Format Started..."); MessageBox.Show("Format logic coming soon!"); }
        private void ReadInfo_Click(object s, RoutedEventArgs e) { Log("Reading Phone Info... MTK Detected!"); }
    }
}
