using System.Windows;

namespace EmrsTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            var win = new NewAppointment();
            win.ShowDialog();
        }
    }
}
