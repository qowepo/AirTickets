using System.ComponentModel.DataAnnotations;

namespace AirTickets.Models
{
	public class Document
	{
		[Key]
		public int DocumentId { get; set; }
		public string DocumentType { get; set; }
		public string DocumentNumber { get; set; }
		public int PassengerId { get; set; }
		public Passenger Passenger { get; set; }
	}
}
