using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Models;

public class Booking : IBooking
{
	public int Id { get; set; }
	public DateTime Start { get; set; }
	public DateTime End { get; set; }
	public TimeSpan Duration { get; set; }
	public int KMrented { get; set; }
	public int KMreturned { get; set; }
	public int Cost { get; set; }
	public required IPerson RentedBy { get; set; }
	public required IVehicle Vehicle { get; set; }
	public required BookingStatus Status { get; set; }
}
