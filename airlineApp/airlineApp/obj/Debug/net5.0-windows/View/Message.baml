   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5   	       airlineApp.View.Message   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:airlineApp.View     5   	   -   5        $��
MessageWnd��5   	     � Title$  Message��5	   	   $	��160��6   $	��260��6&    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��70 �6   .+�5   
   �� -   5         ��Name$ MessageText��5      $��0��6)   $��Center=�5      $��Center=�5      $
��Wrap=�5      �� 5   
   $��1��6      InstrumentsButtonBlack#���   5      $��OK��5      $	��110��5      $��40��5      
����  �
����  �$��4q�5       $��16(�5!      $��DemiBold"�5"       � Cursor$
 Hand��5#      ��5      �� *CloseWndCommand+��5      ��  �� ElementName$ 
MessageWnd��5#      5$      5%      