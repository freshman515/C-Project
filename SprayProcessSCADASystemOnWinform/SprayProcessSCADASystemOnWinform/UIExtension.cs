using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
namespace SprayProcessSCADASystemOnWinform {
    public static class UIExtension {
        //Action<UIStyleManager>：这个委托接受一个 UIStyleManager 对象，可以用于设置样式或进行样式更新。
        //UIStyleManager：是 SunnyUI 框架中负责管理界面样式的类（通常用于设置应用程序的主题、样式、颜色等）。
        public static Action<UIStyleManager>? SetStyleManager;
    }

    public static class LogExtension {
        public static Action<string, LogLevel>? ShowMessage;
    }
}
