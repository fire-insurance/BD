   M S B A M L   `   `   `  ����B  >Kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:KursachKursach  5   	       Kursach.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Kursach     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��600��5      $	��450��6'     � WindowStartupLocation$  CenterScreen=�63    � 
ResizeMode$ NoResize=�6X    � Icon$( "/Kursach;component/Assets/logo.png��6n    � WindowStyle$
 None=�6�   ���	#FF272727 J� Effect 5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
   
   .��5      � $��	0,0,0,-27q�6    � RowDefinitions 5   
   �� 5      �� 5      $
��599* �6   .+�5   
   �� $��50,50,50,50q�6   $��1��6*   .+�5      �� $��/Assets/logo.png��6   $��95��6.   $��128,-20,127,0q�69   �� 5      
�������$��10 20q�6(    �� CornerRadius$ 10��67   ._�5      �� $��40q�6   .+�5      �� $7��1Пожалуйста, выполните вход��6        MaterialDesignBody1TextBlock#��[  6B   $��Center=�5       �� 5      -   5         ��Name$ 	LoginText��5      $��-25,30,-25,0q�61     MaterialDesignTextBox#��[ 6G   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6v   	 �� 
CaretBrush
	 �P��6�   G� 5      -   5        
 G�Name$
 PasswordText��5   "   $��-25,35,-25,0q�68     MaterialDesignPasswordBox#��[ 6N   $ Пароль��6�    G� 
CaretBrush
 �P��6�   �� 5       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   .+�5      �� -   5         ��Name$ CancelButton��5   !   $��15,30q�67   $��Отмена��6F   
���P�� �� IsCancel . 6�   �� 5      -   5        $ EnterButton��5   !   $��15,30q�66   $��
Войти��6E   
���P�� �� 	IsDefault . 6�   5      �� 5      -   5         ��Name$ Invalid_info��5       $�� ��66   #��[  6>   5      5!      5$      5%      5&      