   M S B A M L   `   `   `  ����F  BScadaSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ScadaSystem.ViewsScadaSystem.Views  5      ?$clr-namespace:ScadaSystem.ViewModelsScadaSystem.ViewModels  5
      "    ScadaSystem.Views.DeviceView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      +localclr-namespace:ScadaSystem.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      c _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a<md1http://materialdesigninxaml.net/winfx/xaml/themes   5	      /vm$clr-namespace:ScadaSystem.ViewModels   5
       #  MaterialDesign.Brush.Background#���   5      $��Microsoft YaHei)�5      $��16(�5      $��16(�5      $��Regular"�5      
�������.��5      �   � RowDefinitions  5   
   �� 5      $��40 �6   �� 5      $��4* �6   �� 5      $	��10* �6   .+�5   
   �� ���#034572._�5      �� $��Center=�5      $��30(�5      $��产线总控制��5      5      �� 5   
   $��1��5       
����=H�$��1q�5"      ._�5#      A�  A� Rows$ 1��6   .+�5$      �� $	��200��5%      $	��100��5&      $��10q�5'      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndeterminate$
 True��5(         IsIndicatorVisible$
 True��5)      
���2�2�$��
TotalStart��5,      $��	总启动��5-      $��40(�5.      ��5+      �� *WriteDeviceControlCommand+5.      �� 5/      $	��200��50      $	��100��51      $��10q�52      $
 True��53      $
 True��54      
���  ��$��	TotalStop��57      $��	总停止��58      $��40(�59      ��56      �� *WriteDeviceControlCommand+59      �� 5:      $	��200��5;      $	��100��5<      $��10q�5=      $
 True��5>      $
 True��5?      ���#50a0ff$��MechanicalReset��5B      $��机械复位��5C      $��40(�5D      ��5A      �� *WriteDeviceControlCommand+5D      �� 5E      $	��200��5F      $	��100��5G      $��10q�5H      $
 True��5I      $
 True��5J      ���#febf57$��
AlarmReset��5M      $��报警复位��5N      $��40(�5O      ��5L      �� *WriteDeviceControlCommand+5O      �� 5P      $	��200��5Q      $	��100��5R      $��10q�5S      $
 True��5T      $
 True��5U      ���#414141$��IdleRun��5X      $��空体运行��5Y      $��40(�5Z      ��5W      �� *WriteDeviceControlCommand+5Z      5[      5^      �� 5_   
   $��2��5`      
����=H�$��1q�5b      ._�5c      �  � ColumnDefinitions 5d      �� 5e      �� 5f      .+�5h      �� $��0��5i      
����=H�$��1q�5k      ._�5l      A�  A� Columns$ 1��6"   $ 4��6.   .+�5m      ��  �� Orientation$ 
Horizontal=�6%   .+�5n      �� $��10q�5o   !   $��Stretch=�5p   !   $��Center=�5q   !   $ 
Horizontal=�5r   !   .+�5s   "   �� $��80��5t   %   $��2q�5u   %   $
��Left=�5v   %   $��Center=�5w   %   $��脱脂工位：��5x   %   ���#1b27555y   %   d� 5z   "   $��80��5{   %   $��2q�5|   %    $  MaterialDesignSwitchToggleButton#��[ 5~   %    � ToolTip$ 脱脂工位��5   %    d� 	IsChecked 5}   %   �� **(RootParam.PlcParam.DegreasingStationOpen+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�   &   +  %Microsoft.Xaml.Behaviors.EventTrigger  5�   *      	EventName$ Checked��69   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5�   .   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter$ DegreasingStationOpen��5�   D      Command 5�   D   �� *ToggleCollectionCommand+5�   D   5�   +     5�   *   $ 	Unchecked��69   . 5�   .     $ DegreasingStationClose��5�   D    5�   D   �� *ToggleCollectionCommand+5�   D   5�   +   5�   #   5�      �� 5�      $��60��6(   �� 5�      $��10q�5�   !   $��Stretch=�5�   !   $��Center=�5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� $	��100��5�   %   $��2q�5�   %   $
��Left=�5�   %   $��Center=�5�   %   $��冷却室工位：��5�   %   ���#1b27555�   %   d� 5�   "   $��80��5�   %   $��2q�5�   %   #��[ 5�   %   $ 水分炉工位开关��5�   %    5�   /   �� **(RootParam.PlcParam.CuringOvenStationOpen+$	 TwoWay=�$
 PropertyChanged=� 5�   &     5�   *   $ Checked��69   . 5�   .     $ CoolingRoomStationOpen��5�   D    5�   D   �� *ToggleCollectionCommand+5�   D   5�   +     5�   *   $ 	Unchecked��69   . 5�   .     $ CoolingRoomStationClose��5�   D    5�   D   �� *ToggleCollectionCommand+5�   D   5�   +   5�   #   5�      5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��10q�5�   !   $��Stretch=�5�   !   $��Center=�5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� $��80��5�   %   $��2q�5�   %   $
��Left=�5�   %   $��Center=�5�   %   $��粗洗工位：��5�   %   ���#1b27555�   %   d� 5�   "   $��80��5�   %   $��2q�5�   %   #��[ 5�   %   $ 粗洗工位开关��5�   %    5�   /   �� *,*RootParam.PlcParam.RoughWashingStationOpen+$	 TwoWay=�$
 PropertyChanged=� 5�   &     5�   *   $ Checked��69   . 5�   .     $ RoughWashingStationOpen��5�   D    5�   D   �� *ToggleCollectionCommand+5�   D   5�   +     5�   *   $ 	Unchecked��69   . 5�   .     $ RoughWashingStationClose��5�   D    5�   D   �� *ToggleCollectionCommand+5�   D   5�   +   5�   #   5�      �� 5�      $��60��6(   �� 5�      $��10q�5�   !   $��Stretch=�5�   !   $��Center=�5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� $	��100��5�   %   $��2q�5�   %   $
