using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReizTech.Response
{
	public class TimeResponse
	{
		public int Hour { get; set; }

		public int Minutes { get; set; }

		public TimeResponse(int hour, int minutes)
		{
			Hour = hour;
			Minutes = minutes;
		}
	}
}
