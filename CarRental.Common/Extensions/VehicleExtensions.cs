using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Extensions
{
	public static class VehicleExtensions
	{
		public static TimeSpan Duration(this DateTime start, DateTime End) 
		{
			return start - End;
		}
	}
}
