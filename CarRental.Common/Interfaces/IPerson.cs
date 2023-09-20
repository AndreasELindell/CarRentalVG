using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces;

public interface IPerson
{
	public int Id { get; set; }
	public int SSN { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
}
