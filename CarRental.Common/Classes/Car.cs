using CarRental.Common.Classes;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Models;

public class Car : Vehicle
{
    public Car()
    {
        Wheels = 4;
    }
	public override string HowManyWheels()
	{
		return $"I have {Wheels} wheels sinces im a Car";
	}
}
