using CarRental.Common.Interfaces;

namespace CarRental.Data.Interfaces;

public interface IData
{
    public IEnumerable<IVehicle> GetVehicles();
    public IEnumerable<IBooking> GetBookings();
    public IEnumerable<IPerson> GetPersons();
}
