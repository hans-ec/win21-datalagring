   M S B A M L   `   `   `  ����Q  M03_EntityFramework_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:_03_EntityFramework_WPF.Views_03_EntityFramework_WPF.Views  5      ,    &_03_EntityFramework_WPF.Views.UserView   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:_03_EntityFramework_WPF.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��Customer List��6,   $��18(�6A   $
��Left=�6O   $��7q�6j   $��Center=�6u   5      � 5      $��7q�6    5      �� 5      $
��0.5* �6'   �� 5      $��1* �6'   �� 5      $��1* �6'   �� 5      $
��1.5* �6'   .+�5!      �� $��0��6   $��#��6,   �� 5"      $��1��6   $
��User��6,   �� 5#      $��2��6   $
��Role��6,   �� 5$      $��3��6   $��Email��6,   5%      5&      �� 5)   
   -   5         ��Name$ lvUsers��5)       � DataContext$ Wpf.Models.User��6$   $��1��6B   
������ $��Stretch=�6h   $��Stretch=�6�   ��5*      �� 5+      .R�5,      �  5-      �� 5.      $
��0.5* �6/   �� 5/      $��1* �6/   �� 50      $��1* �6/   �� 51      $
��1.5* �6/   .+�54      �� $��0��6$   ��64   �� *Id+�� 55      $��1��6$   ��64   �� *DisplayName+�� 56      $��2��6$   ��64   �� *	Role.Name+�� 57      $��3��6$   ��64   �� *Email+58      59      5;      5<      5=      