   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyToDoMyToDo  3clr-namespace:MyToDo.ExtensinsMyToDo.Extensins  _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a{Sclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf#MaterialDesignThemes.Wpf.Converters O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem -clr-namespace:MyToDo.CommonMyToDo.Common      MyToDo.Views.MainView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:MyToDo     .extclr-namespace:MyToDo.Extensins     FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  rmaterialDesignConvertersSclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf  3system&clr-namespace:System;assembly=mscorlib  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 &asclr-namespace:MyToDo.Common 	 
   � WindowStyle$
  None=�! 
 Prism.Mvvm.ViewModelLocator   AutoWireViewModel True � AllowsTransparency$
 True�� #  MaterialDesign.Brush.Foreground#���    # MaterialDesign.Brush.Background#���  $��Medium"�$��14(�$��微软雅黑)� � WindowStartupLocation$ CenterScreen=� � Title$ 
MainWindow��$	��618��$
��1100��.��)  #MaterialDesignThemes.Wpf.DialogHost  -     Name$ 
DialogHost��   DialogTheme$ Inherit=�   
Identifier$
 Root��.���� 
�������$��1q� �� CornerRadius$ 10��._�)  #MaterialDesignThemes.Wpf.DrawerHost  -   	  Name$	 
drawerHost��
   IsLeftDrawerOpen
 ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked�   LeftDrawerContent ]� $	��220��.+��� $
��0,20q�$	��Top=�.+��� $��/Images/images.png��$��40��$��40��$��Center=� J� Clip @�  @� Center$ 25,25&� @� RadiusX$ 25Q� @� RadiusY$ 25Q��� $
��0,10q�$��Center=����� *
UserName+�� -    ��Name$ menuBar��  MyListBoxItemStyle#��[ ���� *
MenuBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ SelectionChanged��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *NavigateCommand+   CommandParameter �� *SelectedItem+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType ListBox���� .R��� 
������  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  $
��15,0q�   Kind �� *Icon+�� $
��10,0q����� *Title+.���  � RowDefinitions �� $
��auto ��� .+�'	  !MaterialDesignThemes.Wpf.Snackbar	  -    	 Name$ Snackbar�� K� ZIndex$ 1��  	  MessageQueue  4
  .MaterialDesignThemes.Wpf.MessageQueueExtension
  (  "MaterialDesignThemes.Wpf.ColorZone  -   !  Name$! 	colorZone��$��16q�.  (MaterialDesignThemes.Wpf.ElevationAssist"   	Elevation$	" Dp4=�$	��Top=�#   CornerRadius$# 	10,10,0,0��$   Mode$$ 
PrimaryMid=�.��]� $��False��.+��� $ 
Horizontal=�.+�d� -   % d�Name$% MenuToggleButton��4  .System.Windows.Automation.AutomationProperties&   Name$& HamburgerToggleButton��' d� 	IsChecked$' FalseY� ' #MaterialDesignHamburgerToggleButton#��[ �� $��24,0,0,0q�  MaterialDesignToolButton#��[ ( � ToolTip$( Previous Item��+  %MaterialDesignThemes.Wpf.RippleAssist)   Feedback) ��  �� *Self+$ 
Foreground�=  7MaterialDesignThemes.Wpf.Converters.BrushRoundConverter*   Instance+ �� 	Converter#+ Z* ���� *GoBackCommand+��0  *MaterialDesignThemes.Wpf.PackIconExtension  ,   Kind$, 	ArrowLeft=�-   Size- 24����  �� " �$ (TextElement.Foreground)��� $��16,0,0,0q�#��[ $( 	Next Item��) ��  �� *Self+$ 
Foreground�#+ Z* ���� *GoForwardCommand+��  $, 
ArrowRight=�- 24����  �� " �$ (TextElement.Foreground)��� $
��16,0q�$��Center=�$��Center=�$%& Material Design In XAML Toolkit��$��22(�$��	笔记本���� $ 
Horizontal=�$��Right=�.+��� -   . ��Name$. btnMin�� ! MaterialDesignFlatMidBgButton#��[ ��  $, Minimize=��� -   $. btnMax��#��[ ��  $, Maximize=��� -	   $. btnClose��#��[ ��  $, Close=�'  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�/   ToggleContent/ �� $��/Images/images.png��$��40��$��40��0 � Cursor$0  �� @� $ 20,20&�$ 20Q�$ 20Q�1   PopupContent.1 �� .+��� $��注销账号������ *LoginOutCommand+�� $��1��#  MyToDo.Extensins.PrismManager2   MainViewRegionName! 
 Prism.Regions.RegionManager3   
RegionName#3 Z2 