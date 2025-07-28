using System.Windows;

namespace SportBooking_WPF.Views.Manager
{
    public partial class ManagerDashboardWindow : Window
    {
        public ManagerDashboardWindow()
        {
            InitializeComponent();
        }

        private void BtnUserManagement_Click(object sender, RoutedEventArgs e)
        {
            var userWindow = new ManagerWindow();
            userWindow.ShowDialog();
        }

        private void BtnCourtManagement_Click(object sender, RoutedEventArgs e)
        {
            //lay cua trang Admin 
        }

        private void BtnRevenueReport_Click(object sender, RoutedEventArgs e)
        {
            RevenueReportWindow window = new RevenueReportWindow();
            window.ShowDialog(); 
        }

        private void BtnBookingManagement_Click(object sender, RoutedEventArgs e)
        {
            //lay window booking 
        }
    }
}
