using CarRental.Common.Interfaces;
using System.Linq.Expressions;

namespace CarRental.Data.Interfaces;

public interface IData
{
	public void CloseBooking(IBooking booking);
	public List<T> Get<T>(Expression<Func<T, bool>>? expression);
	public void Add<T>(T item);
}
