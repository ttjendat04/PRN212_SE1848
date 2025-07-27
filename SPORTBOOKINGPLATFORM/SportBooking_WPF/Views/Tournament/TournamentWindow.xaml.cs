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
        ITournamentService tournamentService = new TournamentService();
        BusinessObjects.User _currentUser;

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
            List<BusinessObjects.Tournament> tournaments = tournamentService.GetAllTournaments();
            dgTournaments.ItemsSource = tournaments;
        }

        private void ApplyRolePermissions()
        {
            bool isManagerOrAdmin = _currentUser.RoleId == 3 || _currentUser.RoleId == 4;

           btnAdd.Visibility = isManagerOrAdmin ? Visibility.Visible : Visibility.Collapsed;
           btnEdit.Visibility = isManagerOrAdmin ? Visibility.Visible : Visibility.Collapsed;
           btnDelete.Visibility = isManagerOrAdmin ? Visibility.Visible : Visibility.Collapsed;
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
    }
}
    

