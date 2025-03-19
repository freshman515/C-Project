using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Models {
    [SugarTable("menu")]
    public class MenuEntity :BaseEntity{

	private string menuName;

	public string MenuName {
	    get => menuName;
	    set { SetProperty(ref menuName, value); }
	}

        private string icon;

        public string Icon {
            get => icon;
            set { SetProperty(ref icon, value); }
        }

        private string view;

        public string View {
            get => view;
            set { SetProperty(ref view, value); }
        }

        private int sort;

        public int Sort {
            get => sort;
            set { SetProperty(ref sort, value); }
        }


    }
}
