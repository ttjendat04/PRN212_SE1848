   M S B A M L   `   `   `  ����K  GSportBooking_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SportBooking_WPF.Views.UserSportBooking_WPF.Views.User  5   	   0    *SportBooking_WPF.Views.User.UserMainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:SportBooking_WPF.Views.User     5   	     � Title$  SPOTI��5   	   $	��600��6   $	��900��6$   ���#2E8B57 � WindowStartupLocation$ CenterScreen=�5	       � 	Resources 5         NavButtonStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  CustomMenuItemStyle��%>  &	        &	 �    �� 5   
   " ��6'   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 18(�6)   �� 5       � ��$ 20,10q�6(   �� 5       � ��$
 10,0q�6'   �� 5       � ��$ 0q�60   �� 5       �@�Cursor$
 Hand��6'    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#FBBA1663   �� 5       � �� �#2E8B5763   5      5      �� 5   
   " m�6   .�5       ��  � ��
 �����6+   �� 5!       � ��$ 18(�6)   �� 5"       � ��$ 20,10q�6(    5#      P� 5$       �@J�IsMouseOver$
 True��61   . �5%      ��  � �� �#FBBA1663   �� 5&       � �� �#2E8B5763   5'      5)      5*      .��5,      ]� .+�5-   
   � $	��Top=�6   ���#2E8B57$��80��69   	 � ColumnDefinitions	 5.      �� 5/      $	��250 �6#   �� 50      $��* �6#   �� 51      $	��250 �6#   .+�55      �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�62   $��0��6M   $
��20,0q�6]   .+�56      �� $#��/Resources/football-field.png��6   $��45��6?   $��45��6J   $��0,0,10,0q�6V   �� 57      $��SPOTI��6   $��	BebasNeue)�6)   $��32(�6@   ���#FBBA16$��Center=�58   1   $
��Bold"�6L   $��Italic$�6^   59      �� 5<      $
 
Horizontal=�6   $��Center=�62   $��Center=�6O   $��1��6j   $
��10,0q�6z   .+�5=      �� -   5        $��Trang chủ��5=      $��18(�6-   $��20,10q�6;   #��[  6K   $
��10,0q�5>      
������ 
�������
������  � Cursor$
 Hand��6m   o� 5A      $��Center=�6   $
��10,0q�62   .@�5B      m� $��Đặt sân��6   #��[ 60   .@�5C      m� -   5        $��Sân bóng đá��5C   #   #��[ 68   6e   m� 5D      -   5        $��Sân bóng rổ��5D   #   #��[ 68   6e   m� 5E      -   5        $��Sân cầu lông��5E   #   #��[ 69   6f   5F      5G      �� 5I      -   5        $��Giải đấu��5I      #��[  6,   6T   5J      o� 5L      $��2��6   $��Right=�6#   $��Center=�6?   $
��20,0q�6Z   .@�5M      m� $��Xin chào, [Tên]��6   #��[ 68   .@�5N      m� -   5        $��Hồ sơ��5N      #��[ 6.   6[   m� 5O      -   5        $��Lịch sử��5O      #��[ 60   6]   �� 5P      m� 5Q      -   5        $��Đăng xuất��5Q      #��[ 62   6_   5R      5S      5U       � 5X   
   -	   5          �Name$ 	MainFrame��5X        � NavigationUIVisibility$ Hidden=�6#   5Z      5[      