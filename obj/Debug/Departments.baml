   M S B A M L   `   `   `  ����A  =alimak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:alimakalimak  5          alimak.Departments   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:alimak     5      .��5	      � -   5        
�������  � RowDefinitions  5
   
   �� 5      $��50 �6   6*   �� 5      $��20 �6   6*   �� 5      6   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6   $��30(�6!    �� TextAlignment$ Center=�6/   
Цехи6L   � 5   
   $��1��6   $
��20 0q�6   
����ح� � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��5* �6#   60   �� 5      $��6* �6#   60   .+�5      �� $��0��6   $��15(�6(   $	��5 0q�66   № цеха6K   �� 5      $��1��6   $��15(�6(   $	��5 0q�66   $��Center=�6C   Начальник6k   �� 5      $��2��6   $��15(�6(   $	��5 0q�66   $��Center=�6C   Работники6k   5      � 5   
   $��2��6   $
��20 0q�6   .+�5      �� -   5         ��Name$ DepContainer��5      
�������$��15(�6C   $��Stretch=�6Q   ��5      �� 5       .R�5!      �  5"      �� 5#   "   $��* �63   6?   �� 5$   "   $��5* �63   6@   �� 5%   "   $��6* �63   6@   .+�5'      �� $��0��6(   $��15(�68   ��6F   �� *IDdep+6`   �� 5(      -   5        $��1��5(   (   $��15(�68   $
��Wrap=�6[   $��Center=�6�   ��6F   �� *FIO+6�   �� 5)      $��2��6&   
�������$��15(�6M    �� DisplayMemberPath$	 FIO��6[   ��6s   �� *
Depworkers+6�   5*      5+      5.      5/      � 50   
   $��3��6   .+�51      �� -   5         ��Name$ AddDepButton��51      $	��300��6+   $��25(�67   
�����p�$y�Hidden=�6x   .��6�   $"Добавить новый цех6�   52      55      56      