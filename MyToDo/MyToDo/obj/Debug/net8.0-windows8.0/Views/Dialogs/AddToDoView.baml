   M S B A M L   `   `   `  ����A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MyToDo.ViewModels.DialogsMyToDo.ViewModels.Dialogs  5      &     MyToDo.Views.Dialogs.AddToDoView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      3local'clr-namespace:MyToDo.ViewModels.Dialogs  5      $
�� 280��5	      $	��450��5
      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��添加待办��5      $��20,10q�5      $	�� 20(�5      $
��Bold"�5      ]� 5   
   $��1��6   $��False��5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�5      $��20,10q�5      .+�5      �� $��	状态：��6   �� 5       �� SelectedIndex 6   �� *Model.Status+.@�5      �� .��6#   待办6'   �� 5      .��6#   	已完成6(   5      5       �� 5!      $
��20,5q�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入待办概要��5"       �� AcceptsReturn$
 True��5#       �� TextWrapping$
 Wrap=�5%      $	��Top=�5&      ��5$      �� *Model.Title+5&      �� 5(      $��20,15,10,15q�6   $
 True��5*      $��60��5+      $
 Wrap=�5,      $ 请输入待办内容��5-      $	��Top=�5.      ��5)      �� *Model.Content+5.      �� 5/      $��Bottom=�6   $��0,0,0,10q�50      $ 
Horizontal=�51      $��Right=�52      .+�53      �� $��取消��6    %  !MaterialDesignOutlinedLightButton#��[  55      $
��20,5q�56      ��54      �� *CancelCommand+56      �� 57      $��保存��6   $
��20,5q�59      ��58      �� *SaveCommand+59      5:      5;      5<      5=      