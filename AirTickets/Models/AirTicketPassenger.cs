using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirTickets.Models
{
	public class AirTicketPassenger
	{
		[Key]
		[ForeignKey("Ticket")]
		public int TicketId { get; set; }
		[ForeignKey("Passenger")]
		public int PassengerId { get; set; }
		public AirTicket Ticket { get; set; }
		public Passenger Passenger { get; set; }		
	}
}
