using System.ComponentModel.DataAnnotations;

namespace AirTickets.Models
{
	public class Passenger
	{
		[Key]
		public int PassengerId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Patronymic { get; set; }
	}
}
