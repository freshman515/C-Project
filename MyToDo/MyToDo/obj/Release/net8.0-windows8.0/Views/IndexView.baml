   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyToDo.ViewsMyToDo.Views  _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a{Sclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf#MaterialDesignThemes.Wpf.Converters C&clr-namespace:MyToDo.Common.ConvertersMyToDo.Common.Converters      MyToDo.Views.IndexView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:MyToDo.Views     FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  rmaterialDesignConvertersSclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  /cv&clr-namespace:MyToDo.Common.Converters    � 	Resources  1   +MyToDo.Common.Converters.IntToBoolConverter   intToBoolConverter��%   &	          .���  � RowDefinitions �� $
��Auto ��� $
��auto ��� .+���  �� Orientation$ 
Horizontal=�.+��� $��12q�$��24(����� *Title+�� $��1������ *
TaskBars+���� .R�A�  A� Columns$ 4������ .R�?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension     Kind$ ExpandIn=�.����  �� CornerRadius$ 20��$��10q����� *Color+ J� InputBindings d�  d� MouseAction$ 	LeftClicke�	 �� Command	 �� *DataContext.NavigateCommand+
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType ItemsControl �� CommandParameter �� ����  �� 
TargetType" �� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� Property �@J�Effect �� Value 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ #DDDDDD��   ShadowDepth$ 1Q�   
BlurRadius$ 10Q�   Opacity$ 1Q�._�� .+��� $��20,10q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��$
��15,0q�   Kind �� *Icon+�� $
��15,0q�$��15(�$
��Bold"����� *Title+�� $
��Bold"�$
��15,0q�$��40(����� *	Content+�� $
}�True��.+��� 
 �� Top$ 15�� �� Right$	 -50��$	 100��$	��120��$	��120�����#ffffff J� Opacity$	 0.1Q��� $ 80��$	 100��$	 -30��$	��120��$	��120�����#ffffff$	 0.1Q�� $��2��$
��0,10q� � ColumnDefinitions �� �� .+�]� $
��15,0q�$��0��.+�]� $��15,5,0,0q�$	��Top=�$��False��.+��� $��待办事项��$��20(�$
��Bold"��� $��30��$��新增待办��$��30�� & "MaterialDesignFloatingActionButton#��[ $��0,0,15,0q�$��Right=�$	��Top=����� *ExecuteCommand+.��  $	 Add=�     $ ExpandIn=�.���� -    ��Name$ todoList��$��Stretch=�$��Hidden=����� *Summary.ToDoList+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseDoubleClick��*	  $Microsoft.Xaml.Behaviors.TriggerBase  	  Actions.  2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
  ! 
  Command! �� *EditToDoCommand+" 
  CommandParameter" �� # �� ElementName$# todoList��$ �� Path$$ SelectedItem����� .R�]� $��80��$��False��.+��� .+��� $��16(�$
��Bold"����� *Title+�� $	��0,5q�$	 0.5Q����� *	Content+d� $��Right=� $  MaterialDesignActionToggleButton#��[ ���� *" DataContext.ToDoCompletedCommand+
 �� $ FindAncestor=� ItemsControl���� % d� 	IsChecked% �� *Status+& �� 	Converter#& [  ]� $
��15,0q�$��1��.+�]� $��15,5,0,0q�$	��Top=�$��False��.+��� $��	备忘录��$��20(�$
��Bold"��� $��30��$��30��#��[ $��0,0,15,0q�$��新增备忘录��$��Right=�$	��Top=����� *ExecuteCommand+.��  $	 Add=�     $ ExpandIn=�.���� -   $ memoList��$��Hidden=����� *Summary.MemoList+   $ MouseDoubleClick��.  
  ! �� *EditMemoCommand+" �� $# memoList��$$ SelectedItem����� .R��� $��60��.+��� $��16(�$
��Bold"����� *Title+�� $	��0,5q�$	 0.5Q����� *	Content+�� $ 5��$
��10,0q����#BEBEBE$	 0.1Q�' K� ZIndex$' -1���� $��1��$ 5��$
��10,0q����#BEBEBE$	 0.1Q�$' -1��