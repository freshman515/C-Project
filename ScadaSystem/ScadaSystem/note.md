## 代码笔记

### 常用名称空间
```xml
  xmlns:vm="clr-namespace:ScadaSystem.ViewModels"
             xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
             xmlns:md="http://materialdesigninxaml.net/winfx/xaml/themes"
             d:DataContext="{d:DesignInstance vm:LoginViewModel}"
             Background="{DynamicResource MaterialDesign.Brush.Background}"
             FontFamily="Microsoft YaHei"
             FontSize="16"
             TextElement.FontSize="16"
             TextElement.FontWeight="Regular"
             TextElement.Foreground="{DynamicResource MaterialDesignBody}"
```

### wpf 渐变色代码
```
 <Border Grid.Row="0">
     <Border.Background>
         <LinearGradientBrush  StartPoint="0,0"
                               EndPoint="0,1">
             <GradientStop Offset="0.0"
                           Color="#47a0ff" />
             <GradientStop Offset="0.5"
                           Color="#7fb3d3" />
             <GradientStop Offset="1.0"
                           Color="#ffffff" />
         </LinearGradientBrush>
     </Border.Background>
 </Border>
 ```

 ### 图标和文字代码
 ```xml 
 <StackPanel Grid.Row="0" HorizontalAlignment="Center" Margin="10" Orientation="Horizontal">
                <md:PackIcon Width="50"
                             Height="50"
                             Margin="5"
                             VerticalAlignment="Center"
                             Foreground="#1b2755"
                             Kind="ChartScatterPlot" />
                <TextBlock VerticalAlignment="Center"
                HorizontalAlignment="Center"
                           FontSize="40"
                           Style="{StaticResource MaterialDesignTitleSmallTextBlock}"
                           Text="喷涂工艺系统" />
            </StackPanel>
 ```
### 登录导航

<details>
<summary>点击展开代码</summary>

#### 定义消息类
```csharp
public class LoginMessage : ValueChangedMessage<UserEntity>
{
    public LoginMessage(UserEntity value) : base(value)
    {
    }
}
```
#### 发送消息
```csharp
   WeakReferenceMessenger.Default.Send(new LoginMessage(user));
```
#### xaml.cs 文件接收消息
```csharp
    WeakReferenceMessenger.Default.Register<LoginMessage>(this, (sender, arg) => {
                Container.Content = App.Services.GetService<MainView>();
                Width = 1200;
                Height = 800;
                //设置弹出的坐标位置
                SetWindowLocation();
            });

```
</details>

## ListView使用
```xml
   <ListView Grid.Row="1" ItemsSource="{Binding UserList}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="序号" DisplayMemberBinding="{Binding Id}" />
                    <GridViewColumn Header="用户名" DisplayMemberBinding="{Binding Username}" />
                    <GridViewColumn Header="角色" >
                        <GridViewColumn.DisplayMemberBinding>
                            <Binding Path="Role" Converter="{StaticResource RoleToTextConverter}" />
                        </GridViewColumn.DisplayMemberBinding> 
                    </GridViewColumn>
                    <GridViewColumn Header="创建时间" DisplayMemberBinding="{Binding CreateTime}" />
                    <GridViewColumn Header="更新时间" DisplayMemberBinding="{Binding UpdateTime}" />
                </GridView>
            </ListView.View>
        </ListView>
```

### 弹出对话框的实现
<details>
<Summary>点击展开代码</Summary>

### view端
```xml
  <StackPanel>
        <TextBlock
            Margin="0,10"
            HorizontalAlignment="Center"
            FontSize="24"
            Text="用户信息" />
        <TextBox
            Width="300"
            Margin="8"
            md:HintAssist.Hint="用户名"
            Text="{Binding Entity.Username, UpdateSourceTrigger=PropertyChanged}" />
        <TextBox
            Width="300"
            Margin="8"
            md:HintAssist.Hint="密码"
            Text="{Binding Entity.Password, UpdateSourceTrigger=PropertyChanged}" />
        <TextBox
            Width="300"
            Margin="8"
            md:HintAssist.Hint="角色"
            Text="{Binding Entity.Role, UpdateSourceTrigger=PropertyChanged}" />
        <StackPanel
            Width="300"
            Margin="0,8,0,0"
            Orientation="Horizontal">
            <Button
                Width="120"
                Command="{x:Static md:DialogHost.CloseDialogCommand}"
                CommandParameter="{x:Static helper:Constant.TRUE}"
                Content="确定" />
            <Rectangle Width="60" />
            <Button
                Width="120"
                Command="{x:Static md:DialogHost.CloseDialogCommand}"
                CommandParameter="{x:Static helper:Constant.FALSE}"
                Content="取消" />
        </StackPanel>
    </StackPanel>

    重要的地方： Command="{x:Static md:DialogHost.CloseDialogCommand}"
                CommandParameter="{x:Static helper:Constant.TRUE}"
  Text="{Binding Entity.Password, UpdateSourceTrigger=PropertyChanged}" />
```
### ViewModel
view所绑定的viewmodel，注意，绑定代码是在程序运行中实现的
```csharp
 public class UpdateViewModel<T> : ObservableObject where T : class {
        public T Entity { get; set; }
        public UpdateViewModel(T entity) {
            Entity = entity;
        }
    }
```

### 创建对话框，绑定viewmodel代码：
```csharp
   var Entity = new UserEntity();
   var view = new UserOperateView { DataContext = new UpdateViewModel<UserEntity>(Entity)};
   var res = (bool)await DialogHost.Show(view, "ShellDialog");
```
###  ShellDialog 是主界面的
```xml
  
 <md:DialogHost Identifier="ShellDialog">
        <ContentControl x:Name="Container"/>
    </md:DialogHost>
```
</details>
