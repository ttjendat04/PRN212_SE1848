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

namespace SportBooking_WPF.Views.User
{
    /// <summary>
    /// Interaction logic for UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        private BusinessObjects.User _currentUser;
        public UserMainWindow(BusinessObjects.User user)
        {
            InitializeComponent();
            _currentUser = user;

            this.Title = $"Xin chào {user.FullName}";
        }
    }
}
