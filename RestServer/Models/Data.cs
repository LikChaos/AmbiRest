using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServer.Models
{
	public class Data
	{
		public Data(string Name, DateTime DateStart, DateTime DateEnd, string URL)
		{
			this.Name = Name;
			this.DateStart = DateStart;
			this.DateEnd = DateEnd;
			this.URL = URL;
		}

		public string Name { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }
		public string URL { get; set; }

	}
}
