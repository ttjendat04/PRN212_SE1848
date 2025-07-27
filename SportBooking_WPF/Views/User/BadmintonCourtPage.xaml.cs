﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccessLayer;
using Repositories;
using Services;
using SportBooking_WPF.Views.Court;
using CourtModel = BusinessObjects.Court;

namespace SportBooking_WPF.Views.User
{
    /// <summary>
    /// Interaction logic for BadmintonCourtPage.xaml
    /// </summary>
    public partial class BadmintonCourtPage : Page
    {
        private readonly ICourtService _courtService;

        public BadmintonCourtPage()
        {
            InitializeComponent();

            var dbContext = new SportsBookingDbContext();
            var courtRepository = new CourtRepository(dbContext);
            _courtService = new CourtService(courtRepository);
            LoadCourtsBySport(3);
        }

        private void LoadCourtsBySport(int sportId)
        {
            var courts = _courtService.GetCourtsBySportId(sportId);
            CourtWrapPanel.Children.Clear();

            foreach (var court in courts)
            {
                var border = new Border
                {
                    Width = 250,
                    Margin = new Thickness(10),
                    BorderBrush = Brushes.LightGray,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(8),
                    Background = Brushes.White
                };

                var stack = new StackPanel();

                var image = new Image
                {
                    Height = 150,
                    Stretch = Stretch.Fill,
                    Margin = new Thickness(0, 0, 0, 10)
                };

                try
                {
                    image.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/Images/court_{court.CourtId}.jpg"));
                }
                catch
                {
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/default-court.jpg"));
                }

                var nameText = new TextBlock
                {
                    Text = court.CourtName,
                    FontWeight = FontWeights.Bold,
                    FontSize = 16,
                    Margin = new Thickness(10, 0, 10, 5)
                };

                var locationText = new TextBlock
                {
                    Text = court.Location,
                    FontSize = 14,
                    Margin = new Thickness(10, 0, 10, 5)
                };

                var priceText = new TextBlock
                {
                    Text = $"Giá: {court.PricePerHour:N0} VND/giờ",
                    FontSize = 14,
                    Margin = new Thickness(10, 0, 10, 10)
                };

                var button = new Button
                {
                    Content = "Xem chi tiết",
                    Margin = new Thickness(10, 0, 10, 10),
                    Tag = court,
                    Background = new SolidColorBrush(Color.FromRgb(46, 139, 87)),
                    Foreground = Brushes.White
                };
                button.Click += CourtDetail_Click;


                // Nút "Đặt sân"
                var bookButton = new Button
                {
                    Content = "Đặt sân",
                    Margin = new Thickness(10, 0, 10, 10),
                    Tag = court,
                    Background = new SolidColorBrush(Color.FromRgb(46, 139, 87)),
                    Foreground = Brushes.White
                };

                bookButton.Click += BookCourtButton_Click;

                stack.Children.Add(image);
                stack.Children.Add(nameText);
                stack.Children.Add(locationText);
                stack.Children.Add(priceText);
                stack.Children.Add(button);
                stack.Children.Add(bookButton);

                border.Child = stack;
                CourtWrapPanel.Children.Add(border);
            }
        }

        private void CourtDetail_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is CourtModel selectedCourt)
            {
                var detailPage = new CourtDetailPage(selectedCourt);
                NavigationService?.Navigate(detailPage);
            }
        }

        private void BookCourtButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is CourtModel court)
            {
                var currentUser = Helpers.LoggedInUser.Instance.User; // hoặc truyền user đang đăng nhập
                var bookingPage = new SportBooking_WPF.Views.Booking.CourtBookingPage(court, currentUser);
                NavigationService?.Navigate(bookingPage);
            }
        }

    }
}
