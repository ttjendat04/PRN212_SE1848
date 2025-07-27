using BusinessObjects;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Court = BusinessObjects.Court;
using CourtStatus = BusinessObjects.CourtStatus;

namespace SportBooking_WPF.Views.Manager
{
    public partial class CourtManagementWindow : Window
    {
        private readonly ICourtService _courtService;
        private BusinessObjects.Court? _selectedCourt;
        private List<CourtStatus> _statuses = new();

        public CourtManagementWindow(ICourtService courtService)
        {
            InitializeComponent();
            _courtService = courtService;
            this.Title = "Quản lý Sân Thể Thao";
            LoadStatuses();
            LoadCourts();
        }

        private void LoadStatuses()
        {
            try 
            {
                _statuses = _courtService.GetStatuses();
                cbStatus.ItemsSource = _statuses;
                cbStatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách trạng thái: {ex.Message}", 
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadCourts()
        {
            try 
            {
                var courts = _courtService.GetAllCourts();
                foreach (var court in courts)
                {
                    var status = _statuses.FirstOrDefault(s => s.StatusId == court.StatusId);
                    if (status != null)
                    {
                        court.StatusName = status.StatusName;
                    }
                }
                dgCourts.ItemsSource = courts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sân: {ex.Message}", 
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgCourts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCourts.SelectedItem is Court selected)
            {
                _selectedCourt = selected;
                txtCourtName.Text = selected.CourtName ?? "";
                txtLocation.Text = selected.Location ?? "";
                txtPrice.Text = selected.PricePerHour?.ToString() ?? "";
                txtSportId.Text = selected.SportId.ToString();
                cbStatus.SelectedValue = selected.StatusId ?? -1;
            }
        }

        private bool ValidateCourtData(out decimal price, out int sportId)
        {
            price = 0;
            sportId = 0;

            if (string.IsNullOrWhiteSpace(txtCourtName.Text) ||
                string.IsNullOrWhiteSpace(txtLocation.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtSportId.Text) ||
                cbStatus.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0)
            {
                MessageBox.Show("Giá/giờ phải là số dương hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(txtSportId.Text, out sportId) || sportId <= 0)
            {
                MessageBox.Show("SportID phải là số nguyên dương.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateCourtData(out decimal price, out int sportId))
                {
                    return;
                }

                var court = new Court
                {
                    CourtName = txtCourtName.Text.Trim(),
                    Location = txtLocation.Text.Trim(),
                    PricePerHour = price,
                    SportId = sportId,
                    StatusId = (int)cbStatus.SelectedValue
                };

                _courtService.AddCourt(court);
                MessageBox.Show("Thêm sân thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadCourts();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCourt == null)
            {
                MessageBox.Show("Vui lòng chọn sân cần cập nhật.", "Thông báo", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (!ValidateCourtData(out decimal price, out int sportId))
                {
                    return;
                }

                _selectedCourt.CourtName = txtCourtName.Text.Trim();
                _selectedCourt.Location = txtLocation.Text.Trim();
                _selectedCourt.PricePerHour = price;
                _selectedCourt.SportId = sportId;
                _selectedCourt.StatusId = (int)cbStatus.SelectedValue;

                _courtService.UpdateCourt(_selectedCourt);
                LoadCourts();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sân: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCourt == null)                 
            {
                MessageBox.Show("Vui lòng chọn sân cần xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sân '{_selectedCourt.CourtName}' không?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _courtService.DeleteCourt(_selectedCourt.CourtId);
                    MessageBox.Show("Xóa sân thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCourts();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ClearForm()
        {
            txtCourtName.Text = "";
            txtLocation.Text = "";
            txtPrice.Text = "";
            txtSportId.Text = "";
            cbStatus.SelectedIndex = -1;
            _selectedCourt = null;
        }
    }
}
