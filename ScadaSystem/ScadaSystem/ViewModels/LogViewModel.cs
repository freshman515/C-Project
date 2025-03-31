using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Masuit.Tools.Reflection;
using ScadaSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.ViewModels {
    public partial class LogViewModel : ObservableObject, IInjectable {
        [ObservableProperty]
        ObservableCollection<FileInfo> logFiles = new();


        [ObservableProperty]
        ObservableCollection<LogEntry> logEntries = new();

        [ObservableProperty]
        FileInfo selectedLogFile;
        partial void OnSelectedLogFileChanged(FileInfo value) {
            if (value == null) {
                return;
            }
            LogEntries.Clear();
            try {
               var lines = File.ReadAllLines(value.FullName);
                foreach (var line in lines) {
                    LogEntries.Add(LogEntry.Parse(line));
                }
            } catch (Exception e) {
                
                throw;
            }
        }

        [RelayCommand]
        void OpenLogFolder() {
            //打开文件夹

            try {
                LogFiles.Clear();

                var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                if (!Directory.Exists(logPath)) {
                    return;
                }
                var currentData = DateTime.Now;
                var oneWeekAgoData = currentData.AddDays(-30);

                //得到所有文件夹,并转换为DirectoryInfo的集和
                //where是为了筛选可以成功转换为DateTime类型的文件夹名词，比如2025-3-21就可以成功转换，而系统报错日志.log就不行，当然也得不到文件，只能得到文件夹
                //Select这一部分代码将筛选后的路径转换为 DirectoryInfo 对象。
                //new DirectoryInfo(dir) 创建一个 DirectoryInfo 实例，使其更易于访问目录的详细信息（如创建时间、大小等）。
                var dataFolders = Directory.GetDirectories(logPath)
                    .Where(dir => DateTime.TryParse(Path.GetFileName(dir), out _))
                    .Select(dir => new DirectoryInfo(dir));

                //筛选日期
                var recentFolders = dataFolders.Where(dir => {
                    if (DateTime.TryParse(dir.Name, out var data)) {
                        return data >= oneWeekAgoData && data <= currentData;
                    }
                    return false;
                });

                //获取满足日期的文件夹下的所有日志   所有*.log 文件并遍历所有子文件夹
                //SelectMany 的作用是扁平化数据 每个 DirectoryInfo 可能返回多个.log 文件，我们希望最终得到一个 FileInfo 列表。
                var logfiles = recentFolders.SelectMany(dir => dir.GetFiles("*.log", SearchOption.AllDirectories))
                    .OrderByDescending(file => file.LastWriteTime);
                LogFiles = new ObservableCollection<FileInfo>(logfiles);

            } catch (Exception e) {

                throw;
            }
        }
    }
}
