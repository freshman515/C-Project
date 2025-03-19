using CommunityToolkit.Mvvm.ComponentModel;
using ScadaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Services {
    public class UserSession : ObservableObject {
	private UserEntity user = new UserEntity { Username = "test", Password = "test", Role = 1 };

	public UserEntity CurrentUser {
	    get => user;
	    set {SetProperty(ref user, value); }
	}

    }
}
