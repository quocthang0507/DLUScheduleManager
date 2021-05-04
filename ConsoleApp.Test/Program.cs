using DLUSchedule.Services;
using System;

namespace ConsoleApp.Test
{
	class Program
	{

		static void Main(string[] args)
		{
			MockSheduleData schedule = new MockSheduleData("2020-2021", "HK02", 19, "011.015.00007");
			Console.ReadKey();
		}
	}
}