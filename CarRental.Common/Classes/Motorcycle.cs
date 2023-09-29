using CarRental.Common.Classes;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Models;

public class Motorcycle : Vehicle
{
    public Motorcycle()
    {
        Wheels = 2;
    }

    public override string HowManyWheels() 
    {
        return $"I have {Wheels} wheels sinces im a MC";
    }
}
