   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5   	   &     airlineApp.View.AddCompanyWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:airlineApp.View     5   	   -   5        $��AddCompanyWnd��5   	     � Title$  Add Company��5   	   $	��240��5	   	   $	��300��6    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ #000080��6    � Offset$	 0.0Q�6+   � 5      $ #0000cd��6   $ 1Q�6+   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��130 �6   �� 5      $	��130 �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��15 �6   .+�5    
   �� $��2��6   $��1��5!      $��Center=�5"      $��Stretch=�5#      .+�5$      �� -   5        	 ��Name$	 CompanyNameTextBox��5$      $��Light"�5%      $��	helvetica)�5&      $��18(�5'      $��Center=�5)      
�������
������ 
������ $��1q�5-      $	��130��5.      $��35��5/      $
��Left=�50      
 J� Opacity$	
 0.7Q�51      $��
-15,30,0,0q�52       � Cursor$ IBeam��53   7   ��6   �� *CompanyName+67   �� 54       J� IsHitTestVisible$ False��6      CompanyNameTextBlock#���   55   !   $��Light"�56   !   $��	helvetica)�57      $��18(�58      $
��Left=�59      
�������
������ $	��130��5<      $��25��5=      $	
 0.7Q�5>      $��	0,-30,0,0q�5?      ��5@      �� 5A       �� 
TargetType" ��6   .�5B      ��  �� Property � y� �� Value$ 	Collapsed=�67    �� Triggers 5C      �� 5D       �� Binding 6*   �� *Text+ �� ElementName$ CompanyNameTextBox�� �� Value  6d   .a�5E   "   ��  � y�$ Visible=�6?   5F      5H      5J      �� 5K        InstrumentsButton#���  6   $	��100��5L      $��40��5M        Add#���  5N      $��0,55,0,0q�5O      ��5P      �� *AddCompanyWndCommand+��5Q      �� $ AddCompanyWnd��5R      �� 5S   
   $��1��6   $��1��5T      $��Stretch=�5U      $��Stretch=�5V      .+�5W      � $��80��6   $��80��5X      
�������$��0,10,0,0q�5Z      .+�5[      �� -   5         ��Name$
 Logo��5\   !   $��80��5[      $��80��5\      $
��Fill=�5^      ��5]      ��  �� Path$ CompanyLogo�5^      5_      �� 5`      #���  5a      $	��100��5b      $��40��5c        LoadLogo#���  5d      $��0,30,0,0q�5e      ��5f      �� *LoadCompanyLogoWndCommand+��5g      �� $ AddCompanyWnd��5i      5j      5k      