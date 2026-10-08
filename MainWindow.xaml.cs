using System.Windows;

namespace EmrsTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AppointmentButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            NewAppointment appointment =
                new NewAppointment();

            appointment.Owner = this;
            appointment.ShowDialog();
        }
    }
}
