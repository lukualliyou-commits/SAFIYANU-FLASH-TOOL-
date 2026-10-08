using System.Diagnostics;
using System.IO;

public partial class MainWindow {
    string firmwareFolder = @"C:\SAFIYANU_WORLD\Firmware";
    
    public MainWindow() {
        InitializeComponent();
        BtnReadInfo.Click += (s,e) => RunADB("adb devices", "Reading device info");
        BtnBackup.Click += (s,e) => RunADB("adb backup -all", "Backup");
        BtnADB.Click += (s,e) => RunADB("adb reboot recovery", "ADB Tools");
        BtnFlash.Click += (s,e) => {
            if(Directory.Exists(firmwareFolder))
                Process.Start("explorer.exe", firmwareFolder);
            else 
                LogText.Text += "\n> Create folder: C:\\SAFIYANU_WORLD\\Firmware - saka official firmware a ciki";
        };
        BtnOpenFolder.Click += (s,e) => Process.Start("explorer.exe", firmwareFolder);
        BtnSearchModels.Click += (s,e) => {
            // Load 6647 CSV
            var models = File.ReadAllLines("FULL_WORLD_6647.csv");
            LogText.Text += $"\n> Loaded {models.Length} models";
        };
    }

    void RunADB(string cmd, string action) {
        try {
            var psi = new ProcessStartInfo("cmd.exe", "/c " + cmd) { RedirectStandardOutput=true, UseShellExecute=false, CreateNoWindow=true };
            var p = Process.Start(psi);
            string output = p.StandardOutput.ReadToEnd();
            LogText.Text += $"\n> {action}: {output}";
            LogGrid.Items.Add(new { Time=DateTime.Now.ToString("HH:mm:ss"), Action=action, Result=output.Substring(0, Math.Min(50, output.Length)) });
        } catch(Exception ex) { LogText.Text += $"\n> Error: {ex.Message} - Install ADB first"; }
    }
}
