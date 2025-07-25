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

namespace SportBooking_WPF.Views.Staff
{
    /// <summary>
    /// Interaction logic for UserEditWindow.xaml
    /// </summary>
    public partial class UserEditWindow : Window
    {
        public BusinessObjects.User User { get; set; }
        private bool isEditMode = false;
        public UserEditWindow(BusinessObjects.User user = null)
        {
            InitializeComponent();
            isEditMode = user != null;
            this.User = isEditMode ? user : new BusinessObjects.User();
            
            LoadDetail();
        }
        private void LoadDetail()
        {
            if (isEditMode)
            {
                txtFullName.Text = User.FullName;
                txtEmail.Text = User.Email;
                txtPhone.Text = User.Phone;
                txtAddress.Text = User.Address;
                dpDOB.SelectedDate = User.Dob.Value.ToDateTime(new TimeOnly(0, 0));
                cbStatus.SelectedItem = User.Status;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string selectedStatus = (cbStatus.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Active";

            if (User == null) User = new BusinessObjects.User();

            User.FullName = txtFullName.Text.Trim();
            User.Email = txtEmail.Text.Trim();
            User.Phone = txtPhone.Text.Trim();
            User.Address = txtAddress.Text.Trim();
            User.Dob = DateOnly.FromDateTime(dpDOB.SelectedDate.Value);
            User.Status = selectedStatus;

            if (!isEditMode)
            {
                User.RoleId = 1; // Mặc định là User
                User.PasswordHash = "1";
                User.CreatedAt = DateTime.Now;
            }

            DialogResult = true;
            Close();
        }
    }
}
