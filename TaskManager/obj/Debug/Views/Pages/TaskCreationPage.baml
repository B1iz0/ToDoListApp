   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      F BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TaskManager.Views.PagesTaskManager.Views.Pages 5      .   (TaskManager.Views.Pages.TaskCreationPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      9system&clr-namespace:System;assembly=mscorlib     5      7local%clr-namespace:TaskManager.Views.Pages     5      .��5      � $��15q�6     � RowDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ TaskName��5   2   $��10 0 0 0q�6   $��0��6%   $��50��6D   $��30(�6P   $��Center=�6^   ��6�   �� *	TaskTitle+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�   ��5      �� 5       �� 
TargetType" ��6    �� 	Resources 5         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%�   &	        !� 5      $
 Left=�6=   $ Center=�6O   $ Uniform=�6c    5      �� 5   "   $��Enter title...��6(   
�������
�������5   #   5      5      	 �� Triggers	 5       P� 5!      
 P� Property
 � �� �� Empty P� Value# Z 62   . �5"      ��  �� Property � �� �� Value# [  6;   5#      P� 5$      
 � �� 62   Z� . �5%      ��  � ��# [  6;   5&      5(      .��5)      5*      (  "System.Windows.Controls.DatePicker  5+   
   $��1��6   $��50��6"   $��30(�6.   $��Center=�6<      SelectedDate 6W   �� *TaskDeadline+$ PropertyChanged=�6�   �� 5,   
   $��2��6   $��10 0 0 0q�6   $��30(�62    �� TextWrapping$
 Wrap=�6@   ��6T   �� *TaskDescription+$ PropertyChanged=��� 5-   
   $��3��6   $��10 0 0 0q�6   $��30(�62   $��0 10 0 0q�6@   $��Center=�6R   ��6t   �� *TagsTextBoxColor+��6�   �� *
TaskTags+$ PropertyChanged=�.��6�   .   (System.Windows.Interactivity.Interaction   Triggers 5.      /   )System.Windows.Interactivity.EventTrigger  5/         	EventName$ TextChanged��6!   .   (System.Windows.Interactivity.TriggerBase   Actions. 50      6   0System.Windows.Interactivity.InvokeCommandAction     Command 51      �� *CheckTagsForValidCommand+52      .��53   &   ��54      �� 55      " ��6    56      ��%�   &	        !� 57      $
 Left=�6=   $ Center=�6O   $ Uniform=�6c    58      �� 59   "   $��Enter tags...��6(   
�������
�������5:   #   5<      5=      	 5>      P� 5?      
 � ��# Z 62   . �5@      ��  � ��# [  6;   5A      P� 5B      
 � �� 62   Z� . �5C      ��  � ��# [  6;   5D      5F      .��5G      5H      �� 5I   
   -   5         ��Name$ importanceRadioButtons��5I   "   $��4��6   $��Center=�6B   $��Center=�6]    �� Orientation$ 
Horizontal=�6z   .+�5J      	�  	� 	GroupName$ 
Importance��6   $��Center=�61   $��	Immediate��6�   
���  ��$��30(�6�    d� 	IsChecked$
 TrueY�6�   $��	Immediate��6�   ��6S   �� *RadioButtonCheckedCommand+6�   	� 5K      $ 
Importance��6   $��Center=�61   $��	Important��6�   
��� ���$
��10 0q�6�   $��30(�6�   $��	Important��6�   ��6S   �� *RadioButtonCheckedCommand+6�   	� 5L      $ 
Importance��6   $��Center=�61   $��	NonUrgent��6�   
��� � �$��30(�6�   $��	NonUrgent��6�   ��6S   �� *RadioButtonCheckedCommand+6�   5M      � 5N   
   $��5��6   $��70��6    � ColumnDefinitions 5O      �� 5P      �� 5Q      .+�5T      �� $��0��6   $	��150��6%   $��50��64   $��20(�6C   $
��Back��6Q   ��6`   �� *BackToMainPageCommand+�� 5U      $��1��6   $	��150��6%   $��50��64   $��20(�6C   
������$��Create��6i   ��6z   �� *CreateNewTaskCommand+5V      5W      5X      