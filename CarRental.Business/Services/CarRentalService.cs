using CarRental.Common.Interfaces;
using CarRental.Common.Models;
using CarRental.Data.Interfaces;
using System.Runtime.Serialization;

namespace CarRental.Business.Services;

public class CarRentalService
{
	private readonly IData _data;

    public CarRentalService(IData data)
    {
        _data = data;
    }
    public IEnumerable<IBooking> GetBookings()
	{
		IEnumerable<IBooking> bookings = _data.GetBookings();
		return bookings;
	}

	public IEnumerable<IPerson> GetPeople()
	{
		IEnumerable<IPerson> people = _data.GetPersons();
		return people;
	}

	public IEnumerable<IVehicle> GetVehicles()
	{
		IEnumerable<IVehicle> vehicles = _data.GetVehicles();
		return vehicles;
	}
}
