   M S B A M L   `   `   `  ����A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyToDo.ViewsMyToDo.Views  5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a{Sclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf#MaterialDesignThemes.Wpf.Converters 5      C&clr-namespace:MyToDo.Common.ConvertersMyToDo.Common.Converters  5
          MyToDo.Views.IndexView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MyToDo.Views     5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      rmaterialDesignConvertersSclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	      /cv&clr-namespace:MyToDo.Common.Converters  5
        � 	Resources  5      1   +MyToDo.Common.Converters.IntToBoolConverter   intToBoolConverter��%   &	          5   
   6    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��12q�5      $��24(�5      ��5      �� *Title+5      5      �� 5   
   $��1��6   ��5      �� *
TaskBars+��5       �� 5"      .R�5#      A�  A� Columns$ 4��6"   5%      ��5(      �� 5*      .R�5+      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6:   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension     Kind$ ExpandIn=�.��5-      ��  �� CornerRadius$ 20��5.   !   $��10q�5/   !   ��5-   !   �� *Color+ J� InputBindings 50      d� 51   "    d� MouseAction$ 	LeftClicke�6/   	 �� Command	 52   /   �� *DataContext.NavigateCommand+
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType ItemsControl �� CommandParameter 53   /   �� ��55      �� 56   "    �� 
TargetType" ��6(    �� Triggers 57   &   P� 58   *    P� Property �@J�IsMouseOver P� Value$
 True��59   2   . �5:   .   ��  �� Property �@J�Effect �� Value 5;   2   3  -System.Windows.Media.Effects.DropShadowEffect  5<   6      Color$ #DDDDDD��6G      ShadowDepth$ 1Q�5=   G      
BlurRadius$ 10Q�5>   G      Opacity$ 1Q�5?   G   5A   /   5B   +   5D   #   ._�5F      � .+�5G   "   �� $��20,10q�6-   .+�5H   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5I   >   $��30��5J   >   $
��15,0q�5K   >      Kind 5H   >   �� *Icon+5K   >   �� 5L   &   $
��15,0q�5M   0   $��15(�5N   0   $
��Bold"�5O   0   ��5L   0   �� *Title+5O   0   �� 5P   &   $
��Bold"�5Q   0   $
��15,0q�5R   0   $��40(�5S   0   ��5P   0   �� *	Content+5S   0   5T   #   �� 5U   "   $
}�True��6)   .+�5V   &   �� 
 �� Top$ 15��6-    �� Right$	 -50��5W   -   $	 100��5X   -   $	��120��5Y   -   $	��120��5Z   -   ���#ffffff J� Opacity$	 0.1Q�5\   -   5]   '   �� 5^   &   $ 80��6-   $	 100��5_   -   $	 -30��5`   -   $	��120��5a   -   $	��120��5b   -   ���#ffffff$	 0.1Q�5d   -   5e   '   5f   #   5h      5i      5j      5k      5m      � 5p   
   $��2��6   $
��0,10q�5q       � ColumnDefinitions 5s      �� 5t      �� 5u      .+�5x      ]� $
��15,0q�6   $��0��5y      .+�5z      ]� $��15,5,0,0q�6   $	��Top=�5{      $��False��5|      .+�5}      �� $��待办事项��6    $��20(�5~       $
��Bold"�5       �� 5�      $��30��6   $��新增待办��5�      $��30��5�       & "MaterialDesignFloatingActionButton#��[ 5�      $��0,0,15,0q�5�      $��Right=�5�      $	��Top=�5�      ��5�      �� *ExecuteCommand+.��5�        $	 Add=�62   5�      5�        5�       66     $ ExpandIn=�.��5�      �� -   5         ��Name$ todoList��5�      $��Stretch=�5�      $��Hidden=�5�      ��5�      �� *Summary.ToDoList+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�      +  %Microsoft.Xaml.Behaviors.EventTrigger  5�         	EventName$ MouseDoubleClick��6-   *	  $Microsoft.Xaml.Behaviors.TriggerBase  	  Actions.  5�   "   2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
  ! 
  Command! 68   �� *EditToDoCommand+" 
  CommandParameter" 5�   8   �� # �� ElementName$# todoList��$ �� Path$$ SelectedItem�5�      ��5�      �� 5�      .R�5�   "   ]� $��80��6,   $��False��5�   ,   .+�5�   &   �� .+�5�   *   �� $��16(�5�   4   $
��Bold"�5�   4   ��5�   4   �� *Title+5�   4   �� 5�   *   $	��0,5q�5�   4   $	 0.5Q�5�   4   ��5�   4   �� *	Content+5�   4   5�   '   d� 5�   &   $��Right=�63    $  MaterialDesignActionToggleButton#��[ 5�   3   ��5�   3   �� *" DataContext.ToDoCompletedCommand+
 �� $ FindAncestor=� ItemsControl��5�   3   �� % d� 	IsChecked% 5�   3   �� *Status+& �� 	Converter#& [  5�   3   5�   #   5�      5�      5�      5�      ]� 5�      $
��15,0q�6   $��1��5�      .+�5�      ]� $��15,5,0,0q�6   $	��Top=�5�      $��False��5�      .+�5�      �� $��	备忘录��6    $��20(�5�       $
��Bold"�5�       �� 5�      $��30��6   $��30��5�      #��[ 5�      $��0,0,15,0q�5�      $��新增备忘录��5�      $��Right=�5�      $	��Top=�5�      ��5�      �� *ExecuteCommand+.��5�        $	 Add=�62   5�      5�        5�       66     $ ExpandIn=�.��5�      �� -   5        $ memoList��5�      $��Hidden=�5�      ��5�      �� *Summary.MemoList+ 5�        5�      $ MouseDoubleClick��6-   .  5�   "   
  ! 68   �� *EditMemoCommand+" 5�   8   �� $# memoList��$$ SelectedItem�5�      ��5�      �� 5�      .R�5�   "   �� $��60��6-   .+�5�   &   �� $��16(�5�   0   $
��Bold"�5�   0   ��5�   0   �� *Title+5�   0   �� 5�   &   $	��0,5q�5�   0   $	 0.5Q�5�   0   ��5�   0   �� *	Content+5�   0   5�   #   5�      5�      5�      5�      �� 5�      $ 5��6   $
��10,0q�5�      ���#BEBEBE$	 0.1Q�5�      ' K� ZIndex$' -1��5�      �� 5�      $��1��6   $ 5��5�      $
��10,0q�5�      ���#BEBEBE$	 0.1Q�5�      $' -1��5�      5�      5�      5�      