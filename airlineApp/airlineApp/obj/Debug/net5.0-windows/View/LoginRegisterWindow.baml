   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5   	   E'clr-namespace:airlineApp.CustomControlsairlineApp.CustomControls  5   
   )    #airlineApp.View.LoginRegisterWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:airlineApp.View     5   	   :custom'clr-namespace:airlineApp.CustomControls     5   
   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  LoginWindow��5
   	   $	��450��6   $	��380��6*    � AllowsTransparency$
 True��5   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $	��200 �6    �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   ��5      �� 5      .��5      �  � Color$ #000080��6'    � Offset$	 0.0Q�67   � 5      $ #0000cd��6'   $ 1Q�67   5      5      �� 5      -   5        	 ��Name$	 ShutDownButton��5      $��25��5      $��25��6$   
�������$��1q�5#      $��Right=�5$      $	��Top=�5%      $��	0,15,15,0q�5&      
 � Cursor$

 Hand��5'   =   ��5       Z� ��5!      Z� ��5'      �� *ShutDownCommand+.��5*      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ power=�5+      $��22��5,      $��22��6$   5-      �� 5.      $��Center=�6   $��0��5/      .+�50      �� $��/Styles/logo.png��6   $��80��62   $��0,0,0,7q�51      �� 52      $��
AirlineApp��6   $��Light"�53      $��	helvetica)�54      $��22(�55      
�������$��Center=�57      58      �� 5:      $��1��6   .+�5;      ��  �� Orientation$ 
Horizontal=�6   $��Center=�67   .+�5<        $ Account=�5=      $��Center=�5>      $��Center=�5?      
�������$��0,0,10,0q�5A      �� 5B      -   5         ��Name$ EmailBox��5C      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Email��5D         
HelperText$  ��5E      
�������
�������$��Light"�5H      $��	helvetica)�5I      $��20(�5J      $	��200��5K      $
 IBeam��5M      ��5L      �� *
LoginEmail+5M      5O      �� 5R      $ 
Horizontal=�6   $��Center=�68   $��0,20,0,0q�6U   .+�5S        $	 Key=�5T      $��Center=�5U      $��Center=�5V      
�������$��0,0,10,0q�5X      3   -airlineApp.CustomControls.BindablePasswordBox  5Y      -   5          Name$ PasswordBox��5Z      
�������
�������$��Light"�5]      $��	helvetica)�5^      $��20(�5_         PasswordText# �   5`      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5a        PasswordMiniText# �  5b      $	��200��5c         Password 5d      �� *LoginPassword+5h      �� 5k      $ Vertical=�6   $��Center=�5l      $��0,30,0,0q�5m      .+�5n      ��   LoginRegisterButton#���  6   $	��100��6L   $��40��6X   $��LOGIN��6d   $��0,0,0,0q�6t   ��5o      �� *LoginCommand+��6>   ��  �� RelativeSource ��  �� AncestorType local:LoginRegisterWindow�� 5q      -   5        $	 ForgotPassLabel��5q        ForgotPassLabel#���  5r      
�������$��Light"�5t      $��	helvetica)�5u      $��10(�5v      
������ 
������ $��0,0,0,0q�5y       J� Opacity$	 0.7Q�5z      $��Center=�5{      $

 Hand��5|   H   ��6   �� *ForgotPasswordCommand+6H   �� 5}      -   5        $��RegisterLabel��5}        RegisterLabel#���  5~      
�������$��Light"�5�      $��	helvetica)�5�      $��16(�5�      
������ 
������ $��0,0,0,0q�5�      $	 0.7Q�5�      $��Center=�5�      $

 Hand��5�   G   ��6   �� *OpenRegisterWndCommand+��6U   ��  ��  local:LoginRegisterWindow5�      5�      5�      5�      5�      