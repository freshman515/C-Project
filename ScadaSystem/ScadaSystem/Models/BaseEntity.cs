using CommunityToolkit.Mvvm.ComponentModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Models {
    public class BaseEntity:ObservableObject {
	private int id;

	[SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
	public int Id {
	    get => id;
	    set { SetProperty(ref id,value); }
	}

	private DateTime createTime = DateTime.Now;

	public DateTime CreateTime {
	    get => createTime;
	    set { SetProperty(ref createTime, value); }
	}

	private DateTime updateTime = DateTime.Now;

	public DateTime UpdateTime {
	    get => updateTime;
	    set { SetProperty(ref updateTime, value); }
	}


    }
}
