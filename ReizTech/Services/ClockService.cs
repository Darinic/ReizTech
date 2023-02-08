using ReizTech.Interfaces;
using ReizTech.Request;
using ReizTech.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReizTech.Services
{
	enum TimeRange
	{
		MinHour = 1,
		MaxHour = 12,
		MinMinute = 0,
		MaxMinute = 59
	}



	public class ClockService : IClockService
	{
		private const int MINUTES_PER_HOUR = 60;
		private const int FULL_CIRCLE_DEGREES = 360;
		private const double HOUR_HAND_MULTIPLIER = 0.5;
		private const double MINUTE_HAND_MULTIPLIER = 6;

		public TimeResponse GetHourAndMinutes()
		{
			return new TimeResponse(GetValidHourInput(), GetValidMinutesInput());
		}

		public double CalculateAngleBetweenHourAndMinuteHand(AngleCalculationRequest request)
		{
			double hourHandAngle = CalculateHourHandAngle(request.Hour, request.Minutes);
			double minuteHandAngle = CalculateMinuteHandAngle(request.Minutes);

			double angleBetweenHands = CalculateAngleBetweenHourAndMinuteHand(hourHandAngle, minuteHandAngle);
			return GetLowerAngle(angleBetweenHands);
		}

		private int GetValidHourInput()
		{
			return GetValidIntInput("Enter hours (1-12):", (int)TimeRange.MinHour, (int)TimeRange.MaxHour);
		}

		private int GetValidMinutesInput()
		{
			return GetValidIntInput("Enter minutes (0-59):", (int)TimeRange.MinMinute, (int)TimeRange.MaxMinute);
		}

		private string? GetInput(string request)
		{
			Console.WriteLine(request);
			return Console.ReadLine();
		}

		private int GetValidIntInput(string request, int minValue, int maxValue)
		{
			int input;
			while (!int.TryParse(GetInput(request), out input) || input < minValue || input > maxValue)
			{
				Console.WriteLine("Invalid input. Please enter a number between " + minValue + " and " + maxValue + ".");
			}
			return input;
		}

		private double CalculateHourHandAngle(int hour, int minutes)
		{
			return HOUR_HAND_MULTIPLIER * (MINUTES_PER_HOUR * hour + minutes);
		}

		private double CalculateMinuteHandAngle(int minutes)
		{
			return MINUTE_HAND_MULTIPLIER * minutes;
		}

		private double CalculateAngleBetweenHourAndMinuteHand(double hourAngle, double minuteAngle)
		{
			return Math.Abs(hourAngle - minuteAngle);
		}

		private double GetLowerAngle(double angle)
		{
			return Math.Min(angle, FULL_CIRCLE_DEGREES - angle);
		}
	}
}
