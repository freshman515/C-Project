   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MyToDo.ViewModels.DialogsMyToDo.ViewModels.Dialogs  &     MyToDo.Views.Dialogs.AddToDoView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  3local'clr-namespace:MyToDo.ViewModels.Dialogs  $
�� 280��$	��450��.���   � RowDefinitions  �� $
��auto ��� �� $
��auto �.+��� $��0��$��添加待办��$��20,10q�$	�� 20(�$
��Bold"�]� $��1��$��False��.+���  �� Orientation$ 
Horizontal=�$	��Top=�$��20,10q�.+��� $��	状态：����  �� SelectedIndex �� *Model.Status+.@��� .��待办�� .��	已完成�� $
��20,5q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入待办概要�� �� AcceptsReturn$
 True�� �� TextWrapping$
 Wrap=�$	��Top=����� *Model.Title+�� $��20,15,10,15q�$
 True��$��60��$
 Wrap=�$ 请输入待办内容��$	��Top=����� *Model.Content+�� $��Bottom=�$��0,0,0,10q�$ 
Horizontal=�$��Right=�.+��� $��取消�� %  !MaterialDesignOutlinedLightButton#��[  $
��20,5q����� *CancelCommand+�� $��保存��$
��20,5q����� *SaveCommand+