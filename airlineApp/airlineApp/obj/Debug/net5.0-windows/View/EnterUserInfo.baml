   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5      #    airlineApp.View.EnterUserInfo   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:airlineApp.View     5      .��5	      � 
������   � ColumnDefinitions  5
   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   ��    InstrumentsButton#���   6   $��40��6=     Back#���  5      $��	20,0,0,20q�5      $��Bottom=�5      $��Place��5      $��0��5      ��5      �� *UpdateViewCommand+5      �� 5   
   $��Center=�6   $��Center=�5      $	��300��5      $	��300��5      $��40,0,0,0q�5      
������  �� Orientation$ Vertical=�5      $��1��5      .+�5      ��   EnterUserInfoLabel#���  6   $��Center=�6D   $��0,10,0,0q�5       $
��Bold"�5!      
�������$��16(�5#      �� 5&      $ 
Horizontal=�6   $��	10,10,0,0q�5'      .+�5(      ��   Surname#���  6   $	��140��5)      $��16(�6!   $��0,10,0,0q�5*      $��DemiBold"�5+      
�������5,      �� 5-      -   5        $	��180��5-      $��30��6&   
�������
�������$��16(�50       � Cursor$ IBeam��52   <   ��6   �� *PassengerSurname+6<   53      �� 54      $ 
Horizontal=�6   $��	10,10,0,0q�55      .+�56      �� #��� ��6   $	��140��57      $��16(�6!   $��0,10,0,0q�58      $��DemiBold"�59      
�������5:      �� 5;      -   5        $	��180��5;      $��30��6&   
�������
�������$��16(�5>      ��5@      �� *PassengerName+5A      �� 5B      $ 
Horizontal=�6   $��	10,10,0,0q�5C      .+�5D      ��   
MiddleName#���  6   $	��140��5E      $��16(�6!   $��0,10,0,0q�5F      $��DemiBold"�5G      
�������5H      �� 5I      -   5        $	��180��5I      $��30��6&   
�������
�������$��16(�5L      ��5N      �� *PassengerMiddleName+5O      �� 5P      $ 
Horizontal=�6   $��	10,10,0,0q�5Q      .+�5R      ��   Passport#���  6   $	��140��5S      $��16(�6!   
�������$��0,10,0,0q�5U      $��DemiBold"�5V      �� 5W      $	��180��6   $��30��6&   
�������
�������$��16(�5Z      $ IBeam��5[   =   ��6   �� *PassengerPassport+6=   5\      5_      �� 5`   
   $��2��6   #���   5a      $��80��5b      $��40��6     Next#���  5c      $��	0,0,20,20q�5d      $��Right=�5f      $��Bottom=�5g      $��BookATicket��5h      ��5e      �� *UpdateViewCommand+5h      5j      5k      