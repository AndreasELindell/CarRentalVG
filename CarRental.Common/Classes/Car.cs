using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Models
{
	public class Car : IVehicle
	{
		public int Id { get; set; }
		public static int NextId;
		public string? RegNo { get; set; }
		public string? Make { get; set; }
		public int Odometer { get; set; }
		public int CostKM { get; set; }
		public int CostPerDay { get; set; }
		public VehicleTypes VehicleType { get; set; }
		public VehicleStatuses VehicleStatus { get; set; }
        public Car()
        {
            Id = Interlocked.Increment(ref NextId);
        }
    }
}
