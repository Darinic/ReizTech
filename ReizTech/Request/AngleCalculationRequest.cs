using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReizTech.Request
{
	public class AngleCalculationRequest
	{
		[Required]
		public int Hour { get; set; }

		[Required]
		public int Minutes { get; set; }

		public AngleCalculationRequest(int hour, int minutes)
		{
			Hour = hour;
			Minutes = minutes;
		}
	}
}
