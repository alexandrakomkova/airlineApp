   M S B A M L   `   `   `  ����  
airlineApp    airlineApp.View.GetPlace   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5	      � 
������   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $	��150 �6   .+�5   
   �� $	��900��61   $	��200��5      $��bottom=�5      $��0��5      ��5      �� *schemeOfPlane+5      �� 5         InstrumentsButton#���   6   $��80��5      $��40��6     Back#���  5      $��	20,0,0,20q�5      $
��Left=�5      $��Center=�5      $��	GetTicket��5      $��1��5      ��5      �� *UpdateViewCommand+5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�5       $��Center=�5!      $��	0,0,10,10q�5"      $��1��5#      .+�5%      �� -   5         ��Name$ combo��5&      $	��120��5)      $��30��5*      $��4q�5+      
�������
���   �$��
0,0,100,20q�5.      $��Right=�5/        ChoosePlace)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  50      ��5'      �� *
PlacesList+ �� SelectedItem 5(      �� *ChosenPlace+52      �� 53      #���   6   $��80��54      $��40��6     Next#���  55      $��	0,0,20,20q�56      $��Right=�58      $��Bottom=�59      $��	Passenger��5:      ��57      �� *UpdateViewCommand+5:      5;      5<      5>      