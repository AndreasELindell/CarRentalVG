using CarRental.Common.Enums;
using CarRental.Common.Extensions;
using CarRental.Common.Interfaces;
using CarRental.Common.Models;
using CarRental.Data.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace CarRental.Business.Services;

public class CarRentalService
{
	private readonly IData _data;

	//Processing Booking
	public bool isLoading = false;
	public string taskLoading => isLoading ? "display: block;" : "display: none;";
	public string LockTable => isLoading ? "pointer-events: none; opacity: 0.5; filter: grayscale(50%);" : "pointer-events: default; opacity: default; filter: default";

	//Input Error
	public bool error = false;
	public string errorShow => error ? "display: block;" : "display: none;";
	public string? errorMessage;

	//New Car properties
	public string? RegNo;
	public string? Make;
	public int Odometer;
	public int CostKM;
	public int CostPerDay;
	public VehicleTypes type;

	//New Costumer
	public Customer newCustomer = new();

	//Parameters for closing booking
	public int addedKM;
	public int customerId; 

    public async Task FakeDelayReturnCar(IVehicle vehicle)
	{
		if (!isLoading)
		{
			try
			{
				isLoading = true;
				await Task.Delay(TimeSpan.FromSeconds(2));
				await ReturnCarAsync(vehicle, addedKM);

				addedKM = 0;
				isLoading = false;
			}
			catch
			{
				error = true;
				errorMessage = "Something went wrong, try again";
				await Task.Delay(TimeSpan.FromSeconds(5));
				error = false;
				throw;
			}
		}
	}
	public async Task CheckInputAddPerson()
	{
		if (!(String.IsNullOrEmpty(newCustomer.FirstName) && String.IsNullOrEmpty(newCustomer.LastName)) && newCustomer.SSN > 0)
		{
			error = false;
			AddPerson(newCustomer);
		}
		else
		{
			error = true;
			errorMessage = "You need all Person fields to be valid";
			await Task.Delay(TimeSpan.FromSeconds(5));
			error = false;
		}
	}

	public async Task CheckInputAddVehicle()
	{
		if (!(String.IsNullOrEmpty(RegNo) && String.IsNullOrEmpty(Make)) && CostKM > 0 && CostPerDay > 0)
		{
			error = false;
			AddVehicle(RegNo.ToUpper(), Char.ToUpper(Make.First()) + Make.Substring(1).ToLower(), Odometer, CostKM, CostPerDay, type);
		}
		else
		{
			error = true;
			errorMessage = "You need all Vehicle fields to be valid";
			await Task.Delay(TimeSpan.FromSeconds(5));
			error = false;
		}
	}

	public async Task FakeDelayRentCar(IVehicle vehicle)
	{
		if (customerId < 1)
		{
			error = true;
			errorMessage = "You need a valid customer to rent a car!";
			await Task.Delay(TimeSpan.FromSeconds(5));
			error = false;
		}
		if (!isLoading)
		{
			isLoading = true;
			await Task.Delay(TimeSpan.FromSeconds(5));
			await RentcarAsync(vehicle, customerId);

			customerId = 0;
			isLoading = false;
		}
	}


	public CarRentalService(IData data)
	{
		_data = data;
	}
	public IEnumerable<IBooking> GetBookings()
	{
		return _data.Get<IBooking>(null);
	}
	public IEnumerable<IPerson> GetPeople()
	{
		return _data.Get<IPerson>(null);
	}
	public IEnumerable<IVehicle> GetVehicles()
	{
		return _data.Get<IVehicle>(null);
	}
	public IBooking GetBooking(int id) => _data.Single<IBooking>(b => b.Id == id);
	public IPerson GetPerson(int id) => _data.Single<IPerson>(b => b.Id == id);
	public IVehicle GetVehicle(int id) => _data.Single<IVehicle>(b => b.Id == id);
	public async Task RentcarAsync(IVehicle vehicle, int personid)
	{
		IPerson? person = _data.Get<IPerson>(null).FirstOrDefault(x => x.Id == personid);
		vehicle.VehicleStatus = VehicleStatuses.Booked;
		Booking booking = new()
		{
			Id = _data.Get<IBooking>(null).Max(x => x.Id) + 1,
			RentedBy = person,
			Start = DateTime.Now,
			KMrented = vehicle.Odometer,
			Status = BookingStatus.Open,
			Vehicle = vehicle,
		};
		await Task.Run(() => _data.Add<IBooking>(booking));
	}
	public async Task ReturnCarAsync(IVehicle vehicle, int addedKM)
	{
		IBooking? booking = _data.Get<IBooking>(null).LastOrDefault(x => x.Vehicle == vehicle);
		if (booking != null)
		{
			vehicle.Odometer += addedKM;
			vehicle.VehicleStatus = VehicleStatuses.Available;
			booking.End = DateTime.Now;
			booking.Duration = VehicleExtensions.Duration(booking.Start, booking.End);
			booking.KMreturned = booking.KMrented + addedKM;
			booking.Status = BookingStatus.Closed;
			int costkm = booking.Vehicle.CostKM * addedKM;

			int costday = booking.Vehicle.CostPerDay * booking.Duration.Days;
			if (booking.Duration.Days < 1)
			{
				costday = booking.Vehicle.CostPerDay;
			}
			if (costkm > costday)
			{
				booking.Cost = costkm;
			}
			else
			{
				booking.Cost = costday;
			}
			await Task.Run(() => _data.CloseBooking(booking));
		}
	}
	public void AddVehicle(string RegNo, string Make, int Odometer, int CostKM, int CostPerDay, VehicleTypes type)
	{
		if (type == VehicleTypes.MotorCycle)
		{
			Motorcycle motorcycle = new()
			{
				Id = _data.Get<IVehicle>(null).Max(x => x.Id) + 1,
				RegNo = RegNo,
				Make = Make,
				Odometer = Odometer,
				CostKM = CostKM,
				CostPerDay = CostPerDay,
				VehicleStatus = VehicleStatuses.Available,
				VehicleType = VehicleTypes.MotorCycle
			};
			_data.Add<IVehicle>(motorcycle);
		}
		else
		{
			Car newCar = new()
			{
				Id = _data.Get<IVehicle>(null).Max(x => x.Id) + 1,
				RegNo = RegNo,
				Make = Make,
				Odometer = Odometer,
				CostKM = CostKM,
				CostPerDay = CostPerDay,
				VehicleStatus = VehicleStatuses.Available,
				VehicleType = type,
			};
			_data.Add<IVehicle>(newCar);

		}
	}
	public void AddPerson(IPerson person)
	{
		Customer newPerson = new()
		{
			Id = _data.Get<IPerson>(null).Max(x => x.Id) + 1,
			SSN = person.SSN,
			FirstName = person.FirstName,
			LastName = person.LastName
		};
		_data.Add<IPerson>(newPerson);
	}
}
