   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      F BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TaskManager.ViewModelsTaskManager.ViewModels 5      A%clr-namespace:TaskManager.Views.PagesTaskManager.Views.Pages 5      1   +TaskManager.Views.Pages.TaskInformationPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      3vm$clr-namespace:TaskManager.ViewModels     5      7local%clr-namespace:TaskManager.Views.Pages     5      .��5      � $��15q�6     � RowDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ TaskName��5      $��0��6   $��50��61   $��30(�6=   $��Center=�6K   {�6f   �� *IsEnableTitle+��6�   �� *	TaskTitle+ �� UpdateSourceTrigger$ PropertyChanged=�(  "System.Windows.Controls.DatePicker  5   
   $��1��6   $��50��6"   $��30(�6.   $��Center=�6<   {�6W   �� *IsEnableDeadline+   SelectedDate 6~   �� *
Deadline+$ PropertyChanged=�6�   �� 5   
   $��2��6   $��30(�6    �� TextWrapping$
 Wrap=�6-   {�6A   �� *IsEnableDescription+��6k   �� *TaskDescription+$ PropertyChanged=�6�   �� 5   
   $��3��6   $��30(�6   $��0 10 0 0q�6P   $��Center=�6b   {�6-   �� *IsEnableTags+��6�   �� *TagsTextBoxColor+��6�   �� *
TaskTags+$ PropertyChanged=�.��6�   .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5         	EventName$ TextChanged��6!   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 5      �� *CheckTagsForValidCommand+5      .��5   &   5      �� 5    
   -   5        	 ��Name$	 importanceRadioButtons��5    "   $��4��6   $��Center=�6B   $��Center=�6�   
 �� Orientation$
 
Horizontal=�6�   {�6]   �� *IsEnableImportance+.+�5!      	�  	� 	GroupName$ 
Importance��6   $��Center=�61   
���  ��$��30(�6d   $��	Immediate��6�    d� 	IsChecked 6r   �� *IsCheckedImmediate+6�   	� 5"      $ 
Importance��6   $��Center=�61   
��� ���$
��10 0q�6g   $��30(�6u   $��	Important��6�    6�   �� *IsCheckedImportant+6�   	� 5#      $ 
Importance��6   $��Center=�61   
��� � �$��30(�6f   $��	NonUrgent��6�    6t   �� *IsCheckedNonUrgent+6�   5$      � 5%   
   $��5��6   $��70��6    � ColumnDefinitions 5&      �� 5'      �� 5(      �� 5)      �� 5*      .+�5-      �� $��0��6   $	��150��6%   $��50��64   $��20(�6C   $
��Back��6Q   ��6`   �� *BackToMainPageCommand+�� 5.      $��1��6   $	��150��6%   $��50��64   
���  ��$��20(�6T   $��Delete��6b   ��6s   �� *DeleteTaskCommand+�� 5/      $��2��6   $	��150��6'   $��50��66   $��20(�6E   $��Perform again��6S   {�6k   �� *IsEnablePerformAgain+$ PropertyChanged=� 6�   �� *IsCheckedPerformAgain+�� 50      $��3��6   $	��150��6%   $��50��64   $��20(�6C   $��Change��6   
������y�6Q   �� *ChangeButtonVisibility+��6�   �� *ChangeInformationCommand+�� 51      $��3��6   $	��150��6%   $��50��64   $��20(�6C   $
��Save��6}   
������y�6Q   �� *SaveButtonVisibility+��6�   �� *SaveChangesCommand+53      54      55      