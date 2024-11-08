using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using CSharpLearning.ConcertBooking.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Repositories.Implementation
{
    public class TicketRepo : ITicketRepo
    {
        private readonly ApplicationDbContext _context;

        public TicketRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<int>> GetBookedTicket(int id)
        {
            var bookedTicket = await _context.Tickets.Where(t=>t.ConcertId == id && t.IsBooked)
                .Select(t=>t.SeatNumber).ToListAsync();
            return bookedTicket;
        }
    }
}
