   M S B A M L   `   `   `  ����K  GSportBooking_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SportBooking_WPF.Views.BookingSportBooking_WPF.Views.Booking  5   	   5    /SportBooking_WPF.Views.Booking.CourtBookingPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:SportBooking_WPF.Views.Booking     5   	     N� 
Background  �#2E8B57 N� Title$ BookingWindow��5   	   $
��Auto��6   $	��800��6-   .��5	      � $��30q�6    � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��3* �6   .+�5   
   �� -   5         ��Name$ imgCourt��5      $��0��5   
   $��10q�5   
   $��UniformToFill=�5   
   $��Center=�5   
   $	��Top=�5   
   �� 5   
   $��1��6   $
��Auto=�6'   .��5      �� $��1��6   $��20q�6)   $	��Top=�65   .+�5      �� $��Đặt sân��6   $��24(�6'   $
��Bold"�65   $��0 0 0 20q�5      
�������6*   �� 5      $��Tên người đặt:��6   �� 5      -   5         ��Name$ txtboxBookerName��5      $��0 0 0 10q�60    �� 
IsReadOnly$
 True��5       �� 5"      $��
Tên sân:��6   
�������6(   �� 5#      -   5        $ txtboxCourtName��5#      $
 True��5$      $��0 0 0 10q�6(   �� 5)      $��Ngày đặt sân:��6   
�������6-   (  "System.Windows.Controls.DatePicker  5*      -   5          Name$ dpDate��5*      $��0 0 0 10q�6)      SelectedDate 6;   �� *BookingDate+�� 5,      $��Thời gian bắt đầu:��6   
�������62   �� 5-      -   5         ��Name$ cbStartTime��5-      $��0 0 0 10q�6,   .@�5.      �� $��06:00��6   �� 5/      $��07:00��6   �� 50      $��08:00��6   �� 51      $��09:00��6   �� 52      $��10:00��6   �� 53      $��11:00��6   �� 54      $��12:00��6   �� 55      $��13:00��6   �� 56      $��14:00��6   �� 57      $��15:00��6   �� 58      $��16:00��6   �� 59      $��17:00��6   �� 5:      $��18:00��6   �� 5;      $��19:00��6   �� 5<      $��20:00��6   �� 5=      $��21:00��6   �� 5>      $��22:00��6   �� 5?      $��23:00��6   5@      �� 5B      $��Thời lượng (giờ):��6   $
��Bold"�61   
�������6C   �� 5C      -   5        $ txtDuration��5C      $��0 0 0 10q�6+   ��5D      �� *
Duration+60   �� 5F      $��Giá tiền (VND):��6   $
��Bold"�6/   
�������6A   �� 5G      -   5        $ txtTotalPrice��5G      $��0 0 0 20q�6-   $
 True��6?   �� 5K      -   5        $��Xác nhận đặt sân��5K      $	��200��5L      $��40��5M      ���#2E8B57
�������$��Center=�5P      5Q      5R      5S      5T      5U      