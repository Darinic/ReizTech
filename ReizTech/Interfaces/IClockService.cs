using ReizTech.Request;
using ReizTech.Response;
using ReizTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReizTech.Interfaces
{
	public interface IClockService
	{
		public TimeResponse GetHourAndMinutes();

		public double CalculateAngleBetweenHourAndMinuteHand(AngleCalculationRequest request);
	}
}
