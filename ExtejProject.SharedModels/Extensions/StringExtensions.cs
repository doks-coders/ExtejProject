using System.Text.Json;

namespace ExtejProject.SharedModels.Extensions
{
	public static class StringExtensions
	{
		public class Intervals
		{
			public double hour { get; set; }
			public double rate { get; set; }
		}

		//This gets the current price from the last index, which should be the most recent change in price
		public static double GetCurrentPrice(this string intervalsString)
		{
			var intervals = JsonSerializer.Deserialize<List<Intervals>>(intervalsString);
			var lastinterval = intervals[intervals.Count - 1];
	
			return lastinterval.rate;
		}

		//This get change rate which is the rate change between the last price and the prior price
		public static double GetChangeRate(this string intervalsString)
		{
			var intervals = JsonSerializer.Deserialize<List<Intervals>>(intervalsString);
			var lastinterval = intervals[intervals.Count - 1];
			var secondToLast = intervals[intervals.Count - 2];

			double diff = lastinterval.rate - secondToLast.rate;
			double changeRate = (diff/secondToLast.rate) * 100;
			return changeRate;
		}

		//This gets the rate change fromthe 24th price and the recent price.
		public static double GetChangeRate24hr(this string intervalsString)
		{
			var allHours = 25;
			var intervals = JsonSerializer.Deserialize<List<Intervals>>(intervalsString);
			var lastinterval = intervals[intervals.Count - 1];
			var _24HrInterval = intervals.Where(u=>u.hour== allHours-24).FirstOrDefault();
			double diff = lastinterval.rate - _24HrInterval.rate;
			double changeRate = (diff / _24HrInterval.rate) * 100;
			return changeRate;
		}
		//This gets the rate change fromthe 7th price and the recent price.
		public static double GetChangeRate7hr(this string intervalsString)
		{
			var allHours = 25;
			var intervals = JsonSerializer.Deserialize<List<Intervals>>(intervalsString);
			var lastinterval = intervals[intervals.Count - 1];
			var _7HrInterval = intervals.Where(u => u.hour == allHours - 7).FirstOrDefault();
			double diff = lastinterval.rate - _7HrInterval.rate;
			double changeRate = (diff / _7HrInterval.rate) * 100;
			return changeRate;
		}
	}
}
