   M S B A M L   `   `   `  ����F  BScadaSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ScadaSystem.ConverterScadaSystem.Converter  5      5clr-namespace:ScadaSystem.ViewsScadaSystem.Views  5      ?$clr-namespace:ScadaSystem.ViewModelsScadaSystem.ViewModels  5
           ScadaSystem.Views.UserView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2cv#clr-namespace:ScadaSystem.Converter     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      +localclr-namespace:ScadaSystem.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      c _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a<md1http://materialdesigninxaml.net/winfx/xaml/themes   5	      /vm$clr-namespace:ScadaSystem.ViewModels   5
       #  MaterialDesign.Brush.Background#���   5      $��Microsoft YaHei)�5      $��16(�5      $��16(�5      $��Regular"�5        MaterialDesignBody#���  5      *  $Microsoft.Xaml.Behaviors.Interaction    Triggers  5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *LoadCommand+5       � 	Resources 5      /  )ScadaSystem.Converter.RoleToTextConverter  RoleToTextConverter��%   &	         5   
   6!   5      .��5      �  � RowDefinitions 5   
   �� 5       $��50 �6   �� 5!      $
��auto �6   .+�5#   
   �� $��0��6   $��Center=�5$      $��Center=�5%       �� Orientation$ 
Horizontal=�5&      .+�5'      �� $	��100��6   $��0,0,10,0q�5(      $��查询用户��5*        ButtonStyle#��[ 5+      ��5)      �� *SearchCommand+5+      �� 5,      $	��100��6   $��添加用户��5.      #��[ 5/      ��5-      �� *
AddCommand+5/      50      �� 51   
   $��1��6   ��52      �� *
UserList+ �� View 53      �� 54      .P�55      �� $��序号��56   %    �� DisplayMemberBinding 55   %   �� *Id+56   %   �� 57      $��	用户名��58   %    57   %   �� *
Username+58   %   �� 59      $��角色��6%    5:      �� 5;      	 �� 	Converter#	 [ 6&   
 �� Path$

 Role�5<   &   5>      �� 5?      $��创建时间��5@   %    5?   %   �� *
CreateTime+5@   %   �� 5A      $��更新时间��5B   %    5A   %   �� *
UpdateTime+5B   %   �� 5C      $��操作��6%    �� CellTemplate 5D      �� 5E      .R�5F   "   �� $ 
Horizontal=�6-   .+�5G   &   �� $
��10,0q�60     TextBlockStyle#��[ 5H   0   $��删除��5I   0     5J   *     5K   .   $ PreviewMouseUp��6=   . 5L   2      6H   ��  �� RelativeSource ��  �� AncestorType UserControl �� Mode$ FindAncestor=�$
 DataContext.DeleteCommand�   CommandParameter 5M   H   �� 5N   /   5P   '   �� 5Q   &   #��[ 60   $��修改��5R   0     5S   *     5T   .   $ PreviewMouseUp��6=   . 5U   2      6H   ��  ��  UserControl$ FindAncestor=�$
 DataContext.ModifyCommand� 5V   H   �� 5W   /   5Y   '   5[   #   5\      5^      5_      5a      5b      5c      