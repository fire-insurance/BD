   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   B >Kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:KursachKursach 5   	      Kursach.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5   	   !localclr-namespace:Kursach  5   	   $��Segoe UI Light)�5	      $	��720��5
   
   $
��1080��6   ���	#FF272727  � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � Icon$( "/Kursach;component/Assets/logo.png��6D    � WindowStyle$
 None=�6n   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��21 �6   �� 5      $��31 �6   �� 5      $	��796 �6   �� 5      $	��154 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $��* �6   �� 5"      $��20 �6   .+�5%   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	TableView��5%         MaterialDesignDataGrid#��[  6&      
IsReadOnly . $��	50,50,0,0q�5&      $	��900��6&   $��5��62   $��1��6B   $��7��6O      GridLinesVisibility$	 All=�6`   $��2��5'   B   �� 5)   
   $��0��6   $��6��6"   $��
0,0,553,51q�66   $��2��6J   .+�5*      o� $��	0,0,259,0q�6   $��50��6&   $��Center=�62   $	��Top=�6O   ���	#DDFFFFFF��6g   Z� .@�5+      m� $��Словари��6   $	��200��6,   
�������.@�5,      m� -   5        	 m�Name$	 CityS��5,      $��Города��6B   ���	#FF5757576R   m� 5-      -   5        $	 HouseS��5-      $'��!Назначение зданий��6D   ���	#FF5757576_   m� 5.      -   5        $	 RoomS��5.      $-��'Назначение помещений��6B   ���	#FF5757576`   5/      50      52      �� 54   
   -   5        
 ��Name$
 	AddButton��54      $��1��6$   $��1��64   $��Добавить��6A   
���P��$��0,50,0,0q�55   $   
�������$��4��6b   �� 56   
   -   5        $
 DeleteButton��56      $��1��6'   $��2��6R   $��Удалить��6_   
���P��$��0,50,0,0q�6�   
�������$��4��6�   �� 57   
   -   5        $
 UpdateButton��57      $��1��6'   $��3��6R   $��Изменить��6_   
���P��$��	0, 50,0,0q�6�   
�������$��4��6�   �� 58   
   -   5        $
 SearchButton��58       �� 	IsDefault . $��5��68   $��1��6c   $��
Поиск��6p   
���P��$��402,0,302,47q�6�   
�������$
��Auto��6�   �� 59   
   -	   5         ��Name$ 	SearchBox��59        MaterialDesignTextBox#��[ 6%   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��6T   $��5��6{   $��50,0,425,47q�6�   $��1��6�   
�������$��16(�6�   .��6�   ��5:      �� 5;       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5<      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5=      $ Coral��6#   $ 1Q�61   � 5>      $ 	#FE020101��6#   � 5?      $ 	#FF272727��6#   � 5@      $ 	#FF7B4937��6#   $ 0.452Q�65   � 5A      $ 	#FEB66142��6#   $
 0.67Q�65   � 5B      $ 	#FF51382F��6#   $ 0.296Q�65   � 5C      $ 	#FE9A553C��6#   $ 0.609Q�65   5D      .��5E   "   5F      �� 5G   
   -
   5        $
 CloseButton��5G      $��6��6&   $��4��66   $��	129,0,0,0q�6J   $��0��6^   ���	#FFF04242���	#FFF04242$��X��5H   )   $��10(�5I      $��Segoe UI Black)�6   $
��Auto��5J      $��Center=�6   $
��Bold"�5K       J� RenderTransformOrigin$ 0.333,0.492&�6#   5L      �� 5M   
   -   5        $
 
HideButton��5M      $��6��6%   $��	85,0,24,0q�65   $��45��5N      $��0��6   ���	#FF4681FF���	#FF4681FF$	��–��5O   )   $
��Auto��65   $��Segoe UI Black)�5P      $��12(�6-   5Q      �� 5R   
   -   5         ��Name$ Error��5R      $�� ��6#   $��7��6+   $��16(�68   
�������$��5��6Y   $��0,333,751,5q�6m   $��1��6�   $��2��6�   �� 5S   
   -   5        $
 ExportButton��5S       . $��1��68   $��7��6c   $��Экспорт в XML��6p   
���P��$��0,50,759,352q�6�   
�������$��5��6�   5V      5Y      