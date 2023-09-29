using CarRental.Common.Interfaces;

namespace CarRental.Common.Models;

public class Customer : IPerson
{
	public int Id { get; set; }
	public int SSN { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
}
