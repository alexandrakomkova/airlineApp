   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5   	   &     airlineApp.View.EditFlightWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:airlineApp.View     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  EditFlightWnd��5   	    � Title$ Edit Flight��5	   	   $	��400��6   $	��280��6*    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ #000080��6    � Offset$	 0.0Q�6+   � 5      $ #0000cd��6   $ 1Q�6+   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��15 �6   	 � RowDefinitions	 5   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��15 �6   .+�5   
   �� $��1��6   $��1��5      .+�5!      �� $	��200��5%      $��30��5&      $��4q�5'      
�������
���   �$��0,00,0,0q�5*      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Choose a company��5+      ��5"      �� *AllCompaniesString+ �� SelectedItem 5#      �� *FlightCompany+5,      �� 5-      $ �� IsSynchronizedWithCurrentItem$
 TrueY�51      $	��200��52      $��30��53      $��4q�54      $��	0,15,0,15q�55      
�������
���   �$!
 Choose a place of departure��58      ��5/      �� *AllDeparturesString+ 50      �� *FlightWayDepartureString+ �� Mode$ TwoWay=�58      �� 5:       �� 
IsEditable$
 True��5>      $	��200��5@      $��30��5A      $��4q�5B      $��0,0,0,15q�5C      
�������
���   �$
 Choose a place of arrival��5F      ��5;      �� *AllArrivalsString+ 5<      �� *FlightWayArrivalString+ �� Text 5=      �� *FlightWayArrivalString+5G      �� 5H       �� DisplayMemberPath$ DepartureTime��5K      $	��200��5L      $��30��5M      $��4q�5N      $��0,0,0,15q�5O      
�������
���   �$!
 Choose a departure datetime��5R      ��5I      �� *AllWaysDateTime+ 5J      �� *	FlightWay+5S      �� 5T      $	��200��5X      $��30��5Y      $��4q�5Z      $��0,0,0,0q�5[      
�������
���   �$
 Choose a plane��5^      ��5U      �� *	AllPlanes+ 5V      �� *FlightPlane+5_      �� 5`      -   5         ��Name$ CommentTextBox��5a      $
 Price��5c      $	��200��5e      $��25��6   $��Light"�5f      $��	helvetica)�5g      $��12(�5h      
�������
������ 
������ $��1q�5l      $��0,15,0,0q�5m       � Cursor$ IBeam��6,   ��5b      �� *FlightPrice+5m   ,   �� 5n         InstrumentsButton#���   6   $	��100��5o      $��40��5p      $��
SAVE EDITS��5q      $��0,20,0,0q�5r      ��5s      �� *EditFlightCommand+��5t      ��  �� RelativeSource ��  �� AncestorType local:EditFlightWindow5w      5x      5y      