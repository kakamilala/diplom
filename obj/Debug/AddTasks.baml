   M S B A M L   `   `   `  ����A  =alimak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:alimakalimak  5          alimak.AddTasks   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:alimak     5      .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $��50 �6   6*   �� 5      $��50 �6   6*   �� 5      6   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6   $��30(�6!    �� TextAlignment$ Center=�6/   Добавить задачи6W   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��4* �6#   60   .+�5      �� $��0��6   $��0��6%   $��25(�65   $��10 0 0 0q�6C   Название6_   �� 5      -   5         ��Name$
 name��5      $��0��6&   $��1��63   $��20(�6C   $��	 0 0 10 1q�6Q   6f   5      � 5   
   $��2��6   .+�5      �� -   5         ��Name$ tasks��5      
�������$��10q�6<   5!      5"      � 5$   
   $��3��6    5%      �� 5&      6%   �� 5'      6%   .+�5)      �� -   5         ��Name$ AddTaskButton��5)      $��0��6,   $
��10 5q�6<   $��25(�6J   
�����p�.��6�   Добавить задачу6�   �� 5*      -   5        $ DoneTasksButton��5*      $��1��6.   $
��10 5q�6>   $��25(�6L   
�����p�.��6�   Готово6�   5,      5-      5.      