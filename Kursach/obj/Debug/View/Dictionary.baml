   M S B A M L   `   `   `  ����B  >Kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Kursach.ViewKursach.View  5   	       Kursach.View.Dictionary   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Kursach.View     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Словарь��5	   	   $��437.161��6   $��356.742��6*    � WindowStyle$ 
ToolWindow=�6:   ���	#FF272727.��5
      �  � RowDefinitions 5   
   �� 5      $	��18* �6   �� 5      $	��19* �6   .+�5   
   �� -   5         ��Name$ 	AddButton��5      $��20,20,225,146q�6$   $��Добавить��6;   
���P��$
��Auto��6y   �� 5   
   -   5        $ DeleteButton��5      $��20,67,225,99q�6'   $��Удалить��6=   
���P��$
��Auto��6}   �� 5   
   -   5        $ 
EditButton��5      $��20,114,225,52q�6%   $��Изменить��6<   
���P��$
��Auto��6{   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Table��5         MinColumnWidth$	 185Q�6"      
IsReadOnly .    GridLinesVisibility$	 All=�6J   $��135,20,20,79q�6d   $��2��6z   �� 5   
   -   5        $ CancelButton��5      $��237,154,20,23q�6'   $��Отмена��6>   
���P��$��1��5   ,   $y�Hidden=�69    �� IsCancel . 6M   �� 5   
   -   5        $ OkButton��5      $��172,154,119,23q�6#   $
��Ок��6;   
���P��	 �� 	IsDefault	 . $��1��5   9   $y�Hidden=�6F   �� 5   
   -   5        
 ��Name$
 	EnterText��5      $��20,154,189,23q�6%      MaterialDesignTextBox#��[  6<   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ввод��6k    �� 
CaretBrush
 �P��
�������$��1��5   N   $y�Hidden=�6[   ��6%   Z� 6[   �� 5   
   -   5         ��Name$ Error��5      $�� ��6#   $��1��6+   $��10,135,10,54q�68   
�������{�.  6a   �� 5   
   -	   5        $ SearchButton��5      $��20,162,225,4q�6'   $��
Поиск��6=   
���P��$
��Auto��6{   5      5      