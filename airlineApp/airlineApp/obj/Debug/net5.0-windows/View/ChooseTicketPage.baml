   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5      E'clr-namespace:airlineApp.CustomControlsairlineApp.CustomControls  5      ;"clr-namespace:airlineApp.ViewModelairlineApp.ViewModel  6>   &     airlineApp.View.ChooseTicketPage   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:airlineApp.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      4custom'clr-namespace:airlineApp.CustomControls  5      2	viewmodel"clr-namespace:airlineApp.ViewModel  6>   .��5      �   � RowDefinitions  5   
   �� 5      $	��120 �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6   $��Center=�5       �� Orientation$ 
Horizontal=�5      $	��780��6*   .+�5      �� $ 
Horizontal=�6   $	��Top=�5      .+�5      �� $	��130��5      $��40��5      $��4q�5      
�������
���   �$��0,0,10,0q�5"      $��Center=�5#      $��Center=�5$         DepartureLabel)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   5%      ��5&      �� *AllDeparturesString+ �� SelectedItem 5'      �� *FlightWayDepartureString+5*      �� 5+      $��30��6   $��30��6$   
�������$��1q�5/      $��0,0,10,0q�50      ��5,      Z� ��5-      Z� ��51      �� *SwitchDapartureArrivalCommand+.��52      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowLeftRight=�53      $��25��6/   $��25��6:   55      �� 56      $	��130��57      $��40��58      $��4q�59      
�������
���   �$��0,0,0,0q�5<      $��Center=�5=      $��Center=�5>        ArrivalLabel# �  5?      ��5@      �� *AllArrivalsString+ 5A      �� *FlightWayArrivalString+5C      5E      �� 5G      $��30,0,0,0q�5I      $ 
Horizontal=�5J      .+�5L      (  "System.Windows.Controls.DatePicker  $	��Top=�5M      $	��135��5N        DepartureTime# �  5P       $  MaterialDesignOutlinedDatePicker#��[ 5Q      
�������
�������$��0,0,20,0q�5U         FirstDayOfWeek$ Monday=�5V         DisplayDateEnd 
2031-12-125X         SelectedDate 5T      �� *SelectedDepartureDate+   DisplayDateStart 5W      �� *SelectedDepartureDate+	   DisplayDate	 5Y      �� *SelectedDepartureDate+�� 5]      $ Vertical=�6   $��60,0,0,0q�5^      $��Right=�5_      $��0��5`      .+�5b      ��   InstrumentsButton#���  6   $	��110��5c      $��40��6!    
 Search#���  5d      $��0,0,0,0q�68   ��5e      �� *UserSearchCommand+5f      5g      5i      �� 5j   
   $��1��6   $ Vertical=�5k      $��center=�5l      
�������.+�5n      �� -   5        
 ��Name$
 ViewUserFlights��5n      $	��770��5o      $	��300��5p      $��0,0,0,30q�5q      
���������5s      �� *UserListOneWay+ 5t      �� *UserSelectedFlight+ �� View 5u      �� 5v      .P�5w      �� $��	Departure��5y       �� Width$
 auto��5z       �� DisplayMemberBinding 5x      ��  �� Path$ flightWay.Departure�5z      �� 5{      $��Arrival��5}      $
 auto��5~       5|      �� $ flightWay.Arrival�5~      �� 5      $��Departure Date��5�      $
 auto��5�       5�      �� $ flightWay.DepartureTime�5�      �� 5�      $��Arrival Date��5�      $
 auto��5�       5�      �� $ flightWay.ArrivalTime�5�      �� 5�      $��Price��5�      $
 auto��5�       5�      �� $ Price�5�      �� 5�      $��Free Places��5�      $
 auto��5�       5�      �� $ 
FreePlaces�5�      5�      5�      5�      �� 5�   
   #���  5�      $��80��5�      $��40��6     Next#���  5�      $��	0,0,20,20q�5�      $��Bottom=�5�      $��Right=�5�      $��Place��5�      $��1��5�      ��5�      �� *UpdateViewCommand+5�      5�      5�      