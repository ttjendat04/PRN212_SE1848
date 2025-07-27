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
            var courtWindow = new CourtManagementWindow();
            courtWindow.ShowDialog();
        }

        private void BtnRevenueReport_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng xem báo cáo doanh thu sẽ được bổ sung sau.", "Thông báo");
        }
    }
}
