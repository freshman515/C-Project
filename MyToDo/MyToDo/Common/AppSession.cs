using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace MyToDo.Common {
    public static class AppSession   {
        private static string userName;

	public static  string UserName {
	    get { return userName; }
	    set { userName = value; OnPropertyChanged(); }
	}


	public static event PropertyChangedEventHandler PropertyChanged;

        private static void OnPropertyChanged([CallerMemberName] string propertyName="") {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}