��Left=�5�   %   $��Center=�5�   %   $��水分炉工位：��5�   %   ���#1b27555�   %   d� 5�   "   $��80��5�   %   $��2q�5�   %   #��[ 5�   %   $ 自动模拟开关��5�   %    5�   /   �� */-RootParam.PlcParam.MoistureFurnaceStationOpen+$	 TwoWay=�$
 PropertyChanged=� 5�   &     5�   *   $ Checked��69   . 5�   .     $  MoistureFurnaceStationOpen��5�   D    5�   D   �� *ToggleCollectionCommand+5�   D   5�   +     5�   *   $ 	Unchecked��69   . 5�   .     $! MoistureFurnaceStationClose��5�   D    5�   D   �� *ToggleCollectionCommand+5�   D   5�   +   5�   #   5�      5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��10q�5�   !   $��Stretch=�5�   !   $��Center=�5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� $��80��5�   %   $��2q�5�   %   $
��Left=�5�   %   $��Center=�5�   %   $��陶化工位：��5�   %   ���#1b27555�   %   d� 5�   "   $��80��5�   %   $��2q�5�   %   #��[ 5�   %   $ 自动采集开关��5�   %    5�   /   �� *.,RootParam.PlcParam.CeramicCoatingStationOpen+$	 TwoWay=�$
 PropertyChanged=� 5   &     5  *   $ Checked��69   . 5  .     $ CeramicCoatingStationOpen��5  D    5  D   �� *ToggleCollectionCommand+5  D   5  +     5  *   $ 	Unchecked��69   . 5  .     $  CeramicCoatingStationClose��5  D    5  D   �� *ToggleCollectionCommand+5  D   5  +   5
  #   5     �� 5     $��60��6(   �� 5     $��10q�5  !   $��Stretch=�5  !   $��Center=�5  !   $ 
Horizontal=�5  !   .+�5  "   �� $	��100��5  %   $��2q�5  %   $
��Left=�5  %   $��Center=�5  %   $��固化炉工位：��5  %   ���#1b27555  %   d� 5  "   $��80��5  %   $��2q�5  %   #��[ 5  %   $ 自动模拟开关��5  %    5  /   �� **(RootParam.PlcParam.CuringOvenStationOpen+$	 TwoWay=�$
 PropertyChanged=� 5  &     5   *   $ Checked��69   . 5!  .     $ CuringOvenStationOpen��5"  D    5!  D   �� *ToggleCollectionCommand+5"  D   5#  +     5$  *   $ 	Unchecked��69   . 5%  .     $ CuringOvenStationClose��5&  D    5%  D   �� *ToggleCollectionCommand+5&  D   5'  +   5)  #   5*     5,     �� 5-     $ 
Horizontal=�6%   .+�5.     �� $��10q�5/  !   $��Stretch=�50  !   $��Center=�51  !   $ 
Horizontal=�52  !   .+�53  "   �� $��80��54  %   $��2q�55  %   $
��Left=�56  %   $��Center=�57  %   $��精洗工位：��58  %   ���#1b275559  %   d� 5:  "   $��80��5;  %   $��2q�5<  %   #��[ 5>  %   $ 自动采集开关��5?  %    5=  /   �� *+)RootParam.PlcParam.FineWashingStationOpen+$	 TwoWay=�$
 PropertyChanged=� 5@  &     5A  *   $ Checked��69   . 5B  .     $ FineWashingStationOpen��5C  D    5B  D   �� *ToggleCollectionCommand+5C  D   5D  +     5E  *   $ 	Unchecked��69   . 5F  .     $ FineWashingStationOpen��5G  D    5F  D   �� *ToggleCollectionCommand+5G  D   5H  +   5J  #   5K     �� 5L     $��60��6(   �� 5M     $��10q�5N  !   $��Stretch=�5O  !   $��Center=�5P  !   $ 
Horizontal=�5Q  !   .+�5R  "   �� $	��100��5S  %   $��2q�5T  %   $
��Left=�5U  %   $��Center=�5V  %   $��输送机工位：��5W  %   ���#1b27555X  %   d� 5Y  "   $��80��5Z  %   $��2q�5[  %   #��[ 5]  %   $ 自动模拟开关��5^  %    5\  /   �� *(&RootParam.PlcParam.ConveyorStationOpen+$	 TwoWay=�$
 PropertyChanged=� 5_  &     5`  *   $ Checked��69   . 5a  .     $ ConveyorStationOpen��5b  D    5a  D   �� *ToggleCollectionCommand+5b  D   5c  +     5d  *   $ 	Unchecked��69   . 5e  .     $ ConveyorStationClose��5f  D    5e  D   �� *ToggleCollectionCommand+5f  D   5g  +   5j  #   5k     5m     5n     5o     �� 5p     $��1��5q     
����=H�$��1q�5s     $��日志文件��5t      5v       5w     $ PreviewMouseDoubleClick��6)   . 5x        64   �� *ClearLogCommand+5y     .��5{     �� $
��auto=�6#   .��5|     �� $��17(�5}     
���   �$
��Wrap=�5�     ��5     �� *
LogContent+$	 TwoWay=�$
 PropertyChanged=�5�     5�     5�     5�     5�     5�     5�     