   M S B A M L   `   `   `  ����F  BScadaSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ScadaSystem.ViewsScadaSystem.Views  5      ?$clr-namespace:ScadaSystem.ViewModelsScadaSystem.ViewModels  5	           ScadaSystem.Views.MainView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      +localclr-namespace:ScadaSystem.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      c _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a<md1http://materialdesigninxaml.net/winfx/xaml/themes   5      /vm$clr-namespace:ScadaSystem.ViewModels   5	       #  MaterialDesign.Brush.Background#���   5      $��Microsoft YaHei)�5      $��16(�5      $��16(�5      $��Regular"�5        MaterialDesignBody#���  5      .��5      ]� .+�5   
   ]� ���#546e7a$
��Left=�5      .+�5      �� $	��Top=�6   .+�5      ��   � Cursor$
  Hand��6   $��Disabled=�5       �� SelectedIndex$ 0��5      ��5      �� *MenuEntities+��5      �� 5      .R�5       �� $��0,5,0,5q�6)    �� Orientation$ Vertical=�5!   )   $��Center=�5"   )   $��Center=�5#   )   
������ *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5%   "   +  %Microsoft.Xaml.Behaviors.EventTrigger  5&   &      	EventName$ PreviewMouseUp��65   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5'   *   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6@   ��  �� RelativeSource ��  �� Mode$ FindAncestor=�	 �� AncestorType	 UserControl
 �� Path$#
 DataContext.NavigationCommand�   CommandParameter 5(   @   �� 5)   '   .+�5+   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6.   $��25��5,   .   $	��5,0q�5-   .   $��Center=�5.   .   $��Center=�5/   .   
�������
������    Kind 50   .   �� *Icon+52   .   �� 53   "   $��Center=�6,   $��Center=�54   ,   $	��5,0q�55   ,   $��18(�56   ,    �� TextAlignment$ Center=�57   ,   
������ 
������� % !MaterialDesignTitleSmallTextBlock#��[ 5;   ,   ��59   ,   �� *
MenuName+5;   ,   5>      5?      5A      5B      �� 5C      $��0,5,0,5q�6   $��Bottom=�5D      
������  5F        5G      $ PreviewMouseUp��6%   . 5H         60   �� *ChangeUserCommand+5I      .+�5K        $��25��6   $��25��5L      $	��5,0q�5M      $��Center=�5N      $��Center=�5O      $ 
AccountCog=�5P      
�������
������ 5R      �� 5S      $��Center=�6   $��Center=�5T      $	��5,0q�5U      $��18(�5V      
������ $��切换用户��5X      
�������#��[ 5Z      5[      5\      5^      ]� 5_   
   ]� 5`   
   .+�5a      �  � RowDefinitions 5b      �� 5c      $	��36* �6$   �� 5d      $
��737* �6$   �� 5e      $
��auto �6$   .+�5g      �� -   5         ��Name$
 Page��5g   !   $��0,0,0,27q�5h   !   $��3��5i   !   �� 5j      $��2��6   ���#cfd8dc$ 
Horizontal=�5l      .+�5m      �� $��0,0,5,0q�6$   
�������$"��[Spray Process Scada System]��5o   $   �� 5p      $��0,0,5,0q�6$   
�������$��当前用户��5r   $   �� 5s      $��0,0,5,0q�6$   
���������5u   $   �� *&$UserSessionProp.CurrentUser.Username+5w      5x      5z      5{      5|      