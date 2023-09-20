using CarRental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Models
{
	public class Customer : IPerson
	{
		public int Id { get; set ; }
		static int NextId;
		public int SSN { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public Customer()
        {
            Id = Interlocked.Increment(ref NextId);
        }
    }
}
