   M S B A M L   `   `   `  ����F  BScadaSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ScadaSystem.ViewsScadaSystem.Views  5      ?$clr-namespace:ScadaSystem.ViewModelsScadaSystem.ViewModels  5
          ScadaSystem.Views.LogView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      +localclr-namespace:ScadaSystem.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      c _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a<md1http://materialdesigninxaml.net/winfx/xaml/themes   5	      /vm$clr-namespace:ScadaSystem.ViewModels   5
       #  MaterialDesign.Brush.Background#���   5      $��Microsoft YaHei)�5      $��16(�5      $��16(�5      $��Regular"�5        MaterialDesignBody#���  5      .��5      �   � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   �� $��0��5      ���#546e7a$��1q�5      ._�5      �� .+�5      �� ���#54637a$��16(�5!      
�������$��日志控制台��5#       �� TextAlignment$ Center=�5$      �� 5%      $	��0,5q�5&      $��Stretch=�5'      $��Center=�5(      ���#54647a �� Orientation$ 
Horizontal=�5*      .+�5+      '  !MaterialDesignThemes.Wpf.PackIcon  $��40��5,      $��40��5-      $��5q�5.      $��Center=�5/      $��20(�50      
�������   Kind$ FolderInformation=�52      �� 53      $��Center=�54      $��Center=�55      $��35(�56      
�������$��显示一周日志��58      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 59      +  %Microsoft.Xaml.Behaviors.EventTrigger  5:         	EventName$ MouseLeftButtonDown��6-   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5;   "   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   �� *OpenLogFolderCommand+5<      5>      5?      �� 5B      $��5q�6   .+�5C      �� $
��Auto=�5E      ��5D      �� *
LogFiles+ �� SelectedItem 5F      �� *SelectedLogFile+	 �� View	 5G      �� 5H      .P�5I   "   �� $��	文件名��6W   
 �� DisplayMemberBinding
 61   �� *Name+6W   �� 5J   "   $��修改时间��6`   
 61   �� *LastWriteTime+6`   5K      5M      5N      5O      5Q      �� 5R   
   $��1��5S      ���#546e7a$��1q�5U      ._�5W      ]� .+�5X      �� $	��Top=�5Y      ���#54637a$��16(�5[      
�������$��日志内容��5]      $ Center=�5^      �� 5a      $��5q�6   .+�5b      �� $
��Auto=�6B   ��6   �� *
LogEntries+	 5c      �� 5d      .P�5e   "   ��  �� Width$	 200��5f   %   $��时间��5h   %   
 5g   %   �� *	TimeStamp+5h   %   �� 5i   "   $	 100��5j   %   $��级别��5l   %   
 5k   %   �� *Level+5l   %   �� 5m   "   $	 150��5n   %   $��来源��5p   %   
 5o   %   �� *Logger+5p   %   �� 5q   "   $	 150��5r   %   $��内容��5t   %   
 5s   %   �� *	Message+5t   %   5u      5w      5x      5y      5z      5{      5|      