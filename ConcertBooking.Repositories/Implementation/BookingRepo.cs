﻿using ConcertBooking.Entities;
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
    public class BookingRepo : IBookingRepo
    {
        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAll(int ConcertId)
        {
            var bookings = await _context.Bookings.Include(b => b.Tickets)
                .Include(c=>c.Concert)
                .Include(u=>u.User).Where(b=>b.ConcertId == ConcertId).ToListAsync();
            return bookings;
        }
    }
}