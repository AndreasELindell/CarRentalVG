using CarRental.Common.Interfaces;
using CarRental.Common.Models;
using CarRental.Data.Interfaces;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CarRental.Data.Classes;

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
		Motorcycle motorcycle2 = new() { RegNo = "EFG567", Make = "BMW", Odometer = 100, CostKM = 10, CostPerDay = 150, VehicleStatus = Common.Enums.VehicleStatuses.Available, VehicleType = Common.Enums.VehicleTypes.MotorCycle };
		_vehicles.Add(car1);
		_vehicles.Add(car2);
		_vehicles.Add(car3);
		_vehicles.Add(motorcycle1);
		_vehicles.Add(motorcycle2);
		//People
		Customer customer1 = new() { Id = 1, SSN = 1234567, FirstName = "Sven", LastName = "Svensson" };
		Customer customer2 = new() { Id = 2, SSN = 7654321, FirstName = "Julia", LastName = "Juliadotter" };
		_people.Add(customer1);
		_people.Add(customer2);
		//Bookings
		Booking booking1 = new() { Start = DateTime.Now, KMrented = 30000, RentedBy = customer1, Vehicle = car3, Status = Common.Enums.BookingStatus.Open };
		Booking booking2 = new() { Start = DateTime.Now.AddDays(-5), End = DateTime.Now, KMrented = 9500, KMreturned = 10000, Cost = 5000, RentedBy = customer2, Vehicle = car1, Status = Common.Enums.BookingStatus.Closed };
		_bookings.Add(booking1);
		_bookings.Add(booking2);
	}


	public List<T> Get<T>(Expression<Func<T, bool>>? expression)
	{
		List<T>? list = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>)).GetValue(this) as List<T>;

		if (expression != null)
		{
			try 
			{
				return list.Where(expression.Compile()).ToList();
			}
			catch (Exception)
			{
				throw;
			}
		}
		return list;

	}
	public T? Single<T>(Expression<Func<T, bool>>? expression)
	{
		List<T> list = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>)).GetValue(this) as List<T>;

		if(expression != null) 
		{
			try
			{
				return list.SingleOrDefault(expression.Compile());
			}
			catch (Exception)
			{

				throw;
			}
		}
		return default;
		
	}
	public void Add<T>(T item)
	{
		List<T>? list = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>)).GetValue(this) as List<T>;
		list.Add(item);

	}
	public void CloseBooking(IBooking booking)
	{
		var temp = _bookings.FirstOrDefault(x => x.Id == booking.Id);
		temp = booking;
	}
}
