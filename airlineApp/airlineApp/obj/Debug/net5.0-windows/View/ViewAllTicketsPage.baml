   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5      (    "airlineApp.View.ViewAllTicketsPage   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:airlineApp.View     5      .��5	      � 
�������.+�5
   
   �� -   5          ��Name$  ViewAllTickets��5      
���   �$��Center=�5      ��5      �� *
AllTickets+ �� View 5      �� 5      .P�5      �� $��Id��5       �� Width$
 auto��5       �� DisplayMemberBinding 5      ��  �� Path$ Id�5      �� 5      $��Company��5       5      �� $ ticketCompany.Name�5      �� 5      $��	Flight Id��5      $
 auto��5       5      �� $ ticketFlight.Id�5      �� 5      $��Fullname��5      $
 auto��5        5      �� $ Fullname�5       �� 5!      $��	Departure��5#      $
 auto��5$       5"      �� $ ticketWay.Departure�5$      �� 5%      $��Departure Time��5'      $
 auto��5(       5&      �� $ ticketWay.DepartureTime�5(      �� 5)      $��Arrival��5+      $
 auto��5,       5*      �� $ ticketWay.Arrival�5,      �� 5-      $��Arrival Time��5/      $
 auto��50       5.      �� $ ticketWay.ArrivalTime�50      �� 51      $��Plane��53      $
 auto��54       52      �� $ ticketPlane.Name�54      �� 55      $
��Seat��57      $
 auto��58       56      �� $
 Seat�58      �� 59      $��Price��5;      $
 auto��5<       5:      �� $ ticketFlight.Price�5<      5?      5A      5B      5C      