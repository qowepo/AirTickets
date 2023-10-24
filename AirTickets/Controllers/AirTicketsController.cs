using AirTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AirTickets.Controllers
{
	public class AirTicketsController : Controller
	{
		private readonly ILogger<AirTicketsController> _logger;
		private DBContext db;
		
		public AirTicketsController(DBContext context, ILogger<AirTicketsController> logger)
		{
			db = context;
			_logger = logger;
		}

		public class AllData
		{
			public AirTicket AirTicket { get; set; }
			public List<Passenger> Passengers { get; set; }
			public List<Document> Documents { get; set; }
		}

		public IActionResult Reading()
		{
			return View();
		}

		public IActionResult Editing()
		{
			return View();
		}

		public IActionResult Deleting()
		{
			return View();
		}

		public async Task<List<AirTicket>> GetAirTickets()
		{
			List<AirTicket> tickets = new List<AirTicket>();
			try
			{
				tickets = await db.AirTicket.ToListAsync();
				tickets = tickets != null ? tickets : new List<AirTicket>();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return tickets;
		}

		public async Task<List<Passenger>> GetPassenger(string orderNumber)
		{			
			List<Passenger> passenger = new List<Passenger>();
			try
			{
				 passenger = await db.AirTicketPassenger
					.Where(x => x.Ticket.OrderNumber == orderNumber)
					.Select(x => x.Passenger).ToListAsync();
				passenger = passenger != null ? passenger : new List<Passenger>();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return passenger;
		}

		public async Task<List<Document>> GetDocument(string lastName, string firstName, string patronymic)
		{			
			List<Document> document = new List<Document>();
			try
			{
				document = await db.Document
				   .Where(x => x.Passenger.LastName == lastName 
					&& x.Passenger.FirstName == firstName
					&& x.Passenger.Patronymic == patronymic).ToListAsync();
				document = document != null ? document : new List<Document>();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return document;
		}
		public async Task<AllData> GetAllData(string orderNumber)
		{
			AllData allData = new AllData();
			
			try
			{
				allData.AirTicket = await db.AirTicket.Where(x => x.OrderNumber == orderNumber).FirstOrDefaultAsync();

				if(allData.AirTicket != null)
				{
					allData.Passengers = await db.AirTicketPassenger
						.Where(x => x.TicketId == allData.AirTicket.TicketId)
						.Select(x => x.Passenger).ToListAsync();
					if (allData.Passengers != null)
					{
						allData.Documents = await db.Document
							.Where(x => allData.Passengers.Select(y => y.PassengerId).Contains(x.PassengerId))
							.ToListAsync();
					}
				}				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return allData;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}