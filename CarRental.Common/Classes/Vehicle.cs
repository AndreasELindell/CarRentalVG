using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Vehicle : IVehicle
{
	public int Id { get; set; }
	public string? RegNo { get; set; }
	public string? Make { get; set; }
	public int Odometer { get; set; }
	public int CostKM { get; set; }
	public int CostPerDay { get; set; }
	public int Wheels { get; set; }
	public VehicleTypes VehicleType { get; set; }
	public VehicleStatuses VehicleStatus { get; set; }

	public virtual string HowManyWheels() 
	{
		return $"I have some amount of wheels";
	}
}
