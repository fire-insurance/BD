   M S B A M L   `   `   `  ����B  >Kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Kursach.ViewKursach.View  5   	       Kursach.View.HouseInfo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Kursach.View     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
     � Title$  LandInfo��5	   	   $	��720��6   $
��1375��6'   ���	#FF272727 � WindowStartupLocation$ CenterScreen=�6K    � 
ResizeMode$ NoResize=�6p    � WindowStyle$
 None=�6�    � Icon$( "/Kursach;component/Assets/logo.png��6�   .��5
      � $��
0,0,-102,0q�6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��47 �6   �� 5      $��22 �6   �� 5      $��28 �6   �� 5      $	��796 �6   �� 5      $	��154 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5!   
   �� 
�������$	��630��6$   $��4��62   $��1��6B   $��7��6O   $��4��6`   $��44,50,111,0q�6t    �� CornerRadius$ 50��6�   ._�5#      �  5$      �� 5%      $��40 �6'   �� 5&      $	��120 �6'   �� 5'      $��25 �6'   �� 5(      $	��150 �6'   �� 5)      $	��260 �6'   �� 5*      $
��233* �6'   �� 5+      $��40 �6'    5-      �� 5.      $��40 �6$   �� 5/      $��40 �6$   �� 50      $��40 �6$   �� 51      $��40 �6$   �� 52      $	��180 �6$   �� 53      �� 54      $��40 �6$   .+�56      &   System.Windows.Controls.DataGrid  -   5          Name$ HouseInfoTable��56      	   
IsReadOnly	 . $��1��57   H   $��1��6U   
   GridLinesVisibility$	
 All=�6f   $��5��58      $��0,0,0,10q�6(   $��5��6:   5;      5=      �� 5?   
   $G��AИнформания о землевладении | Здания��6   $��4��6?   $��7��6O   $��88,24,357,624q�6\   $��18(�6s   
�������6�   �� 5@   
   -   5         ��Name$ BackBtn��5@      $��
Назад��68   $��1��6H   $��7��6X   
���P��$��10,533,780,115q�6x   $��4��6�   �� 5A   
   -   5        $ CloseButton2��5A      $��7��6'   $��
252,0,83,0q�67   $��0��6L   ���	#FFF04242���	#FFF04242$��X��5B   )   $��10(�5C      $��Segoe UI Black)�6   $
��Auto��5D      $��Center=�6   $
��Bold"�5E       J� RenderTransformOrigin$ 0.333,0.492&�6#   $��45��5F   ,   �� 5G   
   -   5        $ HideButton2��5G      $��7��6&   $��208,0,127,0q�66   $��45��5H      $��0��6   ���	#FF4681FF���	#FF4681FF$	��–��5I   )   $
��Auto��65   $��Segoe UI Black)�5J      $��12(�6-   5K      �� 5L   
   -   5        $ AddBtn��5L      $��Добавить��66   $��1��6I   $��7��6Y   
���P��$��10,50,780,598q�6y   $��4��6�   �� 5M   
   -   5        $ 	DeleteBtn��5M      $��Удалить��6<   $��1��6N   $��7��6^   
���P��$��10,112,780,536q�6~   $��4��6�   �� 5N   
   -   5        $ EditBtn��5N      $��Изменить��68   $��1��6K   $��7��6[   
���P��$��10,177,780,471q�6{   $��4��6�   �� 5O   
   -   5         ��Name$ Error��5O      $��1��6#   $��0,601,777,59q�63   $��7��6I   $��4��6V   
�������6j   5Q      5S      