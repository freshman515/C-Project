using CommunityToolkit.Mvvm.ComponentModel;
using ScadaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Helper.Dtos {
    public class UserAddDto  {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
