   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MyToDo.ViewModels.DialogsMyToDo.ViewModels.Dialogs  &     MyToDo.Views.Dialogs.AddMemoView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9local'clr-namespace:MyToDo.ViewModels.Dialogs     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  $
�� 280��$	��450��.���   � RowDefinitions  �� $
��auto ��� �� $
��auto �.+��� $��0��$��添加备忘录��$��20,10q�$	�� 20(�$
��Bold"�]� $��1��$��False��.+��� $��20,20q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入备忘录概要�� �� AcceptsReturn$
 True�� �� TextWrapping$
 Wrap=�$	��Top=����� *Model.Title+�� $��20,20,10,15q�$
 True��$��60��$
 Wrap=�$ 请输入备忘录内容��$	��Top=����� *Model.Content+�� $��Bottom=�$��0,0,0,10q� �� Orientation$ 
Horizontal=�$��Right=�.+��� $��取消�� %  !MaterialDesignOutlinedLightButton#��[  $
��20,5q����� *CancelCommand+�� $��保存��$
��20,5q����� *SaveCommand+