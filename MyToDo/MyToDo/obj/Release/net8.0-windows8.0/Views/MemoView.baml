   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyToDo.ViewsMyToDo.Views  C&clr-namespace:MyToDo.Common.ConvertersMyToDo.Common.Converters      MyToDo.Views.MemoView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  :d2http://schemas.microsoft.com/expression/blend/2008  &localclr-namespace:MyToDo.Views  _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  /cv&clr-namespace:MyToDo.Common.Converters    � 	Resources  7   1MyToDo.Common.Converters.IntToVisibilityConverter   IntToVisibility��%   &	          .��)  #MaterialDesignThemes.Wpf.DialogHost  .��)  #MaterialDesignThemes.Wpf.DrawerHost     IsRightDrawerOpen �� *IsRightDrawerOpen+   RightDrawerContent ]� $	��300��$��	15,15,0,0q�$��False��.+��� $��添加备忘录��$��20(�$
��Bold"�$	��Top=��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入备忘录概要��$��0,10,0,0q�$	��Top=����� *CurrentDto.Title+�� $ 请输入备忘录内容��$��0,10,0,0q�$	��Top=����� *CurrentDto.Content+�� $��添加到备忘录��$��保存��$	��Top=����� *ExecuteCommand+.���  � RowDefinitions �� $
��Auto ��� .+��� $
��10,0q� �� Orientation$ 
Horizontal=�.+��� $	��250��$��Center=�$ 查找备忘录��.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True������ *
SearchText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��	 J� InputBindings	 �� 

 �� Key$
 Enter�� �� CommandParameter$ 查询�� �� Command �� *ExecuteCommand+.���� $��+ 添加备忘录��$��新增��$��Right=�$
��10,5q����� *ExecuteCommand+�� $��1��$
��0,10q�$��Center=�y��� *MemoDtos.Count+ �� 	Converter# [  .+��� $��/Images/wind.png��$	��120��$	��120���� $
��0,10q�$��Center=�$4��.暂无任何备忘录，尝试添加一些吧~��$��24(��� $��1��.���� $��Center=����� *
MemoDtos+���� .R�� ���� .R�?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension     Kind$ ExpandIn=�.��� $	��220��$	��180��$��8q�$	��250��*	  $Microsoft.Xaml.Behaviors.Interaction 	  Triggers +
  %Microsoft.Xaml.Behaviors.EventTrigger
   
  	EventName$ MouseLeftButtonUp��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *DataContext.SelectedCommand+ �� RelativeSource ��  �� AncestorType ItemsControl   CommandParameter �� ����  �� 
TargetType" � �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� Property �@J�Effect �� Value 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ #DDDDDD��   ShadowDepth$ 1Q�    Opacity$  1Q� �� $
��Auto ��� .+��� ! �� CornerRadius$! 3�����#66CCFF$��2���� $
��10,5q�$
��Bold"����� *Title+�� $
��10,5q�$��1������ *	Content+�� $
}�True��$��2��.+��� 
" �� Top$" 15��# �� Right$	# -50��$	! 100��$	��120��$	��120�����#ffffff$ J� Opacity$	$ 0.1Q��� $" 80��$	! 100��$	# -30��$	��120��$	��120�����#ffffff$	$ 0.1Q�'  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�%   PopupContent.% �� $��删除������ *DataContext.DeletedCommand+ ��  ItemsControl���� 