   M S B A M L   `   `   `  ����E  AairlineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:airlineApp.ViewairlineApp.View  5   	   E'clr-namespace:airlineApp.CustomControlsairlineApp.CustomControls  5   	   E'clr-namespace:airlineApp.CustomControlsairlineApp.CustomControls  5   R   $    airlineApp.View.RegisterWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:airlineApp.View     5   	   :custom'clr-namespace:airlineApp.CustomControls     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   <customcontrols'clr-namespace:airlineApp.CustomControls  6R     � Title$  RegisterWindow��5
   	   $	��450��6    $	��380��6-   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $	��180 �6    �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   ��5      �� 5      .��5      �  � Color$ #000080��6'    � Offset$	 0.0Q�67   � 5      $ #0000cd��6'   $ 1Q�67   5      5      �� 5      -   5         ��Name$ ShutDownButton��5      $��25��5      $��25��6$   
�������$��1q�5#      $��Right=�5$      $	��Top=�5%      $��	0,15,15,0q�5&      	 � Cursor$
	 Hand��5'   =   ��5       Z� ��5!      Z� ��5'      �� *ShutDownCommand+.��5*      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 power=�5+      $��22��5,      $��22��6$   5-      �� 5.      $��Center=�6   .+�5/      �� $��/Styles/logo.png��6   $��80��66   $��0,0,0,7q�50      �� 51      $��
AirlineApp��6    $��Light"�52      $��	helvetica)�53      $��22(�54      
�������$��Center=�56      58      �� 5<      $��1��6   .+�5=      ��  �� Orientation$ 
Horizontal=�6   $��Center=�67   .+�5>        $
 Account=�5?      $��Center=�5@      $��Center=�5A      
�������$��0,0,10,0q�5C      �� 5D      -   5         ��Name$ EmailBox��5E      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Email��5F         
HelperText$  ��5G      
�������
�������$��Light"�5J      $��	helvetica)�5K      $��20(�5L      $	��200��5M      ��5N      �� *	EmailText+5O      �� 5R      $ 
Horizontal=�6   $��Center=�68   $��0,20,0,0q�6U   .+�5S        $	
 Key=�5T      $��Center=�5U      $��Center=�5V      
�������$��0,0,10,0q�5X      3   -airlineApp.CustomControls.BindablePasswordBox  5Y      -   5          Name$ passwordBox��5Z      
�������
�������$��Light"�5]      $��	helvetica)�5^      $��20(�5_         PasswordText# �   5`      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5a        PasswordMiniText# �  5b      $	��200��5c         Password 5d      �� *PasswordText+5f      �� 5g      $ 
Horizontal=�6   $��Center=�68   $��0,20,0,0q�6U   .+�5h        $	
 Key=�5i      $��Center=�5j      $��Center=�5k      
�������$��0,0,10,0q�5m        5o      -   5        $ ConfirmPasswordBox��5p      
�������
�������$��Light"�5s      $��	helvetica)�5t      $��20(�5u        ConfirmPasswordText# �  5v      $
 True��5w        ConfirmPasswordMiniText# �  5x      $	��200��5y       5z      �� *ConfirmPasswordText+5|      �� 5~      $ Vertical=�6   $��Center=�5      $��0,30,0,0q�5�      .+�5�      ��   LoginRegisterButton#���  6   $	��100��5�      $��40��6)   $��REGISTER��5�      ��5�      �� *RegisterCommand+��5�      ��  �� RelativeSource ��  �� AncestorType local:RegisterWindow�� 5�      -   5        $��RegisterLabel��5�        
LoginLabel#���  5�      
�������$��Light"�5�      $��	helvetica)�5�      
������ 
������ $��16(�5�      $��0,10,0,0q�5�       J� Opacity$	 0.7Q�5�      $��Center=�5�      $
	 Hand��5�   D   ��6   �� *OpenLoginWndCommand+��5�      ��  ��  local:LoginRegisterWindow5�      5�      5�      5�      5�      