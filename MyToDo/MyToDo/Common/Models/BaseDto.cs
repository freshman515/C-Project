﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MyToDo.Common.Models
{
    public class BaseDto:BindableBase
    {
	private int id;
        private DateTime createDate;
        private DateTime updateDate;
        public int Id {
	    get { return id; }
	    set { id = value; }
	}



	public DateTime CreateDate{
	    get { return createDate; }
	    set { createDate = value; }
	}



	public DateTime UpdateDate {
	    get { return updateDate; }
	    set { updateDate = value; }
	}


    }
}
