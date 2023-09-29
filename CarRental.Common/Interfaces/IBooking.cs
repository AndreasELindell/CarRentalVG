using CarRental.Common.Enums;

namespace CarRental.Common.Interfaces;

public interface IBooking
{
	public int Id { get; set; }
	public DateTime Start { get; set; }
	public DateTime End { get; set; }
	public TimeSpan Duration { get; set; }
	public int KMrented { get; set; }
	public int KMreturned { get; set; }
	public int Cost { get; set; }
	public IPerson RentedBy { get; set; }
	public IVehicle Vehicle { get; set; }
	public BookingStatus Status { get; set; }
}
