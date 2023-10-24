using System.ComponentModel.DataAnnotations;

namespace AirTickets.Models
{
	public class AirTicket
	{
        [Key]
        public int TicketId { get; set; }
        public string DeparturePoint { get; set; }
        public string Destination { get; set; }
        public string OrderNumber { get; set; }
        public string ServiceProvider { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
