using CarRental.Common.Interfaces;
using CarRental.Common.Models;
using CarRental.Data.Interfaces;

namespace CarRental.Data.Classes
{
	public class Data : IData
	{
		readonly List<IPerson> _people = new();
		readonly List<IBooking> _bookings = new();
		readonly List<IVehicle> _vehicles = new();

		public Data() => SeedData();

		void SeedData()
		{
			//Vehicles
			Car car1 = new() { RegNo = "ABC123", Make = "Volvo", Odometer = 10000, CostKM = 10, CostPerDay = 500, VehicleStatus = Common.Enums.VehicleStatuses.Available, VehicleType = Common.Enums.VehicleTypes.Combi };
			Car car2 = new() { RegNo = "BCD234", Make = "Ford", Odometer = 20000, CostKM = 20, CostPerDay = 1000, VehicleStatus = Common.Enums.VehicleStatuses.Available, VehicleType = Common.Enums.VehicleTypes.Van };
			Car car3 = new() { RegNo = "CDE345", Make = "Tesla", Odometer = 30000, CostKM = 5, CostPerDay = 200, VehicleStatus = Common.Enums.VehicleStatuses.Booked, VehicleType = Common.Enums.VehicleTypes.Sedan };
			Motorcycle motorcycle1 = new() { RegNo = "DEF456", Make = "Yamaha", Odometer = 5000, CostKM = 5, CostPerDay = 100, VehicleStatus = Common.Enums.VehicleStatuses.Available, VehicleType = Common.Enums.VehicleTypes.MotorCycle };
			Motorcycle motorcycle2 = new() { RegNo = "DEF456", Make = "Yamaha", Odometer = 5000, CostKM = 5, CostPerDay = 100, VehicleStatus = Common.Enums.VehicleStatuses.Available, VehicleType = Common.Enums.VehicleTypes.MotorCycle };
			_vehicles.Add(car1);
			_vehicles.Add(car2);
			_vehicles.Add(car3);
			_vehicles.Add(motorcycle1);
			_vehicles.Add(motorcycle2);
			//People
			Customer customer1 = new() { SSN = 1234567, FirstName = "Sven", LastName = "Svensson" };
			Customer customer2 = new() { SSN = 7654321, FirstName = "Julia", LastName = "Juliadotter" };
			_people.Add(customer1);
			_people.Add(customer2);
			//Bookings
			Booking booking1 = new() { Start = DateTime.Now, RentedBy = customer1, Vehicle = car3, Status = Common.Enums.BookingStatus.Open };
			Booking booking2 = new() { Start = DateTime.Now.AddDays(-5), End = DateTime.Now, KMrented = 9500, KMreturned = 10000, Cost = 5000 , RentedBy = customer2, Vehicle = car1, Status = Common.Enums.BookingStatus.Closed };
			Booking booking3 = new() { Start = DateTime.Now.AddDays(-5), End = DateTime.Now, KMrented = 9500, KMreturned = 10000, Cost = 5000, RentedBy = customer2, Vehicle = car1, Status = Common.Enums.BookingStatus.Closed };
			_bookings.Add(booking1);
			_bookings.Add(booking2);
			_bookings.Add(booking3);
		}
		public IEnumerable<IBooking> GetBookings() => _bookings;

		public IEnumerable<IPerson> GetPersons() => _people;

		public IEnumerable<IVehicle> GetVehicles() => _vehicles;
	}
}
