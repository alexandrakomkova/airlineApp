   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5   	        airlineApp.View.UserWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:airlineApp.View     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
UserWindow��5	   	   $	��700��6   $
��1024��6-   $	��600��5
   	   $
��1024��6    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ #000080��6    � Offset$ 0Q�6+   � 5      $ #0000cd��6   $ 1Q�6+   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��15 �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��15 �6   .+�5   
   �� $��/Styles/logo.png��6   $��30��6*   $��0��5       $��1��5!      $��20,0,0,0q�5"      $
��Left=�5#      �� 5$   
   $��0��6   $��1��5%      $��Center=�5&       �� Orientation$ 
Horizontal=�5'      $��Right=�5(      .+�5*      �� $��Center=�6   $��0,0,30,0q�5+      $ 
Horizontal=�5,      .+�5-      �� )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Language��5.      
���   �
�������$��4q�51      
 �� SelectedIndex
 52      �� *SelectedLanguage+.@�54      �� $��Русский��55      �� 56      $��English��58      59      5;      �� 5<      $��10,0,0,0q�6   $��30��5=      $��30��6$   
�������$��1q�5A       � Cursor$
 Hand��5B   E   ��5>      Z� ��5?      Z� ��5B      �� *SearchUserTicketCommand+.��5D      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�5E      $��30��5F      $��30��6$   5H      �� 5I      $��	10,0,10,0q�6   $��30��5J      $��30��6$   
�������$��1q�5N      $
 Hand��5O   C   ��5K      Z� ��5L      Z� ��5O      �� *ViewUserTicketCommand+.��5Q        $ Ticket=�5R      $��30��5S      $��30��6$   5U      �� 5V      -   5         ��Name$ LogOutButton��5V      $��25��5W      $��25��6$   
�������$��1q�5[      $��6,0,6,0q�5\      $
 Hand��5^      ��5Y      Z� ��5Z      Z� ��5]      �� *ChangeAccountWndCommand+��5_      ��  �� RelativeSource ��  �� AncestorType local:UserWindow.��5a        $ Logout=�5b      $��22��5c      $��22��6$   5d      �� 5f      -   5        $ ShutDownButton��5f      $��25��5g      $��25��6$   
�������$��1q�5k      ��5h      Z� ��5i      Z� ��5l      �� *ShutDownCommand+.��5n        $ power=�5o      $��22��5p      $��22��6$   5q      5r      �� 5x   
   -   5         ��Name$ 	mainFrame��5x      $��1��5z      $��1��5{      $��2��6!   ��5y      �� *CurrentPage+5{   !   5~      5      