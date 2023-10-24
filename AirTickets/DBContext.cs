using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirTickets.Models;
using Microsoft.EntityFrameworkCore;
public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
             : base(options)
    {
    }    

    public DbSet<AirTicket> AirTicket { get; set; }
    public DbSet<AirTicketPassenger> AirTicketPassenger { get; set; }
    public DbSet<Document> Document { get; set; }
    public DbSet<Passenger> Passenger { get; set; }
}

