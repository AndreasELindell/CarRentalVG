using CarRental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces;

    public interface IVehicle
    {
	public int Id { get; set; }
	static int NextId;
	public string? RegNo { get; set; }
	public string? Make { get; set; }
	public int Odometer { get; set; }
	public int CostKM { get; set; }
	public int CostPerDay { get; set; }
	public VehicleTypes VehicleType { get; set; }
	public VehicleStatuses VehicleStatus { get; set; }

}
