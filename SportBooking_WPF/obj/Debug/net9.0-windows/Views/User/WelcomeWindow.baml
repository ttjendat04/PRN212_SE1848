   M S B A M L   `   `   `  ����K  GSportBooking_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SportBooking_WPF.ViewsSportBooking_WPF.Views  5   	   (    "SportBooking_WPF.Views.LoginWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:SportBooking_WPF.Views     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Welcome��5	   	   $	��500��6   $	��400��6&   ���#2E8B57.��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Center=�6"   $��	0,20,0,10q�6?   .+�5      �� $#��/Resources/football-field.png��6   $	��100��6;   $	��100��6G   �� 5      $��SPOTI��6      	SportFont#��[  6%   $��Center=�6M   $��36(�6j   $
��Bold"�6x   ���#FBBA16$��0,10,0,0q�6�   $��Italic$�6�   5      �� 5   
   $��1��6   $��	0,10,0,10q�6"   .+�5      � $	��0,5q�6    � ColumnDefinitions 5      �� 5      $��80 �6'   �� 5!      $��* �6'   .+�5%      �� $��Email:��6   $��14(�6)   $��Center=�67   
�������$
��Bold"�6e   �� 5&      -   5         ��Name$ txtEmail��5&      $��Email��6,   $��1��69   
�������$��30��5'   $   5(   .   5)      � 5,      $	��0,5q�6    5-      �� 5.      $��80 �6'   �� 5/      $��* �6'   .+�52      �� $��	Password:��6   $��14(�6,   $��Center=�6:   
�������$
��Bold"�6h   G� 53      -   5         G�Name$ txtPassword��53      $��1��63   $��30��6C   
 � Tag$ Password��54      55   6   56      �� 59      -   5        $��Đăng nhập��59      
����������#2E8B57$
��Bold"�5;      $	��100��6   $��0,10,0,0q�6+   $��35��6=   5<      �� 5@   
   $��2��6   $��Bottom=�6"   $��	0,10,0,10q�6=   .+�5A      �� $��Center=�6   
�������Chưa có tài khoản? �� 5C      -   5        .�5C   3   
Đăng ký6<   5D      5E      5F      5G      