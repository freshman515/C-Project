   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyToDo.ViewsMyToDo.Views  3clr-namespace:MyToDo.ExtensinsMyToDo.Extensins      MyToDo.Views.LoginView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  :d2http://schemas.microsoft.com/expression/blend/2008  &localclr-namespace:MyToDo.Views  _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 +passclr-namespace:MyToDo.Extensins  	 $	��600��$	��350��# 	 Prism.Services.Dialogs.Dialog    WindowStyle  ��  �� 
TargetType" �.���  �� Property � �� �� Value$	 350����  � ��$	 600����  �@�SizeToContent$ WidthAndHeight=���  �@�
ResizeMode$ NoResize=���  �@ WindowStartupLocation$ CenterScreen=�.��� 
������� � ColumnDefinitions �� $
��1.2* ��� .+��� $��/Images/login.png��$��40q�'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ LoginSnackbar��$��2��$	��Top=� K� ZIndex$ 1��   MessageQueue 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  $��1�� �� SelectedIndex �� *SelectedIndex+.@�<  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  .��]� $��False��$��1��$��Center=�$
��20,0q�.+��� $��欢迎使用��$
��Bold"�$	��Top=�$��30(��� $	��Top=�$��50��$��16(�$
��0,10q�)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 请输入账号������ *LoginUserDto.Account+G� $	��Top=�$��50��$��16(�$
��0,10q�$	 请输入密码��(   "MyToDo.Extensins.PassWordExtension
   PassWord
 �� *LoginUserDto.Password+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors '	   !MyToDo.Extensins.PasswordBehavior	  �� $	��Top=�$��	0,10,0,10q� �� CornerRadius$ 10��._��� $��登录系统��$��Login��$��40������ *ExecuteCommand+����  �� 
TargetType" ��.R��� #��z��#��z��$��1q�$ 10��._��� #��z��#��z��#��z��#��z��]� $	��Top=�$��False��.+��� $��注册账号��
���   �$
��Left=�   Triggers +
  %Microsoft.Xaml.Behaviors.EventTrigger
   
  	EventName$ MouseLeftButtonDown��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter$ Go��   Command �� *ExecuteCommand+�� $��忘记密码��$��Right=�  .��]� $��Center=�$��False��$��15q�.+��� $��注册账号��$
��Bold"�$	��Top=�$��25(��� $	��Top=�$��16(�$
��0,10q�$	 请输入用户名������ *UserDto.Name+�� $	��Top=�$��16(�$
��0,10q�$	 请输入账号������ *UserDto.Account+G� $	��Top=�$��40��$��16(�$	��0,0q�$	 请输入密码��
 �� *UserDto.Password+$ TwoWay=�$ PropertyChanged=� 	  G� $	��Top=�$��40��$��16(�$	��0,0q�$	 请再次输入密码��
 �� *UserDto.NewPassword+$ TwoWay=�$ PropertyChanged=� 	  �� $��注册账号��$
��Left=�$��Register��$	��0,5q�$��40������ *ExecuteCommand+�� $��返回登录��$	��0,5q�$��Right=�$��Return��$��40������ *ExecuteCommand+