using Repositories;
using BusinessObjects;
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

namespace SportBooking_WPF.Views.Tournament
{
    /// <summary>
    /// Interaction logic for TournamentWindow.xaml
    /// </summary>
    public partial class TournamentWindow : Window
    {
        private readonly ITournamentService tournamentService = new TournamentService();
        private readonly BusinessObjects.User _currentUser;

        public TournamentWindow(BusinessObjects.User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            Loaded += TournamentWindow_Loaded;
        }

        private void TournamentWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTournaments();
            ApplyRolePermissions();
        }

        private void LoadTournaments()
        {
            if (tournamentService.UpdateTournamentStatuses())
            {
                MessageBox.Show("Đã cập nhật trạng thái các giải đấu.");
            }
            var tournaments = tournamentService.GetAllTournaments();
            dgTournaments.ItemsSource = tournaments;
        }

        private void ApplyRolePermissions()
        {
            bool isAdmin = _currentUser.RoleId == 4;
            bool isStaff = _currentUser.RoleId == 3;
            bool isManager = _currentUser.RoleId == 2;
            bool isUser = _currentUser.RoleId == 1;

            // Staff & Admin => Toàn quyền chỉnh sửa
            btnAdd.Visibility = (isStaff || isAdmin) ? Visibility.Visible : Visibility.Collapsed;
            btnEdit.Visibility = (isStaff || isAdmin) ? Visibility.Visible : Visibility.Collapsed;
            btnDelete.Visibility = (isStaff || isAdmin) ? Visibility.Visible : Visibility.Collapsed;

            // Manager & Staff & Admin => Được quyền duyệt đăng ký
            btnApprove.Visibility = (isManager || isStaff || isAdmin) ? Visibility.Visible : Visibility.Collapsed;

            // Chỉ User được phép đăng ký giải
            btnRegister.Visibility = isUser ? Visibility.Visible : Visibility.Collapsed;
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TournamentEditDialog(_currentUser);
            if (dialog.ShowDialog() == true)
            {
                if (tournamentService.AddTournament(dialog.Tournament))
                {
                    LoadTournaments();
                    MessageBox.Show("Thêm giải đấu thành công.");
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTournaments.SelectedItem is not BusinessObjects.Tournament selected)
            {
                MessageBox.Show("Vui lòng chọn một giải đấu để sửa.");
                return;
            }

            var dialog = new TournamentEditDialog(selected, _currentUser);
            if (dialog.ShowDialog() == true)
            {
                if (tournamentService.UpdateTournament(dialog.Tournament))
                {
                    LoadTournaments();
                    MessageBox.Show("Cập nhật thành công.");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTournaments.SelectedItem is not BusinessObjects.Tournament selected)
            {
                MessageBox.Show("Vui lòng chọn một giải đấu để xoá.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xoá giải đấu này?", "Xác nhận", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                if (tournamentService.DeleteTournament(selected.TournamentId))
                {
                    LoadTournaments();
                    MessageBox.Show("Xoá thành công.");
                }
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (dgTournaments.SelectedItem is not BusinessObjects.Tournament selected)
            {
                MessageBox.Show("Vui lòng chọn một giải đấu để đăng ký.");
                return;
            }

            var registerWindow = new TournamentRegisterWindow(_currentUser, selected.TournamentId);
            registerWindow.ShowDialog();
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            if (dgTournaments.SelectedItem is not BusinessObjects.Tournament selected)
            {
                MessageBox.Show("Vui lòng chọn một giải đấu để duyệt đăng ký.");
                return;
            }

            var approvalWindow = new RegistrationApprovalWindow(selected.TournamentId);
            approvalWindow.ShowDialog();
        }
        private void btnViewMyRegistrations_Click(object sender, RoutedEventArgs e)
        {
            var viewWindow = new ViewRegistrationWindow(_currentUser);
            viewWindow.ShowDialog();
        }

    }
}
    

