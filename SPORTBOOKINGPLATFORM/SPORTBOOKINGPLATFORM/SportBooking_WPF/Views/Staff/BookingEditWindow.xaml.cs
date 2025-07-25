using DataAccessLayer;
using Repositories;
using Services;
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
    /// Interaction logic for BookingEditWindow.xaml
    /// </summary>
    public partial class BookingEditWindow : Window
    {
        public BusinessObjects.Booking BookingResult { get; set; } = null!;
        private bool isEditMode = false;
        private readonly ICourtService courtService = new CourtService();
        private readonly IUserService _userService =
            new UserService(new UserRepository(new SportsBookingDbContext()));

        public BookingEditWindow(BusinessObjects.Booking booking = null)
        {
            InitializeComponent();
            isEditMode = booking != null;
            BookingResult = isEditMode ? booking! : new BusinessObjects.Booking();

            LoadCourts();

            if (isEditMode)
                LoadBookingDetails();
        }

        private void LoadCourts()
        {
            var courts = courtService.GetAllCourts();
            cbCourt.ItemsSource = courts;
            cbCourt.DisplayMemberPath = "CourtName";
            cbCourt.SelectedValuePath = "CourtId";
        }

        private void LoadBookingDetails()
        {
            txtCus.Text = BookingResult.User?.FullName ?? "Guest";
            cbCourt.SelectedValue = BookingResult.CourtId;
            dpBookingDate.SelectedDate = BookingResult.BookingDate.ToDateTime(new TimeOnly(0, 0, 0));
            txtStartTime.Text = BookingResult.StartTime.ToString("hh\\:mm");
            txtEndTime.Text = BookingResult.EndTime.ToString("hh\\:mm");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbCourt.SelectedValue == null || dpBookingDate.SelectedDate == null)
                {
                    MessageBox.Show("All fields must be required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!TimeOnly.TryParse(txtStartTime.Text, out var startTime) ||
                    !TimeOnly.TryParse(txtEndTime.Text, out var endTime))
                {
                    MessageBox.Show("Invalid time format. Please use HH:mm format.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (startTime >= endTime)
                {
                    MessageBox.Show("Start time must be earlier than end time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                BookingResult.CourtId = (int)cbCourt.SelectedValue;
                BookingResult.BookingDate = DateOnly.FromDateTime(dpBookingDate.SelectedDate.Value);
                BookingResult.StartTime = startTime;
                BookingResult.EndTime = endTime;
                if (!isEditMode)
                {
                    string name = txtCus.Text.Trim();
                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Customer name is required.", "Validation Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    if(chkIsRegisteredUser.IsChecked == true)
                    {
                        var matchedUser = _userService.GetAllUsers()
                        .FirstOrDefault(u => u.FullName.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (matchedUser == null)
                        {
                            MessageBox.Show("No matching user found. Please check the name or uncheck the account checkbox.",
                                "User Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        BookingResult.UserId = matchedUser.UserId;
                        BookingResult.GuestName = null;
                    }
                    else
                    {
                        BookingResult.GuestName = name;
                        BookingResult.UserId = null; 
                    }
                    
                    BookingResult.Status = "Confirmed";
                    BookingResult.CreatedAt = DateTime.Now;

                }
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the booking: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
