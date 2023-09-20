using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Models
{
	public class Booking : IBooking
	{
		public int Id { get; set; }
		static int NextId;
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public TimeSpan Duration { get; set; }
		public int KMrented { get; set; }
		public int KMreturned { get; set; }
		public int Cost { get; set; }
		public IPerson RentedBy { get; set; }
		public IVehicle Vehicle { get; set; }
		public BookingStatus Status { get; set; }
        public Booking()
        {
            Id = Interlocked.Increment(ref NextId);
			
        }
    }
}
