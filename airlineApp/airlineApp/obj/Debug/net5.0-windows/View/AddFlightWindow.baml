   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5   	   %    airlineApp.View.AddFlightWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:airlineApp.View     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��AddFlightWnd��5
   	     � Title$  
Add Flight��5	   	   $	��400��6   $	��280��6)    � 
ResizeMode$ NoResize=�5
       � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ #000080��6    � Offset$	 0.0Q�6+   � 5      $ #0000cd��6   $ 1Q�6+   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��15 �6    � RowDefinitions 5   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��15 �6   .+�5   
   �� $��1��6   $��1��5      .+�5       �� $	��200��5#      $��30��5$      $��4q�5%      
�������
���   �$��0,00,0,0q�5(         ChooseCompany)  #MaterialDesignThemes.Wpf.HintAssist	   Hint#	 �   5)      ��5!      �� *AllCompaniesString+
 �� SelectedItem
 5"      �� *FlightCompany+5*      �� 5+      $	��200��5/      $��30��50      $��4q�51      $��	0,15,0,15q�52      
�������
���   �  ChooseDeparture#	 �  55      ��5,      �� *AllDeparturesString+
 5-      �� *FlightWayDepartureString+56      �� 58      $	��200��5;      $��30��5<      $��4q�5=      $��0,0,0,15q�5>      
�������
���   �  ChooseArrival#	 �  5A      ��59      �� *AllArrivalsString+
 5:      �� *FlightWayArrivalString+5B      �� 5C       �� DisplayMemberPath$ DepartureTime��5F      $	��200��5G      $��30��5H      $��4q�5I      $��0,0,0,15q�5J      
�������
���   �  ChooseDepartureTime#	 �  5M      ��5D      �� *AllWaysDateTime+
 5E      �� *	FlightWay+5N      �� 5O      $	��200��5S      $��30��5T      $��4q�5U      $��0,0,0,0q�5V      
�������
���   �  ChoosePlane#	 �  5Y      ��5P      �� *	AllPlanes+
 5Q      �� *FlightPlane+5Z      �� 5[      -   5         ��Name$ CommentTextBox��5\       	 Price#	 �  5^      $	��200��5`      $��25��6   $��Light"�5a      $��	helvetica)�5b      $��12(�5c      
�������
������ 
������ $��1q�5g      $��0,15,0,0q�5h      ��5]      �� *FlightPrice+5h      �� 5k        InstrumentsButton#���  6   $	��100��5l      $��40��5m        Add#���  5n      $��0,20,0,0q�5o      ��5p      �� *AddFlightWndCommand+��5q      ��  �� RelativeSource ��  �� AncestorType local:AddFlightWindow5r      5t      5u      