   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5   	   E'clr-namespace:AirlineApp.CustomControlsAirlineApp.CustomControls  5   	        airlineApp.View.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:airlineApp.View     5   	   :custom'clr-namespace:AirlineApp.CustomControls     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5
   	   $	��600��6   $
��1040��6,   $	��600��5   	   $
��1040��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��210 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��1��6   .+�5      �� ��6   �� *CurrentList+5      � 5   
   $��1��6   ��5       �� 5!       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5"      �  � Color$ #000080��6#    � Offset$ 0Q�63   � 5#      $ #0000cd��6#   $ 1Q�63   5$       5&      �� 5'      $	��100 �6    �� 5(      $��* �6    .+�5+      � $��0��6   .+�5,      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5-      $��Center=�5.      .+�5/      +   %AirlineApp.CustomControls.AnalogClock  $��0,0,0,0q�6)   52      53      �� 55      $��1��6   $��0,30,0,0q�56      .+�57      �� -   5        	 ��Name$	 ViewAllFlight��57         InstrumentsButton#���   60   $	��160��6]   $��40��6i     ViewAllFlight#���  6u   $��0,0,0,0q�6�   $��Flight��6�     ViewAllFlightToolTip
 � ToolTip#
 �  6�   ��6�   �� *UpdateViewCommand+6�   �� 58      -   5        $	 ViewAllCompanies��58      #���   63   $	��160��6`   $��40��6l     ViewAllCompanies#���  6x   $��0,10,0,0q�6�   $��Company��6�     ViewAllCompaniesToolTip#
 �  6�   ��6�   �� *UpdateViewCommand+6�   �� 59      -   5        $	 ViewAllTickets��59      #���   61   $	��160��6^   $��40��6j     ViewAllTickets#���  6v   $��0,10,0,0q�6�   $��Ticket��6�     ViewAllTicketsToolTip#
 �  6�   ��6�   �� *UpdateViewCommand+6�   �� 5:      -   5        $	 
AddCompany��5:      #���   6-   $	��160��6Z   $��40��6f     
AddCompany#���  6r   $��0,10,0,0q�6�   ��6�   �� *OpenAddCompanyWndCommand+�� 5;      -   5        $	 	AddFlight��5;      #���   6,   $	��160��6Y   $��40��6e     	AddFlight#���  6q   $��0,10,0,0q�6�   ��6�   �� *OpenAddFlightWndCommand+5=      5B      � 5F   
   -   5         �Name$ ToolBarGrid��5F      $��2��6$   ���#000080.+�5H      �� $��/Styles/logo.png��6   $��30��6.   $��20,0,0,0q�5I      $
��Left=�5J      �� 5K      $ 
Horizontal=�6   $��Right=�62   $��0,0,15,0q�5L      .+�5O      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�5P      $��25��5Q      $��25��6$   
�������$��0,10,5,0q�5S      $��Center=�5T      $
��Left=�5U      �� 5V      -   5         ��Name$ PhoneTextBox��5W      $��4q�5X      $��25��5Y      
�������$	��150��5[      
���   �$��Center=�5^      $
��Left=�5_      $��	0,0,140,0q�5`      /  )MaterialDesignThemes.Wpf.TransitionAssist   DisableTransitions$
 True��5a       � Cursor$ IBeam��6W   ��5]      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5a   W   �� 5b      $��Center=�6   $��0,0,30,0q�5c      $ 
Horizontal=�5d      .+�5e      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Language��5f      
���   �
�������$��4q�5i       �� SelectedIndex 5j      �� *SelectedLanguage+.@�5l      �� $��Русский��5m      �� 5n      $��English��5p      5q      5s      o� 5t      ���#000080
�������.@�5v      m�  m� Icon 6   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ SortVariant=�.@�5w      m�  	 SortByCompany#��� 	 6#    m� Command 5x   #   �� *SortByCompanyCommand+ 5y   #     $' !SortAlphabeticalDescendingVariant=�m� 5z       
 SortByDeparture#��� 
 6#    5{   #   �� *SortByDepartureCommand+ 5|   #     $ AirplaneTakeoff=�m� 5}        SortByArrival#���  6#    5~   #   �� *SortByArrivalCommand+ 5   #     $ AirplaneLanding=�m� 5�        SortByPrice#���  6#    5�   #   �� *SortByPriceCommand+ 5�   #     $ SortNumericVariant=�5�      5�      �� 5�      -   5        $	 LogOutButton��5�      $��25��5�      $��25��6$   
�������$��1q�5�      $��6,0,6,0q�5�      $
 Hand��5�      ��5�      Z� ��5�      Z� ��5�      �� *ChangeAccountWndCommand+��5�      ��  �� RelativeSource ��  �� AncestorType local:MainWindow.��5�        $ Logout=�5�      $��22��5�      $��22��6$   5�      �� 5�      -	   5        $	 ShutDownButton��5�      $��25��5�      $��25��6$   
�������$��1q�5�      $
 Hand��5�   =   ��5�      Z� ��5�      Z� ��5�      �� *ShutDownCommand+.��5�        $ power=�5�      $��22��5�      $��22��6$   5�      5�      5�      5�      5�      