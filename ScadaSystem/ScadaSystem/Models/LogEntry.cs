using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Models {
    public class LogEntry :BaseEntity{
        
        private DateTime timeStamp;

        public DateTime TimeStamp {
            get => timeStamp;
            set { SetProperty(ref timeStamp, value); }
        }
        private string  level;

        public string Level {
            get => level;
            set { SetProperty(ref level, value); }
        }
        private string logger;

        public string Logger {
            get => logger;
            set { SetProperty(ref logger, value); }
        }
        private string   message;

        public string Message {
            get => message;
            set { SetProperty(ref message, value); }
        }
        public static LogEntry Parse(string line) {
            try {
                var parts = line.Split('|');
                if (parts.Length >= 4) {
                    return new LogEntry() {
                        TimeStamp = DateTime.Parse(parts[0]),
                        Level = parts[1],
                        Logger = parts[2],
                        Message = parts[3]
                    };
                }
                return null;
            } catch (Exception e) {
                Debug.WriteLine(e);
            }
            return null;
        }
    }
}
