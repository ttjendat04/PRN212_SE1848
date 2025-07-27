using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;



namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly SportsBookingDbContext _context;
        public BookingRepository(SportsBookingDbContext context)
        {
            _context = context;
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public IEnumerable<Booking> GetAllBookings(bool includeUser = false)
        {
            if (includeUser)
                return _context.Bookings.Include(b => b.User).Include(b => b.Court).ToList();
            return _context.Bookings.ToList();
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings.FirstOrDefault(b => b.BookingId == id);
        }

        
    }
}
