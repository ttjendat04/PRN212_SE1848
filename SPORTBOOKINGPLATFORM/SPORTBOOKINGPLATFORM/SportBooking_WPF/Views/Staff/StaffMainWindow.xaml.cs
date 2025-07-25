using BusinessObjects;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using BusinessObjects;
namespace SportBooking_WPF.Views.Staff
{
    /// <summary>
    /// Interaction logic for StaffMainWindow.xaml
    /// </summary>
    public partial class StaffMainWindow : Window
    {
        public StaffMainWindow()
        {
            InitializeComponent();
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            var bookingWindow = new StaffBookingWindow();
            bookingWindow.Show();
            this.Close();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            var userWindow = new UserManagementWindow();
            userWindow.Show();
            this.Close();
        }
    }
}
