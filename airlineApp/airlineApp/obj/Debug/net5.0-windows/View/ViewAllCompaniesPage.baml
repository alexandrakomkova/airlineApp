   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5      *    $airlineApp.View.ViewAllCompaniesPage   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:airlineApp.View     5      .��5	      � 
�������.+�5
   
   �� -   5          ��Name$  ViewAllCompanies��5      
���   �$��Center=�5      ��5      �� *AllCompanies+ �� SelectedItem 5      �� *SelectedCompany+ � ContextMenu 5      �� 5      .@�5      m�    Edit#���   6    m� Command 6?   �� *EditCompanyWndCommand+m� 5       
 Delete#���  6    6A   �� *DeleteCompanyCommand+5       �� View 5      �� 5      .P�5      �� $��Id��5       �� Width$
 auto��5       �� DisplayMemberBinding 5      ��  �� Path$ Id�5      �� 5      $
��Logo��5       $
 auto��5!       �� CellTemplate 5"      �� 5#      .R�5$   "   �� $��40��6E   $��40��6P   $
��Fill=�6\   ��6(   �� $
 Logo�6\   5%      5'      �� 5(      $��Company��5*       5)      �� $
 Name�5*      5,      5.      5/      50      