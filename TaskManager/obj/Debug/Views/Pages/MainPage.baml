   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      F BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TaskManager.ViewModelsTaskManager.ViewModels 5      W0clr-namespace:TaskManager.Infastructure.Commands"TaskManager.Infastructure.Commands 5	      A%clr-namespace:TaskManager.Views.PagesTaskManager.Views.Pages 5
      &    TaskManager.Views.Pages.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9system&clr-namespace:System;assembly=mscorlib     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      3vm$clr-namespace:TaskManager.ViewModels     5      @cmd0clr-namespace:TaskManager.Infastructure.Commands     5	      7local%clr-namespace:TaskManager.Views.Pages     5
        � 	Resources  5       �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value��%�   '��       �� 5   
   " ��6    5      �� 5       6   �� *	IsExpired+ True5      .a�5      ��  � ��
 �  ��63   5      5      5      .��5      � $��25q�6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $
��auto �6   �� 5      $��3* �6   �� 5      $��2* �6   .+�5    
   � $��0��6    � ColumnDefinitions 5!      �� 5"      $��* �6#   �� 5#      $
��auto �6#   .+�5&      �� $��Right=�6   $��Center=�65   	 �� FontSize$	 20(�6P   $��0��6^   .��6n   
Sort by:6x   �� 5'      -   5        $��sortList��5'   �   $��1��6   $��Center=�6'   $	��300��6v   $��10 5 0 5q�6�   $��50��6�   $��20(�6�   
 �� SelectedIndex
 6I   �� *SelectedSortFilter+.@�5(      �� Title6#   �� 5)      
Deadline6&   �� 5*      
Importance6(   5+      5,      � 5-   
   $��1��6    5.      �� 5/      $
��auto �6#   �� 50      $��* �6#   .+�53      �� $��0��6   $��40��6$   $��40��63   $?��9C:\Users\mashk\source\repos\TaskManager\Images\search.png��6A   �� 54      $��1��6   $��9 0 0 0q�6&   $��10 0 0 0q�68   $��30(�6J   $��Center=�6�   ��6X   �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�   ��55      �� 56      " ��6    �� 	Resources 57         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%�   &	        !� 58      $
 Left=�6A   $ Center=�6S   $ Uniform=�6g    59   "   �� 5:   &   $��search by title or tags��6,   
�������
�������5;   '   5=      5>       5?      P� 5@       P� Property � �� �� Empty P� Value# Z 66   . �5A   "   ��  � ��# [  6?   5B      P� 5C       � �� 66   Z� . �5D   "   ��  � ��# [  6?   5E      5G      .��5H   !   5I      5J      �� 5K   
   -   5         ��Name$ Tasks��5K      $��2��6"   $��0 10 0 0q�6/   $��30(�6�    �� SelectedItem 6A   �� *SelectedTask+��6g   �� *TasksCollection+$ PropertyChanged=���5L      �� 5M      .R�5N      ��  �� Orientation$ 
Horizontal=�6!   .+�5O      �� ��6$   �� *Title+�� 5P      $��20 0 0 0q�6$   $��20(�66   $��Center=�6D   ��6_   �� *DeadlineFormater+5Q      5R      5T      �� 5U   
   $
��Left=�6   $��3��60   $��Center=�6=   $	��5 5q�6X   $	 20(�6e   .��6s   Perfomed tasks:6�   �� 5V   
   -   5         ��Name$ PerfomedTasks��5V      $��4��6)   $��0 10 0 0q�66   $��30(�6H    6V   �� *SelectedPerfomedTask+��6�   �� *PerfomedTasks+$ PropertyChanged=���5W      �� 5X      .R�5Y      �� 
��� � �$��Strikethrough{�6J   ��63   �� *Title+6J   5Z      5\      � 5]   
   $��5��6    5^      �� 5_      $��1* �6#   �� 5`      $��1* �6#   .+�5c      �� $��0��6   $	��150��6%   $��50��64   $��20(�6C   $��Perform��6Q   
������$
��Left=�6{   y�6�   �� *IsVisiblePerform+��6�   �� *ToPerformTaskCommand+�� 5d      $��2��6    �� CornerRadius$ 15��6%   $��75��67   $��75��6C   $��Right=�6N   ._�5e      �� $��60��6   $��60��6%   $��0q�60   
�������
���������6l   �� *ToCreateTaskCommand+.��5f      �� $<��6C:\Users\mashk\source\repos\TaskManager\Images\add.png��6   $��57��6\   $��57��6h   5g      5h      5i      5j      5k      